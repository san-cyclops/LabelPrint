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

namespace ERP.Report.GUI
{
    public partial class FrmRestInvoiceCancellation : FrmBaseReportsForm
    {
        public FrmRestInvoiceCancellation(AutoGenerateInfo autoGenerateInfo) 
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
            ResRptInvoiceWiseSales resRptInvoiceWiseSales = new ResRptInvoiceWiseSales();

            resRptInvoiceWiseSales.SetDataSource(ResSalesServices.GetDataSourceSalesSummeryReport(fromDate, toDate, locationID, billingLocationID));

            resRptInvoiceWiseSales.SummaryInfo.ReportTitle = "Sales Summery Report";
            resRptInvoiceWiseSales.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            resRptInvoiceWiseSales.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            resRptInvoiceWiseSales.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            resRptInvoiceWiseSales.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            resRptInvoiceWiseSales.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            resRptInvoiceWiseSales.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptInvoiceWiseSales.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptInvoiceWiseSales.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = resRptInvoiceWiseSales;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }
    }
}
