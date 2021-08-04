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
    public partial class FrmCrmLostAndRenewDetail : FrmBaseReportsForm
    {
        int documentID = 0;
        UserPrivileges accessRights = new UserPrivileges();
        bool isValidControls = true;
        string formDisplayText = "";

        List<CardMaster> CardMasterList;

        public FrmCrmLostAndRenewDetail(string formText)
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

            dgvCardType.AutoGenerateColumns = false;

            CommonService commonService = new CommonService();
            dgvCardType.DataSource = commonService.LoadCardMasterToGrid();
            dgvCardType.Refresh();
            
            //cmbLocation.Enabled = false;

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

                lblNameOnCard.Text = string.Empty;
                lblCardType.Text = string.Empty;

                tabMain.SelectedTab = tbpGeneral;

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

                GetSelectedCardTypes();

                if (tabMain.SelectedTab == tbpGeneral)
                {
                    if (chkAlllocations.Checked)
                    {
                        ViewReport(dateFrom, dateTo);
                    }
                    else
                    {
                        ViewReportSelectedLocation(Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()), dateFrom, dateTo);
                    }

                }
                else
                {
                    CardMasterService cardMasterService = new CardMasterService();
                    LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
                    LoyaltyCustomer loyaltyCustomer = new LoyaltyCustomer();
                    loyaltyCustomer = loyaltyCustomerService.GetLoyaltyCustomerByCode(txtCustomerCode.Text.Trim());

                    if (loyaltyCustomer != null)
                    {
                        ViewReportSelectedCustomer(dateFrom, dateTo, loyaltyCustomer.LoyaltyCustomerID);
                    }
                    else
                    {
                        Toast.Show("","","Invalid Customer Code", Toast.messageType.Information, Toast.messageAction.General);
                        txtCustomerCode.Focus();
                        return;
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


        private void ViewReport(DateTime fromDate, DateTime toDate)  //
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptLostAndReNew crmRptLostAndReNew = new CrmRptLostAndReNew();

            crmRptLostAndReNew.SetDataSource(loyaltyReportService.GetLostAndReNewDataSource(fromDate, toDate, CardMasterList));

            crmRptLostAndReNew.SummaryInfo.ReportTitle = "Lost And Renew Details";

            crmRptLostAndReNew.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptLostAndReNew.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptLostAndReNew.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptLostAndReNew.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            crmRptLostAndReNew.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptLostAndReNew.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptLostAndReNew.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptLostAndReNew.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptLostAndReNew;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewReportSelectedLocation(int locationID, DateTime fromDate, DateTime toDate) //
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptLostAndReNewSelectedLocation crmRptLostAndReNewSelectedLocation = new CrmRptLostAndReNewSelectedLocation();

            crmRptLostAndReNewSelectedLocation.SetDataSource(loyaltyReportService.GetLostAndRenewDataSourceSelectedLocation(locationID, fromDate, toDate, CardMasterList));

            crmRptLostAndReNewSelectedLocation.SummaryInfo.ReportTitle = "Lost And Renew Details";

            crmRptLostAndReNewSelectedLocation.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptLostAndReNewSelectedLocation.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptLostAndReNewSelectedLocation.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptLostAndReNewSelectedLocation.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            crmRptLostAndReNewSelectedLocation.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";

            crmRptLostAndReNewSelectedLocation.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptLostAndReNewSelectedLocation.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptLostAndReNewSelectedLocation.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptLostAndReNewSelectedLocation.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptLostAndReNewSelectedLocation;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewReportSelectedCustomer(DateTime fromDate, DateTime toDate, long customerID)  // 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptLostAndReNew crmRptLostAndReNew = new CrmRptLostAndReNew();

            crmRptLostAndReNew.SetDataSource(loyaltyReportService.GetLostAndReNewDataSourceSelectedCustomer(customerID));

            crmRptLostAndReNew.SummaryInfo.ReportTitle = "Lost And Renew Details";

            crmRptLostAndReNew.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptLostAndReNew.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptLostAndReNew.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptLostAndReNew.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            crmRptLostAndReNew.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptLostAndReNew.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptLostAndReNew.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptLostAndReNew.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptLostAndReNew;
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

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
                        {
                            CardMasterService cardMasterService = new CardMasterService();
                            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
                            LoyaltyCustomer loyaltyCustomer = new LoyaltyCustomer();
                            loyaltyCustomer = loyaltyCustomerService.GetLoyaltyCustomerByCode(txtCustomerCode.Text.Trim());

                            if (loyaltyCustomer != null)
                            {
                                txtCustomerName.Text = loyaltyCustomer.CustomerName.Trim();
                                txtCardNo.Text = loyaltyCustomer.CardNo.Trim();
                                txtNic.Text = loyaltyCustomer.NicNo;
                                lblNameOnCard.Text = loyaltyCustomer.NameOnCard;
                                lblCardType.Text = cardMasterService.GetCardMasterById(loyaltyCustomer.CardMasterID).CardName;
                            }
                            else
                            {
                                Toast.Show(this.Text, "","Invalid Customer Code", Toast.messageType.Information, Toast.messageAction.General);
                                txtCustomerCode.Focus();
                                return;
                            }
                        }
                        else
                        {
                            txtCustomerName.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter)) 
                {
                    if (!string.IsNullOrEmpty(txtCardNo.Text.Trim()))
                    {
                        LoyaltyCustomerService loyaltyCustomerervice = new LoyaltyCustomerService();
                        CardMasterService cardMasterService = new CardMasterService();
                        LoyaltyCustomer loyaltyCustomer = new LoyaltyCustomer();
                        loyaltyCustomer = loyaltyCustomerervice.GetLoyaltyCustomerByCardNo(txtCardNo.Text.Trim());

                        if (loyaltyCustomer != null)
                        {
                            txtCustomerCode.Text = loyaltyCustomer.CustomerCode.Trim();
                            txtCustomerName.Text = loyaltyCustomer.CustomerName.Trim();
                            txtCardNo.Text = loyaltyCustomer.CardNo.Trim();
                            txtNic.Text = loyaltyCustomer.NicNo;
                            lblNameOnCard.Text = loyaltyCustomer.NameOnCard;
                            lblCardType.Text = cardMasterService.GetCardMasterById(loyaltyCustomer.CardMasterID).CardName;
                        }
                        else
                        {
                            Toast.Show(this.Text, "","Invalid card no", Toast.messageType.Information, Toast.messageAction.General);
                            txtCardNo.Focus();
                            return;
                        }
                    }
                    else
                    {
                        txtNic.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtNic_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    if (!string.IsNullOrEmpty(txtNic.Text.Trim()))
                    {
                        LoyaltyCustomerService loyaltyCustomerervice = new LoyaltyCustomerService();
                        CardMasterService cardMasterService = new CardMasterService();
                        LoyaltyCustomer loyaltyCustomer = new LoyaltyCustomer();
                        loyaltyCustomer = loyaltyCustomerervice.GetLoyaltyCustomerByNicNo(txtNic.Text.Trim());

                        if (loyaltyCustomer != null)
                        {
                            txtCustomerCode.Text = loyaltyCustomer.CustomerCode.Trim();
                            txtCustomerName.Text = loyaltyCustomer.CustomerName.Trim();
                            txtCardNo.Text = loyaltyCustomer.CardNo.Trim();
                            txtNic.Text = loyaltyCustomer.NicNo;
                            lblNameOnCard.Text = loyaltyCustomer.NameOnCard;
                            lblCardType.Text = cardMasterService.GetCardMasterById(loyaltyCustomer.CardMasterID).CardName;
                        }
                        else
                        {
                            Toast.Show(this.Text,"","Invalid card no", Toast.messageType.Information, Toast.messageAction.General);
                            txtCardNo.Focus();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

    }
}
