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
    public partial class FrmCrmCustomerVisitDetail : FrmBaseReportsForm
    {
        int documentID = 0;
        UserPrivileges accessRights = new UserPrivileges();
        bool isValidControls = true;
        string formDisplayText = "";

        List<CardMaster> CardMasterList;

        public FrmCrmCustomerVisitDetail(string formText)
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
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
            LocationService locationService = new LocationService();

            Common.LoadLocations(cmbLocation, locationService.GetAllLocations());

            prgBar.Value = prgBar.Minimum;
            errorProvider.Clear();

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
            chkVisitedMonth.Enabled = false;
            chkLocation.Enabled = false;

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

                chkVisitedMonth.Enabled = false;
                chkLocation.Enabled = false;

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
                if (bgWorker == null) { bgWorker = new BackgroundWorker(); }
                prgBar.Value = prgBar.Minimum;
                bgWorker.RunWorkerAsync();

                DateTime dateFrom;
                DateTime dateTo;

                dateFrom = dtpFromDate.Value;
                dateTo = dtpToDate.Value;

                GetSelectedCardTypes();

                if (rdoCustomerWise.Checked)
                {
                    int locationID = 0;
                    if (!chkAlllocations.Checked)
                    { locationID = Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString());}

                    if (chkVisitedMonth.Checked)
                    {
                        ViewReportCustomerWiseByMonth(locationID, dateFrom, dateTo, chkVisitedMonth.Checked);
                        prgBar.Value = prgBar.Maximum;
                    }
                    else if (chkAlllocations.Checked)
                    {
                        ViewReportCustomerWiseAllLocation(dateFrom, dateTo);
                        prgBar.Value = prgBar.Maximum;
                    }
                    else
                    {
                        ViewReportCustomerWiseSelectedLocation(Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()),dateFrom, dateTo, chkVisitedMonth.Checked);
                        prgBar.Value = prgBar.Maximum;
                    }
                }
                else
                {
                    if (chkAlllocations.Checked)
                    {
                        if (chkTotalPurchases.Checked)
                        {
                            ViewSummeryReportAllLocation(dateFrom, dateTo);
                            prgBar.Value = prgBar.Maximum;
                        }
                        else
                        {
                            ViewSummeryReportAllLocationWithoutPurchases(dateFrom, dateTo);
                            prgBar.Value = prgBar.Maximum;
                        }
                    }
                    else
                    {
                        if (chkTotalPurchases.Checked)
                        {
                            ViewSummeryReportSelectedLocation(Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()), dateFrom, dateTo);
                            prgBar.Value = prgBar.Maximum;
                        }
                        else
                        {
                            ViewSummeryReportSelectedLocationWithoutPurchases(Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()), dateFrom, dateTo);
                            prgBar.Value = prgBar.Maximum;
                        }
                    }
                }
                bgWorker = null;
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

        private void ViewReportCustomerWiseAllLocation(DateTime fromDate, DateTime toDate)    
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptCustomerVisitCustomerWise crmRptCustomerVisitCustomerWise = new CrmRptCustomerVisitCustomerWise();

            crmRptCustomerVisitCustomerWise.SetDataSource(loyaltyReportService.GetDataSourceCustomerVisitAllLocations(fromDate, toDate, chkVisitedMonth.Checked, CardMasterList));

            crmRptCustomerVisitCustomerWise.SummaryInfo.ReportTitle = "Customer Visit Details";

            crmRptCustomerVisitCustomerWise.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptCustomerVisitCustomerWise.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCustomerVisitCustomerWise.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptCustomerVisitCustomerWise.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            crmRptCustomerVisitCustomerWise.DataDefinition.FormulaFields["LocationName"].Text = "'All Locations'";

            crmRptCustomerVisitCustomerWise.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCustomerVisitCustomerWise.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCustomerVisitCustomerWise.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCustomerVisitCustomerWise.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptCustomerVisitCustomerWise;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewReportCustomerWiseSelectedLocation(int locationID, DateTime fromDate, DateTime toDate, bool isVisitedMonth) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptCustomerVisitCustomerWiseSelectedLocation crmRptCustomerVisitCustomerWiseSelectedLocation = new CrmRptCustomerVisitCustomerWiseSelectedLocation();

            crmRptCustomerVisitCustomerWiseSelectedLocation.SetDataSource(loyaltyReportService.GetDataSourceCustomerVisitSelectedLocations(locationID, fromDate, toDate, isVisitedMonth, CardMasterList));

            crmRptCustomerVisitCustomerWiseSelectedLocation.SummaryInfo.ReportTitle = "Customer Visit Details (Arrowana Member)";

            crmRptCustomerVisitCustomerWiseSelectedLocation.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptCustomerVisitCustomerWiseSelectedLocation.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCustomerVisitCustomerWiseSelectedLocation.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptCustomerVisitCustomerWiseSelectedLocation.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            crmRptCustomerVisitCustomerWiseSelectedLocation.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";

            crmRptCustomerVisitCustomerWiseSelectedLocation.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCustomerVisitCustomerWiseSelectedLocation.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCustomerVisitCustomerWiseSelectedLocation.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCustomerVisitCustomerWiseSelectedLocation.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptCustomerVisitCustomerWiseSelectedLocation;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewReportCustomerWiseByMonth(int locationID, DateTime fromDate, DateTime toDate, bool isVisitedMonth)
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptCustomerVisitCustomerWiseTemplate crmRptCustomerVisitCustomerWiseTemplate = new CrmRptCustomerVisitCustomerWiseTemplate();

            crmRptCustomerVisitCustomerWiseTemplate.SetDataSource(loyaltyReportService.GetDataSourceCustomerVisitsByMonth(fromDate, toDate, isVisitedMonth, chkLocation.Checked, locationID, CardMasterList));

            crmRptCustomerVisitCustomerWiseTemplate.SummaryInfo.ReportTitle = "Customer Visit Details";

            crmRptCustomerVisitCustomerWiseTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptCustomerVisitCustomerWiseTemplate.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCustomerVisitCustomerWiseTemplate.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptCustomerVisitCustomerWiseTemplate.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            crmRptCustomerVisitCustomerWiseTemplate.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";

            crmRptCustomerVisitCustomerWiseTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCustomerVisitCustomerWiseTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCustomerVisitCustomerWiseTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCustomerVisitCustomerWiseTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            
            objReportView.crRptViewer.ReportSource = crmRptCustomerVisitCustomerWiseTemplate;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }


        private void ViewSummeryReportAllLocation(DateTime fromDate, DateTime toDate) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptCustomerVisitSummeryAllLocation crmRptCustomerVisitSummeryAllLocation = new CrmRptCustomerVisitSummeryAllLocation();

            crmRptCustomerVisitSummeryAllLocation.SetDataSource(loyaltyReportService.GetDataSourceSummeryVisitAllLocations(fromDate, toDate, CardMasterList));

            crmRptCustomerVisitSummeryAllLocation.SummaryInfo.ReportTitle = "Customer Visit Details";

            crmRptCustomerVisitSummeryAllLocation.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["LocationName"].Text = "'All Locations'";

            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptCustomerVisitSummeryAllLocation;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewSummeryReportAllLocationWithoutPurchases(DateTime fromDate, DateTime toDate) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptCustomerVisitSummeryAllLocationWithoutPurchases crmRptCustomerVisitSummeryAllLocationWithoutPurchases = new CrmRptCustomerVisitSummeryAllLocationWithoutPurchases();

            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.SetDataSource(loyaltyReportService.GetDataSourceSummeryVisitAllLocations(fromDate, toDate, CardMasterList));

            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.SummaryInfo.ReportTitle = "Customer Visit Details";

            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["LocationName"].Text = "'All Locations'";

            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptCustomerVisitSummeryAllLocationWithoutPurchases;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewSummeryReportSelectedLocation(int locationID, DateTime fromDate, DateTime toDate) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptCustomerVisitSummeryAllLocation crmRptCustomerVisitSummeryAllLocation = new CrmRptCustomerVisitSummeryAllLocation();

            crmRptCustomerVisitSummeryAllLocation.SetDataSource(loyaltyReportService.GetDataSourceSummeryVisitSelectedLocations(locationID, fromDate, toDate, CardMasterList));

            crmRptCustomerVisitSummeryAllLocation.SummaryInfo.ReportTitle = "Customer Visit Details";

            crmRptCustomerVisitSummeryAllLocation.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";

            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCustomerVisitSummeryAllLocation.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptCustomerVisitSummeryAllLocation;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewSummeryReportSelectedLocationWithoutPurchases(int locationID, DateTime fromDate, DateTime toDate) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptCustomerVisitSummeryAllLocationWithoutPurchases crmRptCustomerVisitSummeryAllLocationWithoutPurchases = new CrmRptCustomerVisitSummeryAllLocationWithoutPurchases();

            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.SetDataSource(loyaltyReportService.GetDataSourceSummeryVisitSelectedLocations(locationID, fromDate, toDate, CardMasterList));

            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.SummaryInfo.ReportTitle = "Customer Visit Details";

            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";

            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCustomerVisitSummeryAllLocationWithoutPurchases.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptCustomerVisitSummeryAllLocationWithoutPurchases;
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
                    chkLocation.Enabled = true;
                }
                else
                {
                    chkLocation.Enabled = false;
                    cmbLocation.Enabled = true;
                    cmbLocation.SelectedValue = Common.LoggedLocationID;
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

        private void rdoCustomerWise_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoCustomerWise.Checked)
                {
                    chkVisitedMonth.Enabled = true;
                    //chkLocation.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

    }
}
