
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.UI.Windows;
using ERP.Domain;
using System.Threading;
using ERP.Utility;
using System.Reflection;
using ERP.Report.CRM.Reports;
using ERP.Service;

namespace ERP.Report.GUI
{
    public partial class FrmCrmPurchaseBreakDown : FrmBaseReportsForm
    {

        int documentID = 0;
        UserPrivileges accessRights = new UserPrivileges();
        bool isValidControls = true;
        string formDisplayText = "";
        List<PurchaseBreakdown> updatedPurchaseBreakDownList = new List<PurchaseBreakdown>();
        List<PurchaseBreakdown> InitialPurchaseBreakDownList = new List<PurchaseBreakdown>();

        List<CardMaster> CardMasterList;
        public FrmCrmPurchaseBreakDown(string formText)
        {
            InitializeComponent();
            formDisplayText = formText;

            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
            bgWorker.ProgressChanged += bgWorker_ProgressChanged;
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
        }

        #region Override Methods
        public override void InitializeForm()
        {
            prgBar.Value = prgBar.Minimum;
            errorProvider.Clear();

            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
            //List<PointsBreakdown> pointsBreakdownList = new List<PointsBreakdown>();

            InitialPurchaseBreakDownList = loyaltyCustomerService.GetInitialPurchaseBreakdown();
            dgvBreakdown.DataSource = InitialPurchaseBreakDownList;
            dgvBreakdown.Refresh();
            base.InitializeForm();
        }

        public override void FormLoad()
        {
            this.Text = formDisplayText;
            accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);

            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();

            dgvBreakdown.AutoGenerateColumns = false;

            dgvCardType.AutoGenerateColumns = false;

            CommonService commonService = new CommonService();
            dgvCardType.DataSource = commonService.LoadCardMasterToGrid();
            dgvCardType.Refresh();
            base.FormLoad();
        }

        public override void ClearForm()
        {
            try
            {
                base.ClearForm();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        #endregion

        #region BackGround Worker Events
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(500);
                    if (bgWorker == null) { break; }
                    bgWorker.ReportProgress(i);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                prgBar.Value = e.ProgressPercentage;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        #endregion

        #region Private Methods
        private void GetSelectedCardTypes()
        {
            CardMasterList = new List<CardMaster>();
            for (int i = 0; i < dgvCardType.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvCardType.Rows[i].Cells["Select"].Value) == true)
                {
                    CardMaster cardMaster = new CardMaster();
                    CardMasterService cardMasterService = new CardMasterService();
                    int cardMasterID = Common.ConvertStringToInt(dgvCardType.Rows[i].Cells["CardMasterID"].Value.ToString().Trim());

                    cardMaster = cardMasterService.GetCardMasterById(cardMasterID);
                    CardMasterList.Add(cardMaster);
                }

            }
        }
        private void CheckAllCardTypes()
        {
            for (int i = 0; i < dgvCardType.RowCount; i++)
            {
                dgvCardType.Rows[i].Cells["Select"].Value = true;
            }
        }

        private void UnCheckAllCardTypes()
        {
            for (int i = 0; i < dgvCardType.RowCount; i++)
            {
                dgvCardType.Rows[i].Cells["Select"].Value = false;
            }
        }
        public void UpdateList()
        {
            updatedPurchaseBreakDownList = new List<PurchaseBreakdown>();
            foreach (DataGridViewRow row in dgvBreakdown.Rows)
            {
                PurchaseBreakdown purchaseBreakdown = new PurchaseBreakdown();
                purchaseBreakdown.PurchaseBreakdownID = Common.ConvertStringToLong(dgvBreakdown["PurchaseBreakdownID", row.Index].Value.ToString());
                purchaseBreakdown.RangeFrom = Common.ConvertStringToDecimal(dgvBreakdown["RangeFrom", row.Index].Value.ToString());
                purchaseBreakdown.RangeTo = Common.ConvertStringToDecimal(dgvBreakdown["RangeTo", row.Index].Value.ToString());

                updatedPurchaseBreakDownList.Add(purchaseBreakdown);
            }
        }

        private void ViewReportAllCustomers()
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();

            CrmRptPurchaseBreakDown crmRptPurchaseBreakDown = new CrmRptPurchaseBreakDown();

            crmRptPurchaseBreakDown.SetDataSource(loyaltyCustomerService.GetPurchaseBreakDownDetails());

            crmRptPurchaseBreakDown.SummaryInfo.ReportTitle = "Purchase Breakdown";
            crmRptPurchaseBreakDown.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptPurchaseBreakDown.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptPurchaseBreakDown.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptPurchaseBreakDown.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptPurchaseBreakDown.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptPurchaseBreakDown.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            crmRptPurchaseBreakDown.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptPurchaseBreakDown.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            prgBar.Value = prgBar.Maximum;

            objReportView.crRptViewer.ReportSource = crmRptPurchaseBreakDown;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }


        #endregion

        #region Other
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSelectAll.Checked) { CheckAllCardTypes(); }
                else { UnCheckAllCardTypes(); }
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
                if (bgWorker == null) { bgWorker = new BackgroundWorker(); }
                prgBar.Value = prgBar.Minimum;
                bgWorker.RunWorkerAsync();

                LoyaltyCustomer loyaltyCustomer = new LoyaltyCustomer();
                LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();

                DateTime dateFrom;
                DateTime dateTo;

                dateFrom = dtpFromDate.Value;
                dateTo = dtpToDate.Value;

                if (dateFrom > dateTo)
                {
                    Toast.Show(this.Text, "","", Toast.messageType.Information, Toast.messageAction.InvalidDate);
                    return;
                }

                UpdateList();
                GetSelectedCardTypes();

                prgBar.Value = prgBar.Maximum / 2;
                if (loyaltyCustomerService.UpdatePurchaseBreakdownList(updatedPurchaseBreakDownList, dateFrom, dateTo, CardMasterList))
                {
                    ViewReportAllCustomers();
                    prgBar.Value = prgBar.Maximum;
                }
                else
                {
                    Toast.Show(this.Text, "","Error found in report", Toast.messageType.Information, Toast.messageAction.General);
                    return;
                }

                bgWorker = null;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        #endregion
    }
}
