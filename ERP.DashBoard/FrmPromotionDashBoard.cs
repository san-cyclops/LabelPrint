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
using System.Threading;

using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;

namespace ERP.DashBoard
{
    public partial class FrmPromotionDashBoard : FrmBaseMasterForm
    {
        Color backgroundColor = new Color();

        public FrmPromotionDashBoard()
        {
            InitializeComponent();
        }

        public override void FormLoad()
        {
            dgvOnGoingPromotions.AutoGenerateColumns = false;
            dgvSummery.AutoGenerateColumns = false;

            DisplayChartDetailsPromotionSales();
            DisplayChartDetailsPromotionDiscounts();

            GetChartTypeToComboPromotionSale();
            cmbChartTypePromotionSale.Text = SeriesChartType.Doughnut.ToString();
            chrtPromotionSale.Text = "Location Wise Promotion Sale";

            GetChartTypeToComboPromotionDiscount();
            cmbChartTypePromotionDiscount.Text = SeriesChartType.Funnel.ToString();
            chrtDiscount.Text = "Location Wise Promotion Sale";

            GetDefaultBackColors();
            GetOnGoingPromotions();

            base.FormLoad();
        }

        public void GetDefaultBackColors()
        {
            backgroundColor = this.BackColor;
        }

        private void GetOnGoingPromotions()
        {
            InvPromotionMasterService invPromotionMasterService = new InvPromotionMasterService();

            dgvOnGoingPromotions.DataSource = null;
            dgvOnGoingPromotions.DataSource = invPromotionMasterService.GetOnGoingPromotions(Common.GetSystemDate());
            dgvOnGoingPromotions.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.digitalDisplayControl1.DigitText = DateTime.Now.ToString("HH:mm:ss");
        }

        private void dtpToDateEarn_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFromDateEarn_ValueChanged(object sender, EventArgs e)
        {

        }
         
        private void DisplayChartDetailsPromotionSales()
        {
            InvPromotionMasterService invPromotionMasterService = new InvPromotionMasterService();

            chrtPromotionSale.DataSource = invPromotionMasterService.GetPromotionSale(dtpFromDate.Value, dtpToDate.Value);

            chrtPromotionSale.Series["series"].XValueMember = "LocationPrefixCode";
            chrtPromotionSale.Series["series"].YValueMembers = "Sale";

            //chrtPromotionSale.Series["series"].IsValueShownAsLabel = true;
            chrtPromotionSale.ChartAreas["area"].AxisX.Interval = 1;

            chrtPromotionSale.DataBind();
            chrtPromotionSale.Update();

            //GetChartTypeToComboEarn();
            //GetChartTypeToComboRedeem();
        }

        private void DisplayChartDetailsPromotionDiscounts() 
        {
            InvPromotionMasterService invPromotionMasterService = new InvPromotionMasterService();

            chrtDiscount.DataSource = invPromotionMasterService.GetPromotionDiscount(dtpFromDate.Value, dtpToDate.Value);

            chrtDiscount.Series["series"].XValueMember = "LocationPrefixCode";
            chrtDiscount.Series["series"].YValueMembers = "Discount";

            //chrtPromotionSale.Series["series"].IsValueShownAsLabel = true;
            chrtDiscount.ChartAreas["area"].AxisX.Interval = 1;

            chrtDiscount.DataBind();
            chrtDiscount.Update();

            //GetChartTypeToComboEarn();
            //GetChartTypeToComboRedeem();
        }

        private void GetChartTypeToComboPromotionSale() 
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

            cmbChartTypePromotionSale.DataSource = strList;
            //cmbChartTypeRedeems.DataSource = strList;
        }

        private void GetChartTypeToComboPromotionDiscount() 
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

