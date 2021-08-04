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
    public partial class FrmBrowseInvoice : FrmBaseReportsForm
    {

        private string receiptNo;
        private long shiftNo;
        private long zNo;
        private DateTime recDate;
        private long unitNo;
        private int intlocationID;
        private int intbillingLocationID;


        public FrmBrowseInvoice(int locationID, int billingLocationID,DateTime dateFrom,DateTime dateTo)
        {
            InitializeComponent();
            ResSalesServices ResSalesServices = new ResSalesServices();
            dgvInvoice.AutoGenerateColumns = false;
            dgvInvoice.DataSource = ResSalesServices.GetInvoiceDetails(dateFrom, dateTo, locationID, billingLocationID);
            dgvInvoice.Refresh();
            dgvInvoice.Focus();
            receiptNo = string.Empty;
            shiftNo = 0;
            zNo = 0;
            intlocationID = locationID;
            intbillingLocationID = billingLocationID;

            
        }

        private void dgvInvoice_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                if (dgvInvoice.CurrentCell != null && dgvInvoice.CurrentCell.RowIndex >= 0)
                {

                    int selectedRowIndex = dgvInvoice.CurrentCell.RowIndex;
                    receiptNo = dgvInvoice["InvoiceNo", dgvInvoice.CurrentCell.RowIndex].Value.ToString().Trim();
                    shiftNo = Common.ConvertStringToLong(dgvInvoice["shiftNo", dgvInvoice.CurrentCell.RowIndex].Value.ToString().Trim());
                    zNo = Common.ConvertStringToLong(dgvInvoice["zNo", dgvInvoice.CurrentCell.RowIndex].Value.ToString().Trim());
                    recDate = Common.ConvertStringToDate(dgvInvoice["InvoiceDate", dgvInvoice.CurrentCell.RowIndex].Value.ToString().Trim());
                    unitNo = Common.ConvertStringToLong(dgvInvoice["UnitNo", dgvInvoice.CurrentCell.RowIndex].Value.ToString().Trim());

                    FrmReportViewer objReportView = new FrmReportViewer();
                    ResSalesServices ResSalesServices = new ResSalesServices();
                    ResRptInvoice resRptInvoice = new ResRptInvoice();

                    resRptInvoice.SetDataSource(ResSalesServices.GetInvoice(receiptNo,recDate,unitNo,shiftNo,zNo,intlocationID,intbillingLocationID));

                    resRptInvoice.SummaryInfo.ReportTitle = "Sales Summery Report";
                    resRptInvoice.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

                    resRptInvoice.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                    //resRptInvoice.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
                    //resRptInvoice.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
                    //resRptInvoice.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                    //resRptInvoice.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    resRptInvoice.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    resRptInvoice.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                    objReportView.crRptViewer.ReportSource = resRptInvoice;
                    objReportView.WindowState = FormWindowState.Maximized;
                    objReportView.Show();
                    Cursor.Current = Cursors.Default;
                   
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodBase.GetCurrentMethod().Name, this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }
    }
}
