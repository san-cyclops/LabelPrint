using System;                                                      
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;
using CrystalDecisions.CrystalReports.Engine;
using ERP.Domain;
using ERP.Utility;
using ERP.Service;
using System.Collections;
using ERP.Report.Com.Transactions.Reports;
using CrystalDecisions.Shared;
using ERP.Report.Restaurant.Reference.Reports;
using ERP.Report.Restaurant.Transactions.Reports;
using ERP.Service.Restaurant;

namespace ERP.Report.Restaurant
{
    class ReportSources
    {
        public DataTable reportData { get; set; }
        public ArrayList newSumFieldsIndexes { get; set; }
    }

    public class ResReportGenerator
    {
        private string dataSetName;

        private string sqlStatement;
        public string SqlStatement
        {
            get { return sqlStatement; }
            set { sqlStatement = value; }
        }

        private DataSet dsReport = new DataSet();
        public DataSet DsReport
        {
            get { return dsReport; }
        }

        //public FrmReprotGenerator frmReprotGenerator { get; set; }

        string strFieldName = string.Empty;
        string groupingFields = string.Empty;

        #region report user privileges
        UserPrivileges showCostPrice = new UserPrivileges();
        UserPrivileges showSellingPrice = new UserPrivileges();
        UserPrivileges showQty = new UserPrivileges();
        #endregion

