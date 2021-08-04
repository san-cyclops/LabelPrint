using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using CrystalDecisions.Shared;
using ERP.Domain;
using ERP.Utility;
using System.Collections;
using ERP.Report.Account.Reference.Reports;
using ERP.Report.Account.Transactions.Reports;
using ERP.Report.Com;
using ERP.Service;

namespace ERP.Report.Account
{
    public class AccReportGenerator
    {
        //public FrmReprotGenerator frmReprotGenerator { get; set; }D:\2015-03-04 ERP\ERP\ERP\ERP.Report\Account\AccReportGenerator.cs

        string strFieldName = string.Empty;
        string groupingFields = string.Empty;
        /// <summary>
        /// Generate Reference Report 
        /// </summary>
        /// <param name="autoGenerateInfo"></param>
        /// <param name="documentNo"></param>
        /// <param name="isOrg"></param>
        public void GenearateReferenceReport(AutoGenerateInfo autoGenerateInfo, string documentNo, bool isOrg)
        {
            FrmReportViewer reportViewer = new FrmReportViewer();
            Cursor.Current = Cursors.WaitCursor;
            DataTable reportData = new DataTable();

            //InvRptColumn5Template invRptColumn5Template = new InvRptColumn5Template();
            string departmentText = "", categoryText = "", subCategoryText = "", subCategory2Text = "";

            string[] stringField = new string[] { };

            switch (autoGenerateInfo.FormName)
            {
                #region SalesPerson
                case "FrmChartOfAccounts":
                    //AccLedgerAccountService accLedgerAccountService = new AccLedgerAccountService();
                    //reportData = accLedgerAccountService.GetAllActiveAccountsDataTable();

                    //// Set field text
                    //stringField = new string[] { " ", "Sales Person", "Address", "Telephone", "NIC", "Rec.Date", "Type", "Remark" };
                    //invRptReferenceDetailTemplate.SetDataSource(reportData);
                    //// Assign formula and summery field values
                    //invRptReferenceDetailTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    //invRptReferenceDetailTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    //invRptReferenceDetailTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    //invRptReferenceDetailTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    //invRptReferenceDetailTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    //invRptReferenceDetailTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    ////cryComReferenceDetailTemplate.DataDefinition.FormulaFields["isOrg"].Text = "" + isOrg + "";

                    //for (int i = 0; i < stringField.Length; i++)
                    //{
                    //    string st = "st" + (i + 1);
                    //    invRptReferenceDetailTemplate.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringField[i].Trim() + "'";
                    //}
                    //reportViewer.crRptViewer.ReportSource = invRptReferenceDetailTemplate;
                    break;
                #endregion
                default:
                    break;
            }

            reportViewer.WindowState = FormWindowState.Maximized;
            reportViewer.Show();
            Cursor.Current = Cursors.Default;
        }

        public void GenearateReferenceSummaryReport(AutoGenerateInfo autoGenerateInfo, DataTable dtReportData, List<Common.ReportDataStruct> reportDataStructList, List<Common.ReportDataStruct> groupByStructList)
        {
            FrmReportViewer reportViewer = new FrmReportViewer();
            //InvRptColumn5Template invRptColumn5Template = new InvRptColumn5Template();
            Cursor.Current = Cursors.WaitCursor;


            AccRptReferenceDetailTemplate comRptReferenceDetailTemplate = new AccRptReferenceDetailTemplate();
            Cursor.Current = Cursors.WaitCursor;

            DataTable dtArrangedReportData = new DataTable();
            List<Common.ReportDataStruct> selectedReportStructList;
            List<Common.ReportDataStruct> selectedGroupStructList;

            string strFieldName = string.Empty;
            int sr = 1, dc = 12;
            int gr = 0, gp = 1;

            switch (autoGenerateInfo.FormName)
            {
                #region SalesPerson
                case "FrmSalesPerson":
                    //invRptReferenceDetailTemplate.SetDataSource(dtReportData);
                    //invRptReferenceDetailTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText + " Summary";
                    //invRptReferenceDetailTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    //invRptReferenceDetailTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    //invRptReferenceDetailTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    //invRptReferenceDetailTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    //invRptReferenceDetailTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                    /////////////////////////////////////////////////////////////////////////////
                    //// Use some other way to add values into formula fields DateFrom and  DateTo ()
                    ////goReport.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFrom.Value.ToShortDateString() + "'";
                    ////goReport.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpTo.Value.ToShortDateString() + "'";
                    /////////////////////////////////////////////////////////////////////////////
                    ////cryRptReportTemplate.DataDefinition.FormulaFields["ValueFrom"].Text = "'" + 01000045128 + "'";
                    ////cryRptReportTemplate.DataDefinition.FormulaFields["ValueTo"].Text = "'" + 01000045158 + "'";


                    //for (int i = 0; i < reportDataStructList.Count; i++)
                    //{
                    //    strFieldName = "st" + (i + 1);
                    //    if (reportDataStructList[i].ReportDataType.Equals(typeof(string)))
                    //    {
                    //        invRptReferenceDetailTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'";
                    //    }

                    //    if (reportDataStructList[i].ReportDataType.Equals(typeof(decimal)))
                    //    {
                    //        strFieldName = "st" + (12 - i);
                    //        invRptReferenceDetailTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'";
                    //    }
                    //}

                    //#region Group By

                    //for (int i = 0; i <= 3; i++)
                    //{

                    //    if (groupByStructList.Count > i)
                    //    {
                    //        if (groupByStructList[i].ReportField.Trim() != string.Empty && groupByStructList[i].IsResultGroupBy == true)
                    //        {
                    //            string strGroup = groupByStructList[i].ReportField.ToString();
                    //            invRptReferenceDetailTemplate.SetParameterValue(i, groupByStructList[i].ReportField.Trim());
                    //        }
                    //        else
                    //            invRptReferenceDetailTemplate.SetParameterValue(i, "");
                    //    }
                    //    else
                    //    { invRptReferenceDetailTemplate.SetParameterValue(i, ""); }
                    //}
                    //#endregion
                    //reportViewer.crRptViewer.ReportSource = invRptReferenceDetailTemplate;
                    break;
                #endregion

                #region ChartOfAccounts
                case "FrmChartOfAccounts":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptReferenceGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptReferenceGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, new DataTable(), reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
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
                        comRptReferenceDetailTemplate.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportData);
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
                    }


                    break;
                #endregion

                default:
                    break;
            }

