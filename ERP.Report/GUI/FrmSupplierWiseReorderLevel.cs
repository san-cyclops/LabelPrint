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
using ERP.Report.Inventory.Transactions.Reports;
using ERP.Report.Logistic;
using ERP.Service;
using ERP.Domain;
using ERP.UI.Windows;
using ERP.UI.Windows.Reports;
using ERP.Utility;
using System.Collections;
using ERP.Report.Inventory;
using System.Reflection;
using ERP.Report.GUI;
using ERP.Report.Inventory.Reference.Reports;

namespace ERP.Report.GUI
{
    public partial class FrmSupplierWiseReorderLevelProduct : FrmBaseReportsForm
    {
        int documentID = 0;
        bool isValidControls = true;
        UserPrivileges accessRights = new UserPrivileges();
        private RadioButton RdoStockAging;
        private RadioButton RdoNon;
        private RadioButton RdoSlow;
        private RadioButton RdoFast;
        private Label label2;
        private RadioButton RdoValue;
        private RadioButton RdoQty;
        private RadioButton RdoGp;
        private RadioButton RdoStockSales;
        private GroupBox groupBox2;
        private Label lblDateRange;
        private DateTimePicker dtpFromDate;
        private Label lblLocation;
        private ComboBox cmbLocation;
        private DateTimePicker dtpToDate;
        private Label label1;
        private Label lblSupplierFrom;
        private Label lblSupplierTo;
        private TextBox txtSupplierCodeFrom;
        private TextBox txtSupplierCodeTo;
        private TextBox txtSuppilerNameFrom;
        private TextBox txtSupplierNameTo;
        private CheckBox ChkAutoComplteSupplierFrom;
        private CheckBox ChkAutoComplteSupplierTo;
        private CheckBox chkAllLocation;
        static string strReportName;
        private Panel grpHeader;


        List<Common.CheckedListBoxSelection> productExtendedPropertiesList = new List<Common.CheckedListBoxSelection>();

        public FrmSupplierWiseReorderLevelProduct()
        {
            InitializeComponent();
        }

        public FrmSupplierWiseReorderLevelProduct(string strFReportName)
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
            

                if (ChkAutoComplteSupplierFrom.Checked) { LoadSuppierFrom(); }
                if (ChkAutoComplteSupplierTo.Checked) { LoadSuppierTo(); }
               

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


       

