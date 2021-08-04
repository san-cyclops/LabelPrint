namespace ERP.Report.GUI
{
    partial class FrmDobReport
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
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.rdoGender = new System.Windows.Forms.RadioButton();
            this.rdoMobile = new System.Windows.Forms.RadioButton();
            this.grpMobileNetwork = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNetwork = new System.Windows.Forms.ComboBox();
            this.rdoMonthDate = new System.Windows.Forms.RadioButton();
            this.grpGender = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.grpMonthDate = new System.Windows.Forms.Panel();
            this.cmbDate = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpMobileNetwork.SuspendLayout();
            this.grpGender.SuspendLayout();
            this.grpMonthDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(196, 245);
            this.grpButtonSet2.Size = new System.Drawing.Size(239, 46);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Location = new System.Drawing.Point(2, 245);
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
            this.groupBox1.Controls.Add(this.rdoGender);
            this.groupBox1.Controls.Add(this.rdoMobile);
            this.groupBox1.Controls.Add(this.grpMobileNetwork);
            this.groupBox1.Controls.Add(this.rdoMonthDate);
            this.groupBox1.Controls.Add(this.grpGender);
            this.groupBox1.Controls.Add(this.grpMonthDate);
            this.groupBox1.Location = new System.Drawing.Point(4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 249);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // rdoGender
            // 
            this.rdoGender.AutoSize = true;
            this.rdoGender.Location = new System.Drawing.Point(10, 170);
            this.rdoGender.Name = "rdoGender";
            this.rdoGender.Size = new System.Drawing.Size(173, 17);
            this.rdoGender.TabIndex = 6;
            this.rdoGender.TabStop = true;
            this.rdoGender.Text = "Find customers by gender";
            this.rdoGender.UseVisualStyleBackColor = true;
            this.rdoGender.CheckedChanged += new System.EventHandler(this.rdoGender_CheckedChanged);
            // 
            // rdoMobile
            // 
            this.rdoMobile.AutoSize = true;
            this.rdoMobile.Location = new System.Drawing.Point(10, 89);
            this.rdoMobile.Name = "rdoMobile";
            this.rdoMobile.Size = new System.Drawing.Size(221, 17);
            this.rdoMobile.TabIndex = 6;
            this.rdoMobile.TabStop = true;
            this.rdoMobile.Text = "Find customers by mobile network";
            this.rdoMobile.UseVisualStyleBackColor = true;
            this.rdoMobile.CheckedChanged += new System.EventHandler(this.rdoMobile_CheckedChanged);
            // 
            // grpMobileNetwork
            // 
            this.grpMobileNetwork.Controls.Add(this.label2);
            this.grpMobileNetwork.Controls.Add(this.cmbNetwork);
            this.grpMobileNetwork.Enabled = false;
            this.grpMobileNetwork.Location = new System.Drawing.Point(10, 106);
            this.grpMobileNetwork.Name = "grpMobileNetwork";
            this.grpMobileNetwork.Size = new System.Drawing.Size(409, 58);
            this.grpMobileNetwork.TabIndex = 7;
            this.grpMobileNetwork.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Network";
            // 
            // cmbNetwork
            // 
            this.cmbNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNetwork.FormattingEnabled = true;
            this.cmbNetwork.Items.AddRange(new object[] {
            "Dialog",
            "Mobitel",
            "Etisalat",
            "Hutch",
            "Airtel"});
            this.cmbNetwork.Location = new System.Drawing.Point(66, 25);
            this.cmbNetwork.Name = "cmbNetwork";
            this.cmbNetwork.Size = new System.Drawing.Size(122, 21);
            this.cmbNetwork.TabIndex = 3;
            this.cmbNetwork.SelectedIndexChanged += new System.EventHandler(this.cmbNetwork_SelectedIndexChanged);
            // 
            // rdoMonthDate
            // 
            this.rdoMonthDate.AutoSize = true;
            this.rdoMonthDate.Location = new System.Drawing.Point(10, 11);
            this.rdoMonthDate.Name = "rdoMonthDate";
            this.rdoMonthDate.Size = new System.Drawing.Size(199, 17);
            this.rdoMonthDate.TabIndex = 6;
            this.rdoMonthDate.TabStop = true;
            this.rdoMonthDate.Text = "Find customers by Month/Date";
            this.rdoMonthDate.UseVisualStyleBackColor = true;
            this.rdoMonthDate.CheckedChanged += new System.EventHandler(this.rdoMonthDate_CheckedChanged);
            // 
            // grpGender
            // 
            this.grpGender.Controls.Add(this.label4);
            this.grpGender.Controls.Add(this.cmbGender);
            this.grpGender.Enabled = false;
            this.grpGender.Location = new System.Drawing.Point(10, 186);
            this.grpGender.Name = "grpGender";
            this.grpGender.Size = new System.Drawing.Size(409, 58);
            this.grpGender.TabIndex = 8;
            this.grpGender.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Gender";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(66, 19);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(122, 21);
            this.cmbGender.TabIndex = 3;
            this.cmbGender.SelectedIndexChanged += new System.EventHandler(this.cmbGender_SelectedIndexChanged);
            // 
            // grpMonthDate
            // 
            this.grpMonthDate.Controls.Add(this.cmbDate);
            this.grpMonthDate.Controls.Add(this.lblMonth);
            this.grpMonthDate.Controls.Add(this.cmbMonth);
            this.grpMonthDate.Controls.Add(this.label1);
            this.grpMonthDate.Enabled = false;
            this.grpMonthDate.Location = new System.Drawing.Point(10, 27);
            this.grpMonthDate.Name = "grpMonthDate";
            this.grpMonthDate.Size = new System.Drawing.Size(409, 58);
            this.grpMonthDate.TabIndex = 5;
            this.grpMonthDate.TabStop = false;
            // 
            // cmbDate
            // 
            this.cmbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDate.FormattingEnabled = true;
            this.cmbDate.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbDate.Location = new System.Drawing.Point(243, 25);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Size = new System.Drawing.Size(122, 21);
            this.cmbDate.TabIndex = 4;
            this.cmbDate.SelectedIndexChanged += new System.EventHandler(this.cmbDate_SelectedIndexChanged);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(5, 28);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(41, 13);
            this.lblMonth.TabIndex = 0;
            this.lblMonth.Text = "Month";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "",
            "Jan",
            "Feb",
            "Mar ",
            "Apr ",
            "May ",
            "Jun ",
            "Jul ",
            "Aug ",
            "Sep ",
            "Oct ",
            "Nov ",
            "Dec"});
            this.cmbMonth.Location = new System.Drawing.Point(66, 25);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(122, 21);
            this.cmbMonth.TabIndex = 3;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date";
            // 
            // FrmDobReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 293);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDobReport";
            this.Text = "FrmDobReport";
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpMobileNetwork.ResumeLayout(false);
            this.grpMobileNetwork.PerformLayout();
            this.grpGender.ResumeLayout(false);
            this.grpGender.PerformLayout();
            this.grpMonthDate.ResumeLayout(false);
            this.grpMonthDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel groupBox1;
        private System.Windows.Forms.Panel grpMonthDate;
        private System.Windows.Forms.ComboBox cmbDate;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel grpGender;
        private System.Windows.Forms.RadioButton rdoGender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Panel grpMobileNetwork;
        private System.Windows.Forms.RadioButton rdoMobile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNetwork;
        private System.Windows.Forms.RadioButton rdoMonthDate;
    }
}