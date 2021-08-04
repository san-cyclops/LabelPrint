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
    public partial class FrmCrmDashBoard : FrmBaseMasterForm
    {
        string labelPoints, labelCustomerCount;
        int aa = 0;

        Color backgroundColor = new Color();
        Color grpDateRangeBackColor = new Color();
        Color grpLocationSummeryColor = new Color();
        Color grpVisitColor = new Color();
        Color guageTodayVisitColor = new Color();
        Color guageExpectedVisitColor = new Color();
        Color guageYesterDayVisitColor = new Color();

        public FrmCrmDashBoard()
        {
            InitializeComponent();
        }

        public override void FormLoad()
        {
            DisplayChartDetailsEarns();
            DisplayChartDetailsRedeems();
            GetTotalCurrentPoints();
            GetDefaultBackColors();
            GetTotalPurchases();

            labelCustomerCount = lblTotalCustomers.Text;
            labelPoints = lblTotalPoints.Text;

            cmbChartTypeEarns.SelectedIndex = -1;
            cmbChartTypeRedeems.SelectedIndex = -1;

            dgvLocationSummery.AutoGenerateColumns = false;

            
            GetChartTypeToComboEarn();
            GetChartTypeToComboRedeem();
            DisplayDetails();
            GetCustomerCountAndPoints();

            SetLocationSummeryGridData();

            base.FormLoad();

            cmbChartTypeEarns.Text = SeriesChartType.Column.ToString();
            cmbChartTypeRedeems.Text = SeriesChartType.Column.ToString();
            chrtEarns.Series["series"].ChartType = SeriesChartType.Column;
            chrtRedeems.Series["series"].ChartType = SeriesChartType.Column;

            timer2.Start();
        }

        public void GetDefaultBackColors()
        {
            backgroundColor = this.BackColor;
            grpDateRangeBackColor = this.grpDateRange.BackColor;
            grpLocationSummeryColor = grpLocationSummery.BackColor;
            grpVisitColor = grpVisit.BackColor;
            guageTodayVisitColor = guageTodayVisit.BackColor;
            guageExpectedVisitColor = guageExpectedVisit.BackColor;
            guageYesterDayVisitColor = guageYesterDayVisit.BackColor;
        }

        private void DisplayDetails()
        {
            lblToday.Text = lblToday.Text + " " + Common.GetSystemDate().ToShortDateString();
            lblYesterday.Text = lblYesterday.Text + " " + Common.GetSystemDate().AddDays(-1).ToShortDateString();
            lblExpected.Text = lblExpected.Text + " " + Common.GetSystemDate().AddDays(1).ToShortDateString();
        }

        private void DisplayChartDetailsEarns() 
        {
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
            loyaltyCustomerService.GetDataSourceArapaimaToChartEarn(dtpFromDateEarn.Value, dtpToDateEarn.Value);

            chrtEarns.DataSource = loyaltyCustomerService.DsReport.Tables["LocationWiseSummery"];

            chrtEarns.Series["series"].XValueMember = "LocationPrefixCode";
            chrtEarns.Series["series"].YValueMembers = "TotalEarnpoints";

            //chrtEarns.Series["series"].IsValueShownAsLabel = true;
            chrtEarns.ChartAreas["area"].AxisX.Interval = 1; 

            chrtEarns.DataBind();
            chrtEarns.Update();

            GetChartTypeToComboEarn();
            GetChartTypeToComboRedeem();
        }

        private void DisplayChartDetailsRedeems() 
        {
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
            loyaltyCustomerService.GetDataSourceArapaimaToChartRedeem(dtpFromDateEarn.Value, dtpToDateEarn.Value);

            chrtRedeems.DataSource = loyaltyCustomerService.DsReport.Tables["LocationWiseSummery"];

            chrtRedeems.Series["series"].XValueMember = "LocationPrefixCode";
            chrtRedeems.Series["series"].YValueMembers = "TotalRedeempoints";

            //chrtRedeems.Series["series"].IsValueShownAsLabel = true; 
            chrtRedeems.ChartAreas["area"].AxisX.Interval = 1; 

            chrtRedeems.DataBind();
            chrtRedeems.Update();
        }

        private void GetChartTypeToComboEarn()
        {
            List<String> strList = new List<string>();

            string type1 = SeriesChartType.Area.ToString();
            string type2 = SeriesChartType.Bar.ToString();
            string type3 = SeriesChartType.BoxPlot.ToString();
            string type4 = SeriesChartType.Bubble.ToString();
            string type5 = SeriesChartType.Candlestick.ToString();
            string type6 = SeriesChartType.Column.ToString();
            string type7 = SeriesChartType.Doughnut.ToString();
            string type8 = SeriesChartType.ErrorBar.ToString();
            string type9 = SeriesChartType.FastLine.ToString();
            string type10 = SeriesChartType.FastPoint.ToString();
            string type11 = SeriesChartType.Funnel.ToString();
            string type12 = SeriesChartType.Kagi.ToString();
            string type13 = SeriesChartType.Line.ToString();
            string type14 = SeriesChartType.Pie.ToString();
            string type15 = SeriesChartType.Point.ToString();
            string type16 = SeriesChartType.PointAndFigure.ToString(); 
            string type17 = SeriesChartType.Polar.ToString();
            string type18 = SeriesChartType.Pyramid.ToString();
            string type19 = SeriesChartType.Radar.ToString();
            string type20 = SeriesChartType.Range.ToString();
            string type21 = SeriesChartType.RangeBar.ToString();
            string type22 = SeriesChartType.RangeColumn.ToString();
            string type23 = SeriesChartType.Renko.ToString();
            string type24 = SeriesChartType.Spline.ToString();
            string type25 = SeriesChartType.SplineArea.ToString();
            string type26 = SeriesChartType.SplineRange.ToString();
            string type27 = SeriesChartType.StackedArea.ToString();
            string type28 = SeriesChartType.StackedArea100.ToString();
            string type29 = SeriesChartType.StackedBar.ToString();
            string type30 = SeriesChartType.StackedBar100.ToString();
            string type31 = SeriesChartType.StackedColumn.ToString();
            string type32 = SeriesChartType.StackedColumn100.ToString();
            string type33 = SeriesChartType.StepLine.ToString();
            string type34 = SeriesChartType.Stock.ToString();
            string type35 = SeriesChartType.ThreeLineBreak.ToString();

            strList.Add(type1);
            strList.Add(type2);
            strList.Add(type3);
            strList.Add(type4);
            strList.Add(type5);
            strList.Add(type6);
            strList.Add(type7);
            strList.Add(type8);
            strList.Add(type9);
            strList.Add(type10);
            strList.Add(type11);
            strList.Add(type12);
            strList.Add(type13);
            strList.Add(type14);
            strList.Add(type15);
            strList.Add(type16);
            strList.Add(type17);
            strList.Add(type18);
            strList.Add(type19);
            strList.Add(type20);
            strList.Add(type21);
            strList.Add(type22);
            strList.Add(type23);
            strList.Add(type24);
            strList.Add(type25);
            strList.Add(type26);
            strList.Add(type27);
            strList.Add(type28);
            strList.Add(type29);
            strList.Add(type30);
            strList.Add(type31);
            strList.Add(type32);
            strList.Add(type33);
            strList.Add(type34);
            strList.Add(type35);

            cmbChartTypeEarns.DataSource = strList;
            //cmbChartTypeRedeems.DataSource = strList;
        }

        private void GetChartTypeToComboRedeem() 
        {
            List<String> strList = new List<string>();

            string type1 = SeriesChartType.Area.ToString();
            string type2 = SeriesChartType.Bar.ToString();
            string type3 = SeriesChartType.BoxPlot.ToString();
            string type4 = SeriesChartType.Bubble.ToString();
            string type5 = SeriesChartType.Candlestick.ToString();
            string type6 = SeriesChartType.Column.ToString();
            string type7 = SeriesChartType.Doughnut.ToString();
            string type8 = SeriesChartType.ErrorBar.ToString();
            string type9 = SeriesChartType.FastLine.ToString();
            string type10 = SeriesChartType.FastPoint.ToString();
            string type11 = SeriesChartType.Funnel.ToString();
            string type12 = SeriesChartType.Kagi.ToString();
            string type13 = SeriesChartType.Line.ToString();
            string type14 = SeriesChartType.Pie.ToString();
            string type15 = SeriesChartType.Point.ToString();
            string type16 = SeriesChartType.PointAndFigure.ToString();
            string type17 = SeriesChartType.Polar.ToString();
            string type18 = SeriesChartType.Pyramid.ToString();
            string type19 = SeriesChartType.Radar.ToString();
            string type20 = SeriesChartType.Range.ToString();
            string type21 = SeriesChartType.RangeBar.ToString();
            string type22 = SeriesChartType.RangeColumn.ToString();
            string type23 = SeriesChartType.Renko.ToString();
            string type24 = SeriesChartType.Spline.ToString();
            string type25 = SeriesChartType.SplineArea.ToString();
            string type26 = SeriesChartType.SplineRange.ToString();
            string type27 = SeriesChartType.StackedArea.ToString();
            string type28 = SeriesChartType.StackedArea100.ToString();
            string type29 = SeriesChartType.StackedBar.ToString();
            string type30 = SeriesChartType.StackedBar100.ToString();
            string type31 = SeriesChartType.StackedColumn.ToString();
            string type32 = SeriesChartType.StackedColumn100.ToString();
            string type33 = SeriesChartType.StepLine.ToString();
            string type34 = SeriesChartType.Stock.ToString();
            string type35 = SeriesChartType.ThreeLineBreak.ToString();

            strList.Add(type1);
            strList.Add(type2);
            strList.Add(type3);
            strList.Add(type4);
            strList.Add(type5);
            strList.Add(type6);
            strList.Add(type7);
            strList.Add(type8);
            strList.Add(type9);
            strList.Add(type10);
            strList.Add(type11);
            strList.Add(type12);
            strList.Add(type13);
            strList.Add(type14);
            strList.Add(type15);
            strList.Add(type16);
            strList.Add(type17);
            strList.Add(type18);
            strList.Add(type19);
            strList.Add(type20);
            strList.Add(type21);
            strList.Add(type22);
            strList.Add(type23);
            strList.Add(type24);
            strList.Add(type25);
            strList.Add(type26);
            strList.Add(type27);
            strList.Add(type28);
            strList.Add(type29);
            strList.Add(type30);
            strList.Add(type31);
            strList.Add(type32);
            strList.Add(type33);
            strList.Add(type34);
            strList.Add(type35);

            cmbChartTypeRedeems.DataSource = strList;
        }

        private void cmbChartTypeEarns_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string type1 = SeriesChartType.Area.ToString();
                string type2 = SeriesChartType.Bar.ToString();
                string type3 = SeriesChartType.BoxPlot.ToString();
                string type4 = SeriesChartType.Bubble.ToString();
                string type5 = SeriesChartType.Candlestick.ToString();
                string type6 = SeriesChartType.Column.ToString();
                string type7 = SeriesChartType.Doughnut.ToString();
                string type8 = SeriesChartType.ErrorBar.ToString();
                string type9 = SeriesChartType.FastLine.ToString();
                string type10 = SeriesChartType.FastPoint.ToString();
                string type11 = SeriesChartType.Funnel.ToString();
                string type12 = SeriesChartType.Kagi.ToString();
                string type13 = SeriesChartType.Line.ToString();
                string type14 = SeriesChartType.Pie.ToString();
                string type15 = SeriesChartType.Point.ToString();
                string type16 = SeriesChartType.PointAndFigure.ToString();
                string type17 = SeriesChartType.Polar.ToString();
                string type18 = SeriesChartType.Pyramid.ToString();
                string type19 = SeriesChartType.Radar.ToString();
                string type20 = SeriesChartType.Range.ToString();
                string type21 = SeriesChartType.RangeBar.ToString();
                string type22 = SeriesChartType.RangeColumn.ToString();
                string type23 = SeriesChartType.Renko.ToString();
                string type24 = SeriesChartType.Spline.ToString();
                string type25 = SeriesChartType.SplineArea.ToString();
                string type26 = SeriesChartType.SplineRange.ToString();
                string type27 = SeriesChartType.StackedArea.ToString();
                string type28 = SeriesChartType.StackedArea100.ToString();
                string type29 = SeriesChartType.StackedBar.ToString();
                string type30 = SeriesChartType.StackedBar100.ToString();
                string type31 = SeriesChartType.StackedColumn.ToString();
                string type32 = SeriesChartType.StackedColumn100.ToString();
                string type33 = SeriesChartType.StepLine.ToString();
                string type34 = SeriesChartType.Stock.ToString();
                string type35 = SeriesChartType.ThreeLineBreak.ToString();

                if (cmbChartTypeEarns.Text == SeriesChartType.Area.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Area;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Bar.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Bar;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.BoxPlot.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.BoxPlot;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Bubble.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Bubble;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Candlestick.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Candlestick;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Column.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Column;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Doughnut.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Doughnut;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.ErrorBar.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.ErrorBar;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.FastLine.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.FastLine;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.FastPoint.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.FastPoint;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Funnel.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Funnel;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Kagi.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Kagi;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Line.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Line;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Pie.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Pie;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Point.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Point;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.PointAndFigure.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.PointAndFigure;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Polar.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Polar;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Pyramid.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Pyramid;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Radar.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Radar;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Range.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Range;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.RangeBar.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.RangeBar;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.RangeColumn.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.RangeColumn;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Renko.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Renko;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Spline.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Spline;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.SplineArea.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.SplineArea;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.SplineRange.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.SplineRange;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.StackedArea.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StackedArea;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.StackedArea100.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StackedArea100;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.StackedBar.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StackedBar;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.StackedBar100.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StackedBar100;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.StackedColumn.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StackedColumn;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.StackedColumn100.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StackedColumn100;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.StepLine.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StepLine;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.Stock.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Stock;
                }
                else if (cmbChartTypeEarns.Text == SeriesChartType.ThreeLineBreak.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.ThreeLineBreak;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void dtpFromDateEarn_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayChartDetailsEarns();
                DisplayChartDetailsRedeems();
                SetLocationSummeryGridData();

                cmbChartTypeEarns.Text = SeriesChartType.Column.ToString();
                cmbChartTypeRedeems.Text = SeriesChartType.Column.ToString();
                //chrtEarns.Series["series"].ChartType = SeriesChartType.Column;
                //chrtRedeems.Series["series"].ChartType = SeriesChartType.Column;
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
                DisplayChartDetailsEarns();
                DisplayChartDetailsRedeems();
                SetLocationSummeryGridData();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void cmbChartTypeRedeems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string type1 = SeriesChartType.Area.ToString();
                string type2 = SeriesChartType.Bar.ToString();
                string type3 = SeriesChartType.BoxPlot.ToString();
                string type4 = SeriesChartType.Bubble.ToString();
                string type5 = SeriesChartType.Candlestick.ToString();
                string type6 = SeriesChartType.Column.ToString();
                string type7 = SeriesChartType.Doughnut.ToString();
                string type8 = SeriesChartType.ErrorBar.ToString();
                string type9 = SeriesChartType.FastLine.ToString();
                string type10 = SeriesChartType.FastPoint.ToString();
                string type11 = SeriesChartType.Funnel.ToString();
                string type12 = SeriesChartType.Kagi.ToString();
                string type13 = SeriesChartType.Line.ToString();
                string type14 = SeriesChartType.Pie.ToString();
                string type15 = SeriesChartType.Point.ToString();
                string type16 = SeriesChartType.PointAndFigure.ToString();
                string type17 = SeriesChartType.Polar.ToString();
                string type18 = SeriesChartType.Pyramid.ToString();
                string type19 = SeriesChartType.Radar.ToString();
                string type20 = SeriesChartType.Range.ToString();
                string type21 = SeriesChartType.RangeBar.ToString();
                string type22 = SeriesChartType.RangeColumn.ToString();
                string type23 = SeriesChartType.Renko.ToString();
                string type24 = SeriesChartType.Spline.ToString();
                string type25 = SeriesChartType.SplineArea.ToString();
                string type26 = SeriesChartType.SplineRange.ToString();
                string type27 = SeriesChartType.StackedArea.ToString();
                string type28 = SeriesChartType.StackedArea100.ToString();
                string type29 = SeriesChartType.StackedBar.ToString();
                string type30 = SeriesChartType.StackedBar100.ToString();
                string type31 = SeriesChartType.StackedColumn.ToString();
                string type32 = SeriesChartType.StackedColumn100.ToString();
                string type33 = SeriesChartType.StepLine.ToString();
                string type34 = SeriesChartType.Stock.ToString();
                string type35 = SeriesChartType.ThreeLineBreak.ToString();

                if (cmbChartTypeRedeems.Text == SeriesChartType.Area.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Area;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Bar.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Bar;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.BoxPlot.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.BoxPlot;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Bubble.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Bubble;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Candlestick.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Candlestick;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Column.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Column;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Doughnut.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Doughnut;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.ErrorBar.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.ErrorBar;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.FastLine.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.FastLine;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.FastPoint.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.FastPoint;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Funnel.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Funnel;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Kagi.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Kagi;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Line.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Line;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Pie.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Pie;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Point.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Point;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.PointAndFigure.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.PointAndFigure;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Polar.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Polar;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Pyramid.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Pyramid;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Radar.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Radar;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Range.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Range;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.RangeBar.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.RangeBar;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.RangeColumn.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.RangeColumn;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Renko.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Renko;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Spline.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Spline;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.SplineArea.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.SplineArea;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.SplineRange.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.SplineRange;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.StackedArea.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.StackedArea;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.StackedArea100.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.StackedArea100;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.StackedBar.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.StackedBar;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.StackedBar100.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.StackedBar100;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.StackedColumn.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.StackedColumn;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.StackedColumn100.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.StackedColumn100;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.StepLine.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.StepLine;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.Stock.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.Stock;
                }
                else if (cmbChartTypeRedeems.Text == SeriesChartType.ThreeLineBreak.ToString())
                {
                    chrtRedeems.Series["series"].ChartType = SeriesChartType.ThreeLineBreak;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        public void GetTotalCurrentPoints()
        {
            LoyaltyCustomer LoyaltyCustomer = new LoyaltyCustomer();
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();

            DataTable dtToday = loyaltyCustomerService.GetCustomerVisitToday(Common.GetSystemDate());
            DataTable dtYesterday = loyaltyCustomerService.GetCustomerVisitToday(Common.GetSystemDate().AddDays(-1));

            float orgTodayVisits, orgYesterdayVisits, orgExpectedVisits;

            orgTodayVisits = dtToday.Rows[0].Field<Int32>("TotalCustomers");
            orgYesterdayVisits = dtYesterday.Rows[0].Field<Int32>("TotalCustomers");
            orgExpectedVisits = ((orgTodayVisits + orgYesterdayVisits) / 2);

            float todayVisits = orgTodayVisits / 10;
            float yesterdayVisits = orgYesterdayVisits / 10;
            float expectedVisits = ((orgTodayVisits + orgYesterdayVisits) / 2) / 10;
            

            guageTodayVisit.Value = todayVisits;
            guageYesterDayVisit.Value = yesterdayVisits;
            guageExpectedVisit.Value = expectedVisits;

            lblTodayVisit.Text = orgTodayVisits.ToString();
            lblYesterdayVisit.Text = orgYesterdayVisits.ToString();
            lblExpectedVisit.Text = orgExpectedVisits.ToString();
        }

        private void btnNeedleToday_Click(object sender, EventArgs e)
        {
            try
            {
                if (guageTodayVisit.NeedleType == 0)
                {
                    guageTodayVisit.NeedleType = 1;
                }
                else
                {
                    guageTodayVisit.NeedleType = 0;
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
                if (guageYesterDayVisit.NeedleType == 0)
                {
                    guageYesterDayVisit.NeedleType = 1;
                }
                else
                {
                    guageYesterDayVisit.NeedleType = 0;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void btnNeedleExpected_Click(object sender, EventArgs e)
        {
            try
            {
                if (guageExpectedVisit.NeedleType == 0)
                {
                    guageExpectedVisit.NeedleType = 1;
                }
                else
                {
                    guageExpectedVisit.NeedleType = 0;
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

                chrtEarns.ChartAreas[0].CursorX.Interval = 0;
                chrtEarns.ChartAreas[0].CursorY.Interval = 0;

                chrtEarns.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                chrtEarns.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);

                //lblX.Text = "Pixe X Position : " + chrtEarns.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString();
                //lblX.Text = "Pixe Y Position : " + chrtEarns.ChartAreas[0].AxisY.PixelPositionToValue(e.Y).ToString();

                HitTestResult result = chrtEarns.HitTest(e.X, e.Y);

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

        private void chrtRedeems_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Point mousePoint = new Point(e.X, e.Y);

                chrtRedeems.ChartAreas[0].CursorX.Interval = 0;
                chrtRedeems.ChartAreas[0].CursorY.Interval = 0;

                chrtRedeems.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                chrtRedeems.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);

                HitTestResult result = chrtRedeems.HitTest(e.X, e.Y);

                if (result.PointIndex > -1 && result.ChartArea != null)
                {
                    lblYValueRedeem.Text = "Y - Value : " + result.Series.Points[result.PointIndex].YValues[0].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshPage();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        private void RefreshPage() 
        {
            int todayMaxValue = (int)guageTodayVisit.MaxValue;
            int yesterDayMaxValue = (int)guageYesterDayVisit.MaxValue;
            int ExpectedMaxValue = (int)guageExpectedVisit.MaxValue;

            //lblTodayVisit.Text = "0";
            //lblYesterdayVisit.Text = "0";
            //lblExpectedVisit.Text = "0";

            for (int i = 0; i <= todayMaxValue; i++)
            {
                guageTodayVisit.Value = i;
            }

            for (int i = 0; i <= yesterDayMaxValue; i++)
            {
                guageYesterDayVisit.Value = i;
            }

            for (int i = 0; i <= ExpectedMaxValue; i++)
            {
                guageExpectedVisit.Value = i;
            }

            GetTotalCurrentPoints();
        }

        private void AnimateGuages()  
        {
            //int todayCurrentValue = (int)guageTodayVisit.Value;
            //int yesterCurrentValue = (int)guageYesterDayVisit.Value;
            //int ExpectedCurrentValue = (int)guageExpectedVisit.Value;

            int todayMaxValue = (int)guageTodayVisit.MaxValue / 3;
            int yesterDayMaxValue = (int)guageYesterDayVisit.MaxValue / 2;
            int ExpectedMaxValue = (int)guageExpectedVisit.MaxValue;

            for (int i = 0; i <= todayMaxValue; i++)
            {
                guageTodayVisit.Value = i;
            }

            for (int i = 0; i <= yesterDayMaxValue; i++)
            {
                guageYesterDayVisit.Value = i;
            }

            for (int i = 0; i <= ExpectedMaxValue; i++)
            {
                guageExpectedVisit.Value = i;
            }

            GetTotalCurrentPoints();
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

        private void SetLocationSummeryGridData()
        {
            LoyaltyCustomer LoyaltyCustomer = new LoyaltyCustomer();
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();

            dgvLocationSummery.DataSource = null;
            dgvLocationSummery.DataSource = loyaltyCustomerService.GetLocationSummeryGridData(dtpFromDateEarn.Value, dtpToDateEarn.Value);
            dgvLocationSummery.Refresh();
        }

        private void GetTotalPurchases()  
        {
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
            DataTable dtTotalPurchases = loyaltyCustomerService.GetTotalPurchases(Common.GetSystemDate());

            string member = "";
            member = dtTotalPurchases.Rows[0]["TotalPurchases"].ToString();

            if (!string.IsNullOrEmpty(member))
            {
                ddControlTotalPurchases.DigitText = member;
            }
            else
            {
                ddControlTotalPurchases.DigitText = "0.00";
            }
        }

        private void GetTotalPurchasesTomorrow() 
        {
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
            DataTable dtTotalPurchases = loyaltyCustomerService.GetTotalPurchases(Common.GetSystemDate());

            string member = "";
            member = dtTotalPurchases.Rows[0]["TotalPurchases"].ToString();

            if (!string.IsNullOrEmpty(member))
            {
                ddControlTotalPurchases.DigitText = member;
            }
            else
            {
                ddControlTotalPurchases.DigitText = "0.00";
            }
        }

        public void GetCustomerCountAndPoints()
        {
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();

            lblTotalPoints.Text = labelPoints + " : " + loyaltyCustomerService.GetTotalCurrentPoints().ToString();
            lblTotalCustomers.Text = labelCustomerCount + " : " + loyaltyCustomerService.GetCustomerCount().ToString();
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
                    this.guageTodayVisit.BackColor = clrDialog.Color;
                    this.guageExpectedVisit.BackColor = clrDialog.Color;
                    this.guageYesterDayVisit.BackColor = clrDialog.Color;
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
                this.guageTodayVisit.BackColor = guageTodayVisitColor;
                this.guageExpectedVisit.BackColor = guageExpectedVisitColor;
                this.guageYesterDayVisit.BackColor = guageYesterDayVisitColor;
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            AnimateGuages();
        }

    }
}
