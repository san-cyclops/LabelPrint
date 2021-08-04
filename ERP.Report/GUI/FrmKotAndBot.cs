using ERP.Domain;
using ERP.Domain.RestaurentManagement;
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
    /// <summary>
    /// Developed By Nuwan
    /// </summary>
    public partial class FrmKotAndBot : FrmBaseReportsForm
    {
        List<Location> locationList = new List<Location>();
        List<BillingLocation> billingLocationList = new List<BillingLocation>();
        List<InvPosTerminalDetails> unitList = new List<InvPosTerminalDetails>();
        List<ShiftDet> shiftDetList = new List<ShiftDet>();

        public enum ReportType
        {
            PaidIn,
            PaidOut,
        }

        private int reportTypeNo;
        private AutoGenerateInfo autoGenerateInfo;
        private int documentID;
        private UserPrivileges accessRights;

        public FrmKotAndBot(AutoGenerateInfo autoGenerateInfoPrm)
        {
            InitializeComponent();
            autoGenerateInfo = autoGenerateInfoPrm;
            this.Text = autoGenerateInfoPrm.FormText;
        }

        public override void FormLoad()
        {
            try
            {
                LoadUnitNumbers();
                LoadShiftNumbers();
                LoadLocationList();
                LoadBillingLocationList();

                CommonService commonService = new CommonService();
                Common.LoadOrderTerminals(cmbType, commonService.GetAllOrderTerminals());

                documentID = autoGenerateInfo.DocumentID;
                accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);

                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();

                base.FormLoad();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        public override void InitializeForm()
        {
            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();

            ClearLocationListView();
            ClearBillingLocationListView();
            ClearUnitNoListView();
            ClearShiftNoListView();

            base.InitializeForm();
        }

        private void GetSelectedLocations()
        {
            locationList = new List<Location>();

            foreach (ListViewItem item in lstLocation.Items)
            {
                if (item.Checked)
                {
                    string locationName = item.Text.Trim();

                    Location location = new Location();
                    LocationService locationService = new LocationService();
                    location = locationService.GetLocationsByName(locationName);

                    if (location != null)
                    {
                        locationList.Add(location);
                    }
                }
            }
        }

        private void GetSelectedUnitNumbers()  
        {
            unitList = new List<InvPosTerminalDetails>();

            foreach (ListViewItem item in lstUnit.Items)
            {
                if (item.Checked)
                {
                    int unitNo = Common.ConvertStringToInt(item.Text.Trim());

                    InvPosTerminalDetails unit = new InvPosTerminalDetails();
                    CommonService commonService = new CommonService();
                    unit = commonService.GetUnitByUnitNo(unitNo);

                    if (unit != null)
                    {
                        unitList.Add(unit);
                    }
                }
            }
        }

        private void GetSelectedShiftNumbers() 
        {
            shiftDetList = new List<ShiftDet>();

            foreach (ListViewItem item in lstShift.Items)
            {
                if (item.Checked)
                {
                    long shiftNo = Common.ConvertStringToLong(item.Text.Trim());

                    ShiftDet shiftDet = new ShiftDet();
                    CommonService commonService = new CommonService();
                    shiftDet = commonService.GetShiftDetByNo(shiftNo);

                    if (shiftDet != null)
                    {
                        shiftDetList.Add(shiftDet);
                    }
                }
            }
        }

        private void GetSelectedBillingLocations() 
        {
            billingLocationList = new List<BillingLocation>();

            foreach (ListViewItem item in lstBillingLocation.Items)
            {
                if (item.Checked)
                {
                    string billingLocationName = item.Text.Trim();

                    BillingLocation billingLocation = new BillingLocation();
                    BillingLocationService billingLocationService = new BillingLocationService();
                    billingLocation = billingLocationService.GetBillingLocationsByName(billingLocationName);

                    if (billingLocation != null)
                    {
                        billingLocationList.Add(billingLocation);
                    }
                }
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

                GetSelectedLocations();
                GetSelectedBillingLocations();
                GetSelectedUnitNumbers();
                GetSelectedShiftNumbers();

                ViewReportKotAndBot(dateFrom, dateTo, Common.ConvertStringToInt(cmbType.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        public void LoadShiftNumbers() 
        {
            lstShift.SmallImageList = imgList;

            CommonService commonService = new CommonService();
            var shiftList = commonService.GetAllShiftNumbers();
            lstShift.Clear();

            foreach (var item in shiftList)
            {
                lstShift.Items.Add(item.ShiftNo.ToString(), 4);
            }
        }

        public void LoadUnitNumbers()
        {
            lstUnit.SmallImageList = imgList;

            CommonService commonService = new CommonService();
            var unitList = commonService.GetAllUnitNumbers();
            lstUnit.Clear();

            foreach (var item in unitList)
            {
                lstUnit.Items.Add(item.TerminalId.ToString(), 4);
            }
        }

        public void LoadLocationList() 
        {
            lstLocation.SmallImageList = imgListLoca;

            LocationService locationService = new LocationService();
            var locationList = locationService.GetAllLocationsInventory();
            lstLocation.Clear();

            foreach (var item in locationList)
            {
                lstLocation.Items.Add(item.LocationName, 0);
            }
        }

        public void LoadBillingLocationList() 
        {
            lstBillingLocation.SmallImageList = imgListLoca;

            BillingLocationService billingLocationService = new BillingLocationService();
            var billingLocationList = billingLocationService.GetAllBillingLocations();
            lstBillingLocation.Clear();

            foreach (var item in billingLocationList)
            {
                lstBillingLocation.Items.Add(item.LocationName, 0);
            }
        }

        public override void Clear()
        {
            base.Clear();
        }


        public void ViewReportKotAndBot(DateTime fromDate, DateTime toDate, int type)     
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            ResSalesServices ResSalesServices = new ResSalesServices();
            RptResKotAndBot rptResKotAndBot = new RptResKotAndBot();

            rptResKotAndBot.SetDataSource(ResSalesServices.GetDataSourceKotAndBot(fromDate, toDate, locationList, billingLocationList, unitList, shiftDetList, type));

            rptResKotAndBot.SummaryInfo.ReportTitle = cmbType.Text.Trim() + " Information";
            rptResKotAndBot.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            rptResKotAndBot.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            rptResKotAndBot.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            rptResKotAndBot.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";
            rptResKotAndBot.DataDefinition.FormulaFields["KotBotDesc"].Text = "'" + cmbType.Text.Trim() + "'";
            rptResKotAndBot.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            rptResKotAndBot.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            rptResKotAndBot.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            rptResKotAndBot.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = rptResKotAndBot;
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
                    for (int i = 0; i < lstLocation.Items.Count; i++)
                    {
                        lstLocation.Items[i].Checked = true;
                    }
                }
                else
                {
                    for (int i = 0; i < lstLocation.Items.Count; i++)
                    {
                        lstLocation.Items[i].Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void ClearLocationListView()
        {
            for (int i = 0; i < lstLocation.Items.Count; i++)
            {
                lstLocation.Items[i].Checked = false;
            }
        }

        private void ClearBillingLocationListView() 
        {
            for (int i = 0; i < lstBillingLocation.Items.Count; i++)
            {
                lstBillingLocation.Items[i].Checked = false;
            }
        }

        private void ClearUnitNoListView() 
        {
            for (int i = 0; i < lstUnit.Items.Count; i++)
            {
                lstUnit.Items[i].Checked = false;
            }
        }

        private void ClearShiftNoListView() 
        {
            for (int i = 0; i < lstShift.Items.Count; i++)
            {
                lstShift.Items[i].Checked = false;
            }
        }

        private void chkAllBillingLocations_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllBillingLocations.Checked)
                {
                    for (int i = 0; i < lstBillingLocation.Items.Count; i++)
                    {
                        lstBillingLocation.Items[i].Checked = true;
                    }
                }
                else
                {
                    for (int i = 0; i < lstBillingLocation.Items.Count; i++)
                    {
                        lstBillingLocation.Items[i].Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void chkUnit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkUnit.Checked)
                {
                    for (int i = 0; i < lstUnit.Items.Count; i++)
                    {
                        lstUnit.Items[i].Checked = true;
                    }
                }
                else
                {
                    for (int i = 0; i < lstUnit.Items.Count; i++)
                    {
                        lstUnit.Items[i].Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void chkShift_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkShift.Checked)
                {
                    for (int i = 0; i < lstShift.Items.Count; i++)
                    {
                        lstShift.Items[i].Checked = true;
                    }
                }
                else
                {
                    for (int i = 0; i < lstShift.Items.Count; i++)
                    {
                        lstShift.Items[i].Checked = false;
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
