namespace ERP.Report.GUI
{
    partial class frmAgeAnalysis
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
            this.grpLocations = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAllLocations = new System.Windows.Forms.CheckBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.rbnDepartment = new System.Windows.Forms.RadioButton();
            this.rbnCategory = new System.Windows.Forms.RadioButton();
            this.rbnSubCategory = new System.Windows.Forms.RadioButton();
            this.rbnSubCategory2 = new System.Windows.Forms.RadioButton();
            this.rbnSupplier = new System.Windows.Forms.RadioButton();
            this.grbDepartment = new System.Windows.Forms.Panel();
            this.chkAllDepartments = new System.Windows.Forms.CheckBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.chkLstDepartment = new System.Windows.Forms.CheckedListBox();
            this.grbCategory = new System.Windows.Forms.Panel();
            this.chkAllCategories = new System.Windows.Forms.CheckBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.chkLstCategory = new System.Windows.Forms.CheckedListBox();
            this.grbSubCategory = new System.Windows.Forms.Panel();
            this.chkAllSubCategories = new System.Windows.Forms.CheckBox();
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.chkLstSubCategory = new System.Windows.Forms.CheckedListBox();
            this.grbSubCategory2 = new System.Windows.Forms.Panel();
            this.chkAllSubCategories2 = new System.Windows.Forms.CheckBox();
            this.txtSubCategory2 = new System.Windows.Forms.TextBox();
            this.chkLstSubCategory2 = new System.Windows.Forms.CheckedListBox();
            this.grbProduct = new System.Windows.Forms.Panel();
            this.chkAllProducts = new System.Windows.Forms.CheckBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.chkBxSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtProducts = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.grbSupplier = new System.Windows.Forms.Panel();
            this.chkAllSuppliers = new System.Windows.Forms.CheckBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.chkLstSupplier = new System.Windows.Forms.CheckedListBox();
            this.rbnProduct = new System.Windows.Forms.RadioButton();
            this.grbSlab = new System.Windows.Forms.Panel();
            this.txtDays4To = new global::ERP.UI.Windows.CustomControls.TextBoxNumeric();
            this.txtDays2To = new global::ERP.UI.Windows.CustomControls.TextBoxNumeric();
            this.txtDays3To = new global::ERP.UI.Windows.CustomControls.TextBoxNumeric();
            this.txtDays1To = new global::ERP.UI.Windows.CustomControls.TextBoxNumeric();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDays4From = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDays2From = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDays3From = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDaysOver = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDays1From = new System.Windows.Forms.TextBox();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grpLocations.SuspendLayout();
            this.grbDepartment.SuspendLayout();
            this.grbCategory.SuspendLayout();
            this.grbSubCategory.SuspendLayout();
            this.grbSubCategory2.SuspendLayout();
            this.grbProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbSupplier.SuspendLayout();
            this.grbSlab.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(948, 527);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Location = new System.Drawing.Point(11, 527);
            // 
            // btnClear
            // 
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // grpLocations
            // 
            this.grpLocations.Controls.Add(this.label1);
            this.grpLocations.Controls.Add(this.label4);
            this.grpLocations.Controls.Add(this.chkAllLocations);
            this.grpLocations.Controls.Add(this.cmbLocation);
            this.grpLocations.Controls.Add(this.dtpToDate);
            this.grpLocations.Controls.Add(this.dtpFromDate);
            this.grpLocations.Controls.Add(this.lblDateRange);
            this.grpLocations.Location = new System.Drawing.Point(3, 1);
            this.grpLocations.Name = "grpLocations";
            this.grpLocations.Size = new System.Drawing.Size(547, 96);
            this.grpLocations.TabIndex = 128;
            this.grpLocations.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 135;
            this.label1.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "Location";
            // 
            // chkAllLocations
            // 
            this.chkAllLocations.AutoSize = true;
            this.chkAllLocations.Location = new System.Drawing.Point(286, 44);
            this.chkAllLocations.Name = "chkAllLocations";
            this.chkAllLocations.Size = new System.Drawing.Size(97, 17);
            this.chkAllLocations.TabIndex = 133;
            this.chkAllLocations.Text = "All Locations";
            this.chkAllLocations.UseVisualStyleBackColor = true;
            this.chkAllLocations.CheckedChanged += new System.EventHandler(this.chkAllLocations_CheckedChanged);
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(94, 41);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(186, 21);
            this.cmbLocation.TabIndex = 130;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(286, 11);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(154, 21);
            this.dtpToDate.TabIndex = 129;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(94, 11);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(154, 21);
            this.dtpFromDate.TabIndex = 128;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(6, 17);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(74, 13);
            this.lblDateRange.TabIndex = 127;
            this.lblDateRange.Text = "Date Range";
            // 
            // rbnDepartment
            // 
            this.rbnDepartment.AutoSize = true;
            this.rbnDepartment.Location = new System.Drawing.Point(8, 14);
            this.rbnDepartment.Name = "rbnDepartment";
            this.rbnDepartment.Size = new System.Drawing.Size(132, 17);
            this.rbnDepartment.TabIndex = 140;
            this.rbnDepartment.Text = "Select Department";
            this.rbnDepartment.UseVisualStyleBackColor = true;
            this.rbnDepartment.CheckedChanged += new System.EventHandler(this.rbnDepartment_CheckedChanged);
            // 
            // rbnCategory
            // 
            this.rbnCategory.AutoSize = true;
            this.rbnCategory.Location = new System.Drawing.Point(202, 14);
            this.rbnCategory.Name = "rbnCategory";
            this.rbnCategory.Size = new System.Drawing.Size(109, 17);
            this.rbnCategory.TabIndex = 141;
            this.rbnCategory.Tag = "";
            this.rbnCategory.Text = "Category Wise";
            this.rbnCategory.UseVisualStyleBackColor = true;
            this.rbnCategory.CheckedChanged += new System.EventHandler(this.rbnCategory_CheckedChanged);
            // 
            // rbnSubCategory
            // 
            this.rbnSubCategory.AutoSize = true;
            this.rbnSubCategory.Location = new System.Drawing.Point(371, 14);
            this.rbnSubCategory.Name = "rbnSubCategory";
            this.rbnSubCategory.Size = new System.Drawing.Size(135, 17);
            this.rbnSubCategory.TabIndex = 142;
            this.rbnSubCategory.Text = "Sub Category Wise";
            this.rbnSubCategory.UseVisualStyleBackColor = true;
            this.rbnSubCategory.CheckedChanged += new System.EventHandler(this.rbnSubCategory_CheckedChanged);
            // 
            // rbnSubCategory2
            // 
            this.rbnSubCategory2.AutoSize = true;
            this.rbnSubCategory2.Location = new System.Drawing.Point(540, 14);
            this.rbnSubCategory2.Name = "rbnSubCategory2";
            this.rbnSubCategory2.Size = new System.Drawing.Size(142, 17);
            this.rbnSubCategory2.TabIndex = 143;
            this.rbnSubCategory2.Text = "Sub Category2 Wise";
            this.rbnSubCategory2.UseVisualStyleBackColor = true;
            this.rbnSubCategory2.CheckedChanged += new System.EventHandler(this.rbnSubCategory2_CheckedChanged);
            // 
            // rbnSupplier
            // 
            this.rbnSupplier.AutoSize = true;
            this.rbnSupplier.Location = new System.Drawing.Point(733, 14);
            this.rbnSupplier.Name = "rbnSupplier";
            this.rbnSupplier.Size = new System.Drawing.Size(103, 17);
            this.rbnSupplier.TabIndex = 144;
            this.rbnSupplier.Text = "Supplier Wise";
            this.rbnSupplier.UseVisualStyleBackColor = true;
            this.rbnSupplier.CheckedChanged += new System.EventHandler(this.rbnSupplier_CheckedChanged);
            // 
            // grbDepartment
            // 
            this.grbDepartment.Controls.Add(this.chkAllDepartments);
            this.grbDepartment.Controls.Add(this.txtDepartment);
            this.grbDepartment.Controls.Add(this.chkLstDepartment);
            this.grbDepartment.Enabled = false;
            this.grbDepartment.Location = new System.Drawing.Point(4, 37);
            this.grbDepartment.Name = "grbDepartment";
            this.grbDepartment.Size = new System.Drawing.Size(175, 385);
            this.grbDepartment.TabIndex = 147;
            this.grbDepartment.TabStop = false;
            this.grbDepartment.Text = "Department";
            // 
            // chkAllDepartments
            // 
            this.chkAllDepartments.AutoSize = true;
            this.chkAllDepartments.Location = new System.Drawing.Point(6, 18);
            this.chkAllDepartments.Name = "chkAllDepartments";
            this.chkAllDepartments.Size = new System.Drawing.Size(118, 17);
            this.chkAllDepartments.TabIndex = 149;
            this.chkAllDepartments.Text = "All Departments";
            this.chkAllDepartments.UseVisualStyleBackColor = true;
            this.chkAllDepartments.CheckedChanged += new System.EventHandler(this.chkAllDepartments_CheckedChanged);
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(4, 359);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(166, 21);
            this.txtDepartment.TabIndex = 148;
            this.txtDepartment.TextChanged += new System.EventHandler(this.txtDepartment_TextChanged);
            // 
            // chkLstDepartment
            // 
            this.chkLstDepartment.CheckOnClick = true;
            this.chkLstDepartment.FormattingEnabled = true;
            this.chkLstDepartment.Location = new System.Drawing.Point(4, 43);
            this.chkLstDepartment.Name = "chkLstDepartment";
            this.chkLstDepartment.Size = new System.Drawing.Size(167, 308);
            this.chkLstDepartment.TabIndex = 147;
            this.chkLstDepartment.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstDepartment_ItemCheck);
            // 
            // grbCategory
            // 
            this.grbCategory.Controls.Add(this.chkAllCategories);
            this.grbCategory.Controls.Add(this.txtCategory);
            this.grbCategory.Controls.Add(this.chkLstCategory);
            this.grbCategory.Enabled = false;
            this.grbCategory.Location = new System.Drawing.Point(179, 37);
            this.grbCategory.Name = "grbCategory";
            this.grbCategory.Size = new System.Drawing.Size(175, 385);
            this.grbCategory.TabIndex = 148;
            this.grbCategory.TabStop = false;
            this.grbCategory.Text = "Category";
            // 
            // chkAllCategories
            // 
            this.chkAllCategories.AutoSize = true;
            this.chkAllCategories.Location = new System.Drawing.Point(6, 18);
            this.chkAllCategories.Name = "chkAllCategories";
            this.chkAllCategories.Size = new System.Drawing.Size(106, 17);
            this.chkAllCategories.TabIndex = 149;
            this.chkAllCategories.Text = "All Categories";
            this.chkAllCategories.UseVisualStyleBackColor = true;
            this.chkAllCategories.CheckedChanged += new System.EventHandler(this.chkAllCategories_CheckedChanged);
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(6, 359);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(164, 21);
            this.txtCategory.TabIndex = 148;
            this.txtCategory.TextChanged += new System.EventHandler(this.txtCategory_TextChanged);
            // 
            // chkLstCategory
            // 
            this.chkLstCategory.CheckOnClick = true;
            this.chkLstCategory.FormattingEnabled = true;
            this.chkLstCategory.Location = new System.Drawing.Point(6, 43);
            this.chkLstCategory.Name = "chkLstCategory";
            this.chkLstCategory.Size = new System.Drawing.Size(165, 308);
            this.chkLstCategory.TabIndex = 147;
            this.chkLstCategory.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstCategory_ItemCheck);
            // 
            // grbSubCategory
            // 
            this.grbSubCategory.Controls.Add(this.chkAllSubCategories);
            this.grbSubCategory.Controls.Add(this.txtSubCategory);
            this.grbSubCategory.Controls.Add(this.chkLstSubCategory);
            this.grbSubCategory.Enabled = false;
            this.grbSubCategory.Location = new System.Drawing.Point(354, 37);
            this.grbSubCategory.Name = "grbSubCategory";
            this.grbSubCategory.Size = new System.Drawing.Size(175, 385);
            this.grbSubCategory.TabIndex = 149;
            this.grbSubCategory.TabStop = false;
            this.grbSubCategory.Text = "Sub Category";
            // 
            // chkAllSubCategories
            // 
            this.chkAllSubCategories.AutoSize = true;
            this.chkAllSubCategories.Location = new System.Drawing.Point(6, 18);
            this.chkAllSubCategories.Name = "chkAllSubCategories";
            this.chkAllSubCategories.Size = new System.Drawing.Size(132, 17);
            this.chkAllSubCategories.TabIndex = 149;
            this.chkAllSubCategories.Text = "All Sub Categories";
            this.chkAllSubCategories.UseVisualStyleBackColor = true;
            this.chkAllSubCategories.CheckedChanged += new System.EventHandler(this.chkAllSubCategories_CheckedChanged);
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.Location = new System.Drawing.Point(4, 359);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.Size = new System.Drawing.Size(164, 21);
            this.txtSubCategory.TabIndex = 148;
            this.txtSubCategory.TextChanged += new System.EventHandler(this.txtSubCategory_TextChanged);
            // 
            // chkLstSubCategory
            // 
            this.chkLstSubCategory.CheckOnClick = true;
            this.chkLstSubCategory.FormattingEnabled = true;
            this.chkLstSubCategory.Location = new System.Drawing.Point(4, 43);
            this.chkLstSubCategory.Name = "chkLstSubCategory";
            this.chkLstSubCategory.Size = new System.Drawing.Size(165, 308);
            this.chkLstSubCategory.TabIndex = 147;
            this.chkLstSubCategory.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstSubCategory_ItemCheck);
            // 
            // grbSubCategory2
            // 
            this.grbSubCategory2.Controls.Add(this.chkAllSubCategories2);
            this.grbSubCategory2.Controls.Add(this.txtSubCategory2);
            this.grbSubCategory2.Controls.Add(this.chkLstSubCategory2);
            this.grbSubCategory2.Enabled = false;
            this.grbSubCategory2.Location = new System.Drawing.Point(528, 37);
            this.grbSubCategory2.Name = "grbSubCategory2";
            this.grbSubCategory2.Size = new System.Drawing.Size(175, 385);
            this.grbSubCategory2.TabIndex = 150;
            this.grbSubCategory2.TabStop = false;
            this.grbSubCategory2.Text = "Sub Category2";
            // 
            // chkAllSubCategories2
            // 
            this.chkAllSubCategories2.AutoSize = true;
            this.chkAllSubCategories2.Location = new System.Drawing.Point(6, 18);
            this.chkAllSubCategories2.Name = "chkAllSubCategories2";
            this.chkAllSubCategories2.Size = new System.Drawing.Size(139, 17);
            this.chkAllSubCategories2.TabIndex = 149;
            this.chkAllSubCategories2.Text = "All Sub Categories2";
            this.chkAllSubCategories2.UseVisualStyleBackColor = true;
            this.chkAllSubCategories2.CheckedChanged += new System.EventHandler(this.chkAllSubCategories2_CheckedChanged);
            // 
            // txtSubCategory2
            // 
            this.txtSubCategory2.Location = new System.Drawing.Point(2, 359);
            this.txtSubCategory2.Name = "txtSubCategory2";
            this.txtSubCategory2.Size = new System.Drawing.Size(164, 21);
            this.txtSubCategory2.TabIndex = 148;
            this.txtSubCategory2.TextChanged += new System.EventHandler(this.txtSubCategory2_TextChanged);
            // 
            // chkLstSubCategory2
            // 
            this.chkLstSubCategory2.CheckOnClick = true;
            this.chkLstSubCategory2.FormattingEnabled = true;
            this.chkLstSubCategory2.Location = new System.Drawing.Point(2, 43);
            this.chkLstSubCategory2.Name = "chkLstSubCategory2";
            this.chkLstSubCategory2.Size = new System.Drawing.Size(165, 308);
            this.chkLstSubCategory2.TabIndex = 147;
            this.chkLstSubCategory2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstSubCategory2_ItemCheck);
            // 
            // grbProduct
            // 
            this.grbProduct.Controls.Add(this.chkAllProducts);
            this.grbProduct.Controls.Add(this.dgvProducts);
            this.grbProduct.Controls.Add(this.txtProducts);
            this.grbProduct.Enabled = false;
            this.grbProduct.Location = new System.Drawing.Point(877, 37);
            this.grbProduct.Name = "grbProduct";
            this.grbProduct.Size = new System.Drawing.Size(293, 385);
            this.grbProduct.TabIndex = 151;
            this.grbProduct.TabStop = false;
            this.grbProduct.Text = "Product";
            // 
            // chkAllProducts
            // 
            this.chkAllProducts.AutoSize = true;
            this.chkAllProducts.Location = new System.Drawing.Point(7, 20);
            this.chkAllProducts.Name = "chkAllProducts";
            this.chkAllProducts.Size = new System.Drawing.Size(93, 17);
            this.chkAllProducts.TabIndex = 151;
            this.chkAllProducts.Text = "All Products";
            this.chkAllProducts.UseVisualStyleBackColor = true;
            this.chkAllProducts.CheckedChanged += new System.EventHandler(this.chkAllProducts_CheckedChanged);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkBxSelect});
            this.dgvProducts.GridColor = System.Drawing.SystemColors.Window;
            this.dgvProducts.Location = new System.Drawing.Point(6, 43);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 4;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(280, 308);
            this.dgvProducts.TabIndex = 150;
            // 
            // chkBxSelect
            // 
            this.chkBxSelect.HeaderText = "";
            this.chkBxSelect.Name = "chkBxSelect";
            this.chkBxSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkBxSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chkBxSelect.Width = 25;
            // 
            // txtProducts
            // 
            this.txtProducts.Location = new System.Drawing.Point(4, 359);
            this.txtProducts.Name = "txtProducts";
            this.txtProducts.Size = new System.Drawing.Size(283, 21);
            this.txtProducts.TabIndex = 148;
            this.txtProducts.TextChanged += new System.EventHandler(this.txtProducts_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grbSupplier);
            this.groupBox1.Controls.Add(this.grbProduct);
            this.groupBox1.Controls.Add(this.grbSubCategory2);
            this.groupBox1.Controls.Add(this.grbSubCategory);
            this.groupBox1.Controls.Add(this.grbCategory);
            this.groupBox1.Controls.Add(this.grbDepartment);
            this.groupBox1.Controls.Add(this.rbnProduct);
            this.groupBox1.Controls.Add(this.rbnSupplier);
            this.groupBox1.Controls.Add(this.rbnSubCategory2);
            this.groupBox1.Controls.Add(this.rbnSubCategory);
            this.groupBox1.Controls.Add(this.rbnCategory);
            this.groupBox1.Controls.Add(this.rbnDepartment);
            this.groupBox1.Location = new System.Drawing.Point(6, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1176, 428);
            this.groupBox1.TabIndex = 129;
            this.groupBox1.TabStop = false;
            // 
            // grbSupplier
            // 
            this.grbSupplier.Controls.Add(this.chkAllSuppliers);
            this.grbSupplier.Controls.Add(this.txtSupplier);
            this.grbSupplier.Controls.Add(this.chkLstSupplier);
            this.grbSupplier.Enabled = false;
            this.grbSupplier.Location = new System.Drawing.Point(703, 37);
            this.grbSupplier.Name = "grbSupplier";
            this.grbSupplier.Size = new System.Drawing.Size(175, 385);
            this.grbSupplier.TabIndex = 152;
            this.grbSupplier.TabStop = false;
            this.grbSupplier.Text = "Supplier";
            // 
            // chkAllSuppliers
            // 
            this.chkAllSuppliers.AutoSize = true;
            this.chkAllSuppliers.Location = new System.Drawing.Point(6, 18);
            this.chkAllSuppliers.Name = "chkAllSuppliers";
            this.chkAllSuppliers.Size = new System.Drawing.Size(97, 17);
            this.chkAllSuppliers.TabIndex = 149;
            this.chkAllSuppliers.Text = "All Suppliers";
            this.chkAllSuppliers.UseVisualStyleBackColor = true;
            this.chkAllSuppliers.CheckedChanged += new System.EventHandler(this.chkAllSuppliers_CheckedChanged);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(4, 359);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(164, 21);
            this.txtSupplier.TabIndex = 148;
            this.txtSupplier.TextChanged += new System.EventHandler(this.txtSupplier_TextChanged);
            // 
            // chkLstSupplier
            // 
            this.chkLstSupplier.CheckOnClick = true;
            this.chkLstSupplier.FormattingEnabled = true;
            this.chkLstSupplier.Location = new System.Drawing.Point(4, 43);
            this.chkLstSupplier.Name = "chkLstSupplier";
            this.chkLstSupplier.Size = new System.Drawing.Size(165, 308);
            this.chkLstSupplier.TabIndex = 147;
            this.chkLstSupplier.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstSupplier_ItemCheck);
            // 
            // rbnProduct
            // 
            this.rbnProduct.AutoSize = true;
            this.rbnProduct.Location = new System.Drawing.Point(895, 14);
            this.rbnProduct.Name = "rbnProduct";
            this.rbnProduct.Size = new System.Drawing.Size(99, 17);
            this.rbnProduct.TabIndex = 145;
            this.rbnProduct.Text = "Product Wise";
            this.rbnProduct.UseVisualStyleBackColor = true;
            this.rbnProduct.CheckedChanged += new System.EventHandler(this.rbnProduct_CheckedChanged);
            // 
            // grbSlab
            // 
            this.grbSlab.Controls.Add(this.txtDays4To);
            this.grbSlab.Controls.Add(this.txtDays2To);
            this.grbSlab.Controls.Add(this.txtDays3To);
            this.grbSlab.Controls.Add(this.txtDays1To);
            this.grbSlab.Controls.Add(this.label8);
            this.grbSlab.Controls.Add(this.label9);
            this.grbSlab.Controls.Add(this.txtDays4From);
            this.grbSlab.Controls.Add(this.label6);
            this.grbSlab.Controls.Add(this.label7);
            this.grbSlab.Controls.Add(this.txtDays2From);
            this.grbSlab.Controls.Add(this.label3);
            this.grbSlab.Controls.Add(this.label5);
            this.grbSlab.Controls.Add(this.txtDays3From);
            this.grbSlab.Controls.Add(this.label2);
            this.grbSlab.Controls.Add(this.label19);
            this.grbSlab.Controls.Add(this.txtDaysOver);
            this.grbSlab.Controls.Add(this.label21);
            this.grbSlab.Controls.Add(this.txtDays1From);
            this.grbSlab.Location = new System.Drawing.Point(556, 1);
            this.grbSlab.Name = "grbSlab";
            this.grbSlab.Size = new System.Drawing.Size(620, 96);
            this.grbSlab.TabIndex = 142;
            this.grbSlab.TabStop = false;
            this.grbSlab.Text = "Slab";
            // 
            // txtDays4To
            // 
            this.txtDays4To.Location = new System.Drawing.Point(356, 41);
            this.txtDays4To.Name = "txtDays4To";
            this.txtDays4To.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDays4To.Size = new System.Drawing.Size(53, 21);
            this.txtDays4To.TabIndex = 175;
            this.txtDays4To.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDays4To_KeyDown);
            this.txtDays4To.Leave += new System.EventHandler(this.txtDays4To_Leave);
            // 
            // txtDays2To
            // 
            this.txtDays2To.Location = new System.Drawing.Point(356, 13);
            this.txtDays2To.Name = "txtDays2To";
            this.txtDays2To.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDays2To.Size = new System.Drawing.Size(53, 21);
            this.txtDays2To.TabIndex = 174;
            this.txtDays2To.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDays2To_KeyDown);
            this.txtDays2To.Leave += new System.EventHandler(this.txtDays2To_Leave);
            // 
            // txtDays3To
            // 
            this.txtDays3To.Location = new System.Drawing.Point(145, 41);
            this.txtDays3To.Name = "txtDays3To";
            this.txtDays3To.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDays3To.Size = new System.Drawing.Size(53, 21);
            this.txtDays3To.TabIndex = 173;
            this.txtDays3To.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDays3To_KeyDown);
            this.txtDays3To.Leave += new System.EventHandler(this.txtDays3To_Leave);
            // 
            // txtDays1To
            // 
            this.txtDays1To.Location = new System.Drawing.Point(144, 13);
            this.txtDays1To.Name = "txtDays1To";
            this.txtDays1To.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDays1To.Size = new System.Drawing.Size(53, 21);
            this.txtDays1To.TabIndex = 172;
            this.txtDays1To.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDays1To_KeyDown);
            this.txtDays1To.Leave += new System.EventHandler(this.txtDays1To_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 171;
            this.label8.Text = "To";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(217, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 170;
            this.label9.Text = "4. Days";
            // 
            // txtDays4From
            // 
            this.txtDays4From.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDays4From.Enabled = false;
            this.txtDays4From.ForeColor = System.Drawing.Color.Silver;
            this.txtDays4From.Location = new System.Drawing.Point(271, 41);
            this.txtDays4From.Name = "txtDays4From";
            this.txtDays4From.Size = new System.Drawing.Size(52, 21);
            this.txtDays4From.TabIndex = 168;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 167;
            this.label6.Text = "To";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 166;
            this.label7.Text = "2. Days";
            // 
            // txtDays2From
            // 
            this.txtDays2From.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDays2From.Enabled = false;
            this.txtDays2From.ForeColor = System.Drawing.Color.Silver;
            this.txtDays2From.Location = new System.Drawing.Point(271, 13);
            this.txtDays2From.Name = "txtDays2From";
            this.txtDays2From.Size = new System.Drawing.Size(52, 21);
            this.txtDays2From.TabIndex = 164;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 163;
            this.label3.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 162;
            this.label5.Text = "3. Days";
            // 
            // txtDays3From
            // 
            this.txtDays3From.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDays3From.Enabled = false;
            this.txtDays3From.ForeColor = System.Drawing.Color.Silver;
            this.txtDays3From.Location = new System.Drawing.Point(64, 41);
            this.txtDays3From.Name = "txtDays3From";
            this.txtDays3From.Size = new System.Drawing.Size(52, 21);
            this.txtDays3From.TabIndex = 160;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 159;
            this.label2.Text = "To";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 69);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 158;
            this.label19.Text = "Over";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // txtDaysOver
            // 
            this.txtDaysOver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDaysOver.Enabled = false;
            this.txtDaysOver.ForeColor = System.Drawing.Color.Silver;
            this.txtDaysOver.Location = new System.Drawing.Point(64, 68);
            this.txtDaysOver.Name = "txtDaysOver";
            this.txtDaysOver.Size = new System.Drawing.Size(52, 21);
            this.txtDaysOver.TabIndex = 157;
            this.txtDaysOver.TextChanged += new System.EventHandler(this.textBox22_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(51, 13);
            this.label21.TabIndex = 149;
            this.label21.Text = "1. Days";
            // 
            // txtDays1From
            // 
            this.txtDays1From.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDays1From.Enabled = false;
            this.txtDays1From.ForeColor = System.Drawing.Color.Silver;
            this.txtDays1From.Location = new System.Drawing.Point(64, 13);
            this.txtDays1From.Name = "txtDays1From";
            this.txtDays1From.Size = new System.Drawing.Size(52, 21);
            this.txtDays1From.TabIndex = 147;
            // 
            // frmAgeAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 578);
            this.Controls.Add(this.grbSlab);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpLocations);
            this.Name = "frmAgeAnalysis";
            this.Text = "Age Analysis Report";
            this.Load += new System.EventHandler(this.frmAgeAnalysis_Load);
            this.Controls.SetChildIndex(this.grpLocations, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.grbSlab, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grpLocations.ResumeLayout(false);
            this.grpLocations.PerformLayout();
            this.grbDepartment.ResumeLayout(false);
            this.grbDepartment.PerformLayout();
            this.grbCategory.ResumeLayout(false);
            this.grbCategory.PerformLayout();
            this.grbSubCategory.ResumeLayout(false);
            this.grbSubCategory.PerformLayout();
            this.grbSubCategory2.ResumeLayout(false);
            this.grbSubCategory2.PerformLayout();
            this.grbProduct.ResumeLayout(false);
            this.grbProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbSupplier.ResumeLayout(false);
            this.grbSupplier.PerformLayout();
            this.grbSlab.ResumeLayout(false);
            this.grbSlab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel grpLocations;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkAllLocations;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.RadioButton rbnDepartment;
        private System.Windows.Forms.RadioButton rbnCategory;
        private System.Windows.Forms.RadioButton rbnSubCategory;
        private System.Windows.Forms.RadioButton rbnSubCategory2;
        private System.Windows.Forms.RadioButton rbnSupplier;
        private System.Windows.Forms.Panel grbDepartment;
        private System.Windows.Forms.CheckBox chkAllDepartments;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.CheckedListBox chkLstDepartment;
        private System.Windows.Forms.Panel grbCategory;
        private System.Windows.Forms.CheckBox chkAllCategories;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.CheckedListBox chkLstCategory;
        private System.Windows.Forms.Panel grbSubCategory;
        private System.Windows.Forms.CheckBox chkAllSubCategories;
        private System.Windows.Forms.TextBox txtSubCategory;
        private System.Windows.Forms.CheckedListBox chkLstSubCategory;
        private System.Windows.Forms.Panel grbSubCategory2;
        private System.Windows.Forms.CheckBox chkAllSubCategories2;
        private System.Windows.Forms.TextBox txtSubCategory2;
        private System.Windows.Forms.CheckedListBox chkLstSubCategory2;
        private System.Windows.Forms.Panel grbProduct;
        private System.Windows.Forms.TextBox txtProducts;
        private System.Windows.Forms.Panel groupBox1;
        private System.Windows.Forms.Panel grbSupplier;
        private System.Windows.Forms.CheckBox chkAllSuppliers;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.RadioButton rbnProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel grbSlab;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDaysOver;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDays1From;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDays4From;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDays2From;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDays3From;
        private System.Windows.Forms.Label label2;
        private global::ERP.UI.Windows.CustomControls.TextBoxNumeric txtDays1To;
        private global::ERP.UI.Windows.CustomControls.TextBoxNumeric txtDays4To;
        private global::ERP.UI.Windows.CustomControls.TextBoxNumeric txtDays2To;
        private global::ERP.UI.Windows.CustomControls.TextBoxNumeric txtDays3To;
        private System.Windows.Forms.CheckedListBox chkLstSupplier;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkBxSelect;
        private System.Windows.Forms.CheckBox chkAllProducts;
    }
}