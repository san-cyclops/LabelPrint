using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ERP.Service;
using ERP.Domain;
using ERP.UI.Windows;
using ERP.Utility;
using System.Collections;
using System.Reflection;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI.Export.ExcelML;
using System.IO;
using Telerik.Data;
using Telerik.Pivot.Core;
using Telerik.Pivot.Core.Aggregates;
using System.Text;
using Telerik.WinControls.Data;
using System.Threading;
using ERP.Report.Com;
using ERP.Report.CRM;
using ERP.Report.GV;
using ERP.Report.Inventory;
using ERP.Report.Logistic;
using ERP.Report.Restaurant;

namespace ERP.Report
{
    public partial class FrmReprotGenerator : FrmBaseReportsForm
    {
        class ViewDefinitionInfo
        {
            public List<string> Columns;
            public IGridViewDefinition ViewDefinition;
            public int RowHeight = 30;
            public int HeaderHeight = 30;
        }

        ViewDefinitionInfo tableViewInfo;
        ViewDefinitionInfo htmlViewInfo;
        ViewDefinitionInfo columnGroupViewInfo;
        ViewDefinitionInfo currentViewInfo;

        string layout = string.Empty;

        LocalDataSourceProvider provider;
        Telerik.WinControls.UI.Export.PivotExportToExcelML exporter;

        Thread thread;

        int maxStringFields = 0; // maximum string fields can be displayed in the report
        int maxDecimalFields = 0; // maximum decimal fields can be displayed in the report
        int maxGroups = 0; // maximum groups can be displayed in the report
        //private bool isMdiChild = true;
        //private bool isCrossTabReport = false;
        Color comparisonColor = Color.LightBlue;
        Color DiffColor = Color.LightSteelBlue;

        int documentID;

        string strComparisonFieldNamePortion = string.Empty;

        ArrayList stringField = new ArrayList();           // Eg:- {"Doc.No", "Date", "Pro.Code","Pro.Name"};
        ArrayList decimalField = new ArrayList();         //Eg:-  {"Net Amt","P.Size","F.Qty","C.Price", "Or.Qty"};
        ArrayList decimalFieldSum = new ArrayList();
        ArrayList groupbyField = new ArrayList();
        ArrayList columnTotalField = new ArrayList();
        ArrayList rowTotalField = new ArrayList();
        ArrayList conditionField = new ArrayList();
        ArrayList orderByField = new ArrayList();

        Common.ReportDataStruct reportDataStructTemp;
        DataGridViewColumn sortedColumn = new DataGridViewColumn();
        ListSortDirection sortedDirection = new ListSortDirection();

        List<Common.ReportDataStruct> reportDatStructList = new List<Common.ReportDataStruct>();
        AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();

        private bool exportVisualSettings;

        UserPrivileges accessRights = new UserPrivileges();


        public FrmReprotGenerator()
        {

        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="pautoGenerateInfo"></param>
        /// <param name="pReportDatStructList"></param>
        public FrmReprotGenerator(AutoGenerateInfo pautoGenerateInfo, List<Common.ReportDataStruct> pReportDatStructList)
        {
            InitializeComponent();

            for (int i = 0; i < pReportDatStructList.Count; i++)
            {
                if (pReportDatStructList[i].IsSelectionField.Equals(true) && pReportDatStructList[i].ReportDataType.Equals(typeof(string)))
                { stringField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                if (pReportDatStructList[i].IsSelectionField.Equals(true) && pReportDatStructList[i].IsNotDisplayedOrderBy.Equals(false))
                { orderByField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }
                if (pReportDatStructList[i].IsSelectionField.Equals(true) && pReportDatStructList[i].ReportDataType.Equals(typeof(decimal)))
                { decimalField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                if (pReportDatStructList[i].IsConditionField.Equals(true))
                { conditionField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                if (pReportDatStructList[i].IsGroupBy.Equals(true))
                { groupbyField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                if (pReportDatStructList[i].IsColumnTotal.Equals(true))
                { columnTotalField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                if (pReportDatStructList[i].IsRowTotal.Equals(true))
                { rowTotalField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }
            }


            reportDatStructList = pReportDatStructList;
            autoGenerateInfo = pautoGenerateInfo;

            Text = Text + " - " + pautoGenerateInfo.FormText;
            documentID = autoGenerateInfo.DocumentID;
            cmbValueFrom.BringToFront();
            cmbValueTo.BringToFront();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pautoGenerateInfo"></param>
        /// <param name="pReportDatStructList"></param>
        /// <param name="pMaxStringFields"></param> maximum string fields can be displayed in the report
        /// <param name="pMaxDecimalFields"></param> maximum decimal fields can be displayed in the report
        public FrmReprotGenerator(AutoGenerateInfo pautoGenerateInfo, List<Common.ReportDataStruct> pReportDatStructList, int pMaxStringFields, int pMaxDecimalFields, int pMaxGroups)
        {
            InitializeComponent();

            for (int i = 0; i < pReportDatStructList.Count; i++)
            {
                if (pReportDatStructList[i].IsSelectionField.Equals(true) && pReportDatStructList[i].ReportDataType.Equals(typeof(string)))
                { stringField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                if (pReportDatStructList[i].IsSelectionField.Equals(true) && pReportDatStructList[i].IsNotDisplayedOrderBy.Equals(false))
                { orderByField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                if (pReportDatStructList[i].IsSelectionField.Equals(true) && pReportDatStructList[i].ReportDataType.Equals(typeof(decimal)))
                { decimalField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                if (pReportDatStructList[i].IsConditionField.Equals(true))
                {
                    conditionField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim());
                    if (pReportDatStructList[i].IsComparisonField.Equals(true))
                    {
                        conditionField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim() + pReportDatStructList[i].ComparisonFieldNamePortion.ToString().Trim());
                        strComparisonFieldNamePortion = pReportDatStructList[i].ComparisonFieldNamePortion.ToString().Trim();
                    }
                }

                if (pReportDatStructList[i].IsGroupBy.Equals(true))
                { groupbyField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                if (pReportDatStructList[i].IsColumnTotal.Equals(true))
                { columnTotalField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                if (pReportDatStructList[i].IsRowTotal.Equals(true))
                { rowTotalField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }
            }

            reportDatStructList = pReportDatStructList;
            autoGenerateInfo = pautoGenerateInfo;
            maxStringFields = pMaxStringFields;
            maxDecimalFields = pMaxDecimalFields;
            maxGroups = pMaxGroups;

            Text = Text + " - " + pautoGenerateInfo.FormText;
            documentID = autoGenerateInfo.DocumentID;
            cmbValueFrom.BringToFront();
            cmbValueTo.BringToFront();
        }



        #region Methods

        private void LoadFieldS()
        {

            ArrayList allValueType = new ArrayList();
            allValueType.AddRange(stringField);
            allValueType.AddRange(decimalField);

            //ArrayList allGroupBy = new ArrayList();
            //allGroupBy.AddRange(groupbyField);

            ArrayList allOrderBy = new ArrayList();
            //allOrderBy.AddRange(allValueType);
            allOrderBy.AddRange(orderByField);

            //ArrayList allRowTotal = new ArrayList();
            //allRowTotal.AddRange(rowTotalField);

            //ArrayList allColumnTotal = new ArrayList();
            //allColumnTotal.AddRange(columnTotalField);

            chkLstFieldSelectionStr.DataSource = stringField;
            chkLstFieldSelectionDes.DataSource = decimalField;
            chkLstGroupBy.DataSource = groupbyField;
            chkLstOrderBy.DataSource = allOrderBy;
            chkRowTotal.DataSource = rowTotalField;
            chklstColumnTotal.DataSource = columnTotalField;

            this.cmbValueType.SelectedValueChanged -= new System.EventHandler(this.cmbValueType_SelectedIndexChanged);
            //cmbValueType.SelectedIndexChanged -= new Telerik.WinControls.UI.Data.PositionChangedEventHandler(cmbValueType_SelectedIndexChanged);
            cmbValueType.DataSource = conditionField;
            cmbValueType.SelectedIndex = -1;
            //cmbValueType.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(cmbValueType_SelectedIndexChanged);
            this.cmbValueType.SelectedValueChanged += new System.EventHandler(this.cmbValueType_SelectedIndexChanged);
            // Loop through and set all to checked.

            this.chkLstFieldSelectionDes.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionDes_ItemCheck);
            for (int x = 0; x < ((maxDecimalFields <= chkLstFieldSelectionDes.Items.Count) ? maxDecimalFields : chkLstFieldSelectionDes.Items.Count); x++)
            {
                chkLstFieldSelectionDes.SetItemChecked(x, GetReportCheckedStatusByDataStruct(chkLstFieldSelectionDes.Items[x].ToString().Trim()));
            }
            this.chkLstFieldSelectionDes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionDes_ItemCheck);

            this.chkLstFieldSelectionStr.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionStr_ItemCheck);
            for (int x = 0; x < ((maxStringFields <= chkLstFieldSelectionStr.Items.Count) ? maxStringFields : chkLstFieldSelectionStr.Items.Count); x++)
            {
                chkLstFieldSelectionStr.SetItemChecked(x, GetReportCheckedStatusByDataStruct(chkLstFieldSelectionStr.Items[x].ToString().Trim()));
            }
            this.chkLstFieldSelectionStr.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionStr_ItemCheck);

            // Loop through and set first field to checked.
            this.chkLstOrderBy.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstOrderBy_ItemCheck);
            if (chkLstOrderBy.Items.Count > 0)//if (chkLstOrderBy.Items.Count >= 0)
            { chkLstOrderBy.SetItemChecked(0, true); }
            this.chkLstOrderBy.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstOrderBy_ItemCheck);

        }

        private void AllocateUserRights()
        {
            this.chkLstFieldSelectionStr.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionStr_ItemCheck);
            this.chkLstFieldSelectionDes.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionDes_ItemCheck);

            this.chkLstFieldSelectionStr.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionStr_ItemCheck);
            this.chkLstFieldSelectionDes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionDes_ItemCheck);

        }

        /// <summary>
        /// Validate Comparison Condition
        /// </summary>
        /// <returns></returns>
        private bool IsValidComparisonCondition()
        {
            if (cmbValueType.Text.Trim().Contains(strComparisonFieldNamePortion.Trim()) && !string.IsNullOrEmpty(strComparisonFieldNamePortion))
            {
                if (dgvValueRange.Rows.Cast<DataGridViewRow>().Any(r => r.Cells["ValueType"].Value.ToString().Trim().Equals(cmbValueType.Text.Replace(strComparisonFieldNamePortion.Trim(), string.Empty).Trim())))
                {
                    Toast.Show(this.Text, "Comparison condition", "", Toast.messageType.Information, Toast.messageAction.Invalid, "\nTo get comparison reports, Please enter the comparison condtion first");
                    return false;
                }
            }
            else
            {
                if (dgvValueRange.Rows.Cast<DataGridViewRow>().Any(r => r.Cells["ValueType"].Value.ToString().Trim().Equals(cmbValueType.Text.Trim() + strComparisonFieldNamePortion.Trim())))
                {
                    if (GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()).ValueDataType.Equals(typeof(DateTime)))
                    {
                        DateTime dtExistingFrom, dtExistingTo;
                        dtExistingFrom = DateTime.Parse(dgvValueRange.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["ValueType"].Value.ToString().Trim().Equals(cmbValueType.Text.Trim() + strComparisonFieldNamePortion.Trim()))
                                                                            .Select(v => v.Cells["ValueFrom"].Value.ToString()).FirstOrDefault());
                        dtExistingTo = DateTime.Parse(dgvValueRange.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["ValueType"].Value.ToString().Trim().Equals(cmbValueType.Text.Trim() + strComparisonFieldNamePortion.Trim()))
                                                                            .Select(v => v.Cells["ValueTo"].Value.ToString()).FirstOrDefault());

                        var existingDateRange = new Tuple<DateTime, DateTime>(dtExistingFrom, dtExistingTo);
                        var newDateRange = new Tuple<DateTime, DateTime>(DateTime.Parse(dtpDateFrom.Value.ToShortDateString()), DateTime.Parse(dtpDateTo.Value.ToShortDateString()));

                        if (Common.IsAnyDateRangeOverlap(existingDateRange, newDateRange))
                        {
                            Toast.Show(this.Text, "Entered " + cmbValueType.Text.Trim() + " Range", "", Toast.messageType.Information, Toast.messageAction.Invalid, "\nComparison ranges shouldn't be overlapped");
                            return false;
                        }

                        if (dtExistingTo >= DateTime.Parse(dtpDateFrom.Value.ToShortDateString()))
                        {
                            Toast.Show(this.Text, "Entered " + cmbValueType.Text.Trim() + " Range", "", Toast.messageType.Information, Toast.messageAction.Invalid, "\nComparison range shouldn't be lower than the other range");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Add Condition values into dgvValueRange
        /// </summary>
        private void AddConditions()
        {
            if (!IsValidComparisonCondition())
            { return; }

            foreach (DataGridViewRow drItem in dgvValueRange.Rows)
            {
                if (cmbValueType.Text.Trim().Equals(drItem.Cells["ValueType"].Value.ToString().Trim()))
                { dgvValueRange.Rows.Remove(drItem); }
            }

            dgvValueRange.Rows.Add();
            int row = dgvValueRange.Rows.Count - 1;

            if (GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()).ValueDataType.Equals(typeof(DateTime)))
            {
                dgvValueRange.Rows[row].Cells["ValueType"].Value = cmbValueType.Text.Trim();
                dgvValueRange.Rows[row].Cells["ValueFrom"].Value = dtpDateFrom.Value.ToShortDateString().Trim();
                dgvValueRange.Rows[row].Cells["ValueTo"].Value = dtpDateTo.Value.ToShortDateString().Trim();
            }
            else if (GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()).ValueDataType.Equals(typeof(decimal)))
            {
                dgvValueRange.Rows[row].Cells["ValueType"].Value = cmbValueType.Text.Trim();
                dgvValueRange.Rows[row].Cells["ValueFrom"].Value = txtValueFrom.Text.Trim();
                dgvValueRange.Rows[row].Cells["ValueTo"].Value = txtValueTo.Text.Trim();
            }
            else if (reportDataStructTemp.IsManualRecordFilter.Equals(true))
            {
                dgvValueRange.Rows[row].Cells["ValueType"].Value = cmbValueType.Text.Trim();
                dgvValueRange.Rows[row].Cells["ValueFrom"].Value = txtValue.Text.Trim();
                dgvValueRange.Rows[row].Cells["ValueTo"].Value = txtValue.Text.Trim();
            }
            else
            {
                dgvValueRange.Rows[row].Cells["ValueType"].Value = cmbValueType.Text.Trim();
                dgvValueRange.Rows[row].Cells["ValueFrom"].Value = cmbValueFrom.Text.Trim();
                dgvValueRange.Rows[row].Cells["ValueTo"].Value = cmbValueTo.Text.Trim();
            }

            if (IsComparisonReport())
            {
                ClearCheckedListBox(chkLstGroupBy);
                ClearCheckedListBox(chkLstFieldSelectionStr);
                ClearCheckedListBox(chkLstFieldSelectionDes);

                // Set comparison condtion color
                foreach (DataGridViewRow dgvRow in dgvValueRange.Rows)
                {
                    if (dgvRow.Cells["ValueType"].Value.ToString().Contains(strComparisonFieldNamePortion.Trim()))
                    {
                        dgvRow.DefaultCellStyle.BackColor = comparisonColor;
                    }
                }
            }
        }

        private void LoadSelectionData()
        {
            cmbValueFrom.DataSource = null;
            cmbValueTo.DataSource = null;
            lblValue.Text = "Value Between";

            reportDataStructTemp.IsManualRecordFilter = false;

            if (GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()).IsRecordFilterByGivenOption.Equals(true))
            {
                if (Toast.Show(this.Text, "Filter - By entered value ", "", Toast.messageType.Question, Toast.messageAction.General).Equals(DialogResult.Yes))
                {
                    reportDataStructTemp.IsManualRecordFilter = true;
                }
            }

