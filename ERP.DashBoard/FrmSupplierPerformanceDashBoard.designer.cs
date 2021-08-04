using RIT;

namespace ERP.DashBoard
{
    partial class FrmSupplierPerformanceDashBoard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.clrDialog = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ddControlTotalPurchasesTomorrow = new Owf.Controls.DigitalDisplayControl();
            this.label6 = new System.Windows.Forms.Label();
            this.ddControlTotalPurchases = new Owf.Controls.DigitalDisplayControl();
            this.label5 = new System.Windows.Forms.Label();
            this.a1Panel1 = new Owf.Controls.A1Panel();
            this.digitalDisplayControl1 = new Owf.Controls.DigitalDisplayControl();
            this.btnSettings = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnClose = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnRefresh = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.grpDateRange = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblYValueEarn = new System.Windows.Forms.Label();
            this.chrtPurchaseOrders = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnReset = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnChangeColor = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.grpVisit = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNeedleToday = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnNeedleYesterday = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.lblSupplier2Code = new System.Windows.Forms.Label();
            this.lblSupplier1Code = new System.Windows.Forms.Label();
            this.lblSupplier2Name = new System.Windows.Forms.Label();
            this.lblSupplier1Name = new System.Windows.Forms.Label();
            this.guageSupplier1 = new RIT.AGauge();
            this.guageSupplier2 = new RIT.AGauge();
            this.grpLocationSummery = new System.Windows.Forms.Panel();
            this.txtTopNSupplier = new System.Windows.Forms.TextBox();
            this.btnTopnSupplier = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.dgvTopSupplierSummery = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.cmbSupplierTo = new System.Windows.Forms.ComboBox();
            this.cmbSupplierFrom = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPurchases = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a1Panel1.SuspendLayout();
            this.grpDateRange.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPurchaseOrders)).BeginInit();
            this.pnlSettings.SuspendLayout();
            this.grpVisit.SuspendLayout();
            this.grpLocationSummery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSupplierSummery)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ddControlTotalPurchasesTomorrow
            // 
            this.ddControlTotalPurchasesTomorrow.BackColor = System.Drawing.Color.Transparent;
            this.ddControlTotalPurchasesTomorrow.DigitColor = System.Drawing.Color.RoyalBlue;
            this.ddControlTotalPurchasesTomorrow.DigitText = "17866.99";
            this.ddControlTotalPurchasesTomorrow.Location = new System.Drawing.Point(327, 713);
            this.ddControlTotalPurchasesTomorrow.Name = "ddControlTotalPurchasesTomorrow";
            this.ddControlTotalPurchasesTomorrow.Size = new System.Drawing.Size(126, 18);
            this.ddControlTotalPurchasesTomorrow.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(213, 714);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Total GRN Today : ";
            // 
            // ddControlTotalPurchases
            // 
            this.ddControlTotalPurchases.BackColor = System.Drawing.Color.Transparent;
            this.ddControlTotalPurchases.DigitColor = System.Drawing.Color.RoyalBlue;
            this.ddControlTotalPurchases.DigitText = "17866.99";
            this.ddControlTotalPurchases.Location = new System.Drawing.Point(458, 682);
            this.ddControlTotalPurchases.Name = "ddControlTotalPurchases";
            this.ddControlTotalPurchases.Size = new System.Drawing.Size(126, 18);
            this.ddControlTotalPurchases.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Copperplate Gothic Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(213, 683);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(277, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Purchase Orders Today : ";
            // 
            // a1Panel1
            // 
            this.a1Panel1.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel1.Controls.Add(this.digitalDisplayControl1);
            this.a1Panel1.GradientEndColor = System.Drawing.SystemColors.MenuHighlight;
            this.a1Panel1.GradientStartColor = System.Drawing.Color.Thistle;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(4, 675);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.RoundCornerRadius = 29;
            this.a1Panel1.ShadowOffSet = 12;
            this.a1Panel1.Size = new System.Drawing.Size(203, 68);
            this.a1Panel1.TabIndex = 36;
            // 
            // digitalDisplayControl1
            // 
            this.digitalDisplayControl1.BackColor = System.Drawing.Color.Transparent;
            this.digitalDisplayControl1.DigitColor = System.Drawing.Color.RoyalBlue;
            this.digitalDisplayControl1.Location = new System.Drawing.Point(6, 8);
            this.digitalDisplayControl1.Name = "digitalDisplayControl1";
            this.digitalDisplayControl1.Size = new System.Drawing.Size(170, 39);
            this.digitalDisplayControl1.TabIndex = 35;
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = global::ERP.DashBoard.Properties.Resources.settings_icon32;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSettings.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(1073, 11);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(69, 53);
            this.btnSettings.TabIndex = 34;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::ERP.DashBoard.Properties.Resources.Actions_window_close_icon;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1154, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 53);
            this.btnClose.TabIndex = 32;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::ERP.DashBoard.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_view_refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1236, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(69, 53);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpDateRange
            // 
            this.grpDateRange.Controls.Add(this.label4);
            this.grpDateRange.Controls.Add(this.label1);
            this.grpDateRange.Controls.Add(this.dtpToDate);
            this.grpDateRange.Controls.Add(this.dtpFromDate);
            this.grpDateRange.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDateRange.Location = new System.Drawing.Point(6, 7);
            this.grpDateRange.Name = "grpDateRange";
            this.grpDateRange.Size = new System.Drawing.Size(514, 53);
            this.grpDateRange.TabIndex = 6;
            this.grpDateRange.TabStop = false;
            this.grpDateRange.Text = "Change Date Range";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "From";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(287, 21);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(216, 23);
            this.dtpToDate.TabIndex = 9;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDateEarn_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(52, 21);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(204, 23);
            this.dtpFromDate.TabIndex = 8;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDateEarn_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblYValueEarn);
            this.panel1.Controls.Add(this.chrtPurchaseOrders);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.panel1.Location = new System.Drawing.Point(5, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1333, 271);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label2.Location = new System.Drawing.Point(125, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Supplier Wise Purchase Orders";
            // 
            // lblYValueEarn
            // 
            this.lblYValueEarn.AutoSize = true;
            this.lblYValueEarn.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblYValueEarn.Location = new System.Drawing.Point(570, 12);
            this.lblYValueEarn.Name = "lblYValueEarn";
            this.lblYValueEarn.Size = new System.Drawing.Size(46, 15);
            this.lblYValueEarn.TabIndex = 3;
            this.lblYValueEarn.Text = "Value : ";
            // 
            // chrtPurchaseOrders
            // 
            this.chrtPurchaseOrders.BackColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            chartArea1.Name = "area";
            this.chrtPurchaseOrders.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrtPurchaseOrders.Legends.Add(legend1);
            this.chrtPurchaseOrders.Location = new System.Drawing.Point(-22, 34);
            this.chrtPurchaseOrders.Name = "chrtPurchaseOrders";
            this.chrtPurchaseOrders.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "area";
            series1.CustomProperties = "DrawingStyle=Cylinder";
            series1.Legend = "Legend1";
            series1.Name = "series";
            series1.ToolTip = "#VAL{G}";
            series1.YValuesPerPoint = 2;
            series2.ChartArea = "area";
            series2.CustomProperties = "DrawingStyle=Cylinder";
            series2.Legend = "Legend1";
            series2.Name = "series2";
            series2.ToolTip = "#VAL{G}";
            this.chrtPurchaseOrders.Series.Add(series1);
            this.chrtPurchaseOrders.Series.Add(series2);
            this.chrtPurchaseOrders.Size = new System.Drawing.Size(1304, 218);
            this.chrtPurchaseOrders.TabIndex = 0;
            this.chrtPurchaseOrders.Text = "chart1";
            this.chrtPurchaseOrders.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chrtEarns_MouseMove);
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.Teal;
            this.pnlSettings.Controls.Add(this.btnReset);
            this.pnlSettings.Controls.Add(this.btnChangeColor);
            this.pnlSettings.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.pnlSettings.Location = new System.Drawing.Point(1073, 70);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(233, 66);
            this.pnlSettings.TabIndex = 34;
            this.pnlSettings.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(170, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(58, 51);
            this.btnReset.TabIndex = 36;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeColor.Location = new System.Drawing.Point(3, 6);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(164, 51);
            this.btnChangeColor.TabIndex = 35;
            this.btnChangeColor.Text = "Change Background Color";
            this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // grpVisit
            // 
            this.grpVisit.Controls.Add(this.label10);
            this.grpVisit.Controls.Add(this.label9);
            this.grpVisit.Controls.Add(this.btnNeedleToday);
            this.grpVisit.Controls.Add(this.btnNeedleYesterday);
            this.grpVisit.Controls.Add(this.lblSupplier2Code);
            this.grpVisit.Controls.Add(this.lblSupplier1Code);
            this.grpVisit.Controls.Add(this.lblSupplier2Name);
            this.grpVisit.Controls.Add(this.lblSupplier1Name);
            this.grpVisit.Controls.Add(this.guageSupplier1);
            this.grpVisit.Controls.Add(this.guageSupplier2);
            this.grpVisit.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.grpVisit.Location = new System.Drawing.Point(664, 348);
            this.grpVisit.Name = "grpVisit";
            this.grpVisit.Size = new System.Drawing.Size(317, 386);
            this.grpVisit.TabIndex = 7;
            this.grpVisit.TabStop = false;
            this.grpVisit.Text = "Purchase Wise Top 2 Suppliers";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label10.Location = new System.Drawing.Point(229, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 15);
            this.label10.TabIndex = 36;
            this.label10.Text = "Scale 1:10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label9.Location = new System.Drawing.Point(219, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 35;
            this.label9.Text = "Scale 1:10";
            // 
            // btnNeedleToday
            // 
            this.btnNeedleToday.Font = new System.Drawing.Font("Calibri", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnNeedleToday.Location = new System.Drawing.Point(11, 47);
            this.btnNeedleToday.Name = "btnNeedleToday";
            this.btnNeedleToday.Size = new System.Drawing.Size(46, 23);
            this.btnNeedleToday.TabIndex = 31;
            this.btnNeedleToday.Text = "Needle";
            this.btnNeedleToday.Click += new System.EventHandler(this.btnNeedleToday_Click);
            // 
            // btnNeedleYesterday
            // 
            this.btnNeedleYesterday.Font = new System.Drawing.Font("Calibri", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnNeedleYesterday.Location = new System.Drawing.Point(28, 230);
            this.btnNeedleYesterday.Name = "btnNeedleYesterday";
            this.btnNeedleYesterday.Size = new System.Drawing.Size(46, 23);
            this.btnNeedleYesterday.TabIndex = 32;
            this.btnNeedleYesterday.Text = "Needle";
            this.btnNeedleYesterday.Click += new System.EventHandler(this.btnNeedleYesterday_Click);
            // 
            // lblSupplier2Code
            // 
            this.lblSupplier2Code.AutoSize = true;
            this.lblSupplier2Code.BackColor = System.Drawing.Color.Teal;
            this.lblSupplier2Code.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSupplier2Code.Location = new System.Drawing.Point(13, 203);
            this.lblSupplier2Code.Name = "lblSupplier2Code";
            this.lblSupplier2Code.Size = new System.Drawing.Size(59, 15);
            this.lblSupplier2Code.TabIndex = 26;
            this.lblSupplier2Code.Text = "Supplier2";
            // 
            // lblSupplier1Code
            // 
            this.lblSupplier1Code.AutoSize = true;
            this.lblSupplier1Code.BackColor = System.Drawing.Color.Teal;
            this.lblSupplier1Code.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSupplier1Code.Location = new System.Drawing.Point(11, 20);
            this.lblSupplier1Code.Name = "lblSupplier1Code";
            this.lblSupplier1Code.Size = new System.Drawing.Size(59, 15);
            this.lblSupplier1Code.TabIndex = 3;
            this.lblSupplier1Code.Text = "Supplier1";
            // 
            // lblSupplier2Name
            // 
            this.lblSupplier2Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSupplier2Name.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblSupplier2Name.Location = new System.Drawing.Point(38, 340);
            this.lblSupplier2Name.Name = "lblSupplier2Name";
            this.lblSupplier2Name.Size = new System.Drawing.Size(254, 27);
            this.lblSupplier2Name.TabIndex = 23;
            this.lblSupplier2Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSupplier1Name
            // 
            this.lblSupplier1Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSupplier1Name.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblSupplier1Name.Location = new System.Drawing.Point(28, 157);
            this.lblSupplier1Name.Name = "lblSupplier1Name";
            this.lblSupplier1Name.Size = new System.Drawing.Size(254, 27);
            this.lblSupplier1Name.TabIndex = 21;
            this.lblSupplier1Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guageSupplier1
            // 
            this.guageSupplier1.BaseArcColor = System.Drawing.Color.Gray;
            this.guageSupplier1.BaseArcRadius = 150;
            this.guageSupplier1.BaseArcStart = 215;
            this.guageSupplier1.BaseArcSweep = 110;
            this.guageSupplier1.BaseArcWidth = 2;
            this.guageSupplier1.Cap_Idx = ((byte)(1));
            this.guageSupplier1.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.guageSupplier1.CapPosition = new System.Drawing.Point(10, 10);
            this.guageSupplier1.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.guageSupplier1.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
            this.guageSupplier1.CapText = "";
            this.guageSupplier1.Center = new System.Drawing.Point(150, 180);
            this.guageSupplier1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guageSupplier1.Location = new System.Drawing.Point(6, 39);
            this.guageSupplier1.MaxValue = 1000F;
            this.guageSupplier1.MinValue = 0F;
            this.guageSupplier1.Name = "guageSupplier1";
            this.guageSupplier1.NeedleColor1 = RIT.AGauge.NeedleColorEnum.Green;
            this.guageSupplier1.NeedleColor2 = System.Drawing.Color.DimGray;
            this.guageSupplier1.NeedleRadius = 150;
            this.guageSupplier1.NeedleType = 0;
            this.guageSupplier1.NeedleWidth = 5;
            this.guageSupplier1.Range_Idx = ((byte)(1));
            this.guageSupplier1.RangeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guageSupplier1.RangeEnabled = false;
            this.guageSupplier1.RangeEndValue = 400F;
            this.guageSupplier1.RangeInnerRadius = 10;
            this.guageSupplier1.RangeOuterRadius = 40;
            this.guageSupplier1.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.guageSupplier1.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.guageSupplier1.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.guageSupplier1.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.guageSupplier1.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.guageSupplier1.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.guageSupplier1.RangeStartValue = 300F;
            this.guageSupplier1.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.guageSupplier1.ScaleLinesInterInnerRadius = 145;
            this.guageSupplier1.ScaleLinesInterOuterRadius = 150;
            this.guageSupplier1.ScaleLinesInterWidth = 2;
            this.guageSupplier1.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.guageSupplier1.ScaleLinesMajorInnerRadius = 140;
            this.guageSupplier1.ScaleLinesMajorOuterRadius = 150;
            this.guageSupplier1.ScaleLinesMajorStepValue = 100F;
            this.guageSupplier1.ScaleLinesMajorWidth = 2;
            this.guageSupplier1.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.guageSupplier1.ScaleLinesMinorInnerRadius = 145;
            this.guageSupplier1.ScaleLinesMinorNumOf = 9;
            this.guageSupplier1.ScaleLinesMinorOuterRadius = 150;
            this.guageSupplier1.ScaleLinesMinorWidth = 1;
            this.guageSupplier1.ScaleNumbersColor = System.Drawing.Color.Black;
            this.guageSupplier1.ScaleNumbersFormat = null;
            this.guageSupplier1.ScaleNumbersRadius = 162;
            this.guageSupplier1.ScaleNumbersRotation = 90;
            this.guageSupplier1.ScaleNumbersStartScaleLine = 1;
            this.guageSupplier1.ScaleNumbersStepScaleLines = 2;
            this.guageSupplier1.Size = new System.Drawing.Size(304, 115);
            this.guageSupplier1.TabIndex = 20;
            this.guageSupplier1.Text = "aGauge4";
            this.guageSupplier1.Value = 0F;
            // 
            // guageSupplier2
            // 
            this.guageSupplier2.BaseArcColor = System.Drawing.Color.Gray;
            this.guageSupplier2.BaseArcRadius = 150;
            this.guageSupplier2.BaseArcStart = 215;
            this.guageSupplier2.BaseArcSweep = 110;
            this.guageSupplier2.BaseArcWidth = 2;
            this.guageSupplier2.Cap_Idx = ((byte)(1));
            this.guageSupplier2.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.guageSupplier2.CapPosition = new System.Drawing.Point(10, 10);
            this.guageSupplier2.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.guageSupplier2.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
            this.guageSupplier2.CapText = "";
            this.guageSupplier2.Center = new System.Drawing.Point(150, 180);
            this.guageSupplier2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guageSupplier2.Location = new System.Drawing.Point(10, 219);
            this.guageSupplier2.MaxValue = 1000F;
            this.guageSupplier2.MinValue = 0F;
            this.guageSupplier2.Name = "guageSupplier2";
            this.guageSupplier2.NeedleColor1 = RIT.AGauge.NeedleColorEnum.Green;
            this.guageSupplier2.NeedleColor2 = System.Drawing.Color.DimGray;
            this.guageSupplier2.NeedleRadius = 150;
            this.guageSupplier2.NeedleType = 0;
            this.guageSupplier2.NeedleWidth = 5;
            this.guageSupplier2.Range_Idx = ((byte)(1));
            this.guageSupplier2.RangeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guageSupplier2.RangeEnabled = false;
            this.guageSupplier2.RangeEndValue = 400F;
            this.guageSupplier2.RangeInnerRadius = 10;
            this.guageSupplier2.RangeOuterRadius = 40;
            this.guageSupplier2.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.guageSupplier2.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.guageSupplier2.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.guageSupplier2.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.guageSupplier2.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.guageSupplier2.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.guageSupplier2.RangeStartValue = 300F;
            this.guageSupplier2.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.guageSupplier2.ScaleLinesInterInnerRadius = 145;
            this.guageSupplier2.ScaleLinesInterOuterRadius = 150;
            this.guageSupplier2.ScaleLinesInterWidth = 2;
            this.guageSupplier2.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.guageSupplier2.ScaleLinesMajorInnerRadius = 140;
            this.guageSupplier2.ScaleLinesMajorOuterRadius = 150;
            this.guageSupplier2.ScaleLinesMajorStepValue = 100F;
            this.guageSupplier2.ScaleLinesMajorWidth = 2;
            this.guageSupplier2.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.guageSupplier2.ScaleLinesMinorInnerRadius = 145;
            this.guageSupplier2.ScaleLinesMinorNumOf = 9;
            this.guageSupplier2.ScaleLinesMinorOuterRadius = 150;
            this.guageSupplier2.ScaleLinesMinorWidth = 1;
            this.guageSupplier2.ScaleNumbersColor = System.Drawing.Color.Black;
            this.guageSupplier2.ScaleNumbersFormat = null;
            this.guageSupplier2.ScaleNumbersRadius = 162;
            this.guageSupplier2.ScaleNumbersRotation = 90;
            this.guageSupplier2.ScaleNumbersStartScaleLine = 1;
            this.guageSupplier2.ScaleNumbersStepScaleLines = 2;
            this.guageSupplier2.Size = new System.Drawing.Size(297, 118);
            this.guageSupplier2.TabIndex = 22;
            this.guageSupplier2.Text = "aGauge1";
            this.guageSupplier2.Value = 0F;
            // 
            // grpLocationSummery
            // 
            this.grpLocationSummery.Controls.Add(this.txtTopNSupplier);
            this.grpLocationSummery.Controls.Add(this.btnTopnSupplier);
            this.grpLocationSummery.Controls.Add(this.dgvTopSupplierSummery);
            this.grpLocationSummery.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLocationSummery.Location = new System.Drawing.Point(4, 348);
            this.grpLocationSummery.Name = "grpLocationSummery";
            this.grpLocationSummery.Size = new System.Drawing.Size(654, 321);
            this.grpLocationSummery.TabIndex = 30;
            this.grpLocationSummery.TabStop = false;
            this.grpLocationSummery.Text = "Sales Wise Top N Supplier Summery";
            // 
            // txtTopNSupplier
            // 
            this.txtTopNSupplier.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTopNSupplier.Location = new System.Drawing.Point(7, 23);
            this.txtTopNSupplier.Name = "txtTopNSupplier";
            this.txtTopNSupplier.Size = new System.Drawing.Size(100, 23);
            this.txtTopNSupplier.TabIndex = 38;
            // 
            // btnTopnSupplier
            // 
            this.btnTopnSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTopnSupplier.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopnSupplier.Location = new System.Drawing.Point(129, 22);
            this.btnTopnSupplier.Name = "btnTopnSupplier";
            this.btnTopnSupplier.Size = new System.Drawing.Size(124, 24);
            this.btnTopnSupplier.TabIndex = 37;
            this.btnTopnSupplier.Text = "Load Summery";
            this.btnTopnSupplier.Click += new System.EventHandler(this.btnTopnSupplier_Click);
            // 
            // dgvTopSupplierSummery
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.CadetBlue;
            this.dgvTopSupplierSummery.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTopSupplierSummery.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvTopSupplierSummery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopSupplierSummery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Location,
            this.TotalPurchases,
            this.TotalSales});
            this.dgvTopSupplierSummery.Location = new System.Drawing.Point(6, 53);
            this.dgvTopSupplierSummery.Name = "dgvTopSupplierSummery";
            this.dgvTopSupplierSummery.RowHeadersWidth = 4;
            this.dgvTopSupplierSummery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopSupplierSummery.Size = new System.Drawing.Size(642, 262);
            this.dgvTopSupplierSummery.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSupplierTo);
            this.groupBox1.Controls.Add(this.cmbSupplierFrom);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(526, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 54);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change Supplier Range";
            // 
            // cmbSupplierTo
            // 
            this.cmbSupplierTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSupplierTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSupplierTo.FormattingEnabled = true;
            this.cmbSupplierTo.Location = new System.Drawing.Point(287, 20);
            this.cmbSupplierTo.Name = "cmbSupplierTo";
            this.cmbSupplierTo.Size = new System.Drawing.Size(216, 23);
            this.cmbSupplierTo.TabIndex = 37;
            this.cmbSupplierTo.SelectedIndexChanged += new System.EventHandler(this.cmbSupplierTo_SelectedIndexChanged);
            // 
            // cmbSupplierFrom
            // 
            this.cmbSupplierFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSupplierFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSupplierFrom.FormattingEnabled = true;
            this.cmbSupplierFrom.Location = new System.Drawing.Point(52, 20);
            this.cmbSupplierFrom.Name = "cmbSupplierFrom";
            this.cmbSupplierFrom.Size = new System.Drawing.Size(204, 23);
            this.cmbSupplierFrom.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(262, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "To";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 15);
            this.label11.TabIndex = 8;
            this.label11.Text = "From";
            // 
            // Location
            // 
            this.Location.DataPropertyName = "SupplierCode";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Location.DefaultCellStyle = dataGridViewCellStyle2;
            this.Location.HeaderText = "Supplier Code";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Width = 120;
            // 
            // TotalPurchases
            // 
            this.TotalPurchases.DataPropertyName = "SupplierName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.TotalPurchases.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalPurchases.HeaderText = "Supplier Name";
            this.TotalPurchases.Name = "TotalPurchases";
            this.TotalPurchases.ReadOnly = true;
            this.TotalPurchases.Width = 340;
            // 
            // TotalSales
            // 
            this.TotalSales.DataPropertyName = "TotalSales";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.TotalSales.DefaultCellStyle = dataGridViewCellStyle4;
            this.TotalSales.HeaderText = "Total Sales";
            this.TotalSales.Name = "TotalSales";
            this.TotalSales.ReadOnly = true;
            this.TotalSales.Width = 150;
            // 
            // FrmSupplierPerformanceDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1350, 749);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ddControlTotalPurchasesTomorrow);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.grpVisit);
            this.Controls.Add(this.a1Panel1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grpDateRange);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpLocationSummery);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ddControlTotalPurchases);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmSupplierPerformanceDashBoard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSupplierPerformanceDashBoard";
            this.a1Panel1.ResumeLayout(false);
            this.grpDateRange.ResumeLayout(false);
            this.grpDateRange.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPurchaseOrders)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.grpVisit.ResumeLayout(false);
            this.grpVisit.PerformLayout();
            this.grpLocationSummery.ResumeLayout(false);
            this.grpLocationSummery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSupplierSummery)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel grpVisit;
        private System.Windows.Forms.Label lblSupplier2Name;
        private AGauge guageSupplier2;
        private AGauge guageSupplier1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtPurchaseOrders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Panel grpDateRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Panel grpLocationSummery;
        private System.Windows.Forms.Label lblSupplier2Code;
        private System.Windows.Forms.Label lblSupplier1Code;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnNeedleToday;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnNeedleYesterday;
        private System.Windows.Forms.Label lblYValueEarn;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnRefresh;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnClose;
        private System.Windows.Forms.DataGridView dgvTopSupplierSummery;
        private System.Windows.Forms.Panel pnlSettings;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnSettings;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnChangeColor;
        private System.Windows.Forms.ColorDialog clrDialog;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnReset;
        private Owf.Controls.DigitalDisplayControl digitalDisplayControl1;
        private Owf.Controls.A1Panel a1Panel1;
        private System.Windows.Forms.Timer timer1;
        private Owf.Controls.DigitalDisplayControl ddControlTotalPurchases;
        private System.Windows.Forms.Label label5;
        private Owf.Controls.DigitalDisplayControl ddControlTotalPurchasesTomorrow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbSupplierFrom;
        private System.Windows.Forms.ComboBox cmbSupplierTo;
        private System.Windows.Forms.Label lblSupplier1Name;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnTopnSupplier;
        private System.Windows.Forms.TextBox txtTopNSupplier;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPurchases;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSales;
    }
}