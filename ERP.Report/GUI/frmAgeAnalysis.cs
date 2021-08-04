using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.UI.Windows;
using ERP.Service;
using ERP.Utility;
using System.Reflection;
using ERP.Domain;
using ERP.Report;
using ERP.Report.Inventory.Transactions.Reports;

namespace ERP.Report.GUI
{

    public partial class frmAgeAnalysis : FrmBaseReportsForm
    {
        List<Common.CheckedListBoxSelection> departmentList = new List<Common.CheckedListBoxSelection>();
        string[] departmentNames;

        List<Common.CheckedListBoxSelection> categoryList = new List<Common.CheckedListBoxSelection>();
        string[] categoryNames;

        List<Common.CheckedListBoxSelection> subCategoryList = new List<Common.CheckedListBoxSelection>();
        string[] subCategoryNames;

        List<Common.CheckedListBoxSelection> subCategory2List = new List<Common.CheckedListBoxSelection>();
        string[] subCategory2Names;

        List<Common.CheckedListBoxSelection> suppliersList = new List<Common.CheckedListBoxSelection>();
        string[] supplierNames;

        DataTable dtAllProducts = new DataTable();
        //string[] productsNames;

        List<InvAgeAnalysisSlab> Slabs;

        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;
        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;

        public frmAgeAnalysis()
        {
            InitializeComponent();
        }


        private List<Common.CheckedListBoxSelection> CreateSelectionList(string[] inArray)
        {
            List<Common.CheckedListBoxSelection> selectionDataStruct = new List<Common.CheckedListBoxSelection>();

            foreach (var item in inArray)
            {
                selectionDataStruct.Add(new Common.CheckedListBoxSelection() { Value = item.ToString().Trim(), isChecked = CheckState.Unchecked });
            }
            return selectionDataStruct;
        }

