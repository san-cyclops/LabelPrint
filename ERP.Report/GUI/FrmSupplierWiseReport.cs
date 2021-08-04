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
using ERP.Report.Inventory.Reference.Reports;
using ERP.Report.GUI;

namespace ERP.Report.GUI
{
    public partial class FrmSupplierWiseReport: FrmBaseReportsForm
    {
        int documentID = 0;
        bool isValidControls = true;
        UserPrivileges accessRights = new UserPrivileges();
        private GroupBox groupBox1;
        private Label label1;
        private DateTimePicker dtpToDate;
        private ComboBox cmbLocation;
        private Label lblLocation;
        private CheckBox ChkAutoComplteTo;
        private CheckBox ChkAutoComplteFrom;
        private TextBox TxtSearchNameTo;
        private TextBox TxtSearchNameFrom;
        private TextBox TxtSearchCodeTo;
        private TextBox TxtSearchCodeFrom;
        private Label lblProductTo;
        private Label lblProductFrom;
        private DateTimePicker dtpFromDate;
        private Label lblDateRange;
        private RadioButton RdoBinCard;
        private RadioButton RdoMovement;
        private RadioButton RdoStockAging;
        private RadioButton RdoNon;
        private RadioButton RdoSlow;
        private RadioButton RdoFast;
        private CheckBox ChkAutoComplteSupplierTo;
        private CheckBox ChkAutoComplteSupplierFrom;
        private TextBox txtSupplierNameTo;
        private TextBox txtSuppilerNameFrom;
        private TextBox txtSupplierCodeTo;
        private TextBox txtSupplierCodeFrom;
        private Label lblSupplierTo;
        private CheckBox chkAllLocation;
        private Label label2;
        private RadioButton RdoValue;
        private RadioButton RdoQty;
        private RadioButton RdoGp;
        private RadioButton RdoStockSales;
        private GroupBox groupBox2;
        private GroupBox grpExtendedProperty;
        private CheckBox chkExtendedProperty;
        private TextBox txtProductExtendedProperties;
        private CheckedListBox chkLstProductExtendedProperties;
        private Label lblSupplierFrom;


        List<Common.CheckedListBoxSelection> productExtendedPropertiesList = new List<Common.CheckedListBoxSelection>();

        public FrmSupplierWiseReport()
        {
            InitializeComponent();
        }

        private DataTable GetProductExtendedProperties()
        {
            DataTable dtExtendedProperties = new DataTable();
            dtExtendedProperties.Columns.Add("InvProductExtendedPropertyID", typeof(long));

            if (chkExtendedProperty.Checked)
            {
                InvProductExtendedPropertyService invProductExtendedPropertyService = new InvProductExtendedPropertyService();
                if (productExtendedPropertiesList.Any(l => l.isChecked.Equals(CheckState.Checked)))
                {
                    foreach (var item in productExtendedPropertiesList.Where(l => l.isChecked.Equals(CheckState.Checked)))
                    {
                        dtExtendedProperties.Rows.Add(invProductExtendedPropertyService.GetInvProductExtendedPropertyByName(item.Value.Trim()).InvProductExtendedPropertyID);
                    }
                }
            }
            return dtExtendedProperties;
        }