        private void CheckUserRights()
        {
            showCostPrice = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, 19002);
            showSellingPrice = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, 19003);
            showQty = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, 19004);
        }

        /// <summary>
        /// Organize Report Generator Fields
        /// </summary>
        /// <param name="autoGenerateInfo"></param>
        /// <returns></returns>
        public FrmReprotGenerator OrganizeFormFields(AutoGenerateInfo autoGenerateInfo)
        {
            List<Common.ReportDataStruct> reportDatStructList = new List<Common.ReportDataStruct>();
            FrmReprotGenerator frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList);

            string departmentText = "", categoryText = "", subCategoryText = "", subCategory2Text = "";
            departmentText = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmDepartment").FormText;
            categoryText = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmCategory").FormText;
            subCategoryText = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmSubCategory").FormText;
            subCategory2Text = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmSubCategory2").FormText;

            string strComparisonFieldNamePortion = " (Comparison)";

            CheckUserRights();

            switch (autoGenerateInfo.FormName)
            {
                #region RptResSalesRegister
                case "RptResSalesRegister":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Prod. Code", ReportDataType = typeof(string), DbColumnName = "ProductCode", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Product Name", ReportDataType = typeof(string), DbColumnName = "ProductName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationName", ValueDataType = typeof(string), IsConditionField = true, IsSelectionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = departmentText, ReportDataType = typeof(string), DbColumnName = "DepartmentName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = categoryText, ReportDataType = typeof(string), DbColumnName = "CategoryName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true, });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = subCategoryText, ReportDataType = typeof(string), DbColumnName = "SubCategoryName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true, });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = subCategory2Text, ReportDataType = typeof(string), DbColumnName = "SubCategory2Name", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true, });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Sale Type", ReportDataType = typeof(string), DbColumnName = "DocumentID", ValueDataType = typeof(int), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true, IsComparisonField = true, ComparisonFieldNamePortion = strComparisonFieldNamePortion });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Terminal", ReportDataType = typeof(string), DbColumnName = "TerminalNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Customer Type", ReportDataType = typeof(string), DbColumnName = "CustomerType", ValueDataType = typeof(int), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString12", ReportFieldName = "Customer", ReportDataType = typeof(string), DbColumnName = "CustomerCode", ValueDataType = typeof(string), IsSelectionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString13", ReportFieldName = "Cashier", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString14", ReportFieldName = "Supplier", ReportDataType = typeof(string), DbColumnName = "SupplierName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString15", ReportFieldName = "Billing Location", ReportDataType = typeof(string), DbColumnName = "LocationID", ValueDataType = typeof(int), IsConditionField = true, IsSelectionField = true, IsGroupBy = true });


                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Qty", ReportDataType = typeof(decimal), DbColumnName = "Qty", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsUnAuthorized = (!showQty.IsAccess) });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Gross Amt.", ReportDataType = typeof(decimal), DbColumnName = "GrossAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Dis. Amt.", ReportDataType = typeof(decimal), DbColumnName = "DiscountAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "S. Disc. Amount.", ReportDataType = typeof(decimal), DbColumnName = "SubTotalDiscountAmount", ValueDataType = typeof(decimal), IsSelectionField = false, IsColumnTotal = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "Net. Amt.", ReportDataType = typeof(decimal), DbColumnName = "NetAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal5", ReportFieldName = "Sel. Price", ReportDataType = typeof(decimal), DbColumnName = "SellingPrice", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsUnAuthorized = (!showSellingPrice.IsAccess) });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal6", ReportFieldName = "Cost Price", ReportDataType = typeof(decimal), DbColumnName = "CostPrice", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsUnAuthorized = (!showCostPrice.IsAccess) });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);
                //return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList);
                #endregion

                #region RptResSalesRegisterExt
                case "RptResSalesRegisterExt":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Prod. Code", ReportDataType = typeof(string), DbColumnName = "ProductCode", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Product Name", ReportDataType = typeof(string), DbColumnName = "ProductName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationName", ValueDataType = typeof(string), IsConditionField = true, IsSelectionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = departmentText, ReportDataType = typeof(string), DbColumnName = "DepartmentName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = categoryText, ReportDataType = typeof(string), DbColumnName = "CategoryName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true, });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = subCategoryText, ReportDataType = typeof(string), DbColumnName = "SubCategoryName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true, });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = subCategory2Text, ReportDataType = typeof(string), DbColumnName = "SubCategory2Name", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true, });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Sale Type", ReportDataType = typeof(string), DbColumnName = "DocumentID", ValueDataType = typeof(int), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Terminal", ReportDataType = typeof(string), DbColumnName = "TerminalNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Customer Type", ReportDataType = typeof(string), DbColumnName = "CustomerType", ValueDataType = typeof(int), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString12", ReportFieldName = "Customer", ReportDataType = typeof(string), DbColumnName = "CustomerCode", ValueDataType = typeof(string), IsSelectionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString13", ReportFieldName = "Cashier", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString14", ReportFieldName = "Supplier", ReportDataType = typeof(string), DbColumnName = "SupplierName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString15", ReportFieldName = "Colour", ReportDataType = typeof(string), DbColumnName = "Colour", DbJoinColumnName = "Colour", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString16", ReportFieldName = "Country", ReportDataType = typeof(string), DbColumnName = "Country", DbJoinColumnName = "Country", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString17", ReportFieldName = "Cut", ReportDataType = typeof(string), DbColumnName = "Cut", DbJoinColumnName = "Cut", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString18", ReportFieldName = "Embelishment", ReportDataType = typeof(string), DbColumnName = "Embelishment", DbJoinColumnName = "Embelishment", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString19", ReportFieldName = "Fit", ReportDataType = typeof(string), DbColumnName = "Fit", DbJoinColumnName = "Fit", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString20", ReportFieldName = "Heel", ReportDataType = typeof(string), DbColumnName = "Heel", DbJoinColumnName = "Heel", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString21", ReportFieldName = "Length", ReportDataType = typeof(string), DbColumnName = "Length", DbJoinColumnName = "Length", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString22", ReportFieldName = "Material", ReportDataType = typeof(string), DbColumnName = "Material", DbJoinColumnName = "Material", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString23", ReportFieldName = "Neck", ReportDataType = typeof(string), DbColumnName = "Neck", DbJoinColumnName = "Neck", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString24", ReportFieldName = "PatternNo", ReportDataType = typeof(string), DbColumnName = "PatternNo", DbJoinColumnName = "PatternNo", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString25", ReportFieldName = "ProductFeature", ReportDataType = typeof(string), DbColumnName = "ProductFeature", DbJoinColumnName = "ProductFeature", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString26", ReportFieldName = "Shop", ReportDataType = typeof(string), DbColumnName = "Shop", DbJoinColumnName = "Shop", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString27", ReportFieldName = "Size", ReportDataType = typeof(string), DbColumnName = "Size", DbJoinColumnName = "Size", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString28", ReportFieldName = "Sleeve", ReportDataType = typeof(string), DbColumnName = "Sleeve", DbJoinColumnName = "Sleeve", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString29", ReportFieldName = "Texture", ReportDataType = typeof(string), DbColumnName = "Texture", DbJoinColumnName = "Texture", IsJoinField = true, ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Qty", ReportDataType = typeof(decimal), DbColumnName = "Qty", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsUnAuthorized = (!showQty.IsAccess) });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Gross Amt.", ReportDataType = typeof(decimal), DbColumnName = "GrossAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Dis. Amt.", ReportDataType = typeof(decimal), DbColumnName = "DiscountAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "S. Disc. Amount.", ReportDataType = typeof(decimal), DbColumnName = "SubTotalDiscountAmount", ValueDataType = typeof(decimal), IsSelectionField = false, IsColumnTotal = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "Net. Amt.", ReportDataType = typeof(decimal), DbColumnName = "NetAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal5", ReportFieldName = "Sel. Price", ReportDataType = typeof(decimal), DbColumnName = "SellingPrice", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsUnAuthorized = (!showSellingPrice.IsAccess) });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal6", ReportFieldName = "Cost Price", ReportDataType = typeof(decimal), DbColumnName = "CostPrice", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsUnAuthorized = (!showCostPrice.IsAccess) });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 4);
                //return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList);
                #endregion

                #region BillingLocation
                case "FrmBillingLocation":
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Bill.Loca.Code", ReportDataType = typeof(string), DbColumnName = "LocationCode", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true }); //, IsGroupBy = true
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Bill.Loca.Name", ReportDataType = typeof(string), DbColumnName = "LocationName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Company", ReportDataType = typeof(string), DbColumnName = "CompanyID", DbJoinColumnName = "CompanyName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsSelectionField = true, IsGroupBy = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Address", ReportDataType = typeof(string), DbColumnName = "Address1", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Telephone", ReportDataType = typeof(string), DbColumnName = "Telephone", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Contact Person", ReportDataType = typeof(string), DbColumnName = "ContactPersonName", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Other Business Name", ReportDataType = typeof(string), DbColumnName = "OtherBusinessName", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "CreatedDate", ValueDataType = typeof(DateTime), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Costing Method", ReportDataType = typeof(string), DbColumnName = "CostingMethod", ValueDataType = typeof(string), IsSelectionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Type of Business", ReportDataType = typeof(string), DbColumnName = "TypeOfBusiness", ValueDataType = typeof(string), IsSelectionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString12", ReportFieldName = "Prefix Code", ReportDataType = typeof(string), DbColumnName = "LocationPrefixCode", ValueDataType = typeof(string), IsJoinField = true, IsSelectionField = true });
                    frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 14, 0, 4);
                    return frmReprotGenerator;
                #endregion

                default:
                    return null;
            }
        }


        public ArrayList GetSelectionData(Common.ReportDataStruct reportDatStruct, AutoGenerateInfo autoGenerateInfo)
        {
            switch (autoGenerateInfo.FormName)
            {
                case "RptResSalesRegister":
                    ResSalesServices resSalesServiceSalesRegister = new ResSalesServices();
                    return resSalesServiceSalesRegister.GetSelectionSalesDataSummary(reportDatStruct);
                case "FrmBillingLocation":
                    BillingLocationService billingLocationService = new BillingLocationService();
                    return billingLocationService.GetSelectionData(reportDatStruct);

                default:
                    return null;
            }
        }

        public DataTable GetResultData(List<Common.ReportConditionsDataStruct> reportConditionsDataStructList, List<Common.ReportDataStruct> reportDataStructList, List<Common.ReportDataStruct> reportGroupDataStructList, List<Common.ReportDataStruct> reportOrderByDataStructList, AutoGenerateInfo autoGenerateInfo)
        {
            switch (autoGenerateInfo.FormName)
            {
                case "RptResSalesRegister":
                    ResSalesServices resSalesServicesSalesRegister = new ResSalesServices();
                    return resSalesServicesSalesRegister.GetSalesRegisterDataTable(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                
                case "RptResSalesRegisterExt":
                    resSalesServicesSalesRegister = new ResSalesServices();
                    return resSalesServicesSalesRegister.GetSalesRegisterExtDataTable(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);

                case "FrmBillingLocation":
                    BillingLocationService billingLocationService = new BillingLocationService();
                    return billingLocationService.GetAllLocationDataTable(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList);                  
                   
                default:
                    return null;
            }
        }


        public void GenearateTransactionSummeryReport(AutoGenerateInfo autoGenerateInfo, DataTable dtReportData, DataTable dtReportConditions, List<Common.ReportDataStruct> reportDataStructList, List<Common.ReportDataStruct> groupByStructList, bool viewGroupDetails, bool isComparisonReport = false)
        {
            FrmReportViewer reportViewer = new FrmReportViewer();
            Cursor.Current = Cursors.WaitCursor;
            DataTable dtArrangedReportData = new DataTable();

            int yx = 0;
            switch (autoGenerateInfo.FormName)
            {
                #region Sales Register
                case "RptResSalesRegister":
                    if (isComparisonReport)
                    {
                        //InvRptComparisonTemplate invRptComparisonTemplate = new InvRptComparisonTemplate();
                        //reportViewer.crRptViewer.ReportSource = ViewComparisonReport(invRptComparisonTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                        {
                            ResRptGroupedDetailsTemplate resRptGroupedDetailsTemplate = new ResRptGroupedDetailsTemplate();
                            reportViewer.crRptViewer.ReportSource = ViewGroupedReport(resRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                        }
                        else
                        {
                            ResRptDetailsTemplate resRptDetailsTemplate = new ResRptDetailsTemplate();
                            reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(resRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                        }
                    }
                    break;
                #endregion

                #region Sales RegisterExt
                case "RptResSalesRegisterExt":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        ResRptGroupedDetailsTemplate resRptGroupedDetailsTemplate = new ResRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(resRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        ResRptDetailsTemplate resRptDetailsTemplate = new ResRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(resRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    break;
                #endregion

                default:
                    return;
            }

            reportViewer.WindowState = FormWindowState.Maximized;
            reportViewer.Show();
            // reportViewer.crRptViewer.ReportSource = null;

            Cursor.Current = Cursors.Default;
        }


        private ResRptGroupedDetailsTemplate ViewGroupedReport(ResRptGroupedDetailsTemplate resRptGroupedDetailsTemplate, DataTable dtReportData, DataTable dtReportConditions, List<Common.ReportDataStruct> reportDataStructList, AutoGenerateInfo autoGenerateInfo, bool viewGroupRowCount = false)
        {
            DataTable dtArrangedReportData = new DataTable();

            #region Set Values for report header fields
            
            strFieldName = string.Empty;
            int sr = 1, dc = 11;

            foreach (var col in dtReportData.Columns)
            {
                if (reportDataStructList.Any(c => c.ReportField.Equals(col.ToString())))
                {
                    Common.ReportDataStruct reportDataStruct = reportDataStructList.Where(c => c.ReportField.Equals(col.ToString())).FirstOrDefault();
                    if (reportDataStruct.ReportDataType.Equals(typeof(string)))
                    {
                        strFieldName = "st" + sr;
                        resRptGroupedDetailsTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStruct.ReportFieldName.Trim() + "'";
                        sr++;
                        groupingFields = string.IsNullOrEmpty(groupingFields) ? (reportDataStruct.ReportFieldName.Trim()) : (groupingFields + "/ " + reportDataStruct.ReportFieldName.Trim());
                    }

                    if (reportDataStruct.ReportDataType.Equals(typeof(decimal)))
                    {
                        strFieldName = "st" + dc;
                        resRptGroupedDetailsTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStruct.ReportFieldName.Trim() + "'";
                        dc++;
                    }
                }
            }

            #endregion

            // Re arrange data table header columns for report
            dtArrangedReportData = dtReportData.Copy();
            dtReportData = null;
            dtArrangedReportData = ConvertDateTimeFieldsToStringFields(SetReportDataTableHeadersForReport(dtArrangedReportData));

            resRptGroupedDetailsTemplate.SetDataSource(dtArrangedReportData);
            resRptGroupedDetailsTemplate.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
            resRptGroupedDetailsTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
            resRptGroupedDetailsTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            resRptGroupedDetailsTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            resRptGroupedDetailsTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptGroupedDetailsTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptGroupedDetailsTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            resRptGroupedDetailsTemplate.DataDefinition.FormulaFields["GroupNames"].Text = "'" + (string.IsNullOrEmpty(groupingFields) ? "" : groupingFields) + "'";
            resRptGroupedDetailsTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";
            resRptGroupedDetailsTemplate.SetParameterValue("prmGroupRowCount", viewGroupRowCount);

            #region Group By

             int ix = 0;
            // Set report group field values
            for (int i = 0; i < dtArrangedReportData.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FieldString")).Count(); i++)
            {
                if (i < resRptGroupedDetailsTemplate.DataDefinition.Groups.Count)
                {
                    resRptGroupedDetailsTemplate.DataDefinition.Groups[i].ConditionField = resRptGroupedDetailsTemplate.Database.Tables[0].Fields[string.Concat("FieldString", (i + 1).ToString())];
                    ix++;
                }
            }

            // Set report group field values * decimal field
            for (int i = 0; i < dtArrangedReportData.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FieldDecimal")).Count(); i++)
            {
                if (i < resRptGroupedDetailsTemplate.DataDefinition.Groups.Count)
                {
                    resRptGroupedDetailsTemplate.DataDefinition.Groups[ix].ConditionField = resRptGroupedDetailsTemplate.Database.Tables[0].Fields[string.Concat("FieldDecimal", (i + 1).ToString())];
                    ix++;
                }
            }

            // Set parameter select field values
            for (int i = 0; i < resRptGroupedDetailsTemplate.DataDefinition.Groups.Count; i++)
            {
                if (resRptGroupedDetailsTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                {
                    if (i < dtArrangedReportData.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FieldString")).Count())
                    {
                        resRptGroupedDetailsTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), true);
                    }
                    else
                    {
                        resRptGroupedDetailsTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                    }
                }
            }

            #endregion

            return resRptGroupedDetailsTemplate;
        }


        private ResRptDetailsTemplate ViewUnGroupedReport(ResRptDetailsTemplate resRptDetailsTemplate, DataTable dtReportData, DataTable dtReportConditions, List<Common.ReportDataStruct> reportDataStructList, AutoGenerateInfo autoGenerateInfo)
        {
            DataTable dtArrangedReportData = new DataTable();
            
            #region Set Values for report header fields
            
            strFieldName = string.Empty;
            int sr = 1, dc = 11;

            foreach (var item in reportDataStructList)
            {
                if (dtReportData.Columns.Contains(item.ReportField.Trim()))
                {

                    if (item.ReportDataType.Equals(typeof(string)))
                    {
                        strFieldName = "st" + sr;
                        resRptDetailsTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                        sr++;
                    }

                    if (item.ReportDataType.Equals(typeof(decimal)))
                    {
                        strFieldName = "st" + dc;
                        resRptDetailsTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                        dc++;
                    }
                }
            }

            #endregion

            // Re arrange data table header columns for report
            dtArrangedReportData = dtReportData.Copy();
            dtReportData = null;
            ReportSources reportSources = new ReportSources();
            reportSources = SetReportSourcesForReport(dtArrangedReportData, reportDataStructList);
            dtArrangedReportData = reportSources.reportData;
            ArrayList newSumFieldsIndexesList = reportSources.newSumFieldsIndexes;

            resRptDetailsTemplate.SetDataSource(dtArrangedReportData);
            resRptDetailsTemplate.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
            resRptDetailsTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
            resRptDetailsTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            resRptDetailsTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            resRptDetailsTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptDetailsTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptDetailsTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            resRptDetailsTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

            // Set parameter sum fields
            for (int i = 0; i < resRptDetailsTemplate.ParameterFields.Count; i++)
            {
                if (resRptDetailsTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter) && newSumFieldsIndexesList.Contains(i + 1) && resRptDetailsTemplate.ParameterFields[i].Name.StartsWith("prmSumFieldDecimal"))
                {
                    resRptDetailsTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), true);
                }
                else
                {
                    resRptDetailsTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), false);
                }
            }

            return resRptDetailsTemplate;

        }


        private DataTable ConvertDateTimeFieldsToStringFields(DataTable dtReportData)
        {
            DataTable dtCloned = dtReportData.Clone();

            for (int i = 0; i < dtReportData.Columns.Count; i++)
            {
                if (dtReportData.Columns[i].DataType.Equals(typeof(DateTime)))
                {
                    dtCloned.Columns[i].DataType = typeof(string);
                }
            }

            foreach (DataRow row in dtReportData.Rows)
            {
                dtCloned.ImportRow(row);
            }

            return dtCloned;
        }

        private DataTable SetReportDataTableHeadersForReport(DataTable dtReportData)
        {

            int stringColIndex = 0, decimalColIndex = 0;
            string stringColumnName = "FieldString";
            string decimalColumnName = "FieldDecimal";

            foreach (DataColumn col in dtReportData.Columns)
            {
                // Reset all column headers before arrange them according to report fields  
                if (col.ColumnName.Contains(stringColumnName))
                {
                    col.ColumnName = stringColumnName + (stringColIndex + 1 + "S").ToString();
                    stringColIndex++;
                }

                if (col.ColumnName.Contains(decimalColumnName))
                {
                    col.ColumnName = decimalColumnName + (decimalColIndex + 1 + "D").ToString();
                    decimalColIndex++;
                }
            }

            // Rearrange column headers for the report
            foreach (DataColumn col in dtReportData.Columns)
            {
                if (col.ColumnName.Contains(stringColumnName))
                {
                    col.ColumnName = col.ColumnName.Remove(col.ColumnName.Length - 1, 1);
                }

                if (col.ColumnName.Contains(decimalColumnName))
                {
                    col.ColumnName = col.ColumnName.Remove(col.ColumnName.Length - 1, 1);
                }
            }

            return dtReportData;
        }

        private ReportSources SetReportSourcesForReport(DataTable reportData, List<Common.ReportDataStruct> reportDataStructList)
        {
            ReportSources reportSources = new ReportSources();
            ArrayList originalSumFields = new ArrayList();
            ArrayList newIndexesList = new ArrayList();

            int stringColIndex = 0, decimalColIndex = 0;
            string stringColumnName = "FieldString";
            string decimalColumnName = "FieldDecimal";

            originalSumFields.AddRange(reportDataStructList.Where(d => d.ReportDataType.Equals(typeof(decimal)) && d.IsColumnTotal.Equals(true)).Select(d => d.ReportField).ToList());

            foreach (DataColumn col in reportData.Columns)
            {
                // Reset all column headers before arrange them according to report fields  
                if (col.ColumnName.Contains(stringColumnName))
                {
                    col.ColumnName = stringColumnName + (stringColIndex + 1 + "S").ToString();
                    stringColIndex++;
                }

                if (col.ColumnName.Contains(decimalColumnName))
                {
                    if (originalSumFields.Contains(col.ColumnName))
                    {
                        newIndexesList.Add(decimalColIndex + 1);
                    }
                    col.ColumnName = decimalColumnName + (decimalColIndex + 1 + "D").ToString();
                    decimalColIndex++;
                }
            }

            // Rearrange column headers for the report
            foreach (DataColumn col in reportData.Columns)
            {
                if (col.ColumnName.Contains(stringColumnName))
                {
                    col.ColumnName = col.ColumnName.Remove(col.ColumnName.Length - 1, 1);
                }

                if (col.ColumnName.Contains(decimalColumnName))
                {
                    col.ColumnName = col.ColumnName.Remove(col.ColumnName.Length - 1, 1);
                }
            }

            reportSources.reportData = reportData;
            reportData = null;
            reportSources.newSumFieldsIndexes = newIndexesList;
            return reportSources;
        }


        public string GetConditionValue(Common.ReportDataStruct reportDataStruct, string dataValue)
        {
            string conditionValue = string.Empty;
            switch (reportDataStruct.DbColumnName.Trim())
            {
                case "SupplierID":
                    SupplierService supplierService = new SupplierService();
                    conditionValue = supplierService.GetSupplierByName(dataValue.Trim()).SupplierName.ToString();
                    break;
                case "LookupKey":
                    LookUpReferenceService lookUpReferenceTitleTypeService = new LookUpReferenceService();
                    string titleType = ((int)LookUpReference.TitleType).ToString();
                    conditionValue = lookUpReferenceTitleTypeService.GetLookUpReferenceByKey(titleType, int.Parse(dataValue.Trim())).LookupKey.ToString();
                    break;
                case "SalesPersonTypeID":
                    LookUpReferenceService lookUpReferenceSalesPersonTypeService = new LookUpReferenceService();
                    string salesPersonType = ((int)LookUpReference.SalesPersonType).ToString();
                    conditionValue = lookUpReferenceSalesPersonTypeService.GetLookUpReferenceByKey(salesPersonType, int.Parse(dataValue.Trim())).LookupKey.ToString();
                    break;
                case "PaymentMethodID":
                    PaymentMethodService paymentMethodService = new PaymentMethodService();
                    if (string.Equals(reportDataStruct.DbJoinColumnName, "PaymentMethodName"))
                    { conditionValue = paymentMethodService.GetPaymentMethodsByName(dataValue.Trim()).PaymentMethodName.ToString(); }
                    else
                    { conditionValue = paymentMethodService.GetPaymentMethodsByID(int.Parse(dataValue.Trim())).PaymentMethodID.ToString(); }
                    break;
                case "PaymentTermID":
                    PaymentTermService paymentTermService = new PaymentTermService();
                    if (string.Equals(reportDataStruct.DbJoinColumnName, "PaymentTermName"))
                    { conditionValue = paymentTermService.GetPaymentTermsByName(dataValue.Trim()).PaymentTermName.ToString(); }
                    else
                    { conditionValue = paymentTermService.GetPaymentTermsByID(int.Parse(dataValue.Trim())).PaymentTermID.ToString(); }
                    break;
                case "SupplierGroupID":
                    SupplierGroupService supplierGroupService = new SupplierGroupService();
                    if (string.Equals(reportDataStruct.DbJoinColumnName, "SupplierGroupName"))
                    { conditionValue = supplierGroupService.GetSupplierGroupsByName(dataValue.Trim()).SupplierGroupName.ToString(); }
                    else if (string.Equals(reportDataStruct.DbJoinColumnName, "SupplierGroupCode"))
                    { conditionValue = supplierGroupService.GetSupplierGroupsByCode(dataValue.Trim()).SupplierGroupCode.ToString(); }
                    else
                    { conditionValue = supplierGroupService.GetSupplierGroupsByID(int.Parse(dataValue.Trim())).SupplierGroupID.ToString(); }
                    break;

                case "CustomerID":
                    CustomerService customerService = new CustomerService();
                    conditionValue = customerService.GetCustomersByCode(dataValue.Trim()).CustomerID.ToString();
                    break;
                case "InvSalesPersonID":
                    InvSalesPersonService invSalesPersonService = new InvSalesPersonService();
                    conditionValue = invSalesPersonService.GetInvSalesPersonByCode(dataValue.Trim()).InvSalesPersonID.ToString();
                    break;
                case "ProductID":
                    InvProductMasterService invProductMasterService = new InvProductMasterService();
                    conditionValue = invProductMasterService.GetProductsByCode(dataValue.Trim()).InvProductMasterID.ToString();
                    break;
                case "InvProductMasterID":
                    InvProductMasterService invProductMasterServicePm = new InvProductMasterService();
                    if (string.Equals(reportDataStruct.DbJoinColumnName, "ProductCode"))
                    {
                        conditionValue = invProductMasterServicePm.GetProductsByCode(dataValue.Trim()).ProductCode.ToString();
                    }
                    if (string.Equals(reportDataStruct.DbJoinColumnName, "ProductName"))
                    {
                        conditionValue = invProductMasterServicePm.GetProductsByName(dataValue.Trim()).ProductName.ToString();
                    }

                    break;
                case "InvPurchaseHeaderID":
                    AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
                    autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmGoodsReceivedNote");
                    InvPurchaseService invPurchaseService = new InvPurchaseService();
                    conditionValue = invPurchaseService.GetInvPurchaseHeaderByDocumentNo(autoGenerateInfo.DocumentID, dataValue.Trim(), Common.LoggedLocationID).InvPurchaseHeaderID.ToString();
                    break;
                case "InvDepartmentID":
                    InvDepartmentService invDepartmentService = new InvDepartmentService();
                    bool isDepend = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmDepartment").IsDepend;
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = invDepartmentService.GetInvDepartmentsByCode(dataValue.Trim(), isDepend).InvDepartmentID.ToString(); }
                    else
                    { conditionValue = invDepartmentService.GetInvDepartmentsByName(dataValue.Trim(), isDepend).DepartmentName.ToString(); }

                    break;
                case "DepartmentID":
                    InvDepartmentService invProductDepartmentService = new InvDepartmentService();
                    bool isDependProduct = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmDepartment").IsDepend;
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = invProductDepartmentService.GetInvDepartmentsByCode(dataValue.Trim(), isDependProduct).InvDepartmentID.ToString(); }
                    else
                    { conditionValue = invProductDepartmentService.GetInvDepartmentsByName(dataValue.Trim(), isDependProduct).DepartmentName.ToString(); }
                    break;
                case "InvCategoryID":
                    InvCategoryService invCategoryService = new InvCategoryService();
                    bool isDependDepartment = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmCategory").IsDepend;
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = invCategoryService.GetInvCategoryByCode(dataValue.Trim(), isDependDepartment).InvCategoryID.ToString(); }
                    else
                    { conditionValue = invCategoryService.GetInvCategoryByName(dataValue.Trim(), isDependDepartment).CategoryName.ToString(); }
                    break;
                case "CategoryID":
                    InvCategoryService invProductCategoryService = new InvCategoryService();
                    bool isDependProductDepartment = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmCategory").IsDepend;
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = invProductCategoryService.GetInvCategoryByCode(dataValue.Trim(), isDependProductDepartment).InvCategoryID.ToString(); }
                    else
                    { conditionValue = invProductCategoryService.GetInvCategoryByName(dataValue.Trim(), isDependProductDepartment).CategoryName.ToString(); }
                    break;
                case "InvSubCategoryID":
                    InvSubCategoryService invSubCategoryService = new InvSubCategoryService();
                    bool isDependCategory = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmSubCategory").IsDepend;
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = invSubCategoryService.GetInvSubCategoryByCode(dataValue.Trim(), isDependCategory).InvCategoryID.ToString(); }
                    else
                    { conditionValue = invSubCategoryService.GetInvSubCategoryByName(dataValue.Trim(), isDependCategory).SubCategoryName.ToString(); }
                    break;
                case "SubCategoryID":
                    InvSubCategoryService invProductSubCategoryService = new InvSubCategoryService();
                    bool isDependProductCategory = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmSubCategory").IsDepend;
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = invProductSubCategoryService.GetInvSubCategoryByCode(dataValue.Trim(), isDependProductCategory).InvCategoryID.ToString(); }
                    else
                    { conditionValue = invProductSubCategoryService.GetInvSubCategoryByName(dataValue.Trim(), isDependProductCategory).SubCategoryName.ToString(); }
                    break;
                case "InvSubCategory2ID":
                    InvSubCategory2Service invSubCategory2Service = new InvSubCategory2Service();
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = invSubCategory2Service.GetInvSubCategory2ByCode(dataValue.Trim()).InvSubCategoryID.ToString(); }
                    else
                    { conditionValue = invSubCategory2Service.GetInvSubCategory2ByName(dataValue.Trim()).SubCategory2Name.ToString(); }
                    break;
                case "SubCategory2ID":
                    InvSubCategory2Service invProductSubCategory2Service = new InvSubCategory2Service();
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = invProductSubCategory2Service.GetInvSubCategory2ByCode(dataValue.Trim()).InvSubCategoryID.ToString(); }
                    else
                    { conditionValue = invProductSubCategory2Service.GetInvSubCategory2ByName(dataValue.Trim()).SubCategory2Name.ToString(); }
                    break;
                case "LocationID":
                case "ToLocationID":
                    LocationService locationService = new LocationService();
                    conditionValue = locationService.GetLocationsByName(dataValue.Trim()).LocationName.ToString();
                    break;
                case "LocationId":
                    locationService = new LocationService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = locationService.GetLocationsByName(dataValue.Trim()).LocationID.ToString(); }
                    else
                    { conditionValue = locationService.GetLocationsByName(dataValue.Trim()).LocationName.ToString(); }
                    break;
                case "FromLocationID":
                    locationService = new LocationService();
                    conditionValue = locationService.GetLocationsByName(dataValue.Trim()).LocationName.ToString();
                    break;
                case "UnitOfMeasureID":
                    UnitOfMeasureService unitOfMeasureService = new UnitOfMeasureService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = unitOfMeasureService.GetUnitOfMeasureByName(dataValue.Trim()).UnitOfMeasureID.ToString(); }
                    else
                    { conditionValue = unitOfMeasureService.GetUnitOfMeasureByName(dataValue.Trim()).UnitOfMeasureName.ToString(); }
                    break;
                case "StockAdjustmentMode":
                    LookUpReferenceService lookUpReferenceService = new LookUpReferenceService();
                    conditionValue = lookUpReferenceService.GetLookUpReferenceByValue(((int)LookUpReference.StockAdjustmentMode).ToString(), dataValue.Trim()).LookupKey.ToString();
                    break;
                case "TransferTypeID":
                    InvTransferTypeService invTransferTypeService = new InvTransferTypeService();
                    conditionValue = invTransferTypeService.GetTransferTypesByName(dataValue.Trim()).TransferType.Trim();
                    break;
                case "EmployeeId":
                    EmployeeService employeeService = new EmployeeService();
                    
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = employeeService.GetEmployeesByName(dataValue.Trim()).EmployeeID.ToString(); }
                    else
                    { conditionValue = employeeService.GetEmployeesByCode(dataValue.Trim()).EmployeeID.ToString(); }
                    break;
                case "OpeningStockType":
                    LookUpReferenceService lookUpReferenceService2 = new LookUpReferenceService();
                    string titleType2 = ((int)LookUpReference.ModuleType).ToString();
                    conditionValue = lookUpReferenceService2.GetLookUpReferenceByValue(titleType2, dataValue.Trim()).LookupValue.ToString();
                    break;
                case "PriceBatchNo":
                    conditionValue = dataValue.ToString();
                    break;
                case "LocationName":
                    locationService = new LocationService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = locationService.GetLocationsByName(dataValue.Trim()).LocationID.ToString(); }
                    else
                    { conditionValue = locationService.GetLocationsByName(dataValue.Trim()).LocationID.ToString(); }
                    break;
                case "PaymentID":
                    PayTypeService payTypeService = new PayTypeService();
                    conditionValue = payTypeService.GetPayTypeByName(dataValue.Trim()).PrintDescrip.ToString();
                    break;
                case "BankPosID":
                    BankPosService bankPosService = new BankPosService();
                    conditionValue = bankPosService.GetBankPosByName(dataValue.Trim()).Bank.ToString();
                    break;
                case "CashierID":
                case "UpdatedBy":
                    EmployeeService posEmployeeService = new EmployeeService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = posEmployeeService.GetEmployeesByCode(dataValue.Trim()).EmployeeID.ToString(); }
                    else
                    { conditionValue = posEmployeeService.GetEmployeesByName(dataValue.Trim()).EmployeeName.ToString(); }
                    break;
                case "LoyaltyCustomerID":
                    LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = loyaltyCustomerService.GetLoyaltyCustomerByCode(dataValue.Trim()).CustomerId.ToString(); }
                    else
                    { conditionValue = loyaltyCustomerService.GetLoyaltyCustomerByName(dataValue.Trim()).CustomerName.ToString(); }
                    break;
                case "Brand":
                case "Collar":
                case "Colour":
                case "Country":
                case "Cut":
                case "Embelishment":
                case "Fit":
                case "Heel":
                case "Length":
                case "Material":
                case "Neck":
                case "PatternNo":
                case "ProductFeature":
                case "Shop":
                case "Size":
                case "Sleeve":
                case "Texture":
                    conditionValue = dataValue.ToString();
                    break;

                default:
                    break;
            }

            return conditionValue;
        }


        public void GenearateReferenceSummaryReport(AutoGenerateInfo autoGenerateInfo, DataTable dtReportData, DataTable dtReportConditions, List<Common.ReportDataStruct> reportDataStructList, List<Common.ReportDataStruct> groupByStructList)
        {
            FrmReportViewer reportViewer = new FrmReportViewer();
            ResRptReferenceDetailTemplate comRptReferenceDetailTemplate = new ResRptReferenceDetailTemplate();
            Cursor.Current = Cursors.WaitCursor;

            DataTable dtArrangedReportData = new DataTable();
            List<Common.ReportDataStruct> selectedReportStructList;
            List<Common.ReportDataStruct> selectedGroupStructList;

            string strFieldName = string.Empty;
            int sr = 1, dc = 12;
            int gr = 0, gp = 1;

            switch (autoGenerateInfo.FormName)
            {
                #region BillingLocation
                case "FrmBillingLocation":
                    #region Set Values for report header Fields
                    strFieldName = string.Empty;
                    sr = 1; dc = 12;

                    foreach (var item in reportDataStructList)
                    {
                        if (dtReportData.Columns.Contains(item.ReportField.Trim()))
                        {
                            if (item.ReportDataType.Equals(typeof(string)))
                            {
                                strFieldName = "st" + sr;
                                if (GetSelectedReportDataStruct(groupByStructList, item.ReportFieldName.Trim()).IsResultGroupBy)
                                {
                                    comRptReferenceDetailTemplate.DataDefinition.FormulaFields[strFieldName].Text = "''";
                                    groupingFields = string.IsNullOrEmpty(groupingFields) ? (item.ReportFieldName.Trim()) : (groupingFields + ", " + item.ReportFieldName.Trim());
                                }
                                else
                                { comRptReferenceDetailTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'"; }
                                sr++;
                            }

                            //if (item.ReportDataType.Equals(typeof(decimal)))
                            //{
                            //    strFieldName = "st" + dc;
                            //    comRptReferenceDetailTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                            //    dc++;
                            //}
                        }
                    }

                    #endregion

                    dtArrangedReportData = dtReportData.Copy();
                    dtArrangedReportData = SetReportDataTableHeadersForReport(dtArrangedReportData);

                    comRptReferenceDetailTemplate.SetDataSource(dtArrangedReportData);

                    //comRptReferenceDetailTemplate.SetDataSource(dtReportData);
                    comRptReferenceDetailTemplate.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
                    comRptReferenceDetailTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText + " List";
                    comRptReferenceDetailTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    comRptReferenceDetailTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    comRptReferenceDetailTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    comRptReferenceDetailTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    comRptReferenceDetailTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                    ///////////////////////////////////////////////////////////////////////////
                    // Use some other way to add values into formula fields DateFrom and  DateTo ()
                    //goReport.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFrom.Value.ToShortDateString() + "'";
                    //goReport.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpTo.Value.ToShortDateString() + "'";
                    ///////////////////////////////////////////////////////////////////////////
                    //cryRptReportTemplate.DataDefinition.FormulaFields["ValueFrom"].Text = "'" + 01000045128 + "'";
                    //cryRptReportTemplate.DataDefinition.FormulaFields["ValueTo"].Text = "'" + 01000045158 + "'";

                    //string strFieldName = string.Empty;
                    #region Set Header - old
                    //for (int i = 0; i < reportDataStructList.Count; i++)
                    //{
                    //    if (reportDataStructList[i].IsSelectionField.Equals(true))
                    //    {
                    //        strFieldName = "st" + (i + 1);
                    //        if (reportDataStructList[i].ReportDataType.Equals(typeof(string)))
                    //        {
                    //            comRptReferenceDetailTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'";
                    //        }

                    //        if (reportDataStructList[i].ReportDataType.Equals(typeof(decimal)))
                    //        {
                    //            strFieldName = "st" + (12 - i);
                    //            comRptReferenceDetailTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'";
                    //        }
                    //    }
                    //}
                    #endregion

                    #region Group By - old

                    //for (int i = 0; i <= 3; i++)
                    //{
                    //    comRptReferenceDetailTemplate.SetParameterValue(i, "");

                    //    if (groupByStructList.Count > i)
                    //    {
                    //        if (groupByStructList[i].ReportField.Trim() != string.Empty && groupByStructList[i].IsResultGroupBy == true)
                    //        {
                    //            string strGroup = groupByStructList[i].ReportField.ToString();
                    //            comRptReferenceDetailTemplate.SetParameterValue(i, groupByStructList[i].ReportField.Trim());
                    //        }
                    //        else
                    //        {comRptReferenceDetailTemplate.SetParameterValue(i, "");}
                    //    }
                    //    //{ comRptReferenceDetailTemplate.SetParameterValue(i, ""); }
                    //}
                    #endregion

                    #region Group By
                    selectedReportStructList = reportDataStructList.Where(c => c.IsSelectionField.Equals(true)).ToList();
                    selectedGroupStructList = groupByStructList.Where(c => c.IsResultGroupBy.Equals(true)).ToList();

                    gr = 0; gp = 1;
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        // Set report group field values
                        for (int i = 0; i < selectedReportStructList.Count(); i++)
                        {
                            if (gr < comRptReferenceDetailTemplate.DataDefinition.Groups.Count)
                            {
                                if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                {
                                    comRptReferenceDetailTemplate.DataDefinition.Groups[gr].ConditionField = comRptReferenceDetailTemplate.Database.Tables[0].Fields[string.Concat("FieldString", (i + 1).ToString())];
                                    gr++;
                                }
                            }
                        }

                        // Set parameter field values
                        for (int i = 0; i < selectedReportStructList.Count(); i++)
                        {
                            if (gp - 1 < comRptReferenceDetailTemplate.DataDefinition.Groups.Count)
                            {
                                if (comRptReferenceDetailTemplate.ParameterFields[gp - 1].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                                {
                                    if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                    {
                                        comRptReferenceDetailTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), true);
                                        gp++;
                                    }
                                    else
                                    {
                                        comRptReferenceDetailTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), false);
                                    }
                                }
                            }
                        }

                        for (int i = gp; i < comRptReferenceDetailTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (comRptReferenceDetailTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                comRptReferenceDetailTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    else
                    {
                        // Set parameter field values
                        for (int i = 0; i < comRptReferenceDetailTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (comRptReferenceDetailTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                comRptReferenceDetailTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    #endregion
                    reportViewer.crRptViewer.ReportSource = comRptReferenceDetailTemplate;
                    break;
                #endregion
                default:
                    break;
            }

            reportViewer.WindowState = FormWindowState.Maximized;
            reportViewer.Show();
            Cursor.Current = Cursors.Default;
        }

        private Common.ReportDataStruct GetSelectedReportDataStruct(List<Common.ReportDataStruct> reportDatStructList, string selectedRepoertFieldName)
        {
            Common.ReportDataStruct reportDataStruct = new Common.ReportDataStruct();

            foreach (Common.ReportDataStruct reportDataStructItem in reportDatStructList)
            {
                if (reportDataStructItem.ReportFieldName.Trim().Equals(selectedRepoertFieldName.Trim()))
                {
                    reportDataStruct = reportDataStructItem;
                    return reportDataStruct;
                }
            }

            return reportDataStruct;
        }

    }
    
}