        public override void InitializeForm()
        {
            try
            {
                InitializeSelectionLists();
                OrganiseFormControls();

                Slabs = new List<InvAgeAnalysisSlab>();
                InvAgeAnalysisSlabServices invAgeAnalysisSlabServices = new InvAgeAnalysisSlabServices();
                Slabs = invAgeAnalysisSlabServices.GetAllSlabs();
                LoadDgvProducts();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void InitializeSelectionLists()
        {
            // Departments
            InvDepartmentService invDepartmentService = new InvDepartmentService();
            departmentList = CreateSelectionList(invDepartmentService.GetAllDepartmentNames());
            departmentNames = invDepartmentService.GetAllDepartmentNames();

            // Categories
            InvCategoryService invCategoryService = new InvCategoryService();
            categoryList = CreateSelectionList(invCategoryService.GetAllCategoryNames());
            categoryNames = invCategoryService.GetAllCategoryNames();

            // Sub Categories
            InvSubCategoryService invSubCategoryService = new InvSubCategoryService();
            subCategoryList = CreateSelectionList(invSubCategoryService.GetAllSubCategoryNames());
            subCategoryNames = invSubCategoryService.GetAllSubCategoryNames();

            // Sub Categories2
            InvSubCategory2Service invSubCategory2Service = new InvSubCategory2Service();
            subCategory2List = CreateSelectionList(invSubCategory2Service.GetInvSubCategory2Names());
            subCategory2Names = invSubCategory2Service.GetInvSubCategory2Names();


            // Suppliers
            SupplierService supplierService = new SupplierService();
            suppliersList = CreateSelectionList(supplierService.GetSupplierNames());
            supplierNames = supplierService.GetSupplierNames();

            // Products
            //InvProductMasterService invProductMasterService = new InvProductMasterService();
            //dtAllProducts = invProductMasterService.GetAllProductIdAndNames();            
        }

        private void LoadDgvProducts()
        {
            try
            {
                dtAllProducts = new DataTable();
                InvProductMasterService invProductMasterService = new InvProductMasterService();
                dtAllProducts = invProductMasterService.GetAllProductsCodesAndNames();
                if (dtAllProducts.Rows.Count > 0)
                {
                    dgvProducts.DataSource = dtAllProducts;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void OrganiseFormControls()
        {
            // Apply Product Property Types
            grbDepartment.Text = "     " + (AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmDepartment").FormText);
            grbCategory.Text = "     " + (AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmCategory").FormText);
            grbSubCategory.Text = "     " + (AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmSubCategory").FormText);
            grbSubCategory2.Text = "     " + (AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmSubCategory2").FormText);
            grbSupplier.Text = "     " + (AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmSupplier").FormText);
            grbProduct.Text = "     " + (AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmProduct").FormText);

            rbnDepartment.Text = (AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmDepartment").FormText) + " wise";
            rbnCategory.Text = (AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmCategory").FormText) + " wise";
            rbnSubCategory.Text = (AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmSubCategory").FormText) + " wise";
            rbnSubCategory2.Text = (AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmSubCategory2").FormText) + " wise";
            rbnSupplier.Text = (AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmSupplier").FormText) + " wise";
            rbnProduct.Text = (AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmProduct").FormText) + " wise";

            LoadToLists();

            //// Department
            //Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstDepartment, departmentList, "", "");

            //// Category
            //Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstCategory, categoryList, "", "");

            //// Sub Category
            //Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstSubCategory, subCategoryList, "", "");

            //// Sub Category 2
            //Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstSubCategory2, subCategory2List, "", "");

            ////Supplier
            //Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstSupplier, suppliersList, "", "");

            //Products
            //Common.LoadProductsToGrid(dgvProducts,dtAllProducts);

            //lstProduct, dtAllProducts);

            //ActiveControl = ;
            //.Focus();
        }




        private void LoadAutoList(TextBox sourceTextBox, bool status, string[] autoCompleteList)
        {
            Common.SetAutoComplete(sourceTextBox, autoCompleteList, status);
        }

        public override void FormLoad()
        {
            base.FormLoad();
            LoadSlabs();

            LocationService locationService = new LocationService();
            Common.LoadLocations(cmbLocation, locationService.GetAllLocations());
            cmbLocation.SelectedValue = Common.LoggedLocationID;

            rbnDepartment.Checked = true;
            chkAllDepartments.Checked = true;
        }


        private void LoadSlabs()
        {
            for (int i = 0; i < Slabs.Count; i++)
            {
                if (i == 0)
                {
                    txtDays1From.Text = Slabs[i].FromSlab.ToString();
                    txtDays1To.Text = Slabs[i].ToSlab.ToString();
                }
                else if (i == 1)
                {
                    txtDays2From.Text = Slabs[i].FromSlab.ToString();
                    txtDays2To.Text = Slabs[i].ToSlab.ToString();
                }
                else if (i == 2)
                {
                    txtDays3From.Text = Slabs[i].FromSlab.ToString();
                    txtDays3To.Text = Slabs[i].ToSlab.ToString();
                }
                else if (i == 3)
                {
                    txtDays4From.Text = Slabs[i].FromSlab.ToString();
                    txtDays4To.Text = Slabs[i].ToSlab.ToString();
                }
                else if (i == 4)
                {
                    txtDaysOver.Text = Slabs[i].FromSlab.ToString();
                }
            }
        }

        private void LoadToLists()
        {
            Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstDepartment, departmentList, "", "");
            Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstCategory, categoryList, "", "");
            Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstSubCategory, subCategoryList, "", "");
            Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstSubCategory2, subCategory2List, "", "");
            Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstSupplier, suppliersList, "", "");
        }
        public override void ClearForm()
        {
            try
            {
                base.ClearForm();
                LoadSlabs();
                dgvProducts.DataSource = dtAllProducts;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void chkAllDepartments_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllDepartments.Checked) { CheckedAllDepartments(); } else { UnCheckedAllDepartments(); }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void UnCheckedAllDepartments()
        {

            for (int i = 0; i < chkLstDepartment.Items.Count; i++)
            {
                chkLstDepartment.SetItemChecked(i, false);
            }
        }

        private void UnCheckedAllCategories()
        {

            for (int i = 0; i < chkLstCategory.Items.Count; i++)
            {
                chkLstCategory.SetItemChecked(i, false);
            }
        }

        private void UnCheckedAllSubCategories()
        {
            for (int i = 0; i < chkLstSubCategory.Items.Count; i++)
            {
                chkLstSubCategory.SetItemChecked(i, false);
            }
        }

        private void UnCheckedAllSubCategories2()
        {
            for (int i = 0; i < chkLstSubCategory2.Items.Count; i++)
            {
                chkLstSubCategory2.SetItemChecked(i, false);
            }
        }

        private void UnCheckedAllSupplies()
        {
            for (int i = 0; i < chkLstSupplier.Items.Count; i++)
            {
                chkLstSupplier.SetItemChecked(i, false);
            }
        }

        private void UnCheckedAllProducts()
        {
            for (int k = 0; k <= dgvProducts.RowCount - 1; k++)
            {
                dgvProducts.Rows[k].Cells["chkBxSelect"].Value = false;
            }
            this.dgvProducts.EndEdit();
        }

        private void CheckedAllDepartments()
        {
            for (int i = 0; i < chkLstDepartment.Items.Count; i++)
            {
                chkLstDepartment.SetItemChecked(i, true);
            }
        }

        private void CheckedAllCategories()
        {
            for (int i = 0; i < chkLstCategory.Items.Count; i++)
            {
                chkLstCategory.SetItemChecked(i, true);
            }
        }

        private void CheckedAllSubCategories()
        {
            for (int i = 0; i < chkLstSubCategory.Items.Count; i++)
            {
                chkLstSubCategory.SetItemChecked(i, true);
            }
        }

        private void CheckedAllSubCategories2()
        {
            for (int i = 0; i < chkLstSubCategory2.Items.Count; i++)
            {
                chkLstSubCategory2.SetItemChecked(i, true);
            }
        }

        private void CheckedAllSuppliers()
        {
            for (int i = 0; i < chkLstSupplier.Items.Count; i++)
            {
                chkLstSupplier.SetItemChecked(i, true);
            }

        }

        private void CheckedAllProducts()
        {
            for (int k = 0; k <= dgvProducts.RowCount - 1; k++)
            {
                dgvProducts.Rows[k].Cells["chkBxSelect"].Value = true;
            }
            this.dgvProducts.EndEdit();


            //foreach (DataGridViewRow row in dgvProducts.Rows)
            //{
            //    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
            //    chk.Selected = true;
            //}
        }


        private void rbnDepartment_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbnDepartment.Checked)
                {
                    grbDepartment.Enabled = true;
                    grbCategory.Enabled = false;
                    UnCheckedAllCategories();
                    grbSubCategory.Enabled = false;
                    UnCheckedAllSubCategories();
                    grbSubCategory2.Enabled = false;
                    UnCheckedAllSubCategories2();
                    grbSupplier.Enabled = false;
                    UnCheckedAllSupplies();
                    grbProduct.Enabled = false;
                    UnCheckedAllProducts();

                    chkAllCategories.Checked = false;
                    chkAllSubCategories.Checked = false;
                    chkAllSubCategories2.Checked = false;
                    chkAllSuppliers.Checked = false;
                    //chkAllProducts.Checked = false;

                    txtCategory.Text = "";
                    txtSubCategory.Text = "";
                    txtSubCategory2.Text = "";
                    txtSupplier.Text = "";
                    txtProducts.Text = "";
                    dgvProducts.DataSource = dtAllProducts;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void rbnCategory_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbnCategory.Checked)
                {
                    grbDepartment.Enabled = false;
                    UnCheckedAllDepartments();
                    grbCategory.Enabled = true;
                    grbSubCategory.Enabled = false;
                    UnCheckedAllSubCategories();
                    grbSubCategory2.Enabled = false;
                    UnCheckedAllSubCategories2();
                    grbSupplier.Enabled = false;
                    UnCheckedAllSupplies();
                    grbProduct.Enabled = false;
                    UnCheckedAllProducts();

                    chkAllDepartments.Checked = false;
                    chkAllSubCategories.Checked = false;
                    chkAllSubCategories2.Checked = false;
                    chkAllSuppliers.Checked = false;
                    //chkAllProducts.Checked = false;
                    txtDepartment.Text = "";
                    txtSubCategory.Text = "";
                    txtSubCategory2.Text = "";
                    txtSupplier.Text = "";
                    txtProducts.Text = "";
                    dgvProducts.DataSource = dtAllProducts;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void rbnSubCategory_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbnSubCategory.Checked)
                {
                    grbDepartment.Enabled = false;
                    UnCheckedAllDepartments();
                    grbCategory.Enabled = false;
                    UnCheckedAllCategories();
                    grbSubCategory.Enabled = true;
                    grbSubCategory2.Enabled = false;
                    UnCheckedAllSubCategories2();
                    grbSupplier.Enabled = false;
                    UnCheckedAllSupplies();
                    grbProduct.Enabled = false;
                    UnCheckedAllProducts();

                    chkAllDepartments.Checked = false;
                    chkAllCategories.Checked = false;
                    chkAllSubCategories2.Checked = false;
                    chkAllSuppliers.Checked = false;
                    //chkAllProducts.Checked = false;

                    txtDepartment.Text = "";
                    txtCategory.Text = "";
                    txtSubCategory2.Text = "";
                    txtSupplier.Text = "";
                    txtProducts.Text = "";
                    dgvProducts.DataSource = dtAllProducts;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void rbnSubCategory2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbnSubCategory2.Checked)
                {
                    grbDepartment.Enabled = false;
                    UnCheckedAllDepartments();
                    grbCategory.Enabled = false;
                    UnCheckedAllCategories();
                    grbSubCategory.Enabled = false;
                    UnCheckedAllSubCategories();
                    grbSubCategory2.Enabled = true;
                    grbSupplier.Enabled = false;
                    UnCheckedAllSupplies();
                    grbProduct.Enabled = false;
                    UnCheckedAllProducts();

                    chkAllDepartments.Checked = false;
                    chkAllCategories.Checked = false;
                    chkAllSubCategories.Checked = false;
                    chkAllSuppliers.Checked = false;
                    //chkAllProducts.Checked = false;

                    txtDepartment.Text = "";
                    txtCategory.Text = "";
                    txtSubCategory.Text = "";
                    txtSupplier.Text = "";
                    txtProducts.Text = "";
                    dgvProducts.DataSource = dtAllProducts;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void rbnSupplier_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbnSupplier.Checked)
                {
                    grbDepartment.Enabled = false;
                    UnCheckedAllDepartments();
                    grbCategory.Enabled = false;
                    UnCheckedAllCategories();
                    grbSubCategory.Enabled = false;
                    UnCheckedAllSubCategories();
                    grbSubCategory2.Enabled = false;
                    UnCheckedAllSubCategories2();
                    grbSupplier.Enabled = true;
                    grbProduct.Enabled = false;
                    UnCheckedAllProducts();

                    chkAllDepartments.Checked = false;
                    chkAllCategories.Checked = false;
                    chkAllSubCategories.Checked = false;
                    chkAllSubCategories2.Checked = false;
                    //chkAllProducts.Checked = false;

                    txtDepartment.Text = "";
                    txtCategory.Text = "";
                    txtSubCategory.Text = "";
                    txtSubCategory2.Text = "";
                    txtProducts.Text = "";
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void rbnProduct_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dgvProducts.DataSource = dtAllProducts;
                if (rbnProduct.Checked)
                {
                    grbDepartment.Enabled = false;
                    UnCheckedAllDepartments();
                    grbCategory.Enabled = false;
                    UnCheckedAllCategories();
                    grbSubCategory.Enabled = false;
                    UnCheckedAllSubCategories();
                    grbSubCategory2.Enabled = false;
                    UnCheckedAllSubCategories2();
                    grbSupplier.Enabled = false;
                    UnCheckedAllSupplies();
                    grbProduct.Enabled = true;
                    dgvProducts.Enabled = true;
                    chkAllDepartments.Checked = false;
                    chkAllCategories.Checked = false;
                    chkAllSubCategories.Checked = false;
                    chkAllSubCategories2.Checked = false;
                    chkAllSuppliers.Checked = false;

                    txtDepartment.Text = "";
                    txtCategory.Text = "";
                    txtSubCategory.Text = "";
                    txtSubCategory2.Text = "";
                    txtSupplier.Text = "";
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void frmAgeAnalysis_Load(object sender, EventArgs e)
        {

        }

        private void chkAllCategories_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (chkAllCategories.Checked) { CheckedAllCategories(); } else { UnCheckedAllCategories(); }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void chkAllSubCategories_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllSubCategories.Checked) { CheckedAllSubCategories(); } else { UnCheckedAllSubCategories(); }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void chkAllSubCategories2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllSubCategories2.Checked) { CheckedAllSubCategories2(); } else { UnCheckedAllSubCategories2(); }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
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

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDays1To_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                txtDays2To.Focus();
            }
        }

        private void txtDays2To_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                txtDays3To.Focus();
            }
        }

        private void txtDays3To_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                txtDays4To.Focus();
            }
        }

        private void txtDays4To_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                rbnDepartment.Focus();
            }
        }

        private void chkAllSuppliers_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllSuppliers.Checked) { CheckedAllSuppliers(); } else { UnCheckedAllSupplies(); }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void chkAllProducts_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllProducts.Checked) { CheckedAllProducts(); } else { UnCheckedAllProducts(); }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void txtDays1To_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(txtDays1To.Text) > Convert.ToInt16(txtDays1From.Text))
                {
                    txtDays2From.Text = (int.Parse(txtDays1To.Text) + 1).ToString();
                    txtDays2To.Text = "0";
                    txtDays3From.Text = "0";
                    txtDays3To.Text = "0";
                    txtDays4From.Text = "0";
                    txtDays4To.Text = "0";
                    txtDaysOver.Text = "0";
                    txtDays2To.Focus();
                }
                else
                {
                    Toast.Show(this.Text, "", "To Date can not smaller than the From Date Slab.\nPlease enter a higher date to To Days Slab", Toast.messageType.Information, Toast.messageAction.General);
                    txtDays1To.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtDays2To_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(txtDays2To.Text) > Convert.ToInt16(txtDays2From.Text))
                {
                    txtDays3From.Text = (int.Parse(txtDays2To.Text) + 1).ToString();
                    txtDays3To.Text = "0";
                    txtDays4From.Text = "0";
                    txtDays4To.Text = "0";
                    txtDaysOver.Text = "0";
                    txtDays3To.Focus();
                }
                else
                {
                    Toast.Show(this.Text, "", "To Date can not smaller than the From Date Slab.\nPlease enter a higher date to To Days Slab", Toast.messageType.Information, Toast.messageAction.General);
                    txtDays4To.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtDays3To_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(txtDays3To.Text) > Convert.ToInt16(txtDays3From.Text))
                {
                    txtDays4From.Text = (int.Parse(txtDays3To.Text) + 1).ToString();
                    txtDays4To.Text = "0";
                    txtDaysOver.Text = "0";
                    txtDays4To.Focus();
                }
                else
                {
                    Toast.Show(this.Text, "", "To Date can not smaller than the From Date Slab.\nPlease enter a higher date to To Days Slab", Toast.messageType.Information, Toast.messageAction.General);
                    txtDays3To.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtDays4To_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(txtDays4To.Text) > Convert.ToInt16(txtDays4From.Text))
                {
                    txtDaysOver.Text = txtDays4To.Text;
                    rbnDepartment.Focus();
                }
                else
                {
                    Toast.Show(this.Text, "", "To Date can not smaller than the From Date Slab.\nPlease enter a higher date to To Days Slab", Toast.messageType.Information, Toast.messageAction.General);
                    txtDays4To.Focus();
                }
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
                int locationId = -1;

                if (chkAllLocations.Checked == false)
                {
                    if (ValidateComboBox().Equals(false)) { return; }
                }

                locationId = cmbLocation.SelectedIndex + 1;

                if (chkAllLocations.Checked == true) { locationId = 0; } else { locationId = cmbLocation.SelectedIndex + 1; }


                if (dtpFromDate.Value > dtpToDate.Value)
                {
                    Toast.Show(this.Text, "", "'To Date' can not smaller than the 'From Date'.\nPlease enter a higher date to 'To Date'", Toast.messageType.Information, Toast.messageAction.General);
                    dtpToDate.Focus();
                    return;
                }
                if (Convert.ToInt16(txtDays1To.Text) < Convert.ToInt16(txtDays1From.Text))
                {
                    Toast.Show(this.Text, "", "'To Date' can not smaller than the 'From Date Slab'.\nPlease enter a higher date to 'To Days Slab'", Toast.messageType.Information, Toast.messageAction.General);
                    txtDays1To.Focus();
                    return;
                }
                else if (Convert.ToInt16(txtDays2To.Text) < Convert.ToInt16(txtDays2From.Text))
                {
                    Toast.Show(this.Text, "", "'To Date' can not smaller than the 'From Date Slab'.\nPlease enter a higher date to 'To Days Slab'", Toast.messageType.Information, Toast.messageAction.General);
                    txtDays2To.Focus();
                    return;
                }
                else if (Convert.ToInt16(txtDays3To.Text) < Convert.ToInt16(txtDays3From.Text))
                {
                    Toast.Show(this.Text, "", "'To Date' can not smaller than the 'From Date Slab'.\nPlease enter a higher date to 'To Days Slab'", Toast.messageType.Information, Toast.messageAction.General);
                    txtDays3To.Focus();
                    return;
                }
                else if (Convert.ToInt16(txtDays4To.Text) < Convert.ToInt16(txtDays4From.Text))
                {
                    Toast.Show(this.Text, "", "'To Date' can not smaller than the 'From Date Slab'.\nPlease enter a higher date to 'To Days Slab'", Toast.messageType.Information, Toast.messageAction.General);
                    txtDays4To.Focus();
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;

                string report = string.Empty, reportType = string.Empty, displayType = string.Empty, productCodeFrom = string.Empty, productCodeTo = string.Empty;
                bool isAmt, isQty, isCval, isSval;
                DateTime dateFrom, dateTo;
                DataTable dtDepartments = new DataTable(), dtCategories = new DataTable(), dtSubCategories = new DataTable(),
                    dtSubCategories2 = new DataTable(), dtSupplier = new DataTable(), dtProductsSelected = new DataTable(); //, dtReportType = new DataTable();
                #region product properties


                dtDepartments = GetDepartments();
                dtCategories = GetCategories();
                dtSubCategories = GetSubCategories();
                dtSubCategories2 = GetSubCategories2();
                dtSupplier = GetSupplier();
                dtProductsSelected = GetProduct();


                #endregion


                //InvAgeAnalysisReportService invAgeAnalysisReportService = new InvAgeAnalysisReportService();
                //if (invAgeAnalysisReportService.ViewReport(locationId, dtProductsSelected, dtDepartments, dtCategories, dtSubCategories, dtSubCategories2, dtSupplier, dtpFromDate.Value, dtpToDate.Value))
                //{
                //    // if (dtDepartments.Rows.Count > 0)
                //    // {
                //    ViewReport();
                //    // }
                //}

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }

        }

