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
using ERP.Report.CRM;
using ERP.Service;
using ERP.Domain;
using ERP.UI.Windows;
using ERP.UI.Windows.Reports;
using ERP.Utility;
using System.Collections;
using ERP.Report.Inventory;
using System.Reflection;
using ERP.Report.GUI;
using System.Threading;
using ERP.Report.CRM.Reports;

namespace ERP.Report.GUI
{
    public partial class FrmCrmGoldCardSelection : FrmBaseReportsForm
    {
        int documentID = 0;
        UserPrivileges accessRights = new UserPrivileges();
        bool isValidControls = true;
        string formDisplayText = "";

        public FrmCrmGoldCardSelection(string formText)
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

        public override void InitializeForm()
        {
            base.InitializeForm();

            prgBar.Value = prgBar.Minimum;
            errorProvider.Clear();
        }

        public override void FormLoad()
        {
            //AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
            //autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm(this.Name);
            this.Text = formDisplayText;

            //documentID = autoGenerateInfo.DocumentID;
            accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);

            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();

            //cmbLocation.Enabled = false;

            LoadSearchCodes();
            base.FormLoad();
        }

        private void LoadSearchCodes()
        {
            try
            {
                if (ChkAutoComplteFrom.Checked) { LoadCustomersFrom(); }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        private void LoadCustomersFrom() 
        {
            try
            {
                LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();

                Common.SetAutoComplete(TxtSearchCodeFrom, loyaltyCustomerService.GetAllLoyaltyCustomerCodes(), ChkAutoComplteFrom.Checked);
                Common.SetAutoComplete(TxtSearchNameFrom, loyaltyCustomerService.GetAllLoyaltyCustomerNames(), ChkAutoComplteFrom.Checked);
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
                TxtSearchCodeFrom.Text = string.Empty;
                TxtSearchNameFrom.Text = string.Empty;

                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();
                lblAmount.Enabled = true;
                txtAmount.Enabled = true;
                lblAmountdtl.Enabled = true;
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
                if (!chkAllCostomers.Checked && (string.IsNullOrEmpty(TxtSearchCodeFrom.Text.Trim())))
                {
                    Toast.Show(this.Text,"","Please select option", Toast.messageType.Information, Toast.messageAction.General);
                    return;
                }

                if (bgWorker == null) { bgWorker = new BackgroundWorker(); }
                prgBar.Value = prgBar.Minimum;
                bgWorker.RunWorkerAsync();

                LoyaltyCustomer loyaltyCustomer = new LoyaltyCustomer();
                LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();

                DateTime fromDate;
                DateTime toDate;
                DateTime issuedDate;
                decimal amount;
                int totalVisits;

                fromDate = dtpFromDate.Value;
                toDate = dtpToDate.Value;
                issuedDate = dtpIssuedDate.Value;

                if (string.IsNullOrEmpty(txtAmount.Text.Trim())) { amount = 0; }
                else { amount = Common.ConvertStringToDecimalCurrency(txtAmount.Text.Trim()); }

                if (string.IsNullOrEmpty(txtTotalVisit.Text.Trim())) { totalVisits = 0; }
                else { totalVisits = Common.ConvertStringToInt(txtTotalVisit.Text.Trim()); }

                if (fromDate > toDate)
                {
                    Toast.Show(this.Text, "", "", Toast.messageType.Information, Toast.messageAction.InvalidDate);
                    return;
                }

                if (chkAllCostomers.Checked)
                {
                    ViewReportAllCustomers(amount, totalVisits, fromDate, toDate, issuedDate);
                }
                else
                {
                    loyaltyCustomer = loyaltyCustomerService.GetLoyaltyCustomerByCode(TxtSearchCodeFrom.Text.Trim());

                    if (loyaltyCustomer == null)
                    {
                        Toast.Show(this.Text, "", "Invalid customer code", Toast.messageType.Information, Toast.messageAction.General);
                        TxtSearchCodeFrom.SelectAll();
                        TxtSearchCodeFrom.Focus();
                        return;
                    }

                    ViewReportSelectedlCustomers(loyaltyCustomer.LoyaltyCustomerID, amount, totalVisits, fromDate, toDate, issuedDate);
                }
                bgWorker = null;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private bool ValidateControls()
        {
            if (!Validater.ValidateTextBox("",errorProvider, Validater.ValidateType.Empty, TxtSearchCodeFrom))
            { return false; }

            else
            {
                isValidControls = true;
                this.ValidateChildren();

                return isValidControls;
            }
        }

        private void ViewReportAllCustomers(decimal amount, int totalVisits, DateTime fromDate, DateTime toDate, DateTime issuedDate)   
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();

            CrmRptGoldCardSelection crmRptGoldCardSelection = new CrmRptGoldCardSelection();

            crmRptGoldCardSelection.SetDataSource(loyaltyCustomerService.GetGoldCardSelectionAllCustomers(amount, totalVisits, fromDate, toDate, issuedDate));

            crmRptGoldCardSelection.SummaryInfo.ReportTitle = "Proposed Gold Card Customer Details";
            crmRptGoldCardSelection.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptGoldCardSelection.DataDefinition.FormulaFields["FromDate"].Text = "'" + fromDate + "'";
            crmRptGoldCardSelection.DataDefinition.FormulaFields["ToDate"].Text = "'" + toDate + "'";
            crmRptGoldCardSelection.DataDefinition.FormulaFields["IssuedDate"].Text = "'" + issuedDate + "'";

            crmRptGoldCardSelection.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptGoldCardSelection.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptGoldCardSelection.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptGoldCardSelection.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptGoldCardSelection.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            crmRptGoldCardSelection.DataDefinition.FormulaFields["AmountGraterThan"].Text = "'" + txtAmount.Text.Trim() + "'";

            prgBar.Value = prgBar.Maximum;

            objReportView.crRptViewer.ReportSource = crmRptGoldCardSelection;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewReportSelectedlCustomers(long customerId, decimal amount, int totalVisits, DateTime fromDate, DateTime toDate, DateTime issuedDate)  
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();

            CrmRptGoldCardSelection crmRptGoldCardSelection = new CrmRptGoldCardSelection();

            crmRptGoldCardSelection.SetDataSource(loyaltyCustomerService.GetGoldCardSelectionSelectedCustomers(customerId, amount, totalVisits, fromDate, toDate, issuedDate));

            crmRptGoldCardSelection.SummaryInfo.ReportTitle = "Gold Card Selection";
            crmRptGoldCardSelection.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptGoldCardSelection.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptGoldCardSelection.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptGoldCardSelection.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptGoldCardSelection.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptGoldCardSelection.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            crmRptGoldCardSelection.DataDefinition.FormulaFields["AmountGraterThan"].Text = "'" + txtAmount.Text.Trim() + "'";

            prgBar.Value = prgBar.Maximum;

            objReportView.crRptViewer.ReportSource = crmRptGoldCardSelection;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ChkAutoComplteFrom_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAutoComplteFrom.Checked)
                {
                    LoadCustomersFrom();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void TxtSearchCodeFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    TxtSearchNameFrom.Focus();
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
                if (string.IsNullOrEmpty(TxtSearchCodeFrom.Text))
                {
                    return;
                }
                else
                {
                    LoyaltyCustomer loyaltyCustomerFrom = new LoyaltyCustomer();
                    LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();

                    loyaltyCustomerFrom = loyaltyCustomerService.GetLoyaltyCustomerByCode(TxtSearchCodeFrom.Text.Trim());

                    if (loyaltyCustomerFrom != null)
                    {
                        TxtSearchCodeFrom.Text = loyaltyCustomerFrom.CustomerCode.Trim();
                        TxtSearchNameFrom.Text = loyaltyCustomerFrom.CustomerName.Trim();
                    }
                    else
                    {
                        Toast.Show("","","Invalid customer code", Toast.messageType.Information, Toast.messageAction.General);
                        TxtSearchCodeFrom.SelectAll();
                        TxtSearchCodeFrom.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void ClearSelection()
        {
            TxtSearchCodeFrom.Text = string.Empty;
            TxtSearchNameFrom.Text = string.Empty;
        }

        private void chkAllCostomers_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllCostomers.Checked)
                {
                    ClearSelection();
                    TxtSearchCodeFrom.Enabled = false;
                    TxtSearchNameFrom.Enabled = false;
                }
                else
                {
                    ClearSelection();
                    TxtSearchCodeFrom.Enabled = true;
                    TxtSearchNameFrom.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Validater.ValidateAmount(sender, e);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

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

        private void txtTotalVisit_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Validater.ValidateFigure(sender, e);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

    }
}
