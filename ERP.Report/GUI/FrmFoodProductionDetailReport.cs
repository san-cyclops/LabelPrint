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
using ERP.Report.Inventory;
using System.Reflection;

namespace ERP.UI.Windows
{
    public partial class FrmFoodProductionDetailReport : FrmBaseReportsForm
    {
        int documentID = 0;
        UserPrivileges accessRights = new UserPrivileges();
        UserPrivileges percentageRights = new UserPrivileges();
        static string strReportName;

        public FrmFoodProductionDetailReport()
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
                autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm(strReportName);

                documentID = autoGenerateInfo.DocumentID;

                accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);
                percentageRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);



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

  

        public override void CloseForm(string formName)
        {
            try
            {
                formName = this.Text.Trim();
                base.CloseForm(formName);
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

            txtIngredientCode.Text = null;
            
            ChkAllLocations.Checked = false;
            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();

        }

        private bool ValidateComboBoxes()
        { 
             return Validater.ValidateComboBox(this.Text, errorProvider, Validater.ValidateType.Empty, cmbLocation);
        }

        public override void View()
        {

             LoadFoodProductionDetails();


        }

       
        public void LoadFoodProductionDetails()
        { 
             int locationId = 0;
             int terminalId = 0;
             Double txtIngredientCodeVal;

             DateTime dateFrom = dtpFromDate.Value;
             DateTime dateTo = dtpToDate.Value;
             txtIngredientCodeVal = Convert.ToDouble(txtIngredientCode.Text);

            if (dateFrom > dateTo)
              {
                 Toast.Show(this.Text, "", "", Toast.messageType.Information, Toast.messageAction.InvalidDateRange);
               return;
             }
            if (ChkAllLocations.Checked == true)
            {
                this.Cursor = Cursors.WaitCursor;

                PrintFoodProductionDetailReport(locationId, dateFrom, dateTo, txtIngredientCodeVal);
            }
            else
            {
                if (ChkAllLocations.Checked == true) { locationId = 0; } else { locationId = cmbLocation.SelectedIndex + 1; }
                 

                if (ChkAllLocations.Checked == false)
                {
                    if (ValidateComboBoxes().Equals(false)) { return; }
                }

                this.Cursor = Cursors.WaitCursor;

                PrintFoodProductionDetailReport(locationId, dateFrom, dateTo, txtIngredientCodeVal);



            }
            this.Cursor = Cursors.Default;
        }


       
        private void PrintFoodProductionDetailReport(int locationID, DateTime fromDate, DateTime toDate, Double txtIngredientCodeVal)
        {

             FrmReportViewer reportViewer = new FrmReportViewer();
            ////PosSaleCreditCardsServices posSaleCreditCardsServices = new PosSaleCreditCardsServices();
            InvSalesServices invsalesservices = new InvSalesServices();       
            InvRptFoodProductionDetail invRptFoodProductionDetail = new InvRptFoodProductionDetail();

            ////invRptFoodCosting.SetDataSource(posSaleCreditCardsServices.GetPosCreditCard());
            try
            {
                invRptFoodProductionDetail.SetDataSource(invsalesservices.GetFoodProductionDetails(locationID, txtIngredientCodeVal, fromDate, toDate, true));
                invRptFoodProductionDetail.SummaryInfo.ReportTitle = "Food Production Detail Report";
                invRptFoodProductionDetail.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                invRptFoodProductionDetail.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
                invRptFoodProductionDetail.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
                invRptFoodProductionDetail.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
                invRptFoodProductionDetail.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                invRptFoodProductionDetail.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptFoodProductionDetail.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                invRptFoodProductionDetail.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                //invRptFoodProductionDetail.PrintToPrinter(1, false, 0, 0);
                reportViewer.crRptViewer.ReportSource = invRptFoodProductionDetail;
                reportViewer.WindowState = FormWindowState.Maximized;
                reportViewer.Show();
                Cursor.Current = Cursors.Default;
            }
            catch(Exception ex)
            {

            }
           
          
        }

        private void txtIngredientCode_KeyDown(object sender, KeyEventArgs e)
        {
            try 
            {
                if (e.KeyCode.Equals(Keys.F3))
                {
                    InvProductMasterService invProductMasterService = new InvProductMasterService();

                    DataView dvAllReferenceData = new DataView(Common.DataTableColumnNameChange(invProductMasterService.GetProductIngredientsDataTable()));
                    if (dvAllReferenceData.Count != 0)
                    {
                         LoadReferenceSearchForm(dvAllReferenceData, this.Name.Trim(), this.Text.Trim(), this.ActiveControl.Text.Trim(), txtIngredientCode, 0, 0, 4);
                       // txtIngredientCode_Leave(this, e);
                    }
                } 
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    if (!string.IsNullOrEmpty(txtIngredientCode.Text.Trim()))
                    {
                        dtpFromDate.Focus();
                    }
                   // TxtSearchCodeTo.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        private void LoadReferenceSearchForm(DataView dvAllReferenceData, string parentOfSearch, string searchFormCaption, string searchText, Control focusControl, int focusOrder, int defaultSearchIndex, int defaultOperandIndex = 0)
        {
            try
            {
                FrmReferenceSearch referenceSearch = new FrmReferenceSearch();
                referenceSearch.ParentOfSearch = parentOfSearch.Trim();
                referenceSearch.FormCaption = searchFormCaption.Trim();
                referenceSearch.SearchText = searchText.Trim();
                referenceSearch.DvResults = dvAllReferenceData;
                referenceSearch.FocusControl = focusControl;
                referenceSearch.FocusOrder = focusOrder;
                referenceSearch.DefaultSearchIndex = defaultSearchIndex;
                referenceSearch.DvResults = dvAllReferenceData;
                referenceSearch.DefaultOperandIndex = defaultOperandIndex;

                if (referenceSearch.IsDisposed)
                {
                    referenceSearch = new FrmReferenceSearch();
                }

                foreach (Form frm in Application.OpenForms)
                {
                    if (frm is FrmReferenceSearch)
                    {
                        FrmReferenceSearch masterSearch2 = (FrmReferenceSearch)frm;
                        if (string.Equals(masterSearch2.ParentOfSearch.Trim(), this.Name.Trim()))
                        {
                            return;
                        }
                    }
                }

                referenceSearch.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtIngredientCode_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(lblIngredientCode);
                 if (string.IsNullOrEmpty(txtIngredientCode.Text.Trim()))
                {
                    return;
                }
                InvProductMaster invProductMaster = new InvProductMaster();
                if (Common.IsBatch)
                {
                    InvProductStockMasterService invProductStockMasterService = new InvProductStockMasterService();
                    invProductMaster = invProductStockMasterService.GetProductMasterBystockCode(txtIngredientCode.Text.Trim());

                    if (invProductMaster != null)
                    {
                        txtIngredientCode.Text = invProductMaster.ProductCode;
                 //       TxtSearchNameFrom.Text = invProductMaster.ProductName;
                    }

                }
                else
                {
                    InvProductMasterService invProductMasterService = new InvProductMasterService();


                   // invProductMaster = invProductMasterService.GetProductsByCode(TxtSearchCodeFrom.Text.Trim());

                    if (invProductMaster != null)
                    {
                     //   TxtSearchCodeFrom.Text = invProductMaster.ProductCode;
                     //   TxtSearchNameFrom.Text = invProductMaster.ProductName;
                    }
                }




            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        //private void btnView_Click(object sender, EventArgs e)
        //{


        //}

        //private void btnClear_Click(object sender, EventArgs e)
        //{

        //}



        //private void btnSave_Click(object sender, EventArgs e)
        //{

        //}

        //private void cmbLocation_Enter(object sender, EventArgs e)
        //{
        //    //Common.HighlightControl(lblLocation);
        //}

        //private void cmbLocation_Leave(object sender, EventArgs e)
        //{
        //    //Common.UnHighlightControl(lblLocation);
        //}

        //private void cmbTerminal_Enter(object sender, EventArgs e)
        //{
        //    //Common.HighlightControl(lblTerminal);
        //}

        //private void cmbTerminal_Leave(object sender, EventArgs e)
        //{
        //    //Common.UnHighlightControl(lblTerminal);
        //}

        //private void dtpFromDate_Enter(object sender, EventArgs e)
        //{
        //    //Common.HighlightControl(lblDateRange);
        //}

        //private void dtpFromDate_Leave(object sender, EventArgs e)
        //{
        //    //Common.UnHighlightControl(lblDateRange);
        //}

        //private void dtpToDate_Enter(object sender, EventArgs e)
        //{
        //    //Common.HighlightControl(lblToDate);
        //}

        //private void dtpToDate_Leave(object sender, EventArgs e)
        //{
        //    //Common.UnHighlightControl(lblToDate);
        //}

        //private void ChkLocationWise_Enter(object sender, EventArgs e)
        //{
        //   // Common.HighlightControl(ChkLocationWise);
        //}

        //private void ChkLocationWise_Leave(object sender, EventArgs e)
        //{
        //    //Common.UnHighlightControl(ChkLocationWise);
        //}

        //private void ChkAllLocations_Enter(object sender, EventArgs e)
        //{
        //    Common.HighlightControl(ChkAllLocations);
        //}

        //private void ChkAllLocations_Leave(object sender, EventArgs e)
        //{
        //    Common.UnHighlightControl(ChkAllLocations);
        //}

        //private void ChkAllTerminals_Enter(object sender, EventArgs e)
        //{
        //    Common.HighlightControl(ChkAllTerminals);
        //}

        //private void ChkAllTerminals_Leave(object sender, EventArgs e)
        //{
        //    Common.UnHighlightControl(ChkAllTerminals);
        //}

         private void ChkAllLocations_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAllLocations.Checked == true)
            {
                Common.ClearComboBox(cmbLocation);
                cmbLocation.Enabled = false;
            }
            else
            {
                cmbLocation.Enabled = true;
                //ChkLocationWise.Checked = false;
                cmbLocation.SelectedValue = Common.LoggedLocationID;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }
    }
}
