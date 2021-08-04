using ERP.Domain;
using ERP.Report.CRM.Reports;
using ERP.Service;
using ERP.UI.Windows;
using ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Report.Inventory;
using ERP.Report.Inventory.Transactions.Reports;

namespace ERP.Report.GUI
{
    public partial class FrmSupplierWiseStockMovement : FrmBaseReportsForm
    {
        public FrmSupplierWiseStockMovement(AutoGenerateInfo autoGenerateInfo)
        {
            InitializeComponent();
            this.Text = autoGenerateInfo.FormText;
        }

        public override void InitializeForm()
        {
            base.InitializeForm();
        }

        public override void FormLoad()
        {
            dtpFromDate.Value = Common.GetSystemDate();
            dtpToDate.Value = Common.GetSystemDate();

            SupplierService supplierService = new SupplierService();
            Common.SetAutoComplete(txtSupplierCode, supplierService.GetSupplierCodes(), chkAutoCompleationSupplier.Checked);
            Common.SetAutoComplete(txtSupplierName, supplierService.GetSupplierNames(), chkAutoCompleationSupplier.Checked);

            base.FormLoad();
        }

        public override void ClearForm()
        {
            try
            {
                this.Cursor = Cursors.Default;

                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();

                base.ClearForm();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtSupplierCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    txtSupplierName.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierCode.Text.Trim() != string.Empty)
                {
                    SupplierService supplierService = new SupplierService();
                    Supplier supplier = new Supplier();

                    supplier = supplierService.GetSupplierByCode(txtSupplierCode.Text.Trim());

                    if (supplier != null)
                    {
                        txtSupplierCode.Text = supplier.SupplierCode;
                        txtSupplierName.Text = supplier.SupplierName;
                    }
                    else
                    {
                        Toast.Show(this.Text, "", "Supplier " + txtSupplierCode.Text.Trim(), Toast.messageType.Information, Toast.messageAction.NotExists);
                        txtSupplierCode.Focus();
                        txtSupplierCode.SelectAll();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    txtSupplierName_Leave(this, e);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtSupplierName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierName.Text.Trim() != string.Empty)
                {
                    SupplierService supplierService = new SupplierService();
                    Supplier supplier = new Supplier();

                    supplier = supplierService.GetSupplierByName(txtSupplierName.Text.Trim());

                    if (supplier != null)
                    {
                        txtSupplierCode.Text = supplier.SupplierCode;
                        txtSupplierName.Text = supplier.SupplierName;
                    }
                    else
                    {
                        Toast.Show(this.Text, "", "Supplier " + txtSupplierName.Text.Trim(), Toast.messageType.Information, Toast.messageAction.NotExists);
                        txtSupplierName.Focus();
                        txtSupplierName.SelectAll();
                        return;
                    }
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
                DateTime dateFrom;
                DateTime dateTo;

                dateFrom = dtpFromDate.Value;
                dateTo = dtpToDate.Value;


                SupplierService supplierService = new SupplierService();
                Supplier supplier = new Supplier();


                if (chkAllSup.Checked)
                {

                    InvReportGenerator invReportGenerator = new InvReportGenerator();
                    if (invReportGenerator.GetSupplierWiseStockMovement(0, dateFrom, dateTo))
                    {
                        ViewReport(supplier.SupplierID, dateFrom, dateTo);
                    }
                    else
                    {
                        Toast.Show(this.Text, "", "Error found in data processing", Toast.messageType.Error, Toast.messageAction.General);
                        return;
                    }

                }
                else
                {
                    if (txtSupplierCode.Text.Trim() == string.Empty)
                    {
                        Toast.Show(this.Text, "", "Invalid Supplier ", Toast.messageType.Information, Toast.messageAction.General);
                        return;
                    }


                    supplier = supplierService.GetSupplierByCode(txtSupplierCode.Text.Trim());

                    if (supplier != null)
                    {
                        InvReportGenerator invReportGenerator = new InvReportGenerator();
                        if (invReportGenerator.GetSupplierWiseStockMovement(supplier.SupplierID, dateFrom, dateTo))
                        {
                            ViewReport(supplier.SupplierID, dateFrom, dateTo);
                        }
                        else
                        {
                            Toast.Show(this.Text, "", "Error found in data processing", Toast.messageType.Error, Toast.messageAction.General);
                            return;
                        }
                    }
                    else
                    {
                        Toast.Show(this.Text, "", "Supplier " + txtSupplierCode.Text.Trim(), Toast.messageType.Information, Toast.messageAction.NotExists);
                        txtSupplierCode.Focus();
                        txtSupplierCode.SelectAll();
                        return;
                    }
                }
            }



            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void ViewReport(long supplierID, DateTime fromDate, DateTime toDate)
        {
            FrmReportViewer objReportView = new FrmReportViewer();
            InvReportGenerator invReportGenerator = new InvReportGenerator();
            //InvRptSupplierWiseMovement invRptSupplierWiseStockMovement = new InvRptSupplierWiseMovement();

            DataTable dtx = invReportGenerator.GetReportSupplierWiseStockMovement();

            if (rbnSupplierWise.Checked)
            {
                InvRptSupplierWiseMovement1 invRptSupplierWiseStockMovement = new InvRptSupplierWiseMovement1();
                invRptSupplierWiseStockMovement.SetDataSource(dtx);
                invRptSupplierWiseStockMovement.SummaryInfo.ReportTitle = "Supplier Wise Movement Reports";
                invRptSupplierWiseStockMovement.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                invRptSupplierWiseStockMovement.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptSupplierWiseStockMovement.DataDefinition.FormulaFields["Supplier"].Text = "'" + txtSupplierCode.Text.Trim() + "   " + txtSupplierName.Text.Trim() + "'";
                invRptSupplierWiseStockMovement.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                invRptSupplierWiseStockMovement.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptSupplierWiseStockMovement.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                invRptSupplierWiseStockMovement.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                invRptSupplierWiseStockMovement.DataDefinition.FormulaFields["DateFrom"].Text = "'" + fromDate + "'";
                invRptSupplierWiseStockMovement.DataDefinition.FormulaFields["DateTo"].Text = "'" + toDate + "'";
                objReportView.crRptViewer.ReportSource = invRptSupplierWiseStockMovement;
            }
            else
            {
                InvRptSupplierWiseMovement2 invRptSupplierWiseStockMovement2 = new InvRptSupplierWiseMovement2();
                invRptSupplierWiseStockMovement2.SetDataSource(dtx);
                invRptSupplierWiseStockMovement2.SummaryInfo.ReportTitle = "Supplier Wise Movement - Department Wise Reports ";
                invRptSupplierWiseStockMovement2.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;
                invRptSupplierWiseStockMovement2.DataDefinition.FormulaFields["SelectLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptSupplierWiseStockMovement2.DataDefinition.FormulaFields["Supplier"].Text = "'" + txtSupplierCode.Text.Trim() + "   " + txtSupplierName.Text.Trim() + "'";
                invRptSupplierWiseStockMovement2.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser + "'";
                invRptSupplierWiseStockMovement2.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                invRptSupplierWiseStockMovement2.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                invRptSupplierWiseStockMovement2.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";
                invRptSupplierWiseStockMovement2.DataDefinition.FormulaFields["DateFrom"].Text = "'" + fromDate + "'";
                invRptSupplierWiseStockMovement2.DataDefinition.FormulaFields["DateTo"].Text = "'" + toDate + "'";
                objReportView.crRptViewer.ReportSource = invRptSupplierWiseStockMovement2;

            }
            objReportView.WindowState = FormWindowState.Maximized;
            objReportView.Show();
            Cursor.Current = Cursors.Default;
        }

        private void chkAutoCompleationSupplier_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SupplierService supplierService = new SupplierService();
                Common.SetAutoComplete(txtSupplierCode, supplierService.GetSupplierCodes(), chkAutoCompleationSupplier.Checked);
                Common.SetAutoComplete(txtSupplierName, supplierService.GetSupplierNames(), chkAutoCompleationSupplier.Checked);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void chkAllSup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllSup.Checked == true)
            {
                Common.ClearTextBox(txtSupplierName, txtSupplierCode);
                txtSupplierCode.Enabled = false;
                txtSupplierName.Enabled = false;
            }
            else
            {
                Common.ClearTextBox(txtSupplierName, txtSupplierCode);
                txtSupplierCode.Enabled = true;
                txtSupplierName.Enabled = true;
            }
        }
    }
}
