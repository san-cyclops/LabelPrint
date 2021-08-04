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
    public partial class FrmCrmUserPerformance : FrmBaseReportsForm
    {
        int documentID = 0;
        UserPrivileges accessRights = new UserPrivileges();
        bool isValidControls = true;
        string formDisplayText = "";

        List<CardMaster> CardMasterList;

        public FrmCrmUserPerformance(string formText)
        {
            InitializeComponent();
            formDisplayText = formText;
        }

        public override void InitializeForm()
        {
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
           
            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();

            base.InitializeForm();
        }

        public override void FormLoad()
        {
            //AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
            //autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm(this.Name);
            this.Text = formDisplayText;

            //documentID = autoGenerateInfo.DocumentID;
            accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);
            
            //cmbLocation.Enabled = false;

            base.FormLoad();
        }

        public override void ClearForm()
        {
            try
            {
                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();

                this.Cursor = Cursors.Default;

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

                if (chkAllUsers.Checked)
                {
                    ViewReportAllUsers(dateFrom, dateTo);
                }
                else
                {
                    ViewReportSelectedUsers(dateFrom, dateTo, txtUserName.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        private void ViewReportAllUsers(DateTime fromDate, DateTime toDate) //
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptUserPerformances crmRptUserPerformances = new CrmRptUserPerformances();

            crmRptUserPerformances.SetDataSource(loyaltyReportService.GetDataSourceAllUserPerformances(fromDate, toDate));

            crmRptUserPerformances.SummaryInfo.ReportTitle = "User Performances";

            crmRptUserPerformances.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptUserPerformances.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptUserPerformances.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptUserPerformances.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            crmRptUserPerformances.DataDefinition.FormulaFields["LocationName"].Text = "'All Locations'";

            crmRptUserPerformances.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptUserPerformances.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptUserPerformances.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptUserPerformances.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptUserPerformances;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewReportSelectedUsers(DateTime fromDate, DateTime toDate, string userName) //
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptUserPerformances crmRptUserPerformances = new CrmRptUserPerformances();

            crmRptUserPerformances.SetDataSource(loyaltyReportService.GetDataSourceSelectedUserPerformances(fromDate, toDate, userName));

            crmRptUserPerformances.SummaryInfo.ReportTitle = "User Performances";

            crmRptUserPerformances.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptUserPerformances.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptUserPerformances.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptUserPerformances.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            //crmRptCashierPerformances.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";

            crmRptUserPerformances.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptUserPerformances.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptUserPerformances.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptUserPerformances.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptUserPerformances;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void chkAllUsers_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllUsers.Checked) { txtUserName.Enabled = false; }
                else { txtUserName.Enabled = true; }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

    }
}
