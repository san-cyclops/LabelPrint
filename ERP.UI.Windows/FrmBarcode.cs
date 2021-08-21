using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;
using System.Transactions;
using ERP.Domain;
using ERP.Utility;
using ERP.Service;
using System.Threading;
using System.IO;
using System.Globalization;

namespace ERP.UI.Windows
{
    public partial class FrmBarcode : FrmBaseTransactionForm
    {
        List<InvBarcodeDetailTemp> invBarcodeDetailTempList = new List<InvBarcodeDetailTemp>();
        InvBarcodeDetailTemp existingInvBarcodeDetailTemp = new InvBarcodeDetailTemp();
        int documentID = 2;
        int referenceDocumentID = 0;
        static string batchNumber;
        static string barcode;
        bool isInvProduct;
        int rowCount;
        int selectedRowIndex;
        bool isUpdateGrid = false;

        private DateTime referenceDocumentDate;
        public Dictionary<string, Process> OpenedProcesses = new Dictionary<string, Process>(StringComparer.OrdinalIgnoreCase);


        public FrmBarcode()
        {
            InitializeComponent();
        }

        public override void InitializeForm()
        {
            try
            {
                // Disable product details controls
                dgvItemDetails.DataSource = null;

                EnableLine(false);

                Common.EnableButton(false, btnSave);
                grpBody.Enabled = false;
                //grpLeftFooter.Enabled = false;
                referenceDocumentID = 0;
                referenceDocumentDate = Common.GetSystemDateWithTime();
                invBarcodeDetailTempList = null;
                existingInvBarcodeDetailTemp = null;

                selectedRowIndex = 0;
                isUpdateGrid = false;
                rowCount = 0;

                cmbTag.Enabled = true;
                InvBarCodeService invBarCodeService = new InvBarCodeService();

                Common.SetAutoBindRecords(cmbTag, invBarCodeService.GetLabel());
                Common.SetAutoBindRecords(cmbUnit, invBarCodeService.GetUnitOfMeasure());
                Common.SetAutoBindRecords(cmbDocNo, invBarCodeService.GetDocumentNos());

                dtpExpiry.Value = DateTime.Now;
                dtpManufDate.Value = DateTime.Now;
                dtpReferenceDocumentDate.Value = Common.GetSystemDateWithTime();

                batchNumber = null;

                this.ActiveControl = txtReferenceDocumentNo;
                txtProductCode.Enabled = true;
                txtProductCode.Focus();
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
        }

        private void EnableLine(bool enable)
        {
            Common.EnableTextBox(enable, txtQty, txtWholesalePrice, txtSellingPrice, txtBatchNo);
            Common.EnableComboBox(enable, cmbUnit);
            dtpExpiry.Enabled = enable;
        }

        private string GetDocumentNo(bool isTemporytNo)
        {
            try
            {
                //return commonService.GetDocumentNo(this.Name, Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString()), locationService.GetLocationsByID(Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString())).LocationCode, documentID, isTemporytNo).Trim();
                return "00001";

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
                return string.Empty;
            }
        }


        public override void FormLoad()
        {
            try
            {
                dgvItemDetails.AutoGenerateColumns = false;

                documentID = 0;
                this.Text = "Lable Printing"; //autoGenerateInfo.FormText.Trim();

                dgvItemDetails.AutoGenerateColumns = false;
                btnSave.Text = "P&rint";
                dtpReferenceDocumentDate.Enabled = false;

                GetPrintingDetails();
                InvBarCodeService invBarCodeService = new InvBarCodeService();
                string docNo = invBarCodeService.GetDocumentNo();

                cmbDocNo.Text = docNo;
                dtpReferenceDocumentDate.Value = Common.GetSystemDateWithTime();
                isInvProduct = true;
                base.FormLoad();
                txtReferenceDocumentNo.Focus();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        public void SetBatchNumber(string batchNo)
        {
            batchNumber = batchNo;
        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                {
                    if (txtProductCode.Text.Trim().Equals(string.Empty))
                    {
                        txtProductCode.Enabled = true;
                        txtProductCode.Focus();
                        return;
                    }
                    else
                    {
                        txtProductCode_Leave(this, e);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductCode.Leave -= txtProductCode_Leave;
                if (!string.IsNullOrEmpty(txtProductCode.Text.Trim()))
                {
                    //loadProductDetails(true, txtProductCode.Text.Trim(), 0, dtpExpiry.Value);
                    txtProductName.Focus();
                }
                //loadProductDetails(true, txtProductCode.Text.Trim(), 0, dtpExpiry.Value);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                {

                    if (!txtProductName.Text.Trim().Equals(string.Empty))
                    {
                        cmbUnit.Enabled = true;
                        cmbUnit.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtProductName_Leave(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        private void UpdateGrid()
        {
            try
            {
                if (Common.ConvertStringToDecimalQty(txtQty.Text.Trim()) > 0)
                {
                    InvBarcodeDetailTemp invBarcodeDetail = new InvBarcodeDetailTemp();

                    invBarcodeDetail.UnitOfMeasureID = 0;

                    invBarcodeDetail.UnitOfMeasure = cmbUnit.Text.ToString().Trim();

                    invBarcodeDetail.BarCode = txtProductCode.Text.Trim();
                    invBarcodeDetail.BatchNo = txtBatchNo.Text.Trim();
                    invBarcodeDetail.ExpiryDate = dtpExpiry.Value;
                    invBarcodeDetail.ManufDate = dtpManufDate.Value;
                    invBarcodeDetail.CostPrice = 0;
                    invBarcodeDetail.LineNo = 0;
                    invBarcodeDetail.ProductCode = txtProductCode.Text.Trim();
                    invBarcodeDetail.ProductID = 0;
                    invBarcodeDetail.ProductName = txtProductName.Text.Trim();
                    invBarcodeDetail.Qty = Common.ConvertStringToDecimalQty(txtQty.Text);
                    invBarcodeDetail.SellingPrice = Common.ConvertStringToDecimalQty(txtSellingPrice.Text.Trim());
                    invBarcodeDetail.WholesalePrice = Common.ConvertStringToDecimalQty(txtWholesalePrice.Text.Trim());
                    invBarcodeDetail.Stock = 0;
                    invBarcodeDetail.DocumentDate = dtpReferenceDocumentDate.Value;
                    invBarcodeDetail.SupplierCode = "";


                    InvBarCodeService invBarCodeService = new InvBarCodeService();

                    dgvItemDetails.DataSource = null;
                    invBarcodeDetailTempList = invBarCodeService.getUpdateBarCodeDetailTemp(invBarcodeDetailTempList, invBarcodeDetail,chkOverWrite.Checked);
                    dgvItemDetails.DataSource = invBarcodeDetailTempList;
                    dgvItemDetails.Refresh();
                    txtTotQty.Text = Common.ConvertDecimalToStringQty(invBarcodeDetailTempList.GetSummaryAmount(x => x.Qty));

                    foreach (DataGridViewRow row in dgvItemDetails.Rows)
                    {
                        if (string.Equals(txtProductCode.Text.Trim(), dgvItemDetails["ProductCode", row.Index].Value.ToString()) && string.Equals(txtBatchNo.Text.Trim(), dgvItemDetails["BatchNo", row.Index].Value.ToString()))
                        {
                            isUpdateGrid = true;
                            selectedRowIndex = row.Index;
                            break;
                        }
                    }

                    if (isUpdateGrid)
                    {
                        dgvItemDetails.CurrentCell = dgvItemDetails.Rows[selectedRowIndex].Cells[0];
                        isUpdateGrid = false;
                    }
                    else
                    {
                        rowCount = dgvItemDetails.Rows.Count;
                        dgvItemDetails.CurrentCell = dgvItemDetails.Rows[rowCount - 1].Cells[0];
                    }
                    Common.EnableButton(true, btnSave);

                    ClearLine();
                    EnableLine(false);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void ClearLine()
        {
            try
            {
                Common.ClearTextBox(txtProductCode, txtProductName, txtBatchNo, txtQty, txtWholesalePrice, txtSellingPrice);
                txtProductCode.Focus();
                Common.ClearComboBox(cmbUnit);
                dtpExpiry.Value = DateTime.Now;
                barcode = "";
                txtProductCode.Focus();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void GetPrintingDetails()
        {

            //foreach (string printname in PrinterSettings.InstalledPrinters)
            //{
            //    cmbPrinter.Items.Add(printname);
            //}

        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        txtSellingPrice.Enabled = true;
                        txtSellingPrice.Focus();
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        public override void ClearForm()
        {
            try
            {
                dgvItemDetails.DataSource = null;
                dgvItemDetails.Refresh();
                barcode = "";
                base.ClearForm();
                InitializeForm();
                FormLoad();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtReferenceDocumentNo_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode.Equals(Keys.Return) || e.KeyCode.Equals(Keys.Tab))
                {
                    grpBody.Enabled = true;
                    txtProductCode.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void RefreshGrid()
        {
            try
            {
                dgvItemDetails.DataSource = null;
                dgvItemDetails.DataSource = invBarcodeDetailTempList;
                grpBody.Enabled = true;
                grpLeftFooter.Enabled = true;
                txtTotQty.Text = Common.ConvertDecimalToStringQty(invBarcodeDetailTempList.GetSummaryAmount(x => x.Qty));
                dgvItemDetails.Refresh();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        public bool IsValidSystemTransactionDate(DateTime systemDate)
        {
            return true;
        }

        private void dgvItemDetails_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                isUpdateGrid = true;
                if (dgvItemDetails.CurrentCell != null && dgvItemDetails.CurrentCell.RowIndex >= 0)
                {
                    if (dgvItemDetails["ProductCode", dgvItemDetails.CurrentCell.RowIndex].Value == null)
                    {
                        Toast.Show(this.Text, "No data available to display", "", Toast.messageType.Information, Toast.messageAction.General, "");
                        return;
                    }
                    else
                    {
                        selectedRowIndex = dgvItemDetails.CurrentCell.RowIndex;
                        loadProductDetails(dgvItemDetails["ProductCode", dgvItemDetails.CurrentCell.RowIndex].Value.ToString().Trim(), dgvItemDetails["Unit", dgvItemDetails.CurrentCell.RowIndex].Value.ToString(), dgvItemDetails["BatchNo", dgvItemDetails.CurrentCell.RowIndex].Value.ToString());

                        txtQty.Enabled = true;
                        this.ActiveControl = txtQty;
                        txtQty.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodBase.GetCurrentMethod().Name, this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void loadProductDetails(string strProduct, string unitofMeasure, string batchNo)
        {
            try
            {
                if (strProduct.Equals(string.Empty))
                { return; }


                InvBarCodeService invBarCodeService = new InvBarCodeService();
                if (invBarcodeDetailTempList == null)
                { invBarcodeDetailTempList = new List<InvBarcodeDetailTemp>(); }

                txtBatchNo.Text = string.Empty;
                txtBatchNo.Enabled = false;

                existingInvBarcodeDetailTemp = invBarCodeService.getBarCodeDetailTemp(invBarcodeDetailTempList, strProduct, unitofMeasure, batchNo.Trim());

                if (existingInvBarcodeDetailTemp != null)
                {
                    txtProductCode.Text = existingInvBarcodeDetailTemp.ProductCode;
                    txtProductName.Text = existingInvBarcodeDetailTemp.ProductName;
                    cmbUnit.Text = existingInvBarcodeDetailTemp.UnitOfMeasure;
                    txtWholesalePrice.Text = Common.ConvertDecimalToStringCurrency(existingInvBarcodeDetailTemp.WholesalePrice);
                    txtSellingPrice.Text = Common.ConvertDecimalToStringCurrency(existingInvBarcodeDetailTemp.SellingPrice);
                    txtQty.Text = existingInvBarcodeDetailTemp.Qty.ToString();
                    dtpExpiry.Value = (DateTime)existingInvBarcodeDetailTemp.ExpiryDate;
                    dtpManufDate.Value = (DateTime)existingInvBarcodeDetailTemp.ManufDate;
                    txtBatchNo.Text = existingInvBarcodeDetailTemp.BatchNo;
                    dtpExpiry.Enabled = false;
                    dtpManufDate.Enabled = false;
                    Common.EnableComboBox(false, cmbUnit);
                    txtQty.Enabled = true;
                    this.ActiveControl = txtQty;
                    txtQty.Focus();

                }
                else
                {
                    Toast.Show(this.Text, "Product", strProduct, Toast.messageType.Information, Toast.messageAction.NotExists);
                    return;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void dgvItemDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
            {
                try
                {
                    if (dgvItemDetails.CurrentCell != null && dgvItemDetails.CurrentCell.RowIndex >= 0)
                    {
                        //if (Toast.Show("Product " + dgvItemDetails["ProductCode", dgvItemDetails.CurrentCell.RowIndex].Value.ToString() + " - " + dgvItemDetails["ProductName", dgvItemDetails.CurrentCell.RowIndex].Value.ToString() + "", Toast.messageType.Question, Toast.messageAction.Delete).Equals(DialogResult.No))

                        if (Toast.Show(this.Text, dgvItemDetails["ProductCode", dgvItemDetails.CurrentCell.RowIndex].Value.ToString(), dgvItemDetails["ProductName", dgvItemDetails.CurrentCell.RowIndex].Value.ToString(), Toast.messageType.Question, Toast.messageAction.Delete).Equals(DialogResult.No))

                        { return; }

                        InvBarCodeService invBarCodeService = new InvBarCodeService();
                        InvBarcodeDetailTemp invBarcodeDetailTemp = new InvBarcodeDetailTemp();

                        invBarcodeDetailTemp.ProductCode = dgvItemDetails["ProductCode", dgvItemDetails.CurrentCell.RowIndex].Value.ToString().Trim();
                        invBarcodeDetailTemp.BatchNo = dgvItemDetails["BatchNo", dgvItemDetails.CurrentCell.RowIndex].Value.ToString().Trim();

                        invBarcodeDetailTempList = invBarCodeService.getDeleteBarCodeDetailTemp(invBarcodeDetailTempList, invBarcodeDetailTemp);
                        RefreshGrid();
                        this.ActiveControl = txtProductCode;
                        txtProductCode.Focus();
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex, MethodBase.GetCurrentMethod().Name, this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
                }
            }
        }


        public override void Save()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                InvBarCodeService invBarcodeService = new InvBarCodeService();
                List<InvBarcodeDetailTemp> invBarcodeDetailTemps = invBarcodeService.GetDocument(cmbDocNo.Text.Trim());
                string NewDocumentNo;

                if (invBarcodeDetailTemps.Count>0)
                {
                    bool deleteDocument = invBarcodeService.Delete(cmbDocNo.Text.Trim());
                    if (deleteDocument == false)
                    {
                        Toast.Show(this.Text, cmbDocNo.Text.Trim(), "Transaction Error", Toast.messageType.Error, Toast.messageAction.NotExistsForSelected);
                        return;
                    }
                    NewDocumentNo = cmbDocNo.Text.Trim(); 
                }
                else
                {
                    NewDocumentNo = invBarcodeService.GetDocumentNo();
                }

                bool saveDocument = invBarcodeService.Save(invBarcodeDetailTempList, NewDocumentNo, this.Name);

                if (saveDocument)
                {
                    bool printBarCode = PrintBarCode();
                    this.Cursor = Cursors.Default;
                    if (printBarCode.Equals(true))
                    {
                        Toast.Show(this.Text, NewDocumentNo, "", Toast.messageType.Information, Toast.messageAction.Print);
                        ClearForm();
                    }
                    else
                    {
                        Toast.Show(this.Text, NewDocumentNo, "", Toast.messageType.Error, Toast.messageAction.Print);
                        ClearForm();
                    }
                }
                else
                {
                    Toast.Show(this.Text, NewDocumentNo, "", Toast.messageType.Error, Toast.messageAction.SaveTransaction);
                    return;
                }


            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        public override void CloseForm()
        {
            try
            {
                base.CloseForm();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }
        private bool PrintBarCode()
        {
            try
            {
                SystemConfig systemConfig = new SystemConfig();


                StreamWriter m_streamWriter;

                string @barcodeTextPath, @appPath, @destinationPath;
                bool blnLocalCopy = false, folderExists = false;
                string txtFileName = "", exeFileName = "", tagFileName = "", sourceFile = "", destFile = "";

                txtFileName = "bar.txt";
                exeFileName = "Barcode.exe";

                tagFileName = cmbTag.Text.Trim();

                @appPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "BarCode");

                //systemConfig = commonDetails.GetSystemInfo(1);

                //if (systemConfig != null)
                //{
                //    @barcodeTextPath = @systemConfig.BarcodeTextPath; //@"C:\Barcode";
                //}
                //else
                //{
                //    return false;
                //}

                //@destinationPath = @barcodeTextPath;



                //if (!folderExists)
                //{
                //    folderExists = true;
                //    blnLocalCopy = Common.CopyDirectory(@appPath, @destinationPath, true);
                //}

                folderExists = Directory.Exists(@appPath);

                if (folderExists)
                {
                    FileStream fileStream = new FileStream(@appPath + @"\\" + txtFileName, FileMode.Create);
                    m_streamWriter = new StreamWriter(fileStream);

                    foreach (InvBarcodeDetailTemp invBarcodeDetailTemp in invBarcodeDetailTempList)
                    {
                        // if (invBarcodeDetailTemp.IsBatch)
                        {
                            for (int count = 0; count < invBarcodeDetailTemp.Qty; count = count + 1)
                            {
                                //    string strSellingPrice = (string.Format("{0:#0.##}", invBarcodeDetailTemp.SellingPrice));

                                //    string str1;
                                //    string str2;
                                //    string str3;
                                //    string str4;
                                //    string str5;
                                //    string str6;
                                //    string str7;
                                //    string str8;
                                //    string str9;
                                //    string str0;
                                //    int intLoop;
                                //    string strCostCode;

                                //    strCostCode = "CANTJUMPEX";

                                //    str1 = strCostCode.Substring(1, 1);
                                //    str2 = strCostCode.Substring(2, 1);
                                //    str3 = strCostCode.Substring(3, 1);
                                //    str4 = strCostCode.Substring(4, 1);
                                //    str5 = strCostCode.Substring(5, 1);
                                //    str6 = strCostCode.Substring(6, 1);
                                //    str7 = strCostCode.Substring(7, 1);
                                //    str8 = strCostCode.Substring(8, 1);
                                //    str9 = strCostCode.Substring(9, 1);
                                //    str0 = strCostCode.Substring(10, 1);


                                //    String strCostPrice;
                                //    String strCode;



                                //    strCode = "";

                                //    for (int xcount = 1; count < strSellingPrice.Length; count = count + 1)
                                //    {
                                //        switch (Common.ConvertStringToInt(strSellingPrice.Substring(xcount, 1)))
                                //        {
                                //            case 0:
                                //                strCode = strCode + str0;
                                //                break;
                                //            case 1:
                                //                strCode = strCode + str1;
                                //                break;
                                //            case 2:
                                //                strCode = strCode + str2;
                                //                break;
                                //            case 3:
                                //                strCode = strCode + str3;
                                //                break;
                                //            case 4:
                                //                strCode = strCode + str4;
                                //                break;
                                //            case 5:
                                //                strCode = strCode + str5;
                                //                break;
                                //            case 6:
                                //                strCode = strCode + str6;
                                //                break;
                                //            case 7:
                                //                strCode = strCode + str7;
                                //                break;
                                //            case 8:
                                //                strCode = strCode + str8;
                                //                break;
                                //            case 9:
                                //                strCode = strCode + str9;
                                //                break;
                                //        }
                                //    }
                                //    strCode = strCode + "." + str0 + str0;
                                //    string EncryptedCostPrice = strCode;





                                m_streamWriter.WriteLine(invBarcodeDetailTemp.ProductCode + "," +
                                                               invBarcodeDetailTemp.ProductName + "," +
                                                                    invBarcodeDetailTemp.UnitOfMeasure + ", " +
                                                                    invBarcodeDetailTemp.BatchNo + ", " +
                                                                    Convert.ToDateTime(invBarcodeDetailTemp.ManufDate.ToString()).ToString("dd-MM-yyyy") + "," +
                                                                    Convert.ToDateTime(invBarcodeDetailTemp.ExpiryDate.ToString()).ToString("dd-MM-yyyy") + "," +
                                                                    invBarcodeDetailTemp.Qty + "," +
                                                                    invBarcodeDetailTemp.SellingPrice + "," +
                                                                    invBarcodeDetailTemp.WholesalePrice);
                            }
                        }
                        //    else
                        //    {
                        //        for (int count = 0; count < invBarcodeDetailTemp.Qty; count = count + 1)
                        //        {
                        //            string strSellingPrice = (string.Format("{0:#0.##}", invBarcodeDetailTemp.SellingPrice));
                        //            string strCostPrice = (string.Format("{0:0.##}", invBarcodeDetailTemp.CostPrice));

                        //            string str1;
                        //            string str2;
                        //            string str3;
                        //            string str4;
                        //            string str5;
                        //            string str6;
                        //            string str7;
                        //            string str8;
                        //            string str9;
                        //            string str0;
                        //            int intLoop;
                        //            string strCostCode;



                        //            strCostCode = "CANTJUMPEX";


                        //            str1 = strCostCode.Substring(0, 1);
                        //            str2 = strCostCode.Substring(1, 1);
                        //            str3 = strCostCode.Substring(2, 1);
                        //            str4 = strCostCode.Substring(3, 1);
                        //            str5 = strCostCode.Substring(4, 1);
                        //            str6 = strCostCode.Substring(5, 1);
                        //            str7 = strCostCode.Substring(6, 1);
                        //            str8 = strCostCode.Substring(7, 1);
                        //            str9 = strCostCode.Substring(8, 1);
                        //            str0 = strCostCode.Substring(9,1);


                        //            String strCode;



                        //            strCode = "";

                        //            for (int xcount = 0; xcount < strCostPrice.Length; xcount = xcount + 1)
                        //            {
                        //                switch (Common.ConvertStringToInt(strCostPrice.Substring(xcount, 1)))
                        //                {
                        //                    case 0:
                        //                        strCode = strCode + str0;
                        //                        break;
                        //                    case 1:
                        //                        strCode = strCode + str1;
                        //                        break;
                        //                    case 2:
                        //                        strCode = strCode + str2;
                        //                        break;
                        //                    case 3:
                        //                        strCode = strCode + str3;
                        //                        break;
                        //                    case 4:
                        //                        strCode = strCode + str4;
                        //                        break;
                        //                    case 5:
                        //                        strCode = strCode + str5;
                        //                        break;
                        //                    case 6:
                        //                        strCode = strCode + str6;
                        //                        break;
                        //                    case 7:
                        //                        strCode = strCode + str7;
                        //                        break;
                        //                    case 8:
                        //                        strCode = strCode + str8;
                        //                        break;
                        //                    case 9:
                        //                        strCode = strCode + str9;
                        //                        break;
                        //                }
                        //            }
                        //           // strCode = strCode + "." + str0 + str0;
                        //            string EncryptedCostPrice = strCode;

                        //            m_streamWriter.WriteLine(invBarcodeDetailTemp.ProductID + "," +
                        //                                            invBarcodeDetailTemp.ProductCode + "," +
                        //                                            invBarcodeDetailTemp.ProductName + ", " +
                        //                                            invBarcodeDetailTemp.ProductCode + ", " +
                        //                                            invBarcodeDetailTemp.BatchNo + "," +
                        //                                            invBarcodeDetailTemp.UnitOfMeasure + "," +
                        //                                            invBarcodeDetailTemp.ExpiryDate + "," +
                        //                                            invBarcodeDetailTemp.ManufDate + "," +
                        //                                            invBarcodeDetailTemp.Qty + "," +
                        //                                            invBarcodeDetailTemp.SellingPrice + "," +
                        //                                            invBarcodeDetailTemp.WholesalePrice);
                        //        }
                        //    }
                        //} 
                    }
                    m_streamWriter.Close();
                    fileStream.Close();

                    if (File.Exists(@appPath + @"\\" + tagFileName))
                    {
                        Process.Start(@appPath + @"\\" + tagFileName);
                        //Process.Start(@destinationPath + @"\\" + exeFileName);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
            return true;
        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    cmbUnit_Leave(this, e);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void cmbUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbUnit.Text == null)
                    return;
                else
                {
                    txtBatchNo.Enabled = true;
                    txtBatchNo.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }


        private void dtpReferenceDocumentDate_Leave(object sender, EventArgs e)
        {

            try
            {

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void cmbPrinter_SelectedValueChdanged(object sender, EventArgs e)
        {
            try
            {
                //LookUpReferenceService lookUpReferenceService = new LookUpReferenceService();
                //List<ReferenceType> referenceTypeList = new List<ReferenceType>();
                //if(cmbPrinter.Text.Contains("Zebra 110"))

                //    string[] fileArray = Directory.GetFiles(@"c:\Dir\", "*.jpg");

                //    referenceTypeList = lookUpReferenceService.GetLookUpReferenceByValue(((int)LookUpReference.TitleType).ToString(), cmbTag.Text.Trim());
                //if (referenceType != null)
                //{
                //    tagFileName = string.Concat(referenceType.Remark, ".lbx");
                //}
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void dgvItemDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chkAutoCompleationReferenceDocumentNo_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblPDocumentNo);
        }

        private void chkAutoCompleationReferenceDocumentNo_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblPDocumentNo);
        }

        private void txtReferenceDocumentNo_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblPDocumentNo);
        }

        private void txtReferenceDocumentNo_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblPDocumentNo);
        }

        private void dtpReferenceDocumentDate_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblDate);
        }

        private void cmbTag_Enter(object sender, EventArgs e)
        {
            Common.HighlightControl(lblTag);
        }

        private void cmbTag_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightControl(lblTag);
        }

        private void FrmBarcode_Load(object sender, EventArgs e)
        {
            Common.FormatDataGrid(dgvItemDetails);
            //lblHeader.Text = lblHeader.Text.ToUpper();
            //pnl_header.BackColor = Common.HeaderColor();
            //pnl_header.ForeColor = Common.HeaderForeColor();
        }

        private void chkAutoCompleationReferenceDocumentNo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    txtBatchNo_Leave(this, e);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }

        }

        private void txtBatchNo_Leave(object sender, EventArgs e)
        {
            //if (Common.ConvertStringToDecimal(txtQty.Text.Trim()) == 0)
            //    txtQty.Text = "1";
            dtpManufDate.Enabled = true;
            dtpManufDate.Focus();
        }

        private void dtpExpiry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    txtQty.Enabled = true;
                    txtQty.Text = "1";
                    txtQty.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void dtpManufDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    dtpExpiry.Enabled = true;
                    dtpExpiry.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    txtWholesalePrice.Enabled = true;
                    txtWholesalePrice.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }

        }

        private void txtWholesalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                    { UpdateGrid(); }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void cmbDocNo_Click(object sender, EventArgs e)
        {


        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            InvBarCodeService invBarCodeService = new InvBarCodeService();
            if (cmbDocNo.Text.Trim() != "")
            {
                invBarcodeDetailTempList = invBarCodeService.GetDocument(cmbDocNo.Text.Trim());
                if (invBarcodeDetailTempList == null)
                {
                    Toast.Show(this.Text, "Document No", txtReferenceDocumentNo.Text.Trim(), Toast.messageType.Information, Toast.messageAction.NotExists);
                    txtReferenceDocumentNo.Focus();
                    return;
                }
                else
                {
                    RefreshGrid();
                    Common.EnableButton(true, btnSave);
                    txtProductCode.Focus();
                    return;
                }
            }

        }
    }
}
