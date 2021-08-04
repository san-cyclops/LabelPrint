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

namespace ERP.UI.Windows
{
    public partial class FrmCreditCardReport : FrmBaseReportsForm
    {
        int documentID = 0;
        UserPrivileges accessRights = new UserPrivileges();
        UserPrivileges percentageRights = new UserPrivileges();
        static string strReportName;

        public FrmCreditCardReport()
        {
            InitializeComponent();
        }

        public FrmCreditCardReport(string strFReportName)
        {
            InitializeComponent();
            strReportName = strFReportName;
        }

        public override void FormLoad()
        {
            try
            {

                // Load Locations
                LocationService locationService = new LocationService();
                Common.LoadLocations(cmbLocation, locationService.GetAllLocations());

                AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
                autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm(strReportName);

                documentID = autoGenerateInfo.DocumentID;

                accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);
                percentageRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);

             

                this.Text = autoGenerateInfo.FormText.Trim();
                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();

                base.FormLoad();



            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);

            }
        }

        private void ChkAllTerminals_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAllTerminals.Checked == true)
            {
                Common.ClearComboBox(cmbTerminal);
                cmbTerminal.Enabled = false;
            }
            else
            {
                cmbTerminal.Enabled = true;
            }
        }

        public override void CloseForm(string formName)
        {
            try
            {
                formName = this.Text.Trim();
                base.CloseForm(formName);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }



        public override void ClearForm()
        {
            base.ClearForm();

            Common.ClearComboBox(cmbTerminal, cmbLocation);
            cmbLocation.Focus();

            ChkAllTerminals.Checked = false;
            ChkAllLocations.Checked = false;
            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();

        }

        private bool ValidateComboBoxes()
        {
            return Validater.ValidateComboBox(this.Text, errorProvider, Validater.ValidateType.Empty, cmbTerminal, cmbLocation);
        }

        public override void View()
        {

            LoadPosCreditCards();
           

        }

        public override void Print()
        {
            PrintPosCreditCards();



        }


       
        public void LoadPosCreditCards()
        {
            PosSaleCreditCardsServices posSaleCreditCardsServices = new PosSaleCreditCardsServices();

            int locationId = 0;
            int terminalId = 0;

            DateTime dateFrom = dtpFromDate.Value;
            DateTime dateTo = dtpToDate.Value;

            if (dateFrom > dateTo)
            {
                Toast.Show(this.Text, "", "", Toast.messageType.Information, Toast.messageAction.InvalidDateRange);
                return;
            }
            if ((ChkAllTerminals.Checked) == true && (ChkAllLocations.Checked == true))
            {
                this.Cursor = Cursors.WaitCursor;

                if (posSaleCreditCardsServices.ViewPosSalesCreditCards(locationId, terminalId, dateFrom, dateTo, true) == true)
                {
                    ViewPosCreditCardReport();
                }
                else
                {
                    Toast.Show(this.Text, "Error in data Processing.", "", Toast.messageType.Error, Toast.messageAction.General);
                    return;
                }

            }
            else
            {
                if (ChkAllLocations.Checked == true) { locationId = 0; } else { locationId = cmbLocation.SelectedIndex + 1; }
                if (ChkAllTerminals.Checked == true) { terminalId = 0; } else { terminalId = cmbTerminal.SelectedIndex + 1; }

                if (ChkAllTerminals.Checked == false && ChkAllLocations.Checked == false)
                {
                    if (ValidateComboBoxes().Equals(false)) { return; }
                }


                this.Cursor = Cursors.WaitCursor;

                if (posSaleCreditCardsServices.ViewPosSalesCreditCards(locationId, terminalId, dateFrom, dateTo, true) == true)
                {
                    ViewPosCreditCardReport();
                }
                else
                {
                    Toast.Show(this.Text, "Error in data Processing.", "", Toast.messageType.Error, Toast.messageAction.General);
                    return;
                }


            }
            this.Cursor = Cursors.Default;
        }


        public void PrintPosCreditCards()
        {
            PosSaleCreditCardsServices posSaleCreditCardsServices = new PosSaleCreditCardsServices();

            int locationId = 0;
            int terminalId = 0;

            DateTime dateFrom = dtpFromDate.Value;
            DateTime dateTo = dtpToDate.Value;

            if (dateFrom > dateTo)
            {
                Toast.Show(this.Text, "", "", Toast.messageType.Information, Toast.messageAction.InvalidDateRange);
                return;
            }

            if ((ChkAllTerminals.Checked) == true && (ChkAllLocations.Checked == true))
            {
                this.Cursor = Cursors.WaitCursor;
                if (posSaleCreditCardsServices.ViewPosSalesCreditCards(locationId, terminalId, dateFrom, dateTo, true) == true)
                {
                    PrintPosCreditCardReport();

                }
                else
                {
                    Toast.Show(this.Text, "Error in data Processing.", "", Toast.messageType.Error, Toast.messageAction.General);
                    return;
                }
            }
            else
            {

                if (ChkAllLocations.Checked == true) { locationId = 0; } else { locationId = cmbLocation.SelectedIndex + 1; }
                if (ChkAllTerminals.Checked == true) { terminalId = 0; } else { terminalId = cmbTerminal.SelectedIndex + 1; }

                if (ChkAllTerminals.Checked == false && ChkAllLocations.Checked == false)
                {
                    if (ValidateComboBoxes().Equals(false)) { return; }
                }


                this.Cursor = Cursors.WaitCursor;
                if (posSaleCreditCardsServices.ViewPosSalesCreditCards(locationId, terminalId, dateFrom, dateTo, false) == true)
                {
                    PrintPosCreditCardReport();

                }
                else
                {
                    Toast.Show(this.Text, "Error in data Processing.", "", Toast.messageType.Error, Toast.messageAction.General);
                    return;
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ViewPosCreditCardReport()
        {

            FrmReportViewer reportViewer = new FrmReportViewer();
            PosSaleCreditCardsServices posSaleCreditCardsServices = new PosSaleCreditCardsServices();

            InvRptPosCreditCard invRptPosCreditCard = new InvRptPosCreditCard();

            DataTable dt = posSaleCreditCardsServices.GetPosCreditCard();
            invRptPosCreditCard.SetDataSource(posSaleCreditCardsServices.GetPosCreditCard());

            invRptPosCreditCard.SummaryInfo.ReportTitle = "POS Sale Credit Card Report";
            invRptPosCreditCard.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            invRptPosCreditCard.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["SelectTerminal"].Text = "'" + cmbTerminal.Text.Trim() + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            reportViewer.crRptViewer.ReportSource = invRptPosCreditCard;
            reportViewer.WindowState = FormWindowState.Maximized;
            reportViewer.Show();
            Cursor.Current = Cursors.Default;

        }



        private void PrintPosCreditCardReport()
        {

            FrmReportViewer reportViewer = new FrmReportViewer();
            PosSaleCreditCardsServices posSaleCreditCardsServices = new PosSaleCreditCardsServices();

            InvRptPosCreditCard invRptPosCreditCard = new InvRptPosCreditCard();

            //DataTable dt = posSalesSummeryService.GetSalesSum();

            invRptPosCreditCard.SetDataSource(posSaleCreditCardsServices.GetPosCreditCard());
            invRptPosCreditCard.SummaryInfo.ReportTitle = "POS Sale Credit Card Report";
            invRptPosCreditCard.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            invRptPosCreditCard.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["SelectTerminal"].Text = "'" + cmbTerminal.Text.Trim() + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            invRptPosCreditCard.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            invRptPosCreditCard.PrintToPrinter(1, false, 0, 0);
            Cursor.Current = Cursors.Default;

        }


       
        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void cmbLocation_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblLocation);
        }

        private void cmbLocation_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblLocation);
        }

        private void cmbTerminal_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblTerminal);
        }

        private void cmbTerminal_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblTerminal);
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
            Common.HighlightControl(lblToDate);
        }

        private void dtpToDate_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblToDate);
        }

        //private void ChkLocationWise_Enter(object sender, EventArgs e)
        //{
        //   // Common.HighlightControl(ChkLocationWise);
        //}

        //private void ChkLocationWise_Leave(object sender, EventArgs e)
        //{
        //    //Common.UnHighlightControl(ChkLocationWise);
        //}

        private void ChkAllLocations_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(ChkAllLocations);
        }

        private void ChkAllLocations_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(ChkAllLocations);
        }

        private void ChkAllTerminals_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(ChkAllTerminals);
        }

        private void ChkAllTerminals_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(ChkAllTerminals);
        }

        private void ChkAllLocations_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAllLocations.Checked == true)
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
    }
}