        private DataTable GetDepartments()
        {
            DataTable dtDepartments = new DataTable();
            dtDepartments.Columns.Add("InvDepartmentID", typeof(long));
            if (rbnDepartment.Checked)
            {
                InvDepartmentService invDepartmentService = new InvDepartmentService();
                bool isDepend = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmDepartment").IsDepend;
 
                for (int i = 0; i < chkLstDepartment.Items.Count; i++)
                {
                    if (chkLstDepartment.GetItemChecked(i))
                    {
                        string str = (string)chkLstDepartment.Items[i];
                        dtDepartments.Rows.Add(invDepartmentService.GetInvDepartmentsByName(str, isDepend).InvDepartmentID);
                    }
                }
            }

            return dtDepartments;
        }

        private DataTable GetCategories()
        {
            DataTable dtCategories = new DataTable();
            dtCategories.Columns.Add("InvCategoryID", typeof(long));
            if (rbnCategory.Checked)
            {
                InvCategoryService invCategoryService = new InvCategoryService();
                bool isDepend = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmCategory").IsDepend;

                for (int i = 0; i < chkLstCategory.Items.Count; i++)
                {
                    if (chkLstCategory.GetItemChecked(i))
                    {
                        string str = (string)chkLstCategory.Items[i];
                        dtCategories.Rows.Add(invCategoryService.GetInvCategoryByName(str, isDepend).InvCategoryID);
                    }
                }

            }
            return dtCategories;
        }

