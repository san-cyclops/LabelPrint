using ERP.Domain;
using ERP.Service;
using ERP.UI.Windows;
using ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Report.CRM.Reports;

namespace ERP.Report.GUI
{
    public partial class FrmCrmCustomerWiseTransaction : FrmBaseReportsForm
    {
        public FrmCrmCustomerWiseTransaction()
        {
            InitializeComponent();
        }

        int documentID=0;
        DateTime dateEarnFrom;
        DateTime dateEarnTo;
        DateTime dateRedeemFrom;
        DateTime dateRedeemTo;
        DateTime datePurchaseFrom;
        DateTime datePurchaseTo;
        decimal pointsEarn;
        decimal pointsRedeem;
        decimal pointsPurchase;

        #region Override Methosds

        public override void FormLoad()
        {
            AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
            autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm(this.Name);
            documentID = autoGenerateInfo.DocumentID;
            this.Text = autoGenerateInfo.FormText.Trim();
            base.FormLoad();
        }

        #endregion

        #region Other
        private void rdoPointsEarn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPointsEarn.Checked)
            {
                grpPointsEarn.Enabled = true;
                grpPointRedeem.Enabled = false;
                grpPointPurchase.Enabled = false;
            }
        }

        private void rdoPointsRedeem_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPointsRedeem.Checked)
            {
                grpPointRedeem.Enabled = true;
                grpPointsEarn.Enabled = false;
                grpPointPurchase.Enabled = false;
            }
        }

        private void rdoPointsPurchase_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPurchase.Checked)
            {
                grpPointPurchase.Enabled = true;
                grpPointRedeem.Enabled = false;
                grpPointsEarn.Enabled = false;
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            bool IsValidate;
            if (grpPointsEarn.Enabled)
            {
                IsValidate = Validater.ValidateTextBox("",errorProvider, Validater.ValidateType.Empty, txtEarnPointsGraterThan);
                if (!IsValidate)
                { return; }
                ViewPointsEarnReport();
            }
            if (grpPointRedeem.Enabled)
            {
                IsValidate = Validater.ValidateTextBox("",errorProvider, Validater.ValidateType.Empty, txtRedeemPointsGraterThan);
                if (!IsValidate)
                { return; }
                ViewPointsRedeemReport();
            }
            if (grpPointPurchase.Enabled)
            {
                IsValidate = Validater.ValidateTextBox("",errorProvider, Validater.ValidateType.Empty, txtPurchasePointsGraterThan);
                if (!IsValidate)
                { return; }
                ViewPurchaseReport();
            }


        }
        #endregion

        #region private Methods

        private void ViewPointsEarnReport()
        {
            dateEarnFrom = dtpEarnFrom.Value.Date;
            dateEarnTo = dtpEarnTo.Value.Date;
            pointsEarn = Common.ConvertStringToDecimal(txtEarnPointsGraterThan.Text.Trim());

            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();

            CrmRptCustomerWisePointsEarn crmRptCustomerWisePointsEarn = new CrmRptCustomerWisePointsEarn();

            crmRptCustomerWisePointsEarn.SetDataSource(loyaltyReportService.GetCustumerWisePointsEarn(dateEarnFrom,dateEarnTo,pointsEarn));

            crmRptCustomerWisePointsEarn.SummaryInfo.ReportTitle = "Points Earn";
            crmRptCustomerWisePointsEarn.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpEarnFrom.Value + "'";
            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpEarnTo.Value + "'";

          

            objReportView.crRptViewer.ReportSource = crmRptCustomerWisePointsEarn;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }
        private void ViewPointsRedeemReport()
        {
            dateRedeemFrom = dtpRedeemFrom.Value.Date;
            dateRedeemTo = dtpRedeemTo.Value.Date;
            pointsRedeem = Common.ConvertStringToDecimal(txtRedeemPointsGraterThan.Text.Trim());

            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();

            CrmRptCustomerWisePointsEarn crmRptCustomerWisePointsEarn = new CrmRptCustomerWisePointsEarn();

            crmRptCustomerWisePointsEarn.SetDataSource(loyaltyReportService.GetCustumerWisePointsRedeem(dateRedeemFrom, dateRedeemTo,pointsRedeem));

            crmRptCustomerWisePointsEarn.SummaryInfo.ReportTitle = "Points Redeem";
            crmRptCustomerWisePointsEarn.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpEarnFrom.Value + "'";
            crmRptCustomerWisePointsEarn.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpEarnTo.Value + "'";



            objReportView.crRptViewer.ReportSource = crmRptCustomerWisePointsEarn;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }
        private void ViewPurchaseReport()
        {
            datePurchaseFrom = dtpPurchaseFrom.Value.Date;
            datePurchaseTo = dtpPurchaseTo.Value.Date;
            pointsPurchase = Common.ConvertStringToDecimal(txtPurchasePointsGraterThan.Text.Trim());

            FrmReportViewer objReportView = new FrmReportViewer();
            LoyaltyReportService loyaltyReportService = new LoyaltyReportService();

            CrmRptCustomerWisePointsPurchase crmRptCustomerWisePointsPurchase = new CrmRptCustomerWisePointsPurchase();

            crmRptCustomerWisePointsPurchase.SetDataSource(loyaltyReportService.GetCustumerWisePointPurchase(datePurchaseFrom, datePurchaseTo,pointsPurchase));

            crmRptCustomerWisePointsPurchase.SummaryInfo.ReportTitle = "Points Purchase";
            crmRptCustomerWisePointsPurchase.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

            crmRptCustomerWisePointsPurchase.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
            crmRptCustomerWisePointsPurchase.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
            crmRptCustomerWisePointsPurchase.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            crmRptCustomerWisePointsPurchase.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            crmRptCustomerWisePointsPurchase.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            crmRptCustomerWisePointsPurchase.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpEarnFrom.Value + "'";
            crmRptCustomerWisePointsPurchase.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpEarnTo.Value + "'";



            objReportView.crRptViewer.ReportSource = crmRptCustomerWisePointsPurchase;
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        #endregion

       
    }
}
