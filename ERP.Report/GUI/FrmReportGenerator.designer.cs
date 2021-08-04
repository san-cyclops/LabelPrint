using ERP.Report.GUI.CustomControls;

namespace ERP.Report
{
    partial class FrmReprotGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReprotGenerator));
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadPrintWatermark radPrintWatermark1 = new Telerik.WinControls.UI.RadPrintWatermark();
            Telerik.WinControls.UI.RadPrintWatermark radPrintWatermark2 = new Telerik.WinControls.UI.RadPrintWatermark();
            this.gbFieldSelection = new System.Windows.Forms.Panel();
            this.chkLstFieldSelectionStr = new System.Windows.Forms.CheckedListBox();
            this.chkLstFieldSelectionDes = new System.Windows.Forms.CheckedListBox();
            this.radPivotFieldList1 = new Telerik.WinControls.UI.RadPivotFieldList();
            this.radPivotGrid1 = new Telerik.WinControls.UI.RadPivotGrid();
            this.dgvFilter = new Telerik.WinControls.UI.RadGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.Panel();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.cmbValueFrom = new Telerik.WinControls.UI.RadDropDownList();
            this.txtValueFrom = new TextBoxNumericMinus();
            this.cmbValueTo = new Telerik.WinControls.UI.RadDropDownList();
            this.cmbValueType = new Telerik.WinControls.UI.RadDropDownList();
            this.dgvValueRange = new System.Windows.Forms.DataGridView();
            this.ValueType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblValue = new System.Windows.Forms.Label();
            this.btnValueAdd = new System.Windows.Forms.Button();
            this.lblValueType = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtValueTo = new global::ERP.UI.Windows.CustomControls.TextBoxNumeric();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.tabReportViewer = new System.Windows.Forms.TabControl();
            this.tabPageReport = new System.Windows.Forms.TabPage();
            this.lblProgress = new Telerik.WinControls.UI.RadLabel();
            this.radWaitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.radGroupSettings = new Telerik.WinControls.UI.RadGroupBox();
            this.cmbLayout = new Telerik.WinControls.UI.RadDropDownList();
            this.btnLoadLayout = new Telerik.WinControls.UI.RadButton();
            this.btnSaveLayout = new Telerik.WinControls.UI.RadButton();
            this.radProgressBar1 = new Telerik.WinControls.UI.RadProgressBar();
            this.radBtnBack1 = new Telerik.WinControls.UI.RadButton();
            this.radLblProgress = new Telerik.WinControls.UI.RadLabel();
            this.radDropDownbtnViewer = new Telerik.WinControls.UI.RadDropDownButton();
            this.radMenuItemExcel = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemPDF = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemCSV = new Telerik.WinControls.UI.RadMenuItem();
            this.radBtnCrystalPrint = new Telerik.WinControls.UI.RadButton();
            this.radButtonPrint = new Telerik.WinControls.UI.RadButton();
            this.radButtonPrintPreview = new Telerik.WinControls.UI.RadButton();
            this.radButtonPrintSettings = new Telerik.WinControls.UI.RadButton();
            this.radTextBoxSheet = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radRadioButton1 = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton2 = new Telerik.WinControls.UI.RadRadioButton();
            this.radComboBoxSummaries = new Telerik.WinControls.UI.RadDropDownList();
            this.radCheckBoxExportVisual = new Telerik.WinControls.UI.RadCheckBox();
            this.tabPagePivot = new System.Windows.Forms.TabPage();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radDropDownbtnPVExport = new Telerik.WinControls.UI.RadDropDownButton();
            this.radMenuPVExcel = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuPVPDF = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuPVCSV = new Telerik.WinControls.UI.RadMenuItem();
            this.radBtnClose1 = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radBtnPivotPrintPreview = new Telerik.WinControls.UI.RadButton();
            this.radBtnPivotPrint = new Telerik.WinControls.UI.RadButton();
            this.radProgressBar2 = new Telerik.WinControls.UI.RadProgressBar();
            this.gbRowTotal = new System.Windows.Forms.Panel();
            this.chkRowTotal = new System.Windows.Forms.CheckedListBox();
            this.gbColumnTotal = new System.Windows.Forms.Panel();
            this.chklstColumnTotal = new System.Windows.Forms.CheckedListBox();
            this.gbGroupBy = new System.Windows.Forms.Panel();
            this.btnGroupByDown = new System.Windows.Forms.Button();
            this.btnGroupByUp = new System.Windows.Forms.Button();
            this.chkViewGroupDetails = new System.Windows.Forms.CheckBox();
            this.chkLstGroupBy = new System.Windows.Forms.CheckedListBox();
            this.gbOrderBy = new System.Windows.Forms.Panel();
            this.chkLstOrderBy = new System.Windows.Forms.CheckedListBox();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.radPrintDocument1 = new Telerik.WinControls.UI.RadPrintDocument();
            this.radPrintDocument2 = new Telerik.WinControls.UI.RadPrintDocument();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gbFieldSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter.MasterTemplate)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbValueFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbValueTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbValueType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValueRange)).BeginInit();
            this.tabReportViewer.SuspendLayout();
            this.tabPageReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupSettings)).BeginInit();
            this.radGroupSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnBack1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLblProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownbtnViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCrystalPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonPrintPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonPrintSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radComboBoxSummaries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBoxExportVisual)).BeginInit();
            this.tabPagePivot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownbtnPVExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnClose1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnPivotPrintPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnPivotPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar2)).BeginInit();
            this.gbRowTotal.SuspendLayout();
            this.gbColumnTotal.SuspendLayout();
            this.gbGroupBy.SuspendLayout();
            this.gbOrderBy.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(421, 342);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.grpButtonSet.Location = new System.Drawing.Point(9, 339);
            this.grpButtonSet.Size = new System.Drawing.Size(81, 41);
            this.grpButtonSet.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(2, 5);
            // 
            // gbFieldSelection
            // 
            this.gbFieldSelection.Controls.Add(this.chkLstFieldSelectionStr);
            this.gbFieldSelection.Controls.Add(this.chkLstFieldSelectionDes);
            this.gbFieldSelection.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFieldSelection.Location = new System.Drawing.Point(289, 42);
            this.gbFieldSelection.Name = "gbFieldSelection";
            this.gbFieldSelection.Size = new System.Drawing.Size(79, 44);
            this.gbFieldSelection.TabIndex = 19;
            this.gbFieldSelection.Text = "Field Selection";
            // 
            // chkLstFieldSelectionStr
            // 
            this.chkLstFieldSelectionStr.CheckOnClick = true;
            this.chkLstFieldSelectionStr.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLstFieldSelectionStr.FormattingEnabled = true;
            this.chkLstFieldSelectionStr.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07"});
            this.chkLstFieldSelectionStr.Location = new System.Drawing.Point(17, 21);
            this.chkLstFieldSelectionStr.MultiColumn = true;
            this.chkLstFieldSelectionStr.Name = "chkLstFieldSelectionStr";
            this.chkLstFieldSelectionStr.Size = new System.Drawing.Size(563, 84);
            this.chkLstFieldSelectionStr.TabIndex = 13;
            this.chkLstFieldSelectionStr.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionStr_ItemCheck);
            // 
            // chkLstFieldSelectionDes
            // 
            this.chkLstFieldSelectionDes.CheckOnClick = true;
            this.chkLstFieldSelectionDes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLstFieldSelectionDes.FormattingEnabled = true;
            this.chkLstFieldSelectionDes.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07"});
            this.chkLstFieldSelectionDes.Location = new System.Drawing.Point(17, 111);
            this.chkLstFieldSelectionDes.MultiColumn = true;
            this.chkLstFieldSelectionDes.Name = "chkLstFieldSelectionDes";
            this.chkLstFieldSelectionDes.Size = new System.Drawing.Size(562, 84);
            this.chkLstFieldSelectionDes.TabIndex = 14;
            this.chkLstFieldSelectionDes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstFieldSelectionDes_ItemCheck);
            // 
            // radPivotFieldList1
            // 
            this.radPivotFieldList1.AssociatedPivotGrid = this.radPivotGrid1;
            this.radPivotFieldList1.Location = new System.Drawing.Point(1073, 3);
            this.radPivotFieldList1.MinimumSize = new System.Drawing.Size(262, 305);
            this.radPivotFieldList1.Name = "radPivotFieldList1";
            this.radPivotFieldList1.Size = new System.Drawing.Size(262, 639);
            this.radPivotFieldList1.TabIndex = 38;
            // 
            // radPivotGrid1
            // 
            this.radPivotGrid1.Location = new System.Drawing.Point(5, 4);
            this.radPivotGrid1.Name = "radPivotGrid1";
            this.radPivotGrid1.Size = new System.Drawing.Size(1062, 639);
            this.radPivotGrid1.TabIndex = 37;
            this.radPivotGrid1.Text = "radPivotGrid1";
            // 
            // dgvFilter
            // 
            this.dgvFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.dgvFilter.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvFilter.Location = new System.Drawing.Point(3, 24);
            // 
            // 
            // 
            this.dgvFilter.MasterTemplate.AllowAddNewRow = false;
            this.dgvFilter.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgvFilter.Name = "dgvFilter";
            this.dgvFilter.ReadOnly = true;
            this.dgvFilter.Size = new System.Drawing.Size(1325, 623);
            this.dgvFilter.TabIndex = 36;
            this.dgvFilter.Text = "radGridView1";
            this.dgvFilter.ViewCellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.dgvFilter_ViewCellFormatting);
            this.dgvFilter.DoubleClick += new System.EventHandler(this.dgvResult_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(262, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 150);
            this.panel1.TabIndex = 35;
            this.panel1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 123);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.Text = "Comparisson";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(11, 91);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(138, 17);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Previous Month to Date";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(11, 68);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(130, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Previous Year to Date";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(11, 45);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(94, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Month to Date";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(11, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Year to Date";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbValueFrom);
            this.groupBox1.Controls.Add(this.txtValueFrom);
            this.groupBox1.Controls.Add(this.cmbValueTo);
            this.groupBox1.Controls.Add(this.cmbValueType);
            this.groupBox1.Controls.Add(this.dgvValueRange);
            this.groupBox1.Controls.Add(this.lblValue);
            this.groupBox1.Controls.Add(this.btnValueAdd);
            this.groupBox1.Controls.Add(this.lblValueType);
            this.groupBox1.Controls.Add(this.dtpDateFrom);
            this.groupBox1.Controls.Add(this.txtValueTo);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Location = new System.Drawing.Point(5, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 380);
            this.groupBox1.TabIndex = 30;
            // 
            // cmbValueFrom
            // 
            this.cmbValueFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbValueFrom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbValueFrom.Location = new System.Drawing.Point(119, 50);
            this.cmbValueFrom.Name = "cmbValueFrom";
            this.cmbValueFrom.Size = new System.Drawing.Size(256, 21);
            this.cmbValueFrom.TabIndex = 38;
            // 
            // txtValueFrom
            // 
            this.txtValueFrom.Location = new System.Drawing.Point(119, 50);
            this.txtValueFrom.Name = "txtValueFrom";
            this.txtValueFrom.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValueFrom.Size = new System.Drawing.Size(256, 21);
            this.txtValueFrom.TabIndex = 34;
            this.txtValueFrom.Enter += new System.EventHandler(this.txtValueFrom_Enter);
            this.txtValueFrom.Leave += new System.EventHandler(this.txtValueFrom_Leave);
            // 
            // cmbValueTo
            // 
            this.cmbValueTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbValueTo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbValueTo.Location = new System.Drawing.Point(119, 76);
            this.cmbValueTo.Name = "cmbValueTo";
            this.cmbValueTo.Size = new System.Drawing.Size(256, 21);
            this.cmbValueTo.TabIndex = 39;
            // 
            // cmbValueType
            // 
            this.cmbValueType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbValueType.Location = new System.Drawing.Point(118, 22);
            this.cmbValueType.Name = "cmbValueType";
            this.cmbValueType.Size = new System.Drawing.Size(257, 19);
            this.cmbValueType.TabIndex = 37;
            this.cmbValueType.SelectedValueChanged += new System.EventHandler(this.cmbValueType_SelectedIndexChanged);
            this.cmbValueType.Enter += new System.EventHandler(this.cmbValueType_Enter);
            this.cmbValueType.Leave += new System.EventHandler(this.cmbValueType_Leave);
            // 
            // dgvValueRange
            // 
            this.dgvValueRange.AllowDrop = true;
            this.dgvValueRange.AllowUserToAddRows = false;
            this.dgvValueRange.AllowUserToDeleteRows = false;
            this.dgvValueRange.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvValueRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvValueRange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValueRange.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValueType,
            this.ValueFrom,
            this.ValueTo,
            this.ValueTypeId});
            this.dgvValueRange.Location = new System.Drawing.Point(11, 112);
            this.dgvValueRange.Name = "dgvValueRange";
            this.dgvValueRange.ReadOnly = true;
            this.dgvValueRange.RowHeadersVisible = false;
            this.dgvValueRange.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvValueRange.Size = new System.Drawing.Size(643, 208);
            this.dgvValueRange.TabIndex = 21;
            this.dgvValueRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvValueRange_KeyDown);
            // 
            // ValueType
            // 
            this.ValueType.HeaderText = "Value Type";
            this.ValueType.Name = "ValueType";
            this.ValueType.ReadOnly = true;
            this.ValueType.Width = 130;
            // 
            // ValueFrom
            // 
            this.ValueFrom.HeaderText = "Value From";
            this.ValueFrom.Name = "ValueFrom";
            this.ValueFrom.ReadOnly = true;
            this.ValueFrom.Width = 200;
            // 
            // ValueTo
            // 
            this.ValueTo.HeaderText = "Value To";
            this.ValueTo.Name = "ValueTo";
            this.ValueTo.ReadOnly = true;
            this.ValueTo.Width = 200;
            // 
            // ValueTypeId
            // 
            this.ValueTypeId.HeaderText = "ValueTypeId";
            this.ValueTypeId.Name = "ValueTypeId";
            this.ValueTypeId.ReadOnly = true;
            this.ValueTypeId.Visible = false;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(19, 54);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(43, 13);
            this.lblValue.TabIndex = 28;
            this.lblValue.Text = "Range";
            // 
            // btnValueAdd
            // 
            this.btnValueAdd.Font = new System.Drawing.Font("Verdana", 10.25F);
            this.btnValueAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnValueAdd.Image")));
            this.btnValueAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnValueAdd.Location = new System.Drawing.Point(536, 23);
            this.btnValueAdd.Name = "btnValueAdd";
            this.btnValueAdd.Size = new System.Drawing.Size(110, 68);
            this.btnValueAdd.TabIndex = 9;
            this.btnValueAdd.Text = "Add Selection";
            this.btnValueAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValueAdd.UseVisualStyleBackColor = true;
            this.btnValueAdd.Click += new System.EventHandler(this.btnValueAdd_Click);
            // 
            // lblValueType
            // 
            this.lblValueType.AutoSize = true;
            this.lblValueType.Location = new System.Drawing.Point(19, 22);
            this.lblValueType.Name = "lblValueType";
            this.lblValueType.Size = new System.Drawing.Size(59, 13);
            this.lblValueType.TabIndex = 7;
            this.lblValueType.Text = "Selection";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(119, 49);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(256, 21);
            this.dtpDateFrom.TabIndex = 31;
            this.dtpDateFrom.Visible = false;
            // 
            // txtValueTo
            // 
            this.txtValueTo.Location = new System.Drawing.Point(119, 76);
            this.txtValueTo.Name = "txtValueTo";
            this.txtValueTo.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValueTo.Size = new System.Drawing.Size(256, 21);
            this.txtValueTo.TabIndex = 29;
            this.txtValueTo.Visible = false;
            this.txtValueTo.Enter += new System.EventHandler(this.txtValueTo_Enter);
            this.txtValueTo.Leave += new System.EventHandler(this.txtValueTo_Leave);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(119, 76);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(256, 21);
            this.dtpDateTo.TabIndex = 32;
            this.dtpDateTo.Visible = false;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(118, 50);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(256, 21);
            this.txtValue.TabIndex = 33;
            // 
            // tabReportViewer
            // 
            this.tabReportViewer.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabReportViewer.Controls.Add(this.tabPageReport);
            this.tabReportViewer.Controls.Add(this.tabPagePivot);
            this.tabReportViewer.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabReportViewer.Location = new System.Drawing.Point(9, 9);
            this.tabReportViewer.Name = "tabReportViewer";
            this.tabReportViewer.SelectedIndex = 0;
            this.tabReportViewer.Size = new System.Drawing.Size(1345, 740);
            this.tabReportViewer.TabIndex = 36;
            this.tabReportViewer.Visible = false;
            // 
            // tabPageReport
            // 
            this.tabPageReport.Controls.Add(this.lblProgress);
            this.tabPageReport.Controls.Add(this.radWaitingBar);
            this.tabPageReport.Controls.Add(this.dgvFilter);
            this.tabPageReport.Controls.Add(this.radGroupSettings);
            this.tabPageReport.Location = new System.Drawing.Point(4, 30);
            this.tabPageReport.Name = "tabPageReport";
            this.tabPageReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReport.Size = new System.Drawing.Size(1337, 706);
            this.tabPageReport.TabIndex = 0;
            this.tabPageReport.Text = "   Report Viewer";
            this.tabPageReport.UseVisualStyleBackColor = true;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProgress.ForeColor = System.Drawing.Color.Black;
            this.lblProgress.Location = new System.Drawing.Point(7, 1);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(52, 18);
            this.lblProgress.TabIndex = 38;
            this.lblProgress.Text = "Progress:";
            this.lblProgress.Visible = false;
            // 
            // radWaitingBar
            // 
            this.radWaitingBar.Location = new System.Drawing.Point(63, 5);
            this.radWaitingBar.Name = "radWaitingBar";
            this.radWaitingBar.Size = new System.Drawing.Size(1264, 14);
            this.radWaitingBar.TabIndex = 37;
            this.radWaitingBar.Text = "radWaitingBar1";
            // 
            // radGroupSettings
            // 
            this.radGroupSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupSettings.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radGroupSettings.Controls.Add(this.cmbLayout);
            this.radGroupSettings.Controls.Add(this.btnLoadLayout);
            this.radGroupSettings.Controls.Add(this.btnSaveLayout);
            this.radGroupSettings.Controls.Add(this.radProgressBar1);
            this.radGroupSettings.Controls.Add(this.radBtnBack1);
            this.radGroupSettings.Controls.Add(this.radLblProgress);
            this.radGroupSettings.Controls.Add(this.radDropDownbtnViewer);
            this.radGroupSettings.Controls.Add(this.radBtnCrystalPrint);
            this.radGroupSettings.Controls.Add(this.radButtonPrint);
            this.radGroupSettings.Controls.Add(this.radButtonPrintPreview);
            this.radGroupSettings.Controls.Add(this.radButtonPrintSettings);
            this.radGroupSettings.Controls.Add(this.radTextBoxSheet);
            this.radGroupSettings.Controls.Add(this.radLabel1);
            this.radGroupSettings.Controls.Add(this.radRadioButton1);
            this.radGroupSettings.Controls.Add(this.radRadioButton2);
            this.radGroupSettings.Controls.Add(this.radComboBoxSummaries);
            this.radGroupSettings.Controls.Add(this.radCheckBoxExportVisual);
            this.radGroupSettings.FooterText = "";
            this.radGroupSettings.ForeColor = System.Drawing.Color.Black;
            this.radGroupSettings.HeaderText = "";
            this.radGroupSettings.Location = new System.Drawing.Point(-145, 648);
            this.radGroupSettings.Name = "radGroupSettings";
            this.radGroupSettings.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.radGroupSettings.Size = new System.Drawing.Size(1477, 55);
            this.radGroupSettings.TabIndex = 35;
            // 
            // cmbLayout
            // 
            this.cmbLayout.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbLayout.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            this.cmbLayout.Location = new System.Drawing.Point(856, 11);
            this.cmbLayout.Name = "cmbLayout";
            this.cmbLayout.Size = new System.Drawing.Size(199, 20);
            this.cmbLayout.TabIndex = 41;
            // 
            // btnLoadLayout
            // 
            this.btnLoadLayout.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadLayout.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadLayout.Location = new System.Drawing.Point(1061, 8);
            this.btnLoadLayout.Name = "btnLoadLayout";
            this.btnLoadLayout.Size = new System.Drawing.Size(98, 38);
            this.btnLoadLayout.TabIndex = 40;
            this.btnLoadLayout.Text = "Load Layout";
            this.btnLoadLayout.Click += new System.EventHandler(this.btnLoadLayout_Click);
            // 
            // btnSaveLayout
            // 
            this.btnSaveLayout.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSaveLayout.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveLayout.Location = new System.Drawing.Point(1181, 8);
            this.btnSaveLayout.Name = "btnSaveLayout";
            this.btnSaveLayout.Size = new System.Drawing.Size(49, 38);
            this.btnSaveLayout.TabIndex = 39;
            this.btnSaveLayout.Text = "Save Layout";
            this.btnSaveLayout.Click += new System.EventHandler(this.btnSaveLayout_Click);
            // 
            // radProgressBar1
            // 
            this.radProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radProgressBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radProgressBar1.ForeColor = System.Drawing.Color.Black;
            this.radProgressBar1.Location = new System.Drawing.Point(496, 30);
            this.radProgressBar1.Maximum = 500;
            this.radProgressBar1.Name = "radProgressBar1";
            this.radProgressBar1.SeparatorColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.radProgressBar1.SeparatorWidth = 4;
            this.radProgressBar1.Size = new System.Drawing.Size(199, 19);
            this.radProgressBar1.StepWidth = 13;
            this.radProgressBar1.TabIndex = 5;
            this.radProgressBar1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radBtnBack1
            // 
            this.radBtnBack1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radBtnBack1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBtnBack1.Location = new System.Drawing.Point(1356, 8);
            this.radBtnBack1.Name = "radBtnBack1";
            this.radBtnBack1.Size = new System.Drawing.Size(114, 38);
            this.radBtnBack1.TabIndex = 38;
            this.radBtnBack1.Text = "Close";
            this.radBtnBack1.Click += new System.EventHandler(this.radBtnBack1_Click_1);
            // 
            // radLblProgress
            // 
            this.radLblProgress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radLblProgress.ForeColor = System.Drawing.Color.Black;
            this.radLblProgress.Location = new System.Drawing.Point(410, 30);
            this.radLblProgress.Name = "radLblProgress";
            this.radLblProgress.Size = new System.Drawing.Size(52, 18);
            this.radLblProgress.TabIndex = 7;
            this.radLblProgress.Text = "Progress:";
            // 
            // radDropDownbtnViewer
            // 
            this.radDropDownbtnViewer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDropDownbtnViewer.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItemExcel,
            this.radMenuItemPDF,
            this.radMenuItemCSV});
            this.radDropDownbtnViewer.Location = new System.Drawing.Point(715, 8);
            this.radDropDownbtnViewer.Name = "radDropDownbtnViewer";
            this.radDropDownbtnViewer.Size = new System.Drawing.Size(117, 38);
            this.radDropDownbtnViewer.TabIndex = 37;
            this.radDropDownbtnViewer.Text = "Export";
            // 
            // radMenuItemExcel
            // 
            this.radMenuItemExcel.AccessibleDescription = "Export To Excel";
            this.radMenuItemExcel.AccessibleName = "Export To Excel";
            this.radMenuItemExcel.Name = "radMenuItemExcel";
            this.radMenuItemExcel.Text = "Export To Excel";
            this.radMenuItemExcel.Click += new System.EventHandler(this.radMenuItemExcel_Click);
            // 
            // radMenuItemPDF
            // 
            this.radMenuItemPDF.AccessibleDescription = "Export to PDF";
            this.radMenuItemPDF.AccessibleName = "Export to PDF";
            this.radMenuItemPDF.Name = "radMenuItemPDF";
            this.radMenuItemPDF.Text = "Export to PDF";
            this.radMenuItemPDF.Click += new System.EventHandler(this.radMenuItemPDF_Click);
            // 
            // radMenuItemCSV
            // 
            this.radMenuItemCSV.AccessibleDescription = "Export to CSV";
            this.radMenuItemCSV.AccessibleName = "Export to CSV";
            this.radMenuItemCSV.Name = "radMenuItemCSV";
            this.radMenuItemCSV.Text = "Export to CSV";
            this.radMenuItemCSV.Click += new System.EventHandler(this.radMenuItemCSV_Click);
            // 
            // radBtnCrystalPrint
            // 
            this.radBtnCrystalPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radBtnCrystalPrint.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBtnCrystalPrint.Location = new System.Drawing.Point(838, 10);
            this.radBtnCrystalPrint.Name = "radBtnCrystalPrint";
            this.radBtnCrystalPrint.Size = new System.Drawing.Size(12, 38);
            this.radBtnCrystalPrint.TabIndex = 9;
            this.radBtnCrystalPrint.Text = "Crystal Print";
            this.radBtnCrystalPrint.Visible = false;
            this.radBtnCrystalPrint.Click += new System.EventHandler(this.radBtnCrystalPrint_Click);
            // 
            // radButtonPrint
            // 
            this.radButtonPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radButtonPrint.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonPrint.Location = new System.Drawing.Point(806, 9);
            this.radButtonPrint.Name = "radButtonPrint";
            this.radButtonPrint.Size = new System.Drawing.Size(10, 38);
            this.radButtonPrint.TabIndex = 4;
            this.radButtonPrint.Text = "Print";
            this.radButtonPrint.Visible = false;
            this.radButtonPrint.Click += new System.EventHandler(this.radButtonPrint_Click);
            // 
            // radButtonPrintPreview
            // 
            this.radButtonPrintPreview.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radButtonPrintPreview.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonPrintPreview.Location = new System.Drawing.Point(822, 9);
            this.radButtonPrintPreview.Name = "radButtonPrintPreview";
            this.radButtonPrintPreview.Size = new System.Drawing.Size(10, 38);
            this.radButtonPrintPreview.TabIndex = 5;
            this.radButtonPrintPreview.Text = "Print preview";
            this.radButtonPrintPreview.Visible = false;
            this.radButtonPrintPreview.Click += new System.EventHandler(this.radButtonPrintPreview_Click);
            // 
            // radButtonPrintSettings
            // 
            this.radButtonPrintSettings.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radButtonPrintSettings.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonPrintSettings.Location = new System.Drawing.Point(1236, 8);
            this.radButtonPrintSettings.Name = "radButtonPrintSettings";
            this.radButtonPrintSettings.Size = new System.Drawing.Size(114, 38);
            this.radButtonPrintSettings.TabIndex = 6;
            this.radButtonPrintSettings.Text = "Print";
            this.radButtonPrintSettings.Click += new System.EventHandler(this.radButtonPrintSettings_Click);
            // 
            // radTextBoxSheet
            // 
            this.radTextBoxSheet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radTextBoxSheet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTextBoxSheet.ForeColor = System.Drawing.Color.Black;
            this.radTextBoxSheet.Location = new System.Drawing.Point(496, 8);
            this.radTextBoxSheet.Name = "radTextBoxSheet";
            this.radTextBoxSheet.Size = new System.Drawing.Size(199, 19);
            this.radTextBoxSheet.TabIndex = 6;
            this.radTextBoxSheet.TabStop = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radLabel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.Black;
            this.radLabel1.Location = new System.Drawing.Point(410, 8);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(80, 17);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Sheet name:";
            // 
            // radRadioButton1
            // 
            this.radRadioButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radRadioButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radRadioButton1.Enabled = false;
            this.radRadioButton1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRadioButton1.ForeColor = System.Drawing.Color.Black;
            this.radRadioButton1.Location = new System.Drawing.Point(296, 8);
            this.radRadioButton1.Name = "radRadioButton1";
            this.radRadioButton1.Size = new System.Drawing.Size(83, 17);
            this.radRadioButton1.TabIndex = 3;
            this.radRadioButton1.Text = "Excel 2007";
            this.radRadioButton1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.radRadioButton1.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radRadioButton2
            // 
            this.radRadioButton2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radRadioButton2.Enabled = false;
            this.radRadioButton2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRadioButton2.ForeColor = System.Drawing.Color.Black;
            this.radRadioButton2.Location = new System.Drawing.Point(296, 27);
            this.radRadioButton2.Name = "radRadioButton2";
            this.radRadioButton2.Size = new System.Drawing.Size(98, 17);
            this.radRadioButton2.TabIndex = 4;
            this.radRadioButton2.Text = "prior versions";
            // 
            // radComboBoxSummaries
            // 
            this.radComboBoxSummaries.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radComboBoxSummaries.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.radComboBoxSummaries.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radComboBoxSummaries.ForeColor = System.Drawing.Color.Black;
            radListDataItem1.Text = "All Summaries";
            radListDataItem2.Text = "OnlyTop Summaries";
            radListDataItem3.Text = "Only Bottom Summaries";
            radListDataItem4.Text = "Do not export summaries";
            this.radComboBoxSummaries.Items.Add(radListDataItem1);
            this.radComboBoxSummaries.Items.Add(radListDataItem2);
            this.radComboBoxSummaries.Items.Add(radListDataItem3);
            this.radComboBoxSummaries.Items.Add(radListDataItem4);
            this.radComboBoxSummaries.Location = new System.Drawing.Point(408, 19);
            this.radComboBoxSummaries.Name = "radComboBoxSummaries";
            this.radComboBoxSummaries.NullText = "How to export summaries";
            // 
            // 
            // 
            this.radComboBoxSummaries.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.radComboBoxSummaries.Size = new System.Drawing.Size(12, 19);
            this.radComboBoxSummaries.TabIndex = 5;
            this.radComboBoxSummaries.Visible = false;
            // 
            // radCheckBoxExportVisual
            // 
            this.radCheckBoxExportVisual.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radCheckBoxExportVisual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radCheckBoxExportVisual.Enabled = false;
            this.radCheckBoxExportVisual.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCheckBoxExportVisual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.radCheckBoxExportVisual.Location = new System.Drawing.Point(147, 8);
            this.radCheckBoxExportVisual.Name = "radCheckBoxExportVisual";
            this.radCheckBoxExportVisual.Size = new System.Drawing.Size(143, 17);
            this.radCheckBoxExportVisual.TabIndex = 2;
            this.radCheckBoxExportVisual.Text = "Export visual settings";
            this.radCheckBoxExportVisual.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // tabPagePivot
            // 
            this.tabPagePivot.Controls.Add(this.radGroupBox1);
            this.tabPagePivot.Controls.Add(this.radPivotFieldList1);
            this.tabPagePivot.Controls.Add(this.radPivotGrid1);
            this.tabPagePivot.Location = new System.Drawing.Point(4, 30);
            this.tabPagePivot.Name = "tabPagePivot";
            this.tabPagePivot.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePivot.Size = new System.Drawing.Size(1337, 706);
            this.tabPagePivot.TabIndex = 1;
            this.tabPagePivot.Text = "   Pivot View    ";
            this.tabPagePivot.UseVisualStyleBackColor = true;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radGroupBox1.Controls.Add(this.radDropDownbtnPVExport);
            this.radGroupBox1.Controls.Add(this.radBtnClose1);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radButton3);
            this.radGroupBox1.Controls.Add(this.radBtnPivotPrintPreview);
            this.radGroupBox1.Controls.Add(this.radBtnPivotPrint);
            this.radGroupBox1.Controls.Add(this.radProgressBar2);
            this.radGroupBox1.FooterText = "";
            this.radGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(2, 645);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.radGroupBox1.Size = new System.Drawing.Size(1333, 58);
            this.radGroupBox1.TabIndex = 39;
            // 
            // radDropDownbtnPVExport
            // 
            this.radDropDownbtnPVExport.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuPVExcel,
            this.radMenuPVPDF,
            this.radMenuPVCSV});
            this.radDropDownbtnPVExport.Location = new System.Drawing.Point(579, 14);
            this.radDropDownbtnPVExport.Name = "radDropDownbtnPVExport";
            this.radDropDownbtnPVExport.Size = new System.Drawing.Size(114, 38);
            this.radDropDownbtnPVExport.TabIndex = 39;
            this.radDropDownbtnPVExport.Text = "Export";
            this.radDropDownbtnPVExport.Click += new System.EventHandler(this.radDropDownbtnPVExport_Click);
            // 
            // radMenuPVExcel
            // 
            this.radMenuPVExcel.AccessibleDescription = "Exprot to Excel";
            this.radMenuPVExcel.AccessibleName = "Exprot to Excel";
            this.radMenuPVExcel.Name = "radMenuPVExcel";
            this.radMenuPVExcel.Text = "Exprot to Excel";
            this.radMenuPVExcel.Click += new System.EventHandler(this.radMenuPVExcel_Click);
            // 
            // radMenuPVPDF
            // 
            this.radMenuPVPDF.AccessibleDescription = "Export to PDF";
            this.radMenuPVPDF.AccessibleName = "Export to PDF";
            this.radMenuPVPDF.Name = "radMenuPVPDF";
            this.radMenuPVPDF.Text = "Export to PDF";
            this.radMenuPVPDF.Click += new System.EventHandler(this.radMenuPVPDF_Click);
            // 
            // radMenuPVCSV
            // 
            this.radMenuPVCSV.AccessibleDescription = "Export to CSV";
            this.radMenuPVCSV.AccessibleName = "Export to CSV";
            this.radMenuPVCSV.Name = "radMenuPVCSV";
            this.radMenuPVCSV.Text = "Export to CSV";
            this.radMenuPVCSV.Click += new System.EventHandler(this.radMenuPVCSV_Click);
            // 
            // radBtnClose1
            // 
            this.radBtnClose1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radBtnClose1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBtnClose1.Location = new System.Drawing.Point(1211, 11);
            this.radBtnClose1.Name = "radBtnClose1";
            this.radBtnClose1.Size = new System.Drawing.Size(114, 38);
            this.radBtnClose1.TabIndex = 38;
            this.radBtnClose1.Text = "Close";
            this.radBtnClose1.Click += new System.EventHandler(this.radBtnClose1_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radLabel2.ForeColor = System.Drawing.Color.Black;
            this.radLabel2.Location = new System.Drawing.Point(276, 12);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(52, 18);
            this.radLabel2.TabIndex = 7;
            this.radLabel2.Text = "Progress:";
            this.radLabel2.Visible = false;
            // 
            // radButton3
            // 
            this.radButton3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radButton3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton3.Location = new System.Drawing.Point(749, 14);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(10, 38);
            this.radButton3.TabIndex = 4;
            this.radButton3.Text = "Print";
            this.radButton3.Visible = false;
            // 
            // radBtnPivotPrintPreview
            // 
            this.radBtnPivotPrintPreview.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radBtnPivotPrintPreview.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBtnPivotPrintPreview.Location = new System.Drawing.Point(869, 14);
            this.radBtnPivotPrintPreview.Name = "radBtnPivotPrintPreview";
            this.radBtnPivotPrintPreview.Size = new System.Drawing.Size(145, 38);
            this.radBtnPivotPrintPreview.TabIndex = 5;
            this.radBtnPivotPrintPreview.Text = "Print preview";
            this.radBtnPivotPrintPreview.Visible = false;
            this.radBtnPivotPrintPreview.Click += new System.EventHandler(this.radBtnPivotPrintPreview_Click);
            // 
            // radBtnPivotPrint
            // 
            this.radBtnPivotPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radBtnPivotPrint.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBtnPivotPrint.Location = new System.Drawing.Point(1091, 14);
            this.radBtnPivotPrint.Name = "radBtnPivotPrint";
            this.radBtnPivotPrint.Size = new System.Drawing.Size(114, 38);
            this.radBtnPivotPrint.TabIndex = 6;
            this.radBtnPivotPrint.Text = "Print";
            this.radBtnPivotPrint.Click += new System.EventHandler(this.radBtnPivotPrint_Click);
            // 
            // radProgressBar2
            // 
            this.radProgressBar2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radProgressBar2.ForeColor = System.Drawing.Color.Black;
            this.radProgressBar2.Location = new System.Drawing.Point(362, 14);
            this.radProgressBar2.Name = "radProgressBar2";
            this.radProgressBar2.SeparatorColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.radProgressBar2.SeparatorWidth = 4;
            this.radProgressBar2.Size = new System.Drawing.Size(199, 15);
            this.radProgressBar2.StepWidth = 13;
            this.radProgressBar2.TabIndex = 5;
            this.radProgressBar2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radProgressBar2.Visible = false;
            // 
            // gbRowTotal
            // 
            this.gbRowTotal.Controls.Add(this.chkRowTotal);
            this.gbRowTotal.Location = new System.Drawing.Point(374, 30);
            this.gbRowTotal.Name = "gbRowTotal";
            this.gbRowTotal.Size = new System.Drawing.Size(80, 52);
            this.gbRowTotal.TabIndex = 34;
            this.gbRowTotal.Text = "Row Total";
            this.gbRowTotal.Visible = false;
            // 
            // chkRowTotal
            // 
            this.chkRowTotal.CheckOnClick = true;
            this.chkRowTotal.FormattingEnabled = true;
            this.chkRowTotal.HorizontalScrollbar = true;
            this.chkRowTotal.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.chkRowTotal.Location = new System.Drawing.Point(12, 17);
            this.chkRowTotal.MultiColumn = true;
            this.chkRowTotal.Name = "chkRowTotal";
            this.chkRowTotal.Size = new System.Drawing.Size(125, 164);
            this.chkRowTotal.TabIndex = 13;
            this.chkRowTotal.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkRowTotal_ItemCheck);
            // 
            // gbColumnTotal
            // 
            this.gbColumnTotal.Controls.Add(this.chklstColumnTotal);
            this.gbColumnTotal.Location = new System.Drawing.Point(306, 109);
            this.gbColumnTotal.Name = "gbColumnTotal";
            this.gbColumnTotal.Size = new System.Drawing.Size(139, 38);
            this.gbColumnTotal.TabIndex = 33;
            this.gbColumnTotal.Text = "Column Total";
            this.gbColumnTotal.Visible = false;
            // 
            // chklstColumnTotal
            // 
            this.chklstColumnTotal.CheckOnClick = true;
            this.chklstColumnTotal.FormattingEnabled = true;
            this.chklstColumnTotal.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.chklstColumnTotal.Location = new System.Drawing.Point(52, 7);
            this.chklstColumnTotal.MultiColumn = true;
            this.chklstColumnTotal.Name = "chklstColumnTotal";
            this.chklstColumnTotal.Size = new System.Drawing.Size(62, 20);
            this.chklstColumnTotal.TabIndex = 13;
            this.chklstColumnTotal.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstColumnTotal_ItemCheck);
            // 
            // gbGroupBy
            // 
            this.gbGroupBy.Controls.Add(this.btnGroupByDown);
            this.gbGroupBy.Controls.Add(this.btnGroupByUp);
            this.gbGroupBy.Controls.Add(this.chkViewGroupDetails);
            this.gbGroupBy.Controls.Add(this.chkLstGroupBy);
            this.gbGroupBy.Location = new System.Drawing.Point(541, 63);
            this.gbGroupBy.Name = "gbGroupBy";
            this.gbGroupBy.Size = new System.Drawing.Size(125, 37);
            this.gbGroupBy.TabIndex = 31;
            this.gbGroupBy.Text = "Group By ";
            // 
            // btnGroupByDown
            // 
            this.btnGroupByDown.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupByDown.Location = new System.Drawing.Point(467, 54);
            this.btnGroupByDown.Name = "btnGroupByDown";
            this.btnGroupByDown.Size = new System.Drawing.Size(23, 35);
            this.btnGroupByDown.TabIndex = 14;
            this.btnGroupByDown.Text = "˅";
            this.btnGroupByDown.UseVisualStyleBackColor = true;
            this.btnGroupByDown.Click += new System.EventHandler(this.btnGroupByDown_Click);
            // 
            // btnGroupByUp
            // 
            this.btnGroupByUp.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupByUp.Location = new System.Drawing.Point(467, 17);
            this.btnGroupByUp.Name = "btnGroupByUp";
            this.btnGroupByUp.Size = new System.Drawing.Size(23, 35);
            this.btnGroupByUp.TabIndex = 14;
            this.btnGroupByUp.Text = "˄";
            this.btnGroupByUp.UseVisualStyleBackColor = true;
            this.btnGroupByUp.Click += new System.EventHandler(this.btnGroupByUp_Click);
            // 
            // chkViewGroupDetails
            // 
            this.chkViewGroupDetails.AutoSize = true;
            this.chkViewGroupDetails.Location = new System.Drawing.Point(82, 0);
            this.chkViewGroupDetails.Name = "chkViewGroupDetails";
            this.chkViewGroupDetails.Size = new System.Drawing.Size(135, 17);
            this.chkViewGroupDetails.TabIndex = 13;
            this.chkViewGroupDetails.Text = "View Group Details";
            this.chkViewGroupDetails.UseVisualStyleBackColor = true;
            this.chkViewGroupDetails.Visible = false;
            this.chkViewGroupDetails.CheckedChanged += new System.EventHandler(this.chkViewGroupDetails_CheckedChanged);
            // 
            // chkLstGroupBy
            // 
            this.chkLstGroupBy.CheckOnClick = true;
            this.chkLstGroupBy.FormattingEnabled = true;
            this.chkLstGroupBy.Location = new System.Drawing.Point(24, 11);
            this.chkLstGroupBy.MultiColumn = true;
            this.chkLstGroupBy.Name = "chkLstGroupBy";
            this.chkLstGroupBy.Size = new System.Drawing.Size(94, 20);
            this.chkLstGroupBy.TabIndex = 12;
            this.chkLstGroupBy.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstGroupBy_ItemCheck);
            this.chkLstGroupBy.Leave += new System.EventHandler(this.chkLstGroupBy_Leave);
            // 
            // gbOrderBy
            // 
            this.gbOrderBy.Controls.Add(this.chkLstOrderBy);
            this.gbOrderBy.Location = new System.Drawing.Point(476, 34);
            this.gbOrderBy.Name = "gbOrderBy";
            this.gbOrderBy.Size = new System.Drawing.Size(190, 23);
            this.gbOrderBy.TabIndex = 32;
            this.gbOrderBy.Text = "Order By";
            // 
            // chkLstOrderBy
            // 
            this.chkLstOrderBy.CheckOnClick = true;
            this.chkLstOrderBy.FormattingEnabled = true;
            this.chkLstOrderBy.Location = new System.Drawing.Point(15, 21);
            this.chkLstOrderBy.MultiColumn = true;
            this.chkLstOrderBy.Name = "chkLstOrderBy";
            this.chkLstOrderBy.Size = new System.Drawing.Size(448, 84);
            this.chkLstOrderBy.TabIndex = 13;
            this.chkLstOrderBy.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstOrderBy_ItemCheck);
            // 
            // radPrintDocument1
            // 
            this.radPrintDocument1.AssociatedObject = this.dgvFilter;
            this.radPrintDocument1.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPrintDocument1.FooterHeight = 20;
            this.radPrintDocument1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPrintDocument1.HeaderHeight = 20;
            this.radPrintDocument1.Landscape = true;
            radPrintWatermark1.Pages = null;
            radPrintWatermark1.Text = null;
            this.radPrintDocument1.Watermark = radPrintWatermark1;
            this.radPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.radPrintDocument1_PrintPage);
            // 
            // radPrintDocument2
            // 
            this.radPrintDocument2.AssociatedObject = this.radPivotGrid1;
            this.radPrintDocument2.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPrintDocument2.FooterHeight = 20;
            this.radPrintDocument2.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPrintDocument2.HeaderHeight = 20;
            this.radPrintDocument2.Landscape = true;
            radPrintWatermark2.Pages = null;
            radPrintWatermark2.Text = null;
            this.radPrintDocument2.Watermark = radPrintWatermark2;
            // 
            // FrmReprotGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 742);
            this.Controls.Add(this.tabReportViewer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbFieldSelection);
            this.Controls.Add(this.gbGroupBy);
            this.Controls.Add(this.gbColumnTotal);
            this.Controls.Add(this.gbRowTotal);
            this.Controls.Add(this.gbOrderBy);
            this.Name = "FrmReprotGenerator";
            this.Text = "Report Generator";
            this.Load += new System.EventHandler(this.FrmReprotGenerator_Load);
            this.Controls.SetChildIndex(this.gbOrderBy, 0);
            this.Controls.SetChildIndex(this.gbRowTotal, 0);
            this.Controls.SetChildIndex(this.gbColumnTotal, 0);
            this.Controls.SetChildIndex(this.gbGroupBy, 0);
            this.Controls.SetChildIndex(this.gbFieldSelection, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.tabReportViewer, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gbFieldSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbValueFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbValueTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbValueType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValueRange)).EndInit();
            this.tabReportViewer.ResumeLayout(false);
            this.tabPageReport.ResumeLayout(false);
            this.tabPageReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupSettings)).EndInit();
            this.radGroupSettings.ResumeLayout(false);
            this.radGroupSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnBack1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLblProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownbtnViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCrystalPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonPrintPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonPrintSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radComboBoxSummaries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBoxExportVisual)).EndInit();
            this.tabPagePivot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownbtnPVExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnClose1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnPivotPrintPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnPivotPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar2)).EndInit();
            this.gbRowTotal.ResumeLayout(false);
            this.gbColumnTotal.ResumeLayout(false);
            this.gbGroupBy.ResumeLayout(false);
            this.gbGroupBy.PerformLayout();
            this.gbOrderBy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.Button btnValueAdd;
        //private System.Windows.Forms.ComboBox cmbValueType;
        private System.Windows.Forms.Panel gbFieldSelection;
        private System.Windows.Forms.CheckedListBox chkLstFieldSelectionDes;
        private System.Windows.Forms.CheckedListBox chkLstFieldSelectionStr;
        private System.Windows.Forms.Panel groupBox1;
        private global::ERP.UI.Windows.CustomControls.TextBoxNumeric txtValueTo;
        private System.Windows.Forms.DataGridView dgvValueRange;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Button btnValueAdd;
        private System.Windows.Forms.Label lblValueType;
        private System.Windows.Forms.Panel gbRowTotal;
        private System.Windows.Forms.CheckedListBox chkRowTotal;
        private System.Windows.Forms.Panel gbColumnTotal;
        private System.Windows.Forms.CheckedListBox chklstColumnTotal;
        private System.Windows.Forms.Panel gbGroupBy;
        private System.Windows.Forms.CheckedListBox chkLstGroupBy;
        private System.Windows.Forms.Panel gbOrderBy;
        private System.Windows.Forms.CheckedListBox chkLstOrderBy;
        private System.Windows.Forms.CheckBox chkViewGroupDetails;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnGroupByDown;
        private System.Windows.Forms.Button btnGroupByUp;
        private GUI.CustomControls.TextBoxNumericMinus txtValueFrom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel groupBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueTypeId;
        private Telerik.WinControls.UI.RadGridView dgvFilter;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.UI.RadGroupBox radGroupSettings;
        private Telerik.WinControls.UI.RadTextBox radTextBoxSheet;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton1;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton2;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar1;
        private Telerik.WinControls.UI.RadDropDownList radComboBoxSummaries;
        private Telerik.WinControls.UI.RadLabel radLblProgress;
        private Telerik.WinControls.UI.RadCheckBox radCheckBoxExportVisual;
        private Telerik.WinControls.UI.RadButton radButtonPrint;
        private Telerik.WinControls.UI.RadButton radButtonPrintPreview;
        private Telerik.WinControls.UI.RadButton radButtonPrintSettings;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Telerik.WinControls.UI.RadPrintDocument radPrintDocument1;
        private Telerik.WinControls.UI.RadButton radBtnCrystalPrint;
        private Telerik.WinControls.UI.RadPivotGrid radPivotGrid1;
        private Telerik.WinControls.UI.RadDropDownList cmbValueType;
        private Telerik.WinControls.UI.RadPivotFieldList radPivotFieldList1;
        private System.Windows.Forms.TabControl tabReportViewer;
        private System.Windows.Forms.TabPage tabPageReport;
        private System.Windows.Forms.TabPage tabPagePivot;
        private Telerik.WinControls.UI.RadDropDownButton radDropDownbtnViewer;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemExcel;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemPDF;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemCSV;
        private Telerik.WinControls.UI.RadButton radBtnBack1;
        private Telerik.WinControls.UI.RadButton radBtnClose1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton radBtnPivotPrintPreview;
        private Telerik.WinControls.UI.RadButton radBtnPivotPrint;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar2;
        private Telerik.WinControls.UI.RadDropDownList cmbValueTo;
        private Telerik.WinControls.UI.RadDropDownList cmbValueFrom;
        private Telerik.WinControls.UI.RadDropDownButton radDropDownbtnPVExport;
        private Telerik.WinControls.UI.RadMenuItem radMenuPVExcel;
        private Telerik.WinControls.UI.RadMenuItem radMenuPVPDF;
        private Telerik.WinControls.UI.RadMenuItem radMenuPVCSV;
        private Telerik.WinControls.UI.RadPrintDocument radPrintDocument2;
        private Telerik.WinControls.UI.RadButton btnSaveLayout;
        private Telerik.WinControls.UI.RadButton btnLoadLayout;
        private Telerik.WinControls.UI.RadDropDownList cmbLayout;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar;
        private Telerik.WinControls.UI.RadLabel lblProgress;
        //private UI.Windows.CustomControls.TextBoxNumeric txtValueTo;
        //private UI.Windows.CustomControls.TextBoxNumeric txtValueFrom;
        //private System.Windows.Forms.DateTimePicker dtpDateTo;
        //private System.Windows.Forms.DateTimePicker dtpDateFrom;
        //private System.Windows.Forms.ComboBox cmbValueTo;
        //private System.Windows.Forms.ComboBox cmbValueFrom;

    }
}