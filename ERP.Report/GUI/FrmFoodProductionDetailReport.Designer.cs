namespace ERP.UI.Windows
{
    partial class FrmFoodProductionDetailReport
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
            this.lblIngredientCode = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.grpHeader = new System.Windows.Forms.Panel();
            this.txtIngredientCode = new System.Windows.Forms.TextBox();
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
            this.grpButtonSet2.Location = new System.Drawing.Point(392, 167);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpButtonSet.Location = new System.Drawing.Point(2, 167);
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
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(263, 69);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(20, 13);
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
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(130, 65);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(117, 21);
            this.dtpFromDate.TabIndex = 67;
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
            // lblIngredientCode
            // 
            this.lblIngredientCode.AutoSize = true;
            this.lblIngredientCode.Location = new System.Drawing.Point(7, 41);
            this.lblIngredientCode.Name = "lblIngredientCode";
            this.lblIngredientCode.Size = new System.Drawing.Size(100, 13);
            this.lblIngredientCode.TabIndex = 63;
            this.lblIngredientCode.Text = "Ingredient Code";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(130, 10);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(287, 21);
            this.cmbLocation.TabIndex = 61;
            // 
            // grpHeader
            // 
            this.grpHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpHeader.Controls.Add(this.txtIngredientCode);
            this.grpHeader.Controls.Add(this.lblLocation);
            this.grpHeader.Controls.Add(this.cmbLocation);
            this.grpHeader.Controls.Add(this.ChkAllLocations);
            this.grpHeader.Controls.Add(this.lblIngredientCode);
            this.grpHeader.Controls.Add(this.lblToDate);
            this.grpHeader.Controls.Add(this.dtpToDate);
            this.grpHeader.Controls.Add(this.dtpFromDate);
            this.grpHeader.Controls.Add(this.lblDateRange);
            this.grpHeader.Location = new System.Drawing.Point(4, 8);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(627, 152);
            this.grpHeader.TabIndex = 153;
            // 
            // txtIngredientCode
            // 
            this.txtIngredientCode.Location = new System.Drawing.Point(130, 33);
            this.txtIngredientCode.Name = "txtIngredientCode";
            this.txtIngredientCode.Size = new System.Drawing.Size(287, 21);
            this.txtIngredientCode.TabIndex = 71;
            this.txtIngredientCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIngredientCode_KeyDown);
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
            // FrmFoodProductionDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(633, 217);
            this.Controls.Add(this.grpHeader);
            this.Name = "FrmFoodProductionDetailReport";
            this.Text = "Food Costing Report";
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
        private System.Windows.Forms.Label lblIngredientCode;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.CheckBox ChkAllLocations;
        private System.Windows.Forms.Panel grpHeader;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtIngredientCode;
    }
}
