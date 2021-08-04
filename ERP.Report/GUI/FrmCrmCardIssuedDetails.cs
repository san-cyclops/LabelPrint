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
    public partial class FrmCrmCardIssuedDetails : FrmBaseReportsForm
    {
        int documentID = 0;
        UserPrivileges accessRights = new UserPrivileges();
        bool isValidControls = true;
        string formDisplayText = "";

        List<CardMaster> CardMasterList;
        List<CardMaster> CardMasterListHistory; 

        public FrmCrmCardIssuedDetails(string formText)
        {
            InitializeComponent();
            formDisplayText = formText;
        }

        public override void FormLoad()
        {
            //AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
            //autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm(this.Name);
            this.Text = formDisplayText;

            //documentID = autoGenerateInfo.DocumentID;
            accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);

            dgvCardType.AutoGenerateColumns = false;
            dgvHistory.AutoGenerateColumns = false;

            CommonService commonService = new CommonService();
            dgvCardType.DataSource = commonService.LoadCardMasterToGrid();
            dgvCardType.Refresh();

            dgvHistory.DataSource = commonService.LoadCardMasterToGrid();
            dgvHistory.Refresh();

            cmbLocation.SelectedValue = Common.LoggedLocationID;

            base.FormLoad();
        }

        public override void InitializeForm()
        {
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
            LocationService locationService = new LocationService();

            Common.LoadLocations(cmbLocation, locationService.GetAllLocations());
            Common.LoadLocations(cmbLocationHistory, locationService.GetAllLocations());

            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();

            cmbLocation.SelectedValue = Common.LoggedLocationID;
            cmbLocationHistory.SelectedValue = Common.LoggedLocationID;

            base.InitializeForm();
        }

        public override void ClearForm()
        {
            try
            {
                Common.ClearComboBox(cmbLocation);
                cmbLocation.Focus();

                cmbLocation.SelectedValue = Common.LoggedLocationID;
                cmbLocationHistory.SelectedValue = Common.LoggedLocationID;

                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();
                dtpHistory.Value = Common.GetSystemDate();

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

                if (dateFrom > dateTo)
                {
                    Toast.Show("","","", Toast.messageType.Information, Toast.messageAction.InvalidDate);
                    return;
                }

                GetSelectedCardTypes();

                if (tabCardIssue.SelectedTab == tbpGeneral)
                {
                    if (chkAllLocations.Checked)
                    {
                        ViewReportCardIssueAllLocation(dateFrom, dateTo);
                    }
                    else
                    {
                        ViewReportCardIssueSelectedLocationArapaima(Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()), dateFrom, dateTo);
                    }
                }
                else
                {
                    GetSelectedCardTypesHistory();
                    if (chkAlllocationHistory.Checked)
                    {
                        ViewHistoryReport(dtpHistory.Value);
                    }
                    else
                    {
                        ViewHistoryReportSelectedLocation(dtpHistory.Value, cmbLocationHistory.Text.Trim());
                    }
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

        private void ViewReportCardIssueSelectedLocationArapaima(int locationID, DateTime fromDate, DateTime toDate) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptCardIssuedDetails crmRptCardIssuedDetails = new CrmRptCardIssuedDetails();

            crmRptCardIssuedDetails.SetDataSource(loyaltyReportService.ViewReportCardIssueSelectedLocationArapaima(locationID, fromDate, toDate, CardMasterList));

            crmRptCardIssuedDetails.SummaryInfo.ReportTitle = "Card Issued Details";

            crmRptCardIssuedDetails.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            crmRptCardIssuedDetails.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text + "'";

            crmRptCardIssuedDetails.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCardIssuedDetails.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptCardIssuedDetails.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            crmRptCardIssuedDetails.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCardIssuedDetails.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCardIssuedDetails.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCardIssuedDetails.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptCardIssuedDetails;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewReportCardIssueAllLocation(DateTime fromDate, DateTime toDate) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptCardIssuedDetailsAllLocations crmRptCardIssuedDetailsAllLocations = new CrmRptCardIssuedDetailsAllLocations();

            crmRptCardIssuedDetailsAllLocations.SetDataSource(loyaltyReportService.ViewReportCardIssueAllLocationArapaima(fromDate, toDate, CardMasterList));

            crmRptCardIssuedDetailsAllLocations.SummaryInfo.ReportTitle = "Card Issued Details";

            crmRptCardIssuedDetailsAllLocations.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            crmRptCardIssuedDetailsAllLocations.DataDefinition.FormulaFields["LocationName"].Text = "'All Locations'";

            crmRptCardIssuedDetailsAllLocations.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCardIssuedDetailsAllLocations.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptCardIssuedDetailsAllLocations.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            crmRptCardIssuedDetailsAllLocations.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCardIssuedDetailsAllLocations.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCardIssuedDetailsAllLocations.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCardIssuedDetailsAllLocations.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptCardIssuedDetailsAllLocations;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewHistoryReport(DateTime fromDate) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptCardIssueHistory crmRptCardIssueHistory = new CrmRptCardIssueHistory();

            crmRptCardIssueHistory.SetDataSource(loyaltyReportService.ViewCardIssueHistory(fromDate, CardMasterListHistory));

            crmRptCardIssueHistory.SummaryInfo.ReportTitle = "Card Issued Details";

            crmRptCardIssueHistory.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            crmRptCardIssueHistory.DataDefinition.FormulaFields["LocationName"].Text = "'All Locations'";

            crmRptCardIssueHistory.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCardIssueHistory.DataDefinition.FormulaFields["IssuedDate"].Text = "'" + dtpHistory.Value + "'";

            crmRptCardIssueHistory.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCardIssueHistory.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCardIssueHistory.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCardIssueHistory.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptCardIssueHistory;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewHistoryReportSelectedLocation(DateTime fromDate, string locationName) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptCardIssueHistory crmRptCardIssueHistory = new CrmRptCardIssueHistory();

            crmRptCardIssueHistory.SetDataSource(loyaltyReportService.ViewCardIssueHistoryLocationWise(fromDate, CardMasterListHistory, locationName));

            crmRptCardIssueHistory.SummaryInfo.ReportTitle = "Card Issued Details";

            crmRptCardIssueHistory.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            crmRptCardIssueHistory.DataDefinition.FormulaFields["LocationName"].Text = "'" + locationName + "'";

            crmRptCardIssueHistory.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCardIssueHistory.DataDefinition.FormulaFields["IssuedDate"].Text = "'" + dtpHistory.Value + "'";

            crmRptCardIssueHistory.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCardIssueHistory.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCardIssueHistory.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCardIssueHistory.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptCardIssueHistory;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }



        private void chkAllLocations_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllLocations.Checked)
                {
                    cmbLocation.SelectedIndex = -1;
                    cmbLocation.Enabled = false;
                }
                else
                {
                    cmbLocation.SelectedValue = Common.LoggedLocationID;
                    cmbLocation.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

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

        private void GetSelectedCardTypesHistory() 
        {
            CardMasterListHistory = new List<CardMaster>();
            for (int i = 0; i < dgvHistory.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvHistory.Rows[i].Cells["SelectHistory"].Value) == true)
                {
                    CardMaster cardMaster = new CardMaster();
                    CardMasterService cardMasterService = new CardMasterService();
                    int cardMasterID = Common.ConvertStringToInt(dgvHistory.Rows[i].Cells["CardMasterIDHistory"].Value.ToString().Trim());

                    cardMaster = cardMasterService.GetCardMasterById(cardMasterID);
                    CardMasterListHistory.Add(cardMaster);
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

        private void CheckAllCardTypesHistory()
        {
            for (int i = 0; i < dgvHistory.RowCount; i++)
            {
                dgvHistory.Rows[i].Cells["SelectHistory"].Value = true;
            }
        }

        private void UnCheckAllCardTypesHistory()
        {
            for (int i = 0; i < dgvHistory.RowCount; i++)
            {
                dgvHistory.Rows[i].Cells["SelectHistory"].Value = false;
            }
        }

        private void chkHistory_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkHistory.Checked) { CheckAllCardTypesHistory(); }
                else { UnCheckAllCardTypesHistory(); }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void chkAlllocationHistory_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAlllocationHistory.Checked)
                {
                    cmbLocationHistory.SelectedIndex = -1;
                    cmbLocationHistory.Enabled = false;
                }
                else
                {
                    cmbLocationHistory.SelectedValue = Common.LoggedLocationID;
                    cmbLocationHistory.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

    }
}
