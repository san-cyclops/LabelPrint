﻿namespace ERP.Report.GUI
{
    partial class FrmRestaurentReportGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRestaurentReportGenerator));
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.rdoSummery = new System.Windows.Forms.RadioButton();
            this.rdoDetail = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.chkAllLocations = new System.Windows.Forms.CheckBox();
            this.rdoSelection = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.Panel();
            this.prgBar = new ERP.ProgressBar.ProgressBarEx();
            this.btnClearSelection = new Glass.GlassButton();
            this.lstLayer = new System.Windows.Forms.ListView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.Panel();
            this.lstLocation = new System.Windows.Forms.ListView();
            this.imgListLoca = new System.Windows.Forms.ImageList(this.components);
            this.groupBox4 = new System.Windows.Forms.Panel();
            this.chkAllBillingLocations = new System.Windows.Forms.CheckBox();
            this.lstBillingLocation = new System.Windows.Forms.ListView();
            this.groupBox5 = new System.Windows.Forms.Panel();
            this.chkUnit = new System.Windows.Forms.CheckBox();
            this.lstUnit = new System.Windows.Forms.ListView();
            this.groupBox6 = new System.Windows.Forms.Panel();
            this.chkShift = new System.Windows.Forms.CheckBox();
            this.lstShift = new System.Windows.Forms.ListView();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(897, 402);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Location = new System.Drawing.Point(2, 402);
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSummery);
            this.groupBox1.Controls.Add(this.rdoDetail);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.lblDateRange);
            this.groupBox1.Location = new System.Drawing.Point(3, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1132, 45);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // rdoSummery
            // 
            this.rdoSummery.AutoSize = true;
            this.rdoSummery.Checked = true;
            this.rdoSummery.Location = new System.Drawing.Point(437, 15);
            this.rdoSummery.Name = "rdoSummery";
            this.rdoSummery.Size = new System.Drawing.Size(81, 17);
            this.rdoSummery.TabIndex = 115;
            this.rdoSummery.TabStop = true;
            this.rdoSummery.Text = "Summary";
            this.rdoSummery.UseVisualStyleBackColor = true;
            // 
            // rdoDetail
            // 
            this.rdoDetail.AutoSize = true;
            this.rdoDetail.Location = new System.Drawing.Point(535, 15);
            this.rdoDetail.Name = "rdoDetail";
            this.rdoDetail.Size = new System.Drawing.Size(58, 17);
            this.rdoDetail.TabIndex = 85;
            this.rdoDetail.Text = "Detail";
            this.rdoDetail.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "-";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(278, 13);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(133, 21);
            this.dtpToDate.TabIndex = 113;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(123, 13);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(133, 21);
            this.dtpFromDate.TabIndex = 96;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(6, 17);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(74, 13);
            this.lblDateRange.TabIndex = 95;
            this.lblDateRange.Text = "Date Range";
            // 
            // chkAllLocations
            // 
            this.chkAllLocations.AutoSize = true;
            this.chkAllLocations.Location = new System.Drawing.Point(6, 19);
            this.chkAllLocations.Name = "chkAllLocations";
            this.chkAllLocations.Size = new System.Drawing.Size(94, 17);
            this.chkAllLocations.TabIndex = 115;
            this.chkAllLocations.Tag = "";
            this.chkAllLocations.Text = "All locations";
            this.chkAllLocations.UseVisualStyleBackColor = true;
            this.chkAllLocations.CheckedChanged += new System.EventHandler(this.chkAllLocations_CheckedChanged);
            // 
            // rdoSelection
            // 
            this.rdoSelection.AutoSize = true;
            this.rdoSelection.Location = new System.Drawing.Point(8, 16);
            this.rdoSelection.Name = "rdoSelection";
            this.rdoSelection.Size = new System.Drawing.Size(60, 17);
            this.rdoSelection.TabIndex = 15;
            this.rdoSelection.TabStop = true;
            this.rdoSelection.Text = "Select";
            this.rdoSelection.UseVisualStyleBackColor = true;
            this.rdoSelection.CheckedChanged += new System.EventHandler(this.rdoSelection_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.prgBar);
            this.groupBox2.Controls.Add(this.btnClearSelection);
            this.groupBox2.Controls.Add(this.lstLayer);
            this.groupBox2.Controls.Add(this.rdoSelection);
            this.groupBox2.Location = new System.Drawing.Point(3, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1131, 186);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selection";
            // 
            // prgBar
            // 
            this.prgBar.BackColor = System.Drawing.Color.DodgerBlue;
            this.prgBar.Border = false;
            this.prgBar.Image = null;
            this.prgBar.Location = new System.Drawing.Point(5, 168);
            this.prgBar.Name = "prgBar";
            this.prgBar.ProgressColor = System.Drawing.Color.MidnightBlue;
            this.prgBar.Size = new System.Drawing.Size(1121, 15);
            this.prgBar.Text = "progressBarEx6";
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnClearSelection.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSelection.ForeColor = System.Drawing.Color.Black;
            this.btnClearSelection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearSelection.Location = new System.Drawing.Point(91, 12);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(104, 22);
            this.btnClearSelection.TabIndex = 85;
            this.btnClearSelection.Text = "Clear Selection";
            this.btnClearSelection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // lstLayer
            // 
            this.lstLayer.BackgroundImageTiled = true;
            this.lstLayer.CheckBoxes = true;
            this.lstLayer.HideSelection = false;
            this.lstLayer.Location = new System.Drawing.Point(4, 39);
            this.lstLayer.Name = "lstLayer";
            this.lstLayer.ShowItemToolTips = true;
            this.lstLayer.Size = new System.Drawing.Size(1122, 125);
            this.lstLayer.TabIndex = 83;
            this.lstLayer.UseCompatibleStateImageBehavior = false;
            this.lstLayer.View = System.Windows.Forms.View.List;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "box.png");
            this.imgList.Images.SetKeyName(1, "home.gif");
            this.imgList.Images.SetKeyName(2, "kgpg.png");
            this.imgList.Images.SetKeyName(3, "LogOff.png");
            this.imgList.Images.SetKeyName(4, "xchat.png");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkAllLocations);
            this.groupBox3.Controls.Add(this.lstLocation);
            this.groupBox3.Location = new System.Drawing.Point(3, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 171);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Location";
            // 
            // lstLocation
            // 
            this.lstLocation.BackgroundImageTiled = true;
            this.lstLocation.CheckBoxes = true;
            this.lstLocation.HideSelection = false;
            this.lstLocation.Location = new System.Drawing.Point(6, 40);
            this.lstLocation.Name = "lstLocation";
            this.lstLocation.ShowItemToolTips = true;
            this.lstLocation.Size = new System.Drawing.Size(267, 124);
            this.lstLocation.TabIndex = 84;
            this.lstLocation.UseCompatibleStateImageBehavior = false;
            this.lstLocation.View = System.Windows.Forms.View.List;
            // 
            // imgListLoca
            // 
            this.imgListLoca.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLoca.ImageStream")));
            this.imgListLoca.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLoca.Images.SetKeyName(0, "home.gif");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkAllBillingLocations);
            this.groupBox4.Controls.Add(this.lstBillingLocation);
            this.groupBox4.Location = new System.Drawing.Point(288, 43);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(277, 171);
            this.groupBox4.TabIndex = 117;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Billing Location";
            // 
            // chkAllBillingLocations
            // 
            this.chkAllBillingLocations.AutoSize = true;
            this.chkAllBillingLocations.Location = new System.Drawing.Point(6, 19);
            this.chkAllBillingLocations.Name = "chkAllBillingLocations";
            this.chkAllBillingLocations.Size = new System.Drawing.Size(132, 17);
            this.chkAllBillingLocations.TabIndex = 115;
            this.chkAllBillingLocations.Tag = "";
            this.chkAllBillingLocations.Text = "All Billing locations";
            this.chkAllBillingLocations.UseVisualStyleBackColor = true;
            this.chkAllBillingLocations.CheckedChanged += new System.EventHandler(this.chkAllBillingLocations_CheckedChanged);
            // 
            // lstBillingLocation
            // 
            this.lstBillingLocation.BackgroundImageTiled = true;
            this.lstBillingLocation.CheckBoxes = true;
            this.lstBillingLocation.HideSelection = false;
            this.lstBillingLocation.Location = new System.Drawing.Point(6, 40);
            this.lstBillingLocation.Name = "lstBillingLocation";
            this.lstBillingLocation.ShowItemToolTips = true;
            this.lstBillingLocation.Size = new System.Drawing.Size(267, 124);
            this.lstBillingLocation.SmallImageList = this.imgListLoca;
            this.lstBillingLocation.TabIndex = 84;
            this.lstBillingLocation.UseCompatibleStateImageBehavior = false;
            this.lstBillingLocation.View = System.Windows.Forms.View.List;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkUnit);
            this.groupBox5.Controls.Add(this.lstUnit);
            this.groupBox5.Location = new System.Drawing.Point(570, 43);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(279, 170);
            this.groupBox5.TabIndex = 119;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Unit";
            // 
            // chkUnit
            // 
            this.chkUnit.AutoSize = true;
            this.chkUnit.Location = new System.Drawing.Point(6, 19);
            this.chkUnit.Name = "chkUnit";
            this.chkUnit.Size = new System.Drawing.Size(72, 17);
            this.chkUnit.TabIndex = 115;
            this.chkUnit.Tag = " ";
            this.chkUnit.Text = "All Units";
            this.chkUnit.UseVisualStyleBackColor = true;
            this.chkUnit.CheckedChanged += new System.EventHandler(this.chkUnit_CheckedChanged);
            // 
            // lstUnit
            // 
            this.lstUnit.BackgroundImageTiled = true;
            this.lstUnit.CheckBoxes = true;
            this.lstUnit.HideSelection = false;
            this.lstUnit.Location = new System.Drawing.Point(6, 40);
            this.lstUnit.Name = "lstUnit";
            this.lstUnit.ShowItemToolTips = true;
            this.lstUnit.Size = new System.Drawing.Size(267, 124);
            this.lstUnit.TabIndex = 84;
            this.lstUnit.UseCompatibleStateImageBehavior = false;
            this.lstUnit.View = System.Windows.Forms.View.List;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkShift);
            this.groupBox6.Controls.Add(this.lstShift);
            this.groupBox6.Location = new System.Drawing.Point(854, 43);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(278, 170);
            this.groupBox6.TabIndex = 118;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Shift";
            // 
            // chkShift
            // 
            this.chkShift.AutoSize = true;
            this.chkShift.Location = new System.Drawing.Point(6, 19);
            this.chkShift.Name = "chkShift";
            this.chkShift.Size = new System.Drawing.Size(76, 17);
            this.chkShift.TabIndex = 115;
            this.chkShift.Tag = "";
            this.chkShift.Text = "All Shifts";
            this.chkShift.UseVisualStyleBackColor = true;
            this.chkShift.CheckedChanged += new System.EventHandler(this.chkShift_CheckedChanged);
            // 
            // lstShift
            // 
            this.lstShift.BackgroundImageTiled = true;
            this.lstShift.CheckBoxes = true;
            this.lstShift.HideSelection = false;
            this.lstShift.Location = new System.Drawing.Point(6, 40);
            this.lstShift.Name = "lstShift";
            this.lstShift.ShowItemToolTips = true;
            this.lstShift.Size = new System.Drawing.Size(267, 124);
            this.lstShift.TabIndex = 84;
            this.lstShift.UseCompatibleStateImageBehavior = false;
            this.lstShift.View = System.Windows.Forms.View.List;
            // 
            // FrmRestaurentReportGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 450);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "FrmRestaurentReportGenerator";
            this.Text = "FrmRestaurentReportGenerator";
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.RadioButton rdoSelection;
        private System.Windows.Forms.CheckBox chkAllLocations;
        private System.Windows.Forms.Panel groupBox2;
        internal System.Windows.Forms.ListView lstLayer;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Panel groupBox3;
        internal System.Windows.Forms.ListView lstLocation;
        private System.Windows.Forms.ImageList imgListLoca;
        private System.Windows.Forms.RadioButton rdoSummery;
        private System.Windows.Forms.RadioButton rdoDetail;
        private System.Windows.Forms.Panel groupBox4;
        private System.Windows.Forms.CheckBox chkAllBillingLocations;
        internal System.Windows.Forms.ListView lstBillingLocation;
        private System.Windows.Forms.Panel groupBox5;
        private System.Windows.Forms.CheckBox chkUnit;
        internal System.Windows.Forms.ListView lstUnit;
        private System.Windows.Forms.Panel groupBox6;
        private System.Windows.Forms.CheckBox chkShift;
        internal System.Windows.Forms.ListView lstShift;
        protected Glass.GlassButton btnClearSelection;
        private ERP.ProgressBar.ProgressBarEx prgBar;
    }
}