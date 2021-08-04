using ERP.UI.Windows;
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
using ERP.UI.Windows.Reports;
using ERP.Utility;
using System.Collections;
using ERP.Report.Inventory;
using System.Reflection;
using ERP.Report.Logistic.Reference.Reports;
using ERP.Report.GUI;

namespace ERP.Report.GUI
{
    public partial class FrmLogistciBinCard : FrmBaseReportsForm
    {
        int documentID = 0;
        bool isValidControls = true;
        UserPrivileges accessRights = new UserPrivileges();
        LgsBinCardService binCardService = new LgsBinCardService();

        public FrmLogistciBinCard()
        {
            InitializeComponent();
        }

        public override void FormLoad()
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

            LoadSearchCodes();
            base.FormLoad();
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
                LgsProductMasterService lgsProductMasterService = new LgsProductMasterService();
                Common.SetAutoComplete(TxtSearchCodeFrom, lgsProductMasterService.GetAllProductCodes(), ChkAutoComplteFrom.Checked);
                Common.SetAutoComplete(TxtSearchNameFrom, lgsProductMasterService.GetAllProductNames(), ChkAutoComplteFrom.Checked);
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
                LgsProductMasterService lgsProductMasterService = new LgsProductMasterService();
                Common.SetAutoComplete(TxtSearchCodeTo, lgsProductMasterService.GetAllProductCodes(), ChkAutoComplteTo.Checked);
                Common.SetAutoComplete(TxtSearchNameTo, lgsProductMasterService.GetAllProductNames(), ChkAutoComplteTo.Checked);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        public override void ClearForm()
        {
            Common.ClearComboBox(cmbLocation);
            cmbLocation.Focus();

            cmbLocation.SelectedValue = Common.LoggedLocationID;

            TxtSearchCodeFrom.Text = string.Empty;
            TxtSearchCodeTo.Text = string.Empty;
            TxtSearchNameFrom.Text = string.Empty;
            TxtSearchNameTo.Text = string.Empty;

            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();

            base.ClearForm();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateFrom;
                DateTime dateTo;

                dateFrom = dtpFromDate.Value;
                dateTo = dtpToDate.Value;

                if (ValidateLocationComboBoxes().Equals(false)) { return; }

                if (ValidateControls() == false) return;

                if (dateFrom > dateTo)
                {
                    Toast.Show(this.Text, "","", Toast.messageType.Information, Toast.messageAction.InvalidDate);
                    return;
                }

                int locationId = Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString());

