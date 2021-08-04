using ERP.Service;
using ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ERP.Report.Inventory.Transactions.Reports;

namespace ERP.Report.GUI
{
    public partial class FrmDaySalesSummary : global::ERP.UI.Windows.FrmBaseReportsForm
    {
        public FrmDaySalesSummary()
        {
            InitializeComponent();
        }

        #region Override Methods
        public override void InitializeForm()
        {
            try
            {
                LocationService locationService = new LocationService();
                Common.LoadLocations(cmbLocation, locationService.GetAllLocations());
                cmbLocation.SelectedValue = Common.LoggedLocationID;
                base.InitializeForm();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        public override void FormLoad()
        {
            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();
            base.FormLoad();
        }


        public override void ClearForm()
        {
            try
            {
                Common.ClearComboBox(cmbLocation);
                cmbLocation.Focus();
                cmbLocation.SelectedValue = Common.LoggedLocationID;

                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();

                base.ClearForm();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }


        }

        #endregion

        #region Private Methods
        private void ViewReport(DateTime fromDate, DateTime toDate, int locationID)
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            InvSalesServices invSalesServices = new InvSalesServices();

            InvRptTransactionDaySalesSummary invRptTransactionDaySalesSummary = new InvRptTransactionDaySalesSummary();
            invRptTransactionDaySalesSummary.SetDataSource(invSalesServices.GetDataSourceDaySalesSummeryReport(fromDate, toDate, locationID));

            invRptTransactionDaySalesSummary.SummaryInfo.ReportTitle = "Day Sales Summry Report";
            invRptTransactionDaySalesSummary.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = invRptTransactionDaySalesSummary;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }
        public override void View()
        {
            InvSalesServices invSalesServices = new InvSalesServices();

            int locationId = 0;

            DateTime dateFrom = dtpFromDate.Value;
            DateTime dateTo = dtpToDate.Value;
            locationId = Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString());

            if (dateFrom > dateTo)
            {
                Toast.Show(this.Text, "", "", Toast.messageType.Information, Toast.messageAction.InvalidDateRange);
                return;
            }

            if (invSalesServices.View(locationId, dateFrom, dateTo) == true)
            {
                ViewReport();

            }
            else
            {
                Toast.Show(this.Text, "No data to Process.", "", Toast.messageType.Warning, Toast.messageAction.General);
                return;
            }

            this.Cursor = Cursors.Default;
            base.View();
        }
        private void ViewReport()
        {

            FrmReportViewer reportViewer = new FrmReportViewer();
            InvSalesServices invSalesServices = new InvSalesServices();

            InvRptTransactionDaySalesSummary invRptTransactionDaySalesSummary = new InvRptTransactionDaySalesSummary();

            //DataTable dt = posSalesSummeryService.GetSalesSum();

            invRptTransactionDaySalesSummary.SetDataSource(invSalesServices.GetSalesSum());
            invRptTransactionDaySalesSummary.SummaryInfo.ReportTitle = "Daily Sales Summary";
            invRptTransactionDaySalesSummary.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Text + "'";
            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Text + "'";
            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";
            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            invRptTransactionDaySalesSummary.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            reportViewer.crRptViewer.ReportSource = invRptTransactionDaySalesSummary;
            reportViewer.WindowState = FormWindowState.Maximized;
            reportViewer.Show();
            Cursor.Current = Cursors.Default;

        }

        #endregion

        private void btnView_Click(object sender, EventArgs e)
        {/*
            try
            {
                DateTime dateFrom;
                DateTime dateTo;

                dateFrom = dtpFromDate.Value;
                dateTo = dtpToDate.Value;

                if (!string.IsNullOrEmpty(cmbLocation.Text.Trim()))
                {
                    ViewReport(dateFrom, dateTo, Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()));
                }
                else
                {
                    if (string.IsNullOrEmpty(cmbLocation.Text.Trim()))
                    {
                        Toast.Show(this.Text, "", "Please Select Location", Toast.messageType.Information, Toast.messageAction.General);
                    }
                    else
                    {
                        Toast.Show(this.Text, "", "Please Select Billing Location", Toast.messageType.Information, Toast.messageAction.General);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }*/
        }

       
    }
}