            // Set Datetime Picker for date ranges
            if (GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()).ValueDataType.Equals(typeof(DateTime)))
            {
                cmbValueFrom.Visible = false;
                cmbValueTo.Visible = false;
                txtValueFrom.Text = string.Empty;
                txtValueTo.Text = string.Empty;
                txtValueFrom.Visible = false;
                txtValueTo.Visible = false;
                txtValue.Visible = false;
                dtpDateFrom.Visible = true;
                // dtpDateFrom.Size = new System.Drawing.Size(128, 21);
                dtpDateFrom.TabIndex = 5;

                dtpDateTo.Visible = true;
                // dtpDateTo.Size = new System.Drawing.Size(128, 21);
                dtpDateTo.TabIndex = 6;
            }
            else if (GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()).ValueDataType.Equals(typeof(decimal)))
            {
                cmbValueFrom.Visible = false;
                cmbValueTo.Visible = false;
                dtpDateFrom.Visible = false;
                dtpDateTo.Visible = false;

                txtValueFrom.Visible = true;
                //txtValueFrom.Size = new System.Drawing.Size(128, 21);
                txtValueFrom.TabIndex = 5;

                txtValueTo.Visible = true;
                //txtValueTo.Size = new System.Drawing.Size(128, 21);
                txtValueTo.TabIndex = 6;
            }
            else if (reportDataStructTemp.IsManualRecordFilter)
            {
                cmbValueFrom.Visible = false;
                cmbValueTo.Visible = false;
                dtpDateFrom.Visible = false;
                dtpDateTo.Visible = false;
                txtValueFrom.Visible = false;
                txtValueTo.Visible = false;

                lblValue.Text = "Value";
                txtValue.Visible = true;
                //txtValueFrom.Size = new System.Drawing.Size(128, 21);
                txtValue.TabIndex = 5;

                //txtValueTo.Size = new System.Drawing.Size(128, 21);
                //txtValueTo.TabIndex = 6;
            }
            else if (GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()).IsRecordFilterByOneOption.Equals(true))
            {
                dtpDateFrom.Visible = false;
                dtpDateTo.Visible = false;
                txtValueFrom.Text = string.Empty;
                txtValueTo.Text = string.Empty;
                txtValueFrom.Visible = false;
                txtValueTo.Visible = false;
                cmbValueFrom.Visible = true;
                cmbValueTo.Visible = false;

                #region Load selected data
                switch (autoGenerateInfo.ModuleType)
                {
                    case 1: //Common Summary Report
                        ComReportGenerator comReportGenerator = new ComReportGenerator();
                        //cmbValueFrom.tem
                        cmbValueFrom.DataSource = comReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = comReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    case 2: //Inventory Summary Report
                        InvReportGenerator invReportGenerator = new InvReportGenerator();
                        cmbValueTo.DataSource = invReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueFrom.DataSource = invReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    case 3: //Logistic Summary Report
                        LgsReportGenerator lgsReportGenerator = new LgsReportGenerator();
                        cmbValueFrom.DataSource = lgsReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = lgsReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    case 4: //CRM Summary Report
                        CrmReportGenerator crmReportGenerator = new CrmReportGenerator();
                        cmbValueFrom.DataSource = crmReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = crmReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    case 6: //Gift Voucher Summary Report
                        GvReportGenerator gvReportGenerator = new GvReportGenerator();
                        cmbValueTo.DataSource = gvReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueFrom.DataSource = gvReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    case 7: //POS Summary Report
                        InvReportGenerator posReportGenerator = new InvReportGenerator();
                        cmbValueTo.DataSource = posReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueFrom.DataSource = posReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    case 15: //Restaurant Summary Report
                        ResReportGenerator resReportGenerator = new ResReportGenerator();
                        cmbValueFrom.DataSource = resReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = resReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    default:
                        break;
                }
                #endregion
            }
            #region If not use pls remove below
            else if (reportDataStructTemp.IsRecordFilterByOneOption)
            {
                dtpDateFrom.Visible = false;
                dtpDateTo.Visible = false;
                txtValueFrom.Text = string.Empty;
                txtValueTo.Text = string.Empty;
                txtValueFrom.Visible = false;
                txtValueTo.Visible = false;
                cmbValueFrom.Visible = true;
                //cmbValueTo.Visible = true;

                #region Load selected data
                switch (autoGenerateInfo.ModuleType)
                {
                    case 1: //Common Summary Report
                        ComReportGenerator comReportGenerator = new ComReportGenerator();
                        cmbValueFrom.DataSource = comReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        //cmbValueTo.DataSource = comReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = cmbValueFrom.DataSource;
                        break;
                    case 2: //Inventory Summary Report
                        InvReportGenerator invReportGenerator = new InvReportGenerator();
                        cmbValueTo.DataSource = invReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        //cmbValueFrom.DataSource = invReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = cmbValueFrom.DataSource;
                        break;
                    case 3: //Logistic Summary Report
                        LgsReportGenerator lgsReportGenerator = new LgsReportGenerator();
                        cmbValueFrom.DataSource = lgsReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        //cmbValueTo.DataSource = lgsReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = cmbValueFrom.DataSource;
                        break;
                    case 4: //CRM Summary Report
                        CrmReportGenerator crmReportGenerator = new CrmReportGenerator();
                        cmbValueFrom.DataSource = crmReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        //cmbValueTo.DataSource = crmReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = cmbValueFrom.DataSource;
                        break;
                    case 6: //Gift Voucher Summary Report
                        GvReportGenerator gvReportGenerator = new GvReportGenerator();
                        cmbValueTo.DataSource = gvReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = cmbValueFrom.DataSource;
                        //cmbValueFrom.DataSource = gvReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    case 7: //POS Summary Report
                        InvReportGenerator posReportGenerator = new InvReportGenerator();
                        cmbValueTo.DataSource = posReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        //cmbValueFrom.DataSource = posReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = cmbValueFrom.DataSource;
                        break;
                    case 15: //Restuarent Summary Report
                        ResReportGenerator resReportGenerator = new ResReportGenerator();
                        cmbValueFrom.DataSource = resReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        //cmbValueTo.DataSource = comReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = cmbValueFrom.DataSource;
                        break;
                    default:
                        break;
                }
                #endregion
            }
            #endregion
            else
            {
                dtpDateFrom.Visible = false;
                dtpDateTo.Visible = false;
                txtValueFrom.Text = string.Empty;
                txtValueTo.Text = string.Empty;
                txtValueFrom.Visible = false;
                txtValueTo.Visible = false;
                cmbValueFrom.Visible = true;
                cmbValueTo.Visible = true;

                #region Load selected data
                switch (autoGenerateInfo.ModuleType)
                {
                    case 1: //Common Summary Report
                        ComReportGenerator comReportGenerator = new ComReportGenerator();
                        cmbValueFrom.DataSource = comReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = comReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    case 2: //Inventory Summary Report
                        InvReportGenerator invReportGenerator = new InvReportGenerator();
                        cmbValueTo.DataSource = invReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueFrom.DataSource = invReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    case 3: //Logistic Summary Report
                        LgsReportGenerator lgsReportGenerator = new LgsReportGenerator();
                        cmbValueFrom.DataSource = lgsReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = lgsReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    case 4: //CRM Summary Report
                        CrmReportGenerator crmReportGenerator = new CrmReportGenerator();
                        cmbValueFrom.DataSource = crmReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueTo.DataSource = crmReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    case 6: //Gift Voucher Summary Report
                        GvReportGenerator gvReportGenerator = new GvReportGenerator();
                        cmbValueTo.DataSource = gvReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueFrom.DataSource = gvReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    case 7: //POS Summary Report
                        InvReportGenerator posReportGenerator = new InvReportGenerator();
                        cmbValueTo.DataSource = posReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueFrom.DataSource = posReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    case 15:// Restaurant Summary Report
                        ResReportGenerator resReportGenerator = new ResReportGenerator();
                        cmbValueTo.DataSource = resReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        cmbValueFrom.DataSource = resReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);
                        break;
                    default:
                        break;
                }
                #endregion
            }
        }

        /// <summary>
        ///  Get ReportDataStruct of the selected report field
        /// </summary>
        /// <param name="selectedRepoertFieldName"></param>
        /// <returns></returns>
        private Common.ReportDataStruct GetSelectedReportDataStruct(string selectedRepoertFieldName)
        {
            Common.ReportDataStruct reportDataStruct = new Common.ReportDataStruct();

            foreach (Common.ReportDataStruct reportDataStructItem in reportDatStructList)
            {

                if (reportDataStructItem.ReportFieldName.Trim().Equals(selectedRepoertFieldName.Trim()))// || reportDataStructItem.ReportFieldName.Trim().Equals(selectedRepoertFieldName.Trim().Replace(reportDataStructItem.ComparisonFieldNamePortion.Trim(), "")))
                {
                    reportDataStruct = reportDataStructItem;
                    return reportDataStruct;
                }
                // for comparison fields
                if (reportDataStructItem.IsComparisonField)
                {
                    if (reportDataStructItem.ReportFieldName.Trim().Equals(selectedRepoertFieldName.Trim().Replace(reportDataStructItem.ComparisonFieldNamePortion.Trim(), "").Trim()))
                    {
                        reportDataStruct = reportDataStructItem;
                        return reportDataStruct;
                    }
                }
            }

            return reportDataStruct;
        }

        /// <summary>
        ///  Get ReportDataStruct of the selected report field
        /// </summary>
        /// <param name="selectedRepoertFieldName"></param>
        /// <returns></returns>
        private Common.ReportDataStruct GetReportGroupDataStruct(string selectedRepoertFieldName, bool groupStatus)
        {
            Common.ReportDataStruct reportDataStruct = new Common.ReportDataStruct();

            foreach (Common.ReportDataStruct reportDataStructItem in reportDatStructList)
            {
                if (reportDataStructItem.ReportFieldName.Trim().Equals(selectedRepoertFieldName.Trim()))
                {
                    reportDataStruct = reportDataStructItem;
                    reportDataStruct.IsResultGroupBy = groupStatus;
                    return reportDataStruct;
                }
            }

            return reportDataStruct;
        }

        /// <summary>
        ///  Get ReportDataStruct of the selected orderby report field
        /// </summary>
        /// <param name="selectedRepoertFieldName"></param>
        /// <returns></returns>
        private Common.ReportDataStruct GetReportOrderDataStruct(string selectedRepoertFieldName, bool orderStatus)
        {
            Common.ReportDataStruct reportDataStruct = new Common.ReportDataStruct();

            foreach (Common.ReportDataStruct reportDataStructItem in reportDatStructList)
            {
                if (reportDataStructItem.ReportFieldName.Trim().Equals(selectedRepoertFieldName.Trim()))
                {
                    reportDataStruct = reportDataStructItem;
                    reportDataStruct.IsResultOrderBy = orderStatus;
                    return reportDataStruct;
                }
            }

            return reportDataStruct;
        }

        /// <summary>
        ///  Get status of the default un-tick report field
        /// </summary>
        /// <param name="selectedRepoertFieldName"></param>
        /// <returns></returns>
        private bool GetReportCheckedStatusByDataStruct(string selectedRepoertFieldName)
        {
            bool fieldStatus = true;

            foreach (Common.ReportDataStruct reportDataStructItem in reportDatStructList)
            {
                if (reportDataStructItem.ReportFieldName.Trim().Equals(selectedRepoertFieldName.Trim()) && reportDataStructItem.IsUntickedField.Equals(true))
                {
                    fieldStatus = false;
                    return fieldStatus;
                }
                else if (reportDataStructItem.ReportFieldName.Trim().Equals(selectedRepoertFieldName.Trim()) && reportDataStructItem.IsUnAuthorized)
                {
                    fieldStatus = false;
                    return fieldStatus;
                }
                else if (reportDataStructItem.ReportFieldName.Trim().Equals(selectedRepoertFieldName.Trim()) && reportDataStructItem.IsUncheckable)
                {
                    fieldStatus = false;
                    return fieldStatus;
                }
            }

            return fieldStatus;
        }
        private void dgvFilter_CreateCell(object sender, GridViewCreateCellEventArgs e)
        {
            if (e.CellType == typeof(GridGroupContentCellElement))
            {
                e.CellElement = new MyGridGroupContentCellElement(e.Column, e.Row);
            }
        }
        private void Columns_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.dgvFilter.MasterTemplate.Refresh();
        }
        private DataTable table = null;
        internal delegate void SetDataSourceDelegate(DataTable table);
        List<Common.ReportDataStruct> reportDataStructList = new List<Common.ReportDataStruct>();
        private void loadTable()
        {
            List<Common.ReportConditionsDataStruct> reportConditionsDataStructList = new List<Common.ReportConditionsDataStruct>();

            List<Common.ReportDataStruct> reportGroupDataStructList = new List<Common.ReportDataStruct>();
            List<Common.ReportDataStruct> reportOrderByDataStructList = new List<Common.ReportDataStruct>();

            reportConditionsDataStructList = GetReportConditions();
            reportDataStructList = GetReportFields();
            reportGroupDataStructList = GetGroupByFields();
            reportOrderByDataStructList = GetOrderByFields();

            InitializeGrid(dgvFilter, reportDataStructList);
            InitializePrintDocument();

            SetView(tableViewInfo);



            switch (autoGenerateInfo.ModuleType)
            {
                case 1: //Common Summary Report
                    ComReportGenerator comReportGenerator = new ComReportGenerator();
                    table = comReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);

                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        table.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }

                    break;
                case 2: //Inventory Summary Report

                    InvReportGenerator invReportGenerator = new InvReportGenerator();
                    table = invReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        table.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }

                    break;
                case 3: //Logistic Summary Report
                    LgsReportGenerator lgsReportGenerator = new LgsReportGenerator();
                    table = lgsReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        table.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }

                    break;
                case 4: //CRM Summary Report
                    CrmReportGenerator crmReportGenerator = new CrmReportGenerator();
                    table = crmReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        table.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }
                    break;
                case 6: //Gift Voucher Summary Report
                    GvReportGenerator gvReportGenerator = new GvReportGenerator();
                    table = gvReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        table.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }

                    break;
                case 7: //POS Summary Report
                    InvReportGenerator posReportGenerator = new InvReportGenerator();
                    table = posReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        table.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }

                    break;
                case 15://Restuarant Summary Report
                    ResReportGenerator resReportGenerator = new ResReportGenerator();
                    table = resReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        table.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }
                    break;
                default:
                    break;
            }

            LoadRes(table);

        }

        private void LoadRes(DataTable table)
        {
            dgvFilter.DataSource = null;
            dgvFilter.Rows.Clear();
            dgvFilter.MasterTemplate.Reset();
            dgvFilter.MasterTemplate.SummaryRowsBottom.Clear();
            dgvFilter.EnableFastScrolling = true;  // sanjeewa
            dgvFilter.MasterTemplate.BestFitColumns();// sanjeewa

            //dgvFilter.CreateCell += new GridViewCreateCellEventHandler(dgvFilter_CreateCell);
            //dgvFilter.Columns.CollectionChanged += new NotifyCollectionChangedEventHandler(Columns_CollectionChanged);

            for (int i = 0; i < reportDatStructList.Count; i++)
            {
                table.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
            }
            if (this.InvokeRequired)
            {
                this.Invoke(new SetDataSourceDelegate(LoadRes), table);
            }
            else
            {

                dgvFilter.DataSource = table;
                this.radComboBoxSummaries.SelectedIndex = 0;
                AddSummaries(reportDataStructList);


                #region Pivot Grid


                this.radPivotGrid1.DataSource = table;
                this.exporter = new Telerik.WinControls.UI.Export.PivotExportToExcelML(this.radPivotGrid1);

                #endregion


                if (layout != string.Empty && layout != null)
                {
                    MemoryStream contentStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(layout));
                    this.dgvFilter.LoadLayout(contentStream);
                    this.dgvFilter.Refresh();
                }


                radWaitingBar.StopWaiting();
                radWaitingBar.Visible = false;
                lblProgress.Text = "Rows Count : " + table.Rows.Count.ToString();
                Cursor.Current = Cursors.Default;
            }





        }


        private void LoadResssult(DataTable table)
        {
            #region begin setup
            List<Common.ReportConditionsDataStruct> reportConditionsDataStructList = new List<Common.ReportConditionsDataStruct>();
            List<Common.ReportDataStruct> reportDataStructList = new List<Common.ReportDataStruct>();
            List<Common.ReportDataStruct> reportGroupDataStructList = new List<Common.ReportDataStruct>();
            List<Common.ReportDataStruct> reportOrderByDataStructList = new List<Common.ReportDataStruct>();

            reportConditionsDataStructList = GetReportConditions();
            reportDataStructList = GetReportFields();
            reportGroupDataStructList = GetGroupByFields();
            reportOrderByDataStructList = GetOrderByFields();

            DataTable dtRpt = new DataTable();
            this.dgvFilter.CreateCell += new GridViewCreateCellEventHandler(dgvFilter_CreateCell);
            dgvFilter.DataSource = null;
            dtRpt.BeginLoadData();
            //dgvResult.DataSource = null;

            dgvFilter.MasterTemplate.BeginUpdate();
            //dgvResult.Rows.Clear();
            dgvFilter.Rows.Clear();
            dgvFilter.MasterTemplate.Reset();
            dgvFilter.MasterTemplate.SummaryRowsBottom.Clear();
            //dgvResult.Refresh();
            dgvFilter.Refresh();
            dgvFilter.EnableFastScrolling = true;  // sanjeewa
            dgvFilter.MasterTemplate.BestFitColumns();// sanjeewa

            this.radProgressBar1.ShowProgressIndicators = true;

            #endregion

            #region View
            switch (autoGenerateInfo.ModuleType)
            {
                case 1: //Common Summary Report
                    ComReportGenerator comReportGenerator = new ComReportGenerator();
                    //dgvResult.DataSource = comReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    dtRpt = comReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);

                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        dtRpt.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }

                    dgvFilter.DataSource = dtRpt;
                    break;
                case 2: //Inventory Summary Report



                    InvReportGenerator invReportGenerator = new InvReportGenerator();
                    dtRpt = invReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);



                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        dtRpt.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }

                    dgvFilter.DataSource = dtRpt;
                    break;
                case 3: //Logistic Summary Report
                    LgsReportGenerator lgsReportGenerator = new LgsReportGenerator();
                    //dgvResult.DataSource = lgsReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    dtRpt = lgsReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        dtRpt.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }

                    dgvFilter.DataSource = dtRpt;
                    break;
                case 4: //CRM Summary Report
                    CrmReportGenerator crmReportGenerator = new CrmReportGenerator();
                    //dgvResult.DataSource = crmReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    dtRpt = crmReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        dtRpt.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }

                    dgvFilter.DataSource = dtRpt;
                    break;
                case 6: //Gift Voucher Summary Report
                    GvReportGenerator gvReportGenerator = new GvReportGenerator();
                    //dgvResult.DataSource = gvReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    dtRpt = gvReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        dtRpt.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }

                    dgvFilter.DataSource = dtRpt;
                    break;
                case 7: //POS Summary Report
                    InvReportGenerator posReportGenerator = new InvReportGenerator();
                    //dgvResult.DataSource = posReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    dtRpt = posReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        dtRpt.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }

                    dgvFilter.DataSource = dtRpt;
                    break;
                case 15://Restuarant Summary Report
                    ResReportGenerator resReportGenerator = new ResReportGenerator();
                    //dgvResult.DataSource = resReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    dtRpt = resReportGenerator.GetResultData(reportConditionsDataStructList, reportDataStructList, reportGroupDataStructList, reportOrderByDataStructList, autoGenerateInfo);
                    for (int i = 0; i < reportDatStructList.Count; i++)
                    {
                        dtRpt.Columns[i].ColumnName = reportDatStructList[i].ReportFieldName.Trim();
                    }

                    dgvFilter.DataSource = dtRpt;
                    break;
                default:
                    break;



            }

            dtRpt.EndLoadData();
            AddSummaries(reportDataStructList);
            //this.dgvFilter.MasterTemplate.EnablePaging = true;
            //this.dgvFilter.MasterTemplate.DataView.PagingBeforeGrouping = true;
            //GridAlignment(dgvResult);  // To align numbers to RightAlignment and adjust column Width

            //int compCount = 0;
            //foreach (var reportConditionsDataStruct in reportConditionsDataStructList)
            //{
            //    if (reportConditionsDataStruct.ReportDataStruct.IsComparisonField)
            //    { compCount++; }
            //}


            //SetUpdgvFilterColumns(reportDataStructList);


            InitializeGrid(dgvFilter, reportDataStructList);
            InitializePrintDocument();

            SetView(tableViewInfo);

            this.radComboBoxSummaries.SelectedIndex = 0;



            #region Pivot Grid


            this.radPivotGrid1.DataSource = dtRpt;
            this.exporter = new Telerik.WinControls.UI.Export.PivotExportToExcelML(this.radPivotGrid1);

            #endregion


            if (layout != string.Empty && layout != null)
            {
                MemoryStream contentStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(layout));
                this.dgvFilter.LoadLayout(contentStream);
                this.dgvFilter.Refresh();
            }

            #endregion
        }

        private void dgvFilter_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            //var column = e.CellElement.ColumnInfo;
            //var text = e.CellElement.Text;
            //if (string.IsNullOrEmpty(text))
            //{
            //    return;
            //}

            ////if (dictionary[column.HeaderText].Length < text.Length)
            //{
            //   // dictionary[column.HeaderText] = text;
            //    column.MaxWidth = (int)(this.CreateGraphics().MeasureString(text, this.Font).Width + 8);
            //    column.Width = column.MaxWidth;
            //    column.MinWidth = column.MaxWidth;
            //}
        }

        private void GridAlignment(DataGridView dtGrid)   // To Align data and set column width in the DataGridView Author :
        {
            if (dtGrid.RowCount > 0)
            {
                string dtType;


                for (int i = 0; i < dtGrid.Columns.Count; i++)
                {
                    string a;
                    a = dtGrid.Rows[0].Cells[i].Value.ToString();

                    dtType = dtGrid.Columns[i].ValueType.ToString();

                    switch (dtType)
                    {
                        case "System.Decimal":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.Double":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.Int16":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.Int32":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }
                            break;

                        case "System.Int64":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.Single":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }
                            break;

                        case "System.UInt16":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.UInt32":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.UInt64":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.DateTime":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                            dtGrid.Columns[i].Width = 80;
                            break;

                        default:
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 5) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }
                            break;
                    }

                }
            }
        }



        private void SetUpdgvFilterColumns(List<Common.ReportDataStruct> reportDataStructList)
        {
            for (int i = 0; i < reportDatStructList.Count; i++)
            {
                if (dgvFilter.Columns.Contains(reportDatStructList[i].ReportField.Trim()) && reportDatStructList[i].IsNotDisplayedOnGrid)
                {
                    dgvFilter.Columns[reportDatStructList[i].ReportField.Trim()].HeaderText = reportDatStructList[i].ReportFieldName.Trim();
                }
            }
            for (int i = 0; i < reportDataStructList.Count; i++)
            {
                if (dgvFilter.Columns.Contains(reportDataStructList[i].ReportField.Trim()))
                {
                    dgvFilter.Columns[reportDataStructList[i].ReportField.Trim()].HeaderText = reportDataStructList[i].ReportFieldName.Trim();
                    //dgvFilter.Columns[reportDataStructList[i].ReportField.Trim()].Visible = reportDataStructList[i].IsSelectionField;
                    //dgvResult.Columns[i].Visible = reportDataStructList[i].IsSelectionField;
                }
            }
        }


        /// <summary>
        /// Get report conditions
        /// </summary>
        /// <returns></returns>
        private List<Common.ReportConditionsDataStruct> GetReportConditions()
        {
            string conditionFrom = "";
            string conditionTo = "";
            List<Common.ReportConditionsDataStruct> reportConditionsDataStructList = new List<Common.ReportConditionsDataStruct>();
            // Fill reportConditionsDataStructList
            foreach (DataGridViewRow drValueRange in dgvValueRange.Rows)
            {
                Common.ReportDataStruct reportDataStruct = GetSelectedReportDataStruct(drValueRange.Cells["ValueType"].Value.ToString().Trim());

                switch (autoGenerateInfo.ModuleType)
                {
                    case 1: //Common Summary Report
                        ComReportGenerator comReportGenerator = new ComReportGenerator();
                        conditionFrom = reportDataStruct.IsJoinField.Equals(true) ? comReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueFrom"].Value.ToString().Trim()) : drValueRange.Cells["ValueFrom"].Value.ToString().Trim();
                        conditionTo = reportDataStruct.IsJoinField.Equals(true) ? comReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueTo"].Value.ToString().Trim()) : drValueRange.Cells["ValueTo"].Value.ToString().Trim();
                        break;
                    case 2: //Inventory Summary Report
                        InvReportGenerator invReportGenerator = new InvReportGenerator();
                        conditionFrom = reportDataStruct.IsJoinField.Equals(true) ? invReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueFrom"].Value.ToString().Trim()) : drValueRange.Cells["ValueFrom"].Value.ToString().Trim();
                        conditionTo = reportDataStruct.IsJoinField.Equals(true) ? invReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueTo"].Value.ToString().Trim()) : drValueRange.Cells["ValueTo"].Value.ToString().Trim();
                        break;
                    case 3: //Logistic Summary Report
                        LgsReportGenerator lgsReportGenerator = new LgsReportGenerator();
                        conditionFrom = reportDataStruct.IsJoinField.Equals(true) ? lgsReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueFrom"].Value.ToString().Trim()) : drValueRange.Cells["ValueFrom"].Value.ToString().Trim();
                        conditionTo = reportDataStruct.IsJoinField.Equals(true) ? lgsReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueTo"].Value.ToString().Trim()) : drValueRange.Cells["ValueTo"].Value.ToString().Trim();
                        break;
                    case 4: //CRM Summary Report
                        CrmReportGenerator CrmReportGenerator = new CrmReportGenerator();
                        conditionFrom = reportDataStruct.IsJoinField.Equals(true) ? CrmReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueFrom"].Value.ToString().Trim()) : drValueRange.Cells["ValueFrom"].Value.ToString().Trim();
                        conditionTo = reportDataStruct.IsJoinField.Equals(true) ? CrmReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueTo"].Value.ToString().Trim()) : drValueRange.Cells["ValueTo"].Value.ToString().Trim();
                        break;
                    case 6: //Gift Voucher Summary Report
                        GvReportGenerator gvReportGenerator = new GvReportGenerator();
                        conditionFrom = reportDataStruct.IsJoinField.Equals(true) ? gvReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueFrom"].Value.ToString().Trim()) : drValueRange.Cells["ValueFrom"].Value.ToString().Trim();
                        conditionTo = reportDataStruct.IsJoinField.Equals(true) ? gvReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueTo"].Value.ToString().Trim()) : drValueRange.Cells["ValueTo"].Value.ToString().Trim();
                        break;
                    case 7: //POS Summary Report
                        InvReportGenerator posReportGenerator = new InvReportGenerator();
                        conditionFrom = reportDataStruct.IsJoinField.Equals(true) ? posReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueFrom"].Value.ToString().Trim()) : drValueRange.Cells["ValueFrom"].Value.ToString().Trim();
                        conditionTo = reportDataStruct.IsJoinField.Equals(true) ? posReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueTo"].Value.ToString().Trim()) : drValueRange.Cells["ValueTo"].Value.ToString().Trim();
                        break;
                    case 15: //Restaurant Summary Report
                        ResReportGenerator resReportGenerator = new ResReportGenerator();
                        conditionFrom = reportDataStruct.IsJoinField.Equals(true) ? resReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueFrom"].Value.ToString().Trim()) : drValueRange.Cells["ValueFrom"].Value.ToString().Trim();
                        conditionTo = reportDataStruct.IsJoinField.Equals(true) ? resReportGenerator.GetConditionValue(reportDataStruct, drValueRange.Cells["ValueTo"].Value.ToString().Trim()) : drValueRange.Cells["ValueTo"].Value.ToString().Trim();
                        break;

                    default:
                        break;
                }


                reportConditionsDataStructList.Add(new Common.ReportConditionsDataStruct() { ReportDataStruct = reportDataStruct, ConditionFrom = conditionFrom, ConditionTo = conditionTo });
            }
            return reportConditionsDataStructList;
        }

        /// <summary>
        /// Get report fields
        /// </summary>
        /// <returns></returns>
        private List<Common.ReportDataStruct> GetReportFields()
        {
            List<Common.ReportDataStruct> reportDataStructFielsList = new List<Common.ReportDataStruct>();

            for (int itemIndex = 0; itemIndex < chkLstFieldSelectionStr.Items.Count; itemIndex++)
            {
                if (chkLstFieldSelectionStr.GetItemCheckState(itemIndex).Equals(CheckState.Checked))
                {
                    Common.ReportDataStruct reportDataStructField = GetSelectedReportDataStruct(chkLstFieldSelectionStr.Items[itemIndex].ToString().Trim());
                    reportDataStructField.IsSelectionField = true;
                    reportDataStructFielsList.Add(reportDataStructField);
                }
                else
                {
                    Common.ReportDataStruct reportDataStructField = GetSelectedReportDataStruct(chkLstFieldSelectionStr.Items[itemIndex].ToString().Trim());
                    reportDataStructField.IsSelectionField = false;
                    reportDataStructFielsList.Add(reportDataStructField);
                }
            }

            for (int itemIndex = 0; itemIndex < chkLstFieldSelectionDes.Items.Count; itemIndex++)
            {
                if (chkLstFieldSelectionDes.GetItemCheckState(itemIndex).Equals(CheckState.Checked))
                {
                    Common.ReportDataStruct reportDataStructField = GetSelectedReportDataStruct(chkLstFieldSelectionDes.Items[itemIndex].ToString().Trim());
                    reportDataStructField.IsSelectionField = true;
                    reportDataStructFielsList.Add(reportDataStructField);
                }
                else
                {
                    Common.ReportDataStruct reportDataStructField = GetSelectedReportDataStruct(chkLstFieldSelectionDes.Items[itemIndex].ToString().Trim());
                    reportDataStructField.IsSelectionField = false;
                    reportDataStructFielsList.Add(reportDataStructField);
                }
            }

            return reportDataStructFielsList;
        }

        /// <summary>
        /// Get group by fields
        /// </summary>
        /// <returns></returns>
        private List<Common.ReportDataStruct> GetGroupByFields()
        {
            List<Common.ReportDataStruct> reportDataStructList = new List<Common.ReportDataStruct>();
            // Fill reportDataStructList

            for (int i = 0; i < chkLstGroupBy.Items.Count; i++)
            {
                reportDataStructList.Add(GetReportGroupDataStruct(chkLstGroupBy.Items[i].ToString().Trim(), chkLstGroupBy.GetItemChecked(i)));
            }

            foreach (Common.ReportDataStruct reportDataStructItem in reportDatStructList)
            {
                if (reportDataStructItem.IsManualGroupBy)
                {
                    reportDataStructList.Add(GetReportGroupDataStruct(reportDataStructItem.ReportFieldName.ToString().Trim(), reportDataStructItem.IsManualGroupBy));
                }
            }
            return reportDataStructList;
        }

        /// <summary>
        /// Get order by fields
        /// </summary>
        /// <returns></returns>
        private List<Common.ReportDataStruct> GetOrderByFields()
        {
            List<Common.ReportDataStruct> reportDataStructList = new List<Common.ReportDataStruct>();

            for (int i = 0; i < chkLstOrderBy.Items.Count; i++)
            {
                reportDataStructList.Add(GetReportOrderDataStruct(chkLstOrderBy.Items[i].ToString().Trim(), chkLstOrderBy.GetItemChecked(i)));
            }

            foreach (Common.ReportDataStruct reportDataStructItem in reportDatStructList)
            {
                if (reportDataStructItem.IsManualOrderBy)
                {
                    reportDataStructList.Add(GetReportGroupDataStruct(reportDataStructItem.ReportFieldName.ToString().Trim(), reportDataStructItem.IsManualGroupBy));
                }
            }
            return reportDataStructList;
        }

        /// <summary>
        /// Setup string Fields Statuses depending on selected groups
        /// </summary>
        private void SetUpGroupDependingFieldsStatuses(ItemCheckEventArgs e)
        {
            if (int.Equals(autoGenerateInfo.ReportType, 1)) // && (chkLstGroupBy.CheckedIndices.Count - 1) <= 0) //&& (e.NewValue.Equals(CheckState.Checked)))
            {
                return;
            }

            this.chkLstFieldSelectionStr.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionStr_ItemCheck);
            this.chkLstFieldSelectionDes.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionDes_ItemCheck);
            this.chkLstOrderBy.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstOrderBy_ItemCheck);

            ArrayList checkedGroupsList = new ArrayList();

            foreach (var chkLstGrpItem in chkLstGroupBy.CheckedItems)
            {
                checkedGroupsList.Add(chkLstGrpItem.ToString());
            }

            if (e.NewValue.Equals(CheckState.Checked))
            {
                checkedGroupsList.Add(chkLstGroupBy.Items[e.Index].ToString());
            }
            if (e.NewValue.Equals(CheckState.Unchecked))
            {
                checkedGroupsList.Remove(chkLstGroupBy.Items[e.Index].ToString());
            }

            // uncheck all items in chkLstFieldSelectionStr
            for (int i = 0; i < chkLstFieldSelectionStr.Items.Count; i++)
            {
                chkLstFieldSelectionStr.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (var grpItem in checkedGroupsList)
            {
                for (int i = 0; i < chkLstFieldSelectionStr.Items.Count; i++)
                {
                    if (string.Equals(chkLstFieldSelectionStr.Items[i].ToString(), grpItem.ToString()) && chkLstFieldSelectionStr.GetItemCheckState(i).Equals(CheckState.Unchecked))
                    {
                        chkLstFieldSelectionStr.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }


            if (chkLstGroupBy.CheckedItems.Count - 1 <= 0 && e.NewValue.Equals(CheckState.Unchecked))
            {
                // Check mandatory fields
                foreach (var mandField in reportDatStructList.AsEnumerable().Where(i => i.IsMandatoryField.Equals(true)).ToList())
                {
                    for (int i = 0; i < chkLstFieldSelectionStr.Items.Count; i++)
                    {
                        if (string.Equals(mandField.ReportFieldName, chkLstFieldSelectionStr.Items[i].ToString()) && chkLstFieldSelectionStr.GetItemCheckState(i).Equals(CheckState.Unchecked))
                        {
                            chkLstFieldSelectionStr.SetItemCheckState(i, CheckState.Checked);
                        }
                    }

                    for (int i = 0; i < chkLstFieldSelectionDes.Items.Count; i++)
                    {
                        if (string.Equals(mandField.ReportFieldName, chkLstFieldSelectionDes.Items[i].ToString()) && chkLstFieldSelectionDes.GetItemCheckState(i).Equals(CheckState.Unchecked))
                        {
                            chkLstFieldSelectionDes.SetItemCheckState(i, CheckState.Checked);
                        }
                    }
                }
            }
            else
            {
                // uncheck all items in chkLstOrderBy
                for (int i = 0; i < chkLstOrderBy.Items.Count; i++)
                {
                    chkLstOrderBy.SetItemCheckState(i, CheckState.Unchecked);
                }


                foreach (var grpItem in checkedGroupsList)
                {
                    for (int i = 0; i < chkLstOrderBy.Items.Count; i++)
                    {
                        if (string.Equals(chkLstOrderBy.Items[i].ToString(), grpItem.ToString()) && chkLstOrderBy.GetItemCheckState(i).Equals(CheckState.Unchecked))
                        {
                            chkLstOrderBy.SetItemCheckState(i, CheckState.Checked);
                        }
                    }
                }
            }

            this.chkLstFieldSelectionStr.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionStr_ItemCheck);
            this.chkLstFieldSelectionDes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionDes_ItemCheck);
            this.chkLstOrderBy.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstOrderBy_ItemCheck);
        }

        /// <summary>
        /// Change checked statuses of depending fields in chkLstGroupBy, chkLstOrderBy, chklstColumnTotal and chkRowTotal grid views
        /// </summary>
        /// <param name="reportDataStruct"></param>
        private void SetUpDependingFieldsStatuses(Common.ReportDataStruct reportDataStruct)
        {
            //chkLstGroupBy
            foreach (int itemIndex in chkLstGroupBy.CheckedIndices)
            {
                if (string.Equals(chkLstGroupBy.Items[itemIndex].ToString().Trim(), reportDataStruct.ReportFieldName))
                {
                    this.chkLstGroupBy.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstGroupBy_ItemCheck);
                    chkLstGroupBy.SetItemCheckState(itemIndex, CheckState.Unchecked);
                    this.chkLstGroupBy.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstGroupBy_ItemCheck);
                }
            }

            //chkLstOrderBy
            foreach (int itemIndex in chkLstOrderBy.CheckedIndices)
            {
                if (string.Equals(chkLstOrderBy.Items[itemIndex].ToString().Trim(), reportDataStruct.ReportFieldName))
                {
                    this.chkLstOrderBy.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstOrderBy_ItemCheck);
                    chkLstOrderBy.SetItemCheckState(itemIndex, CheckState.Unchecked);
                    this.chkLstOrderBy.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstOrderBy_ItemCheck);
                }
            }

            //chklstColumnTotal
            foreach (int itemIndex in chklstColumnTotal.CheckedIndices)
            {
                if (string.Equals(chklstColumnTotal.Items[itemIndex].ToString().Trim(), reportDataStruct.ReportFieldName))
                {
                    chklstColumnTotal.SetItemCheckState(itemIndex, CheckState.Unchecked);
                }
            }

            //chkRowTotal
            foreach (int itemIndex in chkRowTotal.CheckedIndices)
            {
                if (string.Equals(chkRowTotal.Items[itemIndex].ToString().Trim(), reportDataStruct.ReportFieldName))
                {
                    chkRowTotal.SetItemCheckState(itemIndex, CheckState.Unchecked);
                }
            }
        }

        /// <summary>
        /// Check the stateses of chkLstFieldSelectionStr and chkLstFieldSelectionDes before change the current state of given field
        /// </summary>
        /// <param name="reportDataStruct"></param>
        /// <returns></returns>
        private bool CheckDependingFieldsStatuses(Common.ReportDataStruct reportDataStruct)
        {
            foreach (int itemIndex in chkLstFieldSelectionStr.CheckedIndices)
            {
                if (string.Equals(chkLstFieldSelectionStr.Items[itemIndex].ToString().Trim(), reportDataStruct.ReportFieldName))
                {
                    return true;
                }
            }

            foreach (int itemIndex in chkLstFieldSelectionDes.CheckedIndices)
            {
                if (string.Equals(chkLstFieldSelectionDes.Items[itemIndex].ToString().Trim(), reportDataStruct.ReportFieldName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validate maximum nuber of string fields can be selected for the report
        /// </summary>
        /// <param name="maxStringFields"></param> number of maximum string fields can be selected
        /// <param name="checkState"></param>
        /// <returns></returns>
        private bool ValidateStringSelectionFiledCount(int maxStringFields, CheckState checkState)
        {
            if (checkState.Equals(CheckState.Checked) && (chkLstFieldSelectionStr.CheckedIndices.Count + 1) > maxStringFields)
            { return false; }
            else
            { return true; }
        }

        /// <summary>
        /// Validate maximum nuber of decimal fields can be selected for the report
        /// </summary>
        /// <param name="maxDecimalFields"></param> number of maximum deciaml fields can be selected
        /// <param name="checkState"></param>
        /// <returns></returns>
        private bool ValidateDecimalSelectionFiledCount(int maxDecimalFields, CheckState checkState, bool isComparisonReport)
        {
            if (checkState.Equals(CheckState.Checked) && isComparisonReport && (chkLstFieldSelectionDes.CheckedIndices.Count + 1) > 2)
            { return false; }
            else if (checkState.Equals(CheckState.Checked) && (chkLstFieldSelectionDes.CheckedIndices.Count + 1) > maxDecimalFields)
            { return false; }
            else
            { return true; }
        }

        /// <summary>
        /// Validate maximum nuber of groups can be selected for the report
        /// </summary>
        /// <param name="maxGroupFields"></param> number of maximum groups can be selected
        /// <param name="checkState"></param>
        /// <returns></returns>
        private bool ValidateGroupSelectionFiledCount(int maxGroupFields, CheckState checkState, bool isComparisonReport)
        {
            if (checkState.Equals(CheckState.Checked) && isComparisonReport && (chkLstGroupBy.CheckedIndices.Count + 1) > 1)
            { return false; }
            if (checkState.Equals(CheckState.Checked) && (chkLstGroupBy.CheckedIndices.Count + 1) > maxGroupFields)
            { return false; }
            else
            { return true; }
        }

        /// <summary>
        /// Re arrange the order of the items of the checked list box
        /// </summary>
        /// <param name="chkLstBox"></param>
        /// <param name="move"></param> true = move up, false = move down
        private void ReArrangeCheckedListBox(CheckedListBox chkLstBox, ArrayList sourceList, bool move)
        {
            if (chkLstBox.Items.Count <= 0)
            { return; }

            if (bool.Equals(move, true))
            {
                if (int.Equals(chkLstBox.SelectedIndex, 0))
                { return; }
            }
            else
            {
                if (int.Equals((chkLstBox.SelectedIndex), chkLstBox.Items.Count - 1))
                { return; }
            }

            //chkLstGroupBy.CheckedItems.OfType<string>().Any(p => p.ToString() == reportDataStructList[i].ReportFieldName))

            // Get checked items
            ArrayList checkedItems = new ArrayList();
            if (!IsComparisonReport())
            {
                foreach (var item in chkLstBox.CheckedItems)
                {
                    checkedItems.Add(item.ToString());
                }
            }
            else
            {
                foreach (var item in chkLstBox.CheckedItems)
                {
                    checkedItems.Add(item.ToString());
                    break;
                }
            }

            // Re arranage source list
            for (int i = 0; i < sourceList.Count; i++)
            {
                if (string.Equals(sourceList[i].ToString().Trim(), chkLstBox.SelectedItem.ToString().Trim()))
                {
                    sourceList.Insert(bool.Equals(move, true) ? (i - 1) : (i + 2), chkLstBox.SelectedItem.ToString());
                    sourceList.RemoveAt(bool.Equals(move, true) ? (i + 1) : (i));
                    break;
                }
            }

            // Reset data source
            chkLstBox.DataSource = null;
            chkLstBox.Items.Clear();
            chkLstBox.DataSource = sourceList;

            // Set checked items
            if (!IsComparisonReport())
            {
                for (int i = 0; i < chkLstBox.Items.Count; i++)
                {
                    foreach (var item in checkedItems)
                    {
                        if (string.Equals(item.ToString(), chkLstBox.Items[i].ToString()))
                        {
                            chkLstBox.SetItemChecked(i, true);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < chkLstBox.Items.Count; i++)
                {
                    foreach (var item in checkedItems)
                    {
                        if (string.Equals(item.ToString(), chkLstBox.Items[i].ToString()))
                        {
                            chkLstBox.SetItemChecked(i, true);
                        }
                    }
                }
            }
            // Reset selected item
            chkLstBox.SetSelected(bool.Equals(move, true) ? (chkLstBox.SelectedIndex - 1) : (chkLstBox.SelectedIndex + 1), true);





        }

        /// <summary>
        /// Uncheck all items in checked list box
        /// </summary>
        /// <param name="chkLstBox"></param>
        private void ClearCheckedListBox(CheckedListBox chkLstBox)
        {
            for (int i = 0; i < chkLstBox.Items.Count; i++)
            {
                chkLstBox.SetItemChecked(i, false);
            }

        }

        /// <summary>
        /// Get report condtions and convert it into data table
        /// </summary>
        /// <returns></returns>
        private DataTable GetConditionsDataTable()
        {
            DataTable dtCondtions = new DataTable();
            dtCondtions.Columns.Add("ValueType", typeof(string));
            dtCondtions.Columns.Add("ValueFrom", typeof(string));
            dtCondtions.Columns.Add("ValueTo", typeof(string));

            foreach (DataGridViewRow dgvRow in dgvValueRange.Rows)
            {
                dtCondtions.Rows.Add(dgvRow.Cells["ValueType"].Value.ToString(), dgvRow.Cells["ValueFrom"].Value.ToString(), dgvRow.Cells["ValueTo"].Value.ToString());
            }

            return dtCondtions;
        }

        /// <summary>
        /// Confirmation of comparison report
        /// </summary>
        /// <returns></returns>
        private bool IsComparisonReport()
        {
            List<Common.ReportConditionsDataStruct> reportConditionsDataStructList = new List<Common.ReportConditionsDataStruct>();
            reportConditionsDataStructList = GetReportConditions();
            int compCount = 0;
            foreach (var reportConditionsDataStruct in reportConditionsDataStructList)
            {
                if (reportConditionsDataStruct.ReportDataStruct.IsComparisonField)
                { compCount++; }
            }

            if (reportDatStructList.Any(c => c.IsComparisonField) && compCount > 1)
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// Sort original data according to gridview sort
        /// </summary>
        /// <param name="dtGridData"></param>
        /// <returns></returns>
        private DataTable SetGridViewSort(DataTable dtGridData)
        {
            if (sortedColumn.Index < 0)
            {
                return dtGridData;
            }
            else
            {
                DataView dvGridData = new DataView(dtGridData);

                if (sortedDirection.Equals(ListSortDirection.Ascending))
                {
                    dvGridData.Sort = sortedColumn.Name + " Asc";
                }
                if (sortedDirection.Equals(ListSortDirection.Descending))
                {
                    dvGridData.Sort = sortedColumn.Name + " Desc";
                }

                dtGridData = dvGridData.ToTable();
            }

            return dtGridData;
        }

        #endregion

        #region Form events

        public void InitializeForm()
        {
            try
            {
                sortedColumn = new DataGridViewColumn();
                sortedDirection = new ListSortDirection();
                LoadFieldS();
                //accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);

                //if (!string.IsNullOrEmpty(accessRights.Layout))
                //{ layout = accessRights.Layout; }


                UserPrivileges accessRightsSaveLayout = new UserPrivileges();
                accessRightsSaveLayout = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, 19011); // save layout privilegeID

                if (accessRightsSaveLayout.IsSave != true)
                {
                    btnSaveLayout.Visible = false;
                    // btnLoadLayout.Visible = false;
                }
                accessRightsSaveLayout = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, 19009); // view pivot

                if (accessRightsSaveLayout.IsAccess != true)
                {
                    tabReportViewer.TabPages.Remove(tabPagePivot);
                }


                UserPrivilegesService userPrivilegesService = new UserPrivilegesService();

                string[] LayoutArr = userPrivilegesService.GetAllLayoutNames(Common.LoggedUserId, documentID);

                //if (LayoutArr.Count() == 0 && Common.LoggedUserId != 1)
                //{
                //    Toast.Show(this.Name, this.Text.ToString(), "", Toast.messageType.Warning, Toast.messageAction.AccessDenied);
                //    Common.EnableButton(false, btnView);

                //    //this.Close();
                //    //this.Dispose();

                //}
                //else
                //{
                cmbLayout.DataSource = LayoutArr;
                if (Common.LoggedUserId != 1)
                {
                    layout = userPrivilegesService.GetLayoutByNames(LayoutArr[0].ToString(), documentID);
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbValueType.SelectedIndex < 0)
                { return; }

                LoadSelectionData();
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void btnValueAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()).ValueDataType.Equals(typeof(DateTime)))
                { AddConditions(); }
                else if (GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()).ValueDataType.Equals(typeof(decimal)))
                {
                    if (string.IsNullOrEmpty(txtValueFrom.Text.Trim()) || string.IsNullOrEmpty(txtValueTo.Text.Trim()))// SelectedIndex < 0 || txtValueTo.SelectedIndex < 0)
                    { return; }
                    AddConditions();
                }
                else if (reportDataStructTemp.IsManualRecordFilter.Equals(true))
                {
                    if (string.IsNullOrEmpty(txtValue.Text.Trim()))
                    { return; }
                    AddConditions();
                }
                else
                {
                    if (cmbValueFrom.SelectedIndex < 0 || cmbValueTo.SelectedIndex < 0)
                    { return; }
                    else
                    {
                        AddConditions();
                    }
                }


            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                tabReportViewer.Visible = true;
                tabReportViewer.Top = 1;
                tabReportViewer.Left = 1;
                groupBox1.Visible = false;
                if (dgvValueRange.Rows.Count < 1)
                { return; }
                Cursor.Current = Cursors.WaitCursor;
                radWaitingBar.StartWaiting();
                lblProgress.Visible = true;
                radWaitingBar.Visible = true;
                thread = new Thread(new ThreadStart(loadTable));
                thread.Start();


            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void dgvResult_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                AutoGenerateInfo autoGenerateTransInfo = null;
                if (dgvFilter.CurrentCell != null && dgvFilter.CurrentCell.RowIndex >= 0)
                {
                    int documentNoColumnIndex = -1;
                    int documentIDColumnIndex = -1;
                    int moduleType = 0;

                    foreach (GridViewColumn col in dgvFilter.Columns)
                    {
                        if (string.Equals(col.HeaderText.Trim(), "Document No"))
                        {
                            documentNoColumnIndex = col.Index;
                        }
                        if (string.Equals(col.HeaderText.Trim(), "DocumentID"))
                        {
                            documentIDColumnIndex = col.Index;
                        }
                    }

                    //documentNoColumnIndex = dgvResult.Columns.OfType<DataGridViewColumn>().ToList()
                    //.Where(col => col.HeaderText == "Document No").Select(col => col.Index).First();// FirstOrDefault();

                    if (int.Equals(documentNoColumnIndex, -1))
                    { return; }
                    if (!int.Equals(documentIDColumnIndex, -1))
                    {
                        autoGenerateTransInfo = AutoGenerateInfoService.GetAutoGenerateInfoByDocumentID(Common.ConvertStringToInt(dgvFilter.SelectedRows[0].Cells[documentIDColumnIndex].Value.ToString())); // dgvFilter[documentIDColumnIndex, dgvFilter.CurrentRow.RowIndex].Value.ToString()));
                        moduleType = autoGenerateTransInfo.ModuleType;
                    }
                    else
                    { moduleType = autoGenerateInfo.ModuleType; }

                    #region View
                    switch (moduleType)
                    {
                        case 1: //Common Summary Report
                            ComReportGenerator comReportGenerator = new ComReportGenerator();
                            switch (autoGenerateInfo.ReportType)
                            {
                                case 1: // Reference
                                    comReportGenerator.GenearateReferenceReport(autoGenerateInfo, dgvFilter.SelectedRows[0].Cells[documentNoColumnIndex].Value.ToString().Trim(), false);
                                    break;
                                case 2: // Transaction
                                    if (int.Equals(documentNoColumnIndex, -1))
                                    { return; }
                                    comReportGenerator.GenearateTransactionReport(autoGenerateInfo, dgvFilter.SelectedRows[0].Cells[documentNoColumnIndex].Value.ToString().Trim(), 2);
                                    break;
                                default:
                                    break;
                            }

                            break;
                        case 2: //Inventory Summary Report
                            InvReportGenerator invReportGenerator = new InvReportGenerator();
                            switch (autoGenerateInfo.ReportType)
                            {
                                case 1: // Reference
                                    invReportGenerator.GenearateReferenceReport(autoGenerateInfo, dgvFilter.SelectedRows[0].Cells[documentNoColumnIndex].Value.ToString().Trim(), false);
                                    break;
                                case 2: // Transaction
                                    if (int.Equals(documentNoColumnIndex, -1))
                                    { return; }
                                    //invReportGenerator.GenerateTransactionReport(autoGenerateInfo, dgvResult[documentNoColumnIndex, dgvResult.CurrentCell.RowIndex].Value.ToString().Trim(), 2);
                                    if (!int.Equals(documentIDColumnIndex, -1))
                                    { invReportGenerator.GenerateTransactionReport(autoGenerateTransInfo, dgvFilter.SelectedRows[0].Cells[documentIDColumnIndex].Value.ToString().Trim(), 2); }
                                    else
                                    { invReportGenerator.GenerateTransactionReport(autoGenerateInfo, dgvFilter.SelectedRows[0].Cells[documentNoColumnIndex].Value.ToString().Trim(), 2); }
                                    break;
                                default:
                                    break;
                            }

                            break;
                        case 3: //Logistic Summary Report
                            LgsReportGenerator lgsReportGenerator = new LgsReportGenerator();
                            switch (autoGenerateInfo.ReportType)
                            {
                                case 1: // Reference
                                    lgsReportGenerator.GenearateReferenceReport(autoGenerateInfo, dgvFilter.SelectedRows[0].Cells[documentNoColumnIndex].Value.ToString().Trim(), false);
                                    break;
                                case 2: // Transaction
                                    if (int.Equals(documentNoColumnIndex, -1))
                                    { return; }
                                    //lgsReportGenerator.GenearateTransactionReport(autoGenerateInfo, dgvResult[documentNoColumnIndex, dgvResult.CurrentCell.RowIndex].Value.ToString().Trim(), 2);
                                    if (!int.Equals(documentIDColumnIndex, -1))
                                    { lgsReportGenerator.GenearateTransactionReport(autoGenerateTransInfo, dgvFilter.SelectedRows[0].Cells[documentIDColumnIndex].Value.ToString().Trim(), 2); }
                                    else
                                    { lgsReportGenerator.GenearateTransactionReport(autoGenerateInfo, dgvFilter.SelectedRows[0].Cells[documentNoColumnIndex].Value.ToString().Trim(), 2); }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 4: //CRM Summary Report
                            CrmReportGenerator crmReportGenerator = new CrmReportGenerator();
                            switch (autoGenerateInfo.ReportType)
                            {
                                case 1: // Reference
                                    if (dgvFilter.Columns.Contains("CustomerCode"))
                                    { crmReportGenerator.GenearateReferenceReport(autoGenerateInfo, dgvFilter.SelectedRows[0].Cells[2].Value.ToString().Trim()); }
                                    else
                                    { crmReportGenerator.GenearateReferenceReport(autoGenerateInfo, dgvFilter.SelectedRows[0].Cells[0].Value.ToString().Trim()); }
                                    break;
                                case 2: // Transaction

                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 6: //Gift Voucher Summary Report
                            GvReportGenerator gvReportGenerator = new GvReportGenerator();
                            switch (autoGenerateInfo.ReportType)
                            {
                                case 1: // Reference
                                    gvReportGenerator.GenearateReferenceReport(autoGenerateInfo, dgvFilter.SelectedRows[0].Cells[0].Value.ToString().Trim(), false);
                                    break;
                                case 2: // Transaction
                                    if (int.Equals(documentNoColumnIndex, -1))
                                    { return; }
                                    gvReportGenerator.GenearateTransactionReport(autoGenerateInfo, dgvFilter.SelectedRows[0].Cells[documentNoColumnIndex].Value.ToString().Trim(), 2);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void dgvValueRange_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (dgvFilter.Rows.Count < 0 || !e.KeyCode.Equals(Keys.F2))
                { return; }

                if (Toast.Show(this.Text, "Filter", dgvValueRange[0, dgvValueRange.CurrentCell.RowIndex].Value.ToString(), Toast.messageType.Question, Toast.messageAction.Delete).Equals(DialogResult.No))
                { return; }

                dgvValueRange.Rows.RemoveAt(dgvValueRange.CurrentCell.RowIndex);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void chkLstFieldSelectionStr_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (chkLstGroupBy.CheckedIndices.Count > 0 && int.Equals(autoGenerateInfo.ReportType, 2))
                {
                    e.NewValue = e.CurrentValue;
                    return;
                }

                #region Validate Selection Filed Count
                if (maxStringFields > 0)
                {
                    if (!ValidateStringSelectionFiledCount(maxStringFields, e.NewValue))
                    {
                        e.NewValue = e.CurrentValue;
                        Toast.Show(this.Text, "Maxium number of fields can be seleted is " + maxStringFields + ".", "", Toast.messageType.Information, Toast.messageAction.General);
                        return;
                    }
                }
                #endregion

                #region Disable unchecking mandatory fields
                foreach (var mandField in reportDatStructList.AsEnumerable().Where(i => i.IsMandatoryField.Equals(true)).ToList())
                {
                    if (string.Equals(GetSelectedReportDataStruct(chkLstFieldSelectionStr.Items[e.Index].ToString().Trim()).ReportFieldName, mandField.ReportFieldName))
                    {
                        this.chkLstFieldSelectionStr.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionStr_ItemCheck);
                        e.NewValue = e.CurrentValue;
                        this.chkLstFieldSelectionStr.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionStr_ItemCheck);
                        return;
                    }
                }
                #endregion

                #region Disable checking Unauthorized fields
                foreach (var unauthorizedField in reportDatStructList.AsEnumerable().Where(i => i.IsUnAuthorized.Equals(true)).ToList())
                {
                    if (string.Equals(GetSelectedReportDataStruct(chkLstFieldSelectionStr.Items[e.Index].ToString().Trim()).ReportFieldName, unauthorizedField.ReportFieldName))
                    {
                        this.chkLstFieldSelectionStr.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionStr_ItemCheck);
                        e.NewValue = e.CurrentValue;
                        this.chkLstFieldSelectionStr.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionStr_ItemCheck);
                        return;
                    }
                }
                #endregion

                #region Disable checking Uncheckable fields
                foreach (var unauthorizedField in reportDatStructList.AsEnumerable().Where(i => i.IsUncheckable.Equals(true)).ToList())
                {
                    if (GetSelectedReportDataStruct(chkLstFieldSelectionStr.Items[e.Index].ToString().Trim()).IsUncheckable)
                    {
                        this.chkLstFieldSelectionStr.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionStr_ItemCheck);
                        e.NewValue = e.CurrentValue;
                        this.chkLstFieldSelectionStr.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionStr_ItemCheck);
                        return;
                    }
                }
                #endregion

                if (e.NewValue.Equals(CheckState.Unchecked))
                {
                    SetUpDependingFieldsStatuses(GetSelectedReportDataStruct(chkLstFieldSelectionStr.Items[e.Index].ToString().Trim()));
                }
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void chkLstFieldSelectionDes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                #region Validate Selection Filed Count
                if (maxDecimalFields > 0)
                {
                    bool isComparisonReport = IsComparisonReport();
                    if (!ValidateDecimalSelectionFiledCount(maxDecimalFields, e.NewValue, isComparisonReport))
                    {
                        e.NewValue = e.CurrentValue;
                        Toast.Show(this.Text, "Maxium number of fields can be seleted is " + ((isComparisonReport.Equals(true)) ? "2" : maxGroups.ToString()) + ".", "", Toast.messageType.Information, Toast.messageAction.General);
                        return;
                    }
                }
                #endregion

                #region Disable unchecking mandatory fields

                foreach (var mandField in reportDatStructList.AsEnumerable().Where(i => i.IsMandatoryField.Equals(true)).ToList())
                {
                    if (string.Equals(GetSelectedReportDataStruct(chkLstFieldSelectionDes.Items[e.Index].ToString().Trim()).ReportFieldName, mandField.ReportFieldName))
                    {
                        this.chkLstFieldSelectionDes.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionDes_ItemCheck);
                        e.NewValue = e.CurrentValue;
                        this.chkLstFieldSelectionDes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionDes_ItemCheck);
                        return;
                    }
                }

                #endregion

                #region Disable checking Unauthorized fields
                foreach (var unauthorizedField in reportDatStructList.AsEnumerable().Where(i => i.IsUnAuthorized.Equals(true)).ToList())
                {
                    if (string.Equals(GetSelectedReportDataStruct(chkLstFieldSelectionDes.Items[e.Index].ToString().Trim()).ReportFieldName, unauthorizedField.ReportFieldName))
                    {
                        this.chkLstFieldSelectionDes.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionDes_ItemCheck);
                        e.NewValue = e.CurrentValue;
                        this.chkLstFieldSelectionDes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionDes_ItemCheck);
                        return;
                    }
                }
                #endregion

                if (e.NewValue.Equals(CheckState.Unchecked))
                {
                    SetUpDependingFieldsStatuses(GetSelectedReportDataStruct(chkLstFieldSelectionDes.Items[e.Index].ToString().Trim()));
                }
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void chkLstGroupBy_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                #region Validate Selection Filed Count
                if (maxGroups > 0)
                {
                    bool isComparisonReport = IsComparisonReport();
                    if (!ValidateGroupSelectionFiledCount(maxGroups, e.NewValue, isComparisonReport))
                    {
                        e.NewValue = e.CurrentValue;
                        Toast.Show(this.Text, "Maxium number of group fields can be seleted is " + ((isComparisonReport.Equals(true)) ? "1" : maxGroups.ToString()) + ".", "", Toast.messageType.Information, Toast.messageAction.General);
                        return;
                    }

                    //if (int.Equals(autoGenerateInfo.ReportType, 2))
                    //{
                    //    if (!ValidateSelectionFiledCount(maxGroups, e.NewValue))
                    //    {
                    //        e.NewValue = e.CurrentValue;
                    //        Toast.Show("Maxium number of fields can be seleted is " + maxGroups + ".", Toast.messageType.Information, Toast.messageAction.General);
                    //        return;
                    //    }
                    //}
                }
                #endregion

                SetUpGroupDependingFieldsStatuses(e);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void chkLstOrderBy_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (e.NewValue.Equals(CheckState.Checked))
                {
                    if (!CheckDependingFieldsStatuses(GetSelectedReportDataStruct(chkLstOrderBy.Items[e.Index].ToString().Trim())))
                    {
                        e.NewValue = e.CurrentValue;
                    }
                }
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void chklstColumnTotal_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (e.NewValue.Equals(CheckState.Checked))
                {
                    if (!CheckDependingFieldsStatuses(GetSelectedReportDataStruct(chklstColumnTotal.Items[e.Index].ToString().Trim())))
                    {
                        e.NewValue = e.CurrentValue;
                    }
                }
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void chkRowTotal_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (e.NewValue.Equals(CheckState.Checked))
                {
                    if (!CheckDependingFieldsStatuses(GetSelectedReportDataStruct(chkRowTotal.Items[e.Index].ToString().Trim())))
                    {
                        e.NewValue = e.CurrentValue;
                    }
                }
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void cmbValueFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbValueFrom.Text))
                {
                    if (cmbValueFrom.FindStringExact(cmbValueFrom.Text.Trim()) < 0)
                    {
                        Toast.Show(this.Text, "Entered Value ", "", Toast.messageType.Information, Toast.messageAction.NotExists);
                        cmbValueFrom.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void cmbValueTo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbValueTo.Text))
                {
                    if (cmbValueTo.FindStringExact(cmbValueTo.Text.Trim()) < 0)
                    {
                        Toast.Show(this.Text, "Entered Value ", "", Toast.messageType.Information, Toast.messageAction.NotExists);
                        cmbValueTo.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void chkViewGroupDetails_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkLstGroupBy.CheckedIndices.Count < 1)
                {
                    chkViewGroupDetails.Checked = false;
                }
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void chkLstGroupBy_Leave(object sender, EventArgs e)
        {
            try
            {
                if (chkLstGroupBy.CheckedIndices.Count < 1)
                {
                    chkViewGroupDetails.Checked = false;
                }
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }

        }

        private void btnGroupByUp_Click(object sender, EventArgs e)
        {
            try
            {
                ReArrangeCheckedListBox(chkLstGroupBy, groupbyField, true);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void btnGroupByDown_Click(object sender, EventArgs e)
        {
            try
            { ReArrangeCheckedListBox(chkLstGroupBy, groupbyField, false); }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                dgvFilter.DataSource = null;
                foreach (DataGridViewRow item in dgvValueRange.Rows)
                {
                    dgvValueRange.Rows.RemoveAt(item.Index);
                }
                dgvValueRange.DataSource = null;
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (panel1.Visible == true)
                { panel1.Visible = false; }
                else
                { panel1.Visible = true; }
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        #endregion

        #region Highlights
        private void cmbValueType_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblValueType);
        }

        private void cmbValueType_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblValueType);
        }

        #region Red Grid View

        private void InitializeGrid(Telerik.WinControls.UI.RadGridView radGridView1, List<Common.ReportDataStruct> reportDataStructList)
        {


            tableViewInfo = new ViewDefinitionInfo();
            tableViewInfo.ViewDefinition = (TableViewDefinition)radGridView1.ViewDefinition;
            //tableViewInfo.Columns = new List<string>() { "FirstName", "LastName", "Title", "Country", "HomePhone", "Address", "Check", "Combo" };
            List<string> strList = new List<string>();
            for (int i = 0; i < reportDataStructList.Count; i++)
            {
                if (dgvFilter.Columns.Contains(reportDataStructList[i].ReportField.Trim()))
                {
                    strList.Add(reportDataStructList[i].ReportFieldName.Trim());

                }
            }
            tableViewInfo.Columns = strList;


            //foreach (GridViewColumn cell in dgvFilter.Columns)
            //{
            //    cell.Width
            //}
        }

        private void FrmReprotGenerator_Load(object sender, EventArgs e)
        {


            InitializeForm();
            this.Left = 1;
            this.Top = 1;
            tabReportViewer.Visible = false;
            groupBox1.Visible = true;
            tabReportViewer.Visible = false;
            this.dgvFilter.AllowAddNewRow = false;
            //this.dgvFilter.EnableFiltering = true;
            //this.dgvFilter.ShowFilteringRow = false;
            this.dgvFilter.ShowHeaderCellButtons = true;
            this.dgvFilter.ShowGroupedColumns = true;
            //this.dgvFilter.AutoExpandGroups = true;
            this.dgvFilter.EnableAlternatingRowColor = true;
            this.dgvFilter.AutoExpandGroups = true;
            this.dgvFilter.MasterTemplate.EnableFiltering = true;
            this.dgvFilter.MasterTemplate.AutoExpandGroups = true;

            this.dgvFilter.CellFormatting += new CellFormattingEventHandler(dgvFilter_CellFormatting);
            //this.dgvFilter.PrintCellFormatting += new PrintCellFormattingEventHandler(dgvFilter_PrintCellFormatting);
            this.dgvFilter.AllowEditRow = false;
            lblProgress.Text = "Progress:";

            dgvFilter.DataSource = null;
            foreach (DataGridViewRow item in dgvValueRange.Rows)
            {
                dgvValueRange.Rows.RemoveAt(item.Index);
            }
            cmbValueTo.DataSource = null;
            cmbValueFrom.DataSource = null;
            cmbValueFrom.Text = "";
            cmbValueTo.Text = "";




        }
        protected void WireEvents()
        {
            //this.radRadioButtonTable.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioTable_ToggleStateChanged);
            //this.radRadioButtonHtml.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioTable_ToggleStateChanged);
            //this.radRadioButtonColumnGroups.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioTable_ToggleStateChanged);
            //this.radButtonPrint.Click += new System.EventHandler(this.radButtonPrint_Click);
            //this.radButtonPrintPreview.Click += new System.EventHandler(this.radButtonPrintPreview_Click);
            //this.radButtonPrintSettings.Click += new System.EventHandler(this.radButtonPrintSettings_Click);
        }
        /*
        private void radRadioTable_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (this.radRadioButtonColumnGroups.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                SetView(columnGroupViewInfo);
            }
            else if (this.radRadioButtonHtml.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                SetView(htmlViewInfo);
            }
            else
            {
                SetView(tableViewInfo);
            }
        }
        */

        private void SetView(ViewDefinitionInfo info)
        {
            currentViewInfo = info;

            this.dgvFilter.FilterDescriptors.Clear();

            this.dgvFilter.BeginUpdate();

            //foreach (GridViewColumn col in this.dgvFilter.Columns)
            //{
            //    // col.IsVisible = info.Columns.Contains(col.Name);
            //}

            GridTraverser traverser = new GridTraverser(this.dgvFilter.MasterView);
            while (traverser.MoveNext())
            {
                if (traverser.Current is GridViewDataRowInfo)
                {
                    traverser.Current.Height = info.RowHeight;
                }
            }

            this.dgvFilter.MasterView.TableHeaderRow.Height = info.HeaderHeight;

            this.dgvFilter.EndUpdate(false);

            this.dgvFilter.ViewDefinition = info.ViewDefinition;
            this.dgvFilter.PrintStyle.FitWidthMode = PrintFitWidthMode.FitPageWidth;
        }

        private void InitializePrintDocument()
        {
            this.radPrintDocument1.LeftFooter = "Page [Page #] of [Total Pages]";
            this.radPrintDocument1.LeftHeader = "[Time Printed]";
            this.radPrintDocument1.MiddleFooter = "***";
            this.radPrintDocument1.MiddleHeader = Common.LoggedCompanyName;
            this.radPrintDocument1.RightFooter = "Printed by:" + Common.LoggedUser.ToString();
            this.radPrintDocument1.RightHeader = "[Date Printed]";
        }

        private void dgvFilter_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            //if ((bool)e.RowElement.RowInfo.Cells["IsDeliver"].Value == true)
            //{
            //    e.RowElement.BackColor = Color.White;
            //}
            //else
            {
                e.RowElement.DrawFill = true;
                e.RowElement.BackColor = Color.Aqua;
            }

        }

        //Update the progress bar with the export progress
        private void exportProgress(object sender, ProgressEventArgs e)
        {
            // Call InvokeRequired to check if thread needs marshalling, to access properly the UI thread.
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(
                    delegate
                    {
                        if (e.ProgressValue <= 100)
                        {
                            radProgressBar1.Value1 = e.ProgressValue;
                        }
                        else
                        {
                            radProgressBar1.Value1 = 100;
                        }
                    }));
            }
            else
            {
                if (e.ProgressValue <= 100)
                {
                    radProgressBar1.Value1 = e.ProgressValue;
                }
                else
                {
                    radProgressBar1.Value1 = 100;
                }

            }
        }

        // when the worker finishes the export, we can do some post processing
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.radProgressBar1.Value1 = 0;
            RadMessageBox.Show("The data in the grid was exported successfully.", "Export to Excel");
        }

        private void radListBox1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            saveFileDialog.Filter = "Excel (*.xls)|*.xls";
            /*
            switch (this.radListBox1.SelectedIndex)
            {
                case 0: //export to excelML
                    this.radCheckBoxExportVisual.Enabled = true;
                    this.radRadioButton1.Enabled = true;
                    this.radRadioButton2.Enabled = true;
                    this.radTextBoxSheet.Enabled = true;
                    this.radComboBoxSummaries.Enabled = true;
                    this.radLabel1.Visible = true;
                    this.radLabel1.Text = "Sheet:";
                    this.radTextBoxSheet.Text = String.Empty;
                    this.radTextBoxSheet.Visible = true;

                    this.radProgressBar1.Visible = false;
                    this.radLblProgress.Visible = false;
                    break;
                case 1: //export to CSV
                    saveFileDialog.Filter = "CSV File (*.csv)|*.csv";
                    this.radCheckBoxExportVisual.Enabled = false;
                    this.radRadioButton1.Enabled = false;
                    this.radRadioButton2.Enabled = false;
                    this.radTextBoxSheet.Enabled = false;
                    this.radComboBoxSummaries.Enabled = true;
                    this.radLabel1.Visible = false;
                    this.radTextBoxSheet.Visible = false;

                    this.radProgressBar1.Visible = false;
                    this.radLblProgress.Visible = false;
                    break;
                case 2: //export to HTML
                    saveFileDialog.Filter = "Html File (*.htm)|*.htm";
                    this.radCheckBoxExportVisual.Enabled = true;
                    this.radRadioButton1.Enabled = false;
                    this.radRadioButton2.Enabled = false;
                    this.radTextBoxSheet.Enabled = true;
                    this.radComboBoxSummaries.Enabled = true;
                    this.radLabel1.Visible = true;
                    this.radLabel1.Text = "HtmlTable Caption:";
                    this.radTextBoxSheet.Text = String.Empty;
                    this.radTextBoxSheet.Visible = true;

                    this.radProgressBar1.Visible = false;
                    this.radLblProgress.Visible = false;
                    break;
                case 3: //export to PDF
                    saveFileDialog.Filter = "PDF File (*.pdf)|*.pdf";
                    this.radCheckBoxExportVisual.Enabled = true;
                    this.radRadioButton1.Enabled = false;
                    this.radRadioButton2.Enabled = false;
                    this.radTextBoxSheet.Enabled = true;
                    this.radComboBoxSummaries.Enabled = true;
                    this.radLabel1.Visible = true;
                    this.radLabel1.Text = "PdfTable Caption:";
                    this.radTextBoxSheet.Text = String.Empty;
                    this.radTextBoxSheet.Visible = true;

                    this.radProgressBar1.Visible = false;
                    this.radLblProgress.Visible = false;
                    break;
            }
            */
            //this.radButtonExport.Focus();
        }

        /*
        private void radButtonExport_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (saveFileDialog.FileName.Equals(String.Empty))
            {
                RadMessageBox.SetThemeName(this.dgvFilter.ThemeName);
                RadMessageBox.Show("Please enter a file name.");
                return;
            }

            string fileName = this.saveFileDialog.FileName;
            bool openExportFile = false;

            if (this.radCheckBoxExportVisual.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                this.exportVisualSettings = true;
            }
            else
            {
                this.exportVisualSettings = false;
            }

            switch (this.radListBox1.SelectedIndex)
            {
                case 0: //export to excelML
                    RunExportToExcelML(fileName, ref openExportFile);
                    break;

                case 1: //export to CSV
                    RunExportToCSV(fileName, ref openExportFile);
                    break;

                case 2: //export to HTML
                    RunExportToHTML(fileName, ref openExportFile);
                    break;

                case 3: //export to PDF
                    RunExportToPDF(fileName, ref openExportFile);
                    break;
            }


            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    string message = String.Format("The file cannot be opened on your system.\nError message: {0}", ex.Message);
                    RadMessageBox.Show(message, "Open File", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }
        */


        GridViewSummaryRowItem item1 = new GridViewSummaryRowItem();

        private void AddSummaries(List<Common.ReportDataStruct> pReportDatStructList)
        {
            item1.Clear();


            for (int i = 0; i < pReportDatStructList.Count; i++)
            {
                if (pReportDatStructList[i].IsColumnTotal.Equals(true) && pReportDatStructList[i].ReportDataType.Equals(typeof(decimal)))
                {
                    item1.Add(new GridViewSummaryItem(pReportDatStructList[i].ReportFieldName.ToString(), "{0}", GridAggregateFunction.Sum));
                }

            }
            dgvFilter.MasterTemplate.SummaryRowsBottom.Add(item1);
            dgvFilter.MasterTemplate.SummaryRowGroupHeaders.Add(item1);

        }

        private void RunExportToExcelML(Object fileName)
        {
            try
            {
                ExportToExcelML excelExporter = new ExportToExcelML(this.dgvFilter);

                if (this.radTextBoxSheet.Text != String.Empty)
                {
                    excelExporter.SheetName = this.radTextBoxSheet.Text;

                }

                switch (this.radComboBoxSummaries.SelectedIndex)
                {
                    case 0:
                        excelExporter.SummariesExportOption = SummariesOption.ExportAll;
                        break;
                    case 1:
                        excelExporter.SummariesExportOption = SummariesOption.ExportOnlyTop;
                        break;
                    case 2:
                        excelExporter.SummariesExportOption = SummariesOption.ExportOnlyBottom;
                        break;
                    case 3:
                        excelExporter.SummariesExportOption = SummariesOption.DoNotExport;
                        break;
                }

                //set max sheet rows
                if (this.radRadioButton1.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                {
                    excelExporter.SheetMaxRows = ExcelMaxRows._1048576;
                }
                else if (this.radRadioButton2.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                {
                    excelExporter.SheetMaxRows = ExcelMaxRows._65536;
                }

                //set exporting visual settings
                excelExporter.ExportVisualSettings = this.exportVisualSettings;

                excelExporter.ExcelCellFormatting += new ExcelCellFormattingEventHandler(exporter_ExcelCellFormatting);
                excelExporter.ExcelTableCreated += new ExcelTableCreatedEventHandler(exporter_ExcelTableCreated);

                excelExporter.RunExport(fileName.ToString());

                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        DialogResult dr = RadMessageBox.Show("The data in the grid was exported successfully. Do you want to open the file?",
                "Export to CSV", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            try
                            {
                                System.Diagnostics.Process.Start(fileName.ToString());
                            }
                            catch (Exception ex)
                            {
                                string message = String.Format("The file cannot be opened on your system.\nError message: {0}", ex.Message);
                                RadMessageBox.Show(message, "Open File", MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                        }
                    }));
                }
                else
                {

                    DialogResult dr = RadMessageBox.Show("The data in the grid was exported successfully. Do you want to open the file?",
                  "Export to CSV", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(fileName.ToString());
                        }
                        catch (Exception ex)
                        {
                            string message = String.Format("The file cannot be opened on your system.\nError message: {0}", ex.Message);
                            RadMessageBox.Show(message, "Open File", MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                    }
                }

            }
            catch (System.IO.IOException ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }));
                }
                else
                {
                    RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            finally
            {
                this.WorkCompleted();
            }

        }

        /// <summary>
        /// using ExcelTableCreated event for adding custom header row
        /// </summary>
        void exporter_ExcelTableCreated(object sender, ExcelTableCreatedEventArgs e)
        {
            if (e.SheetIndex == 0) //add header row only for the first excel sheet
            {
                SingleStyleElement style = ((ExportToExcelML)sender).AddCustomExcelRow(e.ExcelTableElement, 48, "TABLE's TITLE");
                style.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center;
                style.AlignmentElement.VerticalAlignment = VerticalAlignmentType.Center;

                style.InteriorStyle.Pattern = InteriorPatternType.Solid;
                style.InteriorStyle.Color = Color.Red;
                style.FontStyle.Color = Color.White;
                style.FontStyle.Bold = true;
                style.FontStyle.Size = 26;
            }
        }

        /// <summary>
        /// using ExcelCellFormatting event for updating progress bar and applying custom format in excel file
        /// </summary>
        void exporter_ExcelCellFormatting(object sender, ExcelCellFormattingEventArgs e)
        {

            if (e.GridRowInfoType == typeof(GridViewDataRowInfo))
            {
                //update progress bar
                int position = 100;// (int)(100 * (double)e.GridRowIndex / (double)(this.dgvFilter.RowCount - 1));
                this.UpdateProgressBar(position);



            }
        }


        private void WorkCompleted()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate
                {
                    this.radProgressBar1.Visible = false;

                }));
            }
            else
            {
                this.radProgressBar1.Visible = false;

            }
        }
        private void UpdateProgressBar(int value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate
                {
                    if (value < 100)
                    {
                        this.radProgressBar1.Value1 = value;
                    }
                    else
                    {
                        this.radProgressBar1.Value1 = 100;
                    }
                }));
            }
            else
            {
                if (value < 100)
                {
                    this.radProgressBar1.Value1 = value;
                }
                else
                {
                    this.radProgressBar1.Value1 = 100;
                }
            }
        }


        private void RunExportToCSV(string fileName, ref bool openExportFile)
        {
            ExportToCSV csvExporter = new ExportToCSV(this.dgvFilter);
            switch (this.radComboBoxSummaries.SelectedIndex)
            {
                case 0:
                    csvExporter.SummariesExportOption = SummariesOption.ExportAll;
                    break;
                case 1:
                    csvExporter.SummariesExportOption = SummariesOption.ExportOnlyTop;
                    break;
                case 2:
                    csvExporter.SummariesExportOption = SummariesOption.ExportOnlyBottom;
                    break;
                case 3:
                    csvExporter.SummariesExportOption = SummariesOption.DoNotExport;
                    break;
            }
            try
            {
                csvExporter.RunExport(fileName);

                RadMessageBox.SetThemeName(this.dgvFilter.ThemeName);
                DialogResult dr = RadMessageBox.Show("The data in the grid was exported successfully. Do you want to open the file?",
                    "Export to CSV", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openExportFile = true;
                }
            }
            catch (IOException ex)
            {
                RadMessageBox.SetThemeName(this.dgvFilter.ThemeName);
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void RunExportToHTML(string fileName, ref bool openExportFile)
        {
            ExportToHTML htmlExporter = new ExportToHTML(this.dgvFilter);

            switch (this.radComboBoxSummaries.SelectedIndex)
            {
                case 0:
                    htmlExporter.SummariesExportOption = SummariesOption.ExportAll;
                    break;
                case 1:
                    htmlExporter.SummariesExportOption = SummariesOption.ExportOnlyTop;
                    break;
                case 2:
                    htmlExporter.SummariesExportOption = SummariesOption.ExportOnlyBottom;
                    break;
                case 3:
                    htmlExporter.SummariesExportOption = SummariesOption.DoNotExport;
                    break;
            }

            //set exporting visual settings
            htmlExporter.ExportVisualSettings = this.exportVisualSettings;
            htmlExporter.TableCaption = this.radTextBoxSheet.Text;

            try
            {
                htmlExporter.RunExport(fileName);

                RadMessageBox.SetThemeName(this.dgvFilter.ThemeName);
                DialogResult dr = RadMessageBox.Show("The data in the grid was exported successfully. Do you want to open the file?",
                    "Export to HTML", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openExportFile = true;
                }
            }
            catch (IOException ex)
            {
                RadMessageBox.SetThemeName(this.dgvFilter.ThemeName);
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void RunExportToPDF(string fileName, ref bool openExportFile)
        {
            ExportToPDF pdfExporter = new ExportToPDF(this.dgvFilter);
            pdfExporter.PdfExportSettings.Title = "My PDF Title";
            pdfExporter.PdfExportSettings.PageWidth = 297;
            pdfExporter.PdfExportSettings.PageHeight = 210;
            pdfExporter.PageTitle = this.radTextBoxSheet.Text;
            pdfExporter.FitToPageWidth = true;

            switch (this.radComboBoxSummaries.SelectedIndex)
            {
                case 0:
                    pdfExporter.SummariesExportOption = SummariesOption.ExportAll;
                    break;
                case 1:
                    pdfExporter.SummariesExportOption = SummariesOption.ExportOnlyTop;
                    break;
                case 2:
                    pdfExporter.SummariesExportOption = SummariesOption.ExportOnlyBottom;
                    break;
                case 3:
                    pdfExporter.SummariesExportOption = SummariesOption.DoNotExport;
                    break;
            }

            //set exporting visual settings
            pdfExporter.ExportVisualSettings = this.exportVisualSettings;

            try
            {
                pdfExporter.RunExport(fileName);

                RadMessageBox.SetThemeName(this.dgvFilter.ThemeName);
                DialogResult dr = RadMessageBox.Show("The data in the grid was exported successfully. Do you want to open the file?",
                    "Export to PDF", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openExportFile = true;
                }

            }
            catch (IOException ex)
            {
                RadMessageBox.SetThemeName(this.dgvFilter.ThemeName);
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void radListBox1_SelectedIndexChanged_1(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            saveFileDialog.Filter = "Excel (*.xls)|*.xls";
            /*
            switch (this.radListBox1.SelectedIndex)
            {
                case 0: //export to excelML
                    this.radCheckBoxExportVisual.Enabled = true;
                    this.radRadioButton1.Enabled = true;
                    this.radRadioButton2.Enabled = true;
                    this.radTextBoxSheet.Enabled = true;
                    this.radComboBoxSummaries.Enabled = true;
                    this.radLabel1.Visible = true;
                    this.radLabel1.Text = "Sheet:";
                    this.radTextBoxSheet.Text = String.Empty;
                    this.radTextBoxSheet.Visible = true;

                    this.radProgressBar1.Visible = false;
                    this.radLblProgress.Visible = false;
                    break;
                case 1: //export to CSV
                    saveFileDialog.Filter = "CSV File (*.csv)|*.csv";
                    this.radCheckBoxExportVisual.Enabled = false;
                    this.radRadioButton1.Enabled = false;
                    this.radRadioButton2.Enabled = false;
                    this.radTextBoxSheet.Enabled = false;
                    this.radComboBoxSummaries.Enabled = true;
                    this.radLabel1.Visible = false;
                    this.radTextBoxSheet.Visible = false;

                    this.radProgressBar1.Visible = false;
                    this.radLblProgress.Visible = false;
                    break;
                case 2: //export to HTML
                    saveFileDialog.Filter = "Html File (*.htm)|*.htm";
                    this.radCheckBoxExportVisual.Enabled = true;
                    this.radRadioButton1.Enabled = false;
                    this.radRadioButton2.Enabled = false;
                    this.radTextBoxSheet.Enabled = true;
                    this.radComboBoxSummaries.Enabled = true;
                    this.radLabel1.Visible = true;
                    this.radLabel1.Text = "HtmlTable Caption:";
                    this.radTextBoxSheet.Text = String.Empty;
                    this.radTextBoxSheet.Visible = true;

                    this.radProgressBar1.Visible = false;
                    this.radLblProgress.Visible = false;
                    break;
                case 3: //export to PDF
                    saveFileDialog.Filter = "PDF File (*.pdf)|*.pdf";
                    this.radCheckBoxExportVisual.Enabled = true;
                    this.radRadioButton1.Enabled = false;
                    this.radRadioButton2.Enabled = false;
                    this.radTextBoxSheet.Enabled = true;
                    this.radComboBoxSummaries.Enabled = true;
                    this.radLabel1.Visible = true;
                    this.radLabel1.Text = "PdfTable Caption:";
                    this.radTextBoxSheet.Text = String.Empty;
                    this.radTextBoxSheet.Visible = true;

                    this.radProgressBar1.Visible = false;
                    this.radLblProgress.Visible = false;
                    break;
            }
            */
            //this.radButtonExport.Focus();
        }



        private void radButtonPrint_Click(object sender, EventArgs e)
        {
            this.dgvFilter.Print(true, this.radPrintDocument1);
        }

        private void radButtonPrintPreview_Click(object sender, EventArgs e)
        {


            //RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            //dialog.ThemeName = this.dgvFilter.ThemeName;
            //dialog.Document = this.radPrintDocument1;
            //radPrintDocument1.DefaultPageSettings.Landscape = true;

            //((Form)dialog).WindowState = FormWindowState.Maximized;
            //dialog.ShowDialog();

            GridPrintStyle style = new GridPrintStyle();
            style.FitWidthMode = PrintFitWidthMode.FitPageWidth;
            style.PrintAllPages = true;
            style.PrintGrouping = true;
            style.PrintHeaderOnEachPage = true;
            style.PrintSummaries = true;

            style.CellBackColor = Color.Aquamarine;
            style.CellFont = new Font("Arial", 13, FontStyle.Regular);
            style.CellPadding = new Padding(0, 0, 10, 0);

            style.GroupRowBackColor = Color.HotPink;
            style.GroupRowFont = new Font("Arial", 13, FontStyle.Italic);

            style.HeaderCellBackColor = Color.GreenYellow;
            style.HeaderCellFont = new Font("Arial", 12, FontStyle.Bold);

            style.SummaryCellBackColor = Color.DarkSeaGreen;
            style.SummaryCellFont = new Font("Arial", 12, FontStyle.Bold);

            this.dgvFilter.PrintStyle = style;
            this.dgvFilter.PrintPreview();



        }

        private void radButtonPrintSettings_Click(object sender, EventArgs e)
        {
            GridViewPrintSettingsDialog dialog = new GridViewPrintSettingsDialog();
            dialog.ThemeName = this.dgvFilter.ThemeName;
            dialog.ShowPreviewButton = false;
            dialog.PrintDocument = this.radPrintDocument1;
            dialog.StartPosition = FormStartPosition.CenterScreen;
            // dialog.PrintDocument.PaperSource.Kind = System.Drawing.Printing.PaperSourceKind.Custom;


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                radButtonPrintPreview_Click(sender, e);
            }
        }


        #endregion
        private void txtValueFrom_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblValue);
        }

        private void txtValueFrom_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblValue);
        }

        private void txtValueTo_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblValue);
        }

        private void txtValueTo_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblValue);
        }
        #endregion

        private void radBtnCrystalPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFilter.Rows.Count < 1)
                { return; }

                #region View
                switch (autoGenerateInfo.ModuleType)
                {
                    case 1: //Common Summary Report
                        ComReportGenerator comReportGenerator = new ComReportGenerator();
                        switch (autoGenerateInfo.ReportType)
                        {
                            case 1: // Reference
                                comReportGenerator.GenearateReferenceSummaryReport(autoGenerateInfo, SetGridViewSort(dgvFilter.DataSource as DataTable),
                                                                                GetConditionsDataTable(), GetReportFields(), GetGroupByFields());
                                break;
                            case 2: // Transaction
                                comReportGenerator.GenearateTransactionSummeryReport(autoGenerateInfo, SetGridViewSort(dgvFilter.DataSource as DataTable),
                                                                                GetConditionsDataTable(), GetReportFields(), GetGroupByFields(), chkLstGroupBy.CheckedIndices.Count < 1 ? true : chkViewGroupDetails.Checked);

                                break;
                            default:

                                break;
                        }

                        break;
                    case 2: //Inventory Summary Report
                        InvReportGenerator invReportGenerator = new InvReportGenerator();
                        switch (autoGenerateInfo.ReportType)
                        {
                            case 1: // Reference
                                invReportGenerator.GenearateReferenceSummaryReport(autoGenerateInfo, SetGridViewSort(dgvFilter.DataSource as DataTable),
                                                                                GetConditionsDataTable(), GetReportFields(), GetGroupByFields());
                                break;
                            case 2: // Transaction
                                invReportGenerator.GenearateTransactionSummeryReport(autoGenerateInfo, SetGridViewSort(dgvFilter.DataSource as DataTable),
                                                                                GetConditionsDataTable(), GetReportFields(), GetGroupByFields(), chkLstGroupBy.CheckedIndices.Count < 1 ? true : chkViewGroupDetails.Checked, IsComparisonReport());

                                break;
                            default:

                                break;
                        }

                        break;
                    case 3: //Logistic Summary Report
                        LgsReportGenerator lgsReportGenerator = new LgsReportGenerator();
                        switch (autoGenerateInfo.ReportType)
                        {
                            case 1: // Reference
                                lgsReportGenerator.GenearateReferenceSummaryReport(autoGenerateInfo, SetGridViewSort(dgvFilter.DataSource as DataTable),
                                                                            GetConditionsDataTable(), GetReportFields(), GetGroupByFields());
                                break;
                            case 2: // Transaction
                                lgsReportGenerator.GenearateTransactionSummeryReport(autoGenerateInfo, SetGridViewSort(dgvFilter.DataSource as DataTable),
                                                                            GetConditionsDataTable(), GetReportFields(), GetGroupByFields(), chkLstGroupBy.CheckedIndices.Count < 1 ? true : chkViewGroupDetails.Checked);

                                break;
                            default:

                                break;
                        }
                        break;
                    case 4: //CRM Summary Report
                        CrmReportGenerator crmReportGenerator;
                        switch (autoGenerateInfo.ReportType)
                        {

                            case 1: // Reference
                                crmReportGenerator = new CrmReportGenerator();
                                crmReportGenerator.GenearateCrmReport(autoGenerateInfo, SetGridViewSort(dgvFilter.DataSource as DataTable),
                                                                            GetConditionsDataTable(), GetReportFields(), GetGroupByFields());
                                break;
                            case 2: // Transaction
                                crmReportGenerator = new CrmReportGenerator();
                                crmReportGenerator.GenearateCrmReport(autoGenerateInfo, SetGridViewSort(dgvFilter.DataSource as DataTable),
                                                                            GetConditionsDataTable(), GetReportFields(), GetGroupByFields());
                                break;
                            default:

                                break;
                        }
                        break;
                    case 6: //Gift Voucher Summary Report
                        GvReportGenerator gvReportGenerator = new GvReportGenerator();
                        switch (autoGenerateInfo.ReportType)
                        {
                            case 1: // Reference

                                break;
                            case 2: // Transaction

                                gvReportGenerator.GenerateTransactionSummaryReport(autoGenerateInfo, SetGridViewSort(dgvFilter.DataSource as DataTable),
                                                                                GetConditionsDataTable(), GetReportFields(), GetGroupByFields(), GetOrderByFields());
                                break;
                            default:

                                break;
                        }
                        break;

                    case 7: //POS Summary Report
                        InvReportGenerator posReportGenerator = new InvReportGenerator();
                        switch (autoGenerateInfo.ReportType)
                        {
                            case 1: // Reference
                                posReportGenerator.GenearateReferenceSummaryReport(autoGenerateInfo, SetGridViewSort(dgvFilter.DataSource as DataTable),
                                                                                GetConditionsDataTable(), GetReportFields(), GetGroupByFields());
                                break;
                            case 2: // Transaction
                                posReportGenerator.GenearateTransactionSummeryReport(autoGenerateInfo, SetGridViewSort(dgvFilter.DataSource as DataTable),
                                                                                GetConditionsDataTable(), GetReportFields(), GetGroupByFields(), chkLstGroupBy.CheckedIndices.Count < 1 ? true : chkViewGroupDetails.Checked, IsComparisonReport());

                                break;
                            default:

                                break;
                        }

                        break;

                    case 15: //Restaurant Summary Report
                        ResReportGenerator resReportGenerator = new ResReportGenerator();
                        switch (autoGenerateInfo.ReportType)
                        {
                            case 1: // Reference
                                resReportGenerator.GenearateReferenceSummaryReport(autoGenerateInfo, SetGridViewSort(dgvFilter.DataSource as DataTable),
                                                                                                             GetConditionsDataTable(), GetReportFields(), GetGroupByFields());
                                break;
                            case 2: // Transaction


                                break;
                            default:

                                break;
                        }
                        break;

                    default:
                        break;
                }
                #endregion

            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void radMenuItemExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Excel ML|*.xls";
            saveFileDialog.Title = "Export to File";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (saveFileDialog.FileName.Equals(String.Empty))
            {
                RadMessageBox.SetThemeName(this.dgvFilter.ThemeName);
                RadMessageBox.Show("Please enter a file name.");
                return;
            }

            string fileName = this.saveFileDialog.FileName;
            bool openExportFile = false;

            if (this.radCheckBoxExportVisual.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                this.exportVisualSettings = true;
            }
            else
            {
                this.exportVisualSettings = false;
            }
            this.radProgressBar1.Text = "Exporting to ExcelML...";
            this.radProgressBar1.Value1 = 0;
            this.radProgressBar1.Visible = true;

            //export to excelML
            //RunExportToExcelML(fileName, ref openExportFile);
            Thread thread2 = new Thread(new ParameterizedThreadStart(RunExportToExcelML));
            thread2.Start(saveFileDialog.FileName);

        }

        private void radMenuItemPDF_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "PDF ER|*.pdf";
            saveFileDialog.Title = "Export to File";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (saveFileDialog.FileName.Equals(String.Empty))
            {
                RadMessageBox.SetThemeName(this.dgvFilter.ThemeName);
                RadMessageBox.Show("Please enter a file name.");
                return;
            }

            string fileName = this.saveFileDialog.FileName;
            bool openExportFile = false;

            if (this.radCheckBoxExportVisual.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                this.exportVisualSettings = true;
            }
            else
            {
                this.exportVisualSettings = false;
            }
            //export to PDF
            RunExportToPDF(fileName, ref openExportFile);


            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    string message = String.Format("The file cannot be opened on your system.\nError message: {0}", ex.Message);
                    RadMessageBox.Show(message, "Open File", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }

        private void radMenuItemCSV_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (saveFileDialog.FileName.Equals(String.Empty))
            {
                RadMessageBox.SetThemeName(this.dgvFilter.ThemeName);
                RadMessageBox.Show("Please enter a file name.");
                return;
            }

            string fileName = this.saveFileDialog.FileName;
            bool openExportFile = false;

            if (this.radCheckBoxExportVisual.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                this.exportVisualSettings = true;
            }
            else
            {
                this.exportVisualSettings = false;
            }
            //export to CSV
            RunExportToCSV(fileName, ref openExportFile);


            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    string message = String.Format("The file cannot be opened on your system.\nError message: {0}", ex.Message);
                    RadMessageBox.Show(message, "Open File", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }

        private void radBtnClose1_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Visible = true;
                tabReportViewer.Visible = false;
                //if (Toast.Show(this.Text, "", "Do you want to close this form?", Toast.messageType.Question, Toast.messageAction.General).Equals(DialogResult.Yes))
                //{
                //    this.Close();
                //    this.Dispose();

                //}
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }

        }

        private void radDropDownbtnPVExport_Click(object sender, EventArgs e)
        {

        }

        private void radMenuPVCSV_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (saveFileDialog.FileName.Equals(String.Empty))
            {
                RadMessageBox.SetThemeName(this.dgvFilter.ThemeName);
                RadMessageBox.Show("Please enter a file name.");
                return;
            }

            string fileName = this.saveFileDialog.FileName;
            bool openExportFile = false;



            this.exporter.RunExport(saveFileDialog.FileName);


            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    string message = String.Format("The file cannot be opened on your system.\nError message: {0}", ex.Message);
                    RadMessageBox.Show(message, "Open File", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }

        private void radMenuPVExcel_Click(object sender, EventArgs e)
        {

            bool openExportFile = false;


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel ML|*.xls";
            saveFileDialog1.Title = "Export to File";
            // saveFileDialog1.ShowDialog();

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (saveFileDialog1.FileName.Equals(String.Empty))
            {
                RadMessageBox.SetThemeName(this.dgvFilter.ThemeName);
                RadMessageBox.Show("Please enter a file name.");
                return;
            }


            if (saveFileDialog1.FileName != "")
            {
                this.exporter.RunExport(saveFileDialog1.FileName);
                // MessageBox.Show("Successfully exported to " + saveFileDialog1.FileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



                DialogResult dr = RadMessageBox.Show("The data in the grid was exported successfully. Do you want to open the file?",
                   "Export to CSV", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openExportFile = true;
                }
                this.radProgressBar2.Value1 = 0;

                if (openExportFile)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                    }
                    catch (Exception ex)
                    {
                        string message = String.Format("The file cannot be opened on your system.\nError message: {0}", ex.Message);
                        RadMessageBox.Show(message, "Open File", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }

            }




        }

        private void radMenuPVPDF_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (saveFileDialog.FileName.Equals(String.Empty))
            {
                RadMessageBox.SetThemeName(this.dgvFilter.ThemeName);
                RadMessageBox.Show("Please enter a file name.");
                return;
            }

            string fileName = this.saveFileDialog.FileName;
            bool openExportFile = false;

            if (this.radCheckBoxExportVisual.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                this.exportVisualSettings = true;
            }
            else
            {
                this.exportVisualSettings = false;
            }

            this.exporter.RunExport(saveFileDialog.FileName);


            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    string message = String.Format("The file cannot be opened on your system.\nError message: {0}", ex.Message);
                    RadMessageBox.Show(message, "Open File", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }

        private void radBtnClose_Click(object sender, EventArgs e)
        {

        }

        private void radPrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Bitmap bm = new Bitmap(this.dgvFilter.Width, this.dgvFilter.Height);
            //dgvFilter.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvFilter.Width, this.dgvFilter.Height));
            // e.Graphics.DrawImage(bm, 0, 0);
        }

        private void radBtnPivotPrint_Click(object sender, EventArgs e)
        {
            //GridViewPrintSettingsDialog dialog = new GridViewPrintSettingsDialog();
            //dialog.ThemeName = this.radPivotGrid1.ThemeName;
            //dialog.ShowPreviewButton = false;
            //dialog.PrintDocument = this.radPrintDocument2;
            //dialog.StartPosition = FormStartPosition.CenterScreen;
            //// dialog.PrintDocument.PaperSource.Kind = System.Drawing.Printing.PaperSourceKind.Custom;


            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    radBtnPivotPrintPreview_Click(sender, e);
            //}

            PivotGridPrintSettingsDialog dialog = new PivotGridPrintSettingsDialog(this.radPrintDocument2);
            dialog.ThemeName = this.radPivotGrid1.ThemeName;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.radPivotGrid1.PrintPreview(this.radPrintDocument2);
            }
        }

        private void radBtnPivotPrintPreview_Click(object sender, EventArgs e)
        {

            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            dialog.ThemeName = this.radPivotGrid1.ThemeName;
            dialog.Document = this.radPrintDocument2;
            radPrintDocument1.DefaultPageSettings.Landscape = true;
            //radPrintDocument1.page



            // dialog.Width = dgvFilter.Width;
            // dialog.Height = dgvFilter.Height;
            //dialog.StartPosition = FormStartPosition.WindowsDefaultLocation;
            ((Form)dialog).WindowState = FormWindowState.Maximized;
            dialog.ShowDialog();
        }

        private void radBtnBack1_Click(object sender, EventArgs e)
        {
            try
            {
                dgvFilter.DataSource = null;
                foreach (DataGridViewRow item in dgvValueRange.Rows)
                {
                    dgvValueRange.Rows.RemoveAt(item.Index);
                }
                dgvValueRange.DataSource = null;
                groupBox1.Visible = true;
                radPivotGrid1.DataSource = null;
                tabReportViewer.Visible = false;

            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }

        }

        private void radBtnBack1_Click_1(object sender, EventArgs e)
        {
            thread.Join();
            thread.Abort();
            FrmReprotGenerator_Load(this, new EventArgs());
            //groupBox1.Visible = true;
            //tabReportViewer.Visible = false;
            //if (Toast.Show(this.Text, "", "Do you want to close this form?", Toast.messageType.Question, Toast.messageAction.General).Equals(DialogResult.Yes))
            //{
            //    this.Close();
            //    this.Dispose();

            //}
        }

        private void btnSaveLayout_Click(object sender, EventArgs e)
        {
            if (cmbLayout.Text == string.Empty)
            {
                return;
            }
            else
            {
                if ((cmbLayout.Text.Length) < 3)
                {
                    return;
                }
            }

            if ((Toast.Show(this.Text, cmbLayout.Text.Trim(), " ", Toast.messageType.Question, Toast.messageAction.Save).Equals(DialogResult.No)))
            {
                return;
            }


            using (MemoryStream ms = new MemoryStream())
            {
                dgvFilter.SaveLayout(ms);
                layout = Encoding.ASCII.GetString(ms.GetBuffer(), 0, (int)ms.Length);

            }


            UserPrivilegesService userPrivilegesService = new UserPrivilegesService();

            int maxLayout = userPrivilegesService.GetMaxLayout();

            userPrivilegesService.UpdateUser(Common.LoggedUserId, layout, maxLayout, documentID, cmbLayout.Text.Trim());


            //string s = "default.xml"; SaveFileDialog dialog = new SaveFileDialog();
            //dialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            //dialog.Title = "Select a xml file";
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{ s = dialog.FileName; }
            //this.dgvFilter.SaveLayout(s);

            Toast.Show(this.Text, cmbLayout.Text.Trim(), "", Toast.messageType.Information, Toast.messageAction.Saved);


        }

        private void btnLoadLayout_Click(object sender, EventArgs e)
        {
            UserPrivilegesService userPrivilegesService = new UserPrivilegesService();
            layout = userPrivilegesService.GetLayoutByNames(cmbLayout.Text.Trim(), documentID);

            if (layout != string.Empty && layout != null)
            {
                MemoryStream contentStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(layout));
                this.dgvFilter.LoadLayout(contentStream);
                this.dgvFilter.Refresh();
            }
            //string s = "default.xml";
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            //dialog.Title = "Select a xml file";
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{ s = dialog.FileName; }
            //this.dgvFilter.LoadLayout(s);



        }

        private void dgvFilter_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridSummaryCellElement cell = e.CellElement as GridSummaryCellElement;
            if (cell != null)
            {
                e.CellElement.DrawFill = true;
                e.CellElement.ForeColor = Color.DarkBlue;
                e.CellElement.BackColor = Color.LightSeaGreen;
            }
        }

        //private void dgvFilter_GroupSummaryEvaluate(object sender, GroupSummaryEvaluationEventArgs e)
        //{
        //    foreach (Common.ReportDataStruct reportDataStructItem in reportDatStructList)
        //    {
        //        if (reportDataStructItem.IsColumnTotal && reportDataStructItem.Equals(typeof(decimal)))
        //        {
        //            if (e.SummaryItem.Name == reportDataStructItem.ReportFieldName.ToString().Trim())
        //            {
        //                decimal sum = e.Group.Sum(;
        //                //reportDataStructItem.ReportFieldName.ToString().Trim();
        //                e.FormatString = String.Format("There are {0} {1} and {2} of them is(are) from Canada.", count, e.Value, contactsInCanada);
        //            }
        //        }
        //    }



        //    if (e.SummaryItem.Name == "ContactTitle")
        //    {
        //        int count = e.Group.ItemCount;
        //        int contactsInCanada = 0;
        //        foreach (GridViewRowInfo row in e.Group)
        //        {
        //            if (row.Cells["Country"].Value.ToString() == "Canada")
        //            {
        //                contactsInCanada++;
        //            }
        //        }
        //        e.FormatString = String.Format("There are {0} {1} and {2} of them is(are) from Canada.", count, e.Value, contactsInCanada);
        //    }
        //}
    }


    public class MyGridGroupContentCellElement : GridGroupContentCellElement
    {
        private StackLayoutElement stack;
        private bool showSummaryCells = true;

        public MyGridGroupContentCellElement(GridViewColumn column, GridRowElement row)
            : base(column, row)
        {
            //creating the elements here in order to have a valid insance of a row
            if (this.stack == null)
            {
                this.CreateStackElement(row);
            }

            this.ClipDrawing = true;
            row.GridControl.TableElement.HScrollBar.Scroll += new ScrollEventHandler(HScrollBar_Scroll);
            row.GridControl.ColumnWidthChanged += new ColumnWidthChangedEventHandler(GridControl_ColumnWidthChanged);
            row.GridControl.GroupDescriptors.CollectionChanged += new NotifyCollectionChangedEventHandler(GroupDescriptors_CollectionChanged);
        }

        private void HScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                this.stack.PositionOffset = new SizeF(0 - e.NewValue, 0);
            }
        }

        private void GroupDescriptors_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.RowInfo.Parent is GridViewGroupRowInfo && ((GridViewGroupRowInfo)this.RowInfo.Parent).IsExpanded)
            {
                this.InvalidateArrange();
            }
        }

        private void CreateStackElement(GridRowElement row)
        {
            this.stack = new StackLayoutElement();
            this.stack.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            this.stack.AutoSize = true;
            this.stack.StretchHorizontally = true;
            this.stack.Alignment = ContentAlignment.BottomCenter;
            this.stack.DrawFill = true;
            this.stack.BackColor = Color.White;

            for (int i = 0; i < row.RowInfo.Cells.Count; i++)
            {
                SummaryCellElement element = new SummaryCellElement();
                element.ColumnName = row.RowInfo.Cells[i].ColumnInfo.Name;
                element.StretchHorizontally = false;
                element.StretchVertically = true;
                element.DrawBorder = true;
                element.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
                element.BorderColor = Color.LightBlue;
                this.stack.Children.Add(element);
            }

            this.Children.Add(this.stack);
        }

        public override void Initialize(GridViewColumn column, GridRowElement row)
        {
            base.Initialize(column, row);
            this.ShowSummaryCells = !row.Data.IsExpanded || row.Data.Group.Groups.Count > 0;
        }

        protected override void DisposeManagedResources()
        {
            if (this.GridControl != null)
            {
                this.GridControl.ColumnWidthChanged -= GridControl_ColumnWidthChanged;
                this.GridControl.GroupDescriptors.CollectionChanged -= GroupDescriptors_CollectionChanged;
            }

            base.DisposeManagedResources();
        }

        public bool ShowSummaryCells
        {
            get { return this.showSummaryCells; }
            set
            {
                if (this.showSummaryCells != value)
                {
                    this.showSummaryCells = value;

                    if (this.stack == null)
                    {
                        this.CreateStackElement(this.RowElement);
                    }

                    if (this.showSummaryCells)
                    {
                        this.stack.Visibility = ElementVisibility.Visible;
                    }
                    else
                    {
                        this.stack.Visibility = ElementVisibility.Hidden;
                    }
                }
            }
        }

        private void GridControl_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            this.InvalidateArrange();
        }

        protected override SizeF ArrangeOverride(SizeF finalSize)
        {
            SizeF size = base.ArrangeOverride(finalSize);

            float x = this.GridControl.TableElement.GroupIndent * (this.GridControl.GroupDescriptors.Count - this.RowInfo.Group.Level - 1);
            float y = size.Height - this.stack.DesiredSize.Height - 2f;
            float width = size.Width - x;
            float height = this.stack.DesiredSize.Height;

            this.stack.Arrange(new RectangleF(x, y, width, height));

            foreach (SummaryCellElement element in this.stack.Children)
            {
                Size elementSize = new Size(this.RowInfo.Cells[element.ColumnName].ColumnInfo.Width + this.GridControl.TableElement.CellSpacing, 0);
                element.MinSize = elementSize;
                element.MaxSize = elementSize;
            }

            return size;
        }

        public override void SetContent()
        {
            base.SetContent();

            this.ShowSummaryCells = !this.RowInfo.Group.IsExpanded || this.RowInfo.Group.Groups.Count > 0;

            GridViewGroupRowInfo rowInfo = (GridViewGroupRowInfo)this.RowInfo;

            if (rowInfo.Parent is GridViewGroupRowInfo && !((GridViewGroupRowInfo)rowInfo.Parent).IsExpanded)
            {
                return;
            }

            Dictionary<string, string> values = this.GetSummaryValues();
            int index = 0;

            foreach (KeyValuePair<string, string> column in values)
            {
                SummaryCellElement element = ((SummaryCellElement)this.stack.Children[index++]);

                if (this.ViewTemplate.Columns[column.Key].IsGrouped)
                {
                    element.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                }
                else
                {
                    element.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                    element.Text = column.Value;
                }
            }
        }

        public virtual Dictionary<string, string> GetSummaryValues()
        {
            if (this.ElementTree == null)
            {
                return new Dictionary<string, string>();
            }

            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (SummaryCellElement cell in this.stack.Children)
            {
                if (this.GridControl.SummaryRowsTop[0][cell.ColumnName] == null)
                {
                    result.Add(cell.ColumnName, String.Empty);
                }
                else
                {
                    GridViewSummaryItem summaryItem = this.GridControl.SummaryRowsTop[0][cell.ColumnName][0];
                    object value = this.ViewTemplate.DataView.Evaluate(summaryItem.GetSummaryExpression(), this.GetDataRows());
                    string text = string.Format(summaryItem.FormatString, value);
                    result.Add(summaryItem.Name, text);
                }
            }

            return result;
        }

        private IEnumerable<GridViewRowInfo> GetDataRows()
        {
            Queue<GridViewRowInfo> queue = new Queue<GridViewRowInfo>();
            queue.Enqueue(this.RowInfo);

            while (queue.Count != 0)
            {
                GridViewRowInfo currentRow = queue.Dequeue();

                if (currentRow is GridViewDataRowInfo)
                {
                    yield return currentRow;
                }

                foreach (GridViewRowInfo row in currentRow.ChildRows)
                {
                    queue.Enqueue(row);
                }
            }
        }

        protected override Type ThemeEffectiveType
        {
            get { return typeof(GridGroupContentCellElement); }
        }
    }


    public class SummaryCellElement : LightVisualElement
    {
        private string columnName;

        public string ColumnName
        {
            get { return this.columnName; }
            set { this.columnName = value; }
        }
    }
}
