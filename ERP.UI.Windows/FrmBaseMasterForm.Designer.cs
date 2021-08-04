namespace ERP.UI.Windows
{
    partial class FrmBaseMasterForm
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
            this.grpButtonSet = new System.Windows.Forms.Panel();
            this.btnPrint = new Glass.GlassButton();
            this.btnView = new Glass.GlassButton();
            this.btnDelete = new Glass.GlassButton();
            this.grpButtonSet2 = new System.Windows.Forms.Panel();
            this.btnClear = new Glass.GlassButton();
            this.btnSave = new Glass.GlassButton();
            this.btnClose = new Glass.GlassButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnl_header = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.grpButtonSet.SuspendLayout();
            this.grpButtonSet2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.pnl_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpButtonSet.Controls.Add(this.btnPrint);
            this.grpButtonSet.Controls.Add(this.btnView);
            this.grpButtonSet.Controls.Add(this.btnDelete);
            this.grpButtonSet.Location = new System.Drawing.Point(2, 188);
            this.grpButtonSet.Name = "grpButtonSet";
            this.grpButtonSet.Size = new System.Drawing.Size(248, 45);
            this.grpButtonSet.TabIndex = 6;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnPrint.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Image = global::ERP.UI.Windows.Properties.Resources.printer32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(83, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ShineColor = System.Drawing.Color.Brown;
            this.btnPrint.Size = new System.Drawing.Size(82, 37);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "P&rint ";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnView.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.Black;
            this.btnView.Image = global::ERP.UI.Windows.Properties.Resources.computer_icon;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(2, 4);
            this.btnView.Name = "btnView";
            this.btnView.ShineColor = System.Drawing.Color.Brown;
            this.btnView.Size = new System.Drawing.Size(82, 37);
            this.btnView.TabIndex = 7;
            this.btnView.Text = "&View ";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Image = global::ERP.UI.Windows.Properties.Resources.delete_contact32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(164, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShineColor = System.Drawing.Color.Brown;
            this.btnDelete.Size = new System.Drawing.Size(82, 37);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpButtonSet2.Controls.Add(this.btnClear);
            this.grpButtonSet2.Controls.Add(this.btnSave);
            this.grpButtonSet2.Controls.Add(this.btnClose);
            this.grpButtonSet2.Location = new System.Drawing.Point(428, 189);
            this.grpButtonSet2.Name = "grpButtonSet2";
            this.grpButtonSet2.Size = new System.Drawing.Size(239, 44);
            this.grpButtonSet2.TabIndex = 9;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnClear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Image = global::ERP.UI.Windows.Properties.Resources.clear_icon32;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(79, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShineColor = System.Drawing.Color.Brown;
            this.btnClear.Size = new System.Drawing.Size(79, 37);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Cl&ear ";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::ERP.UI.Windows.Properties.Resources.save_icon32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShineColor = System.Drawing.Color.Brown;
            this.btnSave.Size = new System.Drawing.Size(78, 37);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Save ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::ERP.UI.Windows.Properties.Resources.Close_icon32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(157, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShineColor = System.Drawing.Color.Brown;
            this.btnClose.Size = new System.Drawing.Size(80, 37);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "&Close ";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
            this.pnl_header.Controls.Add(this.lblHeader);
            this.pnl_header.Controls.Add(this.pictureBox2);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.MaximumSize = new System.Drawing.Size(1183, 26);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(668, 26);
            this.pnl_header.TabIndex = 148;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 11.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(45, 4);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(136, 19);
            this.lblHeader.TabIndex = 145;
            this.lblHeader.Text = "PURCHASE ORDER ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::ERP.UI.Windows.Properties.Resources.Default_Image;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 144;
            this.pictureBox2.TabStop = false;
            // 
            // FrmBaseMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(668, 236);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.grpButtonSet2);
            this.Controls.Add(this.grpButtonSet);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmBaseMasterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBaseMasterForm";
            this.Load += new System.EventHandler(this.FrmBaseMasterForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBaseMasterForm_KeyDown);
            this.grpButtonSet.ResumeLayout(false);
            this.grpButtonSet2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel grpButtonSet;
        protected System.Windows.Forms.Panel grpButtonSet2;
        protected Glass.GlassButton btnPrint;
        protected Glass.GlassButton btnView;
        protected Glass.GlassButton btnClear;
        protected Glass.GlassButton btnSave;
        protected Glass.GlassButton btnClose;
        protected Glass.GlassButton btnDelete;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.PictureBox pictureBox2;



    }
}