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

namespace ERP.UI.Windows
{
    public partial class FrmBinCard : FrmBaseReportsForm
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
        private Label LblSerachTo;
        private Label LblSearchFrom;
        private DateTimePicker dtpFromDate;
        private Label lblDateRange;
        private RadioButton RdoBinCard;
        private RadioButton RdoMovement;
        private GroupBox grpFooter;
        private RadioButton RdoStockAging;
        private RadioButton RdoNon;
        private RadioButton RdoSlow;
        private RadioButton RdoFast;
        private RadioButton RdoStockSales;
        private RadioButton RdoGp;
        private RadioButton RdoQty;
        private RadioButton RdoValue;
        private Label lblBasedOn;
        private RadioButton RdoReorderLevel;
        BinCardService binCardService = new BinCardService();


        public FrmBinCard()
        {
            InitializeComponent();
        }

        public override void FormLoad()
        {
            try
            {

                LocationService locationService = new LocationService();
                Common.LoadLocations(cmbLocation, locationService.GetAllLocations());

                AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
                autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm(this.Name);
                this.Text = autoGenerateInfo.FormText;

                documentID = autoGenerateInfo.DocumentID;
                accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);

                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();

                cmbLocation.SelectedValue = Common.LoggedLocationID;
                EnableDesableFooter();

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
                if(Common.IsBatch)
                {
                    InvProductStockMasterService invProductStockMasterService = new InvProductStockMasterService();

                    Common.SetAutoComplete(TxtSearchCodeFrom, invProductStockMasterService.GetAllStockCode(), ChkAutoComplteFrom.Checked);
 
                }
                else
                {
                    InvProductMasterService invProductMasterService = new InvProductMasterService();

                    Common.SetAutoComplete(TxtSearchCodeFrom, invProductMasterService.GetAllProductCodes(), ChkAutoComplteFrom.Checked);
 
                }
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
                if (Common.IsBatch)
                {
                    InvProductStockMasterService invProductStockMasterService = new InvProductStockMasterService();

                    Common.SetAutoComplete(TxtSearchCodeTo, invProductStockMasterService.GetAllStockCode(), ChkAutoComplteFrom.Checked);

                }
                else
                {
                    InvProductMasterService invProductMasterService = new InvProductMasterService();

                    Common.SetAutoComplete(TxtSearchCodeTo, invProductMasterService.GetAllProductCodes(), ChkAutoComplteFrom.Checked);

                }
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

                if (RdoBinCard.Checked == true) { typeId = 1; }
                else if (RdoMovement.Checked == true) { typeId = 2; }
                else if (RdoStockAging.Checked == true) { typeId = 3; }
                else if (RdoFast.Checked == true) { typeId = 4; }
                else if (RdoSlow.Checked == true) { typeId = 5; }
                else if (RdoNon.Checked == true) { typeId = 6; }
                else if (RdoReorderLevel.Checked == true) { typeId = 7; }

                if (RdoStockSales.Checked == true)
                {
                    stockId = 1;
                }
                else
                {
                    stockId = 0;
                }

                this.Cursor = Cursors.WaitCursor;

                if (RdoStockAging.Checked == true)
                {
                    if (binCardService.ViewAging(typeId, locationId, dateFrom, dateTo, uniqueId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()) == true)
                    {
                        ViewReport(locationId);
                    }
                    else
                    {
                        Toast.Show(this.Text, "", "View Process Faild", Toast.messageType.Error, Toast.messageAction.General);
                        return;
                    }
                }
                else if (RdoFast.Checked == true)
                {
                    if (binCardService.ViewMovement(typeId, locationId, dateFrom, dateTo, uniqueId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim(), stockId) == true)
                    {
                        ViewReport(locationId);
                    }
                    else
                    {
                        Toast.Show(this.Text, "", "View Process Faild", Toast.messageType.Error, Toast.messageAction.General);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                else if (RdoSlow.Checked == true)
                {
                    if (binCardService.ViewMovement(typeId, locationId, dateFrom, dateTo, uniqueId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim(), stockId) == true)
                    {
                        ViewReport(locationId);
                    }
                    else
                    {
                        Toast.Show(this.Text, "", "View Process Faild", Toast.messageType.Error, Toast.messageAction.General);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                else if (RdoNon.Checked == true)
                {
                    if (binCardService.ViewMovement(typeId, locationId, dateFrom, dateTo, uniqueId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim(), stockId) == true)
                    {
                        ViewReport(locationId);
                    }
                    else
                    {
                        Toast.Show(this.Text, "", "View Process Faild", Toast.messageType.Error, Toast.messageAction.General);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                else if (RdoReorderLevel.Checked == true)
                {
                    if (binCardService.ViewMovement(typeId, locationId, dateFrom, dateTo, uniqueId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim(), stockId) == true)
                    {
                        ViewReport(locationId);
                    }
                    else
                    {
                        Toast.Show(this.Text, "", "View Process Faild", Toast.messageType.Error, Toast.messageAction.General);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                else
                {
                    if (binCardService.View(typeId, locationId, dateFrom, dateTo, uniqueId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()) == true)
                    {
                        ViewReport(locationId);
                    }
                    else
                    {
                        Toast.Show(this.Text, "", "View Process Faild", Toast.messageType.Error, Toast.messageAction.General);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                this.Cursor = Cursors.Default;
               
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private bool ValidateLocationComboBoxes()
        {
            return Validater.ValidateComboBox(this.Text,errorProvider, Validater.ValidateType.Empty, cmbLocation);
        }

        private bool ValidateControls()
        {
            if (!Validater.ValidateTextBox(this.Text,errorProvider, Validater.ValidateType.Empty, TxtSearchCodeFrom, TxtSearchCodeTo))
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
            Cursor.Current = Cursors.WaitCursor;
           

            if (RdoBinCard.Checked == true)
            {
                InvRptBinCard invRptBinCard = new InvRptBinCard();

                invRptBinCard.SetDataSource(binCardService.GetBinCardDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));


                invRptBinCard.SetDataSource(binCardService.DsGetBinCardDetails.Tables["BinCardDetails"]);

                invRptBinCard.SummaryInfo.ReportTitle = "Bin Card Report";
                invRptBinCard.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                invRptBinCard.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";

                invRptBinCard.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                invRptBinCard.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                invRptBinCard.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                invRptBinCard.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
                invRptBinCard.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";

                invRptBinCard.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                invRptBinCard.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptBinCard.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                invRptBinCard.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                objReportView.crRptViewer.ReportSource = invRptBinCard;

            }

            else if (RdoMovement.Checked == true)
            {
                InvRptStockMovement invRptStockMovement = new InvRptStockMovement();

                invRptStockMovement.SetDataSource(binCardService.GetBinCardDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));


                invRptStockMovement.SetDataSource(binCardService.DsGetBinCardDetails.Tables["BinCardDetails"]);

                invRptStockMovement.SummaryInfo.ReportTitle = "Stock Movement Report";
                invRptStockMovement.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                invRptStockMovement.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";

                invRptStockMovement.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                invRptStockMovement.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                invRptStockMovement.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                invRptStockMovement.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
                invRptStockMovement.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";

                invRptStockMovement.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                invRptStockMovement.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptStockMovement.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                invRptStockMovement.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                objReportView.crRptViewer.ReportSource = invRptStockMovement;
            }

            else if (RdoStockAging.Checked == true)
            {
                //    InvRptStockAging invRptStockAging = new InvRptStockAging();

                //invRptStockAging.SetDataSource(binCardService.GetBinCardDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));


                //invRptStockAging.SetDataSource(binCardService.DsGetBinCardDetails.Tables["BinCardDetails"]);

                //invRptStockAging.SummaryInfo.ReportTitle = "Stock Movement Report";
                //invRptStockAging.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                //invRptStockAging.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";

                //invRptStockAging.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                //invRptStockAging.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                //invRptStockAging.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                //invRptStockAging.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
                //invRptStockAging.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";

                //invRptStockAging.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                //invRptStockAging.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                //invRptStockAging.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                //invRptStockAging.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                //objReportView.crRptViewer.ReportSource = invRptStockAging;
            }

            else if (RdoFast.Checked == true)
            {
                InvRptFastMoving invRptFastMoving = new InvRptFastMoving();
                InvRptFastMovingVsPurchase invRptFastMovingVsPurchase = new InvRptFastMovingVsPurchase();

                if (RdoQty.Checked == true)
                {
                    invRptFastMoving.SetDataSource(binCardService.GetFastMovingDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));
                    invRptFastMoving.SetDataSource(binCardService.DsGetBinCardDetails.Tables["FastMovingDetails"]);
                    invRptFastMoving.SummaryInfo.ReportTitle = "Fast Moving Report";
                    invRptFastMoving.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    invRptFastMoving.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                    objReportView.crRptViewer.ReportSource = invRptFastMoving;
                }
                else if (RdoValue.Checked == true)
                {
                    invRptFastMoving.SetDataSource(binCardService.GetFastMovingValueDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));
                    invRptFastMoving.SetDataSource(binCardService.DsGetBinCardDetails.Tables["FastMovingDetails"]);
                    invRptFastMoving.SummaryInfo.ReportTitle = "Fast Moving Report";
                    invRptFastMoving.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    invRptFastMoving.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                    objReportView.crRptViewer.ReportSource = invRptFastMoving;
                }
                else if (RdoGp.Checked == true)
                {
                    invRptFastMoving.SetDataSource(binCardService.GetFastMovingGpDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));
                    invRptFastMoving.SetDataSource(binCardService.DsGetBinCardDetails.Tables["FastMovingDetails"]);
                    invRptFastMoving.SummaryInfo.ReportTitle = "Fast Moving Report";
                    invRptFastMoving.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    invRptFastMoving.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                    objReportView.crRptViewer.ReportSource = invRptFastMoving;
                }
                else if (RdoStockSales.Checked == true)
                {
                    invRptFastMovingVsPurchase.SetDataSource(binCardService.GetFastMovingStockVsSalesDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));
                    invRptFastMovingVsPurchase.SetDataSource(binCardService.DsGetBinCardDetails.Tables["FastMovingDetails"]);
                    invRptFastMovingVsPurchase.SummaryInfo.ReportTitle = "Fast Moving Report";
                    invRptFastMovingVsPurchase.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                    objReportView.crRptViewer.ReportSource = invRptFastMovingVsPurchase;
                }

            }

            else if (RdoSlow.Checked == true)
            {
                InvRptFastMoving invRptFastMoving = new InvRptFastMoving();
                InvRptFastMovingVsPurchase invRptFastMovingVsPurchase = new InvRptFastMovingVsPurchase();

                if (RdoQty.Checked == true)
                {
                    invRptFastMoving.SetDataSource(binCardService.GetSlowMovingDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));
                    invRptFastMoving.SetDataSource(binCardService.DsGetBinCardDetails.Tables["FastMovingDetails"]);
                    invRptFastMoving.SummaryInfo.ReportTitle = "Slow Moving Report";
                    invRptFastMoving.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    invRptFastMoving.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                    objReportView.crRptViewer.ReportSource = invRptFastMoving;
                }
                else if (RdoValue.Checked == true)
                {
                    invRptFastMoving.SetDataSource(binCardService.GetSlowMovingValueDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));
                    invRptFastMoving.SetDataSource(binCardService.DsGetBinCardDetails.Tables["FastMovingDetails"]);
                    invRptFastMoving.SummaryInfo.ReportTitle = "Slow Moving Report";
                    invRptFastMoving.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    invRptFastMoving.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                    objReportView.crRptViewer.ReportSource = invRptFastMoving;
                }
                else if (RdoGp.Checked == true)
                {
                    invRptFastMoving.SetDataSource(binCardService.GetSlowMovingGpDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));
                    invRptFastMoving.SetDataSource(binCardService.DsGetBinCardDetails.Tables["FastMovingDetails"]);
                    invRptFastMoving.SummaryInfo.ReportTitle = "Slow Moving Report";
                    invRptFastMoving.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    invRptFastMoving.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    invRptFastMoving.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                    objReportView.crRptViewer.ReportSource = invRptFastMoving;
                }
                else if (RdoStockSales.Checked == true)
                {
                    invRptFastMovingVsPurchase.SetDataSource(binCardService.GetSlowMovingStockVsSalesDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));
                    invRptFastMovingVsPurchase.SetDataSource(binCardService.DsGetBinCardDetails.Tables["FastMovingDetails"]);
                    invRptFastMovingVsPurchase.SummaryInfo.ReportTitle = "Slow Moving Report";
                    invRptFastMovingVsPurchase.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    invRptFastMovingVsPurchase.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                    objReportView.crRptViewer.ReportSource = invRptFastMovingVsPurchase;
                }

            }

            else if (RdoNon.Checked == true)
            {
                InvRptNonMoving invRptNonMoving = new InvRptNonMoving();

                invRptNonMoving.SetDataSource(binCardService.GetNonMovingDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));


                invRptNonMoving.SetDataSource(binCardService.DsGetBinCardDetails.Tables["FastMovingDetails"]);

                invRptNonMoving.SummaryInfo.ReportTitle = "Non Moving Report";
                invRptNonMoving.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                invRptNonMoving.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";

                invRptNonMoving.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                invRptNonMoving.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                invRptNonMoving.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                invRptNonMoving.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
                invRptNonMoving.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";

                invRptNonMoving.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                invRptNonMoving.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptNonMoving.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                invRptNonMoving.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                objReportView.crRptViewer.ReportSource = invRptNonMoving;
            }
            else if (RdoReorderLevel.Checked == true)
            {
                InvRptReorderLevel invRptNonMoving = new InvRptReorderLevel();

                invRptNonMoving.SetDataSource(binCardService.GetNonMovingDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));


                invRptNonMoving.SetDataSource(binCardService.DsGetBinCardDetails.Tables["FastMovingDetails"]);

                invRptNonMoving.SummaryInfo.ReportTitle = "Non Moving Report";
                invRptNonMoving.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                invRptNonMoving.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";

                invRptNonMoving.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                invRptNonMoving.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                invRptNonMoving.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                invRptNonMoving.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
                invRptNonMoving.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";

                invRptNonMoving.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                invRptNonMoving.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptNonMoving.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                invRptNonMoving.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                objReportView.crRptViewer.ReportSource = invRptNonMoving;
            }


            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RdoReorderLevel = new System.Windows.Forms.RadioButton();
            this.RdoNon = new System.Windows.Forms.RadioButton();
            this.RdoSlow = new System.Windows.Forms.RadioButton();
            this.RdoFast = new System.Windows.Forms.RadioButton();
            this.RdoStockAging = new System.Windows.Forms.RadioButton();
            this.RdoBinCard = new System.Windows.Forms.RadioButton();
            this.RdoMovement = new System.Windows.Forms.RadioButton();
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
            this.LblSerachTo = new System.Windows.Forms.Label();
            this.LblSearchFrom = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.grpFooter = new System.Windows.Forms.GroupBox();
            this.RdoStockSales = new System.Windows.Forms.RadioButton();
            this.RdoGp = new System.Windows.Forms.RadioButton();
            this.RdoQty = new System.Windows.Forms.RadioButton();
            this.RdoValue = new System.Windows.Forms.RadioButton();
            this.lblBasedOn = new System.Windows.Forms.Label();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(560, 218);
            this.grpButtonSet2.Size = new System.Drawing.Size(236, 46);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Location = new System.Drawing.Point(2, 224);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(80, 7);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(158, 7);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(2, 7);
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RdoReorderLevel);
            this.groupBox1.Controls.Add(this.RdoNon);
            this.groupBox1.Controls.Add(this.RdoSlow);
            this.groupBox1.Controls.Add(this.RdoFast);
            this.groupBox1.Controls.Add(this.RdoStockAging);
            this.groupBox1.Controls.Add(this.RdoBinCard);
            this.groupBox1.Controls.Add(this.RdoMovement);
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
            this.groupBox1.Controls.Add(this.LblSerachTo);
            this.groupBox1.Controls.Add(this.LblSearchFrom);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.lblDateRange);
            this.groupBox1.Location = new System.Drawing.Point(2, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 172);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // RdoReorderLevel
            // 
            this.RdoReorderLevel.AutoSize = true;
            this.RdoReorderLevel.Location = new System.Drawing.Point(666, 20);
            this.RdoReorderLevel.Name = "RdoReorderLevel";
            this.RdoReorderLevel.Size = new System.Drawing.Size(105, 17);
            this.RdoReorderLevel.TabIndex = 121;
            this.RdoReorderLevel.Tag = "1";
            this.RdoReorderLevel.Text = "Reorder Level";
            this.RdoReorderLevel.UseVisualStyleBackColor = true;
            // 
            // RdoNon
            // 
            this.RdoNon.AutoSize = true;
            this.RdoNon.Location = new System.Drawing.Point(569, 20);
            this.RdoNon.Name = "RdoNon";
            this.RdoNon.Size = new System.Drawing.Size(91, 17);
            this.RdoNon.TabIndex = 120;
            this.RdoNon.Tag = "1";
            this.RdoNon.Text = "Non Moving";
            this.RdoNon.UseVisualStyleBackColor = true;
            this.RdoNon.CheckedChanged += new System.EventHandler(this.RdoNon_CheckedChanged);
            this.RdoNon.Enter += new System.EventHandler(this.RdoNon_Enter);
            this.RdoNon.Leave += new System.EventHandler(this.RdoNon_Leave);
            // 
            // RdoSlow
            // 
            this.RdoSlow.AutoSize = true;
            this.RdoSlow.Location = new System.Drawing.Point(459, 20);
            this.RdoSlow.Name = "RdoSlow";
            this.RdoSlow.Size = new System.Drawing.Size(96, 17);
            this.RdoSlow.TabIndex = 119;
            this.RdoSlow.Tag = "1";
            this.RdoSlow.Text = "Slow Moving";
            this.RdoSlow.UseVisualStyleBackColor = true;
            this.RdoSlow.CheckedChanged += new System.EventHandler(this.RdoSlow_CheckedChanged);
            this.RdoSlow.Enter += new System.EventHandler(this.RdoSlow_Enter);
            this.RdoSlow.Leave += new System.EventHandler(this.RdoSlow_Leave);
            // 
            // RdoFast
            // 
            this.RdoFast.AutoSize = true;
            this.RdoFast.Location = new System.Drawing.Point(349, 20);
            this.RdoFast.Name = "RdoFast";
            this.RdoFast.Size = new System.Drawing.Size(91, 17);
            this.RdoFast.TabIndex = 118;
            this.RdoFast.Tag = "1";
            this.RdoFast.Text = "Fast Moving";
            this.RdoFast.UseVisualStyleBackColor = true;
            this.RdoFast.CheckedChanged += new System.EventHandler(this.RdoFast_CheckedChanged);
            this.RdoFast.Enter += new System.EventHandler(this.RdoFast_Enter);
            this.RdoFast.Leave += new System.EventHandler(this.RdoFast_Leave);
            // 
            // RdoStockAging
            // 
            this.RdoStockAging.AutoSize = true;
            this.RdoStockAging.Location = new System.Drawing.Point(235, 20);
            this.RdoStockAging.Name = "RdoStockAging";
            this.RdoStockAging.Size = new System.Drawing.Size(93, 17);
            this.RdoStockAging.TabIndex = 117;
            this.RdoStockAging.Tag = "1";
            this.RdoStockAging.Text = "Stock Aging";
            this.RdoStockAging.UseVisualStyleBackColor = true;
            this.RdoStockAging.Visible = false;
            this.RdoStockAging.CheckedChanged += new System.EventHandler(this.RdoStockAging_CheckedChanged);
            this.RdoStockAging.Enter += new System.EventHandler(this.RdoStockAging_Enter);
            this.RdoStockAging.Leave += new System.EventHandler(this.RdoStockAging_Leave);
            // 
            // RdoBinCard
            // 
            this.RdoBinCard.AutoSize = true;
            this.RdoBinCard.Checked = true;
            this.RdoBinCard.Location = new System.Drawing.Point(11, 20);
            this.RdoBinCard.Name = "RdoBinCard";
            this.RdoBinCard.Size = new System.Drawing.Size(75, 17);
            this.RdoBinCard.TabIndex = 116;
            this.RdoBinCard.TabStop = true;
            this.RdoBinCard.Tag = "1";
            this.RdoBinCard.Text = "Bin Card";
            this.RdoBinCard.UseVisualStyleBackColor = true;
            this.RdoBinCard.CheckedChanged += new System.EventHandler(this.RdoBinCard_CheckedChanged);
            this.RdoBinCard.Enter += new System.EventHandler(this.RdoBinCard_Enter);
            this.RdoBinCard.Leave += new System.EventHandler(this.RdoBinCard_Leave);
            // 
            // RdoMovement
            // 
            this.RdoMovement.AutoSize = true;
            this.RdoMovement.Location = new System.Drawing.Point(98, 20);
            this.RdoMovement.Name = "RdoMovement";
            this.RdoMovement.Size = new System.Drawing.Size(120, 17);
            this.RdoMovement.TabIndex = 115;
            this.RdoMovement.Tag = "1";
            this.RdoMovement.Text = "Stock Movement";
            this.RdoMovement.UseVisualStyleBackColor = true;
            this.RdoMovement.CheckedChanged += new System.EventHandler(this.RdoMovement_CheckedChanged);
            this.RdoMovement.Enter += new System.EventHandler(this.RdoMovement_Enter);
            this.RdoMovement.Leave += new System.EventHandler(this.RdoMovement_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "-";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(293, 52);
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
            this.cmbLocation.Location = new System.Drawing.Point(139, 79);
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
            this.lblLocation.Location = new System.Drawing.Point(20, 82);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(54, 13);
            this.lblLocation.TabIndex = 111;
            this.lblLocation.Text = "Location";
            // 
            // ChkAutoComplteTo
            // 
            this.ChkAutoComplteTo.AutoSize = true;
            this.ChkAutoComplteTo.Location = new System.Drawing.Point(117, 140);
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
            this.ChkAutoComplteFrom.Location = new System.Drawing.Point(117, 113);
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
            this.TxtSearchNameTo.Location = new System.Drawing.Point(273, 137);
            this.TxtSearchNameTo.Name = "TxtSearchNameTo";
            this.TxtSearchNameTo.Size = new System.Drawing.Size(394, 21);
            this.TxtSearchNameTo.TabIndex = 104;
            this.TxtSearchNameTo.Enter += new System.EventHandler(this.TxtSearchNameTo_Enter);
            this.TxtSearchNameTo.Leave += new System.EventHandler(this.TxtSearchNameTo_Leave);
            // 
            // TxtSearchNameFrom
            // 
            this.TxtSearchNameFrom.Location = new System.Drawing.Point(273, 110);
            this.TxtSearchNameFrom.Name = "TxtSearchNameFrom";
            this.TxtSearchNameFrom.Size = new System.Drawing.Size(394, 21);
            this.TxtSearchNameFrom.TabIndex = 103;
            this.TxtSearchNameFrom.Enter += new System.EventHandler(this.TxtSearchNameFrom_Enter);
            this.TxtSearchNameFrom.Leave += new System.EventHandler(this.TxtSearchNameFrom_Leave);
            // 
            // TxtSearchCodeTo
            // 
            this.TxtSearchCodeTo.Location = new System.Drawing.Point(138, 137);
            this.TxtSearchCodeTo.Name = "TxtSearchCodeTo";
            this.TxtSearchCodeTo.Size = new System.Drawing.Size(133, 21);
            this.TxtSearchCodeTo.TabIndex = 102;
            this.TxtSearchCodeTo.Enter += new System.EventHandler(this.TxtSearchCodeTo_Enter);
            this.TxtSearchCodeTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearchCodeTo_KeyDown);
            this.TxtSearchCodeTo.Leave += new System.EventHandler(this.TxtSearchCodeTo_Leave);
            // 
            // TxtSearchCodeFrom
            // 
            this.TxtSearchCodeFrom.Location = new System.Drawing.Point(138, 110);
            this.TxtSearchCodeFrom.Name = "TxtSearchCodeFrom";
            this.TxtSearchCodeFrom.Size = new System.Drawing.Size(133, 21);
            this.TxtSearchCodeFrom.TabIndex = 101;
            this.TxtSearchCodeFrom.Enter += new System.EventHandler(this.TxtSearchCodeFrom_Enter);
            this.TxtSearchCodeFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearchCodeFrom_KeyDown);
            this.TxtSearchCodeFrom.Leave += new System.EventHandler(this.TxtSearchCodeFrom_Leave);
            // 
            // LblSerachTo
            // 
            this.LblSerachTo.AutoSize = true;
            this.LblSerachTo.Location = new System.Drawing.Point(21, 140);
            this.LblSerachTo.Name = "LblSerachTo";
            this.LblSerachTo.Size = new System.Drawing.Size(67, 13);
            this.LblSerachTo.TabIndex = 98;
            this.LblSerachTo.Text = "Product To";
            // 
            // LblSearchFrom
            // 
            this.LblSearchFrom.AutoSize = true;
            this.LblSearchFrom.Location = new System.Drawing.Point(21, 113);
            this.LblSearchFrom.Name = "LblSearchFrom";
            this.LblSearchFrom.Size = new System.Drawing.Size(83, 13);
            this.LblSearchFrom.TabIndex = 97;
            this.LblSearchFrom.Text = "Product From";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(139, 52);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(133, 21);
            this.dtpFromDate.TabIndex = 96;
            this.dtpFromDate.Enter += new System.EventHandler(this.dtpFromDate_Enter);
            this.dtpFromDate.Leave += new System.EventHandler(this.dtpFromDate_Leave);
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(20, 58);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(74, 13);
            this.lblDateRange.TabIndex = 95;
            this.lblDateRange.Text = "Date Range";
            // 
            // grpFooter
            // 
            this.grpFooter.Controls.Add(this.RdoStockSales);
            this.grpFooter.Controls.Add(this.RdoGp);
            this.grpFooter.Controls.Add(this.RdoQty);
            this.grpFooter.Controls.Add(this.RdoValue);
            this.grpFooter.Controls.Add(this.lblBasedOn);
            this.grpFooter.Location = new System.Drawing.Point(1, 158);
            this.grpFooter.Name = "grpFooter";
            this.grpFooter.Size = new System.Drawing.Size(794, 55);
            this.grpFooter.TabIndex = 12;
            this.grpFooter.TabStop = false;
            // 
            // RdoStockSales
            // 
            this.RdoStockSales.AutoSize = true;
            this.RdoStockSales.Location = new System.Drawing.Point(384, 23);
            this.RdoStockSales.Name = "RdoStockSales";
            this.RdoStockSales.Size = new System.Drawing.Size(130, 17);
            this.RdoStockSales.TabIndex = 125;
            this.RdoStockSales.Tag = "1";
            this.RdoStockSales.Text = "Purchase Vs Sales";
            this.RdoStockSales.UseVisualStyleBackColor = true;
            this.RdoStockSales.Enter += new System.EventHandler(this.RdoStockSales_Enter);
            this.RdoStockSales.Leave += new System.EventHandler(this.RdoStockSales_Leave);
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
            this.RdoGp.Enter += new System.EventHandler(this.RdoGp_Enter);
            this.RdoGp.Leave += new System.EventHandler(this.RdoGp_Leave);
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
            this.RdoQty.Enter += new System.EventHandler(this.RdoQty_Enter);
            this.RdoQty.Leave += new System.EventHandler(this.RdoQty_Leave);
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
            this.RdoValue.Enter += new System.EventHandler(this.RdoValue_Enter);
            this.RdoValue.Leave += new System.EventHandler(this.RdoValue_Leave);
            // 
            // lblBasedOn
            // 
            this.lblBasedOn.AutoSize = true;
            this.lblBasedOn.Location = new System.Drawing.Point(24, 25);
            this.lblBasedOn.Name = "lblBasedOn";
            this.lblBasedOn.Size = new System.Drawing.Size(62, 13);
            this.lblBasedOn.TabIndex = 121;
            this.lblBasedOn.Text = "Based On";
            // 
            // FrmBinCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(799, 265);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpFooter);
            this.Name = "FrmBinCard";
            this.Load += new System.EventHandler(this.FrmBinCard_Load);
            this.Controls.SetChildIndex(this.grpFooter, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpFooter.ResumeLayout(false);
            this.grpFooter.PerformLayout();
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
                Common.UnHighlightControl(LblSearchFrom);
                if (string.IsNullOrEmpty(TxtSearchCodeFrom.Text.Trim())) { return; }
                InvProductMaster invProductMaster = new InvProductMaster();
                if (Common.IsBatch)
                {
                    InvProductStockMasterService invProductStockMasterService = new InvProductStockMasterService();
                    invProductMaster = invProductStockMasterService.GetProductMasterBystockCode(TxtSearchCodeFrom.Text.Trim());

                    if (invProductMaster != null)
                    {
                        //TxtSearchCodeFrom.Text = invProductMaster.ProductCode;
                        TxtSearchNameFrom.Text = invProductMaster.ProductName;
                    }

                }
                else
                {
                    InvProductMasterService invProductMasterService = new InvProductMasterService();
                   

                    invProductMaster = invProductMasterService.GetProductsByCode(TxtSearchCodeFrom.Text.Trim());

                    if (invProductMaster != null)
                    {
                        TxtSearchCodeFrom.Text = invProductMaster.ProductCode;
                        TxtSearchNameFrom.Text = invProductMaster.ProductName;
                    }
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
                Common.UnHighlightControl(LblSerachTo);
                if (string.IsNullOrEmpty(TxtSearchCodeTo.Text.Trim())) { return; }

                InvProductMaster invProductMaster = new InvProductMaster();
                if (Common.IsBatch)
                {
                    InvProductStockMasterService invProductStockMasterService = new InvProductStockMasterService();
                    invProductMaster = invProductStockMasterService.GetProductMasterBystockCode(TxtSearchCodeFrom.Text.Trim());

                    if (invProductMaster != null)
                    {
                        //TxtSearchCodeFrom.Text = invProductMaster.ProductCode;
                        TxtSearchNameTo.Text = invProductMaster.ProductName;
                    }

                }
                else
                {
                    InvProductMasterService invProductMasterService = new InvProductMasterService();


                    invProductMaster = invProductMasterService.GetProductsByCode(TxtSearchCodeFrom.Text.Trim());

                    if (invProductMaster != null)
                    {
                        TxtSearchCodeFrom.Text = invProductMaster.ProductCode;
                        TxtSearchNameFrom.Text = invProductMaster.ProductName;
                    }
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

        private void RdoSlow_CheckedChanged(object sender, EventArgs e)
        {
            EnableDesableFooter();
        }

        private void EnableDesableFooter()
        {
            try
            {
                if (RdoFast.Checked == true || RdoSlow.Checked == true || RdoNon.Checked == true)
                {
                    grpFooter.Enabled = true;
                }
                else
                {
                    grpFooter.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void RdoBinCard_CheckedChanged(object sender, EventArgs e)
        {
            EnableDesableFooter();
        }

        private void RdoMovement_CheckedChanged(object sender, EventArgs e)
        {
            EnableDesableFooter();
        }

        private void RdoStockAging_CheckedChanged(object sender, EventArgs e)
        {
            EnableDesableFooter();
        }

        private void RdoFast_CheckedChanged(object sender, EventArgs e)
        {
            EnableDesableFooter();
        }

        private void RdoNon_CheckedChanged(object sender, EventArgs e)
        {
            EnableDesableFooter();
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

        private void RdoStockAging_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(RdoStockAging);
        }

        private void RdoStockAging_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(RdoStockAging);
        }

        private void RdoFast_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(RdoFast);
        }

        private void RdoFast_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(RdoFast);
        }

        private void RdoSlow_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(RdoSlow);
        }

        private void RdoSlow_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(RdoSlow);
        }

        private void RdoNon_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(RdoNon);
        }

        private void RdoNon_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(RdoNon);
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

        private void ChkAutoComplteFrom_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(LblSearchFrom);
        }

        private void ChkAutoComplteFrom_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(LblSearchFrom);
        }

        private void TxtSearchCodeFrom_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(LblSearchFrom);
        }

        private void TxtSearchNameFrom_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(LblSearchFrom);
        }

        private void TxtSearchNameFrom_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(LblSearchFrom);
        }

        private void ChkAutoComplteTo_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(LblSerachTo);
        }

        private void ChkAutoComplteTo_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(LblSerachTo);
        }

        private void TxtSearchCodeTo_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(LblSerachTo);
        }

        private void TxtSearchNameTo_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(LblSerachTo);
        }

        private void TxtSearchNameTo_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(LblSerachTo);
        }

        private void RdoQty_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblBasedOn);
        }

        private void RdoQty_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblBasedOn);
        }

        private void RdoValue_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblBasedOn);
        }

        private void RdoValue_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblBasedOn);
        }

        private void RdoGp_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblBasedOn);
        }

        private void RdoGp_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblBasedOn);
        }

        private void RdoStockSales_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblBasedOn);
        }

        private void RdoStockSales_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblBasedOn);
        }
        
    }
}
