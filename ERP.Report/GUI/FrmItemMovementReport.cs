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
    public partial class FrmItemMovementReport : FrmBaseReportsForm
    {
        int documentID = 0;
        bool isValidControls = true;
        UserPrivileges accessRights = new UserPrivileges();
        UserPrivileges percentageRights = new UserPrivileges();
        InvProductMasterService invProduct = new InvProductMasterService();
        static string strReportName;
       

        public FrmItemMovementReport()
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
                cmbLocation.SelectedValue = Common.LoggedLocationID;

                LoadSearchCodes();
               
                base.FormLoad();



            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);

            }
        }
        private void LoadSearchCodes()
        {
            try
            {
                if (ChkAutoComplteFrom.Checked) { LoadProductsFrom(); }
                //if (ChkAutoComplteTo.Checked) { LoadProductsTo(); }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        private void LoadProductsFrom()
        {
            try
            {
                InvProductMasterService invProductMasterService = new InvProductMasterService();
                Common.SetAutoComplete(TxtSearchCodeFrom, invProductMasterService.GetAllProductCodes(), ChkAutoComplteFrom.Checked);
                //Common.SetAutoComplete(TxtSearchNameFrom, invProductMasterService.GetAllProductNames(), ChkAutoComplteFrom.Checked);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }
        //private void LoadProductsTo()
        //{
        //    try
        //    {
        //        InvProductMasterService invProductMasterService = new InvProductMasterService();
        //        Common.SetAutoComplete(TxtSearchCodeTo, invProductMasterService.GetAllProductCodes(), ChkAutoComplteTo.Checked);
               
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
        //    }
        //}


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
        private bool ValidateControls()
        {
            
            if (!Validater.ValidateTextBox(this.Text, errorProvider, Validater.ValidateType.Empty, TxtSearchCodeFrom))
            { return false; }

            else
            {
                isValidControls = true;
                this.ValidateChildren();

                return isValidControls;
            }
        }
        private bool ValidateLocationComboBoxes()
        {
            return Validater.ValidateComboBox(this.Text, errorProvider, Validater.ValidateType.Empty, cmbLocation);
        }

        public override void ClearForm()
        {
            base.ClearForm();

            Common.ClearComboBox(cmbLocation);
            cmbLocation.Focus();
            Common.ClearTextBox(TxtSearchCodeFrom);
            ChkAutoComplteFrom.Checked = false;
            //ChkAllLocations.Checked = false;
            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();

        }

        private bool ValidateComboBoxes()
        {
            return Validater.ValidateComboBox(this.Text, errorProvider, Validater.ValidateType.Empty,cmbLocation);
        }

        public override void View()
         {
            try
            {
              
                DateTime dateFrom;
                DateTime dateTo;
               
                dateFrom = dtpFromDate.Value;
                dateTo = dtpToDate.Value;

                if (ValidateLocationComboBoxes().Equals(false)) { return; }
   
                //if (ValidateControls() == false) return;

                if (dateFrom > dateTo)
                {
                    Toast.Show(this.Text, "", "", Toast.messageType.Information, Toast.messageAction.InvalidDate);
                    return;
                }

                if (!string.IsNullOrEmpty(TxtSearchCodeFrom.Text.Trim()) && string.IsNullOrEmpty(DepartmentCode.Text.Trim()))
                {
                    int locationId = Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString());
                    int departmentId = Common.ConvertStringToInt(DepartmentCode.Text.Trim());

                    if (invProduct.ViewItemMoment(locationId, dateFrom, dateTo, TxtSearchCodeFrom.Text.Trim(), departmentId) == true)
                    {
                        ViewItemMovementReport(locationId,departmentId);
                    }


                }

                 else if (string.IsNullOrEmpty(TxtSearchCodeFrom.Text.Trim()) && !string.IsNullOrEmpty(DepartmentCode.Text.Trim()))
                {
                    int locationId = Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString());
                    int departmentId = Common.ConvertStringToInt(DepartmentCode.Text.Trim());

                    if (invProduct.ViewItemMoment(locationId, dateFrom, dateTo, TxtSearchCodeFrom.Text.Trim(), departmentId) == true)
                    {
                        ViewItemMovementReport(locationId,departmentId);
                    }

                }
               
                else
                {


                    Toast.Show(this.Text, "Error", "", Toast.messageType.Information, Toast.messageAction.General);
                    return;

                }

            }


            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void ViewItemMovementReport(int locationId, int departmentID)
        {
            if (departmentID == 0)
            {
                FrmReportViewer objReportView = new FrmReportViewer();
                Cursor.Current = Cursors.WaitCursor;
                InvRptItemMovement invRptItemMovement = new InvRptItemMovement();
                invRptItemMovement.SetDataSource(invProduct.GetStockDetails(locationId, TxtSearchCodeFrom.Text.Trim(), departmentID));
                invRptItemMovement.SummaryInfo.ReportTitle = "Item Movement Report";
                invRptItemMovement.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                invRptItemMovement.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";
                invRptItemMovement.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Value + "'";
                invRptItemMovement.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Value + "'";
                invRptItemMovement.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                invRptItemMovement.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptItemMovement.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                invRptItemMovement.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                objReportView.crRptViewer.ReportSource = invRptItemMovement;

                objReportView.WindowState = FormWindowState.Maximized;
                objReportView.Show();
                Cursor.Current = Cursors.Default;
            }
            else {
                FrmReportViewer objReportView = new FrmReportViewer();
                Cursor.Current = Cursors.WaitCursor;
                InvRptItemMovementDepartment invRptItemMovementDepartment = new InvRptItemMovementDepartment();
                invRptItemMovementDepartment.SetDataSource(invProduct.GetStockDetails(locationId, TxtSearchCodeFrom.Text.Trim(), departmentID));
                invRptItemMovementDepartment.SummaryInfo.ReportTitle = "Item Movement Department Report";
                invRptItemMovementDepartment.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                invRptItemMovementDepartment.DataDefinition.FormulaFields["LocationName"].Text = "'" + cmbLocation.Text.Trim() + "'";
                invRptItemMovementDepartment.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Value + "'";
                invRptItemMovementDepartment.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                invRptItemMovementDepartment.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptItemMovementDepartment.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                invRptItemMovementDepartment.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                invRptItemMovementDepartment.DataDefinition.FormulaFields["DptName"].Text = "'" + txtDpt_Name.Text.Trim() + "'";
                objReportView.crRptViewer.ReportSource = invRptItemMovementDepartment;
                objReportView.WindowState = FormWindowState.Maximized;
                objReportView.Show();
                Cursor.Current = Cursors.Default;
            }
        }

       


        private void btnView_Click(object sender, EventArgs e)
        {
           

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

       

        private void cmbLocation_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblLocation);
        }

        private void cmbLocation_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblLocation);
        }

        private void cmbTerminal_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(LblSearchFrom);
        }

        private void cmbTerminal_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(LblSearchFrom);
        }

        private void dtpFromDate_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblDateRange);
        }

        private void dtpFromDate_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblDateRange);
        }

        private void dtpToDate_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblToDate);
        }

        private void dtpToDate_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblToDate);
        }


        private void ChkAllTerminals_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(ChkAutoComplteFrom);
        }

        private void ChkAllTerminals_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(ChkAutoComplteFrom);
        }

      
        private void TxtSearchCode_KeyLeave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(LblSearchFrom);
                if (string.IsNullOrEmpty(TxtSearchCodeFrom.Text.Trim())) { return; }
                InvProductMaster invproductmaster = new InvProductMaster();
                InvProductMasterService invproductmasterservice = new InvProductMasterService();

                invproductmaster = invproductmasterservice.GetProductsByCode(TxtSearchCodeFrom.Text.Trim());

                if (invproductmaster != null)
                {
                    TxtSearchCodeFrom.Text = invproductmaster.ProductCode;
                    //TxtSearchNameFrom.Text = lgsProductMaster.ProductName;
                }
                
            } 
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void TxtSearchCodeFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    if (!string.IsNullOrEmpty(TxtSearchCodeFrom.Text.Trim())) { }

                }
                if (e.KeyCode.Equals(Keys.F3))
                {
                    InvProductMasterService invProductMasterService = new InvProductMasterService();

                    DataView dvAllReferenceData = new DataView(Common.DataTableColumnNameChange(invProductMasterService.GetProductsDataTable()));
                    if (dvAllReferenceData.Count != 0)
                    {
                        LoadReferenceSearchForm(dvAllReferenceData, this.Name.Trim(), this.Text.Trim(), this.ActiveControl.Text.Trim(), TxtSearchCodeFrom, 0, 0, 4);
                        TxtSearchCode_KeyLeave(this, e);
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);

            }
        }

        private void TxtSearchCodeTo_Enter(object sender, EventArgs e)
        {

        }

        private void TxtSearchCodeTo_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void TxtSearchCodeTo_Leave(object sender, EventArgs e)
        {
           
           
        }

        private void ChkAutoComplteFrom_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(LblSearchFrom);
            
        }

        private void ChkAutoComplteFrom_chkchanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAutoComplteFrom.Checked)
                {
                    LoadProductsFrom();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
       

    }

        private void ChkAutoComplteTo_chkchanged(object sender, EventArgs e)
        {
           
        }

        private void ChkAutoComplteTo_Leave(object sender, EventArgs e)
        {
           
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

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LblDepartment_Click(object sender, EventArgs e)
        {

        }

        private void SearchTab_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void SearchTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (SearchTab.SelectedTab.Name == "Productwise") {

            //    cmbDepartment.Enabled = false;

            //}

            //if (SearchTab.SelectedTab.Name == "DepatmentWise")
            //{

            //    TxtSearchCodeFrom.Enabled = false;

            //}

        }

  

        private void DepartmentCode_KeyLeave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(LblDepartment);
                if (string.IsNullOrEmpty(DepartmentCode.Text.Trim())) { return; }
               
                InvDepartmentService invdepartmentservice = new InvDepartmentService();
                InvDepartment invdepartment = new InvDepartment();

                invdepartment= invdepartmentservice.GetProductsByCode(DepartmentCode.Text.Trim());

                if (invdepartment != null)
                {
                    DepartmentCode.Text = invdepartment.DepartmentCode;
                    txtDpt_Name.Text = invdepartment.DepartmentName;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void DepartmentCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    if (!string.IsNullOrEmpty(DepartmentCode.Text.Trim())) { }

                }
                if (e.KeyCode.Equals(Keys.F3))
                {   
                    InvDepartmentService invdepartmentservice = new InvDepartmentService();
                    DataView dvAllReferenceData = new DataView(Common.DataTableColumnNameChange(invdepartmentservice.GetProductsDataTable()));
                    if (dvAllReferenceData.Count != 0)
                    {
                        LoadReferenceSearchForm(dvAllReferenceData, this.Name.Trim(), this.Text.Trim(), this.ActiveControl.Text.Trim(), DepartmentCode, 0, 0, 4);
                        DepartmentCode_KeyLeave(this, e);
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);

            }
        }
    }
}

