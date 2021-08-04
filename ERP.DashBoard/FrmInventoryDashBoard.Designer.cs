using RIT;

namespace ERP.DashBoard
{
    partial class FrmInventoryDashBoard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnNonTrading = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.pnlCrm = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.Panel();
            this.lblExpected = new System.Windows.Forms.Label();
            this.aGauge2 = new RIT.AGauge();
            this.lblYesterday = new System.Windows.Forms.Label();
            this.aGauge1 = new RIT.AGauge();
            this.lblToday = new System.Windows.Forms.Label();
            this.aGauge4 = new RIT.AGauge();
            this.groupBox2 = new System.Windows.Forms.Panel();
            this.cmbChartType = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.chrtRedeems = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.chrtEarns = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnInventory = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnPos = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnHr = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnAccounts = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnCrm = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.groupBox1.SuspendLayout();
            this.pnlCrm.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtRedeems)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtEarns)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNonTrading
            // 
            this.btnNonTrading.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonTrading.Location = new System.Drawing.Point(4, 124);
            this.btnNonTrading.Name = "btnNonTrading";
            this.btnNonTrading.Size = new System.Drawing.Size(148, 107);
            this.btnNonTrading.TabIndex = 0;
            this.btnNonTrading.Text = "Non Trading";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlCrm);
            this.groupBox1.Controls.Add(this.btnInventory);
            this.groupBox1.Controls.Add(this.btnPos);
            this.groupBox1.Controls.Add(this.btnHr);
            this.groupBox1.Controls.Add(this.btnNonTrading);
            this.groupBox1.Controls.Add(this.btnAccounts);
            this.groupBox1.Controls.Add(this.btnCrm);
            this.groupBox1.Location = new System.Drawing.Point(2, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1344, 730);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // pnlCrm
            // 
            this.pnlCrm.Controls.Add(this.groupBox3);
            this.pnlCrm.Controls.Add(this.groupBox2);
            this.pnlCrm.Controls.Add(this.panel4);
            this.pnlCrm.Controls.Add(this.panel1);
            this.pnlCrm.Location = new System.Drawing.Point(158, 11);
            this.pnlCrm.Name = "pnlCrm";
            this.pnlCrm.Size = new System.Drawing.Size(1178, 672);
            this.pnlCrm.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblExpected);
            this.groupBox3.Controls.Add(this.aGauge2);
            this.groupBox3.Controls.Add(this.lblYesterday);
            this.groupBox3.Controls.Add(this.aGauge1);
            this.groupBox3.Controls.Add(this.lblToday);
            this.groupBox3.Controls.Add(this.aGauge4);
            this.groupBox3.Location = new System.Drawing.Point(786, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 607);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Customer Visit";
            // 
            // lblExpected
            // 
            this.lblExpected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExpected.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpected.Location = new System.Drawing.Point(59, 436);
            this.lblExpected.Name = "lblExpected";
            this.lblExpected.Size = new System.Drawing.Size(254, 27);
            this.lblExpected.TabIndex = 25;
            this.lblExpected.Text = "Expected Tomorrow : ";
            this.lblExpected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aGauge2
            // 
            this.aGauge2.BaseArcColor = System.Drawing.Color.Gray;
            this.aGauge2.BaseArcRadius = 150;
            this.aGauge2.BaseArcStart = 215;
            this.aGauge2.BaseArcSweep = 110;
            this.aGauge2.BaseArcWidth = 2;
            this.aGauge2.Cap_Idx = ((byte)(1));
            this.aGauge2.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.aGauge2.CapPosition = new System.Drawing.Point(10, 10);
            this.aGauge2.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.aGauge2.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
            this.aGauge2.CapText = "";
            this.aGauge2.Center = new System.Drawing.Point(150, 180);
            this.aGauge2.Location = new System.Drawing.Point(37, 324);
            this.aGauge2.MaxValue = 300F;
            this.aGauge2.MinValue = -300F;
            this.aGauge2.Name = "aGauge2";
            this.aGauge2.NeedleColor1 = RIT.AGauge.NeedleColorEnum.Green;
            this.aGauge2.NeedleColor2 = System.Drawing.Color.DimGray;
            this.aGauge2.NeedleRadius = 150;
            this.aGauge2.NeedleType = 0;
            this.aGauge2.NeedleWidth = 2;
            this.aGauge2.Range_Idx = ((byte)(1));
            this.aGauge2.RangeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.aGauge2.RangeEnabled = false;
            this.aGauge2.RangeEndValue = 400F;
            this.aGauge2.RangeInnerRadius = 10;
            this.aGauge2.RangeOuterRadius = 40;
            this.aGauge2.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.aGauge2.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.aGauge2.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.aGauge2.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.aGauge2.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.aGauge2.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.aGauge2.RangeStartValue = 300F;
            this.aGauge2.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.aGauge2.ScaleLinesInterInnerRadius = 145;
            this.aGauge2.ScaleLinesInterOuterRadius = 150;
            this.aGauge2.ScaleLinesInterWidth = 2;
            this.aGauge2.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.aGauge2.ScaleLinesMajorInnerRadius = 140;
            this.aGauge2.ScaleLinesMajorOuterRadius = 150;
            this.aGauge2.ScaleLinesMajorStepValue = 100F;
            this.aGauge2.ScaleLinesMajorWidth = 2;
            this.aGauge2.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.aGauge2.ScaleLinesMinorInnerRadius = 145;
            this.aGauge2.ScaleLinesMinorNumOf = 9;
            this.aGauge2.ScaleLinesMinorOuterRadius = 150;
            this.aGauge2.ScaleLinesMinorWidth = 1;
            this.aGauge2.ScaleNumbersColor = System.Drawing.Color.Black;
            this.aGauge2.ScaleNumbersFormat = null;
            this.aGauge2.ScaleNumbersRadius = 162;
            this.aGauge2.ScaleNumbersRotation = 90;
            this.aGauge2.ScaleNumbersStartScaleLine = 1;
            this.aGauge2.ScaleNumbersStepScaleLines = 2;
            this.aGauge2.Size = new System.Drawing.Size(297, 107);
            this.aGauge2.TabIndex = 24;
            this.aGauge2.Text = "aGauge2";
            this.aGauge2.Value = 0F;
            // 
            // lblYesterday
            // 
            this.lblYesterday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYesterday.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYesterday.Location = new System.Drawing.Point(59, 276);
            this.lblYesterday.Name = "lblYesterday";
            this.lblYesterday.Size = new System.Drawing.Size(254, 27);
            this.lblYesterday.TabIndex = 23;
            this.lblYesterday.Text = "Yesterday : ";
            this.lblYesterday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aGauge1
            // 
            this.aGauge1.BaseArcColor = System.Drawing.Color.Gray;
            this.aGauge1.BaseArcRadius = 150;
            this.aGauge1.BaseArcStart = 215;
            this.aGauge1.BaseArcSweep = 110;
            this.aGauge1.BaseArcWidth = 2;
            this.aGauge1.Cap_Idx = ((byte)(1));
            this.aGauge1.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.aGauge1.CapPosition = new System.Drawing.Point(10, 10);
            this.aGauge1.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.aGauge1.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
            this.aGauge1.CapText = "";
            this.aGauge1.Center = new System.Drawing.Point(150, 180);
            this.aGauge1.Location = new System.Drawing.Point(37, 164);
            this.aGauge1.MaxValue = 300F;
            this.aGauge1.MinValue = -300F;
            this.aGauge1.Name = "aGauge1";
            this.aGauge1.NeedleColor1 = RIT.AGauge.NeedleColorEnum.Green;
            this.aGauge1.NeedleColor2 = System.Drawing.Color.DimGray;
            this.aGauge1.NeedleRadius = 150;
            this.aGauge1.NeedleType = 0;
            this.aGauge1.NeedleWidth = 2;
            this.aGauge1.Range_Idx = ((byte)(1));
            this.aGauge1.RangeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.aGauge1.RangeEnabled = false;
            this.aGauge1.RangeEndValue = 400F;
            this.aGauge1.RangeInnerRadius = 10;
            this.aGauge1.RangeOuterRadius = 40;
            this.aGauge1.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.aGauge1.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.aGauge1.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.aGauge1.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.aGauge1.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.aGauge1.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.aGauge1.RangeStartValue = 300F;
            this.aGauge1.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.aGauge1.ScaleLinesInterInnerRadius = 145;
            this.aGauge1.ScaleLinesInterOuterRadius = 150;
            this.aGauge1.ScaleLinesInterWidth = 2;
            this.aGauge1.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.aGauge1.ScaleLinesMajorInnerRadius = 140;
            this.aGauge1.ScaleLinesMajorOuterRadius = 150;
            this.aGauge1.ScaleLinesMajorStepValue = 100F;
            this.aGauge1.ScaleLinesMajorWidth = 2;
            this.aGauge1.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.aGauge1.ScaleLinesMinorInnerRadius = 145;
            this.aGauge1.ScaleLinesMinorNumOf = 9;
            this.aGauge1.ScaleLinesMinorOuterRadius = 150;
            this.aGauge1.ScaleLinesMinorWidth = 1;
            this.aGauge1.ScaleNumbersColor = System.Drawing.Color.Black;
            this.aGauge1.ScaleNumbersFormat = null;
            this.aGauge1.ScaleNumbersRadius = 162;
            this.aGauge1.ScaleNumbersRotation = 90;
            this.aGauge1.ScaleNumbersStartScaleLine = 1;
            this.aGauge1.ScaleNumbersStepScaleLines = 2;
            this.aGauge1.Size = new System.Drawing.Size(297, 107);
            this.aGauge1.TabIndex = 22;
            this.aGauge1.Text = "aGauge1";
            this.aGauge1.Value = 0F;
            // 
            // lblToday
            // 
            this.lblToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToday.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToday.Location = new System.Drawing.Point(59, 127);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(254, 27);
            this.lblToday.TabIndex = 21;
            this.lblToday.Text = "Today : ";
            this.lblToday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aGauge4
            // 
            this.aGauge4.BaseArcColor = System.Drawing.Color.Gray;
            this.aGauge4.BaseArcRadius = 150;
            this.aGauge4.BaseArcStart = 215;
            this.aGauge4.BaseArcSweep = 110;
            this.aGauge4.BaseArcWidth = 2;
            this.aGauge4.Cap_Idx = ((byte)(1));
            this.aGauge4.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.aGauge4.CapPosition = new System.Drawing.Point(10, 10);
            this.aGauge4.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.aGauge4.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
            this.aGauge4.CapText = "";
            this.aGauge4.Center = new System.Drawing.Point(150, 180);
            this.aGauge4.Location = new System.Drawing.Point(37, 15);
            this.aGauge4.MaxValue = 300F;
            this.aGauge4.MinValue = -300F;
            this.aGauge4.Name = "aGauge4";
            this.aGauge4.NeedleColor1 = RIT.AGauge.NeedleColorEnum.Green;
            this.aGauge4.NeedleColor2 = System.Drawing.Color.DimGray;
            this.aGauge4.NeedleRadius = 150;
            this.aGauge4.NeedleType = 0;
            this.aGauge4.NeedleWidth = 2;
            this.aGauge4.Range_Idx = ((byte)(1));
            this.aGauge4.RangeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.aGauge4.RangeEnabled = false;
            this.aGauge4.RangeEndValue = 400F;
            this.aGauge4.RangeInnerRadius = 10;
            this.aGauge4.RangeOuterRadius = 40;
            this.aGauge4.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.aGauge4.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.aGauge4.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.aGauge4.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.aGauge4.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.aGauge4.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.aGauge4.RangeStartValue = 300F;
            this.aGauge4.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.aGauge4.ScaleLinesInterInnerRadius = 145;
            this.aGauge4.ScaleLinesInterOuterRadius = 150;
            this.aGauge4.ScaleLinesInterWidth = 2;
            this.aGauge4.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.aGauge4.ScaleLinesMajorInnerRadius = 140;
            this.aGauge4.ScaleLinesMajorOuterRadius = 150;
            this.aGauge4.ScaleLinesMajorStepValue = 100F;
            this.aGauge4.ScaleLinesMajorWidth = 2;
            this.aGauge4.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.aGauge4.ScaleLinesMinorInnerRadius = 145;
            this.aGauge4.ScaleLinesMinorNumOf = 9;
            this.aGauge4.ScaleLinesMinorOuterRadius = 150;
            this.aGauge4.ScaleLinesMinorWidth = 1;
            this.aGauge4.ScaleNumbersColor = System.Drawing.Color.Black;
            this.aGauge4.ScaleNumbersFormat = null;
            this.aGauge4.ScaleNumbersRadius = 162;
            this.aGauge4.ScaleNumbersRotation = 90;
            this.aGauge4.ScaleNumbersStartScaleLine = 1;
            this.aGauge4.ScaleNumbersStepScaleLines = 2;
            this.aGauge4.Size = new System.Drawing.Size(297, 107);
            this.aGauge4.TabIndex = 20;
            this.aGauge4.Text = "aGauge4";
            this.aGauge4.Value = 0F;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbChartType);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 57);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change Chart Style";
            // 
            // cmbChartType
            // 
            this.cmbChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChartType.FormattingEnabled = true;
            this.cmbChartType.Location = new System.Drawing.Point(10, 22);
            this.cmbChartType.Name = "cmbChartType";
            this.cmbChartType.Size = new System.Drawing.Size(200, 27);
            this.cmbChartType.TabIndex = 4;
            this.cmbChartType.SelectedIndexChanged += new System.EventHandler(this.cmbChartType_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SkyBlue;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.chrtRedeems);
            this.panel4.Location = new System.Drawing.Point(8, 344);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(775, 271);
            this.panel4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(278, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Location Wise Redeems";
            // 
            // chrtRedeems
            // 
            this.chrtRedeems.BackColor = System.Drawing.Color.SkyBlue;
            chartArea3.Name = "ChartArea1";
            this.chrtRedeems.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chrtRedeems.Legends.Add(legend3);
            this.chrtRedeems.Location = new System.Drawing.Point(3, 33);
            this.chrtRedeems.Name = "chrtRedeems";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "series";
            this.chrtRedeems.Series.Add(series3);
            this.chrtRedeems.Size = new System.Drawing.Size(766, 218);
            this.chrtRedeems.TabIndex = 0;
            this.chrtRedeems.Text = "chart4";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chrtEarns);
            this.panel1.Location = new System.Drawing.Point(5, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 271);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Location Wise Earns";
            // 
            // chrtEarns
            // 
            this.chrtEarns.BackColor = System.Drawing.Color.SkyBlue;
            chartArea4.Name = "ChartArea1";
            this.chrtEarns.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chrtEarns.Legends.Add(legend4);
            this.chrtEarns.Location = new System.Drawing.Point(-26, 34);
            this.chrtEarns.Name = "chrtEarns";
            this.chrtEarns.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series4.Legend = "Legend1";
            series4.Name = "series";
            series4.YValuesPerPoint = 2;
            this.chrtEarns.Series.Add(series4);
            this.chrtEarns.Size = new System.Drawing.Size(766, 218);
            this.chrtEarns.TabIndex = 0;
            this.chrtEarns.Text = "chart1";
            // 
            // btnInventory
            // 
            this.btnInventory.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.Location = new System.Drawing.Point(4, 11);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(148, 107);
            this.btnInventory.TabIndex = 1;
            this.btnInventory.Text = "Inventory";
            // 
            // btnPos
            // 
            this.btnPos.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPos.Location = new System.Drawing.Point(4, 576);
            this.btnPos.Name = "btnPos";
            this.btnPos.Size = new System.Drawing.Size(148, 107);
            this.btnPos.TabIndex = 6;
            this.btnPos.Text = "Point Of Sale (POS)";
            // 
            // btnHr
            // 
            this.btnHr.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHr.Location = new System.Drawing.Point(4, 463);
            this.btnHr.Name = "btnHr";
            this.btnHr.Size = new System.Drawing.Size(148, 107);
            this.btnHr.TabIndex = 5;
            this.btnHr.Text = "Human Resource (HR)";
            // 
            // btnAccounts
            // 
            this.btnAccounts.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccounts.Location = new System.Drawing.Point(4, 350);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(148, 107);
            this.btnAccounts.TabIndex = 3;
            this.btnAccounts.Text = "Accounts";
            // 
            // btnCrm
            // 
            this.btnCrm.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrm.Location = new System.Drawing.Point(4, 237);
            this.btnCrm.Name = "btnCrm";
            this.btnCrm.Size = new System.Drawing.Size(148, 107);
            this.btnCrm.TabIndex = 2;
            this.btnCrm.Text = "Customer Relation (CRM)";
            this.btnCrm.Click += new System.EventHandler(this.btnCrm_Click);
            // 
            // FrmInventoryDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmInventoryDashBoard";
            this.Text = "FrmInventoryDashBoard";
            this.groupBox1.ResumeLayout(false);
            this.pnlCrm.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtRedeems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtEarns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private global::ERP.UI.Windows.CustomControls.uc_GButton btnNonTrading;
        private System.Windows.Forms.Panel groupBox1;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnInventory;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnCrm;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnAccounts;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnPos;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnHr;
        private System.Windows.Forms.Panel pnlCrm;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtEarns;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtRedeems;
        private System.Windows.Forms.ComboBox cmbChartType;
        private System.Windows.Forms.Panel groupBox2;
        private System.Windows.Forms.Panel groupBox3;
        private System.Windows.Forms.Label lblExpected;
        private AGauge aGauge2;
        private System.Windows.Forms.Label lblYesterday;
        private AGauge aGauge1;
        private System.Windows.Forms.Label lblToday;
        private AGauge aGauge4;
    }
}