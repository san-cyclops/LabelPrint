namespace RIT.ERP.Report.GUI
{
    partial class FrmReportMazex
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
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radCollapsiblePanel1 = new Telerik.WinControls.UI.RadCollapsiblePanel();
            this.dgvCompare = new Telerik.WinControls.UI.RadGridView();
            this.btnCheckoutSelected = new Telerik.WinControls.UI.RadButton();
            this.btnReturnAll = new Telerik.WinControls.UI.RadButton();
            this.btnReturnSelected = new Telerik.WinControls.UI.RadButton();
            this.btnCheckoutAll = new Telerik.WinControls.UI.RadButton();
            this.redCmbSelection = new Telerik.WinControls.UI.RadDropDownList();
            this.dgvBasket = new Telerik.WinControls.UI.RadGridView();
            this.dgvSelection = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCollapsiblePanel1)).BeginInit();
            this.radCollapsiblePanel1.PanelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompare.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCheckoutSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCheckoutAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redCmbSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelection.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Location = new System.Drawing.Point(12, 296);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(307, 397);
            this.radPanel1.TabIndex = 3;
            // 
            // radPanel2
            // 
            this.radPanel2.Location = new System.Drawing.Point(325, 296);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(307, 397);
            this.radPanel2.TabIndex = 4;
            // 
            // radCollapsiblePanel1
            // 
            this.radCollapsiblePanel1.Location = new System.Drawing.Point(638, 72);
            this.radCollapsiblePanel1.Name = "radCollapsiblePanel1";
            // 
            // radCollapsiblePanel1.PanelContainer
            // 
            this.radCollapsiblePanel1.PanelContainer.Controls.Add(this.dgvCompare);
            this.radCollapsiblePanel1.PanelContainer.Size = new System.Drawing.Size(300, 391);
            this.radCollapsiblePanel1.Size = new System.Drawing.Size(302, 419);
            this.radCollapsiblePanel1.TabIndex = 5;
            this.radCollapsiblePanel1.Text = "radCollapsiblePanel1";
            // 
            // dgvCompare
            // 
            this.dgvCompare.Location = new System.Drawing.Point(3, 3);
            this.dgvCompare.Name = "dgvCompare";
            this.dgvCompare.Size = new System.Drawing.Size(290, 383);
            this.dgvCompare.TabIndex = 1;
            this.dgvCompare.Text = "radGridView3";
            // 
            // btnCheckoutSelected
            // 
            this.btnCheckoutSelected.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCheckoutSelected.Location = new System.Drawing.Point(950, 99);
            this.btnCheckoutSelected.Name = "btnCheckoutSelected";
            this.btnCheckoutSelected.Size = new System.Drawing.Size(180, 24);
            this.btnCheckoutSelected.TabIndex = 7;
            this.btnCheckoutSelected.Text = "Checkout Selected";
            // 
            // btnReturnAll
            // 
            this.btnReturnAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReturnAll.Location = new System.Drawing.Point(950, 189);
            this.btnReturnAll.Name = "btnReturnAll";
            this.btnReturnAll.Size = new System.Drawing.Size(180, 24);
            this.btnReturnAll.TabIndex = 10;
            this.btnReturnAll.Text = "Return All";
            // 
            // btnReturnSelected
            // 
            this.btnReturnSelected.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReturnSelected.Location = new System.Drawing.Point(950, 159);
            this.btnReturnSelected.Name = "btnReturnSelected";
            this.btnReturnSelected.Size = new System.Drawing.Size(180, 24);
            this.btnReturnSelected.TabIndex = 9;
            this.btnReturnSelected.Text = "Return Selected";
            // 
            // btnCheckoutAll
            // 
            this.btnCheckoutAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCheckoutAll.Location = new System.Drawing.Point(950, 129);
            this.btnCheckoutAll.Name = "btnCheckoutAll";
            this.btnCheckoutAll.Size = new System.Drawing.Size(180, 24);
            this.btnCheckoutAll.TabIndex = 8;
            this.btnCheckoutAll.Text = "Checkout All";
            // 
            // redCmbSelection
            // 
            this.redCmbSelection.Location = new System.Drawing.Point(29, 23);
            this.redCmbSelection.Name = "redCmbSelection";
            this.redCmbSelection.Size = new System.Drawing.Size(166, 20);
            this.redCmbSelection.TabIndex = 11;
            this.redCmbSelection.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.redCmbSelection_SelectedIndexChanged);
            // 
            // dgvBasket
            // 
            this.dgvBasket.Location = new System.Drawing.Point(423, 51);
            // 
            // dgvBasket
            // 
            this.dgvBasket.MasterTemplate.AllowAddNewRow = false;
            this.dgvBasket.MasterTemplate.EnableGrouping = false;
            this.dgvBasket.Name = "dgvBasket";
            this.dgvBasket.ShowGroupPanel = false;
            this.dgvBasket.Size = new System.Drawing.Size(180, 239);
            this.dgvBasket.TabIndex = 12;
            this.dgvBasket.Text = "radGridView2";
            this.dgvBasket.SelectionChanged += new System.EventHandler(this.dgvBasket_SelectionChanged);
            // 
            // dgvSelection
            // 
            this.dgvSelection.Location = new System.Drawing.Point(127, 51);
            // 
            // dgvSelection
            // 
            this.dgvSelection.MasterTemplate.AllowAddNewRow = false;
            this.dgvSelection.MasterTemplate.EnableGrouping = false;
            this.dgvSelection.Name = "dgvSelection";
            this.dgvSelection.ShowGroupPanel = false;
            this.dgvSelection.Size = new System.Drawing.Size(180, 239);
            this.dgvSelection.TabIndex = 13;
            this.dgvSelection.Text = "radGridView1";
            // 
            // FrmReportMaze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 503);
            this.Controls.Add(this.dgvBasket);
            this.Controls.Add(this.dgvSelection);
            this.Controls.Add(this.redCmbSelection);
            this.Controls.Add(this.btnCheckoutSelected);
            this.Controls.Add(this.btnReturnAll);
            this.Controls.Add(this.btnReturnSelected);
            this.Controls.Add(this.btnCheckoutAll);
            this.Controls.Add(this.radCollapsiblePanel1);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.Name = "FrmReportMaze";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FrmReportMaze";
            this.Load += new System.EventHandler(this.FrmReportMaze_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radCollapsiblePanel1.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radCollapsiblePanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompare.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCheckoutSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCheckoutAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redCmbSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelection.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadCollapsiblePanel radCollapsiblePanel1;
        private Telerik.WinControls.UI.RadGridView dgvCompare;
        private Telerik.WinControls.UI.RadButton btnCheckoutSelected;
        private Telerik.WinControls.UI.RadButton btnReturnAll;
        private Telerik.WinControls.UI.RadButton btnReturnSelected;
        private Telerik.WinControls.UI.RadButton btnCheckoutAll;
        private Telerik.WinControls.UI.RadDropDownList redCmbSelection;
        private Telerik.WinControls.UI.RadGridView dgvBasket;
        private Telerik.WinControls.UI.RadGridView dgvSelection;
    }
}
