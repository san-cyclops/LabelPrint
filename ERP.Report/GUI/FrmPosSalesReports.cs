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
    public partial class FrmPosSalesReports : FrmBaseReportsForm
    {
        int documentID = 0;
        UserPrivileges accessRights = new UserPrivileges();
        UserPrivileges percentageRights = new UserPrivileges();
        static string strReportName;

        public FrmPosSalesReports()
        {
            InitializeComponent();
        }

        public FrmPosSalesReports(string strFReportName)
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
            if (documentID == 8007) // Sales Refund Report
            {
                LoadPosSalesRefundReport();
            }
            if (documentID ==8008) // Void Error Report
            {
                LoadPosVoidErrorReport();
 
            }
            if (documentID == 8010)  // Bill Wise Sales Report
            {
                LoadBillWiseSalesReport();

            }

           

        }

        public override void Print()
        {
            if (documentID == 8007) // Sales Refund Report
            {
                PrintPosSalesRefundReport();

            }

            if (documentID == 8008)  // Void Error Report
            {
                PrintPosVoidErrorReport();

            }


            if (documentID == 8010)  // Bill Wise Sales Report
            {
                PrintPosBillWiseSalesReport();

            }



        }


        //__________________________________Void Error Repor ____________________________________
        public void LoadPosVoidErrorReport()
        {
            PosSalesReportsService posSalesReportsService = new PosSalesReportsService();

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

                if (posSalesReportsService.ViewPosVoidError(locationId, terminalId, dateFrom, dateTo, true, documentID) == true)
                {
                    ViewPosVoidErrorReport();
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

                if (posSalesReportsService.ViewPosVoidError(locationId, terminalId, dateFrom, dateTo, true, documentID) == true)
                {
                    ViewPosVoidErrorReport();
                }
                else
                {
                    Toast.Show(this.Text, "Error in data Processing.", "", Toast.messageType.Error, Toast.messageAction.General);
                    return;
                }


            }
            this.Cursor = Cursors.Default;
        }
       

        public void PrintPosVoidErrorReport()
        { 
             PosSalesReportsService posSalesReportsService = new PosSalesReportsService();

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
                if (posSalesReportsService.ViewPosVoidError(locationId, terminalId, dateFrom, dateTo, true, documentID) == true)
                {
                    PrintVoidErrorReport();

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
                if (posSalesReportsService.ViewPosVoidError(locationId, terminalId, dateFrom, dateTo, false, documentID) == true)
                {
                    PrintVoidErrorReport();

                }
                else
                {
                    Toast.Show(this.Text, "Error in data Processing.", "", Toast.messageType.Error, Toast.messageAction.General);
                    return;
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ViewPosVoidErrorReport()
        {

            FrmReportViewer reportViewer = new FrmReportViewer();
            PosSalesReportsService posSalesReportService = new PosSalesReportsService();

            InvRptPosVoidError invRptPosVoidError = new InvRptPosVoidError();

            DataTable dt = posSalesReportService.GetPosVoidSale(documentID);
            invRptPosVoidError.SetDataSource(posSalesReportService.GetPosVoidSale(documentID));

            invRptPosVoidError.SummaryInfo.ReportTitle = "POS Void Error Report";
            invRptPosVoidError.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            invRptPosVoidError.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["SelectTerminal"].Text = "'" + cmbTerminal.Text.Trim() + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            reportViewer.crRptViewer.ReportSource = invRptPosVoidError;
            reportViewer.WindowState = FormWindowState.Maximized;
            reportViewer.Show();
            Cursor.Current = Cursors.Default;

        }

       

        private void PrintVoidErrorReport()
        {

            FrmReportViewer reportViewer = new FrmReportViewer();
            PosSalesReportsService posSalesReportsService = new PosSalesReportsService();

            InvRptPosVoidError invRptPosVoidError = new InvRptPosVoidError();

            //DataTable dt = posSalesSummeryService.GetSalesSum();

            invRptPosVoidError.SetDataSource(posSalesReportsService.GetPosVoidSale(documentID));
            invRptPosVoidError.SummaryInfo.ReportTitle = "POS Void Error Report";
            invRptPosVoidError.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            invRptPosVoidError.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["SelectTerminal"].Text = "'" + cmbTerminal.Text.Trim() + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            invRptPosVoidError.PrintToPrinter(1, false, 0, 0);
            Cursor.Current = Cursors.Default;

        }


        //___________________________________________POS Sales Refund ________________________________________


        public void LoadPosSalesRefundReport()
        {
            PosSalesReportsService posSalesReportsService = new PosSalesReportsService();

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

                if (posSalesReportsService.ViewPOSSalesRefund(locationId, terminalId, dateFrom, dateTo, true, documentID) == true)
                {
                    ViewSalesRefundReport();
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

                if (posSalesReportsService.ViewPOSSalesRefund(locationId, terminalId, dateFrom, dateTo, true, documentID) == true)
                {
                    ViewSalesRefundReport();
                }
                else
                {
                    Toast.Show(this.Text, "Error in data Processing.", "", Toast.messageType.Error, Toast.messageAction.General);
                    return;
                }


            }
            this.Cursor = Cursors.Default;
        }


        public void PrintPosSalesRefundReport()
        {
            PosSalesReportsService posSalesReportsService = new PosSalesReportsService();

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
                if (posSalesReportsService.ViewPOSSalesRefund(locationId, terminalId, dateFrom, dateTo, true, documentID) == true)
                {
                    PrintPosSalesRefund();

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
                if (posSalesReportsService.ViewPOSSalesRefund(locationId, terminalId, dateFrom, dateTo, false, documentID) == true)
                {
                    PrintPosSalesRefund();

                }
                else
                {
                    Toast.Show(this.Text, "Error in data Processing.", "", Toast.messageType.Error, Toast.messageAction.General);
                    return;
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ViewSalesRefundReport()
        {

            FrmReportViewer reportViewer = new FrmReportViewer();
            PosSalesReportsService posSalesReportService = new PosSalesReportsService();

            InvRptPosVoidError invRptPosVoidError = new InvRptPosVoidError();

            DataTable dt = posSalesReportService.GetPosSaleRefund(documentID);
            invRptPosVoidError.SetDataSource(posSalesReportService.GetPosSaleRefund(documentID));

            invRptPosVoidError.SummaryInfo.ReportTitle = "POS Sales Refund Report";
            invRptPosVoidError.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            invRptPosVoidError.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["SelectTerminal"].Text = "'" + cmbTerminal.Text.Trim() + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            reportViewer.crRptViewer.ReportSource = invRptPosVoidError;
            reportViewer.WindowState = FormWindowState.Maximized;
            reportViewer.Show();
            Cursor.Current = Cursors.Default;

        }



        private void PrintPosSalesRefund()
        {

            FrmReportViewer reportViewer = new FrmReportViewer();
            PosSalesReportsService posSalesReportsService = new PosSalesReportsService();

            InvRptPosVoidError invRptPosVoidError = new InvRptPosVoidError();

            //DataTable dt = posSalesSummeryService.GetSalesSum();

            invRptPosVoidError.SetDataSource(posSalesReportsService.GetPosSaleRefund(documentID));
            invRptPosVoidError.SummaryInfo.ReportTitle = "POS Sales Refund Report";
            invRptPosVoidError.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            invRptPosVoidError.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["SelectTerminal"].Text = "'" + cmbTerminal.Text.Trim() + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            invRptPosVoidError.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            invRptPosVoidError.PrintToPrinter(1, false, 0, 0);
            Cursor.Current = Cursors.Default;

        }



        //___________________________________________Bill Wise Sales Report ________________________________________


        public void LoadBillWiseSalesReport()
        {
            PosSalesReportsService posSalesReportsService = new PosSalesReportsService();

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

                if (posSalesReportsService.ViewBillWiseSalesReport(locationId, terminalId, dateFrom, dateTo, true, documentID) == true)
                {
                    ViewBillWiseSalesReport();
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

                if (posSalesReportsService.ViewBillWiseSalesReport(locationId, terminalId, dateFrom, dateTo, true, documentID) == true)
                {
                    ViewBillWiseSalesReport();
                }
                else
                {
                    Toast.Show(this.Text, "Error in data Processing.", "", Toast.messageType.Error, Toast.messageAction.General);
                    return;
                }


            }
            this.Cursor = Cursors.Default;
        }


        public void PrintPosBillWiseSalesReport()
        {
            PosSalesReportsService posSalesReportsService = new PosSalesReportsService();

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
                if (posSalesReportsService.ViewBillWiseSalesReport(locationId, terminalId, dateFrom, dateTo, true, documentID) == true)
                {
                    PrintBillWiseSales();

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
                if (posSalesReportsService.ViewBillWiseSalesReport(locationId, terminalId, dateFrom, dateTo, false, documentID) == true)
                {
                    PrintBillWiseSales();

                }
                else
                {
                    Toast.Show(this.Text, "Error in data Processing.", "", Toast.messageType.Error, Toast.messageAction.General);
                    return;
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ViewBillWiseSalesReport()
        {

            FrmReportViewer reportViewer = new FrmReportViewer();
            PosSalesReportsService posSalesReportService = new PosSalesReportsService();

            InvRptPosBillWiseSales invRptPosBillWiseSales = new InvRptPosBillWiseSales();

            DataTable dt = posSalesReportService.GetBillWiseSales(documentID);
            invRptPosBillWiseSales.SetDataSource(posSalesReportService.GetBillWiseSales(documentID));

            invRptPosBillWiseSales.SummaryInfo.ReportTitle = "POS Bill Wise Sales Report";
            invRptPosBillWiseSales.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            invRptPosBillWiseSales.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["SelectTerminal"].Text = "'" + cmbTerminal.Text.Trim() + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            reportViewer.crRptViewer.ReportSource = invRptPosBillWiseSales;
            reportViewer.WindowState = FormWindowState.Maximized;
            reportViewer.Show();
            Cursor.Current = Cursors.Default;

        }



        private void PrintBillWiseSales()
        {

            FrmReportViewer reportViewer = new FrmReportViewer();
            PosSalesReportsService posSalesReportsService = new PosSalesReportsService();

            InvRptPosBillWiseSales invRptPosBillWiseSales = new InvRptPosBillWiseSales();

            //DataTable dt = posSalesSummeryService.GetSalesSum();

            invRptPosBillWiseSales.SetDataSource(posSalesReportsService.GetBillWiseSales(documentID));
            invRptPosBillWiseSales.SummaryInfo.ReportTitle = "POS Bill Wise Sales Report";
            invRptPosBillWiseSales.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            invRptPosBillWiseSales.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["SelectTerminal"].Text = "'" + cmbTerminal.Text.Trim() + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            invRptPosBillWiseSales.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            invRptPosBillWiseSales.PrintToPrinter(1, false, 0, 0);
            Cursor.Current = Cursors.Default;

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

        private void FrmPosSalesReports_Load(object sender, EventArgs e)
        {

        }
    }
}
