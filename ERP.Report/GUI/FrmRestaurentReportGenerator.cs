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
    public partial class FrmRestaurentReportGenerator : FrmBaseReportsForm
    {
        List<Location> locationList = new List<Location>();
        List<BillingLocation> billingLocationList = new List<BillingLocation>();
        List<InvDepartment> departmentList = new List<InvDepartment>();
        List<InvProductMaster> productList = new List<InvProductMaster>();
        List<InvCategory> categoryList = new List<InvCategory>();
        List<InvSubCategory> subCategoryList = new List<InvSubCategory>();
        List<InvSubCategory2> subCategory2List = new List<InvSubCategory2>(); 
        List<InvPosTerminalDetails> unitList = new List<InvPosTerminalDetails>();
        List<ShiftDet> shiftDetList = new List<ShiftDet>();

        public enum ReportType
        {
            ItemWiseSales, //reportTypeNo--> 1
            DepartmentWiseSales, //reportTypeNo--> 2
            CategoryWiseSales, //reportTypeNo--> 3
            SubCategoryWiseSales, //reportTypeNo--> 4
            SubCategory2WiseSales, //reportTypeNo--> 5
        }

        private int reportTypeNo;
        private AutoGenerateInfo autoGenerateInfo;
        private int documentID;
        private UserPrivileges accessRights;
        private bool isSelection;

        public FrmRestaurentReportGenerator(AutoGenerateInfo autoGenerateInfoPrm, ReportType reportType)
        {
            InitializeComponent();

            if (reportType == ReportType.ItemWiseSales) { reportTypeNo = 1; }
            if (reportType == ReportType.DepartmentWiseSales) { reportTypeNo = 2; }
            if (reportType == ReportType.CategoryWiseSales) { reportTypeNo = 3; }
            if (reportType == ReportType.SubCategoryWiseSales) { reportTypeNo = 4; }
            if (reportType == ReportType.SubCategory2WiseSales) { reportTypeNo = 5; }

            autoGenerateInfo = autoGenerateInfoPrm;
            this.Text = autoGenerateInfoPrm.FormText;
        }

        public override void FormLoad()
        {
            try
            {
                LoadLocationList();
                LoadBillingLocationList();
                LoadUnitNumbers();
                LoadShiftNumbers();

                documentID = autoGenerateInfo.DocumentID;
                accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);

                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();

                //cmbLocation.SelectedValue = Common.LoggedLocationID;
                //EnableDesableFooter();
                //LoadSearchCodes();

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
            lstLayer.Clear();

            ClearLocationListView();
            ClearBillingLocationListView();
            ClearUnitNoListView();
            ClearShiftNoListView();

            isSelection = false;
            base.InitializeForm();
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

        private void GetSelectedDepartments() 
        {
            departmentList = new List<InvDepartment>();

            foreach (ListViewItem item in lstLayer.Items)
            {
                if (item.Checked)
                {
                    string departmentName = item.Text.Trim();

                    InvDepartment invDepartment = new InvDepartment();
                    InvDepartmentService invDepartmentService = new InvDepartmentService();
                    invDepartment = invDepartmentService.GetInvDepartmentsByName(departmentName, true);

                    if (invDepartment != null)
                    {
                        departmentList.Add(invDepartment);
                    }
                }
            }
        }

        private void GetSelectedCategories() 
        {
            categoryList = new List<InvCategory>();

            foreach (ListViewItem item in lstLayer.Items)
            {
                if (item.Checked)
                {
                    string categoryName = item.Text.Trim();

                    InvCategory invCategory = new InvCategory();
                    InvCategoryService invCategoryService = new InvCategoryService();
                    invCategory = invCategoryService.GetInvCategoryByName(categoryName, true);

                    if (invCategory != null)
                    {
                        categoryList.Add(invCategory);
                    }
                }
            }
        }

        private void GetSelectedSubCategories() 
        {
            subCategoryList = new List<InvSubCategory>();

            foreach (ListViewItem item in lstLayer.Items)
            {
                if (item.Checked)
                {
                    string subCategoryName = item.Text.Trim();

                    InvSubCategory invsubCategory = new InvSubCategory();
                    InvSubCategoryService invSubCategoryService = new InvSubCategoryService();
                    invsubCategory = invSubCategoryService.GetInvSubCategoryByName(subCategoryName, true);

                    if (invsubCategory != null)
                    {
                        subCategoryList.Add(invsubCategory);
                    }
                }
            }
        }

        private void GetSelectedSubCategories2() 
        {
            subCategory2List = new List<InvSubCategory2>();

            foreach (ListViewItem item in lstLayer.Items)
            {
                if (item.Checked)
                {
                    string subCategory2Name = item.Text.Trim();

                    InvSubCategory2 invsubCategory2 = new InvSubCategory2();
                    InvSubCategory2Service invSubCategory2Service = new InvSubCategory2Service();
                    invsubCategory2 = invSubCategory2Service.GetInvSubCategory2ByName(subCategory2Name);

                    if (invsubCategory2 != null)
                    {
                        subCategory2List.Add(invsubCategory2);
                    }
                }
            }
        }

        private void GetSelectedProducts()
        {
            productList = new List<InvProductMaster>();

            foreach (ListViewItem item in lstLayer.Items)
            {
                if (item.Checked)
                {
                    string productName = item.Text.Trim();

                    InvProductMaster invProductMaster = new InvProductMaster();
                    InvProductMasterService invProductMasterService = new InvProductMasterService();
                    invProductMaster = invProductMasterService.GetProductsByName(productName);

                    if (invProductMaster != null)
                    {
                        productList.Add(invProductMaster);
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

                if (reportTypeNo == 1)
                {
                    GetSelectedProducts();
                    if (rdoSummery.Checked) { ViewItemWiseSummeryReport(dateFrom, dateTo); }
                    else { ViewItemWiseDetailReport(dateFrom, dateTo); }
                }
                else if (reportTypeNo == 2)
                {
                    GetSelectedDepartments();
                    if (rdoSummery.Checked) { ViewDepartmentWiseSummeryReport(dateFrom, dateTo); }
                    else { ViewDepartmentWiseDetailReport(dateFrom, dateTo); }
                }
                else if (reportTypeNo == 3)
                {
                    GetSelectedCategories();
                    if (rdoSummery.Checked) { ViewCategoryWiseSummeryReport(dateFrom, dateTo); }
                    else { ViewCategoryWiseDetailReport(dateFrom, dateTo); }
                }
                else if (reportTypeNo == 4)
                {
                    GetSelectedSubCategories();
                    if (rdoSummery.Checked) { ViewSubCategoryWiseSummeryReport(dateFrom, dateTo); }
                    else { ViewSubCategoryWiseDetailReport(dateFrom, dateTo); }
                }
                else if (reportTypeNo == 5)
                {
                    GetSelectedSubCategories2();
                    if (rdoSummery.Checked) { ViewSubCategory2WiseSummeryReport(dateFrom, dateTo); }
                    else { ViewSubCategory2WiseDetailReport(dateFrom, dateTo); }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
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

        private void rdoSelection_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                lstLayer.SmallImageList = imgList;
                int imgIndex = 0;

                prgBar.Value = 0;
                prgBar.ShowPercentage = true;
                prgBar.ShowText = false;

                if (rdoSelection.Checked)
                {
                    isSelection = true;
                    if (reportTypeNo == 1)
                    {
                        imgIndex = 0;
                        InvProductMasterService invProductMasterService = new InvProductMasterService();
                        var productList = invProductMasterService.GetProductList();
                        lstLayer.Clear();

                        prgBar.Maximum = productList.Count - 1;
                        foreach (var item in productList)
                        {
                            lstLayer.Items.Add(item.ProductName, imgIndex);
                            index++;
                            imgIndex++;
                            if (imgIndex == 4) { imgIndex = 0; }

                            prgBar.Value = index;
                            if (prgBar.Value == prgBar.Maximum)
                            {
                                prgBar.ShowPercentage = false;
                                prgBar.ShowText = true;
                                prgBar.Text = "Load Finished";
                            }
                        }
                    }
                    else if (reportTypeNo == 2)
                    {
                        imgIndex = 0;
                        InvDepartmentService invDepartmentService = new InvDepartmentService();
                        var departmentList = invDepartmentService.GetDepartmentList();
                        lstLayer.Clear();

                        prgBar.Maximum = departmentList.Count - 1;
                        foreach (var item in departmentList)
                        {
                            lstLayer.Items.Add(item.DepartmentName, imgIndex);
                            index++;
                            imgIndex++;
                            if (imgIndex == 4) { imgIndex = 0; }

                            prgBar.Value = index;
                            if (prgBar.Value == prgBar.Maximum)
                            {
                                prgBar.ShowPercentage = false;
                                prgBar.ShowText = true;
                                prgBar.Text = "Load Finished";
                            }
                        }
                    }
                    else if (reportTypeNo == 3)
                    {
                        imgIndex = 0;
                        InvCategoryService invCategoryService = new InvCategoryService();
                        var categorytList = invCategoryService.GetCategorytList();
                        lstLayer.Clear();

                        prgBar.Maximum = categorytList.Count - 1;
                        foreach (var item in categorytList)
                        {
                            lstLayer.Items.Add(item.CategoryName, imgIndex);
                            index++;
                            imgIndex++;
                            if (imgIndex == 4) { imgIndex = 0; }

                            prgBar.Value = index;
                            if (prgBar.Value == prgBar.Maximum)
                            {
                                prgBar.ShowPercentage = false;
                                prgBar.ShowText = true;
                                prgBar.Text = "Load Finished";
                            }
                        }
                    }
                    else if (reportTypeNo == 4)
                    {
                        imgIndex = 0;
                        InvSubCategoryService invSubCategoryService = new InvSubCategoryService();
                        var subCategorytList = invSubCategoryService.GetSubCategorytList();
                        lstLayer.Clear();

                        prgBar.Maximum = subCategorytList.Count - 1;
                        foreach (var item in subCategorytList)
                        {
                            lstLayer.Items.Add(item.SubCategoryName, imgIndex);
                            index++;
                            imgIndex++;
                            if (imgIndex == 4) { imgIndex = 0; }

                            prgBar.Value = index;
                            if (prgBar.Value == prgBar.Maximum)
                            {
                                prgBar.ShowPercentage = false;
                                prgBar.ShowText = true;
                                prgBar.Text = "Load Finished";
                            }
                        }
                    }
                    else if (reportTypeNo == 5)
                    {
                        imgIndex = 0;
                        InvSubCategory2Service invSubCategory2Service = new InvSubCategory2Service();
                        var subCategory2List = invSubCategory2Service.GetSubCategory2List();
                        lstLayer.Clear();

                        prgBar.Maximum = subCategory2List.Count - 1;
                        foreach (var item in subCategory2List)
                        {
                            lstLayer.Items.Add(item.SubCategory2Name, imgIndex);
                            index++;
                            imgIndex++;
                            if (imgIndex == 4) { imgIndex = 0; }

                            prgBar.Value = index;
                            if (prgBar.Value == prgBar.Maximum)
                            {
                                prgBar.ShowPercentage = false;
                                prgBar.ShowText = true;
                                prgBar.Text = "Load Finished";
                            }
                        }
                    }
                }
                else
                {
                    isSelection = false;
                    lstLayer.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        public override void Clear()
        {
            prgBar.Value = 0;
            base.Clear();
        }

        #region Item Wise
        public void ViewItemWiseSummeryReport(DateTime fromDate, DateTime toDate)
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            ResSalesServices resSalesServices = new ResSalesServices();
            ResRptItemWiseSalesGroupByLocation resRptItemWiseSalesGroupByLocationcs = new ResRptItemWiseSalesGroupByLocation();

            resRptItemWiseSalesGroupByLocationcs.SetDataSource(resSalesServices.GetDataSourceItemWiseSummery(fromDate, toDate, locationList, billingLocationList, productList, unitList, shiftDetList, isSelection));

            resRptItemWiseSalesGroupByLocationcs.SummaryInfo.ReportTitle = "Item Wise Sales Report";
            resRptItemWiseSalesGroupByLocationcs.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            resRptItemWiseSalesGroupByLocationcs.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            resRptItemWiseSalesGroupByLocationcs.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            resRptItemWiseSalesGroupByLocationcs.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            resRptItemWiseSalesGroupByLocationcs.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            resRptItemWiseSalesGroupByLocationcs.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptItemWiseSalesGroupByLocationcs.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptItemWiseSalesGroupByLocationcs.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = resRptItemWiseSalesGroupByLocationcs;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        public void ViewItemWiseDetailReport(DateTime fromDate, DateTime toDate)   
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            ResSalesServices resSalesServices = new ResSalesServices();
            ResRptItemWiseSales resRptItemWiseSales = new ResRptItemWiseSales();

            resRptItemWiseSales.SetDataSource(resSalesServices.GetDataSourceGetDataSourceItemWiseDetail(fromDate, toDate, locationList, billingLocationList, productList, unitList, shiftDetList, isSelection));

            resRptItemWiseSales.SummaryInfo.ReportTitle = "Item Wise Sales Report";
            resRptItemWiseSales.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            resRptItemWiseSales.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            resRptItemWiseSales.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            resRptItemWiseSales.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            resRptItemWiseSales.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            resRptItemWiseSales.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptItemWiseSales.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptItemWiseSales.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = resRptItemWiseSales;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Department Wise
        public void ViewDepartmentWiseSummeryReport(DateTime fromDate, DateTime toDate)
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            ResSalesServices resSalesServices = new ResSalesServices();
            ResRptDepartmentWiseSalesGroupByDepartment resRptDepartmentWiseSalesGroupByDepartment = new ResRptDepartmentWiseSalesGroupByDepartment();

            resRptDepartmentWiseSalesGroupByDepartment.SetDataSource(resSalesServices.GetDataSourceDepartmentWiseSummery(fromDate, toDate, locationList, billingLocationList, departmentList, unitList, shiftDetList, isSelection));

            resRptDepartmentWiseSalesGroupByDepartment.SummaryInfo.ReportTitle = "Department Wise Sales Report";
            resRptDepartmentWiseSalesGroupByDepartment.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            resRptDepartmentWiseSalesGroupByDepartment.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            resRptDepartmentWiseSalesGroupByDepartment.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            resRptDepartmentWiseSalesGroupByDepartment.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            resRptDepartmentWiseSalesGroupByDepartment.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            resRptDepartmentWiseSalesGroupByDepartment.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptDepartmentWiseSalesGroupByDepartment.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptDepartmentWiseSalesGroupByDepartment.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = resRptDepartmentWiseSalesGroupByDepartment;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }


        public void ViewDepartmentWiseDetailReport(DateTime fromDate, DateTime toDate) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            ResSalesServices resSalesServices = new ResSalesServices();
            ResRptDepartmentWiseSales resRptDepartmentWiseSales = new ResRptDepartmentWiseSales();

            resRptDepartmentWiseSales.SetDataSource(resSalesServices.GetDataSourceDepartmentWiseDetail(fromDate, toDate, locationList, billingLocationList, departmentList, unitList, shiftDetList, isSelection));

            resRptDepartmentWiseSales.SummaryInfo.ReportTitle = "Department Wise Sales Report";
            resRptDepartmentWiseSales.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            resRptDepartmentWiseSales.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            resRptDepartmentWiseSales.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            resRptDepartmentWiseSales.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            resRptDepartmentWiseSales.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            resRptDepartmentWiseSales.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptDepartmentWiseSales.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptDepartmentWiseSales.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = resRptDepartmentWiseSales;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Category Wise
        public void ViewCategoryWiseSummeryReport(DateTime fromDate, DateTime toDate) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            ResSalesServices resSalesServices = new ResSalesServices();
            ResRptCategoryWiseSalesGroupByCategory resRptCategoryWiseSalesGroupByCategory = new ResRptCategoryWiseSalesGroupByCategory();

            resRptCategoryWiseSalesGroupByCategory.SetDataSource(resSalesServices.GetDataSourceCategoryWiseSummery(fromDate, toDate, locationList, billingLocationList, categoryList, unitList, shiftDetList, isSelection));

            resRptCategoryWiseSalesGroupByCategory.SummaryInfo.ReportTitle = "Category Wise Sales Report";
            resRptCategoryWiseSalesGroupByCategory.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            resRptCategoryWiseSalesGroupByCategory.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            resRptCategoryWiseSalesGroupByCategory.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            resRptCategoryWiseSalesGroupByCategory.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            resRptCategoryWiseSalesGroupByCategory.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            resRptCategoryWiseSalesGroupByCategory.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptCategoryWiseSalesGroupByCategory.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptCategoryWiseSalesGroupByCategory.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = resRptCategoryWiseSalesGroupByCategory;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        public void ViewCategoryWiseDetailReport(DateTime fromDate, DateTime toDate)
        { 
            FrmReportViewer objReportView = new FrmReportViewer();
            ResSalesServices resSalesServices = new ResSalesServices();
            ResRptCategoryWiseSales resRptCategoryWiseSales = new ResRptCategoryWiseSales();

            resRptCategoryWiseSales.SetDataSource(resSalesServices.GetDataSourceCategoryWiseDetail(fromDate, toDate, locationList, billingLocationList, categoryList, unitList, shiftDetList, isSelection));

            resRptCategoryWiseSales.SummaryInfo.ReportTitle = "Category Wise Sales Report";
            resRptCategoryWiseSales.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            resRptCategoryWiseSales.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            resRptCategoryWiseSales.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            resRptCategoryWiseSales.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            resRptCategoryWiseSales.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            resRptCategoryWiseSales.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptCategoryWiseSales.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptCategoryWiseSales.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = resRptCategoryWiseSales;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Sub Category Wise
        public void ViewSubCategoryWiseSummeryReport(DateTime fromDate, DateTime toDate) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            ResSalesServices resSalesServices = new ResSalesServices();
            ResRptSubCategoryWiseSalesGroupBySubCategory resRptSubCategoryWiseSalesGroupBySubCategory = new ResRptSubCategoryWiseSalesGroupBySubCategory();

            resRptSubCategoryWiseSalesGroupBySubCategory.SetDataSource(resSalesServices.GetDataSourceSubCategoryWiseSummery(fromDate, toDate, locationList, billingLocationList, subCategoryList, unitList, shiftDetList, isSelection));

            resRptSubCategoryWiseSalesGroupBySubCategory.SummaryInfo.ReportTitle = "Sub Category Wise Sales Report";
            resRptSubCategoryWiseSalesGroupBySubCategory.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            resRptSubCategoryWiseSalesGroupBySubCategory.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            resRptSubCategoryWiseSalesGroupBySubCategory.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            resRptSubCategoryWiseSalesGroupBySubCategory.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            resRptSubCategoryWiseSalesGroupBySubCategory.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            resRptSubCategoryWiseSalesGroupBySubCategory.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptSubCategoryWiseSalesGroupBySubCategory.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptSubCategoryWiseSalesGroupBySubCategory.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = resRptSubCategoryWiseSalesGroupBySubCategory;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        public void ViewSubCategoryWiseDetailReport(DateTime fromDate, DateTime toDate) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            ResSalesServices resSalesServices = new ResSalesServices();
            ResRptSubCategoryWiseSales resRptSubCategoryWiseSales = new ResRptSubCategoryWiseSales();

            resRptSubCategoryWiseSales.SetDataSource(resSalesServices.GetDataSourceSubCategoryWiseDetail(fromDate, toDate, locationList, billingLocationList, subCategoryList, unitList, shiftDetList, isSelection));

            resRptSubCategoryWiseSales.SummaryInfo.ReportTitle = "Sub Category Wise Sales Report";
            resRptSubCategoryWiseSales.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            resRptSubCategoryWiseSales.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            resRptSubCategoryWiseSales.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            resRptSubCategoryWiseSales.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            resRptSubCategoryWiseSales.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            resRptSubCategoryWiseSales.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptSubCategoryWiseSales.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptSubCategoryWiseSales.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = resRptSubCategoryWiseSales;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Sub Category2 Wise
        public void ViewSubCategory2WiseSummeryReport(DateTime fromDate, DateTime toDate) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            ResSalesServices resSalesServices = new ResSalesServices();
            ResRptSubCategory2WiseSalesGroupBySubCategory2 resRptSubCategory2WiseSalesGroupBySubCategory2 = new ResRptSubCategory2WiseSalesGroupBySubCategory2();

            resRptSubCategory2WiseSalesGroupBySubCategory2.SetDataSource(resSalesServices.GetDataSourceSubCategory2WiseSummery(fromDate, toDate, locationList, billingLocationList, subCategory2List, unitList, shiftDetList, isSelection));

            resRptSubCategory2WiseSalesGroupBySubCategory2.SummaryInfo.ReportTitle = "Sub Category2 Wise Sales Report";
            resRptSubCategory2WiseSalesGroupBySubCategory2.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            resRptSubCategory2WiseSalesGroupBySubCategory2.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            resRptSubCategory2WiseSalesGroupBySubCategory2.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            resRptSubCategory2WiseSalesGroupBySubCategory2.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            resRptSubCategory2WiseSalesGroupBySubCategory2.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            resRptSubCategory2WiseSalesGroupBySubCategory2.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptSubCategory2WiseSalesGroupBySubCategory2.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptSubCategory2WiseSalesGroupBySubCategory2.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = resRptSubCategory2WiseSalesGroupBySubCategory2;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        public void ViewSubCategory2WiseDetailReport(DateTime fromDate, DateTime toDate) 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            ResSalesServices resSalesServices = new ResSalesServices();
            ResRptSubCategory2WiseSales resRptSubCategory2WiseSales = new ResRptSubCategory2WiseSales();

            resRptSubCategory2WiseSales.SetDataSource(resSalesServices.GetDataSourceSubCategory2WiseDetail(fromDate, toDate, locationList, billingLocationList, subCategory2List, unitList, shiftDetList, isSelection));

            resRptSubCategory2WiseSales.SummaryInfo.ReportTitle = "Sub Category2 Wise Sales Report";
            resRptSubCategory2WiseSales.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            resRptSubCategory2WiseSales.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            resRptSubCategory2WiseSales.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Value + "'";
            resRptSubCategory2WiseSales.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Value + "'";

            resRptSubCategory2WiseSales.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            resRptSubCategory2WiseSales.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptSubCategory2WiseSales.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptSubCategory2WiseSales.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = resRptSubCategory2WiseSales;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }
        #endregion

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

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            try
            {
                isSelection = false;
                lstLayer.Clear();
                prgBar.Value = 0;
                rdoSelection.Checked = false;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

    }
}
