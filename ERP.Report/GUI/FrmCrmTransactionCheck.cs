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
using ERP.Report.CRM.Reports;
using ERP.Report.GUI;

namespace ERP.Report.GUI
{
    public partial class FrmCrmTransactionCheck : FrmBaseReportsForm
    {
        int documentID = 0;
        UserPrivileges accessRights = new UserPrivileges();
        bool isValidControls = true;
        string formDisplayText = "";

        List<CardMaster> CardMasterList;

        public FrmCrmTransactionCheck(string formText)
        {
            InitializeComponent();
            formDisplayText = formText;
        }

        public override void InitializeForm()
        {
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
            LocationService locationService = new LocationService();

            Common.LoadLocations(cmbLocation, locationService.GetAllLocations());

            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();

            cmbLocation.SelectedValue = Common.LoggedLocationID;

            base.InitializeForm();
        }

        public override void FormLoad()
        {
            //AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
            //autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm(this.Name);
            this.Text = formDisplayText;

            //documentID = autoGenerateInfo.DocumentID;
            accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);

            base.FormLoad();
        }

        public override void ClearForm()
        {
            try
            {
                this.Cursor = Cursors.Default;

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

                if (rdoBillMorreThanOneRedeem.Checked)
                {
                    if (chkAlllocations.Checked)
                    {
                        ViewReportAllLocationsRedeem(dateFrom, dateTo);
                    }
                    else
                    {
                        ViewReportSelectedLocationRedeem(Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()), dateFrom, dateTo);
                    }
                }
                else
                {
                    ViewReportEarn();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private bool ValidateLocationComboBoxes()
        {
            return Validater.ValidateComboBox("",errorProvider, Validater.ValidateType.Empty, cmbLocation);
        }

        private void ViewReportAllLocationsRedeem(DateTime fromDate, DateTime toDate) // 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptTransactionCheck crmRptTransactionCheck = new CrmRptTransactionCheck();

            crmRptTransactionCheck.SetDataSource(loyaltyReportService.TransactionCheckAllLocationsRedeem(fromDate, toDate));

            crmRptTransactionCheck.SummaryInfo.ReportTitle = "Bills More Than One Redeem";
            crmRptTransactionCheck.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptTransactionCheck.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptTransactionCheck.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptTransactionCheck.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            crmRptTransactionCheck.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptTransactionCheck.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptTransactionCheck.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptTransactionCheck.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptTransactionCheck;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewReportSelectedLocationRedeem(int locationID, DateTime fromDate, DateTime toDate) // 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptTransactionCheck crmRptTransactionCheck = new CrmRptTransactionCheck();

            crmRptTransactionCheck.SetDataSource(loyaltyReportService.TransactionCheckSelectedLocationsRedeem(fromDate, toDate, locationID));

            crmRptTransactionCheck.SummaryInfo.ReportTitle = "Bills More Than One Redeem";

            crmRptTransactionCheck.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptTransactionCheck.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptTransactionCheck.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptTransactionCheck.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            crmRptTransactionCheck.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptTransactionCheck.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptTransactionCheck.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptTransactionCheck.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptTransactionCheck;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }


        private void ViewReportEarn() //   
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptTransactionCheckEarn crmRptTransactionCheckEarn = new CrmRptTransactionCheckEarn();

            crmRptTransactionCheckEarn.SetDataSource(loyaltyReportService.TransactionCheckEarn());

            crmRptTransactionCheckEarn.SummaryInfo.ReportTitle = "Bills More Than One Earn";
            crmRptTransactionCheckEarn.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptTransactionCheckEarn.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptTransactionCheckEarn.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptTransactionCheckEarn.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            crmRptTransactionCheckEarn.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptTransactionCheckEarn.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptTransactionCheckEarn.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptTransactionCheckEarn.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptTransactionCheckEarn;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void chkAlllocations_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAlllocations.Checked)
                {
                    cmbLocation.SelectedIndex = -1;
                    cmbLocation.Enabled = false;
                }
                else
                {
                    cmbLocation.Enabled = true;
                    cmbLocation.SelectedValue = Common.LoggedLocationID;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void rdoBillsMoreThanOneEarn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoBillsMoreThanOneEarn.Checked)
                {
                    dtpFromDate.Enabled = false;
                    dtpToDate.Enabled = false;
                    cmbLocation.Enabled = false;
                    chkAlllocations.Enabled = false;
                }
                else
                {
                    dtpFromDate.Enabled = true;
                    dtpToDate.Enabled = true;
                    cmbLocation.Enabled = true;
                    chkAlllocations.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

    }
}
