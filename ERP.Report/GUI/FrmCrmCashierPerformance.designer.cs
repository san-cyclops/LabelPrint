﻿namespace ERP.Report.GUI
{
    partial class FrmCrmCashierPerformance
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
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.chkAlllocations = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.dgvCardType = new System.Windows.Forms.DataGridView();
            this.CardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CardMasterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardType)).BeginInit();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(273, 305);
            this.grpButtonSet2.Size = new System.Drawing.Size(239, 46);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Location = new System.Drawing.Point(2, 305);
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
            this.groupBox1.Controls.Add(this.prgBar);
            this.groupBox1.Controls.Add(this.chkAlllocations);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.cmbLocation);
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.lblDateRange);
            this.groupBox1.Location = new System.Drawing.Point(4, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 314);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(3, 298);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(500, 10);
            this.prgBar.Step = 1;
            this.prgBar.TabIndex = 142;
            // 
            // chkAlllocations
            // 
            this.chkAlllocations.AutoSize = true;
            this.chkAlllocations.Location = new System.Drawing.Point(330, 51);
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
            this.label1.Location = new System.Drawing.Point(239, 23);
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
            this.cmbLocation.Location = new System.Drawing.Point(85, 47);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(239, 21);
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
            this.dtpFromDate.Location = new System.Drawing.Point(85, 17);
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
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            this.dgvCardType.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCardType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CardType,
            this.Select,
            this.CardMasterID});
            this.dgvCardType.Location = new System.Drawing.Point(6, 98);
            this.dgvCardType.Name = "dgvCardType";
            this.dgvCardType.RowHeadersWidth = 5;
            this.dgvCardType.Size = new System.Drawing.Size(496, 196);
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
            // FrmCrmCashierPerformance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 353);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCrmCashierPerformance";
            this.Text = "FrmCrmCashierPerformance";
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardType)).EndInit();
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
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridView dgvCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardMasterID;
    }
}