        private void LoadSuppierFrom()
        {
            try
            {
                SupplierService supplierService = new SupplierService();

                Common.SetAutoComplete(txtSupplierCodeFrom, supplierService.GetAllSupplierCodes(), ChkAutoComplteSupplierFrom.Checked);
                Common.SetAutoComplete(txtSuppilerNameFrom, supplierService.GetAllSupplierNames(), ChkAutoComplteSupplierFrom.Checked);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void LoadSuppierTo()
        {
            try
            {
                SupplierService supplierService = new SupplierService();

                Common.SetAutoComplete(txtSupplierCodeTo, supplierService.GetAllSupplierCodes(), ChkAutoComplteSupplierTo.Checked);
                Common.SetAutoComplete(txtSupplierNameTo, supplierService.GetAllSupplierNames(), ChkAutoComplteSupplierTo.Checked);
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

                cmbLocation.SelectedValue = Common.LoggedLocationID;

                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();

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

                SupplierWiseReorderProductService supplierWiseReorderProductService = new SupplierWiseReorderProductService();
                Location location = new Location();
                LocationService locationService = new LocationService();
                //location=locationService.GetLocationsByID(Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()));

                
                 if (chkAllLocation.Checked == true) { locationId = 0; } else { locationId = cmbLocation.SelectedIndex + 1; }
                
                    if (supplierWiseReorderProductService.ViewReport(locationId,  dtpFromDate.Value, dtpToDate.Value, txtSupplierCodeFrom.Text.Trim(), txtSupplierCodeTo.Text.Trim()))
                 
                    {
                        ViewReport();
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        Toast.Show(this.Text, "No Data to view","", Toast.messageType.Information, Toast.messageAction.NotFound);
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

        private bool ValidateLocationComboBoxes()
        {
            return Validater.ValidateComboBox(this.Text, errorProvider, Validater.ValidateType.Empty, cmbLocation);
        }

        private bool ValidateControls()
        {
            if (!Validater.ValidateTextBox(this.Text, errorProvider, Validater.ValidateType.Empty, txtSupplierCodeFrom, txtSupplierCodeTo))
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
            SupplierWiseReorderProductService supplierWiseReorderProductService = new SupplierWiseReorderProductService();

            //InvRptSupplierWiseReorderProducts invRptSupplierWiseReorderProducts = new InvRptSupplierWiseReorderProducts();

            //DataTable dt = supplierWiseReorderProductService.GetSupplierWiseReorderLevelProduct();
            //invRptSupplierWiseReorderProducts.SetDataSource(supplierWiseReorderProductService.GetSupplierWiseReorderLevelProduct());

            //invRptSupplierWiseReorderProducts.SummaryInfo.ReportTitle = "Supplier Wise Reorder Products Reports";
            //invRptSupplierWiseReorderProducts.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["FromSupplier"].Text = "'" + txtSupplierCodeFrom.Text.Trim() + "   " + txtSuppilerNameFrom.Text.Trim() + "'";
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["ToSupplier"].Text = "'" + txtSupplierCodeTo.Text.Trim() + "   " + txtSupplierNameTo.Text.Trim() + "'";
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            //reportViewer.crRptViewer.ReportSource = invRptSupplierWiseReorderProducts;
            //reportViewer.WindowState = FormWindowState.Maximized;
            //reportViewer.Show();
            //Cursor.Current = Cursors.Default;

        }



        public override void Print()
        {
            PrintSupplierWiseProducts();



        }


        public void PrintSupplierWiseProducts()
        {
            try
            {
                DateTime dateFrom;
                DateTime dateTo;

                int locationId = 0;
                int uniqueId = 0;
                int typeId = 0;
                int stockId = 0;


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

                SupplierWiseReorderProductService supplierWiseReorderProductService = new SupplierWiseReorderProductService();
                Location location = new Location();
                LocationService locationService = new LocationService();
                location = locationService.GetLocationsByID(Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()));


                if (chkAllLocation.Checked == true) { locationId = 0; } else { locationId = cmbLocation.SelectedIndex + 1; }

                if (supplierWiseReorderProductService.ViewReport(locationId, dtpFromDate.Value, dtpToDate.Value, txtSupplierCodeFrom.Text.Trim(), txtSupplierCodeTo.Text.Trim()))
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
            SupplierWiseReorderProductService supplierWiseReorderProductService = new SupplierWiseReorderProductService();

            //InvRptSupplierWiseReorderProducts invRptSupplierWiseReorderProducts = new InvRptSupplierWiseReorderProducts();

            //DataTable dt = supplierWiseReorderProductService.GetSupplierWiseReorderLevelProduct();
            //invRptSupplierWiseReorderProducts.SetDataSource(supplierWiseReorderProductService.GetSupplierWiseReorderLevelProduct());

            //invRptSupplierWiseReorderProducts.SummaryInfo.ReportTitle = "Supplier Wise Reorder Products";
            //invRptSupplierWiseReorderProducts.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["FromSupplier"].Text = "'" + txtSupplierCodeFrom.Text.Trim() + "   " + txtSuppilerNameFrom.Text.Trim() + "'";
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["ToSupplier"].Text = "'" + txtSupplierCodeTo.Text.Trim() + "   " + txtSupplierNameTo.Text.Trim() + "'";
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            //invRptSupplierWiseReorderProducts.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            //reportViewer.crRptViewer.ReportSource = invRptSupplierWiseReorderProducts;
            //reportViewer.WindowState = FormWindowState.Maximized;
            //reportViewer.Show();
            //Cursor.Current = Cursors.Default;

        }
        

        private void InitializeComponent()
        {
            this.RdoNon = new System.Windows.Forms.RadioButton();
            this.RdoSlow = new System.Windows.Forms.RadioButton();
            this.RdoFast = new System.Windows.Forms.RadioButton();
            this.RdoStockAging = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.RdoValue = new System.Windows.Forms.RadioButton();
            this.RdoQty = new System.Windows.Forms.RadioButton();
            this.RdoGp = new System.Windows.Forms.RadioButton();
            this.RdoStockSales = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSupplierFrom = new System.Windows.Forms.Label();
            this.lblSupplierTo = new System.Windows.Forms.Label();
            this.txtSupplierCodeFrom = new System.Windows.Forms.TextBox();
            this.txtSupplierCodeTo = new System.Windows.Forms.TextBox();
            this.txtSuppilerNameFrom = new System.Windows.Forms.TextBox();
            this.txtSupplierNameTo = new System.Windows.Forms.TextBox();
            this.ChkAutoComplteSupplierFrom = new System.Windows.Forms.CheckBox();
            this.ChkAutoComplteSupplierTo = new System.Windows.Forms.CheckBox();
            this.chkAllLocation = new System.Windows.Forms.CheckBox();
            this.grpHeader = new System.Windows.Forms.Panel();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(330, 124);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Controls.Add(this.RdoStockAging);
            this.grpButtonSet.Controls.Add(this.RdoFast);
            this.grpButtonSet.Controls.Add(this.RdoSlow);
            this.grpButtonSet.Controls.Add(this.RdoNon);
            this.grpButtonSet.Location = new System.Drawing.Point(2, 124);
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
            this.RdoFast.Size = new System.Drawing.Size(91, 17);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "Based On";
            // 
            // RdoValue
            // 
            this.RdoValue.AutoSize = true;
            this.RdoValue.Location = new System.Drawing.Point(191, 23);
            this.RdoValue.Name = "RdoValue";
            this.RdoValue.Size = new System.Drawing.Size(56, 17);
            this.RdoValue.TabIndex = 122;
            this.RdoValue.Tag = "1";
            this.RdoValue.Text = "Value";
            this.RdoValue.UseVisualStyleBackColor = true;
            // 
            // RdoQty
            // 
            this.RdoQty.AutoSize = true;
            this.RdoQty.Checked = true;
            this.RdoQty.Location = new System.Drawing.Point(122, 23);
            this.RdoQty.Name = "RdoQty";
            this.RdoQty.Size = new System.Drawing.Size(45, 17);
            this.RdoQty.TabIndex = 123;
            this.RdoQty.TabStop = true;
            this.RdoQty.Tag = "1";
            this.RdoQty.Text = "Qty";
            this.RdoQty.UseVisualStyleBackColor = true;
            // 
            // RdoGp
            // 
            this.RdoGp.AutoSize = true;
            this.RdoGp.Location = new System.Drawing.Point(269, 23);
            this.RdoGp.Name = "RdoGp";
            this.RdoGp.Size = new System.Drawing.Size(92, 17);
            this.RdoGp.TabIndex = 124;
            this.RdoGp.Tag = "1";
            this.RdoGp.Text = "Gross Profit";
            this.RdoGp.UseVisualStyleBackColor = true;
            // 
            // RdoStockSales
            // 
            this.RdoStockSales.AutoSize = true;
            this.RdoStockSales.Location = new System.Drawing.Point(384, 23);
            this.RdoStockSales.Name = "RdoStockSales";
            this.RdoStockSales.Size = new System.Drawing.Size(110, 17);
            this.RdoStockSales.TabIndex = 125;
            this.RdoStockSales.Tag = "1";
            this.RdoStockSales.Text = "Stock Vs Sales";
            this.RdoStockSales.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RdoStockSales);
            this.groupBox2.Controls.Add(this.RdoGp);
            this.groupBox2.Controls.Add(this.RdoQty);
            this.groupBox2.Controls.Add(this.RdoValue);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(55, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(675, 63);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(18, 118);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(74, 13);
            this.lblDateRange.TabIndex = 95;
            this.lblDateRange.Text = "Date Range";
            this.lblDateRange.Visible = false;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(137, 112);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(133, 21);
            this.dtpFromDate.TabIndex = 96;
            this.dtpFromDate.Visible = false;
            this.dtpFromDate.Enter += new System.EventHandler(this.dtpFromDate_Enter);
            this.dtpFromDate.Leave += new System.EventHandler(this.dtpFromDate_Leave);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(18, 14);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(54, 13);
            this.lblLocation.TabIndex = 111;
            this.lblLocation.Text = "Location";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(137, 11);
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
            this.dtpToDate.Location = new System.Drawing.Point(291, 112);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(133, 21);
            this.dtpToDate.TabIndex = 113;
            this.dtpToDate.Visible = false;
            this.dtpToDate.Enter += new System.EventHandler(this.dtpToDate_Enter);
            this.dtpToDate.Leave += new System.EventHandler(this.dtpToDate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "-";
            this.label1.Visible = false;
            // 
            // lblSupplierFrom
            // 
            this.lblSupplierFrom.AutoSize = true;
            this.lblSupplierFrom.Location = new System.Drawing.Point(18, 45);
            this.lblSupplierFrom.Name = "lblSupplierFrom";
            this.lblSupplierFrom.Size = new System.Drawing.Size(87, 13);
            this.lblSupplierFrom.TabIndex = 121;
            this.lblSupplierFrom.Text = "Supplier From";
            // 
            // lblSupplierTo
            // 
            this.lblSupplierTo.AutoSize = true;
            this.lblSupplierTo.Location = new System.Drawing.Point(18, 72);
            this.lblSupplierTo.Name = "lblSupplierTo";
            this.lblSupplierTo.Size = new System.Drawing.Size(71, 13);
            this.lblSupplierTo.TabIndex = 122;
            this.lblSupplierTo.Text = "Supplier To";
            // 
            // txtSupplierCodeFrom
            // 
            this.txtSupplierCodeFrom.Location = new System.Drawing.Point(137, 42);
            this.txtSupplierCodeFrom.Name = "txtSupplierCodeFrom";
            this.txtSupplierCodeFrom.Size = new System.Drawing.Size(133, 21);
            this.txtSupplierCodeFrom.TabIndex = 123;
            this.txtSupplierCodeFrom.Enter += new System.EventHandler(this.txtSupplierCodeFrom_Enter);
            this.txtSupplierCodeFrom.Leave += new System.EventHandler(this.txtSupplierCodeFrom_Leave);
            // 
            // txtSupplierCodeTo
            // 
            this.txtSupplierCodeTo.Location = new System.Drawing.Point(137, 69);
            this.txtSupplierCodeTo.Name = "txtSupplierCodeTo";
            this.txtSupplierCodeTo.Size = new System.Drawing.Size(133, 21);
            this.txtSupplierCodeTo.TabIndex = 124;
            this.txtSupplierCodeTo.Enter += new System.EventHandler(this.txtSupplierCodeTo_Enter);
            this.txtSupplierCodeTo.Leave += new System.EventHandler(this.txtSupplierCodeTo_Leave);
            // 
            // txtSuppilerNameFrom
            // 
            this.txtSuppilerNameFrom.Location = new System.Drawing.Point(273, 42);
            this.txtSuppilerNameFrom.Name = "txtSuppilerNameFrom";
            this.txtSuppilerNameFrom.Size = new System.Drawing.Size(270, 21);
            this.txtSuppilerNameFrom.TabIndex = 125;
            this.txtSuppilerNameFrom.Enter += new System.EventHandler(this.txtSuppilerNameFrom_Enter);
            this.txtSuppilerNameFrom.Leave += new System.EventHandler(this.txtSuppilerNameFrom_Leave);
            // 
            // txtSupplierNameTo
            // 
            this.txtSupplierNameTo.Location = new System.Drawing.Point(273, 69);
            this.txtSupplierNameTo.Name = "txtSupplierNameTo";
            this.txtSupplierNameTo.Size = new System.Drawing.Size(270, 21);
            this.txtSupplierNameTo.TabIndex = 126;
            this.txtSupplierNameTo.Enter += new System.EventHandler(this.txtSupplierNameTo_Enter);
            this.txtSupplierNameTo.Leave += new System.EventHandler(this.txtSupplierNameTo_Leave);
            // 
            // ChkAutoComplteSupplierFrom
            // 
            this.ChkAutoComplteSupplierFrom.AutoSize = true;
            this.ChkAutoComplteSupplierFrom.Location = new System.Drawing.Point(121, 45);
            this.ChkAutoComplteSupplierFrom.Name = "ChkAutoComplteSupplierFrom";
            this.ChkAutoComplteSupplierFrom.Size = new System.Drawing.Size(15, 14);
            this.ChkAutoComplteSupplierFrom.TabIndex = 127;
            this.ChkAutoComplteSupplierFrom.Tag = "1";
            this.ChkAutoComplteSupplierFrom.UseVisualStyleBackColor = true;
            this.ChkAutoComplteSupplierFrom.CheckedChanged += new System.EventHandler(this.ChkAutoComplteSupplierFrom_CheckedChanged);
            this.ChkAutoComplteSupplierFrom.Enter += new System.EventHandler(this.ChkAutoComplteSupplierFrom_Enter);
            this.ChkAutoComplteSupplierFrom.Leave += new System.EventHandler(this.ChkAutoComplteSupplierFrom_Leave);
            // 
            // ChkAutoComplteSupplierTo
            // 
            this.ChkAutoComplteSupplierTo.AutoSize = true;
            this.ChkAutoComplteSupplierTo.Location = new System.Drawing.Point(121, 72);
            this.ChkAutoComplteSupplierTo.Name = "ChkAutoComplteSupplierTo";
            this.ChkAutoComplteSupplierTo.Size = new System.Drawing.Size(15, 14);
            this.ChkAutoComplteSupplierTo.TabIndex = 128;
            this.ChkAutoComplteSupplierTo.Tag = "1";
            this.ChkAutoComplteSupplierTo.UseVisualStyleBackColor = true;
            this.ChkAutoComplteSupplierTo.CheckedChanged += new System.EventHandler(this.ChkAutoComplteSupplierTo_CheckedChanged);
            this.ChkAutoComplteSupplierTo.Enter += new System.EventHandler(this.ChkAutoComplteSupplierTo_Enter);
            this.ChkAutoComplteSupplierTo.Leave += new System.EventHandler(this.ChkAutoComplteSupplierTo_Leave);
            // 
            // chkAllLocation
            // 
            this.chkAllLocation.AutoSize = true;
            this.chkAllLocation.Location = new System.Drawing.Point(442, 15);
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
            // grpHeader
            // 
            this.grpHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpHeader.Controls.Add(this.chkAllLocation);
            this.grpHeader.Controls.Add(this.ChkAutoComplteSupplierTo);
            this.grpHeader.Controls.Add(this.lblDateRange);
            this.grpHeader.Controls.Add(this.ChkAutoComplteSupplierFrom);
            this.grpHeader.Controls.Add(this.dtpFromDate);
            this.grpHeader.Controls.Add(this.txtSupplierNameTo);
            this.grpHeader.Controls.Add(this.lblLocation);
            this.grpHeader.Controls.Add(this.txtSuppilerNameFrom);
            this.grpHeader.Controls.Add(this.cmbLocation);
            this.grpHeader.Controls.Add(this.txtSupplierCodeTo);
            this.grpHeader.Controls.Add(this.dtpToDate);
            this.grpHeader.Controls.Add(this.txtSupplierCodeFrom);
            this.grpHeader.Controls.Add(this.label1);
            this.grpHeader.Controls.Add(this.lblSupplierTo);
            this.grpHeader.Controls.Add(this.lblSupplierFrom);
            this.grpHeader.Location = new System.Drawing.Point(5, 5);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(555, 110);
            this.grpHeader.TabIndex = 154;
            // 
            // FrmSupplierWiseReorderLevelProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(570, 173);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmSupplierWiseReorderLevelProduct";
            this.Text = "Supplier Wise Report";
            this.Load += new System.EventHandler(this.FrmSupplierWiseReorderLevelProduct_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.grpHeader, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            this.grpButtonSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        private void cmbLocation_Click(object sender, EventArgs e)
        {

        }

       

      

        private void ChkAutoComplteSupplierFrom_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAutoComplteSupplierFrom.Checked)
                {
                    LoadSuppierFrom();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void ChkAutoComplteSupplierTo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAutoComplteSupplierTo.Checked)
                {
                    LoadSuppierTo();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtSupplierCodeFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(lblSupplierFrom);
                if (string.IsNullOrEmpty(txtSupplierCodeFrom.Text.Trim())) { return; }


                SupplierService supplierService = new SupplierService();
                Supplier  supplier = new Supplier();

                supplier = supplierService.GetSupplierByCode(txtSupplierCodeFrom.Text.Trim());

                if (supplier != null)
                {
                    txtSupplierCodeFrom.Text = supplier.SupplierCode;
                    txtSuppilerNameFrom.Text = supplier.SupplierName;
                }


            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtSupplierCodeTo_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(lblSupplierTo);
                if (string.IsNullOrEmpty(txtSupplierCodeTo.Text.Trim())) { return; }


                SupplierService supplierService = new SupplierService();
                Supplier supplier = new Supplier();

                supplier = supplierService.GetSupplierByCode(txtSupplierCodeTo.Text.Trim());

                if (supplier != null)
                {
                    txtSupplierCodeTo.Text = supplier.SupplierCode;
                    txtSupplierNameTo.Text = supplier.SupplierName;
                }


            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
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

        private void txtSuppilerNameFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(lblSupplierFrom);
                if (string.IsNullOrEmpty(txtSuppilerNameFrom.Text.Trim())) { return; }


                SupplierService supplierService = new SupplierService();
                Supplier supplier = new Supplier();

                supplier = supplierService.GetSupplierByName(txtSuppilerNameFrom.Text.Trim());

                if (supplier != null)
                {
                    txtSupplierCodeFrom.Text = supplier.SupplierCode;
                    txtSuppilerNameFrom.Text = supplier.SupplierName;
                }


            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtSupplierNameTo_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(lblSupplierTo);
                if (string.IsNullOrEmpty(txtSupplierNameTo.Text.Trim())) { return; }


                SupplierService supplierService = new SupplierService();
                Supplier supplier = new Supplier();

                supplier = supplierService.GetSupplierByName(txtSupplierNameTo.Text.Trim());

                if (supplier != null)
                {
                    txtSupplierCodeTo.Text = supplier.SupplierCode;
                    txtSupplierNameTo.Text = supplier.SupplierName;
                }


            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
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

        private void ChkAutoComplteSupplierFrom_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblSupplierFrom);
        }

        private void ChkAutoComplteSupplierFrom_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblSupplierFrom);
        }

        private void txtSupplierCodeFrom_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblSupplierFrom);
        }

        private void txtSuppilerNameFrom_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblSupplierFrom);
        }

        private void ChkAutoComplteSupplierTo_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblSupplierTo);
        }

        private void ChkAutoComplteSupplierTo_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblSupplierTo);
        }

        private void txtSupplierCodeTo_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblSupplierTo);
        }

        private void txtSupplierNameTo_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblSupplierTo);
        }

        private void FrmSupplierWiseReorderLevelProduct_Load(object sender, EventArgs e)
        {

        }

     
       


    }
}