        private DataTable GetSubCategories()
        {
            DataTable dtSubCategories = new DataTable();
            dtSubCategories.Columns.Add("InvSubCategoryID", typeof(long));
            if (rbnSubCategory.Checked)
            {
                InvSubCategoryService invSubCategoryService = new InvSubCategoryService();
                bool isDepend = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmSubCategory").IsDepend;
               
                for (int i = 0; i < chkLstSubCategory.Items.Count; i++)
                {
                    if (chkLstSubCategory.GetItemChecked(i))
                    {
                        string str = (string)chkLstSubCategory.Items[i];
                        dtSubCategories.Rows.Add(invSubCategoryService.GetInvSubCategoryByName(str, isDepend).InvSubCategoryID);
                    }
                }

            }
            return dtSubCategories;
        }

        private DataTable GetSubCategories2()
        {
            DataTable dtSubCategories2 = new DataTable();
            dtSubCategories2.Columns.Add("InvSubCategory2ID", typeof(long));
            if (rbnSubCategory2.Checked)
            {
                InvSubCategory2Service invSubCategory2Service = new InvSubCategory2Service();

                for (int i = 0; i < chkLstSubCategory2.Items.Count; i++)
                {
                    if (chkLstSubCategory2.GetItemChecked(i))
                    {
                        string str = (string)chkLstSubCategory2.Items[i];
                        dtSubCategories2.Rows.Add(invSubCategory2Service.GetInvSubCategory2ByName(str).InvSubCategoryID);
                    }
                }

            }
            return dtSubCategories2;
        }

