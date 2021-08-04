using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ERP.Report;
using ERP.Report.Com;
using ERP.Report.GV;
using ERP.Report.Inventory.Transactions.Reports;
using ERP.Report.CRM;
using ERP.Service;
using ERP.Domain;
using ERP.UI.Windows;
using ERP.UI.Windows.Reports;
using ERP.Utility;
using System.Collections;
using ERP.Report.Inventory;
using System.Reflection;
using ERP.Report.CRM.Reports;
using ERP.Report.GUI;

namespace ERP.Report.GUI
{
    public partial class FrmDobReport : FrmBaseReportsForm
    {
        private AutoGenerateInfo autoGenerateInfo;
        private string monthNumber, date, gender, mobileCodeNumber;
        private int gendertype;

        public FrmDobReport(AutoGenerateInfo autoGenerateInfoPrm)
        {
            InitializeComponent();
            autoGenerateInfo = autoGenerateInfoPrm;
        }

        public override void InitializeForm()
        {
            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
            LocationService locationService = new LocationService();

            base.InitializeForm();
        }

        public override void FormLoad()
        {
            //AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
            //autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm(this.Name);

            this.Text = autoGenerateInfo.FormText;

            base.FormLoad();
        }

        public override void ClearForm()
        {
            try
            {
                this.Cursor = Cursors.Default;

                base.ClearForm();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoMonthDate.Checked)
                {
                    ViewReportDob();
                }
                else if (rdoMobile.Checked)
                {
                    ViewReportMobileNumberWise();
                }
                else
                {
                    ViewReportGenderType();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void ViewReportDob() // 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptDobReport crmRptDobReport = new CrmRptDobReport();

            crmRptDobReport.SetDataSource(loyaltyReportService.GetDobReport(monthNumber, date));

            crmRptDobReport.SummaryInfo.ReportTitle = "DOB Report";
            crmRptDobReport.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptDobReport.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptDobReport.DataDefinition.FormulaFields["Month"].Text = "'" + cmbMonth.Text + "'";
            crmRptDobReport.DataDefinition.FormulaFields["Date"].Text = "'" + cmbDate.Text + "'";

            crmRptDobReport.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptDobReport.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptDobReport.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptDobReport.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptDobReport;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void ViewReportMobileNumberWise() // 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptDobReport crmRptDobReport = new CrmRptDobReport();

            crmRptDobReport.SetDataSource(loyaltyReportService.GetMobileNumberWiseReport(mobileCodeNumber));

            crmRptDobReport.SummaryInfo.ReportTitle = "Mobile Network Wise Report";
            crmRptDobReport.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptDobReport.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptDobReport.DataDefinition.FormulaFields["Month"].Text = "'" + cmbMonth.Text + "'";
            crmRptDobReport.DataDefinition.FormulaFields["Date"].Text = "'" + cmbDate.Text + "'";

            crmRptDobReport.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptDobReport.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptDobReport.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptDobReport.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptDobReport;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }


        private void ViewReportGenderType() // 
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();
            CrmRptDobReport crmRptDobReport = new CrmRptDobReport();

            crmRptDobReport.SetDataSource(loyaltyReportService.GetGenderWiseReport(gendertype));

            crmRptDobReport.SummaryInfo.ReportTitle = "Gender Wise Report";
            crmRptDobReport.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptDobReport.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptDobReport.DataDefinition.FormulaFields["Month"].Text = "'" + cmbMonth.Text + "'";
            crmRptDobReport.DataDefinition.FormulaFields["Date"].Text = "'" + cmbDate.Text + "'";

            crmRptDobReport.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptDobReport.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptDobReport.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptDobReport.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

            objReportView.crRptViewer.ReportSource = crmRptDobReport;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void rdoMonthDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMonthDate.Checked)
            {
                grpMonthDate.Enabled = true;
                grpGender.Enabled = false;
                grpMobileNetwork.Enabled = false;
            }
        }

        private void rdoMobile_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMobile.Checked)
            {
                grpMobileNetwork.Enabled = true;
                grpGender.Enabled = false;
                grpMonthDate.Enabled = false;
            }
        }

        private void rdoGender_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGender.Checked)
            {
                grpGender.Enabled = true;
                grpMobileNetwork.Enabled = false;
                grpMonthDate.Enabled = false;
            }
        }


        private string GetMonthNumber(string month)
        {
            switch (month)
            {
                case "Jan" :
                    return "01";
                case "Feb":
                    return "02";
                case "Mar":
                    return "03";
                case "Apr":
                    return "04";
                case "May":
                    return "05";
                case "Jun":
                    return "06";
                case "Jul":
                    return "07";
                case "Aug":
                    return "08";
                case "Sep":
                    return "09";
                case "Oct":
                    return "10";
                case "Nov":
                    return "11";
                case "Dec":
                    return "12";
                default:
                    return "%";
            }
        }


        private string GetMobileCodeNumber(string network)
        {
            switch (network)
            {
                case "Dialog":
                    return "077";
                case "Mobitel":
                    return "071";
                case "Etisalat":
                    return "072";
                case "Hutch":
                    return "078";
                case "Airtel":
                    return "075";
                default:
                    return "%";
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                monthNumber = GetMonthNumber(cmbMonth.Text.Trim());
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                date = cmbDate.Text.Trim();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void cmbNetwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mobileCodeNumber = GetMobileCodeNumber(cmbNetwork.Text.Trim());
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CommonService commonService = new CommonService();
                gendertype = commonService.GendertypeFromReferenceType(((int)LookUpReference.GenderType).ToString(), cmbGender.Text.Trim());
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

    }
}