            cmbChartTypePromotionDiscount.DataSource = strList;
        }

        private void cmbChartTypePromotionSale_SelectedIndexChanged(object sender, EventArgs e)
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

                if (cmbChartTypePromotionSale.Text == SeriesChartType.Area.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Area;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Bar.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Bar;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.BoxPlot.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.BoxPlot;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Bubble.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Bubble;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Candlestick.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Candlestick;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Column.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Column;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Doughnut.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Doughnut;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.ErrorBar.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.ErrorBar;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.FastLine.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.FastLine;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.FastPoint.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.FastPoint;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Funnel.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Funnel;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Kagi.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Kagi;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Line.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Line;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Pie.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Pie;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Point.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Point;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.PointAndFigure.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.PointAndFigure;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Polar.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Polar;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Pyramid.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Pyramid;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Radar.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Radar;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Range.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Range;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.RangeBar.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.RangeBar;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.RangeColumn.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.RangeColumn;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Renko.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Renko;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Spline.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Spline;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.SplineArea.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.SplineArea;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.SplineRange.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.SplineRange;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.StackedArea.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.StackedArea;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.StackedArea100.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.StackedArea100;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.StackedBar.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.StackedBar;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.StackedBar100.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.StackedBar100;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.StackedColumn.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.StackedColumn;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.StackedColumn100.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.StackedColumn100;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.StepLine.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.StepLine;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.Stock.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.Stock;
                }
                else if (cmbChartTypePromotionSale.Text == SeriesChartType.ThreeLineBreak.ToString())
                {
                    chrtPromotionSale.Series["series"].ChartType = SeriesChartType.ThreeLineBreak;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayChartDetailsPromotionSales();
                cmbChartTypePromotionSale.Text = SeriesChartType.Doughnut.ToString();
                
                DisplayChartDetailsPromotionDiscounts();
                cmbChartTypePromotionDiscount.Text = SeriesChartType.Funnel.ToString();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayChartDetailsPromotionSales();
                cmbChartTypePromotionSale.Text = SeriesChartType.Doughnut.ToString();

                DisplayChartDetailsPromotionDiscounts();
                cmbChartTypePromotionDiscount.Text = SeriesChartType.Funnel.ToString();
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
        
        private void chrtPromotionSale_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Point mousePoint = new Point(e.X, e.Y);

                chrtPromotionSale.ChartAreas[0].CursorX.Interval = 0;
                chrtPromotionSale.ChartAreas[0].CursorY.Interval = 0;

                chrtPromotionSale.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                chrtPromotionSale.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);

                //lblXValue.Text = "Pixe X Position : " + chrtPromotionSale.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString();
                //lblSaleValue.Text = "Pixe Y Position : " + chrtPromotionSale.ChartAreas[0].AxisY.PixelPositionToValue(e.Y).ToString();

                HitTestResult result = chrtPromotionSale.HitTest(e.X, e.Y);

                if (result.PointIndex > -1 && result.ChartArea != null)
                {
                    lblSaleValue.Text = "Y - Value : " + result.Series.Points[result.PointIndex].YValues[0].ToString();
                    //lblXValue.Text = "X - Value : " + result.Series.Points[result.PointIndex].XValue.ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void dgvOnGoingPromotions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (dgvOnGoingPromotions.CurrentCell != null && dgvOnGoingPromotions.CurrentCell.RowIndex >= 0)
            //    {
            //        if (dgvOnGoingPromotions["Promotion", dgvOnGoingPromotions.CurrentCell.RowIndex].Value == null)
            //        {
            //            Toast.Show("No data available to display", Toast.messageType.Information, Toast.messageAction.General, "");
            //            return;
            //        }
            //        else
            //        {
            //            InvPromotionMasterService invPromotionMasterService = new InvPromotionMasterService();
            //            dgvLocations.DataSource = invPromotionMasterService.GetPromotionLocations(Common.ConvertStringToLong(dgvOnGoingPromotions["PromotionID", dgvOnGoingPromotions.CurrentCell.RowIndex].Value.ToString().Trim()));

            //            pnlLocations.Visible = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.WriteLog(ex, MethodBase.GetCurrentMethod().Name, this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            //}
        }

        private void pnlLocations_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnlLocations.Visible == true)
                {
                    pnlLocations.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodBase.GetCurrentMethod().Name, this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
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

        private void cmbChartTypePromotionDiscount_SelectedIndexChanged(object sender, EventArgs e)
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

                if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Area.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Area;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Bar.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Bar;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.BoxPlot.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.BoxPlot;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Bubble.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Bubble;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Candlestick.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Candlestick;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Column.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Column;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Doughnut.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Doughnut;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.ErrorBar.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.ErrorBar;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.FastLine.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.FastLine;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.FastPoint.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.FastPoint;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Funnel.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Funnel;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Kagi.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Kagi;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Line.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Line;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Pie.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Pie;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Point.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Point;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.PointAndFigure.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.PointAndFigure;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Polar.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Polar;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Pyramid.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Pyramid;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Radar.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Radar;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Range.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Range;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.RangeBar.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.RangeBar;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.RangeColumn.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.RangeColumn;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Renko.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Renko;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Spline.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Spline;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.SplineArea.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.SplineArea;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.SplineRange.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.SplineRange;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.StackedArea.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.StackedArea;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.StackedArea100.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.StackedArea100;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.StackedBar.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.StackedBar;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.StackedBar100.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.StackedBar100;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.StackedColumn.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.StackedColumn;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.StackedColumn100.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.StackedColumn100;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.StepLine.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.StepLine;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.Stock.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.Stock;
                }
                else if (cmbChartTypePromotionDiscount.Text == SeriesChartType.ThreeLineBreak.ToString())
                {
                    chrtDiscount.Series["series"].ChartType = SeriesChartType.ThreeLineBreak;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void chrtDiscount_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Point mousePoint = new Point(e.X, e.Y);

                chrtDiscount.ChartAreas[0].CursorX.Interval = 0;
                chrtDiscount.ChartAreas[0].CursorY.Interval = 0;

                chrtDiscount.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                chrtDiscount.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);

                HitTestResult result = chrtDiscount.HitTest(e.X, e.Y);

                if (result.PointIndex > -1 && result.ChartArea != null)
                {
                    lblDiscountValue.Text = "Y - Value : " + result.Series.Points[result.PointIndex].YValues[0].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void dgvOnGoingPromotions_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (dgvOnGoingPromotions.CurrentCell != null && dgvOnGoingPromotions.CurrentCell.RowIndex >= 0)
                {
                    if (dgvOnGoingPromotions["Promotion", dgvOnGoingPromotions.CurrentCell.RowIndex].Value == null)
                    {
                        Toast.Show(this.Text,"No data available to display", "",Toast.messageType.Information, Toast.messageAction.General, "");
                        return;
                    }
                    else
                    {
                        InvPromotionMasterService invPromotionMasterService = new InvPromotionMasterService();
                        dgvLocations.DataSource = invPromotionMasterService.GetPromotionLocations(Common.ConvertStringToLong(dgvOnGoingPromotions["PromotionID", dgvOnGoingPromotions.CurrentCell.RowIndex].Value.ToString().Trim()));

                        txtPromotionName.Text = dgvOnGoingPromotions["Promotion", dgvOnGoingPromotions.CurrentCell.RowIndex].Value.ToString().Trim();

                        pnlLocations.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodBase.GetCurrentMethod().Name, this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                InvPromotionMasterService invPromotionMasterService = new InvPromotionMasterService();

                if (invPromotionMasterService.SetSaleAndPromotionSummery(dtpFromDate.Value, dtpToDate.Value))
                {
                    dgvSummery.DataSource = null;
                    dgvSummery.DataSource = invPromotionMasterService.GetSaleAndPromotionSummery();
                    dgvSummery.Refresh();
                }
                else
                {
                    Toast.Show(this.Text,"Error","", Toast.messageType.Error, Toast.messageAction.General);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodBase.GetCurrentMethod().Name, this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

    }
}
