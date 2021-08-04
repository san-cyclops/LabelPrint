using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Utility;
using ERP.Domain;
using ERP.Service;
using ERP.Report;

using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;

namespace ERP.DashBoard
{
    public partial class FrmSupplierPerformanceDashBoard : FrmBaseMasterForm
    {
        Color backgroundColor = new Color();
        Color grpDateRangeBackColor = new Color();
        Color grpLocationSummeryColor = new Color();
        Color grpVisitColor = new Color();
        Color guageTodayVisitColor = new Color();
        Color guageExpectedVisitColor = new Color();
        Color guageYesterDayVisitColor = new Color();

        public FrmSupplierPerformanceDashBoard()
        {
            InitializeComponent();
        }

        public override void FormLoad()
        {
            try
            {
                SupplierService supplierService = new SupplierService();
                Common.LoadSupplierNamesToCombo(cmbSupplierFrom, supplierService.GetAllSuppliers());

                cmbSupplierTo.SelectedIndexChanged -= new EventHandler(cmbSupplierTo_SelectedIndexChanged);
                Common.LoadSupplierNamesToCombo(cmbSupplierTo, supplierService.GetAllSuppliers());
                cmbSupplierTo.SelectedIndexChanged += new EventHandler(cmbSupplierTo_SelectedIndexChanged);

                dgvTopSupplierSummery.AutoGenerateColumns = false;

                GetDefaultBackColors();
                DisplayChartDetailsPurchaseOrders();
                //DisplayChartDetailsPurchases();
                DisplayGuageValues();

                //cmbChartTypeEarns.SelectedIndex = -1;
                //cmbChartTypeRedeems.SelectedIndex = -1;

                dgvTopSupplierSummery.AutoGenerateColumns = false;

                base.FormLoad();

                //cmbChartTypeEarns.Text = SeriesChartType.Column.ToString();
                //cmbChartTypeRedeems.Text = SeriesChartType.Column.ToString();
                
                chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Column;
                chrtPurchaseOrders.Series["series2"].ChartType = SeriesChartType.Column;
                
                //chrtPurchases.Series["series"].ChartType = SeriesChartType.Column;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        public void DisplayGuageValues() 
        {
            CommonDashBoardService commonDashBoardService = new CommonDashBoardService();

            DataTable topSupplier = commonDashBoardService.GetTopSupplierSummeryPurchaseWise(dtpFromDate.Value, dtpToDate.Value);

            if (topSupplier == null || topSupplier.Rows.Count <= 0) { return; }

            float supplier1, supplier2;

            supplier1 = topSupplier.Rows[0].Field<Int32>("TotalGrn");
            supplier2 = topSupplier.Rows[1].Field<Int32>("TotalGrn");


            float supplier1Sum = supplier1 / 10; 
            float supplier2Sum = supplier2 / 10;

            guageSupplier1.Value = supplier1Sum;
            guageSupplier2.Value = supplier2Sum;


            lblSupplier1Code.Text = topSupplier.Rows[0].Field<string>("SupplierCode").ToString();
            lblSupplier1Name.Text = topSupplier.Rows[0].Field<string>("SupplierName").ToString();

            lblSupplier2Code.Text = topSupplier.Rows[1].Field<string>("SupplierCode").ToString();
            lblSupplier2Name.Text = topSupplier.Rows[1].Field<string>("SupplierName").ToString();
        }

        public void GetDefaultBackColors()
        {
            backgroundColor = this.BackColor;
            grpDateRangeBackColor = this.grpDateRange.BackColor;
            grpLocationSummeryColor = grpLocationSummery.BackColor;
            grpVisitColor = grpVisit.BackColor;
            guageTodayVisitColor = guageSupplier1.BackColor;
            guageYesterDayVisitColor = guageSupplier2.BackColor;
        }


        //private void DisplayChartDetailsPurchaseOrders() 
        //{
        //    if(string.IsNullOrEmpty(cmbSupplierFrom.Text)||string.IsNullOrEmpty(cmbSupplierTo.Text)){return;}
            
        //    SupplierService supplierService = new SupplierService();
        //    string supplierCodeFrom = supplierService.GetSupplierByName(cmbSupplierFrom.Text.Trim()).SupplierCode;
        //    string supplierCodeTo = supplierService.GetSupplierByName(cmbSupplierTo.Text.Trim()).SupplierCode;
        //    InvPurchaseOrderService invPurchaseOrderService = new InvPurchaseOrderService();

        //    chrtPurchaseOrders.DataSource = invPurchaseOrderService.GetSupplierWisePurchaseOrders(dtpFromDate.Value, dtpToDate.Value, supplierCodeFrom, supplierCodeTo);

        //    chrtPurchaseOrders.Series["series"].XValueMember = "SupplierCode";
        //    chrtPurchaseOrders.Series["series"].YValueMembers = "poCount";

        //    //chrtPurchases.Series["series"].IsValueShownAsLabel = true;
        //    chrtPurchaseOrders.ChartAreas["area"].AxisX.Interval = 1; 

        //    chrtPurchaseOrders.DataBind();
        //    chrtPurchaseOrders.Update();

        //    GetChartTypeToComboEarn();
        //    GetChartTypeToComboRedeem();
        //}

        private void DisplayChartDetailsPurchaseOrders()
        {
            if (string.IsNullOrEmpty(cmbSupplierFrom.Text) || string.IsNullOrEmpty(cmbSupplierTo.Text)) { return; }

            SupplierService supplierService = new SupplierService();
            string supplierCodeFrom = supplierService.GetSupplierByName(cmbSupplierFrom.Text.Trim()).SupplierCode;
            string supplierCodeTo = supplierService.GetSupplierByName(cmbSupplierTo.Text.Trim()).SupplierCode;
            InvPurchaseOrderService invPurchaseOrderService = new InvPurchaseOrderService();

            chrtPurchaseOrders.DataSource = invPurchaseOrderService.GetSupplierWisePurchaseOrdersAndSales(dtpFromDate.Value, dtpToDate.Value, supplierCodeFrom, supplierCodeTo);

            chrtPurchaseOrders.Series["series"].XValueMember = "SupplierCode";
            chrtPurchaseOrders.Series["series"].YValueMembers = "TotalPurchaseOrder";

            chrtPurchaseOrders.Series["series2"].XValueMember = "SupplierCode";
            chrtPurchaseOrders.Series["series2"].YValueMembers = "TotalGrn";

            //chrtPurchases.Series["series"].IsValueShownAsLabel = true;
            chrtPurchaseOrders.ChartAreas["area"].AxisX.Interval = 1;

            chrtPurchaseOrders.DataBind();
            chrtPurchaseOrders.Update();

            //GetChartTypeToComboEarn();
            //GetChartTypeToComboRedeem();
        }

        //private void DisplayChartDetailsPurchases() 
        //{
        //    if (string.IsNullOrEmpty(cmbSupplierFrom.Text) || string.IsNullOrEmpty(cmbSupplierTo.Text)) { return; }

        //    SupplierService supplierService = new SupplierService();
        //    string supplierCodeFrom = supplierService.GetSupplierByName(cmbSupplierFrom.Text.Trim()).SupplierCode;
        //    string supplierCodeTo = supplierService.GetSupplierByName(cmbSupplierTo.Text.Trim()).SupplierCode;
        //    InvPurchaseOrderService invPurchaseOrderService = new InvPurchaseOrderService();

        //    chrtPurchases.DataSource = invPurchaseOrderService.GetSupplierWisePurchases(dtpFromDate.Value, dtpToDate.Value, supplierCodeFrom, supplierCodeTo);

        //    chrtPurchases.Series["series"].XValueMember = "SupplierCode";
        //    chrtPurchases.Series["series"].YValueMembers = "NetAmount";

        //    //chrtPurchases.Series["series"].IsValueShownAsLabel = true; 
        //    chrtPurchases.ChartAreas["area"].AxisX.Interval = 1; 

        //    chrtPurchases.DataBind();
        //    chrtPurchases.Update();
        //}

        //private void GetChartTypeToComboEarn()
        //{
        //    List<String> strList = new List<string>();

        //    string type1 = SeriesChartType.Area.ToString();
        //    string type2 = SeriesChartType.Bar.ToString();
        //    string type3 = SeriesChartType.BoxPlot.ToString();
        //    string type4 = SeriesChartType.Bubble.ToString();
        //    string type5 = SeriesChartType.Candlestick.ToString();
        //    string type6 = SeriesChartType.Column.ToString();
        //    string type7 = SeriesChartType.Doughnut.ToString();
        //    string type8 = SeriesChartType.ErrorBar.ToString();
        //    string type9 = SeriesChartType.FastLine.ToString();
        //    string type10 = SeriesChartType.FastPoint.ToString();
        //    string type11 = SeriesChartType.Funnel.ToString();
        //    string type12 = SeriesChartType.Kagi.ToString();
        //    string type13 = SeriesChartType.Line.ToString();
        //    string type14 = SeriesChartType.Pie.ToString();
        //    string type15 = SeriesChartType.Point.ToString();
        //    string type16 = SeriesChartType.PointAndFigure.ToString(); 
        //    string type17 = SeriesChartType.Polar.ToString();
        //    string type18 = SeriesChartType.Pyramid.ToString();
        //    string type19 = SeriesChartType.Radar.ToString();
        //    string type20 = SeriesChartType.Range.ToString();
        //    string type21 = SeriesChartType.RangeBar.ToString();
        //    string type22 = SeriesChartType.RangeColumn.ToString();
        //    string type23 = SeriesChartType.Renko.ToString();
        //    string type24 = SeriesChartType.Spline.ToString();
        //    string type25 = SeriesChartType.SplineArea.ToString();
        //    string type26 = SeriesChartType.SplineRange.ToString();
        //    string type27 = SeriesChartType.StackedArea.ToString();
        //    string type28 = SeriesChartType.StackedArea100.ToString();
        //    string type29 = SeriesChartType.StackedBar.ToString();
        //    string type30 = SeriesChartType.StackedBar100.ToString();
        //    string type31 = SeriesChartType.StackedColumn.ToString();
        //    string type32 = SeriesChartType.StackedColumn100.ToString();
        //    string type33 = SeriesChartType.StepLine.ToString();
        //    string type34 = SeriesChartType.Stock.ToString();
        //    string type35 = SeriesChartType.ThreeLineBreak.ToString();

        //    strList.Add(type1);
        //    strList.Add(type2);
        //    strList.Add(type3);
        //    strList.Add(type4);
        //    strList.Add(type5);
        //    strList.Add(type6);
        //    strList.Add(type7);
        //    strList.Add(type8);
        //    strList.Add(type9);
        //    strList.Add(type10);
        //    strList.Add(type11);
        //    strList.Add(type12);
        //    strList.Add(type13);
        //    strList.Add(type14);
        //    strList.Add(type15);
        //    strList.Add(type16);
        //    strList.Add(type17);
        //    strList.Add(type18);
        //    strList.Add(type19);
        //    strList.Add(type20);
        //    strList.Add(type21);
        //    strList.Add(type22);
        //    strList.Add(type23);
        //    strList.Add(type24);
        //    strList.Add(type25);
        //    strList.Add(type26);
        //    strList.Add(type27);
        //    strList.Add(type28);
        //    strList.Add(type29);
        //    strList.Add(type30);
        //    strList.Add(type31);
        //    strList.Add(type32);
        //    strList.Add(type33);
        //    strList.Add(type34);
        //    strList.Add(type35);

        //    cmbChartTypeEarns.DataSource = strList;
        //    //cmbChartTypeRedeems.DataSource = strList;
        //}

        //private void GetChartTypeToComboRedeem() 
        //{
        //    List<String> strList = new List<string>();

        //    string type1 = SeriesChartType.Area.ToString();
        //    string type2 = SeriesChartType.Bar.ToString();
        //    string type3 = SeriesChartType.BoxPlot.ToString();
        //    string type4 = SeriesChartType.Bubble.ToString();
        //    string type5 = SeriesChartType.Candlestick.ToString();
        //    string type6 = SeriesChartType.Column.ToString();
        //    string type7 = SeriesChartType.Doughnut.ToString();
        //    string type8 = SeriesChartType.ErrorBar.ToString();
        //    string type9 = SeriesChartType.FastLine.ToString();
        //    string type10 = SeriesChartType.FastPoint.ToString();
        //    string type11 = SeriesChartType.Funnel.ToString();
        //    string type12 = SeriesChartType.Kagi.ToString();
        //    string type13 = SeriesChartType.Line.ToString();
        //    string type14 = SeriesChartType.Pie.ToString();
        //    string type15 = SeriesChartType.Point.ToString();
        //    string type16 = SeriesChartType.PointAndFigure.ToString();
        //    string type17 = SeriesChartType.Polar.ToString();
        //    string type18 = SeriesChartType.Pyramid.ToString();
        //    string type19 = SeriesChartType.Radar.ToString();
        //    string type20 = SeriesChartType.Range.ToString();
        //    string type21 = SeriesChartType.RangeBar.ToString();
        //    string type22 = SeriesChartType.RangeColumn.ToString();
        //    string type23 = SeriesChartType.Renko.ToString();
        //    string type24 = SeriesChartType.Spline.ToString();
        //    string type25 = SeriesChartType.SplineArea.ToString();
        //    string type26 = SeriesChartType.SplineRange.ToString();
        //    string type27 = SeriesChartType.StackedArea.ToString();
        //    string type28 = SeriesChartType.StackedArea100.ToString();
        //    string type29 = SeriesChartType.StackedBar.ToString();
        //    string type30 = SeriesChartType.StackedBar100.ToString();
        //    string type31 = SeriesChartType.StackedColumn.ToString();
        //    string type32 = SeriesChartType.StackedColumn100.ToString();
        //    string type33 = SeriesChartType.StepLine.ToString();
        //    string type34 = SeriesChartType.Stock.ToString();
        //    string type35 = SeriesChartType.ThreeLineBreak.ToString();

        //    strList.Add(type1);
        //    strList.Add(type2);
        //    strList.Add(type3);
        //    strList.Add(type4);
        //    strList.Add(type5);
        //    strList.Add(type6);
        //    strList.Add(type7);
        //    strList.Add(type8);
        //    strList.Add(type9);
        //    strList.Add(type10);
        //    strList.Add(type11);
        //    strList.Add(type12);
        //    strList.Add(type13);
        //    strList.Add(type14);
        //    strList.Add(type15);
        //    strList.Add(type16);
        //    strList.Add(type17);
        //    strList.Add(type18);
        //    strList.Add(type19);
        //    strList.Add(type20);
        //    strList.Add(type21);
        //    strList.Add(type22);
        //    strList.Add(type23);
        //    strList.Add(type24);
        //    strList.Add(type25);
        //    strList.Add(type26);
        //    strList.Add(type27);
        //    strList.Add(type28);
        //    strList.Add(type29);
        //    strList.Add(type30);
        //    strList.Add(type31);
        //    strList.Add(type32);
        //    strList.Add(type33);
        //    strList.Add(type34);
        //    strList.Add(type35);

        //    cmbChartTypeRedeems.DataSource = strList;
        //}

        //private void cmbChartTypeEarns_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string type1 = SeriesChartType.Area.ToString();
        //        string type2 = SeriesChartType.Bar.ToString();
        //        string type3 = SeriesChartType.BoxPlot.ToString();
        //        string type4 = SeriesChartType.Bubble.ToString();
        //        string type5 = SeriesChartType.Candlestick.ToString();
        //        string type6 = SeriesChartType.Column.ToString();
        //        string type7 = SeriesChartType.Doughnut.ToString();
        //        string type8 = SeriesChartType.ErrorBar.ToString();
        //        string type9 = SeriesChartType.FastLine.ToString();
        //        string type10 = SeriesChartType.FastPoint.ToString();
        //        string type11 = SeriesChartType.Funnel.ToString();
        //        string type12 = SeriesChartType.Kagi.ToString();
        //        string type13 = SeriesChartType.Line.ToString();
        //        string type14 = SeriesChartType.Pie.ToString();
        //        string type15 = SeriesChartType.Point.ToString();
        //        string type16 = SeriesChartType.PointAndFigure.ToString();
        //        string type17 = SeriesChartType.Polar.ToString();
        //        string type18 = SeriesChartType.Pyramid.ToString();
        //        string type19 = SeriesChartType.Radar.ToString();
        //        string type20 = SeriesChartType.Range.ToString();
        //        string type21 = SeriesChartType.RangeBar.ToString();
        //        string type22 = SeriesChartType.RangeColumn.ToString();
        //        string type23 = SeriesChartType.Renko.ToString();
        //        string type24 = SeriesChartType.Spline.ToString();
        //        string type25 = SeriesChartType.SplineArea.ToString();
        //        string type26 = SeriesChartType.SplineRange.ToString();
        //        string type27 = SeriesChartType.StackedArea.ToString();
        //        string type28 = SeriesChartType.StackedArea100.ToString();
        //        string type29 = SeriesChartType.StackedBar.ToString();
        //        string type30 = SeriesChartType.StackedBar100.ToString();
        //        string type31 = SeriesChartType.StackedColumn.ToString();
        //        string type32 = SeriesChartType.StackedColumn100.ToString();
        //        string type33 = SeriesChartType.StepLine.ToString();
        //        string type34 = SeriesChartType.Stock.ToString();
        //        string type35 = SeriesChartType.ThreeLineBreak.ToString();

        //        if (cmbChartTypeEarns.Text == SeriesChartType.Area.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Area;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Bar.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Bar;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.BoxPlot.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.BoxPlot;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Bubble.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Bubble;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Candlestick.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Candlestick;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Column.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Column;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Doughnut.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Doughnut;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.ErrorBar.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.ErrorBar;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.FastLine.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.FastLine;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.FastPoint.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.FastPoint;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Funnel.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Funnel;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Kagi.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Kagi;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Line.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Line;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Pie.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Pie;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Point.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Point;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.PointAndFigure.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.PointAndFigure;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Polar.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Polar;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Pyramid.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Pyramid;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Radar.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Radar;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Range.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Range;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.RangeBar.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.RangeBar;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.RangeColumn.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.RangeColumn;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Renko.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Renko;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Spline.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Spline;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.SplineArea.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.SplineArea;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.SplineRange.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.SplineRange;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.StackedArea.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.StackedArea;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.StackedArea100.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.StackedArea100;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.StackedBar.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.StackedBar;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.StackedBar100.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.StackedBar100;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.StackedColumn.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.StackedColumn;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.StackedColumn100.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.StackedColumn100;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.StepLine.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.StepLine;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.Stock.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.Stock;
        //        }
        //        else if (cmbChartTypeEarns.Text == SeriesChartType.ThreeLineBreak.ToString())
        //        {
        //            chrtPurchaseOrders.Series["series"].ChartType = SeriesChartType.ThreeLineBreak;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
        //    }
        //}

        private void dtpFromDateEarn_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayChartDetailsPurchaseOrders();
                //DisplayChartDetailsPurchases();

                //cmbChartTypeEarns.Text = SeriesChartType.Column.ToString();
                //cmbChartTypeRedeems.Text = SeriesChartType.Column.ToString();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void dtpToDateEarn_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayChartDetailsPurchaseOrders();
                //DisplayChartDetailsPurchases();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        //private void cmbChartTypeRedeems_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string type1 = SeriesChartType.Area.ToString();
        //        string type2 = SeriesChartType.Bar.ToString();
        //        string type3 = SeriesChartType.BoxPlot.ToString();
        //        string type4 = SeriesChartType.Bubble.ToString();
        //        string type5 = SeriesChartType.Candlestick.ToString();
        //        string type6 = SeriesChartType.Column.ToString();
        //        string type7 = SeriesChartType.Doughnut.ToString();
        //        string type8 = SeriesChartType.ErrorBar.ToString();
        //        string type9 = SeriesChartType.FastLine.ToString();
        //        string type10 = SeriesChartType.FastPoint.ToString();
        //        string type11 = SeriesChartType.Funnel.ToString();
        //        string type12 = SeriesChartType.Kagi.ToString();
        //        string type13 = SeriesChartType.Line.ToString();
        //        string type14 = SeriesChartType.Pie.ToString();
        //        string type15 = SeriesChartType.Point.ToString();
        //        string type16 = SeriesChartType.PointAndFigure.ToString();
        //        string type17 = SeriesChartType.Polar.ToString();
        //        string type18 = SeriesChartType.Pyramid.ToString();
        //        string type19 = SeriesChartType.Radar.ToString();
        //        string type20 = SeriesChartType.Range.ToString();
        //        string type21 = SeriesChartType.RangeBar.ToString();
        //        string type22 = SeriesChartType.RangeColumn.ToString();
        //        string type23 = SeriesChartType.Renko.ToString();
        //        string type24 = SeriesChartType.Spline.ToString();
        //        string type25 = SeriesChartType.SplineArea.ToString();
        //        string type26 = SeriesChartType.SplineRange.ToString();
        //        string type27 = SeriesChartType.StackedArea.ToString();
        //        string type28 = SeriesChartType.StackedArea100.ToString();
        //        string type29 = SeriesChartType.StackedBar.ToString();
        //        string type30 = SeriesChartType.StackedBar100.ToString();
        //        string type31 = SeriesChartType.StackedColumn.ToString();
        //        string type32 = SeriesChartType.StackedColumn100.ToString();
        //        string type33 = SeriesChartType.StepLine.ToString();
        //        string type34 = SeriesChartType.Stock.ToString();
        //        string type35 = SeriesChartType.ThreeLineBreak.ToString();

        //        if (cmbChartTypeRedeems.Text == SeriesChartType.Area.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Area;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Bar.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Bar;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.BoxPlot.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.BoxPlot;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Bubble.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Bubble;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Candlestick.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Candlestick;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Column.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Column;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Doughnut.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Doughnut;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.ErrorBar.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.ErrorBar;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.FastLine.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.FastLine;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.FastPoint.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.FastPoint;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Funnel.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Funnel;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Kagi.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Kagi;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Line.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Line;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Pie.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Pie;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Point.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Point;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.PointAndFigure.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.PointAndFigure;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Polar.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Polar;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Pyramid.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Pyramid;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Radar.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Radar;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Range.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Range;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.RangeBar.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.RangeBar;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.RangeColumn.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.RangeColumn;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Renko.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Renko;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Spline.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Spline;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.SplineArea.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.SplineArea;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.SplineRange.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.SplineRange;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.StackedArea.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.StackedArea;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.StackedArea100.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.StackedArea100;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.StackedBar.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.StackedBar;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.StackedBar100.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.StackedBar100;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.StackedColumn.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.StackedColumn;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.StackedColumn100.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.StackedColumn100;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.StepLine.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.StepLine;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.Stock.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.Stock;
        //        }
        //        else if (cmbChartTypeRedeems.Text == SeriesChartType.ThreeLineBreak.ToString())
        //        {
        //            chrtPurchases.Series["series"].ChartType = SeriesChartType.ThreeLineBreak;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
        //    }
        //}


        

        private void btnNeedleToday_Click(object sender, EventArgs e)
        {
            try
            {
                if (guageSupplier1.NeedleType == 0)
                {
                    guageSupplier1.NeedleType = 1;
                }
                else
                {
                    guageSupplier1.NeedleType = 0;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void btnNeedleYesterday_Click(object sender, EventArgs e)
        {
            try
            {
                if (guageSupplier2.NeedleType == 0)
                {
                    guageSupplier2.NeedleType = 1;
                }
                else
                {
                    guageSupplier2.NeedleType = 0;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        private void chrtEarns_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Point mousePoint = new Point(e.X, e.Y);

                chrtPurchaseOrders.ChartAreas[0].CursorX.Interval = 0;
                chrtPurchaseOrders.ChartAreas[0].CursorY.Interval = 0;

                chrtPurchaseOrders.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                chrtPurchaseOrders.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);

                //lblX.Text = "Pixe X Position : " + chrtEarns.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString();
                //lblX.Text = "Pixe Y Position : " + chrtEarns.ChartAreas[0].AxisY.PixelPositionToValue(e.Y).ToString();

                HitTestResult result = chrtPurchaseOrders.HitTest(e.X, e.Y);

                if (result.PointIndex > -1 && result.ChartArea != null)
                {
                    lblYValueEarn.Text = "Y - Value : " + result.Series.Points[result.PointIndex].YValues[0].ToString();
                    //lblXValue.Text = "X - Value : " + result.Series.Points[result.PointIndex].XValue.ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        //private void chrtRedeems_MouseMove(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        Point mousePoint = new Point(e.X, e.Y);

        //        chrtPurchases.ChartAreas[0].CursorX.Interval = 0;
        //        chrtPurchases.ChartAreas[0].CursorY.Interval = 0;

        //        chrtPurchases.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
        //        chrtPurchases.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);

        //        HitTestResult result = chrtPurchases.HitTest(e.X, e.Y);

        //        if (result.PointIndex > -1 && result.ChartArea != null)
        //        {
        //            lblYValueRedeem.Text = "Y - Value : " + result.Series.Points[result.PointIndex].YValues[0].ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
        //    }
        //}

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayChartDetailsPurchaseOrders();
                //DisplayChartDetailsPurchases();
                DisplayGuageValues();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        private void RefreshPage() 
        {
            
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnlSettings.Visible == false)
                {
                    pnlSettings.Visible = true;
                }
                else
                {
                    pnlSettings.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            try
            {
                clrDialog.FullOpen = true;
                if (clrDialog.ShowDialog() != DialogResult.Cancel)
                {
                    this.BackColor = clrDialog.Color;
                    this.grpDateRange.BackColor = clrDialog.Color;
                    this.grpLocationSummery.BackColor = clrDialog.Color;
                    this.grpVisit.BackColor = clrDialog.Color;
                    this.guageSupplier1.BackColor = clrDialog.Color;
                    this.guageSupplier2.BackColor = clrDialog.Color;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.BackColor = backgroundColor;
                this.grpDateRange.BackColor = grpDateRangeBackColor;
                this.grpLocationSummery.BackColor = grpLocationSummeryColor;
                this.grpVisit.BackColor = grpVisitColor;
                this.guageSupplier1.BackColor = guageTodayVisitColor;
                this.guageSupplier2.BackColor = guageYesterDayVisitColor;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.digitalDisplayControl1.DigitText = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnTopnSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTopNSupplier.Text)) { return; }

                CommonDashBoardService commonDashBoardService = new CommonDashBoardService();
                dgvTopSupplierSummery.DataSource = null;
                dgvTopSupplierSummery.DataSource = commonDashBoardService.GetTopNSalesWiseSupplierSummery(Common.ConvertStringToInt(txtTopNSupplier.Text.Trim()), dtpFromDate.Value, dtpToDate.Value);
                dgvTopSupplierSummery.Refresh();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void cmbSupplierTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayChartDetailsPurchaseOrders();
                //DisplayChartDetailsPurchases();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


    }
}
