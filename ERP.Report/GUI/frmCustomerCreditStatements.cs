using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using ERP.Report;
using ERP.Report.Com;
using ERP.Report.GV;
using ERP.Report.Logistic;
using ERP.Service;
using ERP.Domain;
using ERP.UI.Windows;
using ERP.UI.Windows.Reports;
using ERP.Utility;
using System.Collections;
using ERP.Report.Inventory;
using System.Reflection;
using ERP.Report.Inventory.Transactions.Reports;
using ERP.Report.GUI;
using ERP.Report.Inventory.Reference.Reports;

namespace ERP.Report.GUI
{
    public partial class frmCustomerCreditStatements : FrmBaseReportsForm
    {
        int documentID = 0;
        bool isValidControls = true;
        UserPrivileges accessRights = new UserPrivileges();
        private RadioButton RdoStockAging;
        private RadioButton RdoNon;
        private RadioButton RdoSlow;
        private RadioButton RdoFast;
        private Label lblDateRange;
        private DateTimePicker dtpFromDate;
        private Label lblLocation;
        private ComboBox cmbLocation;
        private DateTimePicker dtpToDate;
        private Label label1;
        private Label lblCustomer;
        private TextBox txtCustomer;
        private TextBox txtCustomerName;
        private CheckBox ChkAutoComplteCustomer;
        private CheckBox chkAllLocation;
        static string strReportName;
        private RadioButton rdoCredit;
        private RadioButton rdoSettlement;
        private RadioButton rdoStatements;
        private Panel grpHeader;


        List<Common.CheckedListBoxSelection> productExtendedPropertiesList = new List<Common.CheckedListBoxSelection>();

        public frmCustomerCreditStatements()
        {
            InitializeComponent();
        }

