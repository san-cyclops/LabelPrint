namespace ERP.Report.GUI
{
    partial class FrmCrmLostAndRenewDetail
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
            this.chkAlllocations = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.tbpCustomerWise = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.Panel();
            this.lblNameOnCard = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAutoCompleationNic = new System.Windows.Forms.CheckBox();
            this.txtNic = new System.Windows.Forms.TextBox();
            this.lblNic = new System.Windows.Forms.Label();
            this.lblCardType = new System.Windows.Forms.Label();
            this.chkAutoCompleationCardNo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.chkAutoCompleationCustomer = new System.Windows.Forms.CheckBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardType)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.tbpCustomerWise.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(248, 311);
            this.grpButtonSet2.Size = new System.Drawing.Size(239, 46);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Location = new System.Drawing.Point(2, 311);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(82, 11);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(160, 11);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(4, 11);
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSelectAll);
            this.groupBox1.Controls.Add(this.dgvCardType);
            this.groupBox1.Controls.Add(this.chkAlllocations);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.cmbLocation);
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.lblDateRange);
            this.groupBox1.Location = new System.Drawing.Point(4, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 286);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(334, 71);
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
            this.dgvCardType.Location = new System.Drawing.Point(11, 94);
            this.dgvCardType.Name = "dgvCardType";
            this.dgvCardType.RowHeadersWidth = 5;
            this.dgvCardType.Size = new System.Drawing.Size(449, 188);
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
            // chkAlllocations
            // 
            this.chkAlllocations.AutoSize = true;
            this.chkAlllocations.Location = new System.Drawing.Point(334, 51);
            this.chkAlllocations.Name = "chkAlllocations";
            this.chkAlllocations.Size = new System.Drawing.Size(97, 17);
            this.chkAlllocations.TabIndex = 135;
            this.chkAlllocations.Text = "All Locations";
            this.chkAlllocations.UseVisualStyleBackColor = true;
            this.chkAlllocations.CheckedChanged += new System.EventHandler(this.chkAlllocations_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 21);
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
            this.dtpToDate.Size = new System.Drawing.Size(138, 21);
            this.dtpToDate.TabIndex = 127;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(90, 47);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(237, 21);
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
            this.dtpFromDate.Location = new System.Drawing.Point(90, 17);
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
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tbpGeneral);
            this.tabMain.Controls.Add(this.tbpCustomerWise);
            this.tabMain.Location = new System.Drawing.Point(5, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(482, 314);
            this.tabMain.TabIndex = 13;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.groupBox1);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral.Size = new System.Drawing.Size(474, 288);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            this.tbpGeneral.UseVisualStyleBackColor = true;
            // 
            // tbpCustomerWise
            // 
            this.tbpCustomerWise.Controls.Add(this.groupBox2);
            this.tbpCustomerWise.Location = new System.Drawing.Point(4, 22);
            this.tbpCustomerWise.Name = "tbpCustomerWise";
            this.tbpCustomerWise.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCustomerWise.Size = new System.Drawing.Size(474, 288);
            this.tbpCustomerWise.TabIndex = 1;
            this.tbpCustomerWise.Text = "Customer Wise";
            this.tbpCustomerWise.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNameOnCard);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chkAutoCompleationNic);
            this.groupBox2.Controls.Add(this.txtNic);
            this.groupBox2.Controls.Add(this.lblNic);
            this.groupBox2.Controls.Add(this.lblCardType);
            this.groupBox2.Controls.Add(this.chkAutoCompleationCardNo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtCardNo);
            this.groupBox2.Controls.Add(this.lblCardNo);
            this.groupBox2.Controls.Add(this.chkAutoCompleationCustomer);
            this.groupBox2.Controls.Add(this.txtCustomerName);
            this.groupBox2.Controls.Add(this.txtCustomerCode);
            this.groupBox2.Controls.Add(this.lblCustomerCode);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 276);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // lblNameOnCard
            // 
            this.lblNameOnCard.AutoSize = true;
            this.lblNameOnCard.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNameOnCard.Location = new System.Drawing.Point(103, 107);
            this.lblNameOnCard.Name = "lblNameOnCard";
            this.lblNameOnCard.Size = new System.Drawing.Size(70, 13);
            this.lblNameOnCard.TabIndex = 94;
            this.lblNameOnCard.Text = "Card Type ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 93;
            this.label4.Text = "Name on card : ";
            // 
            // chkAutoCompleationNic
            // 
            this.chkAutoCompleationNic.AutoSize = true;
            this.chkAutoCompleationNic.Checked = true;
            this.chkAutoCompleationNic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoCompleationNic.Location = new System.Drawing.Point(289, 41);
            this.chkAutoCompleationNic.Name = "chkAutoCompleationNic";
            this.chkAutoCompleationNic.Size = new System.Drawing.Size(15, 14);
            this.chkAutoCompleationNic.TabIndex = 92;
            this.chkAutoCompleationNic.Tag = "1";
            this.chkAutoCompleationNic.UseVisualStyleBackColor = true;
            // 
            // txtNic
            // 
            this.txtNic.Location = new System.Drawing.Point(307, 38);
            this.txtNic.Name = "txtNic";
            this.txtNic.Size = new System.Drawing.Size(155, 21);
            this.txtNic.TabIndex = 90;
            this.txtNic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNic_KeyDown);
            // 
            // lblNic
            // 
            this.lblNic.AutoSize = true;
            this.lblNic.Location = new System.Drawing.Point(228, 41);
            this.lblNic.Name = "lblNic";
            this.lblNic.Size = new System.Drawing.Size(55, 13);
            this.lblNic.TabIndex = 91;
            this.lblNic.Text = "NIC No*";
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCardType.Location = new System.Drawing.Point(103, 84);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(70, 13);
            this.lblCardType.TabIndex = 35;
            this.lblCardType.Text = "Card Type ";
            // 
            // chkAutoCompleationCardNo
            // 
            this.chkAutoCompleationCardNo.AutoSize = true;
            this.chkAutoCompleationCardNo.Checked = true;
            this.chkAutoCompleationCardNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoCompleationCardNo.Location = new System.Drawing.Point(106, 41);
            this.chkAutoCompleationCardNo.Name = "chkAutoCompleationCardNo";
            this.chkAutoCompleationCardNo.Size = new System.Drawing.Size(15, 14);
            this.chkAutoCompleationCardNo.TabIndex = 33;
            this.chkAutoCompleationCardNo.Tag = "1";
            this.chkAutoCompleationCardNo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Card Type      : ";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(126, 38);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(96, 21);
            this.txtCardNo.TabIndex = 53;
            this.txtCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNo_KeyDown);
            // 
            // lblCardNo
            // 
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.Location = new System.Drawing.Point(6, 41);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(54, 13);
            this.lblCardNo.TabIndex = 31;
            this.lblCardNo.Text = "Card No";
            // 
            // chkAutoCompleationCustomer
            // 
            this.chkAutoCompleationCustomer.AutoSize = true;
            this.chkAutoCompleationCustomer.Checked = true;
            this.chkAutoCompleationCustomer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoCompleationCustomer.Location = new System.Drawing.Point(106, 17);
            this.chkAutoCompleationCustomer.Name = "chkAutoCompleationCustomer";
            this.chkAutoCompleationCustomer.Size = new System.Drawing.Size(15, 14);
            this.chkAutoCompleationCustomer.TabIndex = 29;
            this.chkAutoCompleationCustomer.Tag = "1";
            this.chkAutoCompleationCustomer.UseVisualStyleBackColor = true;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(224, 14);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(238, 21);
            this.txtCustomerName.TabIndex = 50;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(126, 14);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(96, 21);
            this.txtCustomerCode.TabIndex = 1;
            this.txtCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerCode_KeyDown);
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Location = new System.Drawing.Point(6, 17);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(97, 13);
            this.lblCustomerCode.TabIndex = 0;
            this.lblCustomerCode.Text = "Customer Code";
            // 
            // FrmCrmLostAndRenewDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 359);
            this.Controls.Add(this.tabMain);
            this.Name = "FrmCrmLostAndRenewDetail";
            this.Text = "FrmCrmLostAndRenewDetail";
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.tabMain, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardType)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.tbpCustomerWise.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.CheckBox chkAlllocations;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridView dgvCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardMasterID;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpCustomerWise;
        private System.Windows.Forms.Panel groupBox2;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.CheckBox chkAutoCompleationCardNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.CheckBox chkAutoCompleationCustomer;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label lblCustomerCode;
        private System.Windows.Forms.CheckBox chkAutoCompleationNic;
        private System.Windows.Forms.TextBox txtNic;
        private System.Windows.Forms.Label lblNic;
        private System.Windows.Forms.Label lblNameOnCard;
        private System.Windows.Forms.Label label4;
    }
}