            reportViewer.WindowState = FormWindowState.Maximized;
            reportViewer.Show();
            Cursor.Current = Cursors.Default;
        }

        public void GenerateTransactionReport(AutoGenerateInfo autoGenerateInfo, string documentNo, int printStatus, string amountInWords = "", Common.BankDepositMode? bankDepositMode = null)
        {
            FrmReportViewer reportViewer = new FrmReportViewer();
            Cursor.Current = Cursors.WaitCursor;
            DataTable reportData = new DataTable();
            AccRptTransactionTemplate accRptTransactionTemplate = new AccRptTransactionTemplate();
            DataSet dsReportData = new DataSet();
            int documentSataus = 1;
            if (printStatus.Equals(0))
            {
                documentSataus = 0;
            }
            else if (printStatus.Equals(1))
            {
                documentSataus = 1;
            }
            else if (printStatus.Equals(2))
            {
                documentSataus = 1;
            }

            switch (autoGenerateInfo.FormName)
            {

                #region Petty Cash
                case "FrmPettyCashReimbursement":

                    AccRptTransactionTemplatePCBE accRptTransactionTemplatePCR = new AccRptTransactionTemplatePCBE();
                    //AccPettyCashReimbursementService accPettyCashReimbursementService = new AccPettyCashReimbursementService();
                    //reportData = accPettyCashReimbursementService.GetPettyCashReimbursementTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldRI = { "Document", "Date", "Petty Cash", "Remark", "Employee", "Payee", "", "", "Reference No", "Location",
                                            "", "", "Ledger", "", "Date", "Card No", "", "Imprest Amount", "Issued Amount", "", "",
                                            "", "", "", "", "", "", "", "" };

                    accRptTransactionTemplatePCR.SetDataSource(reportData);
                    // Assign formula and summary field values
                    accRptTransactionTemplatePCR.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptTransactionTemplatePCR.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptTransactionTemplatePCR.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptTransactionTemplatePCR.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptTransactionTemplatePCR.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptTransactionTemplatePCR.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptTransactionTemplatePCR.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";

                    for (int i = 0; i < stringFieldRI.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptTransactionTemplatePCR.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldRI[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptTransactionTemplatePCR;
                    break;

                case "FrmPettyCashIOU":
                    //AccPettyCashIOUService accPettyCashIOUService = new AccPettyCashIOUService();
                    //reportData = accPettyCashIOUService.GetPettyCashIOUTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldIOU = { "Document", "Date", "Petty Cash", "Remark", "Employee", "Payee", "", "", "Job/Class", "Reference No", "Location",
                                            "",  "Ledger", "", "", "", "", "", "Value", "", "",
                                            "", "", "", "", "", "", "", "" };

                    AccRptTransactionTemplatePCBE accRptPettyIOUTransactionTemplate = new AccRptTransactionTemplatePCBE();
                    accRptPettyIOUTransactionTemplate.SetDataSource(reportData);
                    // Assign formula and summery field values
                    accRptPettyIOUTransactionTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptPettyIOUTransactionTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptPettyIOUTransactionTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptPettyIOUTransactionTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptPettyIOUTransactionTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptPettyIOUTransactionTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptPettyIOUTransactionTemplate.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";

                    for (int i = 0; i < stringFieldIOU.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptPettyIOUTransactionTemplate.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldIOU[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptPettyIOUTransactionTemplate;
                    break;

                case "FrmPettyCashBillEntry":
                    //AccPettyCashBillService accPettyCashBillService = new AccPettyCashBillService();
                    //reportData = accPettyCashBillService.GetPettyCashBillTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldBill = { "Document", "Date", "Petty Cash", "Remark", "Employee", "Payee", "", "", "Job/Class", "Reference No", "Location",
                                             "", "Ledger", "", "", "", "", "", "Value", "", "",
                                            "", "", "", "", "", "", "", "" };

                    AccRptTransactionTemplatePCBE accRptTransactionTemplatePCBE = new AccRptTransactionTemplatePCBE();
                    accRptTransactionTemplatePCBE.SetDataSource(reportData);
                    // Assign formula and summery field values
                    accRptTransactionTemplatePCBE.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptTransactionTemplatePCBE.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptTransactionTemplatePCBE.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptTransactionTemplatePCBE.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptTransactionTemplatePCBE.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptTransactionTemplatePCBE.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptTransactionTemplatePCBE.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";

                    for (int i = 0; i < stringFieldBill.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptTransactionTemplatePCBE.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldBill[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptTransactionTemplatePCBE;
                    break;

                case "FrmPettyCashPayment":
                    //AccPettyCashPaymentService accPettyCashPaymentService = new AccPettyCashPaymentService();
                    //reportData = accPettyCashPaymentService.GetPettyCashPaymentTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldPettyPMT = { "Document", "Date", "Petty Cash", "Remark", "Employee", "Payee", "", "", "Job/Class", "Reference No", "Location",
                                             "", "Ledger", "", "", "", "", "", "Value", "", "",
                                            "", "", "", "", "", "", "", "" };

                    AccRptTransactionTemplatePCBE accRptPettyPMTTransactionTemplate = new AccRptTransactionTemplatePCBE();
                    accRptPettyPMTTransactionTemplate.SetDataSource(reportData);
                    // Assign formula and summery field values
                    accRptPettyPMTTransactionTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptPettyPMTTransactionTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptPettyPMTTransactionTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptPettyPMTTransactionTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptPettyPMTTransactionTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptPettyPMTTransactionTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptPettyPMTTransactionTemplate.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";

                    for (int i = 0; i < stringFieldPettyPMT.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptPettyPMTTransactionTemplate.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldPettyPMT[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptPettyPMTTransactionTemplate;
                    break;
                #endregion

                #region Journal Entry
                case "FrmJournalEntry":
                    //AccJournalEntryService accJournalEntryService = new AccJournalEntryService();
                    // reportData = accJournalEntryService.GetJournelEntryTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldJE = { "Document", "Date", "", "Remark", "",
                                                "", "", "", "Job/Class", "Reference No", "Manual No",
                                                "Location", "Led.Code", "Led.Name", "Cost Centre",
                                                "Ref Code", "Ref Name", "Debit.Amt", "Credit.Amt", "",
                                                "", "", "Amount", "", "",
                                                "", "", "", "", "" };

                    accRptTransactionTemplate = new AccRptTransactionTemplate();
                    accRptTransactionTemplate.SetDataSource(reportData);
                    // Assign formula and summery field values
                    accRptTransactionTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptTransactionTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptTransactionTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptTransactionTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptTransactionTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptTransactionTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptTransactionTemplate.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                    accRptTransactionTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";
                    accRptTransactionTemplate.DataDefinition.FormulaFields["AmountInWords"].Text = "'" + amountInWords + "'";

                    for (int i = 0; i < stringFieldJE.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptTransactionTemplate.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldJE[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptTransactionTemplate;
                    break;
                #endregion

                #region Bill Entry
                case "FrmBillEntry":
                    AccRptTransactionTemplateBEN accRptTransactionTemplateBEN = new AccRptTransactionTemplateBEN();
                    // AccBillEntryService accBillEntryService = new AccBillEntryService();
                    //reportData = accBillEntryService.GetBillEntryTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldBE = { "Document", "Date", "Reference", "Remark", "Bill Date",
                                                "Due Date", "Received Date", "Reference No", "Job/Class", "Payment Terms", "Manual No",
                                                "Location", "Led.Code", "Led.Name", "Cost Centre",
                                                "Ref Code", "Ref Name", "", "Amount", "",
                                                "", "", "Gross Amt.", "NBT Amt.",
                                                "VAT Amt", "Net Amt.", "", "", "", "" };

                    accRptTransactionTemplateBEN = new AccRptTransactionTemplateBEN();
                    accRptTransactionTemplateBEN.SetDataSource(reportData);
                    // Assign formula and summery field values
                    accRptTransactionTemplateBEN.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptTransactionTemplateBEN.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptTransactionTemplateBEN.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptTransactionTemplateBEN.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptTransactionTemplateBEN.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptTransactionTemplateBEN.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptTransactionTemplateBEN.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                    accRptTransactionTemplateBEN.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    for (int i = 0; i < stringFieldBE.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptTransactionTemplateBEN.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldBE[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptTransactionTemplateBEN;
                    break;
                #endregion

                #region Opening Balance

                case "FrmLedgerOpeningBalances":
                    //AccOpeningBalancesService accOpeningBalancesService = new AccOpeningBalancesService();
                    // reportData = accOpeningBalancesService.GetAccOpenningBalanceTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldOpb = { "Document", "Date", "Reference No", "Remark", "", "", "", "", "", "",
                                            "Cost Centre", "Location", "Acc.Code", "Acc.Name", "",
                                            "", "", "Debit Amt.", "Credit Amt.", "", "", "", "Amount", "", "", "", "", "", "", "" };

                    AccRptTransactionTemplateOPB accRptTransactionTemplateOPB = new AccRptTransactionTemplateOPB();
                    accRptTransactionTemplateOPB.SetDataSource(reportData);
                    // Assign formula and summery field values
                    accRptTransactionTemplateOPB.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptTransactionTemplateOPB.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptTransactionTemplateOPB.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptTransactionTemplateOPB.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptTransactionTemplateOPB.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptTransactionTemplateOPB.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptTransactionTemplateOPB.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                    accRptTransactionTemplateOPB.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    for (int i = 0; i < stringFieldOpb.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptTransactionTemplateOPB.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldOpb[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptTransactionTemplateOPB;

                    break;

                #endregion

                #region Payment

                case "FrmPayment":
                    AccPaymentService accPaymentService = new AccPaymentService();

                    dsReportData = accPaymentService.GetPaymentTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldPay = { "Payee", "", "Address", "", "Reference No", "Remark", "Document No", "Date", "Job/Class", "Manual No", //10
                                                "Cost Centre", "Location", "Ref. Document", "Pay. Mode", "Acccount", "Ref.Account", "Card No", "Cheque Date", //18
                                                 "Set-off Document", "Amount", "", "", "", "Amount", "", "", "", "", "", "" };

                    AccRptTransactionTemplatePAY accRptTransactionTemplatePAY = new AccRptTransactionTemplatePAY();

                    accRptTransactionTemplatePAY.SetDataSource(dsReportData.Tables[0]);
                    accRptTransactionTemplatePAY.Subreports["SetoffDetail"].SetDataSource(dsReportData.Tables[1]);

                    // Assign formula and summary field values
                    accRptTransactionTemplatePAY.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptTransactionTemplatePAY.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptTransactionTemplatePAY.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptTransactionTemplatePAY.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptTransactionTemplatePAY.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptTransactionTemplatePAY.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptTransactionTemplatePAY.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                    accRptTransactionTemplatePAY.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    for (int i = 0; i < stringFieldPay.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptTransactionTemplatePAY.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldPay[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptTransactionTemplatePAY;
                    break;

                #endregion

                #region Loan Entry
                case "FrmLoanEntry":
                    //AccLoanEntryService accLoanEntryService = new AccLoanEntryService();
                    // reportData = accLoanEntryService.GetLoanScheduleDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldLE = { "Document", "Entry Date", "Financial Institute", "Loan Type", "Loan Purpose",
                                                "Location", "Cost center", "Loan period in years", "No of payments per year", "Starting date of loan",
                                                "Loan Amount", "Down Payment", "Rnt No", "Date", "Schedule Amount",
                                                "Capital Amount", "Balance Amount", "Interest Amount", "", "",
                                                "", "", "", "", "",
                                                "", "", "", "", "" };

                    AccRptLoanEntryTemplate accRptLoanEntryTemplate = new AccRptLoanEntryTemplate();
                    accRptLoanEntryTemplate.SetDataSource(reportData);
                    // Assign formula and summery field values
                    accRptLoanEntryTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptLoanEntryTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptLoanEntryTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptLoanEntryTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptLoanEntryTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptLoanEntryTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptLoanEntryTemplate.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                    accRptLoanEntryTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    for (int i = 0; i < stringFieldLE.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptLoanEntryTemplate.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldLE[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptLoanEntryTemplate;
                    break;
                #endregion

                #region Debit Note
                case "FrmDebitNote":
                    // AccDebitNoteService accDebitNoteService = new AccDebitNoteService();
                    //reportData = accDebitNoteService.GetDebitNoteTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldDN = { "Document", "Date", "Manual No", "Remark", "",
                                                "", "", "", "Reference No","Job/Class",
                                                "Cost Centre", "Location", "Led.Code", "Led.Name", "",
                                                "Ref.Code", "Ref.Name", "Debit.Amt", "Credit.Amt", "",
                                                "", "", "", "", "",
                                                "", "", "", "", "" };

                    AccRptTransactionTemplateDN accRptTransactionTemplateDN = new AccRptTransactionTemplateDN();
                    accRptTransactionTemplateDN.SetDataSource(reportData);
                    // Assign formula and summery field values
                    accRptTransactionTemplateDN.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptTransactionTemplateDN.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptTransactionTemplateDN.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptTransactionTemplateDN.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptTransactionTemplateDN.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptTransactionTemplateDN.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptTransactionTemplateDN.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                    accRptTransactionTemplateDN.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    for (int i = 0; i < stringFieldDN.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptTransactionTemplateDN.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldDN[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptTransactionTemplateDN;
                    break;
                #endregion

                #region Credit Note
                case "FrmCreditNote":
                    // AccCreditNoteService accCreditNoteService = new AccCreditNoteService();
                    // reportData = accCreditNoteService.GetCreditNoteTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldCN = { "Document", "Date", "Manual No", "Remark", "",
                                                "", "", "", "Reference No","Job/Class",
                                                "Cost Centre", "Location", "Led.Code", "Led.Name", "",
                                                "Ref.Code", "Ref.Name", "Debit.Amt", "Credit.Amt", "",
                                                "", "", "", "", "",
                                                "", "", "", "", "" };

                    accRptTransactionTemplateDN = new AccRptTransactionTemplateDN();
                    accRptTransactionTemplateDN.SetDataSource(reportData);
                    // Assign formula and summery field values
                    accRptTransactionTemplateDN.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptTransactionTemplateDN.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptTransactionTemplateDN.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptTransactionTemplateDN.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptTransactionTemplateDN.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptTransactionTemplateDN.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptTransactionTemplateDN.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                    accRptTransactionTemplateDN.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    for (int i = 0; i < stringFieldCN.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptTransactionTemplateDN.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldCN[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptTransactionTemplateDN;
                    break;
                #endregion

                #region Receipt

                case "FrmReceipt":
                    AccPaymentService accPaymentServiceReceipt = new AccPaymentService();
                    dsReportData = accPaymentServiceReceipt.GetPaymentTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldRec = { "Customer", "", "Address", "", "Reference No", "Remark", "Document No", "Date", "Job/Class", "Manual No", //10
                                                "Cost Centre", "Location", "Ref. Document", "Pay. Mode", "Acccount", "Ref.Account", "Card No", "Cheque Date", //18
                                                "Set-off Document", "Amount", "", "", "", "Amount", "", "", "", "", "", "" };

                    AccRptTransactionTemplateRecepit cccRptTransactionTemplateRecepit = new AccRptTransactionTemplateRecepit();
                    //cccRptTransactionTemplateRecepit.SetDataSource(reportData);

                    cccRptTransactionTemplateRecepit.SetDataSource(dsReportData.Tables[0]);
                    cccRptTransactionTemplateRecepit.Subreports["SetoffDetail"].SetDataSource(dsReportData.Tables[1]);

                    // Assign formula and summary field values
                    cccRptTransactionTemplateRecepit.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    cccRptTransactionTemplateRecepit.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    cccRptTransactionTemplateRecepit.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    cccRptTransactionTemplateRecepit.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    cccRptTransactionTemplateRecepit.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    cccRptTransactionTemplateRecepit.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    cccRptTransactionTemplateRecepit.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                    cccRptTransactionTemplateRecepit.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    for (int i = 0; i < stringFieldRec.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        cccRptTransactionTemplateRecepit.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldRec[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = cccRptTransactionTemplateRecepit;
                    break;

                #endregion

                #region Bank deposit

                case "FrmBankDeposit":
                    //AccBankDepositService accBankDepositService = new AccBankDepositService();
                    //Common.BankDepositMode bankDepositModeTmp = new Common.BankDepositMode();
                    //bankDepositModeTmp = (Common.BankDepositMode)bankDepositMode;
                    //reportData = accBankDepositService.GetAccBankDepositeTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID, bankDepositModeTmp);

                    if (bankDepositMode.Equals(Common.BankDepositMode.Cheque))
                    {
                        string[] stringFieldBankDep = { "Document", "Date", "Reference No", "Remark", "Bank", "Receivable Acc.", "", "", "", "",
                                                "Cost Centre", "Location", "Cust. Code", "Cust. Name", "Document No",
                                                "Document Date", "Cheque No", "ChequeDate", "Bank", "Barnch", "Amount", "", "", "", "", "", "", "", "", "" };

                        AccRptTransactionTemplateBankDep accRptTransactionTemplateBankDep = new AccRptTransactionTemplateBankDep();
                        accRptTransactionTemplateBankDep.SetDataSource(reportData);
                        // Assign formula and summery field values
                        accRptTransactionTemplateBankDep.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                        accRptTransactionTemplateBankDep.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                        accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                        accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                        accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                        accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                        accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                        accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                        for (int i = 0; i < stringFieldBankDep.Length; i++)
                        {
                            string st = "st" + (i + 1);
                            accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldBankDep[i].Trim() + "'";
                        }
                        reportViewer.crRptViewer.ReportSource = accRptTransactionTemplateBankDep;
                    }

                    if (bankDepositMode.Equals(Common.BankDepositMode.Cash))
                    {
                        string[] stringFieldBankDep = { "Document", "Date", "Reference No", "Remark", "Bank", "Receivable Acc.", "", "", "", "",
                                                "Cost Centre", "Location", "Cust. Code", "Cust. Name", "Document No",
                                                "Document Date", "", "", "", "", "Amount", "", "", "", "", "", "", "", "", "" };

                        AccRptTransactionTemplateBankDep accRptTransactionTemplateBankDep = new AccRptTransactionTemplateBankDep();
                        accRptTransactionTemplateBankDep.SetDataSource(reportData);
                        // Assign formula and summery field values
                        accRptTransactionTemplateBankDep.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                        accRptTransactionTemplateBankDep.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                        accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                        accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                        accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                        accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                        accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                        accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                        for (int i = 0; i < stringFieldBankDep.Length; i++)
                        {
                            string st = "st" + (i + 1);
                            accRptTransactionTemplateBankDep.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldBankDep[i].Trim() + "'";
                        }
                        reportViewer.crRptViewer.ReportSource = accRptTransactionTemplateBankDep;
                    }
                    break;

                #endregion

                #region Bank Reconciliation

                case "FrmAccountsReconciliation":
                    //AccAccountReconciliationService accAccountReconciliationService = new AccAccountReconciliationService();
                    //reportData = accAccountReconciliationService.GetAccBankReconciliationTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldBankRec = { "Document", "Date", "Date From", "Reconcile Date", "Bank Account", "Opening Amt.", "Closing Amt.", "", "", "",
                                            "Cost Centre", "Location", "Date", "Reference No", "Description",
                                            "Cheque No", "Debit", "Credit", "", "", "", "", "", "", "", "", "", "", "", "" };

                    AccRptTransactionTemplateBankRec accRptTransactionTemplateBankRec = new AccRptTransactionTemplateBankRec();
                    accRptTransactionTemplateBankRec.SetDataSource(reportData);
                    // Assign formula and summery field values
                    accRptTransactionTemplateBankRec.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptTransactionTemplateBankRec.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptTransactionTemplateBankRec.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptTransactionTemplateBankRec.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptTransactionTemplateBankRec.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptTransactionTemplateBankRec.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptTransactionTemplateBankRec.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                    accRptTransactionTemplateBankRec.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    for (int i = 0; i < stringFieldBankRec.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptTransactionTemplateBankRec.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldBankRec[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptTransactionTemplateBankRec;

                    break;

                #endregion

                #region Cheque Return

                case "FrmChequeReturn":
                    //AccChequeReturnService accChequeReturnService = new AccChequeReturnService();

                    //reportData = accChequeReturnService.GetAccChequeReturnTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);


                    string[] stringFieldChequeRet = { "Document", "Date", "Reference No", "Remark", "Bank", "", "", "", "", "",
                                            "Cost Centre", "Location", "Ref. Doc. No", "Ref. Doc. Date", "Cheque No",
                                            "Cheque Date", "", "Amount", "", "", "", "", "", "", "", "", "", "", "", "" };

                    AccRptTransactionTemplateChequeRet accRptTransactionTemplateChequeRet = new AccRptTransactionTemplateChequeRet();
                    accRptTransactionTemplateChequeRet.SetDataSource(reportData);
                    // Assign formula and summery field values
                    accRptTransactionTemplateChequeRet.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptTransactionTemplateChequeRet.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptTransactionTemplateChequeRet.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptTransactionTemplateChequeRet.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptTransactionTemplateChequeRet.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptTransactionTemplateChequeRet.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptTransactionTemplateChequeRet.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                    accRptTransactionTemplateChequeRet.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    for (int i = 0; i < stringFieldChequeRet.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptTransactionTemplateChequeRet.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldChequeRet[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptTransactionTemplateChequeRet;

                    break;

                #endregion

                #region Cheque Cancel

                case "FrmChequeCancel":
                    // AccChequeCancelService accChequeCancelService = new AccChequeCancelService();

                    //reportData = accChequeCancelService.GetAccChequeCancelTransactionDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);


                    string[] stringFieldChequeCan = { "Document", "Date", "Reference No", "Remark", "Bank", "", "", "", "", "",
                                            "Cost Centre", "Location", "Ref. Doc. No", "Ref. Doc. Date", "Cheque No",
                                            "Cheque Date", "Amount", "", "", "", "", "", "", "", "", "", "", "", "", "" };

                    AccRptTransactionTemplateChequeRet accRptTransactionTemplateChequeCan = new AccRptTransactionTemplateChequeRet();
                    accRptTransactionTemplateChequeCan.SetDataSource(reportData);
                    // Assign formula and summery field values
                    accRptTransactionTemplateChequeCan.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptTransactionTemplateChequeCan.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptTransactionTemplateChequeCan.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptTransactionTemplateChequeCan.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptTransactionTemplateChequeCan.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptTransactionTemplateChequeCan.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptTransactionTemplateChequeCan.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                    accRptTransactionTemplateChequeCan.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    for (int i = 0; i < stringFieldChequeCan.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptTransactionTemplateChequeCan.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldChequeCan[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptTransactionTemplateChequeCan;

                    break;

                #endregion

                #region Cheque Book Entry
                case "FrmChequeBookEntry":
                    //AccChequeNoEntryService accChequeNoEntryService = new AccChequeNoEntryService();
                    //reportData = accChequeNoEntryService.GetRegisteredChequeDetailsDataTable(documentNo, documentSataus, autoGenerateInfo.DocumentID);

                    string[] stringFieldCBE = { "Ledger Code", "Ledger Name", "", "", "",
                                                "", "", "", "Document No", "Document Date",
                                                "Create User", "", "Cheque No", "", "",
                                                "", "", "", "", "",
                                                "", "", "", "", "",
                                                "", "", "", "", "" };

                    AccRptChequeBookEntryTemplate accRptChequeBookEntryTemplate = new AccRptChequeBookEntryTemplate();
                    accRptChequeBookEntryTemplate.SetDataSource(reportData);
                    // Assign formula and summery field values
                    accRptChequeBookEntryTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptChequeBookEntryTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptChequeBookEntryTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptChequeBookEntryTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptChequeBookEntryTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptChequeBookEntryTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptChequeBookEntryTemplate.DataDefinition.FormulaFields["isOrg"].Text = "" + printStatus + "";
                    accRptChequeBookEntryTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    for (int i = 0; i < stringFieldCBE.Length; i++)
                    {
                        string st = "st" + (i + 1);
                        accRptChequeBookEntryTemplate.DataDefinition.FormulaFields["st" + (i + 1).ToString()].Text = "'" + stringFieldCBE[i].Trim() + "'";
                    }
                    reportViewer.crRptViewer.ReportSource = accRptChequeBookEntryTemplate;
                    break;
                #endregion


                default:
                    break;
            }

            reportViewer.WindowState = FormWindowState.Maximized;
            reportViewer.Show();
            Cursor.Current = Cursors.Default;
        }

        public void GenearateTransactionSummaryReport(AutoGenerateInfo autoGenerateInfo, DataTable dtReportData, DataTable dtReportConditions, List<Common.ReportDataStruct> reportDataStructList, List<Common.ReportDataStruct> groupByStructList, bool viewGroupDetails)
        {
            FrmReportViewer reportViewer = new FrmReportViewer();
            Cursor.Current = Cursors.WaitCursor;
            ReportSources reportSources = new ReportSources();
            ArrayList newSumFieldsIndexesList = new ArrayList();
            DataTable dtArrangedReportData = new DataTable();

            List<Common.ReportDataStruct> selectedReportStructList = null;
            List<Common.ReportDataStruct> selectedGroupStructList = null;

            string group1, group2, group3, group4;
            int yx = 0;

            int sr = 0;
            int dc = 0;
            int gr = 0, gp = 1;
            switch (autoGenerateInfo.FormName)
            {
                #region accounts transactions

                #region Petty Cash Reimbursement
                case "FrmPettyCashReimbursement":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    #region Deleted
                    //AccRptTransactionSummaryTemplateLandscape accRptTransactionSummaryTemplateLandscapeReimb = new AccRptTransactionSummaryTemplateLandscape();

                    //accRptTransactionSummaryTemplateLandscapeReimb.SetDataSource(dtReportData);
                    //accRptTransactionSummaryTemplateLandscapeReimb.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);

                    //accRptTransactionSummaryTemplateLandscapeReimb.SummaryInfo.ReportTitle = autoGenerateInfo.FormText + " Summary";
                    //accRptTransactionSummaryTemplateLandscapeReimb.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    //accRptTransactionSummaryTemplateLandscapeReimb.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    //accRptTransactionSummaryTemplateLandscapeReimb.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    //accRptTransactionSummaryTemplateLandscapeReimb.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    //accRptTransactionSummaryTemplateLandscapeReimb.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    //accRptTransactionSummaryTemplateLandscapeReimb.SetParameterValue("prmViewGroupDetails", viewGroupDetails);

                    //strFieldName = string.Empty;
                    //int srpos = 0;
                    //for (int i = 0; i < reportDataStructList.Count; i++)
                    //{
                    //    strFieldName = "st" + (i + 1);
                    //    if (reportDataStructList[i].ReportDataType.Equals(typeof(string)))
                    //    {
                    //        if (reportDataStructList[i].IsSelectionField)
                    //        { accRptTransactionSummaryTemplateLandscapeReimb.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'"; }
                    //        else
                    //        { accRptTransactionSummaryTemplateLandscapeReimb.DataDefinition.FormulaFields[strFieldName].Text = "''"; }
                    //    }

                    //    if (reportDataStructList[i].ReportDataType.Equals(typeof(decimal)))
                    //    {
                    //        strFieldName = "st" + (8 + srpos);
                    //        if (reportDataStructList[i].IsSelectionField)
                    //        { accRptTransactionSummaryTemplateLandscapeReimb.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'"; }
                    //        else
                    //        { accRptTransactionSummaryTemplateLandscapeReimb.DataDefinition.FormulaFields[strFieldName].Text = "''"; }
                    //        srpos++;
                    //    }
                    //}

                    //#region Group By

                    //for (int i = 0; i <= 4; i++)
                    //{
                    //    if (accRptTransactionSummaryTemplateLandscapeReimb.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.StringParameter))
                    //    {
                    //        accRptTransactionSummaryTemplateLandscapeReimb.SetParameterValue(i, "");

                    //        if (groupByStructList.Count > i)
                    //        {
                    //            if (groupByStructList[i].ReportField.Trim() != string.Empty && groupByStructList[i].IsResultGroupBy == true)
                    //            {
                    //                accRptTransactionSummaryTemplateLandscapeReimb.SetParameterValue(i, groupByStructList[i].ReportField.Trim());
                    //            }
                    //            else
                    //            {
                    //                accRptTransactionSummaryTemplateLandscapeReimb.SetParameterValue(i, "");
                    //            }
                    //        }
                    //    }
                    //}
                    //#endregion
                    //reportViewer.crRptViewer.ReportSource = accRptTransactionSummaryTemplateLandscapeReimb;

                    #endregion
                    break;
                #endregion

                #region Petty Cash IOU
                case "FrmPettyCashIOU":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    #region Deleted
                    //AccRptTransactionSummaryTemplateLandscape accRptTransactionSummaryTemplateLandscapeIOU = new AccRptTransactionSummaryTemplateLandscape();

                    //accRptTransactionSummaryTemplateLandscapeIOU.SetDataSource(dtReportData);
                    //accRptTransactionSummaryTemplateLandscapeIOU.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);

                    //accRptTransactionSummaryTemplateLandscapeIOU.SummaryInfo.ReportTitle = autoGenerateInfo.FormText + " Summary";
                    //accRptTransactionSummaryTemplateLandscapeIOU.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    //accRptTransactionSummaryTemplateLandscapeIOU.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    //accRptTransactionSummaryTemplateLandscapeIOU.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    //accRptTransactionSummaryTemplateLandscapeIOU.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    //accRptTransactionSummaryTemplateLandscapeIOU.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    //accRptTransactionSummaryTemplateLandscapeIOU.SetParameterValue("prmViewGroupDetails", viewGroupDetails);

                    //strFieldName = string.Empty;
                    //int srIOUs = 0;
                    //for (int i = 0; i < reportDataStructList.Count; i++)
                    //{
                    //    strFieldName = "st" + (i + 1);
                    //    if (reportDataStructList[i].ReportDataType.Equals(typeof(string)))
                    //    {
                    //        if (reportDataStructList[i].IsSelectionField)
                    //        { accRptTransactionSummaryTemplateLandscapeIOU.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'"; }
                    //        else
                    //        { accRptTransactionSummaryTemplateLandscapeIOU.DataDefinition.FormulaFields[strFieldName].Text = "''"; }
                    //    }

                    //    if (reportDataStructList[i].ReportDataType.Equals(typeof(decimal)))
                    //    {
                    //        strFieldName = "st" + (8 + srIOUs);
                    //        if (reportDataStructList[i].IsSelectionField)
                    //        { accRptTransactionSummaryTemplateLandscapeIOU.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'"; }
                    //        else
                    //        { accRptTransactionSummaryTemplateLandscapeIOU.DataDefinition.FormulaFields[strFieldName].Text = "''"; }
                    //        srIOUs++;
                    //    }
                    //}

                    //#region Group By

                    //for (int i = 0; i <= 4; i++)
                    //{
                    //    if (accRptTransactionSummaryTemplateLandscapeIOU.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.StringParameter))
                    //    {
                    //        accRptTransactionSummaryTemplateLandscapeIOU.SetParameterValue(i, "");

                    //        if (groupByStructList.Count > i)
                    //        {
                    //            if (groupByStructList[i].ReportField.Trim() != string.Empty && groupByStructList[i].IsResultGroupBy == true)
                    //            {
                    //                accRptTransactionSummaryTemplateLandscapeIOU.SetParameterValue(i, groupByStructList[i].ReportField.Trim());
                    //            }
                    //            else
                    //            {
                    //                accRptTransactionSummaryTemplateLandscapeIOU.SetParameterValue(i, "");
                    //            }
                    //        }
                    //    }
                    //}
                    //#endregion
                    //reportViewer.crRptViewer.ReportSource = accRptTransactionSummaryTemplateLandscapeIOU;
                    #endregion

                    break;
                #endregion

                #region Petty Cash Bill Entry
                case "FrmPettyCashBillEntry":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    #region Deleted
                    //AccRptTransactionSummaryTemplateLandscape accRptTransactionSummaryTemplateLandscapeBill = new AccRptTransactionSummaryTemplateLandscape();

                    //accRptTransactionSummaryTemplateLandscapeBill.SetDataSource(dtReportData);
                    //accRptTransactionSummaryTemplateLandscapeBill.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);

                    //accRptTransactionSummaryTemplateLandscapeBill.SummaryInfo.ReportTitle = autoGenerateInfo.FormText + " Summary";
                    //accRptTransactionSummaryTemplateLandscapeBill.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    //accRptTransactionSummaryTemplateLandscapeBill.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    //accRptTransactionSummaryTemplateLandscapeBill.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    //accRptTransactionSummaryTemplateLandscapeBill.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    //accRptTransactionSummaryTemplateLandscapeBill.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    //accRptTransactionSummaryTemplateLandscapeBill.SetParameterValue("prmViewGroupDetails", viewGroupDetails);

                    //strFieldName = string.Empty;
                    //int srBills = 0;
                    //for (int i = 0; i < reportDataStructList.Count; i++)
                    //{
                    //    strFieldName = "st" + (i + 1);
                    //    if (reportDataStructList[i].ReportDataType.Equals(typeof(string)))
                    //    {
                    //        if (reportDataStructList[i].IsSelectionField)
                    //        { accRptTransactionSummaryTemplateLandscapeBill.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'"; }
                    //        else
                    //        { accRptTransactionSummaryTemplateLandscapeBill.DataDefinition.FormulaFields[strFieldName].Text = "''"; }
                    //    }

                    //    if (reportDataStructList[i].ReportDataType.Equals(typeof(decimal)))
                    //    {
                    //        strFieldName = "st" + (8 + srBills);
                    //        if (reportDataStructList[i].IsSelectionField)
                    //        { accRptTransactionSummaryTemplateLandscapeBill.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'"; }
                    //        else
                    //        { accRptTransactionSummaryTemplateLandscapeBill.DataDefinition.FormulaFields[strFieldName].Text = "''"; }
                    //        srBills++;
                    //    }
                    //}

                    //#region Group By

                    //for (int i = 0; i <= 4; i++)
                    //{
                    //    if (accRptTransactionSummaryTemplateLandscapeBill.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.StringParameter))
                    //    {
                    //        accRptTransactionSummaryTemplateLandscapeBill.SetParameterValue(i, "");

                    //        if (groupByStructList.Count > i)
                    //        {
                    //            if (groupByStructList[i].ReportField.Trim() != string.Empty && groupByStructList[i].IsResultGroupBy == true)
                    //            {
                    //                accRptTransactionSummaryTemplateLandscapeBill.SetParameterValue(i, groupByStructList[i].ReportField.Trim());
                    //            }
                    //            else
                    //            {
                    //                accRptTransactionSummaryTemplateLandscapeBill.SetParameterValue(i, "");
                    //            }
                    //        }
                    //    }
                    //}
                    //#endregion
                    //reportViewer.crRptViewer.ReportSource = accRptTransactionSummaryTemplateLandscapeBill;

                    #endregion
                    break;
                #endregion

                #region Petty Cash Payment
                case "FrmPettyCashPayment":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    #region Deleted
                    //AccRptTransactionSummaryTemplateLandscape accRptTransactionSummaryTemplateLandscapePymt = new AccRptTransactionSummaryTemplateLandscape();

                    //accRptTransactionSummaryTemplateLandscapePymt.SetDataSource(dtReportData);
                    //accRptTransactionSummaryTemplateLandscapePymt.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);

                    //accRptTransactionSummaryTemplateLandscapePymt.SummaryInfo.ReportTitle = autoGenerateInfo.FormText + " Summary";
                    //accRptTransactionSummaryTemplateLandscapePymt.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    //accRptTransactionSummaryTemplateLandscapePymt.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    //accRptTransactionSummaryTemplateLandscapePymt.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    //accRptTransactionSummaryTemplateLandscapePymt.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    //accRptTransactionSummaryTemplateLandscapePymt.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    //accRptTransactionSummaryTemplateLandscapePymt.SetParameterValue("prmViewGroupDetails", viewGroupDetails);

                    //strFieldName = string.Empty;
                    //int srPymts = 0;
                    //for (int i = 0; i < reportDataStructList.Count; i++)
                    //{
                    //    strFieldName = "st" + (i + 1);
                    //    if (reportDataStructList[i].ReportDataType.Equals(typeof(string)))
                    //    {
                    //        if (reportDataStructList[i].IsSelectionField)
                    //        { accRptTransactionSummaryTemplateLandscapePymt.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'"; }
                    //        else
                    //        { accRptTransactionSummaryTemplateLandscapePymt.DataDefinition.FormulaFields[strFieldName].Text = "''"; }
                    //    }

                    //    if (reportDataStructList[i].ReportDataType.Equals(typeof(decimal)))
                    //    {
                    //        strFieldName = "st" + (8 + srPymts);
                    //        if (reportDataStructList[i].IsSelectionField)
                    //        { accRptTransactionSummaryTemplateLandscapePymt.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'"; }
                    //        else
                    //        { accRptTransactionSummaryTemplateLandscapePymt.DataDefinition.FormulaFields[strFieldName].Text = "''"; }
                    //        srPymts++;
                    //    }
                    //}

                    //#region Group By

                    //for (int i = 0; i <= 4; i++)
                    //{
                    //    if (accRptTransactionSummaryTemplateLandscapePymt.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.StringParameter))
                    //    {
                    //        accRptTransactionSummaryTemplateLandscapePymt.SetParameterValue(i, "");

                    //        if (groupByStructList.Count > i)
                    //        {
                    //            if (groupByStructList[i].ReportField.Trim() != string.Empty && groupByStructList[i].IsResultGroupBy == true)
                    //            {
                    //                accRptTransactionSummaryTemplateLandscapePymt.SetParameterValue(i, groupByStructList[i].ReportField.Trim());
                    //            }
                    //            else
                    //            {
                    //                accRptTransactionSummaryTemplateLandscapePymt.SetParameterValue(i, "");
                    //            }
                    //        }
                    //    }
                    //}
                    //#endregion
                    //reportViewer.crRptViewer.ReportSource = accRptTransactionSummaryTemplateLandscapePymt;
                    #endregion

                    break;
                #endregion

                #region Journal Entry
                case "FrmJournalEntry":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    break;
                #endregion

                #region Bill Entry
                case "FrmBillEntry":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    break;
                #endregion

                #region Credit Note
                case "FrmCreditNote":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    break;
                #endregion

                #region Debit Note
                case "FrmDebitNote":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    break;
                #endregion

                #region Payment
                case "FrmPayment":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    break;

                #endregion

                #region Receipt
                case "FrmReceipt":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    break;

                #endregion

                #region Ledger Opening Balances
                case "FrmLedgerOpeningBalances":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    break;
                #endregion

                #region Bank Deposit
                case "FrmBankDeposit":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    break;
                #endregion

                #region Cheque Return
                case "FrmChequeReturn":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    break;
                #endregion

                #region Cheque Cancel
                case "FrmChequeCancel":
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        AccRptGroupedDetailsTemplate accRptGroupedDetailsTemplate = new AccRptGroupedDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewGroupedReport(accRptGroupedDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    else
                    {
                        AccRptDetailsTemplate accRptDetailsTemplate = new AccRptDetailsTemplate();
                        reportViewer.crRptViewer.ReportSource = ViewUnGroupedReport(accRptDetailsTemplate, dtReportData, dtReportConditions, reportDataStructList, autoGenerateInfo);
                    }
                    break;
                #endregion


                #endregion

                #region Account reports

                #region Petty Cash Report
                #region RptPettyCash
                case "RptPettyCash": //RptPettyCashExpenses
                    AccRptTransactionSummaryTemplate accountPettyCashExpensesTemplate = new AccRptTransactionSummaryTemplate();

                    accountPettyCashExpensesTemplate.SetDataSource(dtReportData);
                    accountPettyCashExpensesTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText + " Summary";
                    accountPettyCashExpensesTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accountPettyCashExpensesTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accountPettyCashExpensesTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accountPettyCashExpensesTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accountPettyCashExpensesTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                    ///////////////////////////////////////////////////////////////////////////
                    // Use some other way to add values into formula fields DateFrom and  DateTo ()
                    //goReport.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFrom.Value.ToShortDateString() + "'";
                    //goReport.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpTo.Value.ToShortDateString() + "'";
                    ///////////////////////////////////////////////////////////////////////////
                    //cryRptReportTemplate.DataDefinition.FormulaFields["ValueFrom"].Text = "'" + 01000045128 + "'";
                    //cryRptReportTemplate.DataDefinition.FormulaFields["ValueTo"].Text = "'" + 01000045158 + "'";

                    strFieldName = string.Empty;
                    yx = 0;
                    for (int i = 0; i < reportDataStructList.Count; i++)
                    {
                        strFieldName = "st" + (i + 1);
                        if (reportDataStructList[i].ReportDataType.Equals(typeof(string)))
                        {
                            accountPettyCashExpensesTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'";
                        }

                        if (reportDataStructList[i].ReportDataType.Equals(typeof(decimal)))
                        {
                            strFieldName = "st" + (9 + yx);
                            accountPettyCashExpensesTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'";
                            yx++;
                        }
                    }

                    #region Group By

                    for (int i = 0; i <= 7; i++)
                    {
                        if (groupByStructList.Count > i)
                        {
                            if (groupByStructList[i].ReportField.Trim() != string.Empty && groupByStructList[i].IsResultGroupBy == true)
                            {
                                string strGroup = groupByStructList[i].ReportField.ToString();
                                accountPettyCashExpensesTemplate.SetParameterValue(i, groupByStructList[i].ReportField.Trim());
                            }
                            else
                            {
                                accountPettyCashExpensesTemplate.SetParameterValue(i, "");
                            }
                        }
                        else
                        {
                            accountPettyCashExpensesTemplate.SetParameterValue(i, "");
                        }
                    }
                    #endregion
                    reportViewer.crRptViewer.ReportSource = accountPettyCashExpensesTemplate;
                    break;
                #endregion

                #region Petty cash Register
                case "RptPettyCashRegister":
                    AccRptLedgerListTemplate accRptPettyLedgerListTemplate = new AccRptLedgerListTemplate();

                    #region Set Values for report header fields
                    strFieldName = string.Empty;
                    sr = 1;
                    dc = 11;

                    foreach (var item in reportDataStructList)
                    {
                        if (dtReportData.Columns.Contains(item.ReportField.Trim()))
                        {

                            if (item.ReportDataType.Equals(typeof(string)))
                            {
                                strFieldName = "st" + sr;
                                accRptPettyLedgerListTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                sr++;
                            }

                            if (item.ReportDataType.Equals(typeof(decimal)))
                            {
                                strFieldName = "st" + dc;
                                accRptPettyLedgerListTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                dc++;
                            }
                        }
                    }

                    #endregion

                    // Re arrange data table header columns for report
                    dtArrangedReportData = dtReportData.Copy();
                    dtReportData = null;
                    reportSources = new ReportSources();
                    reportSources = SetReportSourcesForReport(dtArrangedReportData, reportDataStructList);
                    dtArrangedReportData = reportSources.reportData;
                    newSumFieldsIndexesList = new ArrayList();
                    newSumFieldsIndexesList = reportSources.newSumFieldsIndexes;

                    accRptPettyLedgerListTemplate.SetDataSource(dtArrangedReportData);
                    accRptPettyLedgerListTemplate.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
                    accRptPettyLedgerListTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptPettyLedgerListTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptPettyLedgerListTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptPettyLedgerListTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptPettyLedgerListTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptPettyLedgerListTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptPettyLedgerListTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    #region Group By

                    //// Set report group field values
                    //for (int i = 0; i < dtArrangedReportData.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FieldString")).Count(); i++)
                    //{
                    //    if (i < accRptPettyLedgerListTemplate.DataDefinition.Groups.Count)
                    //    {
                    //        accRptPettyLedgerListTemplate.DataDefinition.Groups[i].ConditionField = accRptPettyLedgerListTemplate.Database.Tables[0].Fields[string.Concat("FieldString", (i + 1).ToString())];
                    //    }
                    //}

                    //// Set parameter select field values
                    //for (int i = 0; i < accRptPettyLedgerListTemplate.DataDefinition.Groups.Count; i++)
                    //{
                    //    if (accRptPettyLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                    //    {
                    //        if (i < dtArrangedReportData.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FieldString")).Count())
                    //        {
                    //            accRptPettyLedgerListTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), true);
                    //        }
                    //        else
                    //        {
                    //            accRptPettyLedgerListTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                    //        }
                    //    }
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
                            if (gr < accRptPettyLedgerListTemplate.DataDefinition.Groups.Count)
                            {
                                if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                {
                                    accRptPettyLedgerListTemplate.DataDefinition.Groups[gr].ConditionField = accRptPettyLedgerListTemplate.Database.Tables[0].Fields[string.Concat("FieldString", (i + 1).ToString())];
                                    gr++;
                                }
                            }
                        }

                        // Set parameter field values
                        for (int i = 0; i < selectedReportStructList.Count(); i++)
                        {
                            if (gp - 1 < accRptPettyLedgerListTemplate.DataDefinition.Groups.Count)
                            {
                                if (accRptPettyLedgerListTemplate.ParameterFields[gp - 1].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                                {
                                    if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                    {
                                        accRptPettyLedgerListTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), true);
                                        gp++;
                                    }
                                    else
                                    {
                                        accRptPettyLedgerListTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), false);
                                    }
                                }
                            }
                        }

                        for (int i = gp; i < accRptPettyLedgerListTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptPettyLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                accRptPettyLedgerListTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    else
                    {
                        // Set parameter field values
                        for (int i = 0; i < accRptPettyLedgerListTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptPettyLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                accRptPettyLedgerListTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    #endregion

                    // Set parameter sum fields
                    //for (int i = 0; i < accRptPettyLedgerListTemplate.ParameterFields.Count; i++)
                    //{
                    //    if (accRptPettyLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter) && newSumFieldsIndexesList.Contains(i + 1) && accRptPettyLedgerListTemplate.ParameterFields[i].Name.StartsWith("prmSumFieldDecimal"))
                    //    {
                    //        accRptPettyLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), true);
                    //    }
                    //    else
                    //    {
                    //        accRptPettyLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), false);
                    //    }
                    //}

                    reportViewer.crRptViewer.ReportSource = accRptPettyLedgerListTemplate;
                    break;
                #endregion
                #endregion

                #region Receipts Report
                case "RptReceiptsRegister":
                    AccRptReceiptTransactionSummaryTemplateLandscape accRptReceiptsTemplateReceiptsRegister = new AccRptReceiptTransactionSummaryTemplateLandscape();

                    #region Set Values for report header Fields
                    strFieldName = string.Empty;
                    sr = 1;
                    dc = 12;

                    foreach (var item in reportDataStructList)
                    {
                        if (dtReportData.Columns.Contains(item.ReportField.Trim()))
                        {
                            if (item.ReportDataType.Equals(typeof(string)) && sr < 12)
                            {
                                strFieldName = "st" + sr;
                                accRptReceiptsTemplateReceiptsRegister.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                sr++;
                            }

                            if (item.ReportDataType.Equals(typeof(decimal)))
                            {
                                strFieldName = "st" + dc;
                                accRptReceiptsTemplateReceiptsRegister.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                dc++;
                            }
                        }
                    }

                    #endregion

                    dtArrangedReportData = dtReportData.Copy();
                    dtArrangedReportData = SetReportDataTableHeadersForReport(dtArrangedReportData);

                    accRptReceiptsTemplateReceiptsRegister.SetDataSource(dtArrangedReportData);

                    //accRptReceiptsTemplateReceiptsRegister.SetDataSource(dtReportData);
                    accRptReceiptsTemplateReceiptsRegister.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);

                    accRptReceiptsTemplateReceiptsRegister.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptReceiptsTemplateReceiptsRegister.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptReceiptsTemplateReceiptsRegister.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptReceiptsTemplateReceiptsRegister.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptReceiptsTemplateReceiptsRegister.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptReceiptsTemplateReceiptsRegister.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptReceiptsTemplateReceiptsRegister.SetParameterValue("prmViewGroupDetails", viewGroupDetails);

                    //strFieldName = string.Empty;
                    //int sr = 0;
                    //for (int i = 0; i < reportDataStructList.Count; i++)
                    //{
                    //    strFieldName = "st" + (i + 1);
                    //    if (reportDataStructList[i].ReportDataType.Equals(typeof(string)))
                    //    {
                    //        if (reportDataStructList[i].IsSelectionField)
                    //        { accRptReceiptsTemplateReceiptsRegister.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'"; }
                    //        else
                    //        { accRptReceiptsTemplateReceiptsRegister.DataDefinition.FormulaFields[strFieldName].Text = "''"; }
                    //    }

                    //    if (reportDataStructList[i].ReportDataType.Equals(typeof(decimal)))
                    //    {
                    //        strFieldName = "st" + (12 + sr);
                    //        if (reportDataStructList[i].IsSelectionField)
                    //        { accRptReceiptsTemplateReceiptsRegister.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStructList[i].ReportFieldName.Trim() + "'"; }
                    //        else
                    //        { accRptReceiptsTemplateReceiptsRegister.DataDefinition.FormulaFields[strFieldName].Text = "''"; }
                    //        sr++;
                    //    }
                    //}

                    #region Group By Old

                    //for (int i = 0; i <= 9; i++)
                    //{
                    //    accRptReceiptsTemplateReceiptsRegister.SetParameterValue(i, "");

                    //    if (groupByStructList.Count > i)
                    //    {
                    //        if (groupByStructList[i].ReportField.Trim() != string.Empty && groupByStructList[i].IsResultGroupBy == true)
                    //        {
                    //            accRptReceiptsTemplateReceiptsRegister.SetParameterValue(i, groupByStructList[i].ReportField.Trim());
                    //        }
                    //        else
                    //        {
                    //            accRptReceiptsTemplateReceiptsRegister.SetParameterValue(i, "");
                    //        }
                    //    }
                    //}
                    #endregion

                    #region Group By

                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        // Set report group field values
                        for (int i = 0; i < dtArrangedReportData.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FieldString")).Count(); i++)
                        {
                            if (i < accRptReceiptsTemplateReceiptsRegister.DataDefinition.Groups.Count)
                            {
                                accRptReceiptsTemplateReceiptsRegister.DataDefinition.Groups[i].ConditionField = accRptReceiptsTemplateReceiptsRegister.Database.Tables[0].Fields[string.Concat("FieldString", (i + 1).ToString())]; //[string.Concat("FieldString", groupStrFieldCount)];
                            }
                        }

                        // Set parameter field values
                        for (int i = 0; i < accRptReceiptsTemplateReceiptsRegister.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptReceiptsTemplateReceiptsRegister.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                if (i < dtArrangedReportData.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FieldString")).Count())
                                {
                                    accRptReceiptsTemplateReceiptsRegister.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), true);
                                }
                                else
                                {
                                    accRptReceiptsTemplateReceiptsRegister.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                                }
                            }
                        }
                    }
                    else
                    {
                        // Set parameter field values
                        for (int i = 0; i < accRptReceiptsTemplateReceiptsRegister.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptReceiptsTemplateReceiptsRegister.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                accRptReceiptsTemplateReceiptsRegister.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    #endregion

                    reportViewer.crRptViewer.ReportSource = accRptReceiptsTemplateReceiptsRegister;
                    break;
                #endregion

                #region Ledger Detail

                case "RptLedgerDetail":

                    AccRptLedgerListTemplate accRptLedgerListTemplate = new AccRptLedgerListTemplate();

                    #region Set Values for report header fields
                    strFieldName = string.Empty;
                    sr = 1;
                    dc = 11;

                    foreach (var item in reportDataStructList)
                    {
                        if (dtReportData.Columns.Contains(item.ReportField.Trim()))
                        {

                            if (item.ReportDataType.Equals(typeof(string)))
                            {
                                strFieldName = "st" + sr;
                                accRptLedgerListTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                sr++;
                            }

                            if (item.ReportDataType.Equals(typeof(decimal)))
                            {
                                strFieldName = "st" + dc;
                                accRptLedgerListTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                dc++;
                            }
                        }
                    }

                    #endregion

                    // Re arrange data table header columns for report
                    dtArrangedReportData = dtReportData.Copy();
                    dtReportData = null;
                    reportSources = new ReportSources();
                    reportSources = SetReportSourcesForReport(dtArrangedReportData, reportDataStructList);
                    dtArrangedReportData = reportSources.reportData;
                    newSumFieldsIndexesList = new ArrayList();
                    newSumFieldsIndexesList = reportSources.newSumFieldsIndexes;

                    accRptLedgerListTemplate.SetDataSource(dtArrangedReportData);
                    accRptLedgerListTemplate.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
                    accRptLedgerListTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptLedgerListTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptLedgerListTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptLedgerListTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptLedgerListTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptLedgerListTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptLedgerListTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    // Set parameter sum fields
                    //for (int i = 0; i < accRptLedgerListTemplate.ParameterFields.Count; i++)
                    //{
                    //    if (accRptLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter) && newSumFieldsIndexesList.Contains(i + 1) && accRptLedgerListTemplate.ParameterFields[i].Name.StartsWith("prmSumFieldDecimal"))
                    //    {
                    //        accRptLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), true);
                    //    }
                    //    else
                    //    {
                    //        accRptLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), false);
                    //    }
                    //}

                    #region Group By
                    selectedReportStructList = reportDataStructList.Where(c => c.IsSelectionField.Equals(true)).ToList();
                    selectedGroupStructList = groupByStructList.Where(c => c.IsResultGroupBy.Equals(true)).ToList();

                    gr = 0; gp = 1;
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        // Set report group field values
                        for (int i = 0; i < selectedReportStructList.Count(); i++)
                        {
                            if (gr < accRptLedgerListTemplate.DataDefinition.Groups.Count)
                            {
                                if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                {
                                    accRptLedgerListTemplate.DataDefinition.Groups[gr].ConditionField = accRptLedgerListTemplate.Database.Tables[0].Fields[string.Concat("FieldString", (i + 1).ToString())];
                                    gr++;
                                }
                            }
                        }

                        // Set parameter field values
                        for (int i = 0; i < selectedReportStructList.Count(); i++)
                        {
                            if (gp - 1 < accRptLedgerListTemplate.DataDefinition.Groups.Count)
                            {
                                if (accRptLedgerListTemplate.ParameterFields[gp - 1].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                                {
                                    if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                    {
                                        accRptLedgerListTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), true);
                                        gp++;
                                    }
                                    else
                                    {
                                        accRptLedgerListTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), false);
                                    }
                                }
                            }
                        }

                        for (int i = gp; i < accRptLedgerListTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                accRptLedgerListTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    else
                    {
                        // Set parameter field values
                        for (int i = 0; i < accRptLedgerListTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                accRptLedgerListTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    #endregion

                    reportViewer.crRptViewer.ReportSource = accRptLedgerListTemplate;

                    break;


                #endregion

                #region Trial Balance
                case "RptTrialBalance":

                    AccRptTrialBalanceTemplate accRptTrialBalanceTemplate = new AccRptTrialBalanceTemplate();

                    #region Set Values for report header fields
                    strFieldName = string.Empty;
                    sr = 1;
                    dc = 11;

                    foreach (var item in reportDataStructList)
                    {
                        if (dtReportData.Columns.Contains(item.ReportField.Trim()))
                        {

                            if (item.ReportDataType.Equals(typeof(string)))
                            {
                                strFieldName = "st" + sr;
                                accRptTrialBalanceTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                sr++;
                            }

                            if (item.ReportDataType.Equals(typeof(decimal)))
                            {
                                strFieldName = "st" + dc;
                                accRptTrialBalanceTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                dc++;
                            }
                        }
                    }

                    #endregion

                    // Re arrange data table header columns for report
                    dtArrangedReportData = dtReportData.Copy();
                    dtReportData = null;
                    reportSources = new ReportSources();
                    reportSources = SetReportSourcesForReport(dtArrangedReportData, reportDataStructList);
                    dtArrangedReportData = reportSources.reportData;
                    newSumFieldsIndexesList = new ArrayList();
                    newSumFieldsIndexesList = reportSources.newSumFieldsIndexes;

                    accRptTrialBalanceTemplate.SetDataSource(dtArrangedReportData);
                    accRptTrialBalanceTemplate.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
                    accRptTrialBalanceTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptTrialBalanceTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptTrialBalanceTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptTrialBalanceTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptTrialBalanceTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptTrialBalanceTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptTrialBalanceTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    // Set parameter sum fields
                    for (int i = 0; i < accRptTrialBalanceTemplate.ParameterFields.Count; i++)
                    {
                        if (accRptTrialBalanceTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter) && newSumFieldsIndexesList.Contains(i + 1) && accRptTrialBalanceTemplate.ParameterFields[i].Name.StartsWith("prmSumFieldDecimal"))
                        {
                            accRptTrialBalanceTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), true);
                        }
                        else
                        {
                            accRptTrialBalanceTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), false);
                        }
                    }

                    reportViewer.crRptViewer.ReportSource = accRptTrialBalanceTemplate;

                    break;


                #endregion

                #region Statement
                #region Supplier Statement

                case "RptSupplierStatement":

                    AccRptLedgerListTemplate accRptSupplierLedgerListTemplate = new AccRptLedgerListTemplate();

                    #region Set Values for report header fields
                    strFieldName = string.Empty;
                    sr = 1;
                    dc = 11;

                    foreach (var item in reportDataStructList)
                    {
                        if (dtReportData.Columns.Contains(item.ReportField.Trim()))
                        {

                            if (item.ReportDataType.Equals(typeof(string)))
                            {
                                strFieldName = "st" + sr;
                                accRptSupplierLedgerListTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                sr++;
                            }

                            if (item.ReportDataType.Equals(typeof(decimal)))
                            {
                                strFieldName = "st" + dc;
                                accRptSupplierLedgerListTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                dc++;
                            }
                        }
                    }

                    #endregion

                    // Re arrange data table header columns for report
                    dtArrangedReportData = dtReportData.Copy();
                    dtReportData = null;
                    reportSources = new ReportSources();
                    reportSources = SetReportSourcesForReport(dtArrangedReportData, reportDataStructList);
                    dtArrangedReportData = reportSources.reportData;
                    newSumFieldsIndexesList = new ArrayList();
                    newSumFieldsIndexesList = reportSources.newSumFieldsIndexes;

                    accRptSupplierLedgerListTemplate.SetDataSource(dtArrangedReportData);
                    accRptSupplierLedgerListTemplate.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
                    accRptSupplierLedgerListTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptSupplierLedgerListTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptSupplierLedgerListTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptSupplierLedgerListTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptSupplierLedgerListTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptSupplierLedgerListTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptSupplierLedgerListTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    // Set parameter sum fields
                    //for (int i = 0; i < accRptSupplierLedgerListTemplate.ParameterFields.Count; i++)
                    //{
                    //    if (accRptSupplierLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter) && newSumFieldsIndexesList.Contains(i + 1) && accRptSupplierLedgerListTemplate.ParameterFields[i].Name.StartsWith("prmSumFieldDecimal"))
                    //    {
                    //        accRptSupplierLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), true);
                    //    }
                    //    else
                    //    {
                    //        accRptSupplierLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), false);
                    //    }
                    //}



                    reportViewer.crRptViewer.ReportSource = accRptSupplierLedgerListTemplate;

                    break;


                #endregion

                #region Customer Statement

                case "RptCustomerStatement":

                    AccRptLedgerListTemplate accRptCustomerLedgerListTemplate = new AccRptLedgerListTemplate();

                    #region Set Values for report header fields
                    strFieldName = string.Empty;
                    sr = 1;
                    dc = 11;

                    foreach (var item in reportDataStructList)
                    {
                        if (dtReportData.Columns.Contains(item.ReportField.Trim()))
                        {

                            if (item.ReportDataType.Equals(typeof(string)))
                            {
                                strFieldName = "st" + sr;
                                accRptCustomerLedgerListTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                sr++;
                            }

                            if (item.ReportDataType.Equals(typeof(decimal)))
                            {
                                strFieldName = "st" + dc;
                                accRptCustomerLedgerListTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                dc++;
                            }
                        }
                    }

                    #endregion

                    // Re arrange data table header columns for report
                    dtArrangedReportData = dtReportData.Copy();
                    dtReportData = null;
                    reportSources = new ReportSources();
                    reportSources = SetReportSourcesForReport(dtArrangedReportData, reportDataStructList);
                    dtArrangedReportData = reportSources.reportData;
                    newSumFieldsIndexesList = new ArrayList();
                    newSumFieldsIndexesList = reportSources.newSumFieldsIndexes;

                    accRptCustomerLedgerListTemplate.SetDataSource(dtArrangedReportData);
                    accRptCustomerLedgerListTemplate.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
                    accRptCustomerLedgerListTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptCustomerLedgerListTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptCustomerLedgerListTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptCustomerLedgerListTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptCustomerLedgerListTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptCustomerLedgerListTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptCustomerLedgerListTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    // Set parameter sum fields
                    //for (int i = 0; i < accRptCustomerLedgerListTemplate.ParameterFields.Count; i++)
                    //{
                    //    if (accRptCustomerLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter) && newSumFieldsIndexesList.Contains(i + 1) && accRptCustomerLedgerListTemplate.ParameterFields[i].Name.StartsWith("prmSumFieldDecimal"))
                    //    {
                    //        accRptCustomerLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), true);
                    //    }
                    //    else
                    //    {
                    //        accRptCustomerLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), false);
                    //    }
                    //}

                    #region Group By
                    selectedReportStructList = reportDataStructList.Where(c => c.IsSelectionField.Equals(true)).ToList();
                    selectedGroupStructList = groupByStructList.Where(c => c.IsResultGroupBy.Equals(true)).ToList();

                    gr = 0; gp = 1;
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        // Set report group field values
                        for (int i = 0; i < selectedReportStructList.Count(); i++)
                        {
                            if (gr < accRptCustomerLedgerListTemplate.DataDefinition.Groups.Count)
                            {
                                if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                {
                                    accRptCustomerLedgerListTemplate.DataDefinition.Groups[gr].ConditionField = accRptCustomerLedgerListTemplate.Database.Tables[0].Fields[string.Concat("FieldString", (i + 1).ToString())];
                                    gr++;
                                }
                            }
                        }

                        // Set parameter field values
                        for (int i = 0; i < selectedReportStructList.Count(); i++)
                        {
                            if (gp - 1 < accRptCustomerLedgerListTemplate.DataDefinition.Groups.Count)
                            {
                                if (accRptCustomerLedgerListTemplate.ParameterFields[gp - 1].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                                {
                                    if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                    {
                                        accRptCustomerLedgerListTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), true);
                                        gp++;
                                    }
                                    else
                                    {
                                        accRptCustomerLedgerListTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), false);
                                    }
                                }
                            }
                        }

                        for (int i = gp; i < accRptCustomerLedgerListTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptCustomerLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                accRptCustomerLedgerListTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    else
                    {
                        // Set parameter field values
                        for (int i = 0; i < accRptCustomerLedgerListTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptCustomerLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                accRptCustomerLedgerListTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    #endregion

                    reportViewer.crRptViewer.ReportSource = accRptCustomerLedgerListTemplate;

                    break;


                #endregion
                #endregion

                #region Aging Detail

                case "RptSupplierAgeAnalysis":

                    AccRptAgingCrossTabTemplate accRptAgingCrossTabTemplate = new AccRptAgingCrossTabTemplate();

                    #region Set Values for report header fields
                    strFieldName = string.Empty;
                    sr = 1;
                    dc = 11;

                    //foreach (var item in reportDataStructList)
                    //{
                    //    if (dtReportData.Columns.Contains(item.ReportField.Trim()))
                    //    {

                    //        if (item.ReportDataType.Equals(typeof(string)))
                    //        {
                    //            strFieldName = "st" + sr;
                    //            accRptAgingCrossTabTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                    //            sr++;
                    //        }

                    //        if (item.ReportDataType.Equals(typeof(decimal)))
                    //        {
                    //            strFieldName = "st" + dc;
                    //            accRptAgingCrossTabTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                    //            dc++;
                    //        }
                    //    }
                    //}

                    #endregion

                    // Re arrange data table header columns for report
                    dtArrangedReportData = dtReportData.Copy();
                    dtReportData = null;
                    reportSources = new ReportSources();
                    reportSources = SetReportSourcesForReport(dtArrangedReportData, reportDataStructList);
                    dtArrangedReportData = reportSources.reportData;
                    newSumFieldsIndexesList = new ArrayList();
                    newSumFieldsIndexesList = reportSources.newSumFieldsIndexes;

                    accRptAgingCrossTabTemplate.SetDataSource(dtArrangedReportData);
                    accRptAgingCrossTabTemplate.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
                    accRptAgingCrossTabTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptAgingCrossTabTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptAgingCrossTabTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptAgingCrossTabTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptAgingCrossTabTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptAgingCrossTabTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptAgingCrossTabTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    // Set parameter sum fields
                    //for (int i = 0; i < accRptLedgerListTemplate.ParameterFields.Count; i++)
                    //{
                    //    if (accRptLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter) && newSumFieldsIndexesList.Contains(i + 1) && accRptLedgerListTemplate.ParameterFields[i].Name.StartsWith("prmSumFieldDecimal"))
                    //    {
                    //        accRptLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), true);
                    //    }
                    //    else
                    //    {
                    //        accRptLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), false);
                    //    }
                    //}

                    #region Group By
                    selectedReportStructList = reportDataStructList.Where(c => c.IsSelectionField.Equals(true)).ToList();
                    selectedGroupStructList = groupByStructList.Where(c => c.IsResultGroupBy.Equals(true)).ToList();

                    gr = 0; gp = 1;
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        // Set report group field values
                        for (int i = 0; i < selectedReportStructList.Count(); i++)
                        {
                            if (gr < accRptAgingCrossTabTemplate.DataDefinition.Groups.Count)
                            {
                                if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                {
                                    accRptAgingCrossTabTemplate.DataDefinition.Groups[gr].ConditionField = accRptAgingCrossTabTemplate.Database.Tables[0].Fields[string.Concat("FieldString", (i + 1).ToString())];
                                    gr++;
                                }
                            }
                        }

                        // Set parameter field values
                        for (int i = 0; i < selectedReportStructList.Count(); i++)
                        {
                            if (gp - 1 < accRptAgingCrossTabTemplate.DataDefinition.Groups.Count)
                            {
                                if (accRptAgingCrossTabTemplate.ParameterFields[gp - 1].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                                {
                                    if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                    {
                                        accRptAgingCrossTabTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), true);
                                        gp++;
                                    }
                                    else
                                    {
                                        accRptAgingCrossTabTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), false);
                                    }
                                }
                            }
                        }

                        for (int i = gp; i < accRptAgingCrossTabTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptAgingCrossTabTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                accRptAgingCrossTabTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    else
                    {
                        // Set parameter field values
                        for (int i = 0; i < accRptAgingCrossTabTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptAgingCrossTabTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                accRptAgingCrossTabTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    #endregion

                    reportViewer.crRptViewer.ReportSource = accRptAgingCrossTabTemplate;

                    break;


                #endregion

                #region Cheque Details
                #region Payable Cheque Details

                case "RptPayableChequeDetails":

                    AccRptChequeDetailsTemplate accRptPayableChequeDetailsTemplate = new AccRptChequeDetailsTemplate();
                    #region Set Values for report header fields
                    strFieldName = string.Empty;
                    sr = 1;
                    dc = 14;

                    foreach (var item in reportDataStructList)
                    {
                        if (dtReportData.Columns.Contains(item.ReportField.Trim()))
                        {

                            if (item.ReportDataType.Equals(typeof(string)))
                            {
                                strFieldName = "st" + sr;
                                accRptPayableChequeDetailsTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                sr++;
                            }

                            if (item.ReportDataType.Equals(typeof(decimal)))
                            {
                                strFieldName = "st" + dc;
                                accRptPayableChequeDetailsTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                dc++;
                            }
                        }
                    }

                    #endregion


                    // Re arrange data table header columns for report
                    dtArrangedReportData = new DataTable();
                    dtArrangedReportData = dtReportData.Copy();
                    dtReportData = null;
                    reportSources = new ReportSources();
                    reportSources = SetReportSourcesForReport(dtArrangedReportData, reportDataStructList);
                    dtArrangedReportData = reportSources.reportData;
                    newSumFieldsIndexesList = new ArrayList();
                    newSumFieldsIndexesList = reportSources.newSumFieldsIndexes;

                    accRptPayableChequeDetailsTemplate.SetDataSource(dtArrangedReportData);
                    accRptPayableChequeDetailsTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptPayableChequeDetailsTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptPayableChequeDetailsTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptPayableChequeDetailsTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptPayableChequeDetailsTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptPayableChequeDetailsTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptPayableChequeDetailsTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";


                    reportViewer.crRptViewer.ReportSource = accRptPayableChequeDetailsTemplate;

                    break;
                #endregion

                #region Receivable Cheque Details
                case "RptReceivableChequeDetails":

                    AccRptChequeDetailsTemplate accRptReceivableChequeDetailsTemplate = new AccRptChequeDetailsTemplate();

                    //#region Set Values for report header fields
                    strFieldName = string.Empty;
                    sr = 1;
                    dc = 14;

                    foreach (var item in reportDataStructList)
                    {
                        if (dtReportData.Columns.Contains(item.ReportField.Trim()))
                        {

                            if (item.ReportDataType.Equals(typeof(string)))
                            {
                                strFieldName = "st" + sr;
                                accRptReceivableChequeDetailsTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                sr++;
                            }

                            if (item.ReportDataType.Equals(typeof(decimal)))
                            {
                                strFieldName = "st" + dc;
                                accRptReceivableChequeDetailsTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                dc++;
                            }
                        }
                    }

                    //#endregion

                    // Re arrange data table header columns for report
                    dtArrangedReportData = new DataTable();
                    dtArrangedReportData = dtReportData.Copy();
                    dtReportData = null;
                    reportSources = new ReportSources();
                    reportSources = SetReportSourcesForReport(dtArrangedReportData, reportDataStructList);
                    dtArrangedReportData = reportSources.reportData;
                    newSumFieldsIndexesList = new ArrayList();
                    newSumFieldsIndexesList = reportSources.newSumFieldsIndexes;

                    accRptReceivableChequeDetailsTemplate.SetDataSource(dtArrangedReportData);
                    accRptReceivableChequeDetailsTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptReceivableChequeDetailsTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptReceivableChequeDetailsTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptReceivableChequeDetailsTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptReceivableChequeDetailsTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptReceivableChequeDetailsTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptReceivableChequeDetailsTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";


                    reportViewer.crRptViewer.ReportSource = accRptReceivableChequeDetailsTemplate;

                    break;
                #endregion

                #endregion

                #region Ledger View

                case "RptLedgerView":

                    AccRptLedgerListTemplate accRptLedgerViewTemplate = new AccRptLedgerListTemplate();

                    #region Set Values for report header fields
                    strFieldName = string.Empty;
                    sr = 1;
                    dc = 11;

                    foreach (var item in reportDataStructList)
                    {
                        if (dtReportData.Columns.Contains(item.ReportField.Trim()))
                        {
                            if (item.ReportDataType.Equals(typeof(string)))
                            {
                                strFieldName = "st" + sr;
                                accRptLedgerViewTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                sr++;
                            }

                            if (item.ReportDataType.Equals(typeof(decimal)))
                            {
                                strFieldName = "st" + dc;
                                accRptLedgerViewTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                dc++;
                            }
                        }
                    }

                    #endregion

                    // Re arrange data table header columns for report
                    dtArrangedReportData = dtReportData.Copy();
                    dtReportData = null;
                    reportSources = new ReportSources();
                    reportSources = SetReportSourcesForReport(dtArrangedReportData, reportDataStructList);
                    dtArrangedReportData = reportSources.reportData;
                    newSumFieldsIndexesList = new ArrayList();
                    newSumFieldsIndexesList = reportSources.newSumFieldsIndexes;

                    accRptLedgerViewTemplate.SetDataSource(dtArrangedReportData);
                    accRptLedgerViewTemplate.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
                    accRptLedgerViewTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptLedgerViewTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptLedgerViewTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptLedgerViewTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptLedgerViewTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptLedgerViewTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptLedgerViewTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    // Set parameter sum fields
                    //for (int i = 0; i < accRptLedgerListTemplate.ParameterFields.Count; i++)
                    //{
                    //    if (accRptLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter) && newSumFieldsIndexesList.Contains(i + 1) && accRptLedgerListTemplate.ParameterFields[i].Name.StartsWith("prmSumFieldDecimal"))
                    //    {
                    //        accRptLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), true);
                    //    }
                    //    else
                    //    {
                    //        accRptLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), false);
                    //    }
                    //}

                    #region Group By
                    selectedReportStructList = reportDataStructList.Where(c => c.IsSelectionField.Equals(true)).ToList();
                    selectedGroupStructList = groupByStructList.Where(c => c.IsResultGroupBy.Equals(true)).ToList();

                    gr = 0; gp = 1;
                    if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    {
                        // Set report group field values
                        for (int i = 0; i < selectedReportStructList.Count(); i++)
                        {
                            if (gr < accRptLedgerViewTemplate.DataDefinition.Groups.Count)
                            {
                                if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                {
                                    accRptLedgerViewTemplate.DataDefinition.Groups[gr].ConditionField = accRptLedgerViewTemplate.Database.Tables[0].Fields[string.Concat("FieldString", (i + 1).ToString())];
                                    gr++;
                                }
                            }
                        }

                        // Set parameter field values
                        for (int i = 0; i < selectedReportStructList.Count(); i++)
                        {
                            if (gp - 1 < accRptLedgerViewTemplate.DataDefinition.Groups.Count)
                            {
                                if (accRptLedgerViewTemplate.ParameterFields[gp - 1].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                                {
                                    if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                    {
                                        accRptLedgerViewTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), true);
                                        gp++;
                                    }
                                    else
                                    {
                                        accRptLedgerViewTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), false);
                                    }
                                }
                            }
                        }

                        for (int i = gp; i < accRptLedgerViewTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptLedgerViewTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                accRptLedgerViewTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    else
                    {
                        // Set parameter field values
                        for (int i = 0; i < accRptLedgerViewTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptLedgerViewTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                accRptLedgerViewTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    #endregion

                    reportViewer.crRptViewer.ReportSource = accRptLedgerViewTemplate;

                    break;


                #endregion

                #region Transaction View
                case "RptTransactionView":

                    AccRptTransactionDetailTemplate accRptTransactionViewTemplate = new AccRptTransactionDetailTemplate();

                    #region Set Values for report header fields
                    strFieldName = string.Empty;
                    sr = 1;
                    dc = 11;

                    foreach (var item in reportDataStructList)
                    {
                        if (dtReportData.Columns.Contains(item.ReportField.Trim()))
                        {
                            if (item.ReportDataType.Equals(typeof(string)))
                            {
                                strFieldName = "st" + sr;
                                accRptTransactionViewTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                sr++;
                            }

                            if (item.ReportDataType.Equals(typeof(decimal)))
                            {
                                strFieldName = "st" + dc;
                                accRptTransactionViewTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                                dc++;
                            }
                        }
                    }

                    #endregion

                    // Re arrange data table header columns for report
                    dtArrangedReportData = dtReportData.Copy();
                    dtReportData = null;
                    reportSources = new ReportSources();
                    reportSources = SetReportSourcesForReport(dtArrangedReportData, reportDataStructList);
                    dtArrangedReportData = reportSources.reportData;
                    newSumFieldsIndexesList = new ArrayList();
                    newSumFieldsIndexesList = reportSources.newSumFieldsIndexes;

                    accRptTransactionViewTemplate.SetDataSource(dtArrangedReportData);
                    accRptTransactionViewTemplate.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
                    accRptTransactionViewTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
                    accRptTransactionViewTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                    accRptTransactionViewTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                    accRptTransactionViewTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    accRptTransactionViewTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    accRptTransactionViewTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                    accRptTransactionViewTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

                    // Set parameter sum fields
                    //for (int i = 0; i < accRptLedgerListTemplate.ParameterFields.Count; i++)
                    //{
                    //    if (accRptLedgerListTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter) && newSumFieldsIndexesList.Contains(i + 1) && accRptLedgerListTemplate.ParameterFields[i].Name.StartsWith("prmSumFieldDecimal"))
                    //    {
                    //        accRptLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), true);
                    //    }
                    //    else
                    //    {
                    //        accRptLedgerListTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), false);
                    //    }
                    //}

                    #region Group By Old
                    //selectedReportStructList = reportDataStructList.Where(c => c.IsSelectionField.Equals(true)).ToList();
                    //selectedGroupStructList = groupByStructList.Where(c => c.IsResultGroupBy.Equals(true)).ToList();

                    //gr = 0; gp = 1;
                    //if (groupByStructList.Any(g => g.IsResultGroupBy.Equals(true)))
                    //{
                    //    // Set report group field values
                    //    for (int i = 0; i < selectedReportStructList.Count(); i++)
                    //    {
                    //        if (gr < accRptTransactionViewTemplate.DataDefinition.Groups.Count)
                    //        {
                    //            if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                    //            {
                    //                accRptTransactionViewTemplate.DataDefinition.Groups[gr].ConditionField = accRptTransactionViewTemplate.Database.Tables[0].Fields[string.Concat("FieldString", (i + 1).ToString())];
                    //                gr++;
                    //            }
                    //        }
                    //    }

                    //    // Set parameter field values
                    //    for (int i = 0; i < selectedReportStructList.Count(); i++)
                    //    {
                    //        if (gp - 1 < accRptTransactionViewTemplate.DataDefinition.Groups.Count)
                    //        {
                    //            if (accRptTransactionViewTemplate.ParameterFields[gp - 1].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                    //            {
                    //                if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                    //                {
                    //                    accRptTransactionViewTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), true);
                    //                    gp++;
                    //                }
                    //                else
                    //                {
                    //                    accRptTransactionViewTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), false);
                    //                }
                    //            }
                    //        }
                    //    }

                    //    for (int i = gp; i < accRptTransactionViewTemplate.DataDefinition.Groups.Count; i++)
                    //    {
                    //        if (accRptTransactionViewTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                    //        {
                    //            accRptTransactionViewTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    // Set parameter field values
                    //    for (int i = 0; i < accRptTransactionViewTemplate.DataDefinition.Groups.Count; i++)
                    //    {
                    //        if (accRptTransactionViewTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                    //        {
                    //            accRptTransactionViewTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                    //        }
                    //    }
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
                            if (gr < accRptTransactionViewTemplate.DataDefinition.Groups.Count)
                            {
                                if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                {
                                    accRptTransactionViewTemplate.DataDefinition.Groups[gr].ConditionField = accRptTransactionViewTemplate.Database.Tables[0].Fields[string.Concat("FieldString", (i + 1).ToString())];
                                    gr++;
                                }
                            }
                        }

                        // Set parameter field values
                        for (int i = 0; i < selectedReportStructList.Count(); i++)
                        {
                            if (gp - 1 < accRptTransactionViewTemplate.DataDefinition.Groups.Count)
                            {
                                if (accRptTransactionViewTemplate.ParameterFields[gp - 1].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                                {
                                    if (selectedGroupStructList.ToList().Any(c => c.IsResultGroupBy.Equals(true) && c.DbColumnName == selectedReportStructList[i].DbColumnName.Trim()))
                                    {
                                        accRptTransactionViewTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), true);
                                        gp++;
                                    }
                                    else
                                    {
                                        accRptTransactionViewTemplate.SetParameterValue("prmSelectGroup" + (gp).ToString(), false);
                                    }
                                }
                            }
                        }

                        for (int i = gp; i < accRptTransactionViewTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptTransactionViewTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                accRptTransactionViewTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    else
                    {
                        // Set parameter field values
                        for (int i = 0; i < accRptTransactionViewTemplate.DataDefinition.Groups.Count; i++)
                        {
                            if (accRptTransactionViewTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                            {
                                accRptTransactionViewTemplate.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                            }
                        }
                    }
                    #endregion

                    reportViewer.crRptViewer.ReportSource = accRptTransactionViewTemplate;

                    break;
                #endregion 
                #endregion

                default:
                    break;
            }

            reportViewer.WindowState = FormWindowState.Maximized;
            reportViewer.Show();
            Cursor.Current = Cursors.Default;
        }

        /// Organize Report Generator Fields
        public FrmReprotGenerator OrganizeFormFields(AutoGenerateInfo autoGenerateInfo)
        {
            List<Common.ReportDataStruct> reportDatStructList = new List<Common.ReportDataStruct>();
            FrmReprotGenerator frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList);

            switch (autoGenerateInfo.FormName)
            {
                #region Account Reference
                #region FrmChartOfAccounts
                case "FrmChartOfAccounts":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Ledger Code", ReportDataType = typeof(string), DbColumnName = "LedgerCode", IsConditionNameJoined = true, ValueDataType = typeof(string), IsConditionField = true, IsSelectionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Ledger Name", ReportDataType = typeof(string), DbColumnName = "LedgerName", IsConditionNameJoined = true, ValueDataType = typeof(string), IsConditionField = true, IsSelectionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Account Status", ReportDataType = typeof(string), DbColumnName = "AccountStatus", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Type Level", ReportDataType = typeof(string), DbColumnName = "TypeLevel", IsConditionNameJoined = false, ValueDataType = typeof(int), IsJoinField = false, IsGroupBy = true, IsConditionField = false, IsSelectionField = false });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Remark", ReportDataType = typeof(string), DbColumnName = "Remark", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = false, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Created Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Account No", ReportDataType = typeof(string), DbColumnName = "AccountNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Bank", ReportDataType = typeof(string), DbColumnName = "BankCode", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Bank Branch", ReportDataType = typeof(string), DbColumnName = "BankBranchCode", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Active Status", ReportDataType = typeof(string), DbColumnName = "IsActive", ValueDataType = typeof(bool), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 6, 3, 2);
                #endregion
                #endregion

                #region accounts transactions

                #region Petty Cash
                #region FrmPettyCashReimbursement
                case "FrmPettyCashReimbursement":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Petty Cash Book", ReportDataType = typeof(string), DbColumnName = "PettyCashLedgerID", DbJoinColumnName = "LedgerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "ReimburseAmount", ValueDataType = typeof(decimal), IsSelectionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Gross Amt.", ReportDataType = typeof(decimal), DbColumnName = "GrossAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Disc. Amt.", ReportDataType = typeof(decimal), DbColumnName = "DiscountAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "NBT(2%)", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount1", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal5", ReportFieldName = "NBT(2.04%)", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount2", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal6", ReportFieldName = "VAT", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount3", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal7", ReportFieldName = "Net Amt.", ReportDataType = typeof(decimal), DbColumnName = "NetAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 5, 5, 4);
                #endregion

                #region FrmPettyCashIOU
                case "FrmPettyCashIOU":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Petty Cash Book", ReportDataType = typeof(string), DbColumnName = "PettyCashLedgerID", DbJoinColumnName = "LedgerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "ReimburseAmount", ValueDataType = typeof(decimal), IsSelectionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Gross Amt.", ReportDataType = typeof(decimal), DbColumnName = "GrossAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Disc. Amt.", ReportDataType = typeof(decimal), DbColumnName = "DiscountAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "NBT(2%)", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount1", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal5", ReportFieldName = "NBT(2.04%)", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount2", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal6", ReportFieldName = "VAT", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount3", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal7", ReportFieldName = "Net Amt.", ReportDataType = typeof(decimal), DbColumnName = "NetAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 5, 5, 4);
                #endregion

                #region FrmPettyCashBillEntry
                case "FrmPettyCashBillEntry":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Petty Cash Book", ReportDataType = typeof(string), DbColumnName = "PettyCashLedgerID", DbJoinColumnName = "LedgerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "ReimburseAmount", ValueDataType = typeof(decimal), IsSelectionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Gross Amt.", ReportDataType = typeof(decimal), DbColumnName = "GrossAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Disc. Amt.", ReportDataType = typeof(decimal), DbColumnName = "DiscountAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "NBT(2%)", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount1", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal5", ReportFieldName = "NBT(2.04%)", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount2", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal6", ReportFieldName = "VAT", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount3", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal7", ReportFieldName = "Net Amt.", ReportDataType = typeof(decimal), DbColumnName = "NetAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 5, 5, 4);
                #endregion

                #region FrmPettyCashPayment
                case "FrmPettyCashPayment":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Petty Cash Book", ReportDataType = typeof(string), DbColumnName = "PettyCashLedgerID", DbJoinColumnName = "LedgerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "ReimburseAmount", ValueDataType = typeof(decimal), IsSelectionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Gross Amt.", ReportDataType = typeof(decimal), DbColumnName = "GrossAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Disc. Amt.", ReportDataType = typeof(decimal), DbColumnName = "DiscountAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "NBT(2%)", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount1", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal5", ReportFieldName = "NBT(2.04%)", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount2", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal6", ReportFieldName = "VAT", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount3", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal7", ReportFieldName = "Net Amt.", ReportDataType = typeof(decimal), DbColumnName = "NetAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 5, 5, 4);
                #endregion
                #endregion

                #region Journal Entry
                case "FrmJournalEntry":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList = new List<Common.ReportDataStruct>();
                    //String Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Reference No", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Manual No", ReportDataType = typeof(string), DbColumnName = "ManualNo", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    //Decimal Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsJoinField = true, IsSelectionField = true, IsColumnTotal = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);
                #endregion

                #region Bill Entry
                case "FrmBillEntry":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Reference No", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Manual No", ReportDataType = typeof(string), DbColumnName = "ManualNo", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(decimal), IsJoinField = true, IsSelectionField = true, IsColumnTotal = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Received Date", ReportDataType = typeof(string), DbColumnName = "ReceivedDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Due Date", ReportDataType = typeof(string), DbColumnName = "DueDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsColumnTotal = true });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);

                #endregion

                #region Ledger Opening Balances
                case "FrmLedgerOpeningBalances":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", ValueDataType = typeof(int), IsJoinField = true, IsConditionNameJoined = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal),IsSelectionField = true, IsColumnTotal = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);

                #endregion

                #region Payment
                case "FrmPayment":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Supplier", ReportDataType = typeof(string), DbColumnName = "SupplierName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = false, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Payee Name", ReportDataType = typeof(string), DbColumnName = "CollectorName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Gross Amt.", ReportDataType = typeof(decimal), DbColumnName = "GrossAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Disc. Amt.", ReportDataType = typeof(decimal), DbColumnName = "DiscountAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "NBT(2%)", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount1", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal5", ReportFieldName = "NBT(2.04%)", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount2", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal6", ReportFieldName = "VAT", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount3", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal7", ReportFieldName = "Net Amt.", ReportDataType = typeof(decimal), DbColumnName = "NetAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 6, 5, 4);
                #endregion

                #region Receipt
                case "FrmReceipt":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Gross Amt.", ReportDataType = typeof(decimal), DbColumnName = "GrossAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Disc. Amt.", ReportDataType = typeof(decimal), DbColumnName = "DiscountAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "NBT(2%)", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount1", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal5", ReportFieldName = "NBT(2.04%)", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount2", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal6", ReportFieldName = "VAT", ReportDataType = typeof(decimal), DbColumnName = "TaxAmount3", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true, IsRowTotal = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal7", ReportFieldName = "Net Amt.", ReportDataType = typeof(decimal), DbColumnName = "NetAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsColumnTotal = true, IsRowTotal = true });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 4, 5, 4);
                #endregion

                #region Bank Deposit
                case "FrmBankDeposit":
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    //String Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Deposit Mode", ReportDataType = typeof(string), DbColumnName = "BankDepositMode", ValueDataType = typeof(int), IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", ValueDataType = typeof(int), IsConditionNameJoined = true, IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Receivable Account", ReportDataType = typeof(string), DbColumnName = "AccCashAccountID", DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Bank", ReportDataType = typeof(string), DbColumnName = "AccBankAccountID", DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    // Decimal fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);
                #endregion

                #region Bank Reconciliation
                case "FrmAccountsReconciliation":
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    //String Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Bank Account", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsConditionNameJoined = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    // Decimal fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Closing Amount", ReportDataType = typeof(decimal), DbColumnName = "ClosingAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);


                #endregion

                #region Cheque Return
                case "FrmChequeReturn":
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    //String Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", ValueDataType = typeof(int), IsConditionNameJoined = true, IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Cheque No", ReportDataType = typeof(string), DbColumnName = "ChequeNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Bank Account", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    // Decimal fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Cheque Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);
                #endregion

                #region Cheque Cancel
                case "FrmChequeCancel":
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    //String Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", ValueDataType = typeof(int), IsConditionNameJoined = true, IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Cheque No", ReportDataType = typeof(string), DbColumnName = "ChequeNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Bank Account", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    // Decimal fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Cheque Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsColumnTotal = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);
                #endregion


                #region Credit Note
                case "FrmCreditNote":
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    //String Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Reference No", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Manual No", ReportDataType = typeof(string), DbColumnName = "ManualNo", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    //Decimal Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsJoinField = true, IsSelectionField = true, IsColumnTotal = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);
                #endregion

                #region Debit Note
                case "FrmDebitNote":
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    //String Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Reference No", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Manual No", ReportDataType = typeof(string), DbColumnName = "ManualNo", ValueDataType = typeof(string), IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    //Decimal Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsJoinField = true, IsSelectionField = true, IsColumnTotal = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);
                #endregion
                #endregion

                #region Account Detail reports

                #region Petty Cash
                #region RptPettyCash
                case "RptPettyCash":
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsGroupBy = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", ValueDataType = typeof(int), IsSelectionField = true, IsGroupBy = true, IsJoinField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DepartmentID", ValueDataType = typeof(long), IsSelectionField = true, IsGroupBy = true, IsJoinField = true, IsConditionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = categoryText, ReportDataType = typeof(string), DbColumnName = "CategoryID", ValueDataType = typeof(long), IsSelectionField = true, IsGroupBy = true, IsJoinField = true, IsConditionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = subCategoryText, ReportDataType = typeof(string), DbColumnName = "SubCategoryID", ValueDataType = typeof(long), IsSelectionField = true, IsGroupBy = true, IsJoinField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Product Code", ReportDataType = typeof(string), DbColumnName = "ProductID", ValueDataType = typeof(long), IsSelectionField = true, IsGroupBy = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Product Name", ReportDataType = typeof(string), DbColumnName = "ProductName", ValueDataType = typeof(string), IsSelectionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Unit", ReportDataType = typeof(string), DbColumnName = "UnitOfMeasureID", ValueDataType = typeof(long), IsSelectionField = true, IsGroupBy = true, IsJoinField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Remark", ReportDataType = typeof(string), DbColumnName = "Remark", ValueDataType = typeof(string), IsSelectionField = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Qty", ReportDataType = typeof(decimal), DbColumnName = "ExcessQty", ValueDataType = typeof(decimal), IsSelectionField = true, IsRowTotal = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Percentage", ReportDataType = typeof(decimal), DbColumnName = "OrderQty", ValueDataType = typeof(decimal), IsSelectionField = true, IsRowTotal = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList);
                #endregion

                #region RptPettyCashRegister
                case "RptPettyCashRegister":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Ledger Code", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", DbJoinColumnName = "LedgerCode", ValueDataType = typeof(long), IsSelectionField = true, IsJoinField = true, IsConditionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Ledger Name", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsConditionNameJoined = true, IsSelectionField = true, IsJoinField = true, IsConditionField = true, IsMandatoryField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Company", ReportDataType = typeof(string), DbColumnName = "CompanyID", DbJoinColumnName = "CompanyName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsConditionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsConditionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Employee", ReportDataType = typeof(string), DbColumnName = "EmployeeID", DbJoinColumnName = "EmployeeName", ValueDataType = typeof(long), IsConditionNameJoined = true, IsSelectionField = true, IsJoinField = true, IsConditionField = true, IsNotDisplayedOrderBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Transaction Type", ReportDataType = typeof(string), DbColumnName = "DocumentID", DbJoinColumnName = "FormText", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsManualOrderBy = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsSelectionField = true, IsJoinField = false, IsConditionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Job Class", ReportDataType = typeof(string), DbColumnName = "JobClassID", DbJoinColumnName = "JobClassName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsSelectionField = true, IsJoinField = true, IsConditionField = true, IsNotDisplayedOrderBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "Reference", ValueDataType = typeof(string), IsSelectionField = true, IsJoinField = false, IsConditionField = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Remark", ReportDataType = typeof(string), DbColumnName = "AccGlTransactionHeaderID", DbJoinColumnName = "Remark", ValueDataType = typeof(string), IsSelectionField = true, IsJoinField = true, IsConditionField = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString12", ReportFieldName = "DrCrType", ReportDataType = typeof(string), DbColumnName = "DrCrType", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString13", ReportFieldName = "LedgerID", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", ValueDataType = typeof(long), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsNotDisplayedOnGrid = true, IsManualGroupBy = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString14", ReportFieldName = "DocumentID", ReportDataType = typeof(string), DbColumnName = "DocumentID", ValueDataType = typeof(int), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = true, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = subCategoryText, ReportDataType = typeof(string), DbColumnName = "SubCategoryID", ValueDataType = typeof(long), IsSelectionField = true, IsGroupBy = true, IsJoinField = true, IsConditionField = true });

                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Unit", ReportDataType = typeof(string), DbColumnName = "UnitOfMeasureID", ValueDataType = typeof(long), IsSelectionField = true, IsGroupBy = true, IsJoinField = true, IsConditionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Remark", ReportDataType = typeof(string), DbColumnName = "Remark", ValueDataType = typeof(string), IsSelectionField = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Debit", ReportDataType = typeof(decimal), DbColumnName = "DebitAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsColumnTotal = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Credit", ReportDataType = typeof(decimal), DbColumnName = "CreditAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsColumnTotal = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Balance", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = false, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);
                #endregion
                #endregion

                #region Receipt
                case "RptReceiptsRegister":
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", ValueDataType = typeof(int), IsConditionNameJoined = true, IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true, IsMandatoryField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Sale Type", ReportDataType = typeof(string), DbColumnName = "SaleTypeID", ValueDataType = typeof(int), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Bill Type", ReportDataType = typeof(string), DbColumnName = "BillTypeID", ValueDataType = typeof(int), IsSelectionField = true, IsGroupBy = true }); // IsConditionField = true,
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "SDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "SDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "Receipt", ValueDataType = typeof(string), IsSelectionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Pay Type", ReportDataType = typeof(string), DbColumnName = "PaymentID", DbJoinColumnName = "PrintDescrip", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Customer Type", ReportDataType = typeof(string), DbColumnName = "CustomerType", ValueDataType = typeof(int), IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Customer", ReportDataType = typeof(string), DbColumnName = "EnCodeName", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Bank", ReportDataType = typeof(string), DbColumnName = "BankPosID", DbJoinColumnName = "Bank", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Cheque Date", ReportDataType = typeof(string), DbColumnName = "ChequeDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Reference No", ReportDataType = typeof(string), DbColumnName = "RefNo", ValueDataType = typeof(string), IsSelectionField = true, IsConditionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString12", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "UpdatedBy", DbJoinColumnName = "EmployeeName", IsJoinField = true, ValueDataType = typeof(long), IsConditionNameJoined = true, IsSelectionField = true, IsConditionField = true, IsGroupBy = true }); // IsSelectionField = true,
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString13", ReportFieldName = "Cashier", ReportDataType = typeof(string), DbColumnName = "CashierID", DbJoinColumnName = "EmployeeName", IsJoinField = true, ValueDataType = typeof(long), IsConditionNameJoined = true, IsSelectionField = true, IsConditionField = true, IsGroupBy = true });


                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Rcpt. Amt.", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 4, 5, 4);
                #endregion 

                #region Ledger Detail
                case "RptLedgerDetail":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    //String Fields
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Ledger Code", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = false, DbJoinColumnName = "LedgerCode", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = true, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Ledger Name", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = true, DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = true, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Company", ReportDataType = typeof(string), DbColumnName = "CompanyID", DbJoinColumnName = "CompanyName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsConditionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = false, IsManualGroupBy = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "ReferenceDocumentNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });


                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Transaction Type", ReportDataType = typeof(string), DbColumnName = "DocumentID", DbJoinColumnName = "FormText", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Job Class", ReportDataType = typeof(string), DbColumnName = "JobClassID", DbJoinColumnName = "JobClassName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsSelectionField = true, IsJoinField = true, IsConditionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Transaction Location", ReportDataType = typeof(string), DbColumnName = "ReferenceLocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsNotDisplayedOrderBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Remark", ReportDataType = typeof(string), DbColumnName = "Remark", ValueDataType = typeof(string), IsJoinField = true, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Cheque No", ReportDataType = typeof(string), DbColumnName = "ChequeNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString12", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString13", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString14", ReportFieldName = "Cost Centre", ReportDataType = typeof(string), DbColumnName = "CostCentreID", DbJoinColumnName = "CostCentreName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString15", ReportFieldName = "Cheque Date", ReportDataType = typeof(string), DbColumnName = "PaymentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = false, IsManualGroupBy = true, IsNotDisplayedOrderBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString17", ReportFieldName = "Reference Name", ReportDataType = typeof(string), DbColumnName = "SupplierID", DbJoinColumnName = "ReferenceName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString18", ReportFieldName = "Supplier", ReportDataType = typeof(string), DbColumnName = "SupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString19", ReportFieldName = "Customer", ReportDataType = typeof(string), DbColumnName = "CustomerID", DbJoinColumnName = "CustomerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString20", ReportFieldName = "Logistic Supplier", ReportDataType = typeof(string), DbColumnName = "LgsSupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString21", ReportFieldName = "Loyalty Customer", ReportDataType = typeof(string), DbColumnName = "LoyaltyCustomerID", DbJoinColumnName = "CustomerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString22", ReportFieldName = "Employee", ReportDataType = typeof(string), DbColumnName = "EmployeeID", DbJoinColumnName = "EmployeeName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString25", ReportFieldName = "DrCrType", ReportDataType = typeof(string), DbColumnName = "DrCrType", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString26", ReportFieldName = "LedgerID", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", ValueDataType = typeof(long), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = true, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString27", ReportFieldName = "DocumentID", ReportDataType = typeof(string), DbColumnName = "DocumentID", ValueDataType = typeof(int), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = true, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });

                    //Decimal Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Debit", ReportDataType = typeof(decimal), DbColumnName = "DebitAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsColumnTotal = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Credit", ReportDataType = typeof(decimal), DbColumnName = "CreditAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsColumnTotal = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Balance", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = false, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "LedgerID", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", ValueDataType = typeof(long), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);
                #endregion

                #region Trial Balance
                case "RptTrialBalance":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    //String Fields
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Company", ReportDataType = typeof(string), DbColumnName = "CompanyID", DbJoinColumnName = "CompanyName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Ledger Code", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = false, DbJoinColumnName = "LedgerCode", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = true, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Ledger Name", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = true, DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = true, IsGroupBy = false });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = false });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "ReferenceDocumentNo", ValueDataType = typeof(string), IsJoinField = true, IsGroupBy = false, IsConditionField = false, IsSelectionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Transaction Type", ReportDataType = typeof(string), DbColumnName = "DocumentID", DbJoinColumnName = "FormText", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "DrCrType", ReportDataType = typeof(string), DbColumnName = "DrCrType", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsNotDisplayedOnGrid = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "LedgerID", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", ValueDataType = typeof(long), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsNotDisplayedOnGrid = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Remark", ReportDataType = typeof(string), DbColumnName = "Remark", ValueDataType = typeof(string), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Cheque No", ReportDataType = typeof(string), DbColumnName = "ChequeNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false});
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString12", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "Reference", ValueDataType = typeof(string), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString13", ReportFieldName = "Supplier", ReportDataType = typeof(string), DbColumnName = "SupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString14", ReportFieldName = "Customer", ReportDataType = typeof(string), DbColumnName = "CustomerID", DbJoinColumnName = "CustomerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString15", ReportFieldName = "Logistic Supplier", ReportDataType = typeof(string), DbColumnName = "LgsSupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString16", ReportFieldName = "Loyalty Customer", ReportDataType = typeof(string), DbColumnName = "LoyaltyCustomerID", DbJoinColumnName = "CustomerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString17", ReportFieldName = "Employee", ReportDataType = typeof(string), DbColumnName = "EmployeeID", DbJoinColumnName = "EmployeeName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    ////Decimal Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Debit", ReportDataType = typeof(decimal), DbColumnName = "DebitAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Credit", ReportDataType = typeof(decimal), DbColumnName = "CreditAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = false, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOnGrid = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = false, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOnGrid = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);
                #endregion

                #region Statement
                #region Supplier Statement
                case "RptSupplierStatement":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    //String Fields
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Ledger Code", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = false, DbJoinColumnName = "LedgerCode", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = true, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Ledger Name", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = true, DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = true, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "ReferenceDocumentNo", ValueDataType = typeof(string), IsJoinField = true, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Transaction Type", ReportDataType = typeof(string), DbColumnName = "DocumentID", DbJoinColumnName = "FormText", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Remark", ReportDataType = typeof(string), DbColumnName = "Remark", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Cheque No", ReportDataType = typeof(string), DbColumnName = "ChequeNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Supplier", ReportDataType = typeof(string), DbColumnName = "SupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString12", ReportFieldName = "Logistic Supplier", ReportDataType = typeof(string), DbColumnName = "LgsSupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString13", ReportFieldName = "DrCrType", ReportDataType = typeof(string), DbColumnName = "DrCrType", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString14", ReportFieldName = "LedgerID", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", ValueDataType = typeof(long), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = true, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString15", ReportFieldName = "DocumentID", ReportDataType = typeof(string), DbColumnName = "DocumentID", ValueDataType = typeof(int), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = true, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });

                    //Decimal Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Debit", ReportDataType = typeof(decimal), DbColumnName = "DebitAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Credit", ReportDataType = typeof(decimal), DbColumnName = "CreditAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = false, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);

                #endregion

                #region Customer Statement
                case "RptCustomerStatement":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    //String Fields
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Ledger Code", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = false, DbJoinColumnName = "LedgerCode", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = true, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Ledger Name", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = true, DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = true, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "ReferenceDocumentNo", ValueDataType = typeof(string), IsJoinField = true, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Transaction Type", ReportDataType = typeof(string), DbColumnName = "DocumentID", DbJoinColumnName = "FormText", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Remark", ReportDataType = typeof(string), DbColumnName = "Remark", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Cheque No", ReportDataType = typeof(string), DbColumnName = "ChequeNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Customer", ReportDataType = typeof(string), DbColumnName = "CustomerID", DbJoinColumnName = "CustomerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString13", ReportFieldName = "DrCrType", ReportDataType = typeof(string), DbColumnName = "DrCrType", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString14", ReportFieldName = "LedgerID", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", ValueDataType = typeof(long), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = true, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString15", ReportFieldName = "DocumentID", ReportDataType = typeof(string), DbColumnName = "DocumentID", ValueDataType = typeof(int), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = true, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });

                    //Decimal Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Debit", ReportDataType = typeof(decimal), DbColumnName = "DebitAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Credit", ReportDataType = typeof(decimal), DbColumnName = "CreditAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = false, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);

                #endregion
                #endregion

                #region Age Analysis
                #region Supplier Age Analysis
                case "RptSupplierAgeAnalysis":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    //String Fields
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Period", ReportDataType = typeof(string), DbColumnName = "PeriodID", DbJoinColumnName = "LookupValue", ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsRecordFilterByOneOption = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Ledger Code", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = false, DbJoinColumnName = "LedgerCode", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = true, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Ledger Name", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = true, DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = true, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "ReferenceDocumentNo", ValueDataType = typeof(string), IsJoinField = true, IsGroupBy = false, IsConditionField = false, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Transaction Type", ReportDataType = typeof(string), DbColumnName = "DocumentID", DbJoinColumnName = "FormText", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "DrCrType", ReportDataType = typeof(string), DbColumnName = "DrCrType", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "LedgerID", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", ValueDataType = typeof(long), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Remark", ReportDataType = typeof(string), DbColumnName = "Remark", ValueDataType = typeof(string), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Cheque No", ReportDataType = typeof(string), DbColumnName = "ChequeNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString12", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString13", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "Reference", ValueDataType = typeof(string), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString14", ReportFieldName = "Supplier", ReportDataType = typeof(string), DbColumnName = "SupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString15", ReportFieldName = "Logistic Supplier", ReportDataType = typeof(string), DbColumnName = "LgsSupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    //Decimal Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Date-Dif", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(int), IsSelectionField = true, IsConditionField = false, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Current Slab", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = true, IsGroupBy = false });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);

                #endregion
                #endregion

                #region Cheque Details
                #region Payable Cheque Details
                case "RptPayableChequeDetails":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    //String Fields
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Ledger Code", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = false, DbJoinColumnName = "LedgerCode", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = true, IsGroupBy = false, IsNotDisplayedOrderBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Ledger Name", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = true, DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = true, IsGroupBy = false, IsNotDisplayedOrderBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Cheque Date", ReportDataType = typeof(string), DbColumnName = "ChequeDate", ValueDataType = typeof(DateTime), IsMandatoryField = true, IsSelectionField = true, IsConditionField = true, IsGroupBy = false, IsNotDisplayedOrderBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsJoinField = true, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Bank", ReportDataType = typeof(string), DbColumnName = "BankID", DbJoinColumnName = "BankName", ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsManualGroupBy = true, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Cheque No", ReportDataType = typeof(string), DbColumnName = "ChequeNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsMandatoryField = true, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true, });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Status", ReportDataType = typeof(string), DbColumnName = "ChequeStatus", ValueDataType = typeof(int), IsJoinField = false, IsGroupBy = true, IsMandatoryField = true, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOnGrid = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Supplier", ReportDataType = typeof(string), DbColumnName = "SupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Logistic Supplier", ReportDataType = typeof(string), DbColumnName = "LgsSupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Deposited Bank", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = true, IsNotDisplayedOnGrid = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString12", ReportFieldName = "Cheque Type", ReportDataType = typeof(string), DbColumnName = "ChequeType", ValueDataType = typeof(int), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString13", ReportFieldName = "Company", ReportDataType = typeof(string), DbColumnName = "CompanyID", DbJoinColumnName = "CompanyName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true, IsManualGroupBy = false });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString14", ReportFieldName = "DocumentID", ReportDataType = typeof(string), DbColumnName = "DocumentID", ValueDataType = typeof(int), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = true, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });

                    //Decimal Fields

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 11, 1, 2);
                #endregion

                #region Receivable Cheque Details
                case "RptReceivableChequeDetails":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    //String Fields
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Ledger Code", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = false, DbJoinColumnName = "LedgerCode", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Ledger Name", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = true, DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsGroupBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Cheque Date", ReportDataType = typeof(string), DbColumnName = "ChequeDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = false, IsMandatoryField = true, });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "DocumentNo", ValueDataType = typeof(string), IsJoinField = true, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsMandatoryField = true, });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Bank", ReportDataType = typeof(string), DbColumnName = "BankID", DbJoinColumnName = "BankName", ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsManualGroupBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Cheque No", ReportDataType = typeof(string), DbColumnName = "ChequeNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Status", ReportDataType = typeof(string), DbColumnName = "ChequeStatus", ValueDataType = typeof(int), IsJoinField = false, IsGroupBy = true, IsConditionField = true, IsSelectionField = true, IsMandatoryField = true, });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Customer", ReportDataType = typeof(string), DbColumnName = "CustomerID", DbJoinColumnName = "CustomerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Loyalty Customer", ReportDataType = typeof(string), DbColumnName = "LoyaltyCustomerID", DbJoinColumnName = "CustomerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false });

                    //  reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString12", ReportFieldName = "Cheque Type", ReportDataType = typeof(string), DbColumnName = "ChequeType", ValueDataType = typeof(int), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    // reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString13", ReportFieldName = "Company", ReportDataType = typeof(string), DbColumnName = "CompanyID", DbJoinColumnName = "CompanyName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOnGrid = true, IsManualGroupBy = false });
                    // reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString14", ReportFieldName = "DocumentID", ReportDataType = typeof(string), DbColumnName = "DocumentID", ValueDataType = typeof(int), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Deposited Bank", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = true, IsNotDisplayedOnGrid = true });
                    //Decimal Fields

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 11, 1, 2);
                #endregion
                #endregion

                #region Ledger View
                case "RptLedgerView":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    //String Fields
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "ReferenceDocumentNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = true, IsManualGroupBy = true, IsSelectionField = true, IsMandatoryField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Transaction Type", ReportDataType = typeof(string), DbColumnName = "DocumentID", DbJoinColumnName = "FormText", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = false, IsMandatoryField = true, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Ledger Code", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = false, DbJoinColumnName = "LedgerCode", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Ledger Name", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = true, DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Company", ReportDataType = typeof(string), DbColumnName = "CompanyID", DbJoinColumnName = "CompanyName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsConditionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = false, IsManualGroupBy = false, IsNotDisplayedOrderBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Transaction Location", ReportDataType = typeof(string), DbColumnName = "ReferenceLocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Remark", ReportDataType = typeof(string), DbColumnName = "Remark", ValueDataType = typeof(string), IsJoinField = true, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsMandatoryField = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Job Class", ReportDataType = typeof(string), DbColumnName = "JobClassID", DbJoinColumnName = "JobClassName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsSelectionField = true, IsJoinField = true, IsConditionField = true, IsNotDisplayedOrderBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Cheque No", ReportDataType = typeof(string), DbColumnName = "ChequeNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString12", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString13", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString14", ReportFieldName = "Cost Centre", ReportDataType = typeof(string), DbColumnName = "CostCentreID", DbJoinColumnName = "CostCentreName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString15", ReportFieldName = "Cheque Date", ReportDataType = typeof(string), DbColumnName = "PaymentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = false, IsManualGroupBy = false, IsNotDisplayedOrderBy = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString18", ReportFieldName = "Supplier", ReportDataType = typeof(string), DbColumnName = "SupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString19", ReportFieldName = "Customer", ReportDataType = typeof(string), DbColumnName = "CustomerID", DbJoinColumnName = "CustomerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString20", ReportFieldName = "Logistic Supplier", ReportDataType = typeof(string), DbColumnName = "LgsSupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString21", ReportFieldName = "Loyalty Customer", ReportDataType = typeof(string), DbColumnName = "LoyaltyCustomerID", DbJoinColumnName = "CustomerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString22", ReportFieldName = "Employee", ReportDataType = typeof(string), DbColumnName = "EmployeeID", DbJoinColumnName = "EmployeeName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString25", ReportFieldName = "DrCrType", ReportDataType = typeof(string), DbColumnName = "DrCrType", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString26", ReportFieldName = "LedgerID", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", ValueDataType = typeof(long), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString27", ReportFieldName = "DocumentID", ReportDataType = typeof(string), DbColumnName = "DocumentID", ValueDataType = typeof(int), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = true, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });

                    //Decimal Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Debit", ReportDataType = typeof(decimal), DbColumnName = "DebitAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsColumnTotal = true, IsNotDisplayedOrderBy = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Credit", ReportDataType = typeof(decimal), DbColumnName = "CreditAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsColumnTotal = true, IsNotDisplayedOrderBy = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Balance", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = false, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "LedgerID", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", ValueDataType = typeof(long), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);
                #endregion

                #region Transaction View
                case "RptTransactionView":
                    reportDatStructList = new List<Common.ReportDataStruct>();

                    //String Fields
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList = new List<Common.ReportDataStruct>();
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString1", ReportFieldName = "Document No", ReportDataType = typeof(string), DbColumnName = "ReferenceDocumentNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = true, IsConditionField = true, IsManualGroupBy = false, IsSelectionField = true, IsMandatoryField = true, IsNotDisplayedOrderBy = false, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString2", ReportFieldName = "Transaction Type", ReportDataType = typeof(string), DbColumnName = "DocumentID", DbJoinColumnName = "FormText", IsConditionNameJoined = true, ValueDataType = typeof(int), IsJoinField = true, IsGroupBy = true, IsMandatoryField = true, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = false, IsDetailView = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString3", ReportFieldName = "Ledger Code", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = false, DbJoinColumnName = "LedgerCode", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = false, IsGroupBy = true, IsNotDisplayedOrderBy = false, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString4", ReportFieldName = "Ledger Name", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", IsConditionNameJoined = true, DbJoinColumnName = "LedgerName", ValueDataType = typeof(long), IsJoinField = true, IsSelectionField = true, IsConditionField = true, IsMandatoryField = false, IsGroupBy = true, IsNotDisplayedOrderBy = false, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString5", ReportFieldName = "Company", ReportDataType = typeof(string), DbColumnName = "CompanyID", DbJoinColumnName = "CompanyName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsConditionField = true, IsNotDisplayedOrderBy = false, IsGroupBy = true, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString6", ReportFieldName = "Location", ReportDataType = typeof(string), DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsNotDisplayedOrderBy = false, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString7", ReportFieldName = "Date", ReportDataType = typeof(string), DbColumnName = "DocumentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = false, IsManualGroupBy = false, IsNotDisplayedOrderBy = true, IsDetailView = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "Transaction Location", ReportDataType = typeof(string), DbColumnName = "ReferenceLocationID", DbJoinColumnName = "LocationName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsNotDisplayedOrderBy = true, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString9", ReportFieldName = "Remark", ReportDataType = typeof(string), DbColumnName = "Remark", ValueDataType = typeof(string), IsJoinField = true, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsMandatoryField = false, IsNotDisplayedOrderBy = true, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString10", ReportFieldName = "Job Class", ReportDataType = typeof(string), DbColumnName = "JobClassID", DbJoinColumnName = "JobClassName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsSelectionField = true, IsJoinField = true, IsConditionField = true, IsNotDisplayedOrderBy = false, IsGroupBy = true, IsDetailView = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString11", ReportFieldName = "Cheque No", ReportDataType = typeof(string), DbColumnName = "ChequeNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString12", ReportFieldName = "Created User", ReportDataType = typeof(string), DbColumnName = "CreatedUser", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = true, IsNotDisplayedOrderBy = true, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString13", ReportFieldName = "Reference", ReportDataType = typeof(string), DbColumnName = "ReferenceNo", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = true, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString14", ReportFieldName = "Cost Centre", ReportDataType = typeof(string), DbColumnName = "CostCentreID", DbJoinColumnName = "CostCentreName", IsConditionNameJoined = true, ValueDataType = typeof(int), IsSelectionField = true, IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsNotDisplayedOrderBy = false, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString15", ReportFieldName = "Cheque Date", ReportDataType = typeof(string), DbColumnName = "PaymentDate", ValueDataType = typeof(DateTime), IsSelectionField = true, IsConditionField = true, IsGroupBy = false, IsManualGroupBy = false, IsNotDisplayedOrderBy = true, IsDetailView = true });

                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString18", ReportFieldName = "Supplier", ReportDataType = typeof(string), DbColumnName = "SupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = false, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString19", ReportFieldName = "Customer", ReportDataType = typeof(string), DbColumnName = "CustomerID", DbJoinColumnName = "CustomerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = false });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString20", ReportFieldName = "Logistic Supplier", ReportDataType = typeof(string), DbColumnName = "LgsSupplierID", DbJoinColumnName = "SupplierName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = true, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString21", ReportFieldName = "Loyalty Customer", ReportDataType = typeof(string), DbColumnName = "LoyaltyCustomerID", DbJoinColumnName = "CustomerName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = false, IsConditionField = true, IsSelectionField = false, IsNotDisplayedOrderBy = false, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString22", ReportFieldName = "Employee", ReportDataType = typeof(string), DbColumnName = "EmployeeID", DbJoinColumnName = "EmployeeName", IsConditionNameJoined = true, ValueDataType = typeof(long), IsJoinField = true, IsGroupBy = true, IsConditionField = true, IsSelectionField = true, IsNotDisplayedOrderBy = false, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString25", ReportFieldName = "DrCrType", ReportDataType = typeof(string), DbColumnName = "DrCrType", ValueDataType = typeof(string), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString26", ReportFieldName = "LedgerID", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", ValueDataType = typeof(long), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString27", ReportFieldName = "DocumentID", ReportDataType = typeof(string), DbColumnName = "DocumentID", ValueDataType = typeof(int), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false, IsManualGroupBy = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true, IsDetailView = true });

                    //Decimal Fields
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal1", ReportFieldName = "Debit", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsColumnTotal = true, IsNotDisplayedOrderBy = true, IsDetailView = true });
                    reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal2", ReportFieldName = "Credit", ReportDataType = typeof(decimal), DbColumnName = "CreditAmount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsColumnTotal = true, IsNotDisplayedOrderBy = true, IsDetailView = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal3", ReportFieldName = "Balance", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = true, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOrderBy = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldDecimal4", ReportFieldName = "Amount", ReportDataType = typeof(decimal), DbColumnName = "Amount", ValueDataType = typeof(decimal), IsSelectionField = false, IsConditionField = false, IsGroupBy = false, IsNotDisplayedOnGrid = true, IsNotDisplayedOrderBy = true });
                    //reportDatStructList.Add(new Common.ReportDataStruct() { ReportField = "FieldString8", ReportFieldName = "LedgerID", ReportDataType = typeof(string), DbColumnName = "AccLedgerAccountID", ValueDataType = typeof(long), IsJoinField = false, IsGroupBy = false, IsConditionField = false, IsSelectionField = false });

                    return frmReprotGenerator = new FrmReprotGenerator(autoGenerateInfo, reportDatStructList, 7, 4, 8);
                #endregion
                #endregion

                default:
                    return null;
            }
        }

        public ArrayList GetSelectionData(Common.ReportDataStruct reportDatStruct, AutoGenerateInfo autoGenerateInfo)
        {
            switch (autoGenerateInfo.FormName)
            {

                #region Account transactions


                case "FrmPayment":
                    AccPaymentService accPaymentService = new AccPaymentService();
                    return accPaymentService.GetSelectionData(reportDatStruct, autoGenerateInfo);

                case "FrmReceipt":
                    AccPaymentService accPaymentServiceRec = new AccPaymentService();
                    return accPaymentServiceRec.GetSelectionData(reportDatStruct, autoGenerateInfo);

              
                #endregion

                #region Account reports

            
                #region Statement
                case "RptSupplierStatement":
                    //AccGlTransactionService supplierStatementService = new AccGlTransactionService();
                    //return supplierStatementService.GetStatementSelectionData(reportDatStruct, autoGenerateInfo);
                    AccPaymentService accSupplierStatementService = new AccPaymentService();
                    return accSupplierStatementService.GetStatementSelectionData(reportDatStruct, autoGenerateInfo);
                case "RptCustomerStatement":
                    //AccGlTransactionService supplierStatementService = new AccGlTransactionService();
                    //return supplierStatementService.GetStatementSelectionData(reportDatStruct, autoGenerateInfo);
                    AccPaymentService accCustomerStatementService = new AccPaymentService();
                    return accCustomerStatementService.GetStatementSelectionData(reportDatStruct, autoGenerateInfo);
                #endregion

          
                #endregion

                default:
                    return null;
            }
        }

        public DataTable GetResultData(List<Common.ReportConditionsDataStruct> reportConditionsDataStructList, List<Common.ReportDataStruct> reportDataStructList, List<Common.ReportDataStruct> reportGroupDataStructList, List<Common.ReportDataStruct> reportOrderByDataStructList, AutoGenerateInfo autoGenerateInfo)
        {
            switch (autoGenerateInfo.FormName)
            {


     
                #region Account reports
                
                case "RptReceiptsRegister":
                    AccPaymentService accReceiptsServiceReceiptsRegister = new AccPaymentService();
                    return accReceiptsServiceReceiptsRegister.GetReceiptsRegisterDataTable(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);

  
 
                #endregion

                default:
                    return null;
            }
        }

        public string GetConditionValue(Common.ReportDataStruct reportDataStruct, string dataValue)
        {
            string conditionValue = string.Empty;
            switch (reportDataStruct.DbColumnName.Trim())
            {
                case "LocationID":
                case "ReferenceLocationID":
                    LocationService locationService = new LocationService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    {
                        if (reportDataStruct.DbColumnName.Trim() == "LocationCode")
                        {
                            conditionValue = locationService.GetLocationsByCode(dataValue.Trim()).LocationCode.ToString();
                        }
                        else
                        {
                            conditionValue = locationService.GetLocationsByID(int.Parse(dataValue.Trim())).LocationID.ToString();
                        }
                    }
                    else
                    { conditionValue = locationService.GetLocationsByName(dataValue.Trim()).LocationName.ToString(); }
                    break;

                case "CostCentreID":
                    CostCentreService costCentreService = new CostCentreService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    {
                        if (reportDataStruct.DbColumnName.Trim() == "CostCentreCode")
                        {
                            conditionValue = costCentreService.GetCostCentresByCode(dataValue.Trim()).CostCentreCode.ToString();
                        }
                        else
                        {
                            conditionValue = costCentreService.GetCostCentresByID(int.Parse(dataValue.Trim())).CostCentreID.ToString();
                        }
                    }
                    else
                    { conditionValue = costCentreService.GetCostCentresByName(dataValue.Trim()).CostCentreName.ToString(); }
                    break;
                case "CompanyID":
                    CompanyService companyService = new CompanyService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    {
                        if (reportDataStruct.DbJoinColumnName.Equals("CompanyCode"))
                        { conditionValue = companyService.GetCompaniesByCode(dataValue.Trim()).CompanyCode.ToString(); }
                        else if (reportDataStruct.DbJoinColumnName.Equals("CompanyName"))
                        { conditionValue = companyService.GetCompaniesByName(dataValue.Trim()).CompanyName.ToString(); }
                        else
                        { conditionValue = companyService.GetCompaniesByID(Common.ConvertStringToInt(dataValue.Trim())).CompanyID.ToString(); }
                    }
                    else
                    { conditionValue = companyService.GetCompaniesByName(dataValue.Trim()).CompanyName.ToString(); }
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
                    EmployeeService employeeService = new EmployeeService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = employeeService.GetEmployeesByCode(dataValue.Trim()).EmployeeID.ToString(); }
                    else
                    { conditionValue = employeeService.GetEmployeesByName(dataValue.Trim()).EmployeeName.ToString(); }
                    break;
                case "LoyaltyCustomerID":
                    LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = loyaltyCustomerService.GetLoyaltyCustomerByCode(dataValue.Trim()).CustomerId.ToString(); }
                    else
                    { conditionValue = loyaltyCustomerService.GetLoyaltyCustomerByName(dataValue.Trim()).CustomerName.ToString(); }
                    break;
                case "AccLedgerAccountID":
                    AccLedgerAccountService accLedgerAccountService1 = new AccLedgerAccountService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    {
                        if (reportDataStruct.DbJoinColumnName.Equals("LedgerCode"))
                        { conditionValue = accLedgerAccountService1.GetAllAccLedgerAccountByCode(dataValue.Trim()).LedgerCode.ToString(); }
                        if (reportDataStruct.DbJoinColumnName.Equals("LedgerName"))
                        { conditionValue = accLedgerAccountService1.GetAllAccLedgerAccountByName(dataValue.Trim()).LedgerName.ToString(); }
                        //else
                        //{ conditionValue = accLedgerAccountService1.GetActiveUnlockedAccLedgerAccountByID(dataValue.Trim()).AccLedgerAccountID.ToString(); }
                    }
                    else
                    { conditionValue = accLedgerAccountService1.GetAllAccLedgerAccountByName(dataValue.Trim()).LedgerName.ToString(); }
                    break;

                case "PettyCashLedgerID":
                    AccLedgerAccountService accLedgerAccountService = new AccLedgerAccountService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    {
                        if (reportDataStruct.DbJoinColumnName.Equals("LedgerCode"))
                        { conditionValue = accLedgerAccountService.GetAccLedgerAccountByCode(dataValue.Trim(), (int)LookUpAccountType.PettyCash).LedgerCode.ToString(); }
                        else
                        { conditionValue = accLedgerAccountService.GetAccLedgerAccountByID(Common.ConvertStringToLong(dataValue.Trim()), (int)LookUpAccountType.PettyCash).AccLedgerAccountID.ToString(); }
                    }
                    else
                    { conditionValue = accLedgerAccountService.GetAccLedgerAccountByName(dataValue.Trim(), (int)LookUpAccountType.PettyCash).LedgerName.ToString(); }
                    break;

                case "DocumentID":
                    conditionValue = AutoGenerateInfoService.GetAutoGenerateInfoByFormText(dataValue.Trim()).FormText.ToString();

                    break;

                case "SupplierID":
                    SupplierService supplierService = new SupplierService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = supplierService.GetSupplierByCode(dataValue.Trim()).SupplierCode.ToString(); }
                    else
                    { conditionValue = supplierService.GetSupplierByName(dataValue.Trim()).SupplierName.ToString(); }
                    break;

                case "LgsSupplierID":
                    LgsSupplierService lgssupplierService = new LgsSupplierService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = lgssupplierService.GetSupplierByName(dataValue.Trim()).LgsSupplierID.ToString(); }
                    else
                    { conditionValue = lgssupplierService.GetSupplierByName(dataValue.Trim()).SupplierName.ToString(); }
                    break;

                case "EmployeeID":
                    EmployeeService employeeServiceEmp = new EmployeeService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = employeeServiceEmp.GetEmployeesByName(dataValue.Trim()).EmployeeID.ToString(); }
                    else
                    { conditionValue = employeeServiceEmp.GetEmployeesByName(dataValue.Trim()).EmployeeName.ToString(); }
                    break;

                case "CustomerID":
                    CustomerService customerService = new CustomerService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    { conditionValue = customerService.GetCustomersByName(dataValue.Trim()).CustomerID.ToString(); }
                    else
                    { conditionValue = customerService.GetCustomersByName(dataValue.Trim()).CustomerName.ToString(); }
                    break;
                case "JobClassID":
                    JobClassService jobClassService = new JobClassService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    {
                        if (reportDataStruct.DbJoinColumnName.Equals("JobClassCode"))
                        { conditionValue = jobClassService.GetJobClassByCode(dataValue.Trim()).JobClassCode.ToString(); }
                        else
                        { conditionValue = jobClassService.GetJobsClassByID(Common.ConvertStringToLong(dataValue.Trim())).JobClassID.ToString(); }
                    }
                    else
                    { conditionValue = jobClassService.GetJobClassByName(dataValue.Trim()).JobClassName.ToString(); }
                    break;

                case "PeriodID":
                    LookUpReferenceService lookUpReferenceTitleTypeService = new LookUpReferenceService();
                    string slabPeriodType = ((int)LookUpReference.SlabPeriod).ToString();
                    conditionValue = lookUpReferenceTitleTypeService.GetLookUpReferenceByValue(slabPeriodType, dataValue.Trim()).LookupKey.ToString();
                    break;
                case "BankID":
                    BankService bankService = new BankService();
                    if (!reportDataStruct.IsConditionNameJoined)
                    {
                        if (reportDataStruct.DbJoinColumnName.Equals("BankCode"))
                        { conditionValue = bankService.GetBankByCode(dataValue.Trim()).BankCode.ToString(); }
                        else if (reportDataStruct.DbJoinColumnName.Equals("BankName"))
                        { conditionValue = bankService.GetBankByName(dataValue.Trim()).BankName.ToString(); }
                        else
                        { conditionValue = bankService.GetBankByID(Common.ConvertStringToLong(dataValue.Trim())).BankID.ToString(); }
                    }
                    else
                    { conditionValue = bankService.GetBankByName(dataValue.Trim()).BankName.ToString(); }
                    break;
                case "AccountStatus":

                    conditionValue = dataValue;
                    break;
                default:
                    break;
            }

            return conditionValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportData"></param>
        /// <returns></returns>
        private DataTable SetReportDataTableHeadersForReport(DataTable reportData)
        {

            int stringColIndex = 0, decimalColIndex = 0;
            string stringColumnName = "FieldString";
            string decimalColumnName = "FieldDecimal";
            foreach (DataColumn col in reportData.Columns)
            {
                if (col.ColumnName.Contains(stringColumnName))
                {
                    col.ColumnName = stringColumnName + (stringColIndex + 1).ToString();
                    stringColIndex++;
                }

                if (col.ColumnName.Contains(decimalColumnName))
                {
                    col.ColumnName = decimalColumnName + (decimalColIndex + 1).ToString();
                    decimalColIndex++;
                }
            }
            return reportData;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="accRptGroupedDetails"></param>
        /// <param name="dtReportData"></param>
        /// <param name="dtReportConditions"></param>
        /// <param name="reportDataStructList"></param>
        /// <param name="autoGenerateInfo"></param>
        /// <returns></returns>
        private AccRptGroupedDetailsTemplate ViewGroupedReport(AccRptGroupedDetailsTemplate accRptGroupedDetails, DataTable dtReportData, DataTable dtReportConditions, List<Common.ReportDataStruct> reportDataStructList, AutoGenerateInfo autoGenerateInfo, bool viewGroupRowCount = false)
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
                        accRptGroupedDetails.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStruct.ReportFieldName.Trim() + "'";
                        sr++;
                        groupingFields = string.IsNullOrEmpty(groupingFields) ? (reportDataStruct.ReportFieldName.Trim()) : (groupingFields + "/ " + reportDataStruct.ReportFieldName.Trim());
                    }

                    if (reportDataStruct.ReportDataType.Equals(typeof(decimal)))
                    {
                        strFieldName = "st" + dc;
                        accRptGroupedDetails.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStruct.ReportFieldName.Trim() + "'";
                        dc++;
                    }
                }
            }

            #endregion

            // Re arrange data table header columns for report
            dtArrangedReportData = dtReportData.Copy();
            dtReportData = null;
            dtArrangedReportData = ConvertDateTimeFieldsToStringFields(SetReportDataTableHeadersForReport(dtArrangedReportData));

            accRptGroupedDetails.SetDataSource(dtArrangedReportData);
            accRptGroupedDetails.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
            accRptGroupedDetails.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
            accRptGroupedDetails.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            accRptGroupedDetails.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            accRptGroupedDetails.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            accRptGroupedDetails.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            accRptGroupedDetails.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            accRptGroupedDetails.DataDefinition.FormulaFields["GroupNames"].Text = "'" + (string.IsNullOrEmpty(groupingFields) ? "" : groupingFields) + "'";
            accRptGroupedDetails.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";
            accRptGroupedDetails.SetParameterValue("prmGroupRowCount", viewGroupRowCount);

            #region Group By

            int ix = 0;
            // Set report group field values
            for (int i = 0; i < dtArrangedReportData.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FieldString")).Count(); i++)
            {
                if (i < accRptGroupedDetails.DataDefinition.Groups.Count)
                {
                    accRptGroupedDetails.DataDefinition.Groups[i].ConditionField = accRptGroupedDetails.Database.Tables[0].Fields[string.Concat("FieldString", (i + 1).ToString())];
                    ix++;
                }
            }

            // Set report group field values * decimal field
            for (int i = 0; i < dtArrangedReportData.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FieldDecimal")).Count(); i++)
            {
                if (i < accRptGroupedDetails.DataDefinition.Groups.Count)
                {
                    accRptGroupedDetails.DataDefinition.Groups[ix].ConditionField = accRptGroupedDetails.Database.Tables[0].Fields[string.Concat("FieldDecimal", (i + 1).ToString())];
                    ix++;
                }
            }

            // Set parameter select field values
            for (int i = 0; i < accRptGroupedDetails.DataDefinition.Groups.Count; i++)
            {
                if (accRptGroupedDetails.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                {
                    if (i < dtArrangedReportData.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FieldString")).Count())
                    {
                        accRptGroupedDetails.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), true);
                    }
                    else
                    {
                        accRptGroupedDetails.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                    }
                }
            }

            #endregion

            return accRptGroupedDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accRptDetailsTemplate"></param>
        /// <param name="dtReportData"></param>
        /// <param name="dtReportConditions"></param>
        /// <param name="reportDataStructList"></param>
        /// <param name="autoGenerateInfo"></param>
        /// <returns></returns>
        private AccRptDetailsTemplate ViewUnGroupedReport(AccRptDetailsTemplate accRptDetailsTemplate, DataTable dtReportData, DataTable dtReportConditions, List<Common.ReportDataStruct> reportDataStructList, AutoGenerateInfo autoGenerateInfo)
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
                        accRptDetailsTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
                        sr++;
                    }

                    if (item.ReportDataType.Equals(typeof(decimal)))
                    {
                        strFieldName = "st" + dc;
                        accRptDetailsTemplate.DataDefinition.FormulaFields[strFieldName].Text = "'" + item.ReportFieldName.Trim() + "'";
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

            accRptDetailsTemplate.SetDataSource(dtArrangedReportData);
            accRptDetailsTemplate.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
            accRptDetailsTemplate.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
            accRptDetailsTemplate.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            accRptDetailsTemplate.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            accRptDetailsTemplate.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            accRptDetailsTemplate.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            accRptDetailsTemplate.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            accRptDetailsTemplate.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";

            // Set parameter sum fields
            for (int i = 0; i < accRptDetailsTemplate.ParameterFields.Count; i++)
            {
                if (accRptDetailsTemplate.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter) && newSumFieldsIndexesList.Contains(i + 1) && accRptDetailsTemplate.ParameterFields[i].Name.StartsWith("prmSumFieldDecimal"))
                {
                    accRptDetailsTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), true);
                }
                else
                {
                    accRptDetailsTemplate.SetParameterValue("prmSumFieldDecimal" + (i + 1).ToString(), false);
                }
            }

            return accRptDetailsTemplate;

        }

        private AccRptReferenceGroupedDetailsTemplate ViewGroupedReport(AccRptReferenceGroupedDetailsTemplate accRptGroupedDetails, DataTable dtReportData, DataTable dtReportConditions, List<Common.ReportDataStruct> reportDataStructList, AutoGenerateInfo autoGenerateInfo, bool viewGroupRowCount = false)
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
                        accRptGroupedDetails.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStruct.ReportFieldName.Trim() + "'";
                        sr++;
                        groupingFields = string.IsNullOrEmpty(groupingFields) ? (reportDataStruct.ReportFieldName.Trim()) : (groupingFields + "/ " + reportDataStruct.ReportFieldName.Trim());
                    }

                    if (reportDataStruct.ReportDataType.Equals(typeof(decimal)))
                    {
                        strFieldName = "st" + dc;
                        accRptGroupedDetails.DataDefinition.FormulaFields[strFieldName].Text = "'" + reportDataStruct.ReportFieldName.Trim() + "'";
                        dc++;
                    }
                }
            }

            #endregion

            // Re arrange data table header columns for report
            dtArrangedReportData = dtReportData.Copy();
            dtReportData = null;
            dtArrangedReportData = ConvertDateTimeFieldsToStringFields(SetReportDataTableHeadersForReport(dtArrangedReportData));

            accRptGroupedDetails.SetDataSource(dtArrangedReportData);
            accRptGroupedDetails.Subreports["RptReportConditions.rpt"].SetDataSource(dtReportConditions);
            accRptGroupedDetails.SummaryInfo.ReportTitle = autoGenerateInfo.FormText;
            accRptGroupedDetails.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            accRptGroupedDetails.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            accRptGroupedDetails.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            accRptGroupedDetails.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            accRptGroupedDetails.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            accRptGroupedDetails.DataDefinition.FormulaFields["GroupNames"].Text = "'" + (string.IsNullOrEmpty(groupingFields) ? "" : groupingFields) + "'";
            accRptGroupedDetails.DataDefinition.FormulaFields["DateFormat"].Text = "'" + Common.DateFormat + "'";
            accRptGroupedDetails.SetParameterValue("prmGroupRowCount", viewGroupRowCount);

            #region Group By

            int ix = 0;
            // Set report group field values
            for (int i = 0; i < dtArrangedReportData.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FieldString")).Count(); i++)
            {
                if (i < accRptGroupedDetails.DataDefinition.Groups.Count)
                {
                    accRptGroupedDetails.DataDefinition.Groups[i].ConditionField = accRptGroupedDetails.Database.Tables[0].Fields[string.Concat("FieldString", (i + 1).ToString())];
                    ix++;
                }
            }

            // Set report group field values * decimal field
            ////for (int i = 0; i < dtArrangedReportData.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FieldDecimal")).Count(); i++)
            ////{
            ////    if (i < accRptGroupedDetails.DataDefinition.Groups.Count)
            ////    {
            ////        accRptGroupedDetails.DataDefinition.Groups[ix].ConditionField = accRptGroupedDetails.Database.Tables[0].Fields[string.Concat("FieldDecimal", (i + 1).ToString())];
            ////        ix++;
            ////    }
            ////}

            // Set parameter select field values
            for (int i = 0; i < accRptGroupedDetails.DataDefinition.Groups.Count; i++)
            {
                if (accRptGroupedDetails.ParameterFields[i].ParameterValueType.Equals(ParameterValueKind.BooleanParameter))
                {
                    if (i < dtArrangedReportData.Columns.Cast<DataColumn>().Where(c => c.ColumnName.StartsWith("FieldString")).Count())
                    {
                        accRptGroupedDetails.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), true);
                    }
                    else
                    {
                        accRptGroupedDetails.SetParameterValue("prmSelectGroup" + (i + 1).ToString(), false);
                    }
                }
            }

            #endregion

            return accRptGroupedDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtReportData"></param>
        /// <returns></returns>
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


        private ReportSources SetReportSourcesForReport(DataTable reportData, List<Common.ReportDataStruct> reportDataStructList)
        {
            ReportSources reportSources = new ReportSources();
            ArrayList originalSumFields = new ArrayList();
            ArrayList newIndexesList = new ArrayList();


            int stringColIndex = 0, decimalColIndex = 0;
            string stringColumnName = "FieldString";
            string decimalColumnName = "FieldDecimal";

            originalSumFields.AddRange(reportDataStructList.Where(d => d.ReportDataType.Equals(typeof(decimal)) && d.IsColumnTotal.Equals(true)).Select(d => d.ReportField).ToList());

            List<Common.ReportDataStruct> reportUnOrderDataStructList = reportDataStructList.Where(d => d.IsNotDisplayedOnGrid).ToList();

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

        private Common.ReportDataStruct GetSelectedReportDataStruct(List<Common.ReportDataStruct> reportUnOrderDataStructList, string selectedReportField)
        {
            Common.ReportDataStruct reportDataStruct = new Common.ReportDataStruct();

            foreach (Common.ReportDataStruct reportDataStructItem in reportUnOrderDataStructList)
            {

                if (reportDataStructItem.ReportField.Trim().Equals(selectedReportField.Trim()))// || reportDataStructItem.ReportFieldName.Trim().Equals(selectedRepoertFieldName.Trim().Replace(reportDataStructItem.ComparisonFieldNamePortion.Trim(), "")))
                {
                    reportDataStruct = reportDataStructItem;
                    return reportDataStruct;
                }
            }

            return reportDataStruct;
        }

    }
}
