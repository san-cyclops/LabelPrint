namespace ERP.DTS
{
    partial class frmDTS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDTS));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnUp = new System.Windows.Forms.Button();
            this.chkAutoCompleteLocationCode = new System.Windows.Forms.CheckBox();
            this.lblLocationCode = new System.Windows.Forms.Label();
            this.lblLocationName = new System.Windows.Forms.Label();
            this.txtLocationName = new System.Windows.Forms.TextBox();
            this.txtLocationCode = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblConnection = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbxCompanyImage = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblLocaid = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCompanyImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(149, 472);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(87, 27);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(119)))), ((int)(((byte)(190)))));
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.ForeColor = System.Drawing.Color.White;
            this.btnUp.Location = new System.Drawing.Point(682, 220);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(61, 73);
            this.btnUp.TabIndex = 8;
            this.btnUp.Text = "Upload";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Visible = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // chkAutoCompleteLocationCode
            // 
            this.chkAutoCompleteLocationCode.AutoSize = true;
            this.chkAutoCompleteLocationCode.Checked = true;
            this.chkAutoCompleteLocationCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoCompleteLocationCode.Location = new System.Drawing.Point(22, 446);
            this.chkAutoCompleteLocationCode.Name = "chkAutoCompleteLocationCode";
            this.chkAutoCompleteLocationCode.Size = new System.Drawing.Size(15, 14);
            this.chkAutoCompleteLocationCode.TabIndex = 36;
            this.chkAutoCompleteLocationCode.Tag = "1";
            this.chkAutoCompleteLocationCode.UseVisualStyleBackColor = true;
            this.chkAutoCompleteLocationCode.Visible = false;
            // 
            // lblLocationCode
            // 
            this.lblLocationCode.AutoSize = true;
            this.lblLocationCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationCode.Location = new System.Drawing.Point(37, 423);
            this.lblLocationCode.Name = "lblLocationCode";
            this.lblLocationCode.Size = new System.Drawing.Size(95, 13);
            this.lblLocationCode.TabIndex = 34;
            this.lblLocationCode.Text = "Location Code*";
            this.lblLocationCode.Visible = false;
            // 
            // lblLocationName
            // 
            this.lblLocationName.AutoSize = true;
            this.lblLocationName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationName.Location = new System.Drawing.Point(194, 423);
            this.lblLocationName.Name = "lblLocationName";
            this.lblLocationName.Size = new System.Drawing.Size(98, 13);
            this.lblLocationName.TabIndex = 35;
            this.lblLocationName.Text = "Location Name*";
            this.lblLocationName.Visible = false;
            // 
            // txtLocationName
            // 
            this.txtLocationName.Location = new System.Drawing.Point(197, 440);
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Size = new System.Drawing.Size(251, 20);
            this.txtLocationName.TabIndex = 38;
            this.txtLocationName.Visible = false;
            this.txtLocationName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocationName_KeyDown);
            this.txtLocationName.Leave += new System.EventHandler(this.txtLocationName_Leave);
            // 
            // txtLocationCode
            // 
            this.txtLocationCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocationCode.Location = new System.Drawing.Point(41, 440);
            this.txtLocationCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLocationCode.MaxLength = 25;
            this.txtLocationCode.Name = "txtLocationCode";
            this.txtLocationCode.Size = new System.Drawing.Size(154, 21);
            this.txtLocationCode.TabIndex = 37;
            this.txtLocationCode.Visible = false;
            this.txtLocationCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocationCode_KeyDown);
            this.txtLocationCode.Leave += new System.EventHandler(this.txtLocationCode_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(45, 32);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(33, 25);
            this.lblStatus.TabIndex = 40;
            this.lblStatus.Text = "...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(726, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.lblConnection.ForeColor = System.Drawing.Color.Coral;
            this.lblConnection.Location = new System.Drawing.Point(44, 134);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(38, 31);
            this.lblConnection.TabIndex = 42;
            this.lblConnection.Text = "...";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(117)))), ((int)(((byte)(154)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 31);
            this.panel1.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Smart POS DTS";
            // 
            // pbxCompanyImage
            // 
            this.pbxCompanyImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxCompanyImage.Image = ((System.Drawing.Image)(resources.GetObject("pbxCompanyImage.Image")));
            this.pbxCompanyImage.Location = new System.Drawing.Point(-1, 186);
            this.pbxCompanyImage.Name = "pbxCompanyImage";
            this.pbxCompanyImage.Size = new System.Drawing.Size(169, 119);
            this.pbxCompanyImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCompanyImage.TabIndex = 70;
            this.pbxCompanyImage.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(174, 186);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(169, 119);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 71;
            this.pictureBox2.TabStop = false;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblMsg.Location = new System.Drawing.Point(376, 262);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(21, 20);
            this.lblMsg.TabIndex = 72;
            this.lblMsg.Text = "...";
            // 
            // lblLocaid
            // 
            this.lblLocaid.AutoSize = true;
            this.lblLocaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocaid.Location = new System.Drawing.Point(664, 32);
            this.lblLocaid.Name = "lblLocaid";
            this.lblLocaid.Size = new System.Drawing.Size(33, 25);
            this.lblLocaid.TabIndex = 73;
            this.lblLocaid.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(564, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 74;
            this.label3.Text = "Locatoin ID";
            // 
            // frmDTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 305);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLocaid);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pbxCompanyImage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtLocationName);
            this.Controls.Add(this.txtLocationCode);
            this.Controls.Add(this.chkAutoCompleteLocationCode);
            this.Controls.Add(this.lblLocationCode);
            this.Controls.Add(this.lblLocationName);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDTS";
            this.ShowInTaskbar = false;
            this.Text = "DTS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDTS_FormClosing);
            this.Load += new System.EventHandler(this.frmDTS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCompanyImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.CheckBox chkAutoCompleteLocationCode;
        private System.Windows.Forms.Label lblLocationCode;
        private System.Windows.Forms.Label lblLocationName;
        private System.Windows.Forms.TextBox txtLocationName;
        private System.Windows.Forms.TextBox txtLocationCode;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbxCompanyImage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblLocaid;
        private System.Windows.Forms.Label label3;
    }
}

