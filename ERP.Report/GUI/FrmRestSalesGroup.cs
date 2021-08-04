using ERP.Domain;
using ERP.Report.CRM.Reports;
using ERP.Service;
using ERP.Service.Restaurant;
using ERP.UI.Windows;
using ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Report.Restaurant.Transactions.Reports;

//develop by Anu
namespace ERP.Report.GUI
{
    public partial class FrmRestSalesGroup: FrmBaseReportsForm
    {
        public FrmRestSalesGroup(AutoGenerateInfo autoGenerateInfo) 
        {
            InitializeComponent();
            this.Text = autoGenerateInfo.FormText;
        }

        public override void InitializeForm()
        {
            LocationService locationService = new LocationService();
            Common.LoadLocations(cmbLocation, locationService.GetAllLocations());
            cmbLocation.SelectedValue = Common.LoggedLocationID;

            BillingLocationService billingLocationService = new BillingLocationService();
            Common.LoadBillingLocations(cmbBillingLocation, billingLocationService.GetAllBillingLocations());

            base.InitializeForm();
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


        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateFrom;
                DateTime dateTo;

                dateFrom = dtpFromDate.Value;
                dateTo = dtpToDate.Value;

                if (!string.IsNullOrEmpty(cmbLocation.Text.Trim()) && !string.IsNullOrEmpty(cmbBillingLocation.Text.Trim()))
                {
                    ViewReport(dateFrom, dateTo, Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()), Common.ConvertStringToInt(cmbBillingLocation.SelectedValue.ToString()));
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
            }
        }


        private void ViewReport(DateTime fromDate, DateTime toDate,int locationID, int billingLocationID) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            ResSalesServices ResSalesServices = new ResSalesServices();
            ResRptSalesGroupedReport resRptSalesGroupedReport = new ResRptSalesGroupedReport();

            resRptSalesGroupedReport.SetDataSource(ResSalesServices.GetDataSourceSaleWithGroupingReport(fromDate, toDate, locationID, billingLocationID));

            resRptSalesGroupedReport.SummaryInfo.ReportTitle = "Sales Report (Group)";
            resRptSalesGroupedReport.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            resRptSalesGroupedReport.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            resRptSalesGroupedReport.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            resRptSalesGroupedReport.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            resRptSalesGroupedReport.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            resRptSalesGroupedReport.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptSalesGroupedReport.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptSalesGroupedReport.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            resRptSalesGroupedReport.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";
            resRptSalesGroupedReport.DataDefinition.FormulaFields["BillingLocation"].Text = "'" + cmbBillingLocation.Text.Trim() + "'";

            objReportView.crRptViewer.ReportSource = resRptSalesGroupedReport;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }
    }
}
