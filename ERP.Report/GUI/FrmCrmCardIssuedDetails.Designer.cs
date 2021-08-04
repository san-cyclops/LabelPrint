namespace ERP.Report.GUI
{
    partial class FrmCrmCardIssuedDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.dgvCardType = new System.Windows.Forms.DataGridView();
            this.CardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CardMasterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAllLocations = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.tabCardIssue = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.tbpHistory = new System.Windows.Forms.TabPage();
            this.chkHistory = new System.Windows.Forms.CheckBox();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.CardTypeHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectHistory = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CardMasterIDHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpHistory = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAlllocationHistory = new System.Windows.Forms.CheckBox();
            this.cmbLocationHistory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardType)).BeginInit();
            this.tabCardIssue.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.tbpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(278, 335);
            this.grpButtonSet2.Size = new System.Drawing.Size(236, 46);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Location = new System.Drawing.Point(4, 335);
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSelectAll);
            this.groupBox1.Controls.Add(this.dgvCardType);
            this.groupBox1.Controls.Add(this.chkAllLocations);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.cmbLocation);
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.lblDateRange);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 300);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(330, 74);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(79, 17);
            this.chkSelectAll.TabIndex = 149;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // dgvCardType
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SkyBlue;
            this.dgvCardType.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCardType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CardType,
            this.Select,
            this.CardMasterID});
            this.dgvCardType.Location = new System.Drawing.Point(6, 95);
            this.dgvCardType.Name = "dgvCardType";
            this.dgvCardType.RowHeadersWidth = 5;
            this.dgvCardType.Size = new System.Drawing.Size(477, 196);
            this.dgvCardType.TabIndex = 148;
            // 
            // CardType
            // 
            this.CardType.DataPropertyName = "CardName";
            this.CardType.HeaderText = "Card Type";
            this.CardType.Name = "CardType";
            this.CardType.ReadOnly = true;
            this.CardType.Width = 300;
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 50;
            // 
            // CardMasterID
            // 
            this.CardMasterID.DataPropertyName = "CardMasterID";
            this.CardMasterID.HeaderText = "CardMasterID";
            this.CardMasterID.Name = "CardMasterID";
            this.CardMasterID.Visible = false;
            // 
            // chkAllLocations
            // 
            this.chkAllLocations.AutoSize = true;
            this.chkAllLocations.Location = new System.Drawing.Point(330, 49);
            this.chkAllLocations.Name = "chkAllLocations";
            this.chkAllLocations.Size = new System.Drawing.Size(91, 17);
            this.chkAllLocations.TabIndex = 130;
            this.chkAllLocations.Text = "All Location";
            this.chkAllLocations.UseVisualStyleBackColor = true;
            this.chkAllLocations.CheckedChanged += new System.EventHandler(this.chkAllLocations_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 128;
            this.label1.Text = "-";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(275, 17);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(133, 21);
            this.dtpToDate.TabIndex = 127;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(83, 44);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(245, 21);
            this.cmbLocation.TabIndex = 125;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(8, 50);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(54, 13);
            this.lblLocation.TabIndex = 126;
            this.lblLocation.Text = "Location";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(83, 17);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(133, 21);
            this.dtpFromDate.TabIndex = 116;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(8, 23);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(74, 13);
            this.lblDateRange.TabIndex = 115;
            this.lblDateRange.Text = "Date Range";
            // 
            // tabCardIssue
            // 
            this.tabCardIssue.Controls.Add(this.tbpGeneral);
            this.tabCardIssue.Controls.Add(this.tbpHistory);
            this.tabCardIssue.Location = new System.Drawing.Point(4, 3);
            this.tabCardIssue.Name = "tabCardIssue";
            this.tabCardIssue.SelectedIndex = 0;
            this.tabCardIssue.Size = new System.Drawing.Size(511, 338);
            this.tabCardIssue.TabIndex = 13;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.groupBox1);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral.Size = new System.Drawing.Size(503, 312);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            this.tbpGeneral.UseVisualStyleBackColor = true;
            // 
            // tbpHistory
            // 
            this.tbpHistory.Controls.Add(this.chkAlllocationHistory);
            this.tbpHistory.Controls.Add(this.cmbLocationHistory);
            this.tbpHistory.Controls.Add(this.label3);
            this.tbpHistory.Controls.Add(this.chkHistory);
            this.tbpHistory.Controls.Add(this.dgvHistory);
            this.tbpHistory.Controls.Add(this.dtpHistory);
            this.tbpHistory.Controls.Add(this.label2);
            this.tbpHistory.Location = new System.Drawing.Point(4, 22);
            this.tbpHistory.Name = "tbpHistory";
            this.tbpHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tbpHistory.Size = new System.Drawing.Size(503, 312);
            this.tbpHistory.TabIndex = 1;
            this.tbpHistory.Text = "History";
            this.tbpHistory.UseVisualStyleBackColor = true;
            // 
            // chkHistory
            // 
            this.chkHistory.AutoSize = true;
            this.chkHistory.Location = new System.Drawing.Point(330, 68);
            this.chkHistory.Name = "chkHistory";
            this.chkHistory.Size = new System.Drawing.Size(79, 17);
            this.chkHistory.TabIndex = 150;
            this.chkHistory.Text = "Select All";
            this.chkHistory.UseVisualStyleBackColor = true;
            this.chkHistory.CheckedChanged += new System.EventHandler(this.chkHistory_CheckedChanged);
            // 
            // dgvHistory
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SkyBlue;
            this.dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CardTypeHistory,
            this.SelectHistory,
            this.CardMasterIDHistory});
            this.dgvHistory.Location = new System.Drawing.Point(6, 87);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowHeadersWidth = 5;
            this.dgvHistory.Size = new System.Drawing.Size(484, 216);
            this.dgvHistory.TabIndex = 149;
            // 
            // CardTypeHistory
            // 
            this.CardTypeHistory.DataPropertyName = "CardName";
            this.CardTypeHistory.HeaderText = "Card Type";
            this.CardTypeHistory.Name = "CardTypeHistory";
            this.CardTypeHistory.ReadOnly = true;
            this.CardTypeHistory.Width = 300;
            // 
            // SelectHistory
            // 
            this.SelectHistory.HeaderText = "Select";
            this.SelectHistory.Name = "SelectHistory";
            this.SelectHistory.Width = 50;
            // 
            // CardMasterIDHistory
            // 
            this.CardMasterIDHistory.DataPropertyName = "CardMasterID";
            this.CardMasterIDHistory.HeaderText = "CardMasterID";
            this.CardMasterIDHistory.Name = "CardMasterIDHistory";
            this.CardMasterIDHistory.Visible = false;
            // 
            // dtpHistory
            // 
            this.dtpHistory.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHistory.Location = new System.Drawing.Point(91, 12);
            this.dtpHistory.Name = "dtpHistory";
            this.dtpHistory.Size = new System.Drawing.Size(133, 21);
            this.dtpHistory.TabIndex = 118;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 117;
            this.label2.Text = "From";
            // 
            // chkAlllocationHistory
            // 
            this.chkAlllocationHistory.AutoSize = true;
            this.chkAlllocationHistory.Location = new System.Drawing.Point(330, 44);
            this.chkAlllocationHistory.Name = "chkAlllocationHistory";
            this.chkAlllocationHistory.Size = new System.Drawing.Size(91, 17);
            this.chkAlllocationHistory.TabIndex = 153;
            this.chkAlllocationHistory.Text = "All Location";
            this.chkAlllocationHistory.UseVisualStyleBackColor = true;
            this.chkAlllocationHistory.CheckedChanged += new System.EventHandler(this.chkAlllocationHistory_CheckedChanged);
            // 
            // cmbLocationHistory
            // 
            this.cmbLocationHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocationHistory.FormattingEnabled = true;
            this.cmbLocationHistory.Location = new System.Drawing.Point(91, 39);
            this.cmbLocationHistory.Name = "cmbLocationHistory";
            this.cmbLocationHistory.Size = new System.Drawing.Size(233, 21);
            this.cmbLocationHistory.TabIndex = 151;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 152;
            this.label3.Text = "Location";
            // 
            // FrmCrmCardIssuedDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 383);
            this.Controls.Add(this.tabCardIssue);
            this.Name = "FrmCrmCardIssuedDetails";
            this.Text = "FrmCrmCardIssuedDetails";
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.tabCardIssue, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardType)).EndInit();
            this.tabCardIssue.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.tbpHistory.ResumeLayout(false);
            this.tbpHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.CheckBox chkAllLocations;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridView dgvCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardMasterID;
        private System.Windows.Forms.TabControl tabCardIssue;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpHistory;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DateTimePicker dtpHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardTypeHistory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardMasterIDHistory;
        private System.Windows.Forms.CheckBox chkAlllocationHistory;
        private System.Windows.Forms.ComboBox cmbLocationHistory;
        private System.Windows.Forms.Label label3;
    }
}