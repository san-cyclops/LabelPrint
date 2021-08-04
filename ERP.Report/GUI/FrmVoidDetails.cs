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
using ERP.Report.Logistic;
using ERP.Service;
using ERP.Domain;
using ERP.UI.Windows;
using ERP.UI.Windows.Reports;
using ERP.Utility;
using System.Collections;
using ERP.Report.Restaurant;
using System.Reflection;
using ERP.Report.Restaurant.Transactions.Reports;

namespace ERP.Report.GUI
{
    public partial class FrmVoidDetails : global::ERP.UI.Windows.FrmBaseReportsForm
    {

        int documentID = 0;
        UserPrivileges accessRights = new UserPrivileges();

        public FrmVoidDetails()
        {
            InitializeComponent();
        }

        public override void FormLoad()
        {
            try
            {

                // Load Locations
                LocationService locationService = new LocationService();
                Common.LoadLocations(cmbLocation, locationService.GetAllLocations());

                AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
                autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmVoidDetails");

                documentID = autoGenerateInfo.DocumentID;

                accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);
                this.Text = autoGenerateInfo.FormText.Trim();
                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();

                base.FormLoad();

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);

            }
        }

        

        public override void ClearForm()
        {
            base.ClearForm();

            Common.ClearComboBox(cmbLocation);
            cmbLocation.Focus();

            chkAllLocations.Checked = false;

            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();

        }

        private bool ValidateComboBoxes()
        {
            return Validater.ValidateComboBox(this.Text, errorProvider, Validater.ValidateType.Empty, cmbLocation);
        }

        public override void View()
        {

            ResSalesServices resSalesServices = new ResSalesServices();

            int locationId = 0;
            int voidType = 0;

            if (rdoFullVoid.Checked == true) { voidType = 1; }
            else if (rdoItemVoid.Checked == true) { voidType = 2; }

            DateTime dateFrom = dtpFromDate.Value;
            DateTime dateTo = dtpToDate.Value;

            if (dateFrom > dateTo)
            {
                Toast.Show(this.Text, "", "", Toast.messageType.Information, Toast.messageAction.InvalidDateRange);
                return;
            }

            if (voidType == 0)
            {
                Toast.Show(this.Text, "", "", Toast.messageType.Information, Toast.messageAction.ValidationFailed);
                return;
            }

            if (chkAllLocations.Checked == true) { locationId = 0; } else { locationId = cmbLocation.SelectedIndex + 1; }

            if (chkAllLocations.Checked == false)
            {
                if (ValidateComboBoxes().Equals(false)) { return; }
            }
            
            this.Cursor = Cursors.WaitCursor;

            if (resSalesServices.ViewVoidDetails(locationId, dateFrom, dateTo, voidType) == true)
            {
                ViewReport();

            }
            else
            {
                Toast.Show(this.Text, "Error in data Processing.", "", Toast.messageType.Error, Toast.messageAction.General);
                return;
            }
            
            this.Cursor = Cursors.Default;

        }

        private void ViewReport()
        {

            FrmReportViewer reportViewer = new FrmReportViewer();
            ResSalesServices resSalesServices = new ResSalesServices();

            ResRptVoidDetails resRptVoidDetails = new ResRptVoidDetails();

            resRptVoidDetails.SetDataSource(resSalesServices.GetVoidDetails());

            if (rdoFullVoid.Checked == true) { resRptVoidDetails.SummaryInfo.ReportTitle = "Full Void Details"; }
            else if (rdoItemVoid.Checked == true) { resRptVoidDetails.SummaryInfo.ReportTitle = "Item Void Details"; }

            resRptVoidDetails.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            resRptVoidDetails.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'"; 
            resRptVoidDetails.DataDefinition.FormulaFields["FromDate"].Text = "'" + dtpFromDate.Text + "'";
            resRptVoidDetails.DataDefinition.FormulaFields["ToDate"].Text = "'" + dtpToDate.Text + "'";
            resRptVoidDetails.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            resRptVoidDetails.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            resRptVoidDetails.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            resRptVoidDetails.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            reportViewer.crRptViewer.ReportSource = resRptVoidDetails;
            reportViewer.WindowState = FormWindowState.Maximized;
            reportViewer.Show();
            Cursor.Current = Cursors.Default;

        }

        private void chkAllLocations_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllLocations.Checked == true)
            {
                Common.ClearComboBox(cmbLocation);
                cmbLocation.Enabled = false;
            }
            else
            {
                cmbLocation.Enabled = true;
            }
        }
    }
}
