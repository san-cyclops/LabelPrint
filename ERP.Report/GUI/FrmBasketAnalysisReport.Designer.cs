namespace ERP.Report.GUI
{
    partial class FrmBasketAnalysisReport
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
            this.groupBox2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.Panel();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.chkTuesday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.chkGiftVoucher = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.dgvRange = new System.Windows.Forms.DataGridView();
            this.RangeFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RangeTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdoItem = new System.Windows.Forms.RadioButton();
            this.rdoQty = new System.Windows.Forms.RadioButton();
            this.rdoValue = new System.Windows.Forms.RadioButton();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.chkDayReport = new System.Windows.Forms.CheckBox();
            this.chkGetLocationWise = new System.Windows.Forms.CheckBox();
            this.chkExchange = new System.Windows.Forms.CheckBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.gbFieldSelection = new System.Windows.Forms.Panel();
            this.chkListLocation = new System.Windows.Forms.CheckedListBox();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRange)).BeginInit();
            this.gbFieldSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(764, 540);
            this.grpButtonSet2.Size = new System.Drawing.Size(236, 46);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Location = new System.Drawing.Point(2, 540);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.chkGiftVoucher);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.cmbCustomerType);
            this.groupBox2.Controls.Add(this.lblCustomerType);
            this.groupBox2.Controls.Add(this.chkDayReport);
            this.groupBox2.Controls.Add(this.chkGetLocationWise);
            this.groupBox2.Controls.Add(this.chkExchange);
            this.groupBox2.Controls.Add(this.dtpToDate);
            this.groupBox2.Controls.Add(this.dtpFromDate);
            this.groupBox2.Controls.Add(this.lblDateRange);
            this.groupBox2.Controls.Add(this.gbFieldSelection);
            this.groupBox2.Location = new System.Drawing.Point(2, -5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(999, 549);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkSunday);
            this.groupBox3.Controls.Add(this.chkSaturday);
            this.groupBox3.Controls.Add(this.chkFriday);
            this.groupBox3.Controls.Add(this.chkThursday);
            this.groupBox3.Controls.Add(this.chkWednesday);
            this.groupBox3.Controls.Add(this.chkTuesday);
            this.groupBox3.Controls.Add(this.chkMonday);
            this.groupBox3.Location = new System.Drawing.Point(237, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 110);
            this.groupBox3.TabIndex = 124;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Days";
            this.groupBox3.Visible = false;
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.Location = new System.Drawing.Point(139, 58);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(69, 17);
            this.chkSunday.TabIndex = 124;
            this.chkSunday.Text = "Sunday";
            this.chkSunday.UseVisualStyleBackColor = true;
            this.chkSunday.Enter += new System.EventHandler(this.chkSunday_Enter);
            this.chkSunday.Leave += new System.EventHandler(this.chkSunday_Leave);
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.Location = new System.Drawing.Point(139, 39);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(78, 17);
            this.chkSaturday.TabIndex = 123;
            this.chkSaturday.Text = "Saturday";
            this.chkSaturday.UseVisualStyleBackColor = true;
            this.chkSaturday.Enter += new System.EventHandler(this.chkSaturday_Enter);
            this.chkSaturday.Leave += new System.EventHandler(this.chkSaturday_Leave);
            // 
            // chkFriday
            // 
            this.chkFriday.AutoSize = true;
            this.chkFriday.Location = new System.Drawing.Point(139, 19);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(61, 17);
            this.chkFriday.TabIndex = 122;
            this.chkFriday.Text = "Friday";
            this.chkFriday.UseVisualStyleBackColor = true;
            this.chkFriday.Enter += new System.EventHandler(this.chkFriday_Enter);
            this.chkFriday.Leave += new System.EventHandler(this.chkFriday_Leave);
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Location = new System.Drawing.Point(33, 77);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(79, 17);
            this.chkThursday.TabIndex = 121;
            this.chkThursday.Text = "Thursday";
            this.chkThursday.UseVisualStyleBackColor = true;
            this.chkThursday.Enter += new System.EventHandler(this.chkThursday_Enter);
            this.chkThursday.Leave += new System.EventHandler(this.chkThursday_Leave);
            // 
            // chkWednesday
            // 
            this.chkWednesday.AutoSize = true;
            this.chkWednesday.Location = new System.Drawing.Point(33, 58);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(91, 17);
            this.chkWednesday.TabIndex = 120;
            this.chkWednesday.Text = "Wednesday";
            this.chkWednesday.UseVisualStyleBackColor = true;
            this.chkWednesday.Enter += new System.EventHandler(this.chkWednesday_Enter);
            this.chkWednesday.Leave += new System.EventHandler(this.chkWednesday_Leave);
            // 
            // chkTuesday
            // 
            this.chkTuesday.AutoSize = true;
            this.chkTuesday.Location = new System.Drawing.Point(33, 39);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(73, 17);
            this.chkTuesday.TabIndex = 119;
            this.chkTuesday.Text = "Tuesday";
            this.chkTuesday.UseVisualStyleBackColor = true;
            this.chkTuesday.Enter += new System.EventHandler(this.chkTuesday_Enter);
            this.chkTuesday.Leave += new System.EventHandler(this.chkTuesday_Leave);
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Location = new System.Drawing.Point(33, 19);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(70, 17);
            this.chkMonday.TabIndex = 118;
            this.chkMonday.Text = "Monday";
            this.chkMonday.UseVisualStyleBackColor = true;
            this.chkMonday.Enter += new System.EventHandler(this.chkMonday_Enter);
            this.chkMonday.Leave += new System.EventHandler(this.chkMonday_Leave);
            // 
            // chkGiftVoucher
            // 
            this.chkGiftVoucher.AutoSize = true;
            this.chkGiftVoucher.Location = new System.Drawing.Point(20, 115);
            this.chkGiftVoucher.Name = "chkGiftVoucher";
            this.chkGiftVoucher.Size = new System.Drawing.Size(179, 17);
            this.chkGiftVoucher.TabIndex = 123;
            this.chkGiftVoucher.Text = "Exclude Gift Voucher Sales";
            this.chkGiftVoucher.UseVisualStyleBackColor = true;
            this.chkGiftVoucher.Enter += new System.EventHandler(this.chkGiftVoucher_Enter);
            this.chkGiftVoucher.Leave += new System.EventHandler(this.chkGiftVoucher_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvRange);
            this.groupBox1.Controls.Add(this.rdoItem);
            this.groupBox1.Controls.Add(this.rdoQty);
            this.groupBox1.Controls.Add(this.rdoValue);
            this.groupBox1.Location = new System.Drawing.Point(5, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 365);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Slab";
            // 
            // dgvRange
            // 
            this.dgvRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRange.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RangeFrom,
            this.RangeTo});
            this.dgvRange.Location = new System.Drawing.Point(25, 54);
            this.dgvRange.Name = "dgvRange";
            this.dgvRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvRange.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRange.Size = new System.Drawing.Size(419, 305);
            this.dgvRange.TabIndex = 3;
            // 
            // RangeFrom
            // 
            this.RangeFrom.DataPropertyName = "RangeFrom";
            this.RangeFrom.Frozen = true;
            this.RangeFrom.HeaderText = "Range From";
            this.RangeFrom.Name = "RangeFrom";
            this.RangeFrom.Width = 180;
            // 
            // RangeTo
            // 
            this.RangeTo.DataPropertyName = "RangeTo";
            this.RangeTo.Frozen = true;
            this.RangeTo.HeaderText = "Range To";
            this.RangeTo.Name = "RangeTo";
            this.RangeTo.Width = 180;
            // 
            // rdoItem
            // 
            this.rdoItem.AutoSize = true;
            this.rdoItem.Location = new System.Drawing.Point(310, 20);
            this.rdoItem.Name = "rdoItem";
            this.rdoItem.Size = new System.Drawing.Size(117, 17);
            this.rdoItem.TabIndex = 2;
            this.rdoItem.TabStop = true;
            this.rdoItem.Text = "No of Item Wise";
            this.rdoItem.UseVisualStyleBackColor = true;
            this.rdoItem.CheckedChanged += new System.EventHandler(this.rdoItem_CheckedChanged);
            this.rdoItem.Enter += new System.EventHandler(this.rdoItem_Enter);
            this.rdoItem.Leave += new System.EventHandler(this.rdoItem_Leave);
            // 
            // rdoQty
            // 
            this.rdoQty.AutoSize = true;
            this.rdoQty.Location = new System.Drawing.Point(189, 20);
            this.rdoQty.Name = "rdoQty";
            this.rdoQty.Size = new System.Drawing.Size(76, 17);
            this.rdoQty.TabIndex = 1;
            this.rdoQty.TabStop = true;
            this.rdoQty.Text = "Qty Wise";
            this.rdoQty.UseVisualStyleBackColor = true;
            this.rdoQty.CheckedChanged += new System.EventHandler(this.rdoQty_CheckedChanged);
            this.rdoQty.Enter += new System.EventHandler(this.rdoQty_Enter);
            this.rdoQty.Leave += new System.EventHandler(this.rdoQty_Leave);
            // 
            // rdoValue
            // 
            this.rdoValue.AutoSize = true;
            this.rdoValue.Checked = true;
            this.rdoValue.Location = new System.Drawing.Point(50, 20);
            this.rdoValue.Name = "rdoValue";
            this.rdoValue.Size = new System.Drawing.Size(87, 17);
            this.rdoValue.TabIndex = 0;
            this.rdoValue.TabStop = true;
            this.rdoValue.Text = "Value Wise";
            this.rdoValue.UseVisualStyleBackColor = true;
            this.rdoValue.CheckedChanged += new System.EventHandler(this.rdoValue_CheckedChanged);
            this.rdoValue.Enter += new System.EventHandler(this.rdoValue_Enter);
            this.rdoValue.Leave += new System.EventHandler(this.rdoValue_Leave);
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Items.AddRange(new object[] {
            "All Customers",
            "Loyalty Customers",
            "Staff Purchases"});
            this.cmbCustomerType.Location = new System.Drawing.Point(130, 49);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(287, 21);
            this.cmbCustomerType.TabIndex = 120;
            this.cmbCustomerType.Enter += new System.EventHandler(this.cmbCustomerType_Enter);
            this.cmbCustomerType.Leave += new System.EventHandler(this.cmbCustomerType_Leave);
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Location = new System.Drawing.Point(17, 52);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(94, 13);
            this.lblCustomerType.TabIndex = 121;
            this.lblCustomerType.Text = "Customer Type";
            // 
            // chkDayReport
            // 
            this.chkDayReport.AutoSize = true;
            this.chkDayReport.Location = new System.Drawing.Point(20, 153);
            this.chkDayReport.Name = "chkDayReport";
            this.chkDayReport.Size = new System.Drawing.Size(198, 17);
            this.chkDayReport.TabIndex = 119;
            this.chkDayReport.Text = "Get Day Of Week Wise Report";
            this.chkDayReport.UseVisualStyleBackColor = true;
            this.chkDayReport.Visible = false;
            this.chkDayReport.Enter += new System.EventHandler(this.chkDayReport_Enter);
            this.chkDayReport.Leave += new System.EventHandler(this.chkDayReport_Leave);
            // 
            // chkGetLocationWise
            // 
            this.chkGetLocationWise.AutoSize = true;
            this.chkGetLocationWise.Location = new System.Drawing.Point(20, 134);
            this.chkGetLocationWise.Name = "chkGetLocationWise";
            this.chkGetLocationWise.Size = new System.Drawing.Size(170, 17);
            this.chkGetLocationWise.TabIndex = 118;
            this.chkGetLocationWise.Text = "Get Location Wise Report";
            this.chkGetLocationWise.UseVisualStyleBackColor = true;
            this.chkGetLocationWise.Enter += new System.EventHandler(this.chkGetLocationWise_Enter);
            this.chkGetLocationWise.Leave += new System.EventHandler(this.chkGetLocationWise_Leave);
            // 
            // chkExchange
            // 
            this.chkExchange.AutoSize = true;
            this.chkExchange.Location = new System.Drawing.Point(20, 95);
            this.chkExchange.Name = "chkExchange";
            this.chkExchange.Size = new System.Drawing.Size(135, 17);
            this.chkExchange.TabIndex = 117;
            this.chkExchange.Text = "Exclude Exchanges";
            this.chkExchange.UseVisualStyleBackColor = true;
            this.chkExchange.Enter += new System.EventHandler(this.chkExchange_Enter);
            this.chkExchange.Leave += new System.EventHandler(this.chkExchange_Leave);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(284, 22);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(133, 21);
            this.dtpToDate.TabIndex = 116;
            this.dtpToDate.Enter += new System.EventHandler(this.dtpToDate_Enter);
            this.dtpToDate.Leave += new System.EventHandler(this.dtpToDate_Leave);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(130, 22);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(133, 21);
            this.dtpFromDate.TabIndex = 115;
            this.dtpFromDate.Enter += new System.EventHandler(this.dtpFromDate_Enter);
            this.dtpFromDate.Leave += new System.EventHandler(this.dtpFromDate_Leave);
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(17, 28);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(74, 13);
            this.lblDateRange.TabIndex = 114;
            this.lblDateRange.Text = "Date Range";
            // 
            // gbFieldSelection
            // 
            this.gbFieldSelection.Controls.Add(this.chkListLocation);
            this.gbFieldSelection.Location = new System.Drawing.Point(486, 9);
            this.gbFieldSelection.Name = "gbFieldSelection";
            this.gbFieldSelection.Size = new System.Drawing.Size(507, 536);
            this.gbFieldSelection.TabIndex = 20;
            this.gbFieldSelection.TabStop = false;
            this.gbFieldSelection.Text = "Select Locations";
            // 
            // chkListLocation
            // 
            this.chkListLocation.CheckOnClick = true;
            this.chkListLocation.ColumnWidth = 250;
            this.chkListLocation.FormattingEnabled = true;
            this.chkListLocation.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07"});
            this.chkListLocation.Location = new System.Drawing.Point(11, 17);
            this.chkListLocation.MultiColumn = true;
            this.chkListLocation.Name = "chkListLocation";
            this.chkListLocation.Size = new System.Drawing.Size(486, 516);
            this.chkListLocation.TabIndex = 13;
            // 
            // FrmBasketAnalysisReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 588);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmBasketAnalysisReport";
            this.Text = "Basket Analysis Report";
            this.Load += new System.EventHandler(this.FrmBasketAnalysisReport_Load);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRange)).EndInit();
            this.gbFieldSelection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel groupBox2;
        private System.Windows.Forms.Panel gbFieldSelection;
        private System.Windows.Forms.CheckedListBox chkListLocation;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.CheckBox chkGetLocationWise;
        private System.Windows.Forms.CheckBox chkExchange;
        private System.Windows.Forms.CheckBox chkDayReport;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label lblCustomerType;
        private System.Windows.Forms.Panel groupBox1;
        private System.Windows.Forms.RadioButton rdoItem;
        private System.Windows.Forms.RadioButton rdoQty;
        private System.Windows.Forms.RadioButton rdoValue;
        private System.Windows.Forms.DataGridView dgvRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn RangeFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn RangeTo;
        private System.Windows.Forms.CheckBox chkGiftVoucher;
        private System.Windows.Forms.Panel groupBox3;
        private System.Windows.Forms.CheckBox chkSunday;
        private System.Windows.Forms.CheckBox chkSaturday;
        private System.Windows.Forms.CheckBox chkFriday;
        private System.Windows.Forms.CheckBox chkThursday;
        private System.Windows.Forms.CheckBox chkWednesday;
        private System.Windows.Forms.CheckBox chkTuesday;
        private System.Windows.Forms.CheckBox chkMonday;
    }
}