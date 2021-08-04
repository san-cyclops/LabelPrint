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
    public partial class FrmCrmNewCardDetail : FrmBaseReportsForm
    {
        int documentID = 0;
        string formDisplayText = "";
        UserPrivileges accessRights = new UserPrivileges();
        List<CardMaster> CardMasterList;

        public FrmCrmNewCardDetail(string formText)
        {
            InitializeComponent();
            formDisplayText = formText;
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

                this.Cursor = Cursors.Default;

                base.ClearForm();
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

        private void ViewReportNewCardEarnDetails(DateTime fromDate, DateTime toDate, DateTime issuefromDate, DateTime issuetoDate, bool IsAllLoca,int LocationId)
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptNewCardEarnDetails crmRptNewCardEarnDetails = new CrmRptNewCardEarnDetails();

            crmRptNewCardEarnDetails.SetDataSource(loyaltyReportService.GetDataSourceCrmNewCardEarnDetails(fromDate, toDate, issuefromDate, issuetoDate, IsAllLoca, LocationId, CardMasterList));

            crmRptNewCardEarnDetails.SummaryInfo.ReportTitle = "New Card Vs Earn";

            crmRptNewCardEarnDetails.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptNewCardEarnDetails.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptNewCardEarnDetails.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptNewCardEarnDetails.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            crmRptNewCardEarnDetails.DataDefinition.FormulaFields["LocationName"].Text = "'All Locations'";

            crmRptNewCardEarnDetails.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptNewCardEarnDetails.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptNewCardEarnDetails.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptNewCardEarnDetails.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptNewCardEarnDetails;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;

        }

        private void ViewReportNewCardRedeemDetails(DateTime fromDate, DateTime toDate, DateTime issuefromDate, DateTime issuetoDate, bool IsAllLoca, int LocationId)
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptNewCardRedeemDetails crmRptNewCardRedeemDetails = new CrmRptNewCardRedeemDetails();

            crmRptNewCardRedeemDetails.SetDataSource(loyaltyReportService.GetDataSourceCrmNewCardRedeemDetails(fromDate, toDate, issuefromDate, issuetoDate, IsAllLoca, LocationId, CardMasterList));

            crmRptNewCardRedeemDetails.SummaryInfo.ReportTitle = "New Card Vs Redeem";

            crmRptNewCardRedeemDetails.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptNewCardRedeemDetails.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptNewCardRedeemDetails.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptNewCardRedeemDetails.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            crmRptNewCardRedeemDetails.DataDefinition.FormulaFields["LocationName"].Text = "'All Locations'";

            crmRptNewCardRedeemDetails.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptNewCardRedeemDetails.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptNewCardRedeemDetails.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptNewCardRedeemDetails.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptNewCardRedeemDetails;
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

        public override void FormLoad()
        {
            this.Text = formDisplayText;
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
            LocationService locationService = new LocationService();

            Common.LoadLocations(cmbLocation, locationService.GetAllLocations());

            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();

            cmbLocation.SelectedValue = Common.LoggedLocationID;

            dgvCardType.AutoGenerateColumns = false;

            CommonService commonService = new CommonService();
            dgvCardType.DataSource = commonService.LoadCardMasterToGrid();
            dgvCardType.Refresh();



            ////AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
            ////autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm(this.Name);
            //this.Text = formDisplayText;

            ////documentID = autoGenerateInfo.DocumentID;
            //accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);

            ////cmbLocation.Enabled = false;
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {

                prgBar.Value = prgBar.Minimum;

                DateTime fromDate;
                DateTime toDate;
                DateTime issuefromDate;
                DateTime issuetoDate;
                bool IsAllLoca;

                fromDate = dtpFromDate.Value;
                toDate = dtpToDate.Value;
                issuefromDate = dtpIssueFromDate.Value;
                issuetoDate = dtpIssueToDate.Value;
                IsAllLoca = chkAlllocations.Checked;


                GetSelectedCardTypes();

                if (rdoEarn.Checked)
                {
                    if (chkAlllocations.Checked)
                    {
                        ViewReportNewCardEarnDetails(fromDate, toDate, issuefromDate, issuetoDate, IsAllLoca, Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()));
                        prgBar.Value = prgBar.Maximum;
                    }
                    else
                    {
                        ViewReportNewCardEarnDetails(fromDate, toDate, issuefromDate, issuetoDate, IsAllLoca, Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()));
                        prgBar.Value = prgBar.Maximum;
                    }
                }

                else if (rdoRedeem.Checked)
                {
                    if (chkAlllocations.Checked)
                    {
                        ViewReportNewCardRedeemDetails(fromDate, toDate, issuefromDate, issuetoDate, IsAllLoca, Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()));
                        prgBar.Value = prgBar.Maximum;
                    }
                    else
                    {
                        ViewReportNewCardRedeemDetails(fromDate, toDate, issuefromDate, issuetoDate, IsAllLoca, Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()));
                        prgBar.Value = prgBar.Maximum;
                    }
                }
                else
                {
                    Toast.Show(this.Text,"","Please select an option",Toast.messageType.Information,Toast.messageAction.General);
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


    }
}
