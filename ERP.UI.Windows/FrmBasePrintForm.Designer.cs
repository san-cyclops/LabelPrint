namespace ERP.UI.Windows
{
    partial class FrmBasePrintForm
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
            this.btnHelp = new Glass.GlassButton();
            this.grpButtonSet2 = new System.Windows.Forms.Panel();
            this.btnPrint = new Glass.GlassButton();
            this.btnClear = new Glass.GlassButton();
            this.btnClose = new Glass.GlassButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpButtonSet.SuspendLayout();
            this.grpButtonSet2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpButtonSet.Controls.Add(this.btnHelp);
            this.grpButtonSet.Location = new System.Drawing.Point(2, 186);
            this.grpButtonSet.Name = "grpButtonSet";
            this.grpButtonSet.Size = new System.Drawing.Size(85, 43);
            this.grpButtonSet.TabIndex = 6;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnHelp.FadeOnFocus = true;
            this.btnHelp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.Black;
            this.btnHelp.Image = global::ERP.UI.Windows.Properties.Resources.Help_icon32;
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(2, 3);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.ShineColor = System.Drawing.Color.Brown;
            this.btnHelp.Size = new System.Drawing.Size(80, 37);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "&Help ";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpButtonSet2.Controls.Add(this.btnPrint);
            this.grpButtonSet2.Controls.Add(this.btnClear);
            this.grpButtonSet2.Controls.Add(this.btnClose);
            this.grpButtonSet2.Location = new System.Drawing.Point(427, 187);
            this.grpButtonSet2.Name = "grpButtonSet2";
            this.grpButtonSet2.Size = new System.Drawing.Size(239, 43);
            this.grpButtonSet2.TabIndex = 9;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnPrint.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Image = global::ERP.UI.Windows.Properties.Resources.printer32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(2, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ShineColor = System.Drawing.Color.Brown;
            this.btnPrint.Size = new System.Drawing.Size(76, 37);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.Text = "P&rint ";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnClear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Image = global::ERP.UI.Windows.Properties.Resources.clear_icon32;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(78, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShineColor = System.Drawing.Color.Brown;
            this.btnClear.Size = new System.Drawing.Size(79, 37);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Cl&ear ";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.btnClose.Size = new System.Drawing.Size(81, 37);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "&Close ";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmBasePrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(668, 233);
            this.Controls.Add(this.grpButtonSet2);
            this.Controls.Add(this.grpButtonSet);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmBasePrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBasePrintForm";
            this.Load += new System.EventHandler(this.FrmBasePrintForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBasePrintForm_KeyDown);
            this.grpButtonSet.ResumeLayout(false);
            this.grpButtonSet2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel grpButtonSet;
        protected System.Windows.Forms.Panel grpButtonSet2;
        protected Glass.GlassButton btnHelp;
        protected Glass.GlassButton btnClear;
        protected Glass.GlassButton btnClose;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        protected Glass.GlassButton btnPrint;



    }
}