        public frmCustomerCreditStatements(string strFReportName)
        {
            InitializeComponent();
            strReportName = strFReportName;
        }

        
        public override void FormLoad()
        {
            try
            {

                LocationService locationService = new LocationService();
                Common.LoadLocations(cmbLocation, locationService.GetAllLocations());

                AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
                autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm(strReportName);

                documentID = autoGenerateInfo.DocumentID;
                accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);

                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();

                cmbLocation.SelectedValue = Common.LoggedLocationID;

                InvProductExtendedPropertyService invProductExtendedPropertyService = new InvProductExtendedPropertyService();
                productExtendedPropertiesList = CreateSelectionList(invProductExtendedPropertyService.GetInvProductExtendedPropertyNames());
                

                LoadSearchCodes();

                base.FormLoad();

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);

            }
        }

        private void LoadSearchCodes()
        {
            try
            {
                if (ChkAutoComplteCustomer.Checked) { LoadCustomer(); }
                

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


       

        private void LoadCustomer()
        {
            try
            {
                CustomerService customerService = new CustomerService();

                Common.SetAutoComplete(txtCustomer, customerService.GetAllCustomerCodes(), ChkAutoComplteCustomer.Checked);
                Common.SetAutoComplete(txtCustomerName, customerService.GetAllCustomerNames(), ChkAutoComplteCustomer.Checked);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

      

        public override void ClearForm()
        {
            try
            {
                base.ClearForm();

                Common.ClearComboBox(cmbLocation);
                cmbLocation.Focus();
                chkAllLocation.Checked = false;
                cmbLocation.SelectedValue = Common.LoggedLocationID;

                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();
                ChkAutoComplteCustomer.Checked = true;
                txtCustomer.Text = "";
                txtCustomerName.Text = "";
               

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateFrom;
                DateTime dateTo;

                int locationId = 0;
                int uniqueId = 0;
                int typeId = 0;
                int stockId = 0;
                int ReportType = 0;


                dateFrom = dtpFromDate.Value;
                dateTo= dtpToDate.Value;

                if (chkAllLocation.Checked == false)
                {
                    if (ValidateLocationComboBoxes().Equals(false)) { return; }
                }
            
                

                if (ValidateControls() == false) return;

                if (dateFrom > dateTo)
                {
                    Toast.Show(this.Text,"","", Toast.messageType.Information, Toast.messageAction.InvalidDate);
                    return;
                }

                locationId = cmbLocation.SelectedIndex + 1;

                typeId = 2;

                this.Cursor = Cursors.WaitCursor;

                CustomerCreditStatementsService customerCreditStatementsService = new CustomerCreditStatementsService();
                Location location = new Location();
                LocationService locationService = new LocationService();
                //location=locationService.GetLocationsByID(Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()));

                
                 if (chkAllLocation.Checked == true) { locationId = 0; } else { locationId = cmbLocation.SelectedIndex + 1; }

                
                 if (rdoCredit.Checked == true) { ReportType = 1; }
                 if (rdoSettlement.Checked == true) { ReportType = 2; }

                 if (customerCreditStatementsService.ViewReport(locationId, dtpFromDate.Value, dtpToDate.Value, txtCustomer.Text.Trim(),ReportType))
                 {
                     ViewReport();
                     this.Cursor = Cursors.Default;
                 }
                 else
                 {
                     Toast.Show(this.Text, "No Data to view", "", Toast.messageType.Information, Toast.messageAction.NotFound);
                     this.Cursor = Cursors.Default;
                     return;
                 }

                // ClearForm();
            }

            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private bool ValidateLocationComboBoxes()
        {
            return Validater.ValidateComboBox(this.Text, errorProvider, Validater.ValidateType.Empty, cmbLocation);
        }

        private bool ValidateControls()
        {
            if (!Validater.ValidateTextBox(this.Text, errorProvider, Validater.ValidateType.Empty, txtCustomer))
            { return false; }

            else
            {
                isValidControls = true;
                this.ValidateChildren();

                return isValidControls;
            }
        }
        
        private void ViewReport()
        {

            FrmReportViewer reportViewer = new FrmReportViewer();
            CustomerCreditStatementsService customerCreditStatementsService = new CustomerCreditStatementsService();

            InvRptCustomerCredit invRptCustomerCredit = new InvRptCustomerCredit();
            InvRptCustomerSettlement invRptCustomerSettlement = new InvRptCustomerSettlement();

            DataTable dt = customerCreditStatementsService.GetCustomerCreditStatements();
            if (rdoCredit.Checked == true)
            {

                invRptCustomerCredit.SetDataSource(customerCreditStatementsService.GetCustomerCreditStatements());

                invRptCustomerCredit.SummaryInfo.ReportTitle = "Customer Credit Report";
                invRptCustomerCredit.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                invRptCustomerCredit.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
                invRptCustomerCredit.DataDefinition.FormulaFields["Customer"].Text = "'" + txtCustomer.Text.Trim() + "   " + txtCustomerName.Text.Trim() + "'";
                invRptCustomerCredit.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                invRptCustomerCredit.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptCustomerCredit.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                invRptCustomerCredit.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                reportViewer.crRptViewer.ReportSource = invRptCustomerCredit;
                reportViewer.WindowState = FormWindowState.Maximized;
                reportViewer.Show();
                Cursor.Current = Cursors.Default;
            }

            if (rdoSettlement.Checked == true)
            {

                invRptCustomerSettlement.SetDataSource(customerCreditStatementsService.GetCustomerCreditStatements());

                invRptCustomerSettlement.SummaryInfo.ReportTitle = "Customer Settlement Report";
                invRptCustomerSettlement.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                invRptCustomerSettlement.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
                invRptCustomerSettlement.DataDefinition.FormulaFields["Customer"].Text = "'" + txtCustomer.Text.Trim() + "   " + txtCustomerName.Text.Trim() + "'";
                invRptCustomerSettlement.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                invRptCustomerSettlement.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptCustomerSettlement.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                invRptCustomerSettlement.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                reportViewer.crRptViewer.ReportSource = invRptCustomerSettlement;
                reportViewer.WindowState = FormWindowState.Maximized;
                reportViewer.Show();
                Cursor.Current = Cursors.Default;
            }

        }



        public override void Print()
        {
            PrintCustomerCreditStatements();



        }


        public void PrintCustomerCreditStatements()
        {
            try
            {
                DateTime dateFrom;
                DateTime dateTo;

                int locationId = 0;
                int uniqueId = 0;
                int typeId = 0;
                int stockId = 0;
                int ReportType = 0;


                dateFrom = dtpFromDate.Value;
                dateTo = dtpToDate.Value;


                if (ValidateLocationComboBoxes().Equals(false)) { return; }


                if (ValidateControls() == false) return;

                if (dateFrom > dateTo)
                {
                    Toast.Show(this.Text, "", "", Toast.messageType.Information, Toast.messageAction.InvalidDate);
                    return;
                }

                locationId = cmbLocation.SelectedIndex + 1;

                typeId = 2;

                this.Cursor = Cursors.WaitCursor;

                CustomerCreditStatementsService customerCreditStatementsService = new CustomerCreditStatementsService();
                Location location = new Location();
                LocationService locationService = new LocationService();
                location = locationService.GetLocationsByID(Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()));


                if (chkAllLocation.Checked == true) { locationId = 0; } else { locationId = cmbLocation.SelectedIndex + 1; }

                if (rdoSettlement.Checked == true) { ReportType = 1; }
                if (rdoCredit.Checked == true) { ReportType = 2; } 


                if (customerCreditStatementsService.ViewReport(locationId, dtpFromDate.Value, dtpToDate.Value, txtCustomer.Text.Trim(),ReportType))
                {
                    PrintReport();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    Toast.Show(this.Text, "No Data to view", "", Toast.messageType.Information, Toast.messageAction.NotFound);
                    this.Cursor = Cursors.Default;
                    return;
                }
            }

            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        private void PrintReport()
        {

            FrmReportViewer reportViewer = new FrmReportViewer();
            CustomerCreditStatementsService customerCreditStatementsService = new CustomerCreditStatementsService();

            InvRptCustomerCredit invRptCustomerCredit = new InvRptCustomerCredit();
            InvRptCustomerSettlement invRptCustomerSettlement = new InvRptCustomerSettlement();

            DataTable dt = customerCreditStatementsService.GetCustomerCreditStatements();
            if (rdoCredit.Checked == true)
            {

                invRptCustomerCredit.SetDataSource(customerCreditStatementsService.GetCustomerCreditStatements());

                invRptCustomerCredit.SummaryInfo.ReportTitle = "Customer Credit Report";
                invRptCustomerCredit.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                invRptCustomerCredit.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
                invRptCustomerCredit.DataDefinition.FormulaFields["Customer"].Text = "'" + txtCustomer.Text.Trim() + "   " + txtCustomerName.Text.Trim() + "'";
                invRptCustomerCredit.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                invRptCustomerCredit.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptCustomerCredit.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                invRptCustomerCredit.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                reportViewer.crRptViewer.ReportSource = invRptCustomerCredit;
                reportViewer.WindowState = FormWindowState.Maximized;
                reportViewer.Show();
                Cursor.Current = Cursors.Default;
            }

            if (rdoSettlement.Checked == true)
            {

                invRptCustomerSettlement.SetDataSource(customerCreditStatementsService.GetCustomerCreditStatements());

                invRptCustomerSettlement.SummaryInfo.ReportTitle = "Customer Settlement Report";
                invRptCustomerSettlement.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                invRptCustomerSettlement.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
                invRptCustomerSettlement.DataDefinition.FormulaFields["Customer"].Text = "'" + txtCustomer.Text.Trim() + "   " + txtCustomerName.Text.Trim() + "'";
                invRptCustomerSettlement.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                invRptCustomerSettlement.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptCustomerSettlement.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                invRptCustomerSettlement.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                reportViewer.crRptViewer.ReportSource = invRptCustomerSettlement;
                reportViewer.WindowState = FormWindowState.Maximized;
                reportViewer.Show();
                Cursor.Current = Cursors.Default;
            }

        }
        

        private void InitializeComponent()
        {
            this.RdoNon = new System.Windows.Forms.RadioButton();
            this.RdoSlow = new System.Windows.Forms.RadioButton();
            this.RdoFast = new System.Windows.Forms.RadioButton();
            this.RdoStockAging = new System.Windows.Forms.RadioButton();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.ChkAutoComplteCustomer = new System.Windows.Forms.CheckBox();
            this.chkAllLocation = new System.Windows.Forms.CheckBox();
            this.rdoStatements = new System.Windows.Forms.RadioButton();
            this.rdoCredit = new System.Windows.Forms.RadioButton();
            this.rdoSettlement = new System.Windows.Forms.RadioButton();
            this.grpHeader = new System.Windows.Forms.Panel();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grpHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(324, 178);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Controls.Add(this.RdoStockAging);
            this.grpButtonSet.Controls.Add(this.RdoFast);
            this.grpButtonSet.Controls.Add(this.RdoSlow);
            this.grpButtonSet.Controls.Add(this.RdoNon);
            this.grpButtonSet.Location = new System.Drawing.Point(2, 178);
            this.grpButtonSet.Controls.SetChildIndex(this.RdoNon, 0);
            this.grpButtonSet.Controls.SetChildIndex(this.RdoSlow, 0);
            this.grpButtonSet.Controls.SetChildIndex(this.RdoFast, 0);
            this.grpButtonSet.Controls.SetChildIndex(this.RdoStockAging, 0);
            this.grpButtonSet.Controls.SetChildIndex(this.btnHelp, 0);
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // RdoNon
            // 
            this.RdoNon.AutoSize = true;
            this.RdoNon.Location = new System.Drawing.Point(591, -2);
            this.RdoNon.Name = "RdoNon";
            this.RdoNon.Size = new System.Drawing.Size(91, 17);
            this.RdoNon.TabIndex = 120;
            this.RdoNon.Tag = "1";
            this.RdoNon.Text = "Non Moving";
            this.RdoNon.UseVisualStyleBackColor = true;
            this.RdoNon.Visible = false;
            // 
            // RdoSlow
            // 
            this.RdoSlow.AutoSize = true;
            this.RdoSlow.Location = new System.Drawing.Point(479, -2);
            this.RdoSlow.Name = "RdoSlow";
            this.RdoSlow.Size = new System.Drawing.Size(96, 17);
            this.RdoSlow.TabIndex = 119;
            this.RdoSlow.Tag = "1";
            this.RdoSlow.Text = "Slow Moving";
            this.RdoSlow.UseVisualStyleBackColor = true;
            this.RdoSlow.Visible = false;
            // 
            // RdoFast
            // 
            this.RdoFast.AutoSize = true;
            this.RdoFast.Location = new System.Drawing.Point(373, -2);
            this.RdoFast.Name = "RdoFast";
            this.RdoFast.Size = new System.Drawing.Size(92, 17);
            this.RdoFast.TabIndex = 118;
            this.RdoFast.Tag = "1";
            this.RdoFast.Text = "Fast Moving";
            this.RdoFast.UseVisualStyleBackColor = true;
            this.RdoFast.Visible = false;
            // 
            // RdoStockAging
            // 
            this.RdoStockAging.AutoSize = true;
            this.RdoStockAging.Location = new System.Drawing.Point(262, -2);
            this.RdoStockAging.Name = "RdoStockAging";
            this.RdoStockAging.Size = new System.Drawing.Size(93, 17);
            this.RdoStockAging.TabIndex = 117;
            this.RdoStockAging.Tag = "1";
            this.RdoStockAging.Text = "Stock Aging";
            this.RdoStockAging.UseVisualStyleBackColor = true;
            this.RdoStockAging.Visible = false;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(6, 23);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(74, 13);
            this.lblDateRange.TabIndex = 95;
            this.lblDateRange.Text = "Date Range";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(125, 17);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(133, 21);
            this.dtpFromDate.TabIndex = 96;
            this.dtpFromDate.Enter += new System.EventHandler(this.dtpFromDate_Enter);
            this.dtpFromDate.Leave += new System.EventHandler(this.dtpFromDate_Leave);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(6, 47);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(54, 13);
            this.lblLocation.TabIndex = 111;
            this.lblLocation.Text = "Location";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(125, 44);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(287, 21);
            this.cmbLocation.TabIndex = 110;
            this.cmbLocation.Click += new System.EventHandler(this.cmbLocation_Click);
            this.cmbLocation.Enter += new System.EventHandler(this.cmbLocation_Enter);
            this.cmbLocation.Leave += new System.EventHandler(this.cmbLocation_Leave);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(279, 17);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(133, 21);
            this.dtpToDate.TabIndex = 113;
            this.dtpToDate.Enter += new System.EventHandler(this.dtpToDate_Enter);
            this.dtpToDate.Leave += new System.EventHandler(this.dtpToDate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "-";
            this.label1.Visible = false;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(6, 79);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(63, 13);
            this.lblCustomer.TabIndex = 121;
            this.lblCustomer.Text = "Customer";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(125, 76);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(133, 21);
            this.txtCustomer.TabIndex = 123;
            this.txtCustomer.Enter += new System.EventHandler(this.txtCustomer_Enter);
            this.txtCustomer.Leave += new System.EventHandler(this.txtCustomer_Leave);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(261, 76);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(271, 21);
            this.txtCustomerName.TabIndex = 125;
            this.txtCustomerName.Enter += new System.EventHandler(this.txtCustomerName_Enter);
            this.txtCustomerName.Leave += new System.EventHandler(this.txtCustomerName_Leave);
            // 
            // ChkAutoComplteCustomer
            // 
            this.ChkAutoComplteCustomer.AutoSize = true;
            this.ChkAutoComplteCustomer.Location = new System.Drawing.Point(109, 79);
            this.ChkAutoComplteCustomer.Name = "ChkAutoComplteCustomer";
            this.ChkAutoComplteCustomer.Size = new System.Drawing.Size(15, 14);
            this.ChkAutoComplteCustomer.TabIndex = 127;
            this.ChkAutoComplteCustomer.Tag = "1";
            this.ChkAutoComplteCustomer.UseVisualStyleBackColor = true;
            this.ChkAutoComplteCustomer.CheckedChanged += new System.EventHandler(this.ChkAutoComplteCustomer_CheckedChanged);
            this.ChkAutoComplteCustomer.Enter += new System.EventHandler(this.ChkAutoComplteCustomer_Enter);
            this.ChkAutoComplteCustomer.Leave += new System.EventHandler(this.ChkAutoComplteCustomer_Leave);
            // 
            // chkAllLocation
            // 
            this.chkAllLocation.AutoSize = true;
            this.chkAllLocation.Location = new System.Drawing.Point(430, 48);
            this.chkAllLocation.Name = "chkAllLocation";
            this.chkAllLocation.Size = new System.Drawing.Size(91, 17);
            this.chkAllLocation.TabIndex = 129;
            this.chkAllLocation.Tag = "1";
            this.chkAllLocation.Text = "All Location";
            this.chkAllLocation.UseVisualStyleBackColor = true;
            this.chkAllLocation.CheckedChanged += new System.EventHandler(this.chkAllLocation_CheckedChanged);
            this.chkAllLocation.Enter += new System.EventHandler(this.chkAllLocation_Enter);
            this.chkAllLocation.Leave += new System.EventHandler(this.chkAllLocation_Leave);
            // 
            // rdoStatements
            // 
            this.rdoStatements.AutoSize = true;
            this.rdoStatements.Location = new System.Drawing.Point(287, 116);
            this.rdoStatements.Name = "rdoStatements";
            this.rdoStatements.Size = new System.Drawing.Size(90, 17);
            this.rdoStatements.TabIndex = 132;
            this.rdoStatements.TabStop = true;
            this.rdoStatements.Text = "Statements";
            this.rdoStatements.UseVisualStyleBackColor = true;
            this.rdoStatements.Visible = false;
            // 
            // rdoCredit
            // 
            this.rdoCredit.AutoSize = true;
            this.rdoCredit.Location = new System.Drawing.Point(64, 116);
            this.rdoCredit.Name = "rdoCredit";
            this.rdoCredit.Size = new System.Drawing.Size(60, 17);
            this.rdoCredit.TabIndex = 131;
            this.rdoCredit.TabStop = true;
            this.rdoCredit.Text = "Credit";
            this.rdoCredit.UseVisualStyleBackColor = true;
            // 
            // rdoSettlement
            // 
            this.rdoSettlement.AutoSize = true;
            this.rdoSettlement.Location = new System.Drawing.Point(170, 116);
            this.rdoSettlement.Name = "rdoSettlement";
            this.rdoSettlement.Size = new System.Drawing.Size(87, 17);
            this.rdoSettlement.TabIndex = 130;
            this.rdoSettlement.TabStop = true;
            this.rdoSettlement.Text = "Settlement";
            this.rdoSettlement.UseVisualStyleBackColor = true;
            // 
            // grpHeader
            // 
            this.grpHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpHeader.Controls.Add(this.rdoStatements);
            this.grpHeader.Controls.Add(this.rdoCredit);
            this.grpHeader.Controls.Add(this.lblDateRange);
            this.grpHeader.Controls.Add(this.rdoSettlement);
            this.grpHeader.Controls.Add(this.dtpFromDate);
            this.grpHeader.Controls.Add(this.chkAllLocation);
            this.grpHeader.Controls.Add(this.lblLocation);
            this.grpHeader.Controls.Add(this.ChkAutoComplteCustomer);
            this.grpHeader.Controls.Add(this.cmbLocation);
            this.grpHeader.Controls.Add(this.txtCustomerName);
            this.grpHeader.Controls.Add(this.dtpToDate);
            this.grpHeader.Controls.Add(this.txtCustomer);
            this.grpHeader.Controls.Add(this.label1);
            this.grpHeader.Controls.Add(this.lblCustomer);
            this.grpHeader.Location = new System.Drawing.Point(5, 5);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(554, 165);
            this.grpHeader.TabIndex = 154;
            // 
            // frmCustomerCreditStatements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(564, 227);
            this.Controls.Add(this.grpHeader);
            this.Name = "frmCustomerCreditStatements";
            this.Text = "Customer Wise Report";
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.grpHeader, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            this.grpButtonSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        private void cmbLocation_Click(object sender, EventArgs e)
        {

        }

     

      

        private void chkAllLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllLocation.Checked == true)
            {
                Common.ClearComboBox(cmbLocation);
                cmbLocation.Enabled = false;
            }
            else
            {
                cmbLocation.Enabled = true;
                //ChkLocationWise.Checked = false;
            }
        }

       

      

      
        private void chkLstProductExtendedProperties_ItemCheck(object sender, ItemCheckEventArgs e)
        {
              try
            {
                var item = (CheckedListBox)sender;
                SetItemCheckedStatus(productExtendedPropertiesList, item.SelectedItem.ToString().Trim(), e.CurrentValue.Equals(CheckState.Checked) ? CheckState.Unchecked : CheckState.Checked);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }

        }

        private void SetItemCheckedStatus(List<Common.CheckedListBoxSelection> allValuesList, string checkedListBoxItem, CheckState checkState)
        {
            foreach (var item in allValuesList.Where(v => v.Value == checkedListBoxItem.Trim()))
            {
                item.isChecked = checkState;
            }
        }

        private List<Common.CheckedListBoxSelection> SearchList(List<Common.CheckedListBoxSelection> inList, string searchString)
        {
            return inList.Where(c => c.Value.ToLower().StartsWith(searchString.ToLower().Trim())).ToList();
        }

        private void RefreshCheckedList(CheckedListBox checkedListBox, List<Common.CheckedListBoxSelection> allValuesList)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (allValuesList.Any(a => a.Value.Equals(checkedListBox.Items[i].ToString().Trim()) && a.isChecked.Equals(CheckState.Checked)))
                {
                    checkedListBox.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBox.SetItemChecked(i, false);
                }
            }
        }

        private List<Common.CheckedListBoxSelection> CreateSelectionList(string[] inArray)
        {
            List<Common.CheckedListBoxSelection> selectionDataStruct = new List<Common.CheckedListBoxSelection>();

            foreach (var item in inArray)
            {
                selectionDataStruct.Add(new Common.CheckedListBoxSelection() { Value = item.ToString().Trim(), isChecked = CheckState.Unchecked });
            }
            return selectionDataStruct;
        }

        private void dtpFromDate_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblDateRange);
        }

        private void dtpFromDate_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblDateRange);
        }

        private void dtpToDate_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblDateRange);
        }

        private void dtpToDate_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblDateRange);
        }

        private void cmbLocation_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblLocation);
        }

        private void cmbLocation_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblLocation);
        }

        private void chkAllLocation_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(chkAllLocation);
        }

        private void chkAllLocation_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(chkAllLocation);
        }

      
    
  

        private void txtCustomer_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(lblCustomer);
                if (string.IsNullOrEmpty(txtCustomer.Text.Trim())) { return; }


                CustomerService customerService = new CustomerService();
                Customer customer = new Customer();

                customer = customerService.GetCustomersByCode(txtCustomer.Text.Trim());

                if (customer != null)
                {
                    txtCustomer.Text = customer.CustomerCode;
                    txtCustomerName.Text = customer.CustomerName;
                }


            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(lblCustomer);
                if (string.IsNullOrEmpty(txtCustomerName.Text.Trim())) { return; }

                CustomerService customerService = new CustomerService();
                Customer customer = new Customer();

                customer = customerService.GetCustomersByName(txtCustomerName.Text.Trim());

                if (customer != null)
                {
                    txtCustomer.Text = customer.CustomerCode;
                    txtCustomerName.Text = customer.CustomerName;
                }


            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtCustomer_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblCustomer);
        }

        private void txtCustomerName_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblCustomer);
        }

        private void ChkAutoComplteCustomer_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblCustomer);
        }

        private void ChkAutoComplteCustomer_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblCustomer);
        }

        private void ChkAutoComplteCustomer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAutoComplteCustomer.Checked)
                {
                    LoadCustomer();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

       


    }
}
