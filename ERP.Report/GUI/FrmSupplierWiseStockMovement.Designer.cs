namespace ERP.Report.GUI
{
    partial class FrmSupplierWiseStockMovement
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.chkAllSup = new System.Windows.Forms.CheckBox();
            this.rbnDeptWise = new System.Windows.Forms.RadioButton();
            this.rbnSupplierWise = new System.Windows.Forms.RadioButton();
            this.chkAutoCompleationSupplier = new System.Windows.Forms.CheckBox();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(333, 170);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Location = new System.Drawing.Point(2, 170);
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 132;
            this.label1.Text = "-";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(235, 26);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(122, 21);
            this.dtpToDate.TabIndex = 131;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(104, 26);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(110, 21);
            this.dtpFromDate.TabIndex = 130;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(9, 29);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(74, 13);
            this.lblDateRange.TabIndex = 129;
            this.lblDateRange.Text = "Date Range";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 133;
            this.label2.Text = "Supplier";
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Location = new System.Drawing.Point(104, 58);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(110, 21);
            this.txtSupplierCode.TabIndex = 134;
            this.txtSupplierCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierCode_KeyDown);
            this.txtSupplierCode.Leave += new System.EventHandler(this.txtSupplierCode_Leave);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(216, 58);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(347, 21);
            this.txtSupplierName.TabIndex = 135;
            this.txtSupplierName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierName_KeyDown);
            this.txtSupplierName.Leave += new System.EventHandler(this.txtSupplierName_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAllSup);
            this.groupBox1.Controls.Add(this.rbnDeptWise);
            this.groupBox1.Controls.Add(this.rbnSupplierWise);
            this.groupBox1.Controls.Add(this.chkAutoCompleationSupplier);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.txtSupplierName);
            this.groupBox1.Controls.Add(this.lblDateRange);
            this.groupBox1.Controls.Add(this.txtSupplierCode);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 163);
            this.groupBox1.TabIndex = 136;
            // 
            // chkAllSup
            // 
            this.chkAllSup.AutoSize = true;
            this.chkAllSup.Location = new System.Drawing.Point(104, 97);
            this.chkAllSup.Name = "chkAllSup";
            this.chkAllSup.Size = new System.Drawing.Size(91, 17);
            this.chkAllSup.TabIndex = 140;
            this.chkAllSup.Tag = "1";
            this.chkAllSup.Text = "All Supplier";
            this.chkAllSup.UseVisualStyleBackColor = true;
            this.chkAllSup.CheckedChanged += new System.EventHandler(this.chkAllSup_CheckedChanged);
            // 
            // rbnDeptWise
            // 
            this.rbnDeptWise.AutoSize = true;
            this.rbnDeptWise.Location = new System.Drawing.Point(235, 126);
            this.rbnDeptWise.Name = "rbnDeptWise";
            this.rbnDeptWise.Size = new System.Drawing.Size(124, 17);
            this.rbnDeptWise.TabIndex = 139;
            this.rbnDeptWise.TabStop = true;
            this.rbnDeptWise.Text = "Department Wise";
            this.rbnDeptWise.UseVisualStyleBackColor = true;
            // 
            // rbnSupplierWise
            // 
            this.rbnSupplierWise.AutoSize = true;
            this.rbnSupplierWise.Checked = true;
            this.rbnSupplierWise.Location = new System.Drawing.Point(104, 126);
            this.rbnSupplierWise.Name = "rbnSupplierWise";
            this.rbnSupplierWise.Size = new System.Drawing.Size(103, 17);
            this.rbnSupplierWise.TabIndex = 138;
            this.rbnSupplierWise.TabStop = true;
            this.rbnSupplierWise.Text = "Supplier Wise";
            this.rbnSupplierWise.UseVisualStyleBackColor = true;
            // 
            // chkAutoCompleationSupplier
            // 
            this.chkAutoCompleationSupplier.AutoSize = true;
            this.chkAutoCompleationSupplier.Checked = true;
            this.chkAutoCompleationSupplier.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoCompleationSupplier.Location = new System.Drawing.Point(87, 61);
            this.chkAutoCompleationSupplier.Name = "chkAutoCompleationSupplier";
            this.chkAutoCompleationSupplier.Size = new System.Drawing.Size(15, 14);
            this.chkAutoCompleationSupplier.TabIndex = 137;
            this.chkAutoCompleationSupplier.Tag = "1";
            this.chkAutoCompleationSupplier.UseVisualStyleBackColor = true;
            this.chkAutoCompleationSupplier.CheckedChanged += new System.EventHandler(this.chkAutoCompleationSupplier_CheckedChanged);
            // 
            // FrmSupplierWiseStockMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 208);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSupplierWiseStockMovement";
            this.Text = "FrmSupplierWiseStockMovement";
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Panel groupBox1;
        private System.Windows.Forms.CheckBox chkAutoCompleationSupplier;
        private System.Windows.Forms.RadioButton rbnDeptWise;
        private System.Windows.Forms.RadioButton rbnSupplierWise;
        private System.Windows.Forms.CheckBox chkAllSup;
    }
}