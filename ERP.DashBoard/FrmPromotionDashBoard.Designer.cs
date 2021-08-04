namespace ERP.DashBoard
{
    partial class FrmPromotionDashBoard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.clrDialog = new System.Windows.Forms.ColorDialog();
            this.digitalDisplayControl1 = new Owf.Controls.DigitalDisplayControl();
            this.a1Panel1 = new Owf.Controls.A1Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dgvOnGoingPromotions = new System.Windows.Forms.DataGridView();
            this.Promotion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromotionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromotionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.a1Panel2 = new Owf.Controls.A1Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvSummery = new System.Windows.Forms.DataGridView();
            this.lblDiscountValue = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnReset = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnChangeColor = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.groupBox2 = new System.Windows.Forms.Panel();
            this.cmbChartTypePromotionSale = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.Panel();
            this.cmbChartTypePromotionDiscount = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chrtDiscount = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlLocations = new System.Windows.Forms.Panel();
            this.txtPromotionName = new System.Windows.Forms.TextBox();
            this.dgvLocations = new System.Windows.Forms.DataGridView();
            this.LocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSaleValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chrtPromotionSale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnSettings = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.btnRefresh = new global::ERP.UI.Windows.CustomControls.uc_GButton();
            this.a1Panel3 = new Owf.Controls.A1Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.LocationNameSummery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromotionDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a1Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnGoingPromotions)).BeginInit();
            this.a1Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummery)).BeginInit();
            this.pnlSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtDiscount)).BeginInit();
            this.pnlLocations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPromotionSale)).BeginInit();
            this.a1Panel3.SuspendLayout();
            this.SuspendLayout();
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
            // a1Panel1
            // 
            this.a1Panel1.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel1.Controls.Add(this.digitalDisplayControl1);
            this.a1Panel1.GradientEndColor = System.Drawing.SystemColors.MenuHighlight;
            this.a1Panel1.GradientStartColor = System.Drawing.Color.Thistle;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(9, 662);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.RoundCornerRadius = 29;
            this.a1Panel1.ShadowOffSet = 12;
            this.a1Panel1.Size = new System.Drawing.Size(203, 100);
            this.a1Panel1.TabIndex = 36;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(250, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "From";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(268, 11);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(216, 21);
            this.dtpToDate.TabIndex = 9;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(40, 11);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(204, 21);
            this.dtpFromDate.TabIndex = 8;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // dgvOnGoingPromotions
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.CadetBlue;
            this.dgvOnGoingPromotions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOnGoingPromotions.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvOnGoingPromotions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOnGoingPromotions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Promotion,
            this.PromotionType,
            this.Location,
            this.StartedDate,
            this.EndDate,
            this.PromotionID});
            this.dgvOnGoingPromotions.Location = new System.Drawing.Point(12, 94);
            this.dgvOnGoingPromotions.Name = "dgvOnGoingPromotions";
            this.dgvOnGoingPromotions.RowHeadersWidth = 4;
            this.dgvOnGoingPromotions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOnGoingPromotions.Size = new System.Drawing.Size(643, 253);
            this.dgvOnGoingPromotions.TabIndex = 37;
            this.dgvOnGoingPromotions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOnGoingPromotions_CellContentClick);
            this.dgvOnGoingPromotions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvOnGoingPromotions_MouseClick);
            // 
            // Promotion
            // 
            this.Promotion.DataPropertyName = "PromotionName";
            this.Promotion.HeaderText = "Promotion ";
            this.Promotion.Name = "Promotion";
            this.Promotion.ReadOnly = true;
            this.Promotion.Width = 200;
            // 
            // PromotionType
            // 
            this.PromotionType.DataPropertyName = "PromotionTypeName";
            this.PromotionType.HeaderText = "Promotion Type";
            this.PromotionType.Name = "PromotionType";
            this.PromotionType.ReadOnly = true;
            this.PromotionType.Width = 255;
            // 
            // Location
            // 
            this.Location.DataPropertyName = "LocationName";
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Visible = false;
            // 
            // StartedDate
            // 
            this.StartedDate.DataPropertyName = "StartDate";
            this.StartedDate.HeaderText = "Started Date";
            this.StartedDate.Name = "StartedDate";
            this.StartedDate.ReadOnly = true;
            this.StartedDate.Width = 80;
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "EndDate";
            this.EndDate.HeaderText = "End Date";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            this.EndDate.Width = 80;
            // 
            // PromotionID
            // 
            this.PromotionID.DataPropertyName = "InvPromotionMasterID";
            this.PromotionID.HeaderText = "PromotionID";
            this.PromotionID.Name = "PromotionID";
            this.PromotionID.ReadOnly = true;
            this.PromotionID.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label2.Location = new System.Drawing.Point(243, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 15);
            this.label2.TabIndex = 38;
            this.label2.Text = "On Going Promotion Details";
            // 
            // a1Panel2
            // 
            this.a1Panel2.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel2.Controls.Add(this.label6);
            this.a1Panel2.Controls.Add(this.dgvSummery);
            this.a1Panel2.Controls.Add(this.lblDiscountValue);
            this.a1Panel2.Controls.Add(this.pnlSettings);
            this.a1Panel2.Controls.Add(this.label7);
            this.a1Panel2.Controls.Add(this.chrtDiscount);
            this.a1Panel2.Controls.Add(this.pnlLocations);
            this.a1Panel2.Controls.Add(this.lblSaleValue);
            this.a1Panel2.Controls.Add(this.label5);
            this.a1Panel2.Controls.Add(this.chrtPromotionSale);
            this.a1Panel2.Controls.Add(this.btnSettings);
            this.a1Panel2.Controls.Add(this.label3);
            this.a1Panel2.Controls.Add(this.btnClose);
            this.a1Panel2.Controls.Add(this.btnRefresh);
            this.a1Panel2.Controls.Add(this.a1Panel3);
            this.a1Panel2.Controls.Add(this.dgvOnGoingPromotions);
            this.a1Panel2.Controls.Add(this.a1Panel1);
            this.a1Panel2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.a1Panel2.GradientEndColor = System.Drawing.SystemColors.MenuHighlight;
            this.a1Panel2.GradientStartColor = System.Drawing.Color.Thistle;
            this.a1Panel2.Image = null;
            this.a1Panel2.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel2.Location = new System.Drawing.Point(-6, -10);
            this.a1Panel2.Name = "a1Panel2";
            this.a1Panel2.RoundCornerRadius = 29;
            this.a1Panel2.Size = new System.Drawing.Size(1379, 793);
            this.a1Panel2.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(698, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 15);
            this.label6.TabIndex = 50;
            this.label6.Text = "Total Sales And Promotion Summery";
            // 
            // dgvSummery
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.CadetBlue;
            this.dgvSummery.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSummery.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvSummery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSummery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocationNameSummery,
            this.Sale,
            this.PromotionDiscount,
            this.Profit});
            this.dgvSummery.Location = new System.Drawing.Point(700, 389);
            this.dgvSummery.Name = "dgvSummery";
            this.dgvSummery.RowHeadersWidth = 4;
            this.dgvSummery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSummery.Size = new System.Drawing.Size(643, 253);
            this.dgvSummery.TabIndex = 51;
            // 
            // lblDiscountValue
            // 
            this.lblDiscountValue.AutoSize = true;
            this.lblDiscountValue.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscountValue.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblDiscountValue.Location = new System.Drawing.Point(1132, 55);
            this.lblDiscountValue.Name = "lblDiscountValue";
            this.lblDiscountValue.Size = new System.Drawing.Size(46, 15);
            this.lblDiscountValue.TabIndex = 49;
            this.lblDiscountValue.Text = "Value : ";
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.Teal;
            this.pnlSettings.Controls.Add(this.btnReset);
            this.pnlSettings.Controls.Add(this.btnChangeColor);
            this.pnlSettings.Controls.Add(this.groupBox2);
            this.pnlSettings.Controls.Add(this.groupBox5);
            this.pnlSettings.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.pnlSettings.Location = new System.Drawing.Point(528, 76);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(233, 201);
            this.pnlSettings.TabIndex = 44;
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
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeColor.Location = new System.Drawing.Point(5, 141);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(164, 51);
            this.btnChangeColor.TabIndex = 35;
            this.btnChangeColor.Text = "Change Background Color";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbChartTypePromotionSale);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(5, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 64);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change Chart 1 Style";
            // 
            // cmbChartTypePromotionSale
            // 
            this.cmbChartTypePromotionSale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChartTypePromotionSale.FormattingEnabled = true;
            this.cmbChartTypePromotionSale.Location = new System.Drawing.Point(10, 25);
            this.cmbChartTypePromotionSale.Name = "cmbChartTypePromotionSale";
            this.cmbChartTypePromotionSale.Size = new System.Drawing.Size(200, 23);
            this.cmbChartTypePromotionSale.TabIndex = 4;
            this.cmbChartTypePromotionSale.SelectedIndexChanged += new System.EventHandler(this.cmbChartTypePromotionSale_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbChartTypePromotionDiscount);
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.groupBox5.Location = new System.Drawing.Point(5, 70);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(219, 64);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Change Chart 2 Style";
            // 
            // cmbChartTypePromotionDiscount
            // 
            this.cmbChartTypePromotionDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChartTypePromotionDiscount.FormattingEnabled = true;
            this.cmbChartTypePromotionDiscount.Location = new System.Drawing.Point(10, 25);
            this.cmbChartTypePromotionDiscount.Name = "cmbChartTypePromotionDiscount";
            this.cmbChartTypePromotionDiscount.Size = new System.Drawing.Size(200, 23);
            this.cmbChartTypePromotionDiscount.TabIndex = 4;
            this.cmbChartTypePromotionDiscount.SelectedIndexChanged += new System.EventHandler(this.cmbChartTypePromotionDiscount_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label7.Location = new System.Drawing.Point(824, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(241, 15);
            this.label7.TabIndex = 48;
            this.label7.Text = "Location Wise Promotion Discount Amount";
            // 
            // chrtDiscount
            // 
            this.chrtDiscount.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            chartArea1.Name = "area";
            this.chrtDiscount.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrtDiscount.Legends.Add(legend1);
            this.chrtDiscount.Location = new System.Drawing.Point(701, 94);
            this.chrtDiscount.Name = "chrtDiscount";
            series1.ChartArea = "area";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Funnel;
            series1.CustomProperties = "FunnelLabelStyle=Outside, PieLabelStyle=Outside";
            series1.Legend = "Legend1";
            series1.Name = "series";
            series1.ToolTip = "#VAL";
            this.chrtDiscount.Series.Add(series1);
            this.chrtDiscount.Size = new System.Drawing.Size(643, 253);
            this.chrtDiscount.TabIndex = 47;
            this.chrtDiscount.Text = "chart1";
            this.chrtDiscount.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chrtDiscount_MouseMove);
            // 
            // pnlLocations
            // 
            this.pnlLocations.BackColor = System.Drawing.Color.Teal;
            this.pnlLocations.Controls.Add(this.txtPromotionName);
            this.pnlLocations.Controls.Add(this.dgvLocations);
            this.pnlLocations.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.pnlLocations.Location = new System.Drawing.Point(265, 76);
            this.pnlLocations.Name = "pnlLocations";
            this.pnlLocations.Size = new System.Drawing.Size(257, 240);
            this.pnlLocations.TabIndex = 45;
            this.pnlLocations.Visible = false;
            this.pnlLocations.Click += new System.EventHandler(this.pnlLocations_Click);
            // 
            // txtPromotionName
            // 
            this.txtPromotionName.BackColor = System.Drawing.Color.PowderBlue;
            this.txtPromotionName.Location = new System.Drawing.Point(9, 6);
            this.txtPromotionName.Multiline = true;
            this.txtPromotionName.Name = "txtPromotionName";
            this.txtPromotionName.Size = new System.Drawing.Size(239, 46);
            this.txtPromotionName.TabIndex = 1;
            // 
            // dgvLocations
            // 
            this.dgvLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocationName});
            this.dgvLocations.Location = new System.Drawing.Point(9, 56);
            this.dgvLocations.Name = "dgvLocations";
            this.dgvLocations.RowHeadersWidth = 4;
            this.dgvLocations.Size = new System.Drawing.Size(239, 179);
            this.dgvLocations.TabIndex = 0;
            // 
            // LocationName
            // 
            this.LocationName.DataPropertyName = "LocationName";
            this.LocationName.HeaderText = "Location Name";
            this.LocationName.Name = "LocationName";
            this.LocationName.ReadOnly = true;
            this.LocationName.Width = 210;
            // 
            // lblSaleValue
            // 
            this.lblSaleValue.AutoSize = true;
            this.lblSaleValue.BackColor = System.Drawing.Color.Transparent;
            this.lblSaleValue.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lblSaleValue.Location = new System.Drawing.Point(363, 367);
            this.lblSaleValue.Name = "lblSaleValue";
            this.lblSaleValue.Size = new System.Drawing.Size(46, 15);
            this.lblSaleValue.TabIndex = 46;
            this.lblSaleValue.Text = "Value : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label5.Location = new System.Drawing.Point(12, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 15);
            this.label5.TabIndex = 45;
            this.label5.Text = "Location Wise Promotion Sale";
            // 
            // chrtPromotionSale
            // 
            this.chrtPromotionSale.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            chartArea2.Name = "area";
            this.chrtPromotionSale.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrtPromotionSale.Legends.Add(legend2);
            this.chrtPromotionSale.Location = new System.Drawing.Point(12, 389);
            this.chrtPromotionSale.Name = "chrtPromotionSale";
            series2.ChartArea = "area";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.CustomProperties = "CollectedSliceExploded=True, PieLabelStyle=Outside";
            series2.Legend = "Legend1";
            series2.Name = "series";
            series2.ToolTip = "#VAL";
            this.chrtPromotionSale.Series.Add(series2);
            this.chrtPromotionSale.Size = new System.Drawing.Size(643, 253);
            this.chrtPromotionSale.TabIndex = 43;
            this.chrtPromotionSale.Text = "chart1";
            this.chrtPromotionSale.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chrtPromotionSale_MouseMove);
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = global::ERP.DashBoard.Properties.Resources.settings_icon32;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSettings.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(528, 17);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(69, 53);
            this.btnSettings.TabIndex = 42;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "On Going Promotion Details";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::ERP.DashBoard.Properties.Resources.Actions_window_close_icon;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(608, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 53);
            this.btnClose.TabIndex = 41;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::ERP.DashBoard.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_view_refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(692, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(69, 53);
            this.btnRefresh.TabIndex = 40;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // a1Panel3
            // 
            this.a1Panel3.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel3.Controls.Add(this.dtpToDate);
            this.a1Panel3.Controls.Add(this.label4);
            this.a1Panel3.Controls.Add(this.dtpFromDate);
            this.a1Panel3.Controls.Add(this.label1);
            this.a1Panel3.GradientEndColor = System.Drawing.SystemColors.MenuHighlight;
            this.a1Panel3.GradientStartColor = System.Drawing.Color.Thistle;
            this.a1Panel3.Image = null;
            this.a1Panel3.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel3.Location = new System.Drawing.Point(12, 17);
            this.a1Panel3.Name = "a1Panel3";
            this.a1Panel3.RoundCornerRadius = 29;
            this.a1Panel3.ShadowOffSet = 10;
            this.a1Panel3.Size = new System.Drawing.Size(510, 51);
            this.a1Panel3.TabIndex = 38;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // LocationNameSummery
            // 
            this.LocationNameSummery.DataPropertyName = "LocationName";
            this.LocationNameSummery.HeaderText = "Location";
            this.LocationNameSummery.Name = "LocationNameSummery";
            this.LocationNameSummery.ReadOnly = true;
            this.LocationNameSummery.Width = 205;
            // 
            // Sale
            // 
            this.Sale.DataPropertyName = "Sale";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Sale.DefaultCellStyle = dataGridViewCellStyle3;
            this.Sale.HeaderText = "Total Sale";
            this.Sale.Name = "Sale";
            this.Sale.ReadOnly = true;
            this.Sale.Width = 135;
            // 
            // PromotionDiscount
            // 
            this.PromotionDiscount.DataPropertyName = "PromotionDiscount";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.PromotionDiscount.DefaultCellStyle = dataGridViewCellStyle4;
            this.PromotionDiscount.HeaderText = "Total Promotion Discount";
            this.PromotionDiscount.Name = "PromotionDiscount";
            this.PromotionDiscount.ReadOnly = true;
            this.PromotionDiscount.Width = 135;
            // 
            // Profit
            // 
            this.Profit.DataPropertyName = "Profit";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Profit.DefaultCellStyle = dataGridViewCellStyle5;
            this.Profit.HeaderText = "Profit";
            this.Profit.Name = "Profit";
            this.Profit.ReadOnly = true;
            this.Profit.Width = 135;
            // 
            // FrmPromotionDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1350, 749);
            this.Controls.Add(this.a1Panel2);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmPromotionDashBoard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPromotionDashBoard";
            this.a1Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnGoingPromotions)).EndInit();
            this.a1Panel2.ResumeLayout(false);
            this.a1Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummery)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrtDiscount)).EndInit();
            this.pnlLocations.ResumeLayout(false);
            this.pnlLocations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPromotionSale)).EndInit();
            this.a1Panel3.ResumeLayout(false);
            this.a1Panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog clrDialog;
        private Owf.Controls.DigitalDisplayControl digitalDisplayControl1;
        private Owf.Controls.A1Panel a1Panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DataGridView dgvOnGoingPromotions;
        private System.Windows.Forms.Label label2;
        private Owf.Controls.A1Panel a1Panel2;
        private System.Windows.Forms.Label label3;
        private Owf.Controls.A1Panel a1Panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtPromotionSale;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnSettings;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnClose;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnRefresh;
        private System.Windows.Forms.Panel pnlSettings;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnReset;
        private global::ERP.UI.Windows.CustomControls.uc_GButton btnChangeColor;
        private System.Windows.Forms.Panel groupBox2;
        private System.Windows.Forms.ComboBox cmbChartTypePromotionSale;
        private System.Windows.Forms.Panel groupBox5;
        private System.Windows.Forms.ComboBox cmbChartTypePromotionDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSaleValue;
        private System.Windows.Forms.Panel pnlLocations;
        private System.Windows.Forms.DataGridView dgvLocations;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Promotion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromotionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromotionID;
        private System.Windows.Forms.Label lblDiscountValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtDiscount;
        private System.Windows.Forms.TextBox txtPromotionName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvSummery;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationNameSummery;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sale;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromotionDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit;
    }
}