        public override void FormLoad()
        {
            try
            {

                LocationService locationService = new LocationService();
                Common.LoadLocations(cmbLocation, locationService.GetAllLocations());

                AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
                autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm(this.Name);

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
               
                if (ChkAutoComplteFrom.Checked) { LoadProductsFrom(); }
                if (ChkAutoComplteTo.Checked) { LoadProductsTo(); }

                if (ChkAutoComplteSupplierFrom.Checked) { LoadSuppierFrom(); }
                if (ChkAutoComplteSupplierTo.Checked) { LoadSuppierTo(); }
               

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        private void LoadProductsFrom()
        {
            try
            {
                InvProductMasterService invProductMasterService = new InvProductMasterService();

                Common.SetAutoComplete(TxtSearchCodeFrom, invProductMasterService.GetAllProductCodes(), ChkAutoComplteFrom.Checked);
                Common.SetAutoComplete(TxtSearchNameFrom, invProductMasterService.GetAllProductNames(), ChkAutoComplteFrom.Checked);
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


        private void LoadProductsTo()
        {
            try
            {
                InvProductMasterService invProductMasterService = new InvProductMasterService();

                Common.SetAutoComplete(TxtSearchCodeTo, invProductMasterService.GetAllProductCodes(), ChkAutoComplteTo.Checked);
                Common.SetAutoComplete(TxtSearchNameTo, invProductMasterService.GetAllProductNames(), ChkAutoComplteTo.Checked);
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

                TxtSearchCodeFrom.Text = string.Empty;
                TxtSearchCodeTo.Text = string.Empty;
                TxtSearchNameFrom.Text = string.Empty;
                TxtSearchNameTo.Text = string.Empty;

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

               
                if (ValidateLocationComboBoxes().Equals(false)) { return; }
                

                if (ValidateControls() == false) return;

                if (dateFrom > dateTo)
                {
                    Toast.Show(this.Text,"","", Toast.messageType.Information, Toast.messageAction.InvalidDate);
                    return;
                }

                locationId = cmbLocation.SelectedIndex + 1;

                typeId = 2;

                this.Cursor = Cursors.WaitCursor;

                SupplierService supplierService = new SupplierService();
                Location location = new Location();
                LocationService locationService = new LocationService();
                location=locationService.GetLocationsByID(Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()));

                if (chkAllLocation.Checked)
                {
                    if (supplierService.View("0","Z", txtSupplierCodeFrom.Text.Trim(), txtSupplierCodeTo.Text.Trim(), TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim(), dtpFromDate.Value, dtpToDate.Value))
                    {
                        ViewReport(locationId);
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        Toast.Show(this.Text, "No Data to view","", Toast.messageType.Information, Toast.messageAction.NotFound);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                else
                {
                    if (supplierService.View(location.LocationCode, location.LocationCode, txtSupplierCodeFrom.Text.Trim(), txtSupplierCodeTo.Text.Trim(), TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim(), dtpFromDate.Value, dtpToDate.Value))
                    {
                        ViewReport(locationId);
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        Toast.Show(this.Text, "No Data to view","", Toast.messageType.Information, Toast.messageAction.NotFound);
                        this.Cursor = Cursors.Default;
                        return;
                    }
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
            if (!Validater.ValidateTextBox(this.Text, errorProvider, Validater.ValidateType.Empty, TxtSearchCodeFrom, TxtSearchCodeTo, txtSupplierCodeFrom, txtSupplierCodeTo))
            { return false; }

            else
            {
                isValidControls = true;
                this.ValidateChildren();

                return isValidControls;
            }
        }

        private void ViewReport(int locationId)
        {

            FrmReportViewer objReportView = new FrmReportViewer();
            SupplierService supplierService = new SupplierService();

            InvRptSupplierWisePerformanceAnalysis invsupWisePer = new InvRptSupplierWisePerformanceAnalysis();

           // invsupWisePer.SetDataSource(binCardService.GetBinCardDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));

            invsupWisePer.SetDataSource(supplierService.GetSupplierDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim(),txtSupplierCodeFrom.Text.Trim(),txtSupplierCodeTo.Text.Trim()));

           // invsupWisePer.SetDataSource(binCardService.DsGetBinCardDetails.Tables["BinCardDetails"]);

            invsupWisePer.SummaryInfo.ReportTitle = "Supplier Wise Performance Analysis Report";
            invsupWisePer.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            invsupWisePer.DataDefinition.FormulaFields["LocationName"].Text = "'" + "ALL LOCATION" + "'";

            invsupWisePer.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            invsupWisePer.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            invsupWisePer.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            invsupWisePer.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
            invsupWisePer.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";
            invsupWisePer.DataDefinition.FormulaFields["SupFrom"].Text = "'" + txtSupplierCodeFrom.Text.Trim() + "   " + txtSuppilerNameFrom.Text.Trim() + "'";
            invsupWisePer.DataDefinition.FormulaFields["SupTo"].Text = "'" + txtSupplierCodeTo.Text.Trim() + "   " + txtSupplierNameTo.Text.Trim() + "'";

            invsupWisePer.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            invsupWisePer.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            invsupWisePer.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            invsupWisePer.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = invsupWisePer;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            //Cursor.Current = Cursors.Default;
        }

        

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpExtendedProperty = new System.Windows.Forms.GroupBox();
            this.chkExtendedProperty = new System.Windows.Forms.CheckBox();
            this.txtProductExtendedProperties = new System.Windows.Forms.TextBox();
            this.chkLstProductExtendedProperties = new System.Windows.Forms.CheckedListBox();
            this.chkAllLocation = new System.Windows.Forms.CheckBox();
            this.ChkAutoComplteSupplierTo = new System.Windows.Forms.CheckBox();
            this.ChkAutoComplteSupplierFrom = new System.Windows.Forms.CheckBox();
            this.RdoMovement = new System.Windows.Forms.RadioButton();
            this.RdoBinCard = new System.Windows.Forms.RadioButton();
            this.txtSupplierNameTo = new System.Windows.Forms.TextBox();
            this.txtSuppilerNameFrom = new System.Windows.Forms.TextBox();
            this.txtSupplierCodeTo = new System.Windows.Forms.TextBox();
            this.txtSupplierCodeFrom = new System.Windows.Forms.TextBox();
            this.lblSupplierTo = new System.Windows.Forms.Label();
            this.lblSupplierFrom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.ChkAutoComplteTo = new System.Windows.Forms.CheckBox();
            this.ChkAutoComplteFrom = new System.Windows.Forms.CheckBox();
            this.TxtSearchNameTo = new System.Windows.Forms.TextBox();
            this.TxtSearchNameFrom = new System.Windows.Forms.TextBox();
            this.TxtSearchCodeTo = new System.Windows.Forms.TextBox();
            this.TxtSearchCodeFrom = new System.Windows.Forms.TextBox();
            this.lblProductTo = new System.Windows.Forms.Label();
            this.lblProductFrom = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
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
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpExtendedProperty.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(513, 234);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Controls.Add(this.RdoStockAging);
            this.grpButtonSet.Controls.Add(this.RdoFast);
            this.grpButtonSet.Controls.Add(this.RdoSlow);
            this.grpButtonSet.Controls.Add(this.RdoNon);
            this.grpButtonSet.Location = new System.Drawing.Point(2, 234);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpExtendedProperty);
            this.groupBox1.Controls.Add(this.chkAllLocation);
            this.groupBox1.Controls.Add(this.ChkAutoComplteSupplierTo);
            this.groupBox1.Controls.Add(this.ChkAutoComplteSupplierFrom);
            this.groupBox1.Controls.Add(this.RdoMovement);
            this.groupBox1.Controls.Add(this.RdoBinCard);
            this.groupBox1.Controls.Add(this.txtSupplierNameTo);
            this.groupBox1.Controls.Add(this.txtSuppilerNameFrom);
            this.groupBox1.Controls.Add(this.txtSupplierCodeTo);
            this.groupBox1.Controls.Add(this.txtSupplierCodeFrom);
            this.groupBox1.Controls.Add(this.lblSupplierTo);
            this.groupBox1.Controls.Add(this.lblSupplierFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.cmbLocation);
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Controls.Add(this.ChkAutoComplteTo);
            this.groupBox1.Controls.Add(this.ChkAutoComplteFrom);
            this.groupBox1.Controls.Add(this.TxtSearchNameTo);
            this.groupBox1.Controls.Add(this.TxtSearchNameFrom);
            this.groupBox1.Controls.Add(this.TxtSearchCodeTo);
            this.groupBox1.Controls.Add(this.TxtSearchCodeFrom);
            this.groupBox1.Controls.Add(this.lblProductTo);
            this.groupBox1.Controls.Add(this.lblProductFrom);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.lblDateRange);
            this.groupBox1.Location = new System.Drawing.Point(2, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 507);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // grpExtendedProperty
            // 
            this.grpExtendedProperty.Controls.Add(this.chkExtendedProperty);
            this.grpExtendedProperty.Controls.Add(this.txtProductExtendedProperties);
            this.grpExtendedProperty.Controls.Add(this.chkLstProductExtendedProperties);
            this.grpExtendedProperty.Location = new System.Drawing.Point(751, 240);
            this.grpExtendedProperty.Name = "grpExtendedProperty";
            this.grpExtendedProperty.Size = new System.Drawing.Size(736, 272);
            this.grpExtendedProperty.TabIndex = 130;
            this.grpExtendedProperty.TabStop = false;
            this.grpExtendedProperty.Text = "    Extended Property";
            // 
            // chkExtendedProperty
            // 
            this.chkExtendedProperty.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkExtendedProperty.Location = new System.Drawing.Point(8, 0);
            this.chkExtendedProperty.Name = "chkExtendedProperty";
            this.chkExtendedProperty.Size = new System.Drawing.Size(15, 14);
            this.chkExtendedProperty.TabIndex = 114;
            this.chkExtendedProperty.Text = " ";
            this.chkExtendedProperty.UseVisualStyleBackColor = true;
            // 
            // txtProductExtendedProperties
            // 
            this.txtProductExtendedProperties.Location = new System.Drawing.Point(6, 245);
            this.txtProductExtendedProperties.Name = "txtProductExtendedProperties";
            this.txtProductExtendedProperties.Size = new System.Drawing.Size(146, 21);
            this.txtProductExtendedProperties.TabIndex = 6;
            this.txtProductExtendedProperties.TextChanged += new System.EventHandler(this.txtProductExtendedProperties_TextChanged);
            // 
            // chkLstProductExtendedProperties
            // 
            this.chkLstProductExtendedProperties.CheckOnClick = true;
            this.chkLstProductExtendedProperties.FormattingEnabled = true;
            this.chkLstProductExtendedProperties.Location = new System.Drawing.Point(6, 27);
            this.chkLstProductExtendedProperties.Name = "chkLstProductExtendedProperties";
            this.chkLstProductExtendedProperties.Size = new System.Drawing.Size(724, 212);
            this.chkLstProductExtendedProperties.TabIndex = 5;
            this.chkLstProductExtendedProperties.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstProductExtendedProperties_ItemCheck);
            // 
            // chkAllLocation
            // 
            this.chkAllLocation.AutoSize = true;
            this.chkAllLocation.Location = new System.Drawing.Point(438, 48);
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
            // ChkAutoComplteSupplierTo
            // 
            this.ChkAutoComplteSupplierTo.AutoSize = true;
            this.ChkAutoComplteSupplierTo.Location = new System.Drawing.Point(117, 120);
            this.ChkAutoComplteSupplierTo.Name = "ChkAutoComplteSupplierTo";
            this.ChkAutoComplteSupplierTo.Size = new System.Drawing.Size(15, 14);
            this.ChkAutoComplteSupplierTo.TabIndex = 128;
            this.ChkAutoComplteSupplierTo.Tag = "1";
            this.ChkAutoComplteSupplierTo.UseVisualStyleBackColor = true;
            this.ChkAutoComplteSupplierTo.CheckedChanged += new System.EventHandler(this.ChkAutoComplteSupplierTo_CheckedChanged);
            this.ChkAutoComplteSupplierTo.Enter += new System.EventHandler(this.ChkAutoComplteSupplierTo_Enter);
            this.ChkAutoComplteSupplierTo.Leave += new System.EventHandler(this.ChkAutoComplteSupplierTo_Leave);
            // 
            // ChkAutoComplteSupplierFrom
            // 
            this.ChkAutoComplteSupplierFrom.AutoSize = true;
            this.ChkAutoComplteSupplierFrom.Location = new System.Drawing.Point(117, 93);
            this.ChkAutoComplteSupplierFrom.Name = "ChkAutoComplteSupplierFrom";
            this.ChkAutoComplteSupplierFrom.Size = new System.Drawing.Size(15, 14);
            this.ChkAutoComplteSupplierFrom.TabIndex = 127;
            this.ChkAutoComplteSupplierFrom.Tag = "1";
            this.ChkAutoComplteSupplierFrom.UseVisualStyleBackColor = true;
            this.ChkAutoComplteSupplierFrom.CheckedChanged += new System.EventHandler(this.ChkAutoComplteSupplierFrom_CheckedChanged);
            this.ChkAutoComplteSupplierFrom.Enter += new System.EventHandler(this.ChkAutoComplteSupplierFrom_Enter);
            this.ChkAutoComplteSupplierFrom.Leave += new System.EventHandler(this.ChkAutoComplteSupplierFrom_Leave);
            // 
            // RdoMovement
            // 
            this.RdoMovement.AutoSize = true;
            this.RdoMovement.Location = new System.Drawing.Point(136, 222);
            this.RdoMovement.Name = "RdoMovement";
            this.RdoMovement.Size = new System.Drawing.Size(120, 17);
            this.RdoMovement.TabIndex = 115;
            this.RdoMovement.Tag = "1";
            this.RdoMovement.Text = "Stock Movement";
            this.RdoMovement.UseVisualStyleBackColor = true;
            this.RdoMovement.Visible = false;
            this.RdoMovement.Enter += new System.EventHandler(this.RdoMovement_Enter);
            this.RdoMovement.Leave += new System.EventHandler(this.RdoMovement_Leave);
            // 
            // RdoBinCard
            // 
            this.RdoBinCard.AutoSize = true;
            this.RdoBinCard.Checked = true;
            this.RdoBinCard.Location = new System.Drawing.Point(43, 222);
            this.RdoBinCard.Name = "RdoBinCard";
            this.RdoBinCard.Size = new System.Drawing.Size(75, 17);
            this.RdoBinCard.TabIndex = 116;
            this.RdoBinCard.TabStop = true;
            this.RdoBinCard.Tag = "1";
            this.RdoBinCard.Text = "Bin Card";
            this.RdoBinCard.UseVisualStyleBackColor = true;
            this.RdoBinCard.Visible = false;
            this.RdoBinCard.Enter += new System.EventHandler(this.RdoBinCard_Enter);
            this.RdoBinCard.Leave += new System.EventHandler(this.RdoBinCard_Leave);
            // 
            // txtSupplierNameTo
            // 
            this.txtSupplierNameTo.Location = new System.Drawing.Point(269, 117);
            this.txtSupplierNameTo.Name = "txtSupplierNameTo";
            this.txtSupplierNameTo.Size = new System.Drawing.Size(477, 21);
            this.txtSupplierNameTo.TabIndex = 126;
            this.txtSupplierNameTo.Enter += new System.EventHandler(this.txtSupplierNameTo_Enter);
            this.txtSupplierNameTo.Leave += new System.EventHandler(this.txtSupplierNameTo_Leave);
            // 
            // txtSuppilerNameFrom
            // 
            this.txtSuppilerNameFrom.Location = new System.Drawing.Point(269, 90);
            this.txtSuppilerNameFrom.Name = "txtSuppilerNameFrom";
            this.txtSuppilerNameFrom.Size = new System.Drawing.Size(477, 21);
            this.txtSuppilerNameFrom.TabIndex = 125;
            this.txtSuppilerNameFrom.Enter += new System.EventHandler(this.txtSuppilerNameFrom_Enter);
            this.txtSuppilerNameFrom.Leave += new System.EventHandler(this.txtSuppilerNameFrom_Leave);
            // 
            // txtSupplierCodeTo
            // 
            this.txtSupplierCodeTo.Location = new System.Drawing.Point(133, 117);
            this.txtSupplierCodeTo.Name = "txtSupplierCodeTo";
            this.txtSupplierCodeTo.Size = new System.Drawing.Size(133, 21);
            this.txtSupplierCodeTo.TabIndex = 124;
            this.txtSupplierCodeTo.Enter += new System.EventHandler(this.txtSupplierCodeTo_Enter);
            this.txtSupplierCodeTo.Leave += new System.EventHandler(this.txtSupplierCodeTo_Leave);
            // 
            // txtSupplierCodeFrom
            // 
            this.txtSupplierCodeFrom.Location = new System.Drawing.Point(133, 90);
            this.txtSupplierCodeFrom.Name = "txtSupplierCodeFrom";
            this.txtSupplierCodeFrom.Size = new System.Drawing.Size(133, 21);
            this.txtSupplierCodeFrom.TabIndex = 123;
            this.txtSupplierCodeFrom.Enter += new System.EventHandler(this.txtSupplierCodeFrom_Enter);
            this.txtSupplierCodeFrom.Leave += new System.EventHandler(this.txtSupplierCodeFrom_Leave);
            // 
            // lblSupplierTo
            // 
            this.lblSupplierTo.AutoSize = true;
            this.lblSupplierTo.Location = new System.Drawing.Point(14, 120);
            this.lblSupplierTo.Name = "lblSupplierTo";
            this.lblSupplierTo.Size = new System.Drawing.Size(71, 13);
            this.lblSupplierTo.TabIndex = 122;
            this.lblSupplierTo.Text = "Supplier To";
            // 
            // lblSupplierFrom
            // 
            this.lblSupplierFrom.AutoSize = true;
            this.lblSupplierFrom.Location = new System.Drawing.Point(14, 93);
            this.lblSupplierFrom.Name = "lblSupplierFrom";
            this.lblSupplierFrom.Size = new System.Drawing.Size(87, 13);
            this.lblSupplierFrom.TabIndex = 121;
            this.lblSupplierFrom.Text = "Supplier From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "-";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(287, 17);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(133, 21);
            this.dtpToDate.TabIndex = 113;
            this.dtpToDate.Enter += new System.EventHandler(this.dtpToDate_Enter);
            this.dtpToDate.Leave += new System.EventHandler(this.dtpToDate_Leave);
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(133, 44);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(287, 21);
            this.cmbLocation.TabIndex = 110;
            this.cmbLocation.Click += new System.EventHandler(this.cmbLocation_Click);
            this.cmbLocation.Enter += new System.EventHandler(this.cmbLocation_Enter);
            this.cmbLocation.Leave += new System.EventHandler(this.cmbLocation_Leave);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(14, 47);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(54, 13);
            this.lblLocation.TabIndex = 111;
            this.lblLocation.Text = "Location";
            // 
            // ChkAutoComplteTo
            // 
            this.ChkAutoComplteTo.AutoSize = true;
            this.ChkAutoComplteTo.Location = new System.Drawing.Point(117, 189);
            this.ChkAutoComplteTo.Name = "ChkAutoComplteTo";
            this.ChkAutoComplteTo.Size = new System.Drawing.Size(15, 14);
            this.ChkAutoComplteTo.TabIndex = 106;
            this.ChkAutoComplteTo.Tag = "1";
            this.ChkAutoComplteTo.UseVisualStyleBackColor = true;
            this.ChkAutoComplteTo.CheckedChanged += new System.EventHandler(this.ChkAutoComplteTo_CheckedChanged);
            this.ChkAutoComplteTo.Enter += new System.EventHandler(this.ChkAutoComplteTo_Enter);
            this.ChkAutoComplteTo.Leave += new System.EventHandler(this.ChkAutoComplteTo_Leave);
            // 
            // ChkAutoComplteFrom
            // 
            this.ChkAutoComplteFrom.AutoSize = true;
            this.ChkAutoComplteFrom.Location = new System.Drawing.Point(117, 162);
            this.ChkAutoComplteFrom.Name = "ChkAutoComplteFrom";
            this.ChkAutoComplteFrom.Size = new System.Drawing.Size(15, 14);
            this.ChkAutoComplteFrom.TabIndex = 105;
            this.ChkAutoComplteFrom.Tag = "1";
            this.ChkAutoComplteFrom.UseVisualStyleBackColor = true;
            this.ChkAutoComplteFrom.CheckedChanged += new System.EventHandler(this.ChkAutoComplteFrom_CheckedChanged);
            this.ChkAutoComplteFrom.Enter += new System.EventHandler(this.ChkAutoComplteFrom_Enter);
            this.ChkAutoComplteFrom.Leave += new System.EventHandler(this.ChkAutoComplteFrom_Leave);
            // 
            // TxtSearchNameTo
            // 
            this.TxtSearchNameTo.Location = new System.Drawing.Point(269, 186);
            this.TxtSearchNameTo.Name = "TxtSearchNameTo";
            this.TxtSearchNameTo.Size = new System.Drawing.Size(477, 21);
            this.TxtSearchNameTo.TabIndex = 104;
            this.TxtSearchNameTo.Enter += new System.EventHandler(this.TxtSearchNameTo_Enter);
            this.TxtSearchNameTo.Leave += new System.EventHandler(this.TxtSearchNameTo_Leave);
            // 
            // TxtSearchNameFrom
            // 
            this.TxtSearchNameFrom.Location = new System.Drawing.Point(269, 159);
            this.TxtSearchNameFrom.Name = "TxtSearchNameFrom";
            this.TxtSearchNameFrom.Size = new System.Drawing.Size(477, 21);
            this.TxtSearchNameFrom.TabIndex = 103;
            this.TxtSearchNameFrom.Enter += new System.EventHandler(this.TxtSearchNameFrom_Enter);
            this.TxtSearchNameFrom.Leave += new System.EventHandler(this.TxtSearchNameFrom_Leave);
            // 
            // TxtSearchCodeTo
            // 
            this.TxtSearchCodeTo.Location = new System.Drawing.Point(133, 186);
            this.TxtSearchCodeTo.Name = "TxtSearchCodeTo";
            this.TxtSearchCodeTo.Size = new System.Drawing.Size(133, 21);
            this.TxtSearchCodeTo.TabIndex = 102;
            this.TxtSearchCodeTo.Enter += new System.EventHandler(this.TxtSearchCodeTo_Enter);
            this.TxtSearchCodeTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearchCodeTo_KeyDown);
            this.TxtSearchCodeTo.Leave += new System.EventHandler(this.TxtSearchCodeTo_Leave);
            // 
            // TxtSearchCodeFrom
            // 
            this.TxtSearchCodeFrom.Location = new System.Drawing.Point(133, 159);
            this.TxtSearchCodeFrom.Name = "TxtSearchCodeFrom";
            this.TxtSearchCodeFrom.Size = new System.Drawing.Size(133, 21);
            this.TxtSearchCodeFrom.TabIndex = 101;
            this.TxtSearchCodeFrom.Enter += new System.EventHandler(this.TxtSearchCodeFrom_Enter);
            this.TxtSearchCodeFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearchCodeFrom_KeyDown);
            this.TxtSearchCodeFrom.Leave += new System.EventHandler(this.TxtSearchCodeFrom_Leave);
            // 
            // lblProductTo
            // 
            this.lblProductTo.AutoSize = true;
            this.lblProductTo.Location = new System.Drawing.Point(14, 189);
            this.lblProductTo.Name = "lblProductTo";
            this.lblProductTo.Size = new System.Drawing.Size(67, 13);
            this.lblProductTo.TabIndex = 98;
            this.lblProductTo.Text = "Product To";
            // 
            // lblProductFrom
            // 
            this.lblProductFrom.AutoSize = true;
            this.lblProductFrom.Location = new System.Drawing.Point(14, 162);
            this.lblProductFrom.Name = "lblProductFrom";
            this.lblProductFrom.Size = new System.Drawing.Size(83, 13);
            this.lblProductFrom.TabIndex = 97;
            this.lblProductFrom.Text = "Product From";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(133, 17);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(133, 21);
            this.dtpFromDate.TabIndex = 96;
            this.dtpFromDate.Enter += new System.EventHandler(this.dtpFromDate_Enter);
            this.dtpFromDate.Leave += new System.EventHandler(this.dtpFromDate_Leave);
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(14, 23);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(74, 13);
            this.lblDateRange.TabIndex = 95;
            this.lblDateRange.Text = "Date Range";
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
            // FrmSupplierWiseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(753, 283);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmSupplierWiseReport";
            this.Text = "Supplier Wise Report";
            this.Load += new System.EventHandler(this.FrmBinCard_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            this.grpButtonSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpExtendedProperty.ResumeLayout(false);
            this.grpExtendedProperty.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void cmbLocation_Click(object sender, EventArgs e)
        {

        }

        private void TxtSearchCodeFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    if (!string.IsNullOrEmpty(TxtSearchCodeFrom.Text.Trim())) { TxtSearchNameFrom.Focus(); }
                    TxtSearchCodeTo.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void TxtSearchCodeFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(lblProductFrom);
                if (string.IsNullOrEmpty(TxtSearchCodeFrom.Text.Trim())) { return; }

               
                InvProductMasterService invProductMasterService = new InvProductMasterService();
                InvProductMaster invProductMaster = new InvProductMaster();

                invProductMaster = invProductMasterService.GetProductsByCode(TxtSearchCodeFrom.Text.Trim());

                if (invProductMaster != null)
                {
                    TxtSearchCodeFrom.Text = invProductMaster.ProductCode;
                    TxtSearchNameFrom.Text = invProductMaster.ProductName;
                }

                           
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void TxtSearchCodeTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    if (!string.IsNullOrEmpty(TxtSearchCodeTo.Text.Trim())) { TxtSearchNameTo.Focus(); }
                    TxtSearchNameTo.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void TxtSearchCodeTo_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(lblProductTo);
                if (string.IsNullOrEmpty(TxtSearchCodeTo.Text.Trim())) { return; }
                
                InvProductMasterService invProductMasterService = new InvProductMasterService();
                InvProductMaster invProductMaster = new InvProductMaster();

                invProductMaster = invProductMasterService.GetProductsByCode(TxtSearchCodeTo.Text.Trim());

                if (invProductMaster != null)
                {
                    TxtSearchCodeTo.Text = invProductMaster.ProductCode;
                    TxtSearchNameTo.Text = invProductMaster.ProductName;
                }
                
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void ChkAutoComplteFrom_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAutoComplteFrom.Checked)
                {
                    LoadProductsFrom();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void ChkAutoComplteTo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAutoComplteTo.Checked)
                {
                    LoadProductsTo();
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void FrmBinCard_Load(object sender, EventArgs e)
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
            if (chkAllLocation.Checked)
            {
                cmbLocation.Text = "";
                cmbLocation.Enabled = false;
            }
            else
            {
                cmbLocation.Enabled = true;
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

        private void txtProductExtendedProperties_TextChanged(object sender, EventArgs e)
        {
              try
            {
                this.chkLstProductExtendedProperties.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstProductExtendedProperties_ItemCheck);
                if (string.IsNullOrEmpty(txtProductExtendedProperties.Text.Trim()))
                {
                    Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstProductExtendedProperties, productExtendedPropertiesList, "", "");
                }
                else
                {
                    Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstProductExtendedProperties, SearchList(productExtendedPropertiesList, txtProductExtendedProperties.Text.Trim()), "", "");
                }
                RefreshCheckedList(chkLstProductExtendedProperties, productExtendedPropertiesList);
                this.chkLstProductExtendedProperties.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstProductExtendedProperties_ItemCheck);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex.Message.ToString(), MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }

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

        private void ChkAutoComplteFrom_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblProductFrom);
        }

        private void ChkAutoComplteFrom_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblProductFrom);
        }

        private void TxtSearchCodeFrom_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblProductFrom);
        }

        private void TxtSearchNameFrom_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblProductFrom);
        }

        private void TxtSearchNameFrom_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblProductFrom);
        }

        private void ChkAutoComplteTo_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblProductTo);
        }

        private void ChkAutoComplteTo_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblProductTo);
        }

        private void TxtSearchCodeTo_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblProductTo);
        }

        private void TxtSearchNameTo_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblProductTo);
        }

        private void TxtSearchNameTo_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblProductTo);
        }

        private void RdoBinCard_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(RdoBinCard);
        }

        private void RdoBinCard_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(RdoBinCard);
        }

        private void RdoMovement_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(RdoMovement);
        }

        private void RdoMovement_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(RdoMovement);
        }

       


    }
}