                //this.Cursor = Cursors.WaitCursor;
                if (binCardService.View(locationId, dateFrom, dateTo, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()) == true)
                {
                    ViewReport(locationId);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private bool ValidateLocationComboBoxes()
        {
            return Validater.ValidateComboBox(this.Text, errorProvider, Validater.ValidateType.Empty, cmbLocation);
        }

        private bool ValidateControls()
        {
            if (!Validater.ValidateTextBox(this.Text, errorProvider, Validater.ValidateType.Empty, TxtSearchCodeFrom, TxtSearchCodeTo))
            { return false; }

            else
            {
                isValidControls = true;
                this.ValidateChildren();

                return isValidControls;
            }
        }

        //private void ViewReport(int locationId)
        //{
        //    FrmReportViewer objReportView = new FrmReportViewer();
        //    Cursor.Current = Cursors.WaitCursor;

        //    if (RdoBinCard.Checked == true)
        //    {
        //        LgsRptBinCard lgsRptBinCard = new LgsRptBinCard();

        //        lgsRptBinCard.SetDataSource(binCardService.GetBinCardDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));


        //        lgsRptBinCard.SetDataSource(binCardService.DsGetBinCardDetails.Tables["BinCardDetails"]);

        //        lgsRptBinCard.SummaryInfo.ReportTitle = "Bin Card Report";
        //        lgsRptBinCard.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
        //        lgsRptBinCard.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";

        //        lgsRptBinCard.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
        //        lgsRptBinCard.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
        //        lgsRptBinCard.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
        //        lgsRptBinCard.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
        //        lgsRptBinCard.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";

        //        lgsRptBinCard.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
        //        lgsRptBinCard.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
        //        lgsRptBinCard.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
        //        lgsRptBinCard.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

        //        objReportView.crRptViewer.ReportSource = lgsRptBinCard;

        //    }

        //    objReportView.WindowState = FormWindowState.Maximized;
        //    objReportView.Show();
        //    Cursor.Current = Cursors.Default;
        //}
        private void ViewReport(int locationId)
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            Cursor.Current = Cursors.WaitCursor;

            LgsRptBinCard lgsRptBinCard = new LgsRptBinCard();
            lgsRptBinCard.SetDataSource(binCardService.GetBinCardDetails(locationId, TxtSearchCodeFrom.Text.Trim(), TxtSearchCodeTo.Text.Trim()));

            //lgsRptBinCard.SetDataSource(binCardService.DsGetBinCardDetails.Tables["BinCardDetails"]);

            lgsRptBinCard.SummaryInfo.ReportTitle = "Bin Card Report";
            lgsRptBinCard.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            lgsRptBinCard.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";
            lgsRptBinCard.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            lgsRptBinCard.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            lgsRptBinCard.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            lgsRptBinCard.DataDefinition.FormulaFields["CodeFrom"].Text = "'" + TxtSearchCodeFrom.Text.Trim() + "   " + TxtSearchNameFrom.Text.Trim() + "'";
            lgsRptBinCard.DataDefinition.FormulaFields["CodeTo"].Text = "'" + TxtSearchCodeTo.Text.Trim() + "   " + TxtSearchNameTo.Text.Trim() + "'";
            lgsRptBinCard.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            lgsRptBinCard.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            lgsRptBinCard.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            lgsRptBinCard.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = lgsRptBinCard;

            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
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

                LgsProductMasterService lgsProductMasterService = new LgsProductMasterService();
                LgsProductMaster lgsProductMaster = new LgsProductMaster();

                lgsProductMaster = lgsProductMasterService.GetProductsByCode(TxtSearchCodeFrom.Text.Trim());

                if (lgsProductMaster != null)
                {
                    TxtSearchCodeFrom.Text = lgsProductMaster.ProductCode;
                    TxtSearchNameFrom.Text = lgsProductMaster.ProductName;
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

                LgsProductMasterService lgsProductMasterService = new LgsProductMasterService();
                LgsProductMaster lgsProductMaster = new LgsProductMaster();

                lgsProductMaster = lgsProductMasterService.GetProductsByCode(TxtSearchCodeTo.Text.Trim());

                if (lgsProductMaster != null)
                {
                    TxtSearchCodeTo.Text = lgsProductMaster.ProductCode;
                    TxtSearchNameTo.Text = lgsProductMaster.ProductName;
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

        private void TxtSearchNameFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    TxtSearchCodeTo.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void TxtSearchNameFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(LblSearchFrom);
                if (string.IsNullOrEmpty(TxtSearchNameFrom.Text.Trim())) { return; }

                LgsProductMasterService lgsProductMasterService = new LgsProductMasterService();
                LgsProductMaster lgsProductMaster = new LgsProductMaster();

                lgsProductMaster = lgsProductMasterService.GetProductsByName(TxtSearchNameFrom.Text.Trim());

                if (lgsProductMaster != null)
                {
                    TxtSearchCodeFrom.Text = lgsProductMaster.ProductCode.Trim();
                    TxtSearchNameFrom.Text = lgsProductMaster.ProductName.Trim();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void TxtSearchNameTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void TxtSearchNameTo_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(LblSerachTo);
                if (string.IsNullOrEmpty(TxtSearchNameTo.Text.Trim())) { return; }

                LgsProductMasterService lgsProductMasterService = new LgsProductMasterService();
                LgsProductMaster lgsProductMaster = new LgsProductMaster();

                lgsProductMaster = lgsProductMasterService.GetProductsByName(TxtSearchNameTo.Text.Trim());

                if (lgsProductMaster != null)
                {
                    TxtSearchCodeTo.Text = lgsProductMaster.ProductCode.Trim();
                    TxtSearchNameTo.Text = lgsProductMaster.ProductName.Trim();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
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

        
        
    }
}
