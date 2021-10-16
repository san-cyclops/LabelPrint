namespace ERP.UI.Windows
{
    partial class FrmBarcode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvItemDetails = new System.Windows.Forms.DataGridView();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WholesalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpReferenceDocumentDate = new System.Windows.Forms.DateTimePicker();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.cmbTag = new System.Windows.Forms.ComboBox();
            this.grpHeader = new System.Windows.Forms.Panel();
            this.chkOverWrite = new System.Windows.Forms.CheckBox();
            this.btnLoad = new MaterialSkin.Controls.MaterialFlatButton();
            this.cmbDocNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReferenceDocumentNo = new System.Windows.Forms.TextBox();
            this.lblPDocumentNo = new System.Windows.Forms.Label();
            this.txtSellingPrice = new ERP.UI.Windows.CustomControls.TextBoxQty();
            this.txtWholesalePrice = new ERP.UI.Windows.CustomControls.TextBoxQty();
            this.txtQty = new ERP.UI.Windows.CustomControls.TextBoxQty();
            this.grpBody = new System.Windows.Forms.Panel();
            this.dtpManufDate = new System.Windows.Forms.DateTimePicker();
            this.grpLeftFooter = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotQty = new System.Windows.Forms.TextBox();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.grpButtonSet2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemDetails)).BeginInit();
            this.grpHeader.SuspendLayout();
            this.grpBody.SuspendLayout();
            this.grpLeftFooter.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpButtonSet2.Location = new System.Drawing.Point(897, 683);
            this.grpButtonSet2.Margin = new System.Windows.Forms.Padding(4);
            this.grpButtonSet2.Size = new System.Drawing.Size(399, 56);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(112, 5);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Size = new System.Drawing.Size(103, 45);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(5, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Size = new System.Drawing.Size(103, 45);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(220, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Size = new System.Drawing.Size(103, 45);
            // 
            // dgvItemDetails
            // 
            this.dgvItemDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.ProductCode,
            this.ProductName,
            this.Unit,
            this.BatchNo,
            this.ManufDate,
            this.Expiry,
            this.Stock,
            this.Qty,
            this.SellingPrice,
            this.WholesalePrice});
            this.dgvItemDetails.Location = new System.Drawing.Point(4, 38);
            this.dgvItemDetails.Margin = new System.Windows.Forms.Padding(4);
            this.dgvItemDetails.Name = "dgvItemDetails";
            this.dgvItemDetails.RowHeadersWidth = 15;
            this.dgvItemDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemDetails.Size = new System.Drawing.Size(1293, 309);
            this.dgvItemDetails.TabIndex = 71;
            this.dgvItemDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemDetails_CellContentClick);
            this.dgvItemDetails.DoubleClick += new System.EventHandler(this.dgvItemDetails_DoubleClick);
            this.dgvItemDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvItemDetails_KeyDown);
            // 
            // LineNo
            // 
            this.LineNo.DataPropertyName = "LineNo";
            this.LineNo.HeaderText = "Row";
            this.LineNo.Name = "LineNo";
            this.LineNo.ReadOnly = true;
            this.LineNo.Width = 35;
            // 
            // ProductCode
            // 
            this.ProductCode.DataPropertyName = "ProductCode";
            this.ProductCode.HeaderText = "Product Code";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.ReadOnly = true;
            this.ProductCode.Width = 133;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 245;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "UnitOfMeasure";
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.Width = 65;
            // 
            // BatchNo
            // 
            this.BatchNo.DataPropertyName = "BatchNo";
            this.BatchNo.HeaderText = "Batch No";
            this.BatchNo.Name = "BatchNo";
            this.BatchNo.ReadOnly = true;
            this.BatchNo.Width = 140;
            // 
            // ManufDate
            // 
            this.ManufDate.DataPropertyName = "ManufDate";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.ManufDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.ManufDate.HeaderText = "Manuf Date";
            this.ManufDate.Name = "ManufDate";
            this.ManufDate.Width = 110;
            // 
            // Expiry
            // 
            this.Expiry.DataPropertyName = "ExpiryDate";
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.Expiry.DefaultCellStyle = dataGridViewCellStyle7;
            this.Expiry.HeaderText = "Expiry Date";
            this.Expiry.Name = "Expiry";
            this.Expiry.Width = 110;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Visible = false;
            this.Stock.Width = 65;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle8;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 60;
            // 
            // SellingPrice
            // 
            this.SellingPrice.DataPropertyName = "SellingPrice";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SellingPrice.DefaultCellStyle = dataGridViewCellStyle9;
            this.SellingPrice.HeaderText = "Selling Price";
            this.SellingPrice.Name = "SellingPrice";
            this.SellingPrice.ReadOnly = true;
            // 
            // WholesalePrice
            // 
            this.WholesalePrice.DataPropertyName = "WholesalePrice";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.WholesalePrice.DefaultCellStyle = dataGridViewCellStyle10;
            this.WholesalePrice.HeaderText = "Wholesale Price";
            this.WholesalePrice.Name = "WholesalePrice";
            this.WholesalePrice.ReadOnly = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(668, 17);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 16);
            this.lblDate.TabIndex = 83;
            this.lblDate.Text = "Date";
            // 
            // dtpReferenceDocumentDate
            // 
            this.dtpReferenceDocumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReferenceDocumentDate.Location = new System.Drawing.Point(671, 36);
            this.dtpReferenceDocumentDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpReferenceDocumentDate.Name = "dtpReferenceDocumentDate";
            this.dtpReferenceDocumentDate.Size = new System.Drawing.Size(136, 23);
            this.dtpReferenceDocumentDate.TabIndex = 82;
            this.dtpReferenceDocumentDate.Value = new System.DateTime(2013, 12, 11, 9, 32, 0, 0);
            this.dtpReferenceDocumentDate.Enter += new System.EventHandler(this.dtpReferenceDocumentDate_Enter);
            this.dtpReferenceDocumentDate.Leave += new System.EventHandler(this.dtpReferenceDocumentDate_Leave);
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(490, 5);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(80, 24);
            this.cmbUnit.TabIndex = 76;
            this.cmbUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbUnit_KeyDown);
            this.cmbUnit.Leave += new System.EventHandler(this.cmbUnit_Leave);
            // 
            // dtpExpiry
            // 
            this.dtpExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiry.Location = new System.Drawing.Point(852, 4);
            this.dtpExpiry.Margin = new System.Windows.Forms.Padding(4);
            this.dtpExpiry.Name = "dtpExpiry";
            this.dtpExpiry.Size = new System.Drawing.Size(120, 23);
            this.dtpExpiry.TabIndex = 81;
            this.dtpExpiry.Value = new System.DateTime(2013, 12, 11, 9, 32, 0, 0);
            this.dtpExpiry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpExpiry_KeyDown);
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Location = new System.Drawing.Point(572, 5);
            this.txtBatchNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(160, 23);
            this.txtBatchNo.TabIndex = 75;
            this.txtBatchNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBatchNo_KeyDown);
            this.txtBatchNo.Leave += new System.EventHandler(this.txtBatchNo_Leave);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(210, 5);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(279, 23);
            this.txtProductName.TabIndex = 73;
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductName_KeyDown);
            this.txtProductName.Leave += new System.EventHandler(this.txtProductName_Leave);
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(13, 5);
            this.txtProductCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductCode.MaxLength = 15;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(195, 23);
            this.txtProductCode.TabIndex = 72;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            this.txtProductCode.Leave += new System.EventHandler(this.txtProductCode_Leave);
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTag.Location = new System.Drawing.Point(10, 16);
            this.lblTag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(158, 18);
            this.lblTag.TabIndex = 67;
            this.lblTag.Text = "Label Description";
            // 
            // cmbTag
            // 
            this.cmbTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTag.FormattingEnabled = true;
            this.cmbTag.Location = new System.Drawing.Point(275, 13);
            this.cmbTag.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTag.Name = "cmbTag";
            this.cmbTag.Size = new System.Drawing.Size(344, 24);
            this.cmbTag.TabIndex = 48;
            this.cmbTag.Enter += new System.EventHandler(this.cmbTag_Enter);
            this.cmbTag.Leave += new System.EventHandler(this.cmbTag_Leave);
            // 
            // grpHeader
            // 
            this.grpHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpHeader.Controls.Add(this.chkOverWrite);
            this.grpHeader.Controls.Add(this.btnLoad);
            this.grpHeader.Controls.Add(this.cmbDocNo);
            this.grpHeader.Controls.Add(this.label1);
            this.grpHeader.Controls.Add(this.lblDate);
            this.grpHeader.Controls.Add(this.dtpReferenceDocumentDate);
            this.grpHeader.Controls.Add(this.txtReferenceDocumentNo);
            this.grpHeader.Controls.Add(this.lblPDocumentNo);
            this.grpHeader.Location = new System.Drawing.Point(3, 185);
            this.grpHeader.Margin = new System.Windows.Forms.Padding(4);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1293, 65);
            this.grpHeader.TabIndex = 153;
            // 
            // chkOverWrite
            // 
            this.chkOverWrite.AutoSize = true;
            this.chkOverWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkOverWrite.Location = new System.Drawing.Point(870, 36);
            this.chkOverWrite.Name = "chkOverWrite";
            this.chkOverWrite.Size = new System.Drawing.Size(122, 20);
            this.chkOverWrite.TabIndex = 88;
            this.chkOverWrite.Text = "Qty Overwrite ";
            this.chkOverWrite.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.chkOverWrite.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.AutoSize = true;
            this.btnLoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoad.BackColor = System.Drawing.Color.BlueViolet;
            this.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoad.Depth = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLoad.Location = new System.Drawing.Point(215, 27);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLoad.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Primary = false;
            this.btnLoad.Size = new System.Drawing.Size(46, 36);
            this.btnLoad.TabIndex = 87;
            this.btnLoad.Text = "Load\r\n";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cmbDocNo
            // 
            this.cmbDocNo.FormattingEnabled = true;
            this.cmbDocNo.Location = new System.Drawing.Point(13, 34);
            this.cmbDocNo.Name = "cmbDocNo";
            this.cmbDocNo.Size = new System.Drawing.Size(195, 24);
            this.cmbDocNo.TabIndex = 86;
            this.cmbDocNo.Click += new System.EventHandler(this.cmbDocNo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 85;
            this.label1.Text = "DocumentNo";
            // 
            // txtReferenceDocumentNo
            // 
            this.txtReferenceDocumentNo.Location = new System.Drawing.Point(283, 35);
            this.txtReferenceDocumentNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtReferenceDocumentNo.Name = "txtReferenceDocumentNo";
            this.txtReferenceDocumentNo.Size = new System.Drawing.Size(268, 23);
            this.txtReferenceDocumentNo.TabIndex = 69;
            this.txtReferenceDocumentNo.Enter += new System.EventHandler(this.txtReferenceDocumentNo_Enter);
            this.txtReferenceDocumentNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReferenceDocumentNo_KeyDown);
            this.txtReferenceDocumentNo.Leave += new System.EventHandler(this.txtReferenceDocumentNo_Leave);
            // 
            // lblPDocumentNo
            // 
            this.lblPDocumentNo.AutoSize = true;
            this.lblPDocumentNo.Location = new System.Drawing.Point(281, 15);
            this.lblPDocumentNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPDocumentNo.Name = "lblPDocumentNo";
            this.lblPDocumentNo.Size = new System.Drawing.Size(67, 16);
            this.lblPDocumentNo.TabIndex = 68;
            this.lblPDocumentNo.Text = "Print Rec";
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.Location = new System.Drawing.Point(1054, 4);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.QtyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSellingPrice.Size = new System.Drawing.Size(115, 23);
            this.txtSellingPrice.TabIndex = 85;
            this.txtSellingPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellingPrice_KeyDown);
            // 
            // txtWholesalePrice
            // 
            this.txtWholesalePrice.Location = new System.Drawing.Point(1170, 3);
            this.txtWholesalePrice.Name = "txtWholesalePrice";
            this.txtWholesalePrice.QtyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtWholesalePrice.Size = new System.Drawing.Size(114, 23);
            this.txtWholesalePrice.TabIndex = 84;
            this.txtWholesalePrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWholesalePrice_KeyDown);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(973, 5);
            this.txtQty.Name = "txtQty";
            this.txtQty.QtyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtQty.Size = new System.Drawing.Size(80, 23);
            this.txtQty.TabIndex = 83;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            // 
            // grpBody
            // 
            this.grpBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpBody.Controls.Add(this.txtSellingPrice);
            this.grpBody.Controls.Add(this.txtWholesalePrice);
            this.grpBody.Controls.Add(this.txtQty);
            this.grpBody.Controls.Add(this.dtpManufDate);
            this.grpBody.Controls.Add(this.dgvItemDetails);
            this.grpBody.Controls.Add(this.cmbUnit);
            this.grpBody.Controls.Add(this.dtpExpiry);
            this.grpBody.Controls.Add(this.txtProductCode);
            this.grpBody.Controls.Add(this.txtProductName);
            this.grpBody.Controls.Add(this.txtBatchNo);
            this.grpBody.Location = new System.Drawing.Point(3, 255);
            this.grpBody.Margin = new System.Windows.Forms.Padding(4);
            this.grpBody.Name = "grpBody";
            this.grpBody.Size = new System.Drawing.Size(1293, 353);
            this.grpBody.TabIndex = 154;
            // 
            // dtpManufDate
            // 
            this.dtpManufDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpManufDate.Location = new System.Drawing.Point(732, 5);
            this.dtpManufDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpManufDate.Name = "dtpManufDate";
            this.dtpManufDate.Size = new System.Drawing.Size(118, 23);
            this.dtpManufDate.TabIndex = 82;
            this.dtpManufDate.Value = new System.DateTime(2013, 12, 11, 9, 32, 0, 0);
            this.dtpManufDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpManufDate_KeyDown);
            // 
            // grpLeftFooter
            // 
            this.grpLeftFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpLeftFooter.Controls.Add(this.lblTag);
            this.grpLeftFooter.Controls.Add(this.cmbTag);
            this.grpLeftFooter.Location = new System.Drawing.Point(3, 615);
            this.grpLeftFooter.Margin = new System.Windows.Forms.Padding(4);
            this.grpLeftFooter.Name = "grpLeftFooter";
            this.grpLeftFooter.Size = new System.Drawing.Size(640, 50);
            this.grpLeftFooter.TabIndex = 154;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTotQty);
            this.panel1.Controls.Add(this.lblNetAmount);
            this.panel1.Location = new System.Drawing.Point(651, 615);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 50);
            this.panel1.TabIndex = 155;
            // 
            // txtTotQty
            // 
            this.txtTotQty.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtTotQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtTotQty.Location = new System.Drawing.Point(430, 11);
            this.txtTotQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotQty.Name = "txtTotQty";
            this.txtTotQty.ReadOnly = true;
            this.txtTotQty.Size = new System.Drawing.Size(153, 21);
            this.txtTotQty.TabIndex = 76;
            this.txtTotQty.Text = "0.00";
            this.txtTotQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.AutoSize = true;
            this.lblNetAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetAmount.Location = new System.Drawing.Point(349, 13);
            this.lblNetAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Size = new System.Drawing.Size(66, 13);
            this.lblNetAmount.TabIndex = 77;
            this.lblNetAmount.Text = "Total Qty";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::ERP.UI.Windows.Properties.Resources.pp1;
            this.pictureBox2.Location = new System.Drawing.Point(-6, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1302, 176);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 157;
            this.pictureBox2.TabStop = false;
            // 
            // FrmBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1300, 741);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpLeftFooter);
            this.Controls.Add(this.grpBody);
            this.Controls.Add(this.grpHeader);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBarcode";
            this.Text = "Barcode Printing";
            this.Load += new System.EventHandler(this.FrmBarcode_Load);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.grpHeader, 0);
            this.Controls.SetChildIndex(this.grpBody, 0);
            this.Controls.SetChildIndex(this.grpLeftFooter, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.grpButtonSet2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemDetails)).EndInit();
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpBody.ResumeLayout(false);
            this.grpBody.PerformLayout();
            this.grpLeftFooter.ResumeLayout(false);
            this.grpLeftFooter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvItemDetails;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpReferenceDocumentDate;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.ComboBox cmbTag;
        private System.Windows.Forms.Panel grpHeader;
        private System.Windows.Forms.Panel grpBody;
        private System.Windows.Forms.Panel grpLeftFooter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtReferenceDocumentNo;
        private System.Windows.Forms.Label lblPDocumentNo;
        private System.Windows.Forms.DateTimePicker dtpManufDate;
        private System.Windows.Forms.TextBox txtTotQty;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.PictureBox pictureBox2;
        private CustomControls.TextBoxQty txtSellingPrice;
        private CustomControls.TextBoxQty txtWholesalePrice;
        private CustomControls.TextBoxQty txtQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn WholesalePrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDocNo;
        private MaterialSkin.Controls.MaterialFlatButton btnLoad;
        private System.Windows.Forms.CheckBox chkOverWrite;
    }
}