        private DataTable GetSupplier()
        {
            DataTable dtSupplier = new DataTable();
            dtSupplier.Columns.Add("SupplierID", typeof(long));
            if (rbnSupplier.Checked)
            {
                SupplierService supplierService = new SupplierService();
              
                for (int i = 0; i < chkLstSupplier.Items.Count; i++)
                {
                    if (chkLstSupplier.GetItemChecked(i))
                    {
                        string str = (string)chkLstSupplier.Items[i];
                        dtSupplier.Rows.Add(supplierService.GetSupplierByName(str).SupplierID);
                    }
                }

            }
            return dtSupplier;
        }

        private DataTable GetProduct()
        {
            DataTable dtProduct = new DataTable();
            dtProduct.Columns.Add("ProductID", typeof(long));
            if (rbnProduct.Checked)
            {
                InvProductMasterService invProductMasterService = new InvProductMasterService();

                //DataRow datarow = null;
                //foreach (DataGridViewRow Row in dgvProducts.Rows)
                //{
                //    if (Convert.ToBoolean(Row.Cells[chkBxSelect.Name].Value) == true)
                //    {
                //        datarow = ((DataRowView)Row.DataBoundItem).Row;
                //        dtProduct.ImportRow(datarow);
                //    }
                //}


                for (int i = 0; i < dgvProducts.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvProducts.Rows[i].Cells[chkBxSelect.Name].Value) == true)
                    {
                        string str = dgvProducts.Rows[i].Cells[1].Value.ToString();
                        dtProduct.Rows.Add(invProductMasterService.GetProductsByCode(str).InvProductMasterID);
                    }
                }

            }
            return dtProduct;
        }

        private void ViewReport()
        {
            //FrmReportViewer reportViewer = new FrmReportViewer();
            //DataTable dtReportData = new DataTable();
            //InvAgeAnalysisReportService invAgeAnalysisReportService = new InvAgeAnalysisReportService();

            //if (rbnDepartment.Checked == true)
            //{
            //    InvRptAgeAnalysisDept invRptAgeAnalysisDept = new InvRptAgeAnalysisDept();

            //    DataTable dt = invAgeAnalysisReportService.GetAgeAnalysisData();
            //    invRptAgeAnalysisDept.SetDataSource(invAgeAnalysisReportService.GetAgeAnalysisData());

            //    invRptAgeAnalysisDept.SummaryInfo.ReportTitle = "Department Wise Age Analysis Report";
            //    invRptAgeAnalysisDept.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            //    invRptAgeAnalysisDept.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            //    invRptAgeAnalysisDept.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            //    invRptAgeAnalysisDept.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            //    invRptAgeAnalysisDept.DataDefinition.FormulaFields["Slab1"].Text = "'" + txtDays1From.Text.Trim() + " - " + txtDays1To.Text.Trim() + "'";
            //    invRptAgeAnalysisDept.DataDefinition.FormulaFields["Slab2"].Text = "'" + txtDays2From.Text.Trim() + " - " + txtDays2To.Text.Trim() + "'";
            //    invRptAgeAnalysisDept.DataDefinition.FormulaFields["Slab3"].Text = "'" + txtDays3From.Text.Trim() + " - " + txtDays3To.Text.Trim() + "'";
            //    invRptAgeAnalysisDept.DataDefinition.FormulaFields["Slab4"].Text = "'" + txtDays4From.Text.Trim() + " - " + txtDays4To.Text.Trim() + "'";
            //    invRptAgeAnalysisDept.DataDefinition.FormulaFields["Slab5"].Text = "' Over " + txtDaysOver.Text.Trim() + "'";
            //    invRptAgeAnalysisDept.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            //    invRptAgeAnalysisDept.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            //    invRptAgeAnalysisDept.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            //    invRptAgeAnalysisDept.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            //    reportViewer.crRptViewer.ReportSource = invRptAgeAnalysisDept;
            //    reportViewer.WindowState = FormWindowState.Maximized;
            //    reportViewer.Show();
            //    Cursor.Current = Cursors.Default;

            //    reportViewer.WindowState = FormWindowState.Maximized;
            //    reportViewer.Show();
            //}


            //if (rbnCategory.Checked == true)
            //{
            //    InvRptAgeAnalysisCat invRptAgeAnalysisCat = new InvRptAgeAnalysisCat();

            //    DataTable dt = invAgeAnalysisReportService.GetAgeAnalysisData();
            //    invRptAgeAnalysisCat.SetDataSource(invAgeAnalysisReportService.GetAgeAnalysisData());

            //    invRptAgeAnalysisCat.SummaryInfo.ReportTitle = "Category Wise Age Analysis Report";
            //    invRptAgeAnalysisCat.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            //    invRptAgeAnalysisCat.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            //    invRptAgeAnalysisCat.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            //    invRptAgeAnalysisCat.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            //    invRptAgeAnalysisCat.DataDefinition.FormulaFields["Slab1"].Text = "'" + txtDays1From.Text.Trim() + " - " + txtDays1To.Text.Trim() + "'";
            //    invRptAgeAnalysisCat.DataDefinition.FormulaFields["Slab2"].Text = "'" + txtDays2From.Text.Trim() + " - " + txtDays2To.Text.Trim() + "'";
            //    invRptAgeAnalysisCat.DataDefinition.FormulaFields["Slab3"].Text = "'" + txtDays3From.Text.Trim() + " - " + txtDays3To.Text.Trim() + "'";
            //    invRptAgeAnalysisCat.DataDefinition.FormulaFields["Slab4"].Text = "'" + txtDays4From.Text.Trim() + " - " + txtDays4To.Text.Trim() + "'";
            //    invRptAgeAnalysisCat.DataDefinition.FormulaFields["Slab5"].Text = "' Over " + txtDaysOver.Text.Trim() + "'";
            //    invRptAgeAnalysisCat.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            //    invRptAgeAnalysisCat.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            //    invRptAgeAnalysisCat.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            //    invRptAgeAnalysisCat.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            //    reportViewer.crRptViewer.ReportSource = invRptAgeAnalysisCat;
            //    reportViewer.WindowState = FormWindowState.Maximized;
            //    reportViewer.Show();
            //    Cursor.Current = Cursors.Default;

            //    reportViewer.WindowState = FormWindowState.Maximized;
            //    reportViewer.Show();
            //}


            //if (rbnSubCategory.Checked == true)
            //{
            //    InvRptAgeAnalysisSubCat invRptAgeAnalysisSubCat = new InvRptAgeAnalysisSubCat();

            //    DataTable dt = invAgeAnalysisReportService.GetAgeAnalysisData();
            //    invRptAgeAnalysisSubCat.SetDataSource(invAgeAnalysisReportService.GetAgeAnalysisData());

            //    invRptAgeAnalysisSubCat.SummaryInfo.ReportTitle = "Sub Category Wise Age Analysis Report";
            //    invRptAgeAnalysisSubCat.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            //    invRptAgeAnalysisSubCat.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            //    invRptAgeAnalysisSubCat.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            //    invRptAgeAnalysisSubCat.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            //    invRptAgeAnalysisSubCat.DataDefinition.FormulaFields["Slab1"].Text = "'" + txtDays1From.Text.Trim() + " - " + txtDays1To.Text.Trim() + "'";
            //    invRptAgeAnalysisSubCat.DataDefinition.FormulaFields["Slab2"].Text = "'" + txtDays2From.Text.Trim() + " - " + txtDays2To.Text.Trim() + "'";
            //    invRptAgeAnalysisSubCat.DataDefinition.FormulaFields["Slab3"].Text = "'" + txtDays3From.Text.Trim() + " - " + txtDays3To.Text.Trim() + "'";
            //    invRptAgeAnalysisSubCat.DataDefinition.FormulaFields["Slab4"].Text = "'" + txtDays4From.Text.Trim() + " - " + txtDays4To.Text.Trim() + "'";
            //    invRptAgeAnalysisSubCat.DataDefinition.FormulaFields["Slab5"].Text = "' Over " + txtDaysOver.Text.Trim() + "'";
            //    invRptAgeAnalysisSubCat.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            //    invRptAgeAnalysisSubCat.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            //    invRptAgeAnalysisSubCat.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            //    invRptAgeAnalysisSubCat.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            //    reportViewer.crRptViewer.ReportSource = invRptAgeAnalysisSubCat;
            //    reportViewer.WindowState = FormWindowState.Maximized;
            //    reportViewer.Show();
            //    Cursor.Current = Cursors.Default;

            //    reportViewer.WindowState = FormWindowState.Maximized;
            //    reportViewer.Show();
            //}


            //if (rbnSubCategory2.Checked == true)
            //{
            //    InvRptAgeAnalysisSubCat2 invRptAgeAnalysisSubCat2 = new InvRptAgeAnalysisSubCat2();

            //    DataTable dt = invAgeAnalysisReportService.GetAgeAnalysisData();
            //    invRptAgeAnalysisSubCat2.SetDataSource(invAgeAnalysisReportService.GetAgeAnalysisData());

            //    invRptAgeAnalysisSubCat2.SummaryInfo.ReportTitle = "Sub Category 2 Wise Age Analysis Report";
            //    invRptAgeAnalysisSubCat2.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            //    invRptAgeAnalysisSubCat2.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            //    invRptAgeAnalysisSubCat2.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            //    invRptAgeAnalysisSubCat2.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            //    invRptAgeAnalysisSubCat2.DataDefinition.FormulaFields["Slab1"].Text = "'" + txtDays1From.Text.Trim() + " - " + txtDays1To.Text.Trim() + "'";
            //    invRptAgeAnalysisSubCat2.DataDefinition.FormulaFields["Slab2"].Text = "'" + txtDays2From.Text.Trim() + " - " + txtDays2To.Text.Trim() + "'";
            //    invRptAgeAnalysisSubCat2.DataDefinition.FormulaFields["Slab3"].Text = "'" + txtDays3From.Text.Trim() + " - " + txtDays3To.Text.Trim() + "'";
            //    invRptAgeAnalysisSubCat2.DataDefinition.FormulaFields["Slab4"].Text = "'" + txtDays4From.Text.Trim() + " - " + txtDays4To.Text.Trim() + "'";
            //    invRptAgeAnalysisSubCat2.DataDefinition.FormulaFields["Slab5"].Text = "' Over " + txtDaysOver.Text.Trim() + "'";
            //    invRptAgeAnalysisSubCat2.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            //    invRptAgeAnalysisSubCat2.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            //    invRptAgeAnalysisSubCat2.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            //    invRptAgeAnalysisSubCat2.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            //    reportViewer.crRptViewer.ReportSource = invRptAgeAnalysisSubCat2;
            //    reportViewer.WindowState = FormWindowState.Maximized;
            //    reportViewer.Show();
            //    Cursor.Current = Cursors.Default;

            //    reportViewer.WindowState = FormWindowState.Maximized;
            //    reportViewer.Show();
            //}


            //if (rbnSupplier.Checked == true)
            //{
            //    InvRptAgeAnalysisSupplier invRptAgeAnalysisSupplier = new InvRptAgeAnalysisSupplier();

            //    DataTable dt = invAgeAnalysisReportService.GetAgeAnalysisData();
            //    invRptAgeAnalysisSupplier.SetDataSource(invAgeAnalysisReportService.GetAgeAnalysisData());

            //    invRptAgeAnalysisSupplier.SummaryInfo.ReportTitle = "Supplier Wise Age Analysis Report";
            //    invRptAgeAnalysisSupplier.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            //    invRptAgeAnalysisSupplier.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            //    invRptAgeAnalysisSupplier.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            //    invRptAgeAnalysisSupplier.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            //    invRptAgeAnalysisSupplier.DataDefinition.FormulaFields["Slab1"].Text = "'" + txtDays1From.Text.Trim() + " - " + txtDays1To.Text.Trim() + "'";
            //    invRptAgeAnalysisSupplier.DataDefinition.FormulaFields["Slab2"].Text = "'" + txtDays2From.Text.Trim() + " - " + txtDays2To.Text.Trim() + "'";
            //    invRptAgeAnalysisSupplier.DataDefinition.FormulaFields["Slab3"].Text = "'" + txtDays3From.Text.Trim() + " - " + txtDays3To.Text.Trim() + "'";
            //    invRptAgeAnalysisSupplier.DataDefinition.FormulaFields["Slab4"].Text = "'" + txtDays4From.Text.Trim() + " - " + txtDays4To.Text.Trim() + "'";
            //    invRptAgeAnalysisSupplier.DataDefinition.FormulaFields["Slab5"].Text = "' Over " + txtDaysOver.Text.Trim() + "'";
            //    invRptAgeAnalysisSupplier.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            //    invRptAgeAnalysisSupplier.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            //    invRptAgeAnalysisSupplier.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            //    invRptAgeAnalysisSupplier.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            //    reportViewer.crRptViewer.ReportSource = invRptAgeAnalysisSupplier;
            //    reportViewer.WindowState = FormWindowState.Maximized;
            //    reportViewer.Show();
            //    Cursor.Current = Cursors.Default;

            //    reportViewer.WindowState = FormWindowState.Maximized;
            //    reportViewer.Show();
            //}

            //if (rbnProduct.Checked == true)
            //{
            //    InvRptAgeAnalysisProduct invRptAgeAnalysisProduct = new InvRptAgeAnalysisProduct();

            //    DataTable dt = invAgeAnalysisReportService.GetAgeAnalysisData();
            //    invRptAgeAnalysisProduct.SetDataSource(invAgeAnalysisReportService.GetAgeAnalysisData());

            //    invRptAgeAnalysisProduct.SummaryInfo.ReportTitle = "Product Wise Age Analysis Report";
            //    invRptAgeAnalysisProduct.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
            //    invRptAgeAnalysisProduct.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + cmbLocation.Text.Trim() + "'";
            //    invRptAgeAnalysisProduct.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Text + "'";
            //    invRptAgeAnalysisProduct.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Text + "'";
            //    invRptAgeAnalysisProduct.DataDefinition.FormulaFields["Slab1"].Text = "'" + txtDays1From.Text.Trim() + " - " + txtDays1To.Text.Trim() + "'";
            //    invRptAgeAnalysisProduct.DataDefinition.FormulaFields["Slab2"].Text = "'" + txtDays2From.Text.Trim() + " - " + txtDays2To.Text.Trim() + "'";
            //    invRptAgeAnalysisProduct.DataDefinition.FormulaFields["Slab3"].Text = "'" + txtDays3From.Text.Trim() + " - " + txtDays3To.Text.Trim() + "'";
            //    invRptAgeAnalysisProduct.DataDefinition.FormulaFields["Slab4"].Text = "'" + txtDays4From.Text.Trim() + " - " + txtDays4To.Text.Trim() + "'";
            //    invRptAgeAnalysisProduct.DataDefinition.FormulaFields["Slab5"].Text = "' Over " + txtDaysOver.Text.Trim() + "'";
            //    invRptAgeAnalysisProduct.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
            //    invRptAgeAnalysisProduct.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
            //    invRptAgeAnalysisProduct.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
            //    invRptAgeAnalysisProduct.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
            //    reportViewer.crRptViewer.ReportSource = invRptAgeAnalysisProduct;
            //    reportViewer.WindowState = FormWindowState.Maximized;
            //    reportViewer.Show();
            //    Cursor.Current = Cursors.Default;

            //    reportViewer.WindowState = FormWindowState.Maximized;
            //    reportViewer.Show();
            //}

            // Delete Temp Data
            ReportService reportService = new ReportService();
            if (!reportService.DeleteTempData())
            {
                Toast.Show(this.Text, "Error on deleting temp data", "", Toast.messageType.Information, Toast.messageAction.General);
                return;
            }
        }





        //private DataTable GetCategories()
        //{
        //    DataTable dtCategories = new DataTable();
        //    dtCategories.Columns.Add("InvCategoryID", typeof(long));

        //    if (chkCategory.Checked)
        //    {
        //        if (rbtnCategorySelection.Checked)
        //        {
        //            InvCategoryService invCategoryService = new InvCategoryService();
        //            bool isDepend = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmCategory").IsDepend;

        //            if (categoryList.Any(l => l.isChecked.Equals(CheckState.Checked)))
        //            {
        //                foreach (var item in categoryList.Where(l => l.isChecked.Equals(CheckState.Checked)))
        //                {
        //                    dtCategories.Rows.Add(invCategoryService.GetInvCategoryByName(item.Value.Trim(), isDepend).InvCategoryID);
        //                }
        //            }
        //        }

        //        if (rbtnCategoryRange.Checked)
        //        {
        //            InvCategoryService invCategoryService = new InvCategoryService();
        //            long[] categoryIds = invCategoryService.GetInvCategoryIdRangeByCategoryNames(txtCategoryFrom.Text.Trim(), txtCategoryTo.Text.Trim());

        //            foreach (var item in categoryIds)
        //            {
        //                dtCategories.Rows.Add(item);
        //            }
        //        }
        //    }
        //    return dtCategories;
        //}

        //private DataTable GetSubCategories()
        //{
        //    DataTable dtSubCategories = new DataTable();
        //    dtSubCategories.Columns.Add("InvSubCategoryID", typeof(long));
        //    if (chkSubCategory.Checked)
        //    {
        //        if (rbtnSubCategorySelection.Checked)
        //        {
        //            InvSubCategoryService invSubCategoryService = new InvSubCategoryService();
        //            bool isDepend = AutoGenerateInfoService.GetAutoGenerateInfoByForm("FrmSubCategory").IsDepend;

        //            if (subCategoryList.Any(l => l.isChecked.Equals(CheckState.Checked)))
        //            {
        //                foreach (var item in subCategoryList.Where(l => l.isChecked.Equals(CheckState.Checked)))
        //                {
        //                    dtSubCategories.Rows.Add(invSubCategoryService.GetInvSubCategoryByName(item.Value.Trim(), isDepend).InvSubCategoryID);
        //                }
        //            }
        //        }

        //        if (rbtnSubCategoryRange.Checked)
        //        {
        //            InvSubCategoryService invSubCategoryService = new InvSubCategoryService();
        //            long[] subCategoryIds = invSubCategoryService.GetInvSubCategoryIdRangeBySubCategoryNames(txtSubCategoryFrom.Text.Trim(), txtSubCategoryTo.Text.Trim());

        //            foreach (var item in subCategoryIds)
        //            {
        //                dtSubCategories.Rows.Add(item);
        //            }
        //        }
        //    }
        //    return dtSubCategories;
        //}

        //private DataTable GetSubCategories2()
        //{
        //    DataTable dtSubCategories2 = new DataTable();
        //    dtSubCategories2.Columns.Add("InvSubCategory2ID", typeof(long));

        //    if (chkSubCategory2.Checked)
        //    {
        //        if (rbtnSubCategory2Selection.Checked)
        //        {
        //            InvSubCategory2Service invSubCategory2Service = new InvSubCategory2Service();

        //            if (subCategory2List.Any(l => l.isChecked.Equals(CheckState.Checked)))
        //            {
        //                foreach (var item in subCategory2List.Where(l => l.isChecked.Equals(CheckState.Checked)))
        //                {
        //                    dtSubCategories2.Rows.Add(invSubCategory2Service.GetInvSubCategory2ByName(item.Value.Trim()).InvSubCategory2ID);
        //                }
        //            }
        //        }

        //        if (rbtnSubCategory2Range.Checked)
        //        {
        //            InvSubCategory2Service invSubCategory2Service = new InvSubCategory2Service();
        //            long[] subCategory2Ids = invSubCategory2Service.GetInvSubCategory2IdRangeBySubCategory2Names(txtSubCategory2From.Text.Trim(), txtSubCategory2To.Text.Trim());

        //            foreach (var item in subCategory2Ids)
        //            {
        //                dtSubCategories2.Rows.Add(item);
        //            }
        //        }
        //    }
        //    return dtSubCategories2;
        //}

        private bool ValidateComboBox()
        {
            return Validater.ValidateComboBox(this.Text, errorProvider, Validater.ValidateType.Empty, cmbLocation);
        }

      

        private void chkLstDepartment_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                var item = (CheckedListBox)sender;
                SetItemCheckedStatus(departmentList, item.SelectedItem.ToString().Trim(), e.CurrentValue.Equals(CheckState.Checked) ? CheckState.Unchecked : CheckState.Checked);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }
        private void SetItemCheckedStatus(List<Common.CheckedListBoxSelection> allValuesList, string checkedListBoxItem, CheckState checkState)
        {
            foreach (var item in allValuesList.Where(v => v.Value == checkedListBoxItem.Trim()))
            {
                item.isChecked = checkState;
            }
        }

        private void chkLstCategory_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                var item = (CheckedListBox)sender;
                SetItemCheckedStatus(categoryList, item.SelectedItem.ToString().Trim(), e.CurrentValue.Equals(CheckState.Checked) ? CheckState.Unchecked : CheckState.Checked);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void chkLstSubCategory_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                var item = (CheckedListBox)sender;
                SetItemCheckedStatus(subCategoryList, item.SelectedItem.ToString().Trim(), e.CurrentValue.Equals(CheckState.Checked) ? CheckState.Unchecked : CheckState.Checked);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void chkLstSubCategory2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                var item = (CheckedListBox)sender;
                SetItemCheckedStatus(subCategory2List, item.SelectedItem.ToString().Trim(), e.CurrentValue.Equals(CheckState.Checked) ? CheckState.Unchecked : CheckState.Checked);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }

        }

        private void chkLstSupplier_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                var item = (CheckedListBox)sender;
                SetItemCheckedStatus(suppliersList, item.SelectedItem.ToString().Trim(), e.CurrentValue.Equals(CheckState.Checked) ? CheckState.Unchecked : CheckState.Checked);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }

        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.chkLstDepartment.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstDepartment_ItemCheck);
                if (string.IsNullOrEmpty(txtDepartment.Text.Trim()))
                {
                    Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstDepartment, departmentList, "", "");
                }
                else
                {
                    Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstDepartment, SearchList(departmentList, txtDepartment.Text.Trim()), "", "");
                }
                RefreshCheckedList(chkLstDepartment, departmentList);
                this.chkLstDepartment.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstDepartment_ItemCheck);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex.Message.ToString(), MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void RefreshCheckedList(CheckedListBox checkedListBox, List<Common.CheckedListBoxSelection> allValuesList)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (allValuesList.Any(a => a.Value.Equals(checkedListBox.Items[i].ToString().Trim()) && a.isChecked.Equals(CheckState.Checked)))
                {
                    checkedListBox.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBox.SetItemChecked(i, false);
                }
            }
        }

        private List<Common.CheckedListBoxSelection> SearchList(List<Common.CheckedListBoxSelection> inList, string searchString)
        {
            return inList.Where(c => c.Value.ToLower().StartsWith(searchString.ToLower().Trim())).ToList();
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.chkLstCategory.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstCategory_ItemCheck);
                if (string.IsNullOrEmpty(txtCategory.Text.Trim()))
                {
                    Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstCategory, categoryList, "", "");
                }
                else
                {
                    Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstCategory, SearchList(categoryList, txtCategory.Text.Trim()), "", "");
                }
                RefreshCheckedList(chkLstCategory, categoryList);
                this.chkLstCategory.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstCategory_ItemCheck);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex.Message.ToString(), MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void txtSubCategory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.chkLstSubCategory.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstSubCategory_ItemCheck);
                if (string.IsNullOrEmpty(txtSubCategory.Text.Trim()))
                {
                    Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstSubCategory, subCategoryList, "", "");
                }
                else
                {
                    Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstSubCategory, SearchList(subCategoryList, txtSubCategory.Text.Trim()), "", "");
                }
                RefreshCheckedList(chkLstSubCategory, subCategoryList);
                this.chkLstSubCategory.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstSubCategory_ItemCheck);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex.Message.ToString(), MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void txtSubCategory2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.chkLstSubCategory2.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstSubCategory2_ItemCheck);
                if (string.IsNullOrEmpty(txtSubCategory.Text.Trim()))
                {
                    Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstSubCategory2, subCategory2List, "", "");
                }
                else
                {
                    Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstSubCategory2, SearchList(subCategory2List, txtSubCategory2.Text.Trim()), "", "");
                }
                RefreshCheckedList(chkLstSubCategory2, subCategory2List);
                this.chkLstSubCategory2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstSubCategory2_ItemCheck);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex.Message.ToString(), MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.chkLstSupplier.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.chkLstSupplier_ItemCheck);
                if (string.IsNullOrEmpty(txtSupplier.Text.Trim()))
                {
                    Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstSupplier, suppliersList, "", "");
                }
                else
                {
                    Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstSupplier, SearchList(suppliersList, txtSupplier.Text.Trim()), "", "");
                }
                RefreshCheckedList(chkLstSupplier, suppliersList);
                this.chkLstSupplier.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstSupplier_ItemCheck);
            }
            catch (Exception ex)
            { Logger.WriteLog(ex.Message.ToString(), MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void txtProducts_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProducts.Text.Trim()))
                {
                    dgvProducts.DataSource = dtAllProducts;
                }
                else
                {
                    DataTable dsTmp = dtAllProducts;
                    DataView dv = dsTmp.DefaultView;
                    dv.RowFilter = string.Format("ProductCode LIKE '%{0}%'", txtProducts.Text.Trim());
                    dgvProducts.DataSource = dv;
                }
            }
            catch (Exception ex)
            { Logger.WriteLog(ex.Message.ToString(), MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }
    }
}
