namespace ERP.UI.Windows
{
    partial class FrmPosSalesReports
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
            this.ChkAllLocations = new System.Windows.Forms.CheckBox();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.cmbTerminal = new System.Windows.Forms.ComboBox();
            this.ChkAllTerminals = new System.Windows.Forms.CheckBox();
            this.lblTerminal = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.grpHeader = new System.Windows.Forms.Panel();
            this.lblLocation = new System.Windows.Forms.Label();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grpHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpButtonSet2.Location = new System.Drawing.Point(341, 178);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpButtonSet.Location = new System.Drawing.Point(2, 178);
            // 
            // btnClear
            // 
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // ChkAllLocations
            // 
            this.ChkAllLocations.AutoSize = true;
            this.ChkAllLocations.Location = new System.Drawing.Point(429, 12);
            this.ChkAllLocations.Name = "ChkAllLocations";
            this.ChkAllLocations.Size = new System.Drawing.Size(97, 17);
            this.ChkAllLocations.TabIndex = 70;
            this.ChkAllLocations.Text = "All Locations";
            this.ChkAllLocations.UseVisualStyleBackColor = true;
            this.ChkAllLocations.CheckedChanged += new System.EventHandler(this.ChkAllLocations_CheckedChanged);
            this.ChkAllLocations.Enter += new System.EventHandler(this.ChkAllLocations_Enter);
            this.ChkAllLocations.Leave += new System.EventHandler(this.ChkAllLocations_Leave);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(263, 69);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(21, 13);
            this.lblToDate.TabIndex = 69;
            this.lblToDate.Text = "To";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(300, 65);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(117, 21);
            this.dtpToDate.TabIndex = 68;
            this.dtpToDate.Enter += new System.EventHandler(this.dtpToDate_Enter);
            this.dtpToDate.Leave += new System.EventHandler(this.dtpToDate_Leave);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(130, 65);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(117, 21);
            this.dtpFromDate.TabIndex = 67;
            this.dtpFromDate.Enter += new System.EventHandler(this.dtpFromDate_Enter);
            this.dtpFromDate.Leave += new System.EventHandler(this.dtpFromDate_Leave);
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(7, 69);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(107, 13);
            this.lblDateRange.TabIndex = 66;
            this.lblDateRange.Text = "Date Range From";
            // 
            // cmbTerminal
            // 
            this.cmbTerminal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerminal.FormattingEnabled = true;
            this.cmbTerminal.Items.AddRange(new object[] {
            "Terminal 01",
            "Terminal 02",
            "Terminal 03",
            "Terminal 04",
            "Terminal 05",
            "Terminal 06",
            "Terminal 07",
            "Terminal 08",
            "Terminal 09",
            "Terminal 10",
            "Terminal 11",
            "Terminal 12",
            "Terminal 13",
            "Terminal 14",
            "Terminal 15",
            "Terminal 16",
            "Terminal 17",
            "Terminal 18",
            "Terminal 19",
            "Terminal 20"});
            this.cmbTerminal.Location = new System.Drawing.Point(130, 38);
            this.cmbTerminal.Name = "cmbTerminal";
            this.cmbTerminal.Size = new System.Drawing.Size(287, 21);
            this.cmbTerminal.TabIndex = 65;
            this.cmbTerminal.Enter += new System.EventHandler(this.cmbTerminal_Enter);
            this.cmbTerminal.Leave += new System.EventHandler(this.cmbTerminal_Leave);
            // 
            // ChkAllTerminals
            // 
            this.ChkAllTerminals.AutoSize = true;
            this.ChkAllTerminals.Location = new System.Drawing.Point(429, 40);
            this.ChkAllTerminals.Name = "ChkAllTerminals";
            this.ChkAllTerminals.Size = new System.Drawing.Size(100, 17);
            this.ChkAllTerminals.TabIndex = 64;
            this.ChkAllTerminals.Text = "All Terminals";
            this.ChkAllTerminals.UseVisualStyleBackColor = true;
            this.ChkAllTerminals.CheckedChanged += new System.EventHandler(this.ChkAllTerminals_CheckedChanged);
            this.ChkAllTerminals.Enter += new System.EventHandler(this.ChkAllTerminals_Enter);
            this.ChkAllTerminals.Leave += new System.EventHandler(this.ChkAllTerminals_Leave);
            // 
            // lblTerminal
            // 
            this.lblTerminal.AutoSize = true;
            this.lblTerminal.Location = new System.Drawing.Point(7, 41);
            this.lblTerminal.Name = "lblTerminal";
            this.lblTerminal.Size = new System.Drawing.Size(57, 13);
            this.lblTerminal.TabIndex = 63;
            this.lblTerminal.Text = "Terminal";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(130, 10);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(287, 21);
            this.cmbLocation.TabIndex = 61;
            this.cmbLocation.Enter += new System.EventHandler(this.cmbLocation_Enter);
            this.cmbLocation.Leave += new System.EventHandler(this.cmbLocation_Leave);
            // 
            // grpHeader
            // 
            this.grpHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpHeader.Controls.Add(this.lblLocation);
            this.grpHeader.Controls.Add(this.cmbLocation);
            this.grpHeader.Controls.Add(this.ChkAllLocations);
            this.grpHeader.Controls.Add(this.lblTerminal);
            this.grpHeader.Controls.Add(this.lblToDate);
            this.grpHeader.Controls.Add(this.ChkAllTerminals);
            this.grpHeader.Controls.Add(this.dtpToDate);
            this.grpHeader.Controls.Add(this.cmbTerminal);
            this.grpHeader.Controls.Add(this.dtpFromDate);
            this.grpHeader.Controls.Add(this.lblDateRange);
            this.grpHeader.Location = new System.Drawing.Point(4, 8);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(572, 152);
            this.grpHeader.TabIndex = 153;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(7, 12);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(54, 13);
            this.lblLocation.TabIndex = 62;
            this.lblLocation.Text = "Location";
            // 
            // FrmPosSalesReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(582, 228);
            this.Controls.Add(this.grpHeader);
            this.Name = "FrmPosSalesReports";
            this.Text = "Sales Summary";
            this.Load += new System.EventHandler(this.FrmPosSalesReports_Load);
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.grpHeader, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.ComboBox cmbTerminal;
        private System.Windows.Forms.CheckBox ChkAllTerminals;
        private System.Windows.Forms.Label lblTerminal;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.CheckBox ChkAllLocations;
        private System.Windows.Forms.Panel grpHeader;
        private System.Windows.Forms.Label lblLocation;
    }
}
