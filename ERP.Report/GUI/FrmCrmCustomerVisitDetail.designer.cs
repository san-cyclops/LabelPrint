namespace ERP.Report.GUI
{
    partial class FrmCrmCustomerVisitDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpBody = new System.Windows.Forms.Panel();
            this.grpGroupBy = new System.Windows.Forms.Panel();
            this.chkLocation = new System.Windows.Forms.CheckBox();
            this.chkVisitedMonth = new System.Windows.Forms.CheckBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.dgvCardType = new System.Windows.Forms.DataGridView();
            this.CardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CardMasterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpFieldSelection = new System.Windows.Forms.Panel();
            this.chkTotalPurchases = new System.Windows.Forms.CheckBox();
            this.rdoCustomerWise = new System.Windows.Forms.RadioButton();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.chkAlllocations = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grpBody.SuspendLayout();
            this.grpGroupBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardType)).BeginInit();
            this.grpFieldSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(332, 315);
            this.grpButtonSet2.Size = new System.Drawing.Size(239, 46);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Location = new System.Drawing.Point(2, 315);
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
            // grpBody
            // 
            this.grpBody.Controls.Add(this.grpGroupBy);
            this.grpBody.Controls.Add(this.chkSelectAll);
            this.grpBody.Controls.Add(this.dgvCardType);
            this.grpBody.Controls.Add(this.grpFieldSelection);
            this.grpBody.Controls.Add(this.rdoCustomerWise);
            this.grpBody.Controls.Add(this.prgBar);
            this.grpBody.Controls.Add(this.chkAlllocations);
            this.grpBody.Controls.Add(this.label1);
            this.grpBody.Controls.Add(this.dtpToDate);
            this.grpBody.Controls.Add(this.cmbLocation);
            this.grpBody.Controls.Add(this.lblLocation);
            this.grpBody.Controls.Add(this.dtpFromDate);
            this.grpBody.Controls.Add(this.lblDateRange);
            this.grpBody.Location = new System.Drawing.Point(4, -4);
            this.grpBody.Name = "grpBody";
            this.grpBody.Size = new System.Drawing.Size(567, 324);
            this.grpBody.TabIndex = 12;
            this.grpBody.TabStop = false;
            // 
            // grpGroupBy
            // 
            this.grpGroupBy.Controls.Add(this.chkLocation);
            this.grpGroupBy.Controls.Add(this.chkVisitedMonth);
            this.grpGroupBy.Location = new System.Drawing.Point(410, 55);
            this.grpGroupBy.Name = "grpGroupBy";
            this.grpGroupBy.Size = new System.Drawing.Size(144, 60);
            this.grpGroupBy.TabIndex = 150;
            this.grpGroupBy.TabStop = false;
            this.grpGroupBy.Text = "Group By";
            // 
            // chkLocation
            // 
            this.chkLocation.AutoSize = true;
            this.chkLocation.Location = new System.Drawing.Point(15, 41);
            this.chkLocation.Name = "chkLocation";
            this.chkLocation.Size = new System.Drawing.Size(73, 17);
            this.chkLocation.TabIndex = 138;
            this.chkLocation.Text = "Location";
            this.chkLocation.UseVisualStyleBackColor = true;
            // 
            // chkVisitedMonth
            // 
            this.chkVisitedMonth.AutoSize = true;
            this.chkVisitedMonth.Location = new System.Drawing.Point(15, 22);
            this.chkVisitedMonth.Name = "chkVisitedMonth";
            this.chkVisitedMonth.Size = new System.Drawing.Size(102, 17);
            this.chkVisitedMonth.TabIndex = 137;
            this.chkVisitedMonth.Text = "Visited Month";
            this.chkVisitedMonth.UseVisualStyleBackColor = true;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(308, 96);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(79, 17);
            this.chkSelectAll.TabIndex = 149;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // dgvCardType
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            this.dgvCardType.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCardType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CardType,
            this.Select,
            this.CardMasterID});
            this.dgvCardType.Location = new System.Drawing.Point(6, 119);
            this.dgvCardType.Name = "dgvCardType";
            this.dgvCardType.RowHeadersWidth = 5;
            this.dgvCardType.Size = new System.Drawing.Size(557, 184);
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
            // grpFieldSelection
            // 
            this.grpFieldSelection.Controls.Add(this.chkTotalPurchases);
            this.grpFieldSelection.Location = new System.Drawing.Point(410, 8);
            this.grpFieldSelection.Name = "grpFieldSelection";
            this.grpFieldSelection.Size = new System.Drawing.Size(144, 45);
            this.grpFieldSelection.TabIndex = 143;
            this.grpFieldSelection.TabStop = false;
            this.grpFieldSelection.Text = "Field Selection";
            // 
            // chkTotalPurchases
            // 
            this.chkTotalPurchases.AutoSize = true;
            this.chkTotalPurchases.Location = new System.Drawing.Point(15, 20);
            this.chkTotalPurchases.Name = "chkTotalPurchases";
            this.chkTotalPurchases.Size = new System.Drawing.Size(115, 17);
            this.chkTotalPurchases.TabIndex = 136;
            this.chkTotalPurchases.Text = "Total Purchases";
            this.chkTotalPurchases.UseVisualStyleBackColor = true;
            // 
            // rdoCustomerWise
            // 
            this.rdoCustomerWise.AutoSize = true;
            this.rdoCustomerWise.Location = new System.Drawing.Point(263, 70);
            this.rdoCustomerWise.Name = "rdoCustomerWise";
            this.rdoCustomerWise.Size = new System.Drawing.Size(112, 17);
            this.rdoCustomerWise.TabIndex = 13;
            this.rdoCustomerWise.TabStop = true;
            this.rdoCustomerWise.Text = "Customer Wise";
            this.rdoCustomerWise.UseVisualStyleBackColor = true;
            this.rdoCustomerWise.CheckedChanged += new System.EventHandler(this.rdoCustomerWise_CheckedChanged);
            // 
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(6, 308);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(557, 10);
            this.prgBar.Step = 1;
            this.prgBar.TabIndex = 142;
            // 
            // chkAlllocations
            // 
            this.chkAlllocations.AutoSize = true;
            this.chkAlllocations.Location = new System.Drawing.Point(88, 68);
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
            this.label1.Location = new System.Drawing.Point(223, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 128;
            this.label1.Text = "-";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(237, 17);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(138, 21);
            this.dtpToDate.TabIndex = 127;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(88, 43);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(287, 21);
            this.cmbLocation.TabIndex = 125;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(8, 46);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(54, 13);
            this.lblLocation.TabIndex = 126;
            this.lblLocation.Text = "Location";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(88, 17);
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
            // FrmCrmCustomerVisitDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 363);
            this.Controls.Add(this.grpBody);
            this.Name = "FrmCrmCustomerVisitDetail";
            this.Text = "FrmCrmCustomerVisitDetail";
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.grpBody, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grpBody.ResumeLayout(false);
            this.grpBody.PerformLayout();
            this.grpGroupBy.ResumeLayout(false);
            this.grpGroupBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardType)).EndInit();
            this.grpFieldSelection.ResumeLayout(false);
            this.grpFieldSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel grpBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.CheckBox chkAlllocations;
        private System.Windows.Forms.RadioButton rdoCustomerWise;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.Panel grpFieldSelection;
        private System.Windows.Forms.CheckBox chkTotalPurchases;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridView dgvCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardMasterID;
        private System.Windows.Forms.Panel grpGroupBy;
        private System.Windows.Forms.CheckBox chkVisitedMonth;
        private System.Windows.Forms.CheckBox chkLocation;
    }
}