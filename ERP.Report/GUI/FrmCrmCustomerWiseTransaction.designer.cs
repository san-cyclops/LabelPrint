namespace ERP.Report.GUI
{
    partial class FrmCrmCustomerWiseTransaction
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
            this.rdoPurchase = new System.Windows.Forms.RadioButton();
            this.rdoPointsRedeem = new System.Windows.Forms.RadioButton();
            this.rdoPointsEarn = new System.Windows.Forms.RadioButton();
            this.grpPointRedeem = new System.Windows.Forms.Panel();
            this.txtRedeemPointsGraterThan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpRedeemTo = new System.Windows.Forms.DateTimePicker();
            this.dtpRedeemFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpPointPurchase = new System.Windows.Forms.Panel();
            this.txtPurchasePointsGraterThan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpPurchaseTo = new System.Windows.Forms.DateTimePicker();
            this.dtpPurchaseFrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grpPointsEarn = new System.Windows.Forms.Panel();
            this.txtEarnPointsGraterThan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEarnTo = new System.Windows.Forms.DateTimePicker();
            this.dtpEarnFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpPointRedeem.SuspendLayout();
            this.grpPointPurchase.SuspendLayout();
            this.grpPointsEarn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(222, 324);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Location = new System.Drawing.Point(2, 324);
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoPurchase);
            this.groupBox1.Controls.Add(this.rdoPointsRedeem);
            this.groupBox1.Controls.Add(this.rdoPointsEarn);
            this.groupBox1.Controls.Add(this.grpPointRedeem);
            this.groupBox1.Controls.Add(this.grpPointPurchase);
            this.groupBox1.Controls.Add(this.grpPointsEarn);
            this.groupBox1.Location = new System.Drawing.Point(5, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 330);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // rdoPurchase
            // 
            this.rdoPurchase.AutoSize = true;
            this.rdoPurchase.Location = new System.Drawing.Point(6, 221);
            this.rdoPurchase.Name = "rdoPurchase";
            this.rdoPurchase.Size = new System.Drawing.Size(168, 17);
            this.rdoPurchase.TabIndex = 6;
            this.rdoPurchase.TabStop = true;
            this.rdoPurchase.Text = "Customer Wise Purchase";
            this.rdoPurchase.UseVisualStyleBackColor = true;
            this.rdoPurchase.CheckedChanged += new System.EventHandler(this.rdoPointsPurchase_CheckedChanged);
            // 
            // rdoPointsRedeem
            // 
            this.rdoPointsRedeem.AutoSize = true;
            this.rdoPointsRedeem.Location = new System.Drawing.Point(10, 117);
            this.rdoPointsRedeem.Name = "rdoPointsRedeem";
            this.rdoPointsRedeem.Size = new System.Drawing.Size(201, 17);
            this.rdoPointsRedeem.TabIndex = 6;
            this.rdoPointsRedeem.TabStop = true;
            this.rdoPointsRedeem.Text = "Customer Wise Points Redeem";
            this.rdoPointsRedeem.UseVisualStyleBackColor = true;
            this.rdoPointsRedeem.CheckedChanged += new System.EventHandler(this.rdoPointsRedeem_CheckedChanged);
            // 
            // rdoPointsEarn
            // 
            this.rdoPointsEarn.AutoSize = true;
            this.rdoPointsEarn.Location = new System.Drawing.Point(10, 11);
            this.rdoPointsEarn.Name = "rdoPointsEarn";
            this.rdoPointsEarn.Size = new System.Drawing.Size(180, 17);
            this.rdoPointsEarn.TabIndex = 6;
            this.rdoPointsEarn.TabStop = true;
            this.rdoPointsEarn.Text = "Customer Wise Points Earn";
            this.rdoPointsEarn.UseVisualStyleBackColor = true;
            this.rdoPointsEarn.CheckedChanged += new System.EventHandler(this.rdoPointsEarn_CheckedChanged);
            // 
            // grpPointRedeem
            // 
            this.grpPointRedeem.Controls.Add(this.txtRedeemPointsGraterThan);
            this.grpPointRedeem.Controls.Add(this.label2);
            this.grpPointRedeem.Controls.Add(this.dtpRedeemTo);
            this.grpPointRedeem.Controls.Add(this.dtpRedeemFrom);
            this.grpPointRedeem.Controls.Add(this.label5);
            this.grpPointRedeem.Controls.Add(this.label6);
            this.grpPointRedeem.Enabled = false;
            this.grpPointRedeem.Location = new System.Drawing.Point(10, 131);
            this.grpPointRedeem.Name = "grpPointRedeem";
            this.grpPointRedeem.Size = new System.Drawing.Size(434, 84);
            this.grpPointRedeem.TabIndex = 133;
            this.grpPointRedeem.TabStop = false;
            // 
            // txtRedeemPointsGraterThan
            // 
            this.txtRedeemPointsGraterThan.Location = new System.Drawing.Point(141, 50);
            this.txtRedeemPointsGraterThan.Name = "txtRedeemPointsGraterThan";
            this.txtRedeemPointsGraterThan.Size = new System.Drawing.Size(133, 21);
            this.txtRedeemPointsGraterThan.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 132;
            this.label2.Text = "-";
            // 
            // dtpRedeemTo
            // 
            this.dtpRedeemTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRedeemTo.Location = new System.Drawing.Point(290, 19);
            this.dtpRedeemTo.Name = "dtpRedeemTo";
            this.dtpRedeemTo.Size = new System.Drawing.Size(133, 21);
            this.dtpRedeemTo.TabIndex = 131;
            // 
            // dtpRedeemFrom
            // 
            this.dtpRedeemFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRedeemFrom.Location = new System.Drawing.Point(141, 19);
            this.dtpRedeemFrom.Name = "dtpRedeemFrom";
            this.dtpRedeemFrom.Size = new System.Drawing.Size(133, 21);
            this.dtpRedeemFrom.TabIndex = 130;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 129;
            this.label5.Text = "Date Range";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Points Grater Than";
            // 
            // grpPointPurchase
            // 
            this.grpPointPurchase.Controls.Add(this.txtPurchasePointsGraterThan);
            this.grpPointPurchase.Controls.Add(this.label4);
            this.grpPointPurchase.Controls.Add(this.dtpPurchaseTo);
            this.grpPointPurchase.Controls.Add(this.dtpPurchaseFrom);
            this.grpPointPurchase.Controls.Add(this.label7);
            this.grpPointPurchase.Controls.Add(this.label8);
            this.grpPointPurchase.Enabled = false;
            this.grpPointPurchase.Location = new System.Drawing.Point(10, 236);
            this.grpPointPurchase.Name = "grpPointPurchase";
            this.grpPointPurchase.Size = new System.Drawing.Size(434, 82);
            this.grpPointPurchase.TabIndex = 133;
            this.grpPointPurchase.TabStop = false;
            // 
            // txtPurchasePointsGraterThan
            // 
            this.txtPurchasePointsGraterThan.Location = new System.Drawing.Point(141, 50);
            this.txtPurchasePointsGraterThan.Name = "txtPurchasePointsGraterThan";
            this.txtPurchasePointsGraterThan.Size = new System.Drawing.Size(133, 21);
            this.txtPurchasePointsGraterThan.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 132;
            this.label4.Text = "-";
            // 
            // dtpPurchaseTo
            // 
            this.dtpPurchaseTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseTo.Location = new System.Drawing.Point(290, 19);
            this.dtpPurchaseTo.Name = "dtpPurchaseTo";
            this.dtpPurchaseTo.Size = new System.Drawing.Size(133, 21);
            this.dtpPurchaseTo.TabIndex = 131;
            // 
            // dtpPurchaseFrom
            // 
            this.dtpPurchaseFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseFrom.Location = new System.Drawing.Point(141, 19);
            this.dtpPurchaseFrom.Name = "dtpPurchaseFrom";
            this.dtpPurchaseFrom.Size = new System.Drawing.Size(133, 21);
            this.dtpPurchaseFrom.TabIndex = 130;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 129;
            this.label7.Text = "Date Range";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Points Grater Than";
            // 
            // grpPointsEarn
            // 
            this.grpPointsEarn.Controls.Add(this.txtEarnPointsGraterThan);
            this.grpPointsEarn.Controls.Add(this.label3);
            this.grpPointsEarn.Controls.Add(this.dtpEarnTo);
            this.grpPointsEarn.Controls.Add(this.dtpEarnFrom);
            this.grpPointsEarn.Controls.Add(this.label1);
            this.grpPointsEarn.Controls.Add(this.lblMonth);
            this.grpPointsEarn.Enabled = false;
            this.grpPointsEarn.Location = new System.Drawing.Point(10, 27);
            this.grpPointsEarn.Name = "grpPointsEarn";
            this.grpPointsEarn.Size = new System.Drawing.Size(434, 82);
            this.grpPointsEarn.TabIndex = 5;
            this.grpPointsEarn.TabStop = false;
            // 
            // txtEarnPointsGraterThan
            // 
            this.txtEarnPointsGraterThan.Location = new System.Drawing.Point(141, 50);
            this.txtEarnPointsGraterThan.Name = "txtEarnPointsGraterThan";
            this.txtEarnPointsGraterThan.Size = new System.Drawing.Size(133, 21);
            this.txtEarnPointsGraterThan.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 132;
            this.label3.Text = "-";
            // 
            // dtpEarnTo
            // 
            this.dtpEarnTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEarnTo.Location = new System.Drawing.Point(290, 19);
            this.dtpEarnTo.Name = "dtpEarnTo";
            this.dtpEarnTo.Size = new System.Drawing.Size(133, 21);
            this.dtpEarnTo.TabIndex = 131;
            // 
            // dtpEarnFrom
            // 
            this.dtpEarnFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEarnFrom.Location = new System.Drawing.Point(141, 19);
            this.dtpEarnFrom.Name = "dtpEarnFrom";
            this.dtpEarnFrom.Size = new System.Drawing.Size(133, 21);
            this.dtpEarnFrom.TabIndex = 130;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 129;
            this.label1.Text = "Date Range";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(16, 53);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(114, 13);
            this.lblMonth.TabIndex = 0;
            this.lblMonth.Text = "Points Grater Than";
            // 
            // FrmCrmCustomerWiseTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 372);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCrmCustomerWiseTransaction";
            this.Text = "FrmCrmCustomerWiseTransaction";
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpPointRedeem.ResumeLayout(false);
            this.grpPointRedeem.PerformLayout();
            this.grpPointPurchase.ResumeLayout(false);
            this.grpPointPurchase.PerformLayout();
            this.grpPointsEarn.ResumeLayout(false);
            this.grpPointsEarn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel groupBox1;
        private System.Windows.Forms.RadioButton rdoPurchase;
        private System.Windows.Forms.RadioButton rdoPointsRedeem;
        private System.Windows.Forms.RadioButton rdoPointsEarn;
        private System.Windows.Forms.Panel grpPointsEarn;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEarnTo;
        private System.Windows.Forms.DateTimePicker dtpEarnFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEarnPointsGraterThan;
        private System.Windows.Forms.Panel grpPointPurchase;
        private System.Windows.Forms.TextBox txtPurchasePointsGraterThan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpPurchaseTo;
        private System.Windows.Forms.DateTimePicker dtpPurchaseFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel grpPointRedeem;
        private System.Windows.Forms.TextBox txtRedeemPointsGraterThan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpRedeemTo;
        private System.Windows.Forms.DateTimePicker dtpRedeemFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}