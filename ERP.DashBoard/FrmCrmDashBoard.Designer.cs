using RIT;

namespace ERP.DashBoard
{
    partial class FrmCrmDashBoard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.clrDialog = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.a1Panel3 = new Owf.Controls.A1Panel();
            this.ddControlTotalPurchasesTomorrow = new Owf.Controls.DigitalDisplayControl();
            this.label6 = new System.Windows.Forms.Label();
            this.a1Panel2 = new Owf.Controls.A1Panel();
            this.ddControlTotalPurchases = new Owf.Controls.DigitalDisplayControl();
            this.label5 = new System.Windows.Forms.Label();
            this.a1Panel1 = new Owf.Controls.A1Panel();
            this.digitalDisplayControl1 = new Owf.Controls.DigitalDisplayControl();
            this.btnSettings = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.lblTotalPoints = new System.Windows.Forms.Label();
            this.btnClose = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnRefresh = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.grpDateRange = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDateEarn = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDateEarn = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblYValueRedeem = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chrtRedeems = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnReset = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnChangeColor = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.groupBox2 = new System.Windows.Forms.Panel();
            this.cmbChartTypeEarns = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.Panel();
            this.cmbChartTypeRedeems = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblYValueEarn = new System.Windows.Forms.Label();
            this.chrtEarns = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpVisit = new System.Windows.Forms.Panel();
            this.btnNeedleExpected = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnNeedleToday = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnNeedleYesterday = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblExpectedVisit = new System.Windows.Forms.Label();
            this.lblYesterdayVisit = new System.Windows.Forms.Label();
            this.lblTodayVisit = new System.Windows.Forms.Label();
            this.lblExpected = new System.Windows.Forms.Label();
            this.guageExpectedVisit = new RIT.AGauge();
            this.lblYesterday = new System.Windows.Forms.Label();
            this.guageYesterDayVisit = new RIT.AGauge();
            this.lblToday = new System.Windows.Forms.Label();
            this.guageTodayVisit = new RIT.AGauge();
            this.grpLocationSummery = new System.Windows.Forms.Panel();
            this.dgvLocationSummery = new System.Windows.Forms.DataGridView();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPurchases = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a1Panel3.SuspendLayout();
            this.a1Panel2.SuspendLayout();
            this.a1Panel1.SuspendLayout();
            this.grpDateRange.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtRedeems)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtEarns)).BeginInit();
            this.grpVisit.SuspendLayout();
            this.grpLocationSummery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocationSummery)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // a1Panel3
            // 
            this.a1Panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.a1Panel3.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel3.Controls.Add(this.ddControlTotalPurchasesTomorrow);
            this.a1Panel3.Controls.Add(this.label6);
            this.a1Panel3.GradientEndColor = System.Drawing.SystemColors.MenuHighlight;
            this.a1Panel3.GradientStartColor = System.Drawing.Color.Thistle;
            this.a1Panel3.Image = null;
            this.a1Panel3.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel3.Location = new System.Drawing.Point(751, 647);
            this.a1Panel3.Name = "a1Panel3";
            this.a1Panel3.RoundCornerRadius = 29;
            this.a1Panel3.ShadowOffSet = 12;
            this.a1Panel3.Size = new System.Drawing.Size(607, 100);
            this.a1Panel3.TabIndex = 2;
            // 
            // ddControlTotalPurchasesTomorrow
            // 
            this.ddControlTotalPurchasesTomorrow.BackColor = System.Drawing.Color.Transparent;
            this.ddControlTotalPurchasesTomorrow.DigitColor = System.Drawing.Color.RoyalBlue;
            this.ddControlTotalPurchasesTomorrow.DigitText = "17866.99";
            this.ddControlTotalPurchasesTomorrow.Location = new System.Drawing.Point(396, 10);
            this.ddControlTotalPurchasesTomorrow.Name = "ddControlTotalPurchasesTomorrow";
            this.ddControlTotalPurchasesTomorrow.Size = new System.Drawing.Size(175, 70);
            this.ddControlTotalPurchasesTomorrow.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(8, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(399, 24);
            this.label6.TabIndex = 3;
            this.label6.Text = "Expected Purchases Tomorrow : ";
            // 
            // a1Panel2
            // 
            this.a1Panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.a1Panel2.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel2.Controls.Add(this.ddControlTotalPurchases);
            this.a1Panel2.Controls.Add(this.label5);
            this.a1Panel2.GradientEndColor = System.Drawing.SystemColors.MenuHighlight;
            this.a1Panel2.GradientStartColor = System.Drawing.Color.Thistle;
            this.a1Panel2.Image = null;
            this.a1Panel2.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel2.Location = new System.Drawing.Point(210, 648);
            this.a1Panel2.Name = "a1Panel2";
            this.a1Panel2.RoundCornerRadius = 29;
            this.a1Panel2.ShadowOffSet = 12;
            this.a1Panel2.Size = new System.Drawing.Size(537, 100);
            this.a1Panel2.TabIndex = 1;
            // 
            // ddControlTotalPurchases
            // 
            this.ddControlTotalPurchases.BackColor = System.Drawing.Color.Transparent;
            this.ddControlTotalPurchases.DigitColor = System.Drawing.Color.RoyalBlue;
            this.ddControlTotalPurchases.DigitText = "17866.99";
            this.ddControlTotalPurchases.Location = new System.Drawing.Point(315, 9);
            this.ddControlTotalPurchases.Name = "ddControlTotalPurchases";
            this.ddControlTotalPurchases.Size = new System.Drawing.Size(175, 70);
            this.ddControlTotalPurchases.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(18, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Purchases Today : ";
            // 
            // a1Panel1
            // 
            this.a1Panel1.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel1.Controls.Add(this.digitalDisplayControl1);
            this.a1Panel1.GradientEndColor = System.Drawing.SystemColors.MenuHighlight;
            this.a1Panel1.GradientStartColor = System.Drawing.Color.Thistle;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(4, 646);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.RoundCornerRadius = 29;
            this.a1Panel1.ShadowOffSet = 12;
            this.a1Panel1.Size = new System.Drawing.Size(203, 100);
            this.a1Panel1.TabIndex = 36;
            // 
            // digitalDisplayControl1
            // 
            this.digitalDisplayControl1.BackColor = System.Drawing.Color.Transparent;
            this.digitalDisplayControl1.DigitColor = System.Drawing.Color.RoyalBlue;
            this.digitalDisplayControl1.Location = new System.Drawing.Point(6, 13);
            this.digitalDisplayControl1.Name = "digitalDisplayControl1";
            this.digitalDisplayControl1.Size = new System.Drawing.Size(170, 60);
            this.digitalDisplayControl1.TabIndex = 35;
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = global::ERP.DashBoard.Properties.Resources.settings_icon32;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSettings.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(548, 15);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(69, 53);
            this.btnSettings.TabIndex = 34;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.BackColor = System.Drawing.Color.Teal;
            this.lblTotalCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalCustomers.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCustomers.Location = new System.Drawing.Point(787, 598);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(298, 27);
            this.lblTotalCustomers.TabIndex = 33;
            this.lblTotalCustomers.Text = "Total Registered Customers : ";
            this.lblTotalCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalPoints
            // 
            this.lblTotalPoints.BackColor = System.Drawing.Color.Teal;
            this.lblTotalPoints.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalPoints.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPoints.Location = new System.Drawing.Point(786, 546);
            this.lblTotalPoints.Name = "lblTotalPoints";
            this.lblTotalPoints.Size = new System.Drawing.Size(299, 27);
            this.lblTotalPoints.TabIndex = 27;
            this.lblTotalPoints.Text = "Total Points : ";
            this.lblTotalPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::ERP.DashBoard.Properties.Resources.Actions_window_close_icon;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(629, 15);
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
            this.btnRefresh.Location = new System.Drawing.Point(711, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(69, 53);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpDateRange
            // 
            this.grpDateRange.Controls.Add(this.label4);
            this.grpDateRange.Controls.Add(this.label1);
            this.grpDateRange.Controls.Add(this.dtpToDateEarn);
            this.grpDateRange.Controls.Add(this.dtpFromDateEarn);
            this.grpDateRange.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDateRange.Location = new System.Drawing.Point(6, 7);
            this.grpDateRange.Name = "grpDateRange";
            this.grpDateRange.Size = new System.Drawing.Size(514, 64);
            this.grpDateRange.TabIndex = 6;
            this.grpDateRange.TabStop = false;
            this.grpDateRange.Text = "Change Date Range";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "From";
            // 
            // dtpToDateEarn
            // 
            this.dtpToDateEarn.Location = new System.Drawing.Point(287, 28);
            this.dtpToDateEarn.Name = "dtpToDateEarn";
            this.dtpToDateEarn.Size = new System.Drawing.Size(216, 23);
            this.dtpToDateEarn.TabIndex = 9;
            this.dtpToDateEarn.ValueChanged += new System.EventHandler(this.dtpToDateEarn_ValueChanged);
            // 
            // dtpFromDateEarn
            // 
            this.dtpFromDateEarn.Location = new System.Drawing.Point(52, 28);
            this.dtpFromDateEarn.Name = "dtpFromDateEarn";
            this.dtpFromDateEarn.Size = new System.Drawing.Size(204, 23);
            this.dtpFromDateEarn.TabIndex = 8;
            this.dtpFromDateEarn.ValueChanged += new System.EventHandler(this.dtpFromDateEarn_ValueChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.lblYValueRedeem);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.chrtRedeems);
            this.panel4.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.panel4.Location = new System.Drawing.Point(5, 358);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(775, 271);
            this.panel4.TabIndex = 2;
            // 
            // lblYValueRedeem
            // 
            this.lblYValueRedeem.AutoSize = true;
            this.lblYValueRedeem.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblYValueRedeem.Location = new System.Drawing.Point(386, 11);
            this.lblYValueRedeem.Name = "lblYValueRedeem";
            this.lblYValueRedeem.Size = new System.Drawing.Size(46, 15);
            this.lblYValueRedeem.TabIndex = 4;
            this.lblYValueRedeem.Text = "Value : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label3.Location = new System.Drawing.Point(125, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Location Wise Points Redeem";
            // 
            // chrtRedeems
            // 
            this.chrtRedeems.BackColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Name = "area";
            this.chrtRedeems.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrtRedeems.Legends.Add(legend1);
            this.chrtRedeems.Location = new System.Drawing.Point(-24, 33);
            this.chrtRedeems.Name = "chrtRedeems";
            series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            series1.ChartArea = "area";
            series1.CustomProperties = "DrawingStyle=Emboss";
            series1.Legend = "Legend1";
            series1.Name = "series";
            series1.ToolTip = "#VAL{G}";
            this.chrtRedeems.Series.Add(series1);
            this.chrtRedeems.Size = new System.Drawing.Size(766, 218);
            this.chrtRedeems.TabIndex = 0;
            this.chrtRedeems.Text = "chart4";
            this.chrtRedeems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chrtRedeems_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pnlSettings);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblYValueEarn);
            this.panel1.Controls.Add(this.chrtEarns);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.panel1.Location = new System.Drawing.Point(5, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 271);
            this.panel1.TabIndex = 1;
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.Teal;
            this.pnlSettings.Controls.Add(this.btnReset);
            this.pnlSettings.Controls.Add(this.btnChangeColor);
            this.pnlSettings.Controls.Add(this.groupBox2);
            this.pnlSettings.Controls.Add(this.groupBox5);
            this.pnlSettings.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.pnlSettings.Location = new System.Drawing.Point(539, 3);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(233, 201);
            this.pnlSettings.TabIndex = 34;
            this.pnlSettings.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(172, 141);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(58, 51);
            this.btnReset.TabIndex = 36;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeColor.Location = new System.Drawing.Point(5, 141);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(164, 51);
            this.btnChangeColor.TabIndex = 35;
            this.btnChangeColor.Text = "Change Background Color";
            this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbChartTypeEarns);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(5, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 64);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change Chart 1 Style";
            // 
            // cmbChartTypeEarns
            // 
            this.cmbChartTypeEarns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChartTypeEarns.FormattingEnabled = true;
            this.cmbChartTypeEarns.Location = new System.Drawing.Point(10, 25);
            this.cmbChartTypeEarns.Name = "cmbChartTypeEarns";
            this.cmbChartTypeEarns.Size = new System.Drawing.Size(200, 23);
            this.cmbChartTypeEarns.TabIndex = 4;
            this.cmbChartTypeEarns.SelectedIndexChanged += new System.EventHandler(this.cmbChartTypeEarns_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbChartTypeRedeems);
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.groupBox5.Location = new System.Drawing.Point(5, 70);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(219, 64);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Change Chart 2 Style";
            // 
            // cmbChartTypeRedeems
            // 
            this.cmbChartTypeRedeems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChartTypeRedeems.FormattingEnabled = true;
            this.cmbChartTypeRedeems.Location = new System.Drawing.Point(10, 25);
            this.cmbChartTypeRedeems.Name = "cmbChartTypeRedeems";
            this.cmbChartTypeRedeems.Size = new System.Drawing.Size(200, 23);
            this.cmbChartTypeRedeems.TabIndex = 4;
            this.cmbChartTypeRedeems.SelectedIndexChanged += new System.EventHandler(this.cmbChartTypeRedeems_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label2.Location = new System.Drawing.Point(125, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Location Wise Points Earn";
            // 
            // lblYValueEarn
            // 
            this.lblYValueEarn.AutoSize = true;
            this.lblYValueEarn.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblYValueEarn.Location = new System.Drawing.Point(386, 16);
            this.lblYValueEarn.Name = "lblYValueEarn";
            this.lblYValueEarn.Size = new System.Drawing.Size(46, 15);
            this.lblYValueEarn.TabIndex = 3;
            this.lblYValueEarn.Text = "Value : ";
            // 
            // chrtEarns
            // 
            this.chrtEarns.BackColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            chartArea2.Name = "area";
            this.chrtEarns.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrtEarns.Legends.Add(legend2);
            this.chrtEarns.Location = new System.Drawing.Point(-26, 34);
            this.chrtEarns.Name = "chrtEarns";
            this.chrtEarns.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            series2.ChartArea = "area";
            series2.CustomProperties = "DrawingStyle=Cylinder";
            series2.Legend = "Legend1";
            series2.Name = "series";
            series2.ToolTip = "#VAL{G}";
            series2.YValuesPerPoint = 2;
            this.chrtEarns.Series.Add(series2);
            this.chrtEarns.Size = new System.Drawing.Size(766, 218);
            this.chrtEarns.TabIndex = 0;
            this.chrtEarns.Text = "chart1";
            this.chrtEarns.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chrtEarns_MouseMove);
            // 
            // grpVisit
            // 
            this.grpVisit.Controls.Add(this.btnNeedleExpected);
            this.grpVisit.Controls.Add(this.btnNeedleToday);
            this.grpVisit.Controls.Add(this.btnNeedleYesterday);
            this.grpVisit.Controls.Add(this.label10);
            this.grpVisit.Controls.Add(this.label9);
            this.grpVisit.Controls.Add(this.label8);
            this.grpVisit.Controls.Add(this.lblExpectedVisit);
            this.grpVisit.Controls.Add(this.lblYesterdayVisit);
            this.grpVisit.Controls.Add(this.lblTodayVisit);
            this.grpVisit.Controls.Add(this.lblExpected);
            this.grpVisit.Controls.Add(this.guageExpectedVisit);
            this.grpVisit.Controls.Add(this.lblYesterday);
            this.grpVisit.Controls.Add(this.guageYesterDayVisit);
            this.grpVisit.Controls.Add(this.lblToday);
            this.grpVisit.Controls.Add(this.guageTodayVisit);
            this.grpVisit.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.grpVisit.Location = new System.Drawing.Point(786, 9);
            this.grpVisit.Name = "grpVisit";
            this.grpVisit.Size = new System.Drawing.Size(299, 512);
            this.grpVisit.TabIndex = 7;
            this.grpVisit.TabStop = false;
            this.grpVisit.Text = "Customer Visit";
            // 
            // btnNeedleExpected
            // 
            this.btnNeedleExpected.Font = new System.Drawing.Font("Calibri", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnNeedleExpected.Location = new System.Drawing.Point(6, 380);
            this.btnNeedleExpected.Name = "btnNeedleExpected";
            this.btnNeedleExpected.Size = new System.Drawing.Size(46, 23);
            this.btnNeedleExpected.TabIndex = 33;
            this.btnNeedleExpected.Text = "Needle";
            this.btnNeedleExpected.Click += new System.EventHandler(this.btnNeedleExpected_Click);
            // 
            // btnNeedleToday
            // 
            this.btnNeedleToday.Font = new System.Drawing.Font("Calibri", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnNeedleToday.Location = new System.Drawing.Point(6, 45);
            this.btnNeedleToday.Name = "btnNeedleToday";
            this.btnNeedleToday.Size = new System.Drawing.Size(46, 23);
            this.btnNeedleToday.TabIndex = 31;
            this.btnNeedleToday.Text = "Needle";
            this.btnNeedleToday.Click += new System.EventHandler(this.btnNeedleToday_Click);
            // 
            // btnNeedleYesterday
            // 
            this.btnNeedleYesterday.Font = new System.Drawing.Font("Calibri", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnNeedleYesterday.Location = new System.Drawing.Point(6, 213);
            this.btnNeedleYesterday.Name = "btnNeedleYesterday";
            this.btnNeedleYesterday.Size = new System.Drawing.Size(46, 23);
            this.btnNeedleYesterday.TabIndex = 32;
            this.btnNeedleYesterday.Text = "Needle";
            this.btnNeedleYesterday.Click += new System.EventHandler(this.btnNeedleYesterday_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label10.Location = new System.Drawing.Point(219, 358);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 15);
            this.label10.TabIndex = 29;
            this.label10.Text = "Scale 1:10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label9.Location = new System.Drawing.Point(217, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "Scale 1:10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label8.Location = new System.Drawing.Point(217, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Scale 1:10";
            // 
            // lblExpectedVisit
            // 
            this.lblExpectedVisit.AutoSize = true;
            this.lblExpectedVisit.BackColor = System.Drawing.Color.Teal;
            this.lblExpectedVisit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblExpectedVisit.Location = new System.Drawing.Point(6, 357);
            this.lblExpectedVisit.Name = "lblExpectedVisit";
            this.lblExpectedVisit.Size = new System.Drawing.Size(81, 15);
            this.lblExpectedVisit.TabIndex = 27;
            this.lblExpectedVisit.Text = "ExpectedVisit";
            // 
            // lblYesterdayVisit
            // 
            this.lblYesterdayVisit.AutoSize = true;
            this.lblYesterdayVisit.BackColor = System.Drawing.Color.Teal;
            this.lblYesterdayVisit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblYesterdayVisit.Location = new System.Drawing.Point(6, 190);
            this.lblYesterdayVisit.Name = "lblYesterdayVisit";
            this.lblYesterdayVisit.Size = new System.Drawing.Size(61, 15);
            this.lblYesterdayVisit.TabIndex = 26;
            this.lblYesterdayVisit.Text = "Yesterday";
            // 
            // lblTodayVisit
            // 
            this.lblTodayVisit.AutoSize = true;
            this.lblTodayVisit.BackColor = System.Drawing.Color.Teal;
            this.lblTodayVisit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTodayVisit.Location = new System.Drawing.Point(6, 21);
            this.lblTodayVisit.Name = "lblTodayVisit";
            this.lblTodayVisit.Size = new System.Drawing.Size(38, 15);
            this.lblTodayVisit.TabIndex = 3;
            this.lblTodayVisit.Text = "Today";
            // 
            // lblExpected
            // 
            this.lblExpected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExpected.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblExpected.Location = new System.Drawing.Point(23, 479);
            this.lblExpected.Name = "lblExpected";
            this.lblExpected.Size = new System.Drawing.Size(254, 27);
            this.lblExpected.TabIndex = 25;
            this.lblExpected.Text = "Expected Tomorrow : ";
            this.lblExpected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guageExpectedVisit
            // 
            this.guageExpectedVisit.BaseArcColor = System.Drawing.Color.Gray;
            this.guageExpectedVisit.BaseArcRadius = 150;
            this.guageExpectedVisit.BaseArcStart = 215;
            this.guageExpectedVisit.BaseArcSweep = 110;
            this.guageExpectedVisit.BaseArcWidth = 2;
            this.guageExpectedVisit.Cap_Idx = ((byte)(1));
            this.guageExpectedVisit.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.guageExpectedVisit.CapPosition = new System.Drawing.Point(10, 10);
            this.guageExpectedVisit.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.guageExpectedVisit.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
            this.guageExpectedVisit.CapText = "";
            this.guageExpectedVisit.Center = new System.Drawing.Point(150, 180);
            this.guageExpectedVisit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guageExpectedVisit.Location = new System.Drawing.Point(1, 367);
            this.guageExpectedVisit.MaxValue = 1000F;
            this.guageExpectedVisit.MinValue = 0F;
            this.guageExpectedVisit.Name = "guageExpectedVisit";
            this.guageExpectedVisit.NeedleColor1 = RIT.AGauge.NeedleColorEnum.Green;
            this.guageExpectedVisit.NeedleColor2 = System.Drawing.Color.DimGray;
            this.guageExpectedVisit.NeedleRadius = 150;
            this.guageExpectedVisit.NeedleType = 0;
            this.guageExpectedVisit.NeedleWidth = 5;
            this.guageExpectedVisit.Range_Idx = ((byte)(1));
            this.guageExpectedVisit.RangeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guageExpectedVisit.RangeEnabled = false;
            this.guageExpectedVisit.RangeEndValue = 400F;
            this.guageExpectedVisit.RangeInnerRadius = 10;
            this.guageExpectedVisit.RangeOuterRadius = 40;
            this.guageExpectedVisit.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.guageExpectedVisit.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.guageExpectedVisit.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.guageExpectedVisit.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.guageExpectedVisit.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.guageExpectedVisit.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.guageExpectedVisit.RangeStartValue = 300F;
            this.guageExpectedVisit.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.guageExpectedVisit.ScaleLinesInterInnerRadius = 145;
            this.guageExpectedVisit.ScaleLinesInterOuterRadius = 150;
            this.guageExpectedVisit.ScaleLinesInterWidth = 2;
            this.guageExpectedVisit.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.guageExpectedVisit.ScaleLinesMajorInnerRadius = 140;
            this.guageExpectedVisit.ScaleLinesMajorOuterRadius = 150;
            this.guageExpectedVisit.ScaleLinesMajorStepValue = 100F;
            this.guageExpectedVisit.ScaleLinesMajorWidth = 2;
            this.guageExpectedVisit.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.guageExpectedVisit.ScaleLinesMinorInnerRadius = 145;
            this.guageExpectedVisit.ScaleLinesMinorNumOf = 9;
            this.guageExpectedVisit.ScaleLinesMinorOuterRadius = 150;
            this.guageExpectedVisit.ScaleLinesMinorWidth = 1;
            this.guageExpectedVisit.ScaleNumbersColor = System.Drawing.Color.Black;
            this.guageExpectedVisit.ScaleNumbersFormat = null;
            this.guageExpectedVisit.ScaleNumbersRadius = 162;
            this.guageExpectedVisit.ScaleNumbersRotation = 90;
            this.guageExpectedVisit.ScaleNumbersStartScaleLine = 1;
            this.guageExpectedVisit.ScaleNumbersStepScaleLines = 2;
            this.guageExpectedVisit.Size = new System.Drawing.Size(297, 107);
            this.guageExpectedVisit.TabIndex = 24;
            this.guageExpectedVisit.Text = "aGauge2";
            this.guageExpectedVisit.Value = 0F;
            // 
            // lblYesterday
            // 
            this.lblYesterday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYesterday.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblYesterday.Location = new System.Drawing.Point(23, 316);
            this.lblYesterday.Name = "lblYesterday";
            this.lblYesterday.Size = new System.Drawing.Size(254, 27);
            this.lblYesterday.TabIndex = 23;
            this.lblYesterday.Text = "Yesterday : ";
            this.lblYesterday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guageYesterDayVisit
            // 
            this.guageYesterDayVisit.BaseArcColor = System.Drawing.Color.Gray;
            this.guageYesterDayVisit.BaseArcRadius = 150;
            this.guageYesterDayVisit.BaseArcStart = 215;
            this.guageYesterDayVisit.BaseArcSweep = 110;
            this.guageYesterDayVisit.BaseArcWidth = 2;
            this.guageYesterDayVisit.Cap_Idx = ((byte)(1));
            this.guageYesterDayVisit.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.guageYesterDayVisit.CapPosition = new System.Drawing.Point(10, 10);
            this.guageYesterDayVisit.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.guageYesterDayVisit.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
            this.guageYesterDayVisit.CapText = "";
            this.guageYesterDayVisit.Center = new System.Drawing.Point(150, 180);
            this.guageYesterDayVisit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guageYesterDayVisit.Location = new System.Drawing.Point(1, 204);
            this.guageYesterDayVisit.MaxValue = 1000F;
            this.guageYesterDayVisit.MinValue = 0F;
            this.guageYesterDayVisit.Name = "guageYesterDayVisit";
            this.guageYesterDayVisit.NeedleColor1 = RIT.AGauge.NeedleColorEnum.Green;
            this.guageYesterDayVisit.NeedleColor2 = System.Drawing.Color.DimGray;
            this.guageYesterDayVisit.NeedleRadius = 150;
            this.guageYesterDayVisit.NeedleType = 0;
            this.guageYesterDayVisit.NeedleWidth = 5;
            this.guageYesterDayVisit.Range_Idx = ((byte)(1));
            this.guageYesterDayVisit.RangeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guageYesterDayVisit.RangeEnabled = false;
            this.guageYesterDayVisit.RangeEndValue = 400F;
            this.guageYesterDayVisit.RangeInnerRadius = 10;
            this.guageYesterDayVisit.RangeOuterRadius = 40;
            this.guageYesterDayVisit.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.guageYesterDayVisit.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.guageYesterDayVisit.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.guageYesterDayVisit.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.guageYesterDayVisit.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.guageYesterDayVisit.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.guageYesterDayVisit.RangeStartValue = 300F;
            this.guageYesterDayVisit.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.guageYesterDayVisit.ScaleLinesInterInnerRadius = 145;
            this.guageYesterDayVisit.ScaleLinesInterOuterRadius = 150;
            this.guageYesterDayVisit.ScaleLinesInterWidth = 2;
            this.guageYesterDayVisit.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.guageYesterDayVisit.ScaleLinesMajorInnerRadius = 140;
            this.guageYesterDayVisit.ScaleLinesMajorOuterRadius = 150;
            this.guageYesterDayVisit.ScaleLinesMajorStepValue = 100F;
            this.guageYesterDayVisit.ScaleLinesMajorWidth = 2;
            this.guageYesterDayVisit.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.guageYesterDayVisit.ScaleLinesMinorInnerRadius = 145;
            this.guageYesterDayVisit.ScaleLinesMinorNumOf = 9;
            this.guageYesterDayVisit.ScaleLinesMinorOuterRadius = 150;
            this.guageYesterDayVisit.ScaleLinesMinorWidth = 1;
            this.guageYesterDayVisit.ScaleNumbersColor = System.Drawing.Color.Black;
            this.guageYesterDayVisit.ScaleNumbersFormat = null;
            this.guageYesterDayVisit.ScaleNumbersRadius = 162;
            this.guageYesterDayVisit.ScaleNumbersRotation = 90;
            this.guageYesterDayVisit.ScaleNumbersStartScaleLine = 1;
            this.guageYesterDayVisit.ScaleNumbersStepScaleLines = 2;
            this.guageYesterDayVisit.Size = new System.Drawing.Size(297, 107);
            this.guageYesterDayVisit.TabIndex = 22;
            this.guageYesterDayVisit.Text = "aGauge1";
            this.guageYesterDayVisit.Value = 0F;
            // 
            // lblToday
            // 
            this.lblToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToday.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblToday.Location = new System.Drawing.Point(23, 149);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(254, 27);
            this.lblToday.TabIndex = 21;
            this.lblToday.Text = "Today : ";
            this.lblToday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guageTodayVisit
            // 
            this.guageTodayVisit.BaseArcColor = System.Drawing.Color.Gray;
            this.guageTodayVisit.BaseArcRadius = 150;
            this.guageTodayVisit.BaseArcStart = 215;
            this.guageTodayVisit.BaseArcSweep = 110;
            this.guageTodayVisit.BaseArcWidth = 2;
            this.guageTodayVisit.Cap_Idx = ((byte)(1));
            this.guageTodayVisit.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.guageTodayVisit.CapPosition = new System.Drawing.Point(10, 10);
            this.guageTodayVisit.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.guageTodayVisit.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
            this.guageTodayVisit.CapText = "";
            this.guageTodayVisit.Center = new System.Drawing.Point(150, 180);
            this.guageTodayVisit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guageTodayVisit.Location = new System.Drawing.Point(1, 37);
            this.guageTodayVisit.MaxValue = 1000F;
            this.guageTodayVisit.MinValue = 0F;
            this.guageTodayVisit.Name = "guageTodayVisit";
            this.guageTodayVisit.NeedleColor1 = RIT.AGauge.NeedleColorEnum.Green;
            this.guageTodayVisit.NeedleColor2 = System.Drawing.Color.DimGray;
            this.guageTodayVisit.NeedleRadius = 150;
            this.guageTodayVisit.NeedleType = 0;
            this.guageTodayVisit.NeedleWidth = 5;
            this.guageTodayVisit.Range_Idx = ((byte)(1));
            this.guageTodayVisit.RangeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guageTodayVisit.RangeEnabled = false;
            this.guageTodayVisit.RangeEndValue = 400F;
            this.guageTodayVisit.RangeInnerRadius = 10;
            this.guageTodayVisit.RangeOuterRadius = 40;
            this.guageTodayVisit.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.guageTodayVisit.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.guageTodayVisit.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.guageTodayVisit.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.guageTodayVisit.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.guageTodayVisit.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.guageTodayVisit.RangeStartValue = 300F;
            this.guageTodayVisit.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.guageTodayVisit.ScaleLinesInterInnerRadius = 145;
            this.guageTodayVisit.ScaleLinesInterOuterRadius = 150;
            this.guageTodayVisit.ScaleLinesInterWidth = 2;
            this.guageTodayVisit.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.guageTodayVisit.ScaleLinesMajorInnerRadius = 140;
            this.guageTodayVisit.ScaleLinesMajorOuterRadius = 150;
            this.guageTodayVisit.ScaleLinesMajorStepValue = 100F;
            this.guageTodayVisit.ScaleLinesMajorWidth = 2;
            this.guageTodayVisit.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.guageTodayVisit.ScaleLinesMinorInnerRadius = 145;
            this.guageTodayVisit.ScaleLinesMinorNumOf = 9;
            this.guageTodayVisit.ScaleLinesMinorOuterRadius = 150;
            this.guageTodayVisit.ScaleLinesMinorWidth = 1;
            this.guageTodayVisit.ScaleNumbersColor = System.Drawing.Color.Black;
            this.guageTodayVisit.ScaleNumbersFormat = null;
            this.guageTodayVisit.ScaleNumbersRadius = 162;
            this.guageTodayVisit.ScaleNumbersRotation = 90;
            this.guageTodayVisit.ScaleNumbersStartScaleLine = 1;
            this.guageTodayVisit.ScaleNumbersStepScaleLines = 2;
            this.guageTodayVisit.Size = new System.Drawing.Size(297, 107);
            this.guageTodayVisit.TabIndex = 20;
            this.guageTodayVisit.Text = "aGauge4";
            this.guageTodayVisit.Value = 0F;
            // 
            // grpLocationSummery
            // 
            this.grpLocationSummery.Controls.Add(this.dgvLocationSummery);
            this.grpLocationSummery.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLocationSummery.Location = new System.Drawing.Point(1091, 9);
            this.grpLocationSummery.Name = "grpLocationSummery";
            this.grpLocationSummery.Size = new System.Drawing.Size(254, 620);
            this.grpLocationSummery.TabIndex = 30;
            this.grpLocationSummery.TabStop = false;
            this.grpLocationSummery.Text = "Location Summary";
            // 
            // dgvLocationSummery
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.CadetBlue;
            this.dgvLocationSummery.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocationSummery.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvLocationSummery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocationSummery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Location,
            this.TotalPurchases});
            this.dgvLocationSummery.Location = new System.Drawing.Point(6, 21);
            this.dgvLocationSummery.Name = "dgvLocationSummery";
            this.dgvLocationSummery.RowHeadersWidth = 4;
            this.dgvLocationSummery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocationSummery.Size = new System.Drawing.Size(245, 586);
            this.dgvLocationSummery.TabIndex = 0;
            // 
            // Location
            // 
            this.Location.DataPropertyName = "LocationName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Location.DefaultCellStyle = dataGridViewCellStyle2;
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Width = 120;
            // 
            // TotalPurchases
            // 
            this.TotalPurchases.DataPropertyName = "TotalPurchases";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.TotalPurchases.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalPurchases.HeaderText = "Total Purchases";
            this.TotalPurchases.Name = "TotalPurchases";
            this.TotalPurchases.ReadOnly = true;
            // 
            // FrmCrmDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1350, 749);
            this.Controls.Add(this.a1Panel3);
            this.Controls.Add(this.a1Panel2);
            this.Controls.Add(this.a1Panel1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lblTotalCustomers);
            this.Controls.Add(this.lblTotalPoints);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grpDateRange);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpVisit);
            this.Controls.Add(this.grpLocationSummery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmCrmDashBoard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCrmDashBoard";
            this.a1Panel3.ResumeLayout(false);
            this.a1Panel3.PerformLayout();
            this.a1Panel2.ResumeLayout(false);
            this.a1Panel2.PerformLayout();
            this.a1Panel1.ResumeLayout(false);
            this.grpDateRange.ResumeLayout(false);
            this.grpDateRange.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtRedeems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrtEarns)).EndInit();
            this.grpVisit.ResumeLayout(false);
            this.grpVisit.PerformLayout();
            this.grpLocationSummery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocationSummery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel grpVisit;
        private System.Windows.Forms.Label lblExpected;
        private AGauge guageExpectedVisit;
        private System.Windows.Forms.Label lblYesterday;
        private AGauge guageYesterDayVisit;
        private System.Windows.Forms.Label lblToday;
        private AGauge guageTodayVisit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtRedeems;
        private System.Windows.Forms.ComboBox cmbChartTypeEarns;
        private System.Windows.Forms.Panel groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtEarns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFromDateEarn;
        private System.Windows.Forms.Panel grpDateRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDateEarn;
        private System.Windows.Forms.Panel groupBox5;
        private System.Windows.Forms.ComboBox cmbChartTypeRedeems;
        private System.Windows.Forms.Panel grpLocationSummery;
        private System.Windows.Forms.Label lblExpectedVisit;
        private System.Windows.Forms.Label lblYesterdayVisit;
        private System.Windows.Forms.Label lblTodayVisit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalPoints;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnNeedleExpected;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnNeedleToday;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnNeedleYesterday;
        private System.Windows.Forms.Label lblYValueEarn;
        private System.Windows.Forms.Label lblYValueRedeem;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnRefresh;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnClose;
        private System.Windows.Forms.DataGridView dgvLocationSummery;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPurchases;
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
        private Owf.Controls.A1Panel a1Panel2;
        private Owf.Controls.A1Panel a1Panel3;
        private Owf.Controls.DigitalDisplayControl ddControlTotalPurchasesTomorrow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer2;
    }
}