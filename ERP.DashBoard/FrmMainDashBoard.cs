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
    public partial class FrmMainDashBoard : FrmBaseMasterForm
    {
        public FrmMainDashBoard()
        {
            InitializeComponent();
        }

        public override void FormLoad()
        {
            base.FormLoad();
            this.pnlCrm.Visible = false;
            DisplayDetails();
        }

        private void btnCrm_Click(object sender, EventArgs e)
        {
            try
            {
                pnlCrm.Visible = true;
                DisplayChartDetails();
                cmbChartType.SelectedIndex = -1;
                chrtEarns.Series["series"].ChartType = SeriesChartType.Column;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void DisplayDetails()
        {
            lblToday.Text = lblToday.Text + " " + Common.GetSystemDate().ToShortDateString();
            lblYesterday.Text = lblYesterday.Text + " " + Common.GetSystemDate().AddDays(-1).ToShortDateString();
            lblExpected.Text = lblExpected.Text + " " + Common.GetSystemDate().AddDays(1).ToShortDateString();
        }

        private void DisplayChartDetails()
        {
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
            loyaltyCustomerService.GetDataSourceArapaimaToChart();

            chrtEarns.DataSource = loyaltyCustomerService.DsReport.Tables["LocationWiseSummery"];

            chrtEarns.Series["series"].XValueMember = "LocationPrefixCode";
            chrtEarns.Series["series"].YValueMembers = "TotalEarnpoints";
            chrtEarns.DataBind();
            chrtEarns.Update();

            chrtRedeems.DataSource = loyaltyCustomerService.DsReport.Tables["LocationWiseSummery"];

            chrtRedeems.Series["series"].XValueMember = "LocationPrefixCode";
            chrtRedeems.Series["series"].YValueMembers = "TotalRedeempoints";
            chrtRedeems.DataBind();
            chrtRedeems.Update();

            GetChartTypeToCombo();
        }

        private void GetChartTypeToCombo()
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

            cmbChartType.DataSource = strList;
        }

        private void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
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

                if (cmbChartType.Text == SeriesChartType.Area.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Area;
                }
                else if (cmbChartType.Text == SeriesChartType.Bar.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Bar;
                }
                else if (cmbChartType.Text == SeriesChartType.BoxPlot.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.BoxPlot;
                }
                else if (cmbChartType.Text == SeriesChartType.Bubble.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Bubble;
                }
                else if (cmbChartType.Text == SeriesChartType.Candlestick.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Candlestick;
                }
                else if (cmbChartType.Text == SeriesChartType.Column.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Column;
                }
                else if (cmbChartType.Text == SeriesChartType.Doughnut.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Doughnut;
                }
                else if (cmbChartType.Text == SeriesChartType.ErrorBar.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.ErrorBar;
                }
                else if (cmbChartType.Text == SeriesChartType.FastLine.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.FastLine;
                }
                else if (cmbChartType.Text == SeriesChartType.FastPoint.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.FastPoint;
                }
                else if (cmbChartType.Text == SeriesChartType.Funnel.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Funnel;
                }
                else if (cmbChartType.Text == SeriesChartType.Kagi.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Kagi;
                }
                else if (cmbChartType.Text == SeriesChartType.Line.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Line;
                }
                else if (cmbChartType.Text == SeriesChartType.Pie.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Pie;
                }
                else if (cmbChartType.Text == SeriesChartType.Point.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Point;
                }
                else if (cmbChartType.Text == SeriesChartType.PointAndFigure.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.PointAndFigure;
                }
                else if (cmbChartType.Text == SeriesChartType.Polar.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Polar;
                }
                else if (cmbChartType.Text == SeriesChartType.Pyramid.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Pyramid;
                }
                else if (cmbChartType.Text == SeriesChartType.Radar.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Radar;
                }
                else if (cmbChartType.Text == SeriesChartType.Range.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Range;
                }
                else if (cmbChartType.Text == SeriesChartType.RangeBar.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.RangeBar;
                }
                else if (cmbChartType.Text == SeriesChartType.RangeColumn.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.RangeColumn;
                }
                else if (cmbChartType.Text == SeriesChartType.Renko.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Renko;
                }
                else if (cmbChartType.Text == SeriesChartType.Spline.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Spline;
                }
                else if (cmbChartType.Text == SeriesChartType.SplineArea.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.SplineArea;
                }
                else if (cmbChartType.Text == SeriesChartType.SplineRange.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.SplineRange;
                }
                else if (cmbChartType.Text == SeriesChartType.StackedArea.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StackedArea;
                }
                else if (cmbChartType.Text == SeriesChartType.StackedArea100.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StackedArea100;
                }
                else if (cmbChartType.Text == SeriesChartType.StackedBar.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StackedBar;
                }
                else if (cmbChartType.Text == SeriesChartType.StackedBar100.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StackedBar100;
                }
                else if (cmbChartType.Text == SeriesChartType.StackedColumn.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StackedColumn;
                }
                else if (cmbChartType.Text == SeriesChartType.StackedColumn100.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StackedColumn100;
                }
                else if (cmbChartType.Text == SeriesChartType.StepLine.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.StepLine;
                }
                else if (cmbChartType.Text == SeriesChartType.Stock.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.Stock;
                }
                else if (cmbChartType.Text == SeriesChartType.ThreeLineBreak.ToString())
                {
                    chrtEarns.Series["series"].ChartType = SeriesChartType.ThreeLineBreak;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }
    }
}
