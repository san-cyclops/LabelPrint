namespace ERP.Report.GUI
{
    partial class FrmCrmNewCardDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.dgvCardType = new System.Windows.Forms.DataGridView();
            this.CardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CardMasterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpIssueToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpIssueFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAlllocations = new System.Windows.Forms.CheckBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.rdoEarn = new System.Windows.Forms.RadioButton();
            this.rdoRedeem = new System.Windows.Forms.RadioButton();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardType)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(259, 319);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Location = new System.Drawing.Point(2, 319);
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(4, 11);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoRedeem);
            this.groupBox1.Controls.Add(this.rdoEarn);
            this.groupBox1.Controls.Add(this.chkSelectAll);
            this.groupBox1.Controls.Add(this.dgvCardType);
            this.groupBox1.Controls.Add(this.prgBar);
            this.groupBox1.Location = new System.Drawing.Point(3, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 210);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(332, 18);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(79, 17);
            this.chkSelectAll.TabIndex = 149;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // dgvCardType
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            this.dgvCardType.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCardType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CardType,
            this.Select,
            this.CardMasterID});
            this.dgvCardType.Location = new System.Drawing.Point(8, 38);
            this.dgvCardType.Name = "dgvCardType";
            this.dgvCardType.RowHeadersWidth = 5;
            this.dgvCardType.Size = new System.Drawing.Size(479, 166);
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
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(8, 389);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(473, 10);
            this.prgBar.Step = 1;
            this.prgBar.TabIndex = 142;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtpIssueToDate);
            this.groupBox3.Controls.Add(this.dtpIssueFromDate);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.chkAlllocations);
            this.groupBox3.Controls.Add(this.cmbLocation);
            this.groupBox3.Controls.Add(this.lblLocation);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtpToDate);
            this.groupBox3.Controls.Add(this.dtpFromDate);
            this.groupBox3.Controls.Add(this.lblDateRange);
            this.groupBox3.Location = new System.Drawing.Point(3, -5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(494, 118);
            this.groupBox3.TabIndex = 153;
            this.groupBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 161;
            this.label2.Text = "-";
            // 
            // dtpIssueToDate
            // 
            this.dtpIssueToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIssueToDate.Location = new System.Drawing.Point(336, 42);
            this.dtpIssueToDate.Name = "dtpIssueToDate";
            this.dtpIssueToDate.Size = new System.Drawing.Size(138, 21);
            this.dtpIssueToDate.TabIndex = 160;
            // 
            // dtpIssueFromDate
            // 
            this.dtpIssueFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIssueFromDate.Location = new System.Drawing.Point(170, 42);
            this.dtpIssueFromDate.Name = "dtpIssueFromDate";
            this.dtpIssueFromDate.Size = new System.Drawing.Size(133, 21);
            this.dtpIssueFromDate.TabIndex = 159;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 158;
            this.label3.Text = "Issued Date Range";
            // 
            // chkAlllocations
            // 
            this.chkAlllocations.AutoSize = true;
            this.chkAlllocations.Location = new System.Drawing.Point(332, 96);
            this.chkAlllocations.Name = "chkAlllocations";
            this.chkAlllocations.Size = new System.Drawing.Size(97, 17);
            this.chkAlllocations.TabIndex = 138;
            this.chkAlllocations.Text = "All Locations";
            this.chkAlllocations.UseVisualStyleBackColor = true;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(170, 69);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(304, 21);
            this.cmbLocation.TabIndex = 136;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(10, 77);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(54, 13);
            this.lblLocation.TabIndex = 137;
            this.lblLocation.Text = "Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 132;
            this.label1.Text = "-";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(336, 15);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(138, 21);
            this.dtpToDate.TabIndex = 131;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(170, 15);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(133, 21);
            this.dtpFromDate.TabIndex = 130;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(10, 21);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(143, 13);
            this.lblDateRange.TabIndex = 129;
            this.lblDateRange.Text = "Transaction Date Range";
            // 
            // rdoEarn
            // 
            this.rdoEarn.AutoSize = true;
            this.rdoEarn.Location = new System.Drawing.Point(13, 15);
            this.rdoEarn.Name = "rdoEarn";
            this.rdoEarn.Size = new System.Drawing.Size(82, 17);
            this.rdoEarn.TabIndex = 150;
            this.rdoEarn.TabStop = true;
            this.rdoEarn.Text = "View Earn";
            this.rdoEarn.UseVisualStyleBackColor = true;
            // 
            // rdoRedeem
            // 
            this.rdoRedeem.AutoSize = true;
            this.rdoRedeem.Location = new System.Drawing.Point(170, 15);
            this.rdoRedeem.Name = "rdoRedeem";
            this.rdoRedeem.Size = new System.Drawing.Size(103, 17);
            this.rdoRedeem.TabIndex = 151;
            this.rdoRedeem.TabStop = true;
            this.rdoRedeem.Text = "View Redeem";
            this.rdoRedeem.UseVisualStyleBackColor = true;
            // 
            // FrmCrmNewCardDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 367);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCrmNewCardDetail";
            this.Text = "FrmCrmNewCardDetail";
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardType)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel groupBox1;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridView dgvCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardMasterID;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.Panel groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpIssueToDate;
        private System.Windows.Forms.DateTimePicker dtpIssueFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAlllocations;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.RadioButton rdoRedeem;
        private System.Windows.Forms.RadioButton rdoEarn;


    }
}