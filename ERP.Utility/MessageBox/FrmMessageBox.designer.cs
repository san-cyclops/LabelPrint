namespace ERP.Utility
{
    partial class FrmMessageBox
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
            this.lblTxtMessage = new System.Windows.Forms.Label();
            this.btnYes = new Glass.GlassButton();
            this.btnCancel = new Glass.GlassButton();
            this.btnOk = new Glass.GlassButton();
            this.picBoxMessageBox = new System.Windows.Forms.PictureBox();
            this.btnNo = new Glass.GlassButton();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMessageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTxtMessage
            // 
            this.lblTxtMessage.AutoSize = true;
            this.lblTxtMessage.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtMessage.Location = new System.Drawing.Point(10, 66);
            this.lblTxtMessage.Name = "lblTxtMessage";
            this.lblTxtMessage.Size = new System.Drawing.Size(99, 16);
            this.lblTxtMessage.TabIndex = 1;
            this.lblTxtMessage.Text = "Message Text";
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.SkyBlue;
            this.btnYes.FadeOnFocus = true;
            this.btnYes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.ForeColor = System.Drawing.Color.Black;
            this.btnYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYes.Location = new System.Drawing.Point(236, 113);
            this.btnYes.Name = "btnYes";
            this.btnYes.ShineColor = System.Drawing.Color.Brown;
            this.btnYes.Size = new System.Drawing.Size(87, 32);
            this.btnYes.TabIndex = 8;
            this.btnYes.Text = "&Yes ";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.SkyBlue;
            this.btnCancel.FadeOnFocus = true;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(324, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShineColor = System.Drawing.Color.Brown;
            this.btnCancel.Size = new System.Drawing.Size(87, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.SkyBlue;
            this.btnOk.FadeOnFocus = true;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(237, 112);
            this.btnOk.Name = "btnOk";
            this.btnOk.ShineColor = System.Drawing.Color.Brown;
            this.btnOk.Size = new System.Drawing.Size(87, 32);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "&Ok    ";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // picBoxMessageBox
            // 
            this.picBoxMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBoxMessageBox.Location = new System.Drawing.Point(-3, -2);
            this.picBoxMessageBox.Name = "picBoxMessageBox";
            this.picBoxMessageBox.Size = new System.Drawing.Size(429, 65);
            this.picBoxMessageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxMessageBox.TabIndex = 0;
            this.picBoxMessageBox.TabStop = false;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.SkyBlue;
            this.btnNo.FadeOnFocus = true;
            this.btnNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.ForeColor = System.Drawing.Color.Black;
            this.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNo.Location = new System.Drawing.Point(324, 113);
            this.btnNo.Name = "btnNo";
            this.btnNo.ShineColor = System.Drawing.Color.Brown;
            this.btnNo.Size = new System.Drawing.Size(87, 32);
            this.btnNo.TabIndex = 9;
            this.btnNo.Text = "&No";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // FrmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(414, 149);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.picBoxMessageBox);
            this.Controls.Add(this.lblTxtMessage);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message Text";
            this.Load += new System.EventHandler(this.FrmMessageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMessageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxMessageBox;
        private System.Windows.Forms.Label lblTxtMessage;
        private Glass.GlassButton btnOk;
        private Glass.GlassButton btnCancel;
        private Glass.GlassButton btnYes;
        private Glass.GlassButton btnNo;
    }
}