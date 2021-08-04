namespace ERP.UI.Windows
{
    partial class FrmItemMovementReport
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
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.ChkAutoComplteFrom = new System.Windows.Forms.CheckBox();
            this.LblSearchFrom = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.grpHeader = new System.Windows.Forms.Panel();
            this.SearchTab = new System.Windows.Forms.TabControl();
            this.Productwise = new System.Windows.Forms.TabPage();
            this.TxtSearchCodeFrom = new System.Windows.Forms.TextBox();
            this.DepatmentWise = new System.Windows.Forms.TabPage();
            this.DepartmentCode = new System.Windows.Forms.TextBox();
            this.LblDepartment = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDpt_Name = new System.Windows.Forms.TextBox();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grpHeader.SuspendLayout();
            this.SearchTab.SuspendLayout();
            this.Productwise.SuspendLayout();
            this.DepatmentWise.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpButtonSet2.Location = new System.Drawing.Point(498, 260);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpButtonSet.Location = new System.Drawing.Point(2, 260);
            // 
            // btnClear
            // 
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(281, 17);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(20, 13);
            this.lblToDate.TabIndex = 69;
            this.lblToDate.Text = "To";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(307, 11);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(145, 21);
            this.dtpToDate.TabIndex = 68;
            this.dtpToDate.Enter += new System.EventHandler(this.dtpToDate_Enter);
            this.dtpToDate.Leave += new System.EventHandler(this.dtpToDate_Leave);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(118, 11);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(147, 21);
            this.dtpFromDate.TabIndex = 67;
            this.dtpFromDate.Enter += new System.EventHandler(this.dtpFromDate_Enter);
            this.dtpFromDate.Leave += new System.EventHandler(this.dtpFromDate_Leave);
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(3, 11);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(107, 13);
            this.lblDateRange.TabIndex = 66;
            this.lblDateRange.Text = "Date Range From";
            // 
            // ChkAutoComplteFrom
            // 
            this.ChkAutoComplteFrom.AutoSize = true;
            this.ChkAutoComplteFrom.Location = new System.Drawing.Point(261, 38);
            this.ChkAutoComplteFrom.Name = "ChkAutoComplteFrom";
            this.ChkAutoComplteFrom.Size = new System.Drawing.Size(15, 14);
            this.ChkAutoComplteFrom.TabIndex = 64;
            this.ChkAutoComplteFrom.UseVisualStyleBackColor = true;
            this.ChkAutoComplteFrom.CheckedChanged += new System.EventHandler(this.ChkAutoComplteFrom_chkchanged);
            this.ChkAutoComplteFrom.Enter += new System.EventHandler(this.ChkAutoComplteFrom_Enter);
            this.ChkAutoComplteFrom.Leave += new System.EventHandler(this.ChkAllTerminals_Leave);
            // 
            // LblSearchFrom
            // 
            this.LblSearchFrom.AutoSize = true;
            this.LblSearchFrom.Location = new System.Drawing.Point(3, 38);
            this.LblSearchFrom.Name = "LblSearchFrom";
            this.LblSearchFrom.Size = new System.Drawing.Size(84, 13);
            this.LblSearchFrom.TabIndex = 63;
            this.LblSearchFrom.Text = "Product Code";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(118, 45);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(334, 21);
            this.cmbLocation.TabIndex = 61;
            this.cmbLocation.Enter += new System.EventHandler(this.cmbLocation_Enter);
            this.cmbLocation.Leave += new System.EventHandler(this.cmbLocation_Leave);
            // 
            // grpHeader
            // 
            this.grpHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpHeader.Controls.Add(this.SearchTab);
            this.grpHeader.Controls.Add(this.lblLocation);
            this.grpHeader.Controls.Add(this.cmbLocation);
            this.grpHeader.Controls.Add(this.lblToDate);
            this.grpHeader.Controls.Add(this.dtpToDate);
            this.grpHeader.Controls.Add(this.dtpFromDate);
            this.grpHeader.Controls.Add(this.lblDateRange);
            this.grpHeader.Location = new System.Drawing.Point(6, 12);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(730, 241);
            this.grpHeader.TabIndex = 153;
            // 
            // SearchTab
            // 
            this.SearchTab.Controls.Add(this.Productwise);
            this.SearchTab.Controls.Add(this.DepatmentWise);
            this.SearchTab.Location = new System.Drawing.Point(6, 83);
            this.SearchTab.Name = "SearchTab";
            this.SearchTab.SelectedIndex = 0;
            this.SearchTab.Size = new System.Drawing.Size(527, 141);
            this.SearchTab.TabIndex = 154;
            this.SearchTab.SelectedIndexChanged += new System.EventHandler(this.SearchTab_SelectedIndexChanged);
            this.SearchTab.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTab_KeyDown);
            // 
            // Productwise
            // 
            this.Productwise.BackColor = System.Drawing.Color.Gainsboro;
            this.Productwise.Controls.Add(this.TxtSearchCodeFrom);
            this.Productwise.Controls.Add(this.ChkAutoComplteFrom);
            this.Productwise.Controls.Add(this.LblSearchFrom);
            this.Productwise.Location = new System.Drawing.Point(4, 22);
            this.Productwise.Name = "Productwise";
            this.Productwise.Padding = new System.Windows.Forms.Padding(3);
            this.Productwise.Size = new System.Drawing.Size(519, 115);
            this.Productwise.TabIndex = 0;
            this.Productwise.Text = "ProductWise";
            // 
            // TxtSearchCodeFrom
            // 
            this.TxtSearchCodeFrom.Location = new System.Drawing.Point(92, 34);
            this.TxtSearchCodeFrom.Name = "TxtSearchCodeFrom";
            this.TxtSearchCodeFrom.Size = new System.Drawing.Size(163, 21);
            this.TxtSearchCodeFrom.TabIndex = 71;
            this.TxtSearchCodeFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearchCodeFrom_KeyDown);
            this.TxtSearchCodeFrom.Leave += new System.EventHandler(this.TxtSearchCode_KeyLeave);
            // 
            // DepatmentWise
            // 
            this.DepatmentWise.BackColor = System.Drawing.Color.Gainsboro;
            this.DepatmentWise.Controls.Add(this.txtDpt_Name);
            this.DepatmentWise.Controls.Add(this.label1);
            this.DepatmentWise.Controls.Add(this.DepartmentCode);
            this.DepatmentWise.Controls.Add(this.LblDepartment);
            this.DepatmentWise.Location = new System.Drawing.Point(4, 22);
            this.DepatmentWise.Name = "DepatmentWise";
            this.DepatmentWise.Padding = new System.Windows.Forms.Padding(3);
            this.DepatmentWise.Size = new System.Drawing.Size(519, 115);
            this.DepatmentWise.TabIndex = 1;
            this.DepatmentWise.Text = "Department Wise";
            // 
            // DepartmentCode
            // 
            this.DepartmentCode.Location = new System.Drawing.Point(95, 23);
            this.DepartmentCode.Name = "DepartmentCode";
            this.DepartmentCode.Size = new System.Drawing.Size(176, 21);
            this.DepartmentCode.TabIndex = 72;
            this.DepartmentCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DepartmentCode_KeyDown);
            this.DepartmentCode.Leave += new System.EventHandler(this.DepartmentCode_KeyLeave);
            // 
            // LblDepartment
            // 
            this.LblDepartment.AutoSize = true;
            this.LblDepartment.Location = new System.Drawing.Point(3, 26);
            this.LblDepartment.Name = "LblDepartment";
            this.LblDepartment.Size = new System.Drawing.Size(86, 13);
            this.LblDepartment.TabIndex = 156;
            this.LblDepartment.Text = "Department *";
            this.LblDepartment.Click += new System.EventHandler(this.LblDepartment_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(3, 45);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(54, 13);
            this.lblLocation.TabIndex = 62;
            this.lblLocation.Text = "Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 157;
            this.label1.Text = "Name";
            // 
            // txtDpt_Name
            // 
            this.txtDpt_Name.Location = new System.Drawing.Point(337, 23);
            this.txtDpt_Name.Name = "txtDpt_Name";
            this.txtDpt_Name.Size = new System.Drawing.Size(176, 21);
            this.txtDpt_Name.TabIndex = 158;
            // 
            // FrmItemMovementReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(744, 310);
            this.Controls.Add(this.grpHeader);
            this.Name = "FrmItemMovementReport";
            this.Text = "Item Movement Report";
            this.Controls.SetChildIndex(this.grpHeader, 0);
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.SearchTab.ResumeLayout(false);
            this.Productwise.ResumeLayout(false);
            this.Productwise.PerformLayout();
            this.DepatmentWise.ResumeLayout(false);
            this.DepatmentWise.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.CheckBox ChkAutoComplteFrom;
        private System.Windows.Forms.Label LblSearchFrom;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Panel grpHeader;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox TxtSearchCodeFrom;
        private System.Windows.Forms.TabControl SearchTab;
        private System.Windows.Forms.TabPage Productwise;
        private System.Windows.Forms.TabPage DepatmentWise;
        private System.Windows.Forms.Label LblDepartment;
        private System.Windows.Forms.TextBox DepartmentCode;
        private System.Windows.Forms.TextBox txtDpt_Name;
        private System.Windows.Forms.Label label1;
    }
}
