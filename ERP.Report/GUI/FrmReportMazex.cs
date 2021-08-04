using RIT.ERP.Domain;
using RIT.ERP.Report.Inventory;
using RIT.ERP.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace RIT.ERP.Report.GUI
{
    public partial class FrmReportMazex : Telerik.WinControls.UI.RadForm
    {
        ArrayList stringField = new ArrayList();           // Eg:- {"Doc.No", "Date", "Pro.Code","Pro.Name"};
        ArrayList decimalField = new ArrayList();         //Eg:-  {"Net Amt","P.Size","F.Qty","C.Price", "Or.Qty"};    
        ArrayList decimalFieldSum = new ArrayList();
        ArrayList groupbyField = new ArrayList();
        ArrayList columnTotalField = new ArrayList();
        ArrayList rowTotalField = new ArrayList();
        ArrayList conditionField = new ArrayList();
        ArrayList orderByField = new ArrayList();


        List<InvMazeGenerator.ReportDataStruct> reportDatStructList = new List<InvMazeGenerator.ReportDataStruct>();
        AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();

        public FrmReportMazex()
        {
            InitializeComponent();
            this.SubscribeForGridEvents(this.dgvSelection);
            this.SubscribeForGridEvents(this.dgvBasket);
            this.dgvBasket.SelectionChanged += new EventHandler(dgvBasket_SelectionChanged);
        }

        public FrmReportMazex(AutoGenerateInfo pautoGenerateInfo, List<InvMazeGenerator.ReportDataStruct> pReportDatStructList)
        {
            InitializeComponent();

            for (int i = 0; i < pReportDatStructList.Count; i++)
            {
                //if (pReportDatStructList[i].IsSelectionField.Equals(true) && pReportDatStructList[i].ReportDataType.Equals(typeof(string)))
                //{ stringField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                //if (pReportDatStructList[i].IsSelectionField.Equals(true) && pReportDatStructList[i].IsNotDisplayedOrderBy.Equals(false))
                //{ orderByField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }
                //if (pReportDatStructList[i].IsSelectionField.Equals(true) && pReportDatStructList[i].ReportDataType.Equals(typeof(decimal)))
                //{ decimalField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                if (pReportDatStructList[i].IsConditionField.Equals(true))
                { conditionField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                //if (pReportDatStructList[i].IsGroupBy.Equals(true))
                //{ groupbyField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                //if (pReportDatStructList[i].IsColumnTotal.Equals(true))
                //{ columnTotalField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }

                //if (pReportDatStructList[i].IsRowTotal.Equals(true))
                //{ rowTotalField.Add(pReportDatStructList[i].ReportFieldName.ToString().Trim()); }
            }


            reportDatStructList = pReportDatStructList;
            autoGenerateInfo = pautoGenerateInfo;

            Text = Text + " - " + pautoGenerateInfo.FormText;

            

        }


        #region Red Grid Views

        private void PrepareGrid(RadGridView grid)
        {
            this.Left = 1;
            this.Top = 1;
            grid.TableElement.RowHeight = 35;
            grid.MasterTemplate.AllowRowReorder = true;
            grid.ReadOnly = true;
            grid.MultiSelect = true;
            grid.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grid.GridBehavior = new CustomGridBehavior();



        }

        private void SubscribeForGridEvents(RadGridView grid)
        {
            RadDragDropService dragDropService = grid.GridViewElement.GetService<RadDragDropService>();
            dragDropService.PreviewDragOver += new EventHandler<RadDragOverEventArgs>(dragDropService_PreviewDragOver);
            dragDropService.PreviewDragDrop += new EventHandler<RadDropEventArgs>(dragDropService_PreviewDragDrop);
            dragDropService.PreviewDragHint += new EventHandler<PreviewDragHintEventArgs>(dragDropService_PreviewDragHint);
            //grid.CellFormatting += new CellFormattingEventHandler(grid_CellFormatting);
            grid.Rows.CollectionChanged += new Telerik.WinControls.Data.NotifyCollectionChangedEventHandler(Rows_CollectionChanged);
        }

        #region Drag & drop logic

        private void dragDropService_PreviewDragDrop(object sender, RadDropEventArgs e)
        {
            SnapshotDragItem dragInstance = e.DragInstance as SnapshotDragItem;

            if (dragInstance == null)
            {
                return;
            }

            RadItem dropTarget = e.HitTarget as RadItem;
            RadGridView targetGrid = dropTarget.ElementTree.Control as RadGridView;

            if (targetGrid == null)
            {
                return;
            }

            RadGridView dragGrid = dragInstance.Item.ElementTree.Control as RadGridView;

            if (targetGrid != dragGrid)
            {
                e.Handled = true;

                CustomGridBehavior behavior = (CustomGridBehavior)dragGrid.GridBehavior;
                GridDataRowElement dropTargetRow = dropTarget as GridDataRowElement;
                int index = dropTargetRow != null ? this.GetTargetRowIndex(dropTargetRow, e.DropLocation) : targetGrid.RowCount;
                this.MoveRows(targetGrid, dragGrid, behavior.SelectedRows, index);
            }
        }

        private void MoveRows(RadGridView targetGrid, RadGridView dragGrid, IList<GridViewRowInfo> dragRows, int index)
        {
            for (int i = dragRows.Count - 1; i >= 0; i--)
            {
                GridViewRowInfo row = dragRows[i];

                if (row is GridViewSummaryRowInfo)
                {
                    continue;
                }

                GridViewRowInfo newRow = targetGrid.Rows.NewRow();
                this.InitializeRow(newRow, row);
                targetGrid.Rows.Insert(index, newRow);
                row.IsSelected = false;
                dragGrid.Rows.Remove(row);
                index++;
            }
        }

        private void InitializeRow(GridViewRowInfo destRow, GridViewRowInfo sourceRow)
        {
            destRow.Cells["Code"].Value = sourceRow.Cells["Code"].Value;
            destRow.Cells["Name"].Value = sourceRow.Cells["Name"].Value;
        }

        private int GetTargetRowIndex(GridDataRowElement row, Point dropLocation)
        {
            int halfHeight = row.Size.Height / 2;
            int index = row.RowInfo.Index;

            if (dropLocation.Y > halfHeight)
            {
                index++;
            }

            return index;
        }

        private void dragDropService_PreviewDragOver(object sender, RadDragOverEventArgs e)
        {
            if (e.DragInstance is SnapshotDragItem)
            {
                e.CanDrop = e.HitTarget is GridDataRowElement || e.HitTarget is GridTableElement || e.HitTarget is GridSummaryRowElement;
            }
        }

        private void dragDropService_PreviewDragHint(object sender, PreviewDragHintEventArgs e)
        {
            SnapshotDragItem dragInstance = e.DragInstance as SnapshotDragItem;

            if (dragInstance == null)
            {
                return;
            }

            GridViewRowInfo rowInfo = e.DragInstance.GetDataContext() as GridViewRowInfo;

            if (rowInfo != null && rowInfo.ViewTemplate.MasterTemplate.SelectedRows.Count > 1)
            {
                //e.DragHint = new Bitmap(this.imageList1.Images[6]);
                e.UseDefaultHint = false;
            }
        }

        #endregion

        private void Rows_CollectionChanged(object sender, Telerik.WinControls.Data.NotifyCollectionChangedEventArgs e)
        {
            GridViewRowCollection rows = sender as GridViewRowCollection;

            if (rows.Owner.MasterTemplate == this.dgvBasket.MasterTemplate)
            {
                bool isSummaryRowOnlySelected = this.dgvBasket.SelectedRows.Count == 1 && this.dgvBasket.SelectedRows[0] is GridViewSummaryRowInfo;
                bool isEnabled = rows.Count > 0 && !isSummaryRowOnlySelected;

                btnReturnAll.Enabled = isEnabled;
                btnReturnSelected.Enabled = isEnabled;
            }
            else
            {
                btnCheckoutAll.Enabled = rows.Count > 0;
                btnCheckoutSelected.Enabled = rows.Count > 0;
            }
        }

        private void dgvBasket_SelectionChanged(object sender, EventArgs e)
        {
            RadGridView grid = sender as RadGridView;
            btnReturnSelected.Enabled = true;
            btnReturnAll.Enabled = true;
            if (grid == this.dgvBasket)
            {
                bool isSummaryRowOnlySelected = this.dgvBasket.SelectedRows.Count == 1 && this.dgvBasket.SelectedRows[0] is GridViewSummaryRowInfo;
                btnReturnSelected.Enabled = !isSummaryRowOnlySelected;
            }
        }

        #endregion

        #region Red Combo box

        private void LoadSelectionCombo()
        {

            // 
            //this.cmbValueType.SelectedIndexChanged -= new System.EventHandler(this.cmbValueType_SelectedIndexChanged);
            //cmbValueType.DataSource = conditionField;
            //cmbValueType.SelectedIndex = -1;
            //this.cmbValueType.SelectedIndexChanged += new System.EventHandler(this.cmbValueType_SelectedIndexChanged);

            this.redCmbSelection.DataSource = conditionField;
            redCmbSelection.SelectedIndex = -1;


        }

        #endregion


        private void FrmReportMaze_Load(object sender, EventArgs e)
        {
            this.PrepareGrid(this.dgvBasket);
            this.PrepareGrid(this.dgvSelection);

            LoadSelectionCombo();
        }

        private void redCmbSelection_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (redCmbSelection.SelectedIndex < 0)
                { return; }

                LoadSelectionData();
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }

        }

        private void LoadSelectionData()
        {

            InvMazeGenerator invMazeGenerator = new InvMazeGenerator();
            dgvSelection.DataSource = invMazeGenerator.FillGridSelected(redCmbSelection.SelectedItem.ToString().Trim(), autoGenerateInfo);
            //cmbValueTo.DataSource = posReportGenerator.GetSelectionData(GetSelectedReportDataStruct(cmbValueType.SelectedItem.ToString().Trim()), autoGenerateInfo);

        }
    }
}
