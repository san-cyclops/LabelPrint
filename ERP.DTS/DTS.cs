using ERP.Service;
using ERP.Utility;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using ERP.Domain;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.Net.NetworkInformation;
using System.Drawing;

namespace ERP.DTS
{
    public partial class frmDTS : Form
    {
        BackgroundWorker bgUp = new BackgroundWorker();
        SqlConnection HOConnection;
        SqlConnection OutletConnection;
        private Location existingLocation;
        bool stopwork = true;
        private string OutletIP;
        private static string HOIP;
        string strOutletConnection;
        string strHOConnection;
        static readonly object _locker = new object();


        int loca = 0;


        private BackgroundWorker myWorker = new BackgroundWorker();
        public frmDTS()
        {
            InitializeComponent();
            //pictureBox1.Visible = false;
            myWorker.DoWork += new DoWorkEventHandler(myWorker_DoWork);
            myWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorker_RunWorkerCompleted);
            myWorker.ProgressChanged += new ProgressChangedEventHandler(myWorker_ProgressChanged);
            myWorker.WorkerReportsProgress = true;
            myWorker.WorkerSupportsCancellation = true;
            progressBar1.Maximum = 100;


            //HOConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString);
            //OutletConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OutletCon"].ConnectionString);

            //LocationService locationServise = new LocationService();
            //existingLocation = locationServise.GetHeadOfficeLocationDT();
            //HOIP = existingLocation.LocationIP;
            strHOConnection = ConfigurationManager.ConnectionStrings["SysConn"].ToString();

            strOutletConnection = ConfigurationManager.ConnectionStrings["OutCon"].ToString();

            SqlConnection myConn = new SqlConnection(strHOConnection);
            try
            {
                myConn.Open();
                if (myConn.State != ConnectionState.Open)
                {
                    lblConnection.ForeColor = Color.Red;
                    lblConnection.Text = "HeadOffice Connection Fail";
                    return;
                }

                if (myConn.State == ConnectionState.Open)
                {
                    lblConnection.ForeColor = Color.Green;
                    lblConnection.Text = "HeadOffice Connection Ok";
                    timer1.Enabled = true;
                    pictureBox1.Visible = true;

                }
            }
            catch
            {
                lblConnection.ForeColor = Color.Red;
                lblConnection.Text = "HeadOffice Connection Fail";
                return;
            }



            myConn = new SqlConnection(strOutletConnection);
            try
            {
                myConn.Open();
                if (myConn.State != ConnectionState.Open)
                {
                    lblConnection.ForeColor = Color.Red;
                    lblConnection.Text = "Outlet Connection Fail";
                    return;
                }

                if (myConn.State == ConnectionState.Open)
                {
                    lblConnection.ForeColor = Color.Green;
                    lblConnection.Text = lblConnection.Text + " And Outlet Connection Ok";
                    timer1.Enabled = true;
                    pictureBox1.Visible = true;
                }
            }
            catch
            {
                lblConnection.ForeColor = Color.Red;
                lblConnection.Text = "Outlet Connection Fail";
                return;
            }

            SqlConnection sqlCon = new SqlConnection(strOutletConnection);
            string getId = (@"SELECT LocationID FROM dbo.Location WHERE IsShowRoom = 1 AND IsHeadOffice =0 ");
            sqlCon.Open();
            SqlCommand cmd1 = new SqlCommand(getId, sqlCon);
            loca = Convert.ToInt32(cmd1.ExecuteScalar());
            lblLocaid.Text = Convert.ToInt32(cmd1.ExecuteScalar()).ToString();

            Common.EnableButton(false, btnUp);
        }


        public bool IsOnline(string ip)
        {

            try
            {
                bool isConnected = false;
                string terminalIP = ip;

                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                // Use the default Ttl value which is 128,
                // but change the fragmentation behavior.
                options.DontFragment = true;

                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "Nuwan";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 900;
                //PingReply reply = pingSender.Send(terminalIP, timeout, buffer, options);
                PingReply reply = pingSender.Send(terminalIP);
                if (reply.Status == IPStatus.Success)
                {
                    //Console.WriteLine("Address: {0}", reply.Address.ToString());
                    //Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                    //Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                    //Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                    //Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                    isConnected = true;
                }

                return isConnected;


            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
                return false;
            }

        }



        private void txtLocationCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.F3))
                {
                    LocationService locationService = new LocationService();
                    DataView dvAllReferenceData = new DataView(Common.DataTableColumnNameChange(locationService.GetAllLocationsDataTble()));
                    if (dvAllReferenceData.Count != 0)
                    {
                        LoadReferenceSearchForm(dvAllReferenceData, this.Name.Trim(), this.Text.Trim(), this.ActiveControl.Text.Trim(), txtLocationCode);
                        txtLocationCode_Leave(this, e);
                    }
                }
                if (!e.KeyCode.Equals(Keys.Enter))
                {
                    return;
                }
                txtLocationName.Focus();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtLocationCode_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(lblLocationCode);
                if (txtLocationCode.Text.Trim() != string.Empty)
                {
                    LocationService locationServise = new LocationService();
                    CompanyService companyService = new CompanyService();
                    CostCentreService costCentreService = new CostCentreService();

                    existingLocation = locationServise.GetLocationsByCode(txtLocationCode.Text.Trim());

                    if (existingLocation != null)
                    {

                        txtLocationCode.Text = existingLocation.LocationCode;
                        txtLocationName.Text = existingLocation.LocationName;
                        OutletIP = existingLocation.LocationIP;
                        strOutletConnection = "Data Source=" + OutletIP + ";" +
                                            "Initial Catalog=RIT_ERP;" +
                                            "User id=sa;" +
                                            "Password=SYSMANAGER;";



                        Common.EnableButton(true, btnUp);
                    }
                    else
                    {
                        Common.ClearTextBox(txtLocationName);
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtLocationName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.F3))
                {
                    LocationService locationService = new LocationService();
                    DataView dvAllReferenceData = new DataView(Common.DataTableColumnNameChange(locationService.GetAllLocationsDataTble()));
                    if (dvAllReferenceData.Count != 0)
                    {
                        LoadReferenceSearchForm(dvAllReferenceData, this.Name.Trim(), this.Text.Trim(), this.ActiveControl.Text.Trim(), txtLocationCode);
                        txtLocationCode_Leave(this, e);
                    }
                }
                if (!e.KeyCode.Equals(Keys.Enter))
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void txtLocationName_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightControl(lblLocationName);

                if (txtLocationName.Text.Trim() != string.Empty)
                {
                    LocationService locationServise = new LocationService();
                    CompanyService companyService = new CompanyService();
                    CostCentreService costCentreService = new CostCentreService();

                    existingLocation = locationServise.GetLocationsByName(txtLocationName.Text.Trim());

                    if (existingLocation != null)
                    {

                        txtLocationCode.Text = existingLocation.LocationCode;
                        txtLocationName.Text = existingLocation.LocationName;
                        OutletIP = existingLocation.LocationIP;
                        strOutletConnection = "Data Source=" + OutletIP + ";" +
                                            "Initial Catalog=RIT_ERPOUT;" +
                                            "User id=sa;" +
                                            "Password=SYSMANAGER;";
                        Common.EnableButton(true, btnUp);
                    }
                    else
                    {
                        Common.ClearTextBox(txtLocationName);
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }


        }

        private void LoadReferenceSearchForm(DataView dvAllReferenceData, string parentOfSearch, string searchFormCaption, string searchText, Control focusControl)
        {
            try
            {
                FrmReferenceSearch referenceSearch = new FrmReferenceSearch();
                referenceSearch.ParentOfSearch = parentOfSearch.Trim();
                referenceSearch.FormCaption = searchFormCaption.Trim();
                referenceSearch.SearchText = searchText.Trim();
                referenceSearch.DvResults = dvAllReferenceData;
                referenceSearch.FocusControl = focusControl;

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


        #region Background work
        protected void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker sendingWorker = (BackgroundWorker)sender;//Capture the BackgroundWorker that fired the event
                StringBuilder strz = new StringBuilder();

                int x = UpDepartment();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("Department - : {0}{1}", x, Environment.NewLine));//Append the result to the string builder

                //sb.Append ("Department -" + x);
                sendingWorker.ReportProgress(10);

                //MessageBox.Show("UpDepartment");

                x = UpCategory();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("Category - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(20);

                //MessageBox.Show("Category");

                x = UpSubCategory();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("SubCategory - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(30);

                //MessageBox.Show("SubCategory");

                x = UpSubCategory2();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("SubCategory2 - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(40);

                //MessageBox.Show("SubCategory2");

                x = UpSupplier();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("Supplier - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(45);

                //MessageBox.Show("Supplier");

                x = UpSupplierGroup();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("SupplierGroup - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(48);

                //MessageBox.Show("SupplierGroup");

                x = UpUnitOfMeasure();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("UnitOfMeasure - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(50);

                x = UpSalesPerson();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("InvSalesPerson - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(50);

                //MessageBox.Show("UnitOfMeasure");

                x = UpInvProductMaster();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("InvProductMaster - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(70);

                //MessageBox.Show("InvProductMaster");

                x = UpInvProductStockMaster();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("InvProductStockMaster - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(75);

                x = UpCashierPermission();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("CashierPermission - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(80);

                //MessageBox.Show("CashierPermission");

                x = UpCashierFunction();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("CashierFunction - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(90);

                //MessageBox.Show("CashierFunction");

                x = UpCustomer();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("Customer - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(100);

                x = DownPay();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("PaymentDet - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(100);

                x = DownTrans();
                myWorker.ReportProgress(x);
                strz.Append(string.Format("TransactionDet - : {0}{1}", x, Environment.NewLine));
                sendingWorker.ReportProgress(100);
                //MessageBox.Show("Customer");

                Logger.WriteLog("----------------End of Cycle", "-------------", "---------------------------------------", Logger.logtype.Event, Common.LoggedLocationID);



                e.Result = strz.ToString();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }

        }

        protected void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)//Check if the worker has been cancelled or if an error occured
            {
                //string result = (string)e.Result.ToString();//Get the result from the background thread
                //textBox1.Text =(result);//Display the result to the user
                //lblStatus.Text = "Transfer Complete and Irritate";
                Thread.Sleep(1000);
                //textBox1.Text = "";

                myWorker.RunWorkerAsync();

            }
            else if (e.Cancelled)
            {
                lblStatus.Text = "User Cancelled";
                myWorker.CancelAsync();

            }
            else
            {
                lblStatus.Text = "An error has occured";
                myWorker.CancelAsync();
            }
            btnUp.Enabled = true;//Reneable the start button
        }

        protected void myWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Show the progress to the user based on the input we got from the background worker
            lblStatus.Text = string.Format("Counting number: {0}...", e.ProgressPercentage);
            //listBox1.Items.Add(e.ProgressPercentage);
        }

        #endregion

        private void btnUp_Click(object sender, EventArgs e)
        {
            //pictureBox1.Visible = true;
            //if (!myWorker.IsBusy)//Check if the worker is already in progress
            //{
            //    btnUp.Enabled = false;//Disable the Start button
            //    myWorker.RunWorkerAsync();//Call the background worker
            //}


        }
        //void bgUp_DoWork(object sender, DoWorkEventArgs e)
        void work()
        {
            try
            {

                Thread.Sleep(1000);
                UpDepartment();
                UpCategory();
                UpSubCategory();
                UpSubCategory2();
                UpSupplier();
                UpSupplierGroup();
                //UpSupplierProperty();
                UpUnitOfMeasure();
                UpInvProductMaster();
                UpInvProductStockMaster();
                UpCashierPermission();
                UpCashierFunction();
                UpCustomer();

                stopwork = false;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        public bool UploadTransactions()
        {
            try
            {

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DateTime getModifyDate(string columnName)
        {
            SqlConnection sqlCon = new SqlConnection(strOutletConnection);
            string getId = (@"SELECT " + columnName + " FROM DTSConfig");
            sqlCon.Open();
            SqlCommand cmd1 = new SqlCommand(getId, sqlCon); ;
            return Convert.ToDateTime(cmd1.ExecuteScalar());

        }

        private int UpDepartment()
        {

            DataTable dt = new DataTable();
            InvDepartmentService invDepartmentService = new InvDepartmentService();

            //invDepartmentService.UpdateInvDepartmentDTSelect(1);

            dt = invDepartmentService.GetActiveInvDepartmentsDataTable(getModifyDate("InvDepartment"));
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "InvDepartment";
                string mergeSql = CommonService.MergeSqlTo(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "InvDepartment", mergeSql, strOutletConnection, strHOConnection);
                //lblMsg.Text = "InvDepartment" + " - " + dt.Rows.Count.ToString();
                Logger.WriteLog("InvDepartment" + " - " + dt.Rows.Count.ToString(), "InvDepartment", this.Name, Logger.logtype.Event, Common.LoggedLocationID);
            }
            // lblMsg.Text = "InvDepartment" + " - " + dt.Rows.Count.ToString();

            string textForLabel = "InvDepartment -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);

            return dt.Rows.Count;

        }

        private int UpCategory()
        {


            DataTable dt = new DataTable();
            InvCategoryService invCategoryService = new InvCategoryService();
            //invCategoryService.UpdateInvCategoryDTSelect(1);
            dt = invCategoryService.GetActiveInvCategoriesDataTable(getModifyDate("InvCategory"));

            if (dt.Rows.Count > 0)
            {
                dt.TableName = "InvCategory";
                string mergeSql = CommonService.MergeSqlTo(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "InvCategory", mergeSql, strOutletConnection, strHOConnection);
                Logger.WriteLog("InvCategory" + " - " + dt.Rows.Count.ToString(), "InvCategory", this.Name, Logger.logtype.Event, Common.LoggedLocationID);

            }
            string textForLabel = "InvCategory -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;

        }

        private int UpSubCategory()
        {

            DataTable dt = new DataTable();
            InvSubCategoryService invSubCategoryService = new InvSubCategoryService();
            //invSubCategoryService.UpdateInvSubCategoryDTSelect(1);
            dt = invSubCategoryService.GetInvSubCategoriesDataTable(getModifyDate("InvCategory"));
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "InvSubCategory";
                string mergeSql = CommonService.MergeSqlTo(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "InvSubCategory", mergeSql, strOutletConnection, strHOConnection);
                Logger.WriteLog("InvSubCategory" + " - " + dt.Rows.Count.ToString(), "InvCategory", this.Name, Logger.logtype.Event, Common.LoggedLocationID);

            }
            string textForLabel = "InvSubCategory -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;
        }

        private int UpSubCategory2()
        {

            DataTable dt = new DataTable();
            InvSubCategory2Service invSubCategory2Service = new InvSubCategory2Service();
            //invSubCategory2Service.UpdateInvSubCategory2DTSelect(1);
            dt = invSubCategory2Service.GetAllInvSubCategories2DataTable(getModifyDate("InvSubCategory2"));
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "InvSubCategory2";
                string mergeSql = CommonService.MergeSqlTo(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "InvSubCategory2", mergeSql, strOutletConnection, strHOConnection);
                Logger.WriteLog("InvSubCategory2" + " - " + dt.Rows.Count.ToString(), "InvSubCategory2", this.Name, Logger.logtype.Event, Common.LoggedLocationID);

            }
            string textForLabel = "InvSubCategory2 -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;

        }

        private int UpSupplier()
        {

            DataTable dt = new DataTable();
            SupplierService supplierService = new SupplierService();
            //supplierService.UpdateSupplierDTSelect(1);
            dt = supplierService.GetAllDTSuppliersDataTable(getModifyDate("Supplier"));
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "Supplier";
                string mergeSql = CommonService.MergeSqlTo(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "Supplier", mergeSql, strOutletConnection, strHOConnection);
                Logger.WriteLog("Supplier" + " - " + dt.Rows.Count.ToString(), "Supplier", this.Name, Logger.logtype.Event, Common.LoggedLocationID);

            }
            string textForLabel = "Supplier -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;

        }

        private int UpSupplierGroup()
        {
            DataTable dt = new DataTable();
            SupplierGroupService supplierGroupService = new SupplierGroupService();
            //supplierGroupService.UpdateSupplierGroupDTSelect(1);
            dt = supplierGroupService.GetAllSupGroupsDataTable(getModifyDate("SupplierGroup"));
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "SupplierGroup";
                string mergeSql = CommonService.MergeSqlTo(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "SupplierGroup", mergeSql, strOutletConnection, strHOConnection);
                Logger.WriteLog("SupplierGroup" + " - " + dt.Rows.Count.ToString(), "SupplierGroup", this.Name, Logger.logtype.Event, Common.LoggedLocationID);

            }
            string textForLabel = "SupplierGroup -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;
        }

        private int UpSupplierProperty()
        {

            DataTable dt = new DataTable();
            SupplierPropertyService supplierPropertyService = new SupplierPropertyService();
            //supplierPropertyService.UpdateSupplierPropertyDT(0, 1);
            dt = supplierPropertyService.GetAllDTSupplierPropertyDataTable(getModifyDate("SupplierProperty"));
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "SupplierProperty";
                string mergeSql = CommonService.MergeSqlTo(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "SupplierProperty", mergeSql, strOutletConnection, strHOConnection);
                Logger.WriteLog("SupplierProperty" + " - " + dt.Rows.Count.ToString(), "SupplierProperty", this.Name, Logger.logtype.Event, Common.LoggedLocationID);

            }
            string textForLabel = "SupplierProperty -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;

        }

        private int UpUnitOfMeasure()
        {
            DataTable dt = new DataTable();
            UnitOfMeasureService unitOfMeasureService = new UnitOfMeasureService();
            //unitOfMeasureService.UpdateUnitOfMeasureDTSelect(1);
            dt = unitOfMeasureService.GetAllDTUnitOfMeasuresDataTable(getModifyDate("UnitOfMeasure"));
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "UnitOfMeasure";
                string mergeSql = CommonService.MergeSqlTo(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "UnitOfMeasure", mergeSql, strOutletConnection, strHOConnection);
                Logger.WriteLog("UnitOfMeasure" + " - " + dt.Rows.Count.ToString(), "UnitOfMeasure", this.Name, Logger.logtype.Event, Common.LoggedLocationID);

            }
            string textForLabel = "UnitOfMeasure -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;

        }

        private int UpInvProductMaster()
        {

            DataTable dt = new DataTable();
            InvProductMasterService InvProductMasterService = new InvProductMasterService();
            //InvProductMasterService.UpdateProductDtSelect(1);
            dt = InvProductMasterService.GetAllDTProductsDataTable(getModifyDate("InvProductMaster"));
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "InvProductMaster";
                string mergeSql = CommonService.MergeSqlTo(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "InvProductMaster", mergeSql, strOutletConnection, strHOConnection);
                Logger.WriteLog("InvProductMaster" + " - " + dt.Rows.Count.ToString(), "InvProductMaster", this.Name, Logger.logtype.Event, Common.LoggedLocationID);

            }
            string textForLabel = "InvProductMaster -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;
        }


        private int UpInvProductStockMaster()
        {
            DataTable dt = new DataTable();
            InvProductMasterService InvProductMasterService = new InvProductMasterService();


            dt = InvProductMasterService.GetAllDTProductStockDataTable(getModifyDate("InvProductStockMaster"), loca);
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "InvProductStockMaster";
                string mergeSql = CommonService.MergeSqlToProductStock(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "InvProductStockMaster", mergeSql, strOutletConnection, strHOConnection);
                Logger.WriteLog("InvProductStockMaster" + " - " + dt.Rows.Count.ToString(), "InvProductStockMaster", this.Name, Logger.logtype.Event, Common.LoggedLocationID);
            }
            string textForLabel = "InvProductStockMaster -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;
        }


        private int UpCashierPermission()
        {

            DataTable dt = new DataTable();
            CashierPermissionService cashierPermissionService = new CashierPermissionService();
            //cashierPermissionService.UpdateCashierPermissionselect(0, 1);
            dt = cashierPermissionService.GetAllCashierPermissionDataTable(getModifyDate("CashierPermission"));
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "CashierPermission";
                string mergeSql = CommonService.MergeSqlTo(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "CashierPermission", mergeSql, strOutletConnection, strHOConnection);
                Logger.WriteLog("CashierPermission" + " - " + dt.Rows.Count.ToString(), "CashierPermission", this.Name, Logger.logtype.Event, Common.LoggedLocationID);
            }
            string textForLabel = "CashierPermission -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;
        }

        private int UpCashierFunction()
        {
            DataTable dt = new DataTable();
            CashierPermissionService cashierPermissionService = new CashierPermissionService();
            //cashierPermissionService.UpdateCashierFunction(0, 1);
            dt = cashierPermissionService.GetAllCashierFunctionDataTable(getModifyDate("CashierFunction"));
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "CashierFunction";
                string mergeSql = CommonService.MergeSqlTo(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "CashierFunction", mergeSql, strOutletConnection, strHOConnection);
                Logger.WriteLog(dt.TableName.ToString() + " - " + dt.Rows.Count.ToString(), "CashierFunction", this.Name, Logger.logtype.Event, Common.LoggedLocationID);
            }
            string textForLabel = "CashierFunction -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;
        }

        private int UpCustomer()
        {

            DataTable dt = new DataTable();
            CustomerService customerService = new CustomerService();
            //customerService.UpdateCustomersDT(0, 1);
            dt = customerService.GetAllCustomersDT(getModifyDate("Customer"));
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "Customer";
                string mergeSql = CommonService.MergeSqlTo(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "Customer", mergeSql, strOutletConnection, strHOConnection);
                Logger.WriteLog(dt.TableName.ToString() + " - " + dt.Rows.Count.ToString(), "Customer", this.Name, Logger.logtype.Event, Common.LoggedLocationID);
            }
            string textForLabel = "Customer -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;

        }

        private int UpSalesPerson()
        {

            DataTable dt = new DataTable();
            InvSalesPersonService invSalesPersonService = new InvSalesPersonService();
            //invSalesPersonService.UpdateSalesPersonDT(0, 1);
            dt = invSalesPersonService.GetAllSalesPersonDT(getModifyDate("SalesPerson"));
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "InvSalesPerson";
                string mergeSql = CommonService.MergeSqlTo(dt, dt.TableName.ToString());
                CommonService.BulkInsertDataSync(dt, "SalesPerson", mergeSql, strOutletConnection, strHOConnection);
                lblMsg.Text = "InvSalesPerson" + " - " + dt.Rows.Count.ToString();
                Logger.WriteLog(dt.TableName.ToString() + " - " + dt.Rows.Count.ToString(), "SalesPerson", this.Name, Logger.logtype.Event, Common.LoggedLocationID);
            }
            string textForLabel = "InvSalesPerson -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;

        }

        private int DownTrans()
        {

            DataTable dt = new DataTable();
            TransactionDet transactionDet = new TransactionDet();
            InvSalesServices invSalesServices = new InvSalesServices();
            invSalesServices.UpdateTransactiondetDT(0, 1, strOutletConnection);
            dt = invSalesServices.GetTransactionDetDT(strOutletConnection);
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "TransactionDet";
                string mergeSql = ""; // CommonService.MergeSqlTo(dt, dt.TableName.ToString());

                #region MERGE QUARY

                mergeSql = @"
                 MERGE INTO TransactionDet AS Target
                    USING #TEMP AS Source
                    ON
                     Target.[ProductCode] = Source.[ProductCode]  AND
                     Target.[UnitNo] = Source.[UnitNo]  AND
                     Target.[ZNo] = Source.[ZNo]  AND
                     Target.[Receipt] = Source.[Receipt]  AND
                     Target.[ZDate] = Source.[ZDate]  AND
                     Target.[RecDate] = Source.[RecDate]  AND
                     Target.[LocationID] = Source.[LocationID]  AND
                     Target.[RowNo] = Source.[RowNo] AND
                     Target.[DocumentID] = Source.[DocumentID]  AND
                     Target.[Status] = Source.[Status]  AND
                     Target.[TransStatus] = Source.[TransStatus]  AND
                     Target.[SaleTypeID] = Source.[SaleTypeID]  AND
                     Target.[BillTypeID] = Source.[BillTypeID]
                     WHEN MATCHED
                        THEN UPDATE
                          SET       Target.[ProductID] = Source.[ProductID],
                                    Target.[ProductCode] = Source.[ProductCode],
                                    Target.[RefCode] = Source.[RefCode],
                                    Target.[BarCodeFull] = Source.[BarCodeFull],
                                    Target.[Descrip] = Source.[Descrip],
                                    Target.[BatchNo] = Source.[BatchNo],
                                    Target.[SerialNo] = Source.[SerialNo],
                                    Target.[ExpiryDate] = Source.[ExpiryDate],
                                    Target.[Cost] = Source.[Cost],
                                    Target.[AvgCost] = Source.[AvgCost],
                                    Target.[Price] = Source.[Price],
                                    Target.[Qty] = Source.[Qty],
                                    Target.[BalanceQty] = Source.[BalanceQty],
                                    Target.[Amount] = Source.[Amount],
                                    Target.[UnitOfMeasureID] = Source.[UnitOfMeasureID],
                                    Target.[UnitOfMeasureName] = Source.[UnitOfMeasureName],
                                    Target.[ConvertFactor] = Source.[ConvertFactor],
                                    Target.[IDI1] = Source.[IDI1],
                                    Target.[IDis1] = Source.[IDis1],
                                    Target.[IDiscount1] = Source.[IDiscount1],
                                    Target.[IDI1CashierID] = Source.[IDI1CashierID],
                                    Target.[IDI2] = Source.[IDI2],
                                    Target.[IDis2] = Source.[IDis2],
                                    Target.[IDiscount2] = Source.[IDiscount2],
                                    Target.[IDI2CashierID] = Source.[IDI2CashierID],
                                    Target.[IDI3] = Source.[IDI3],
                                    Target.[IDis3] = Source.[IDis3],
                                    Target.[IDiscount3] = Source.[IDiscount3],
                                    Target.[IDI3CashierID] = Source.[IDI3CashierID],
                                    Target.[IDI4] = Source.[IDI4],
                                    Target.[IDis4] = Source.[IDis4],
                                    Target.[IDiscount4] = Source.[IDiscount4],
                                    Target.[IDI4CashierID] = Source.[IDI4CashierID],
                                    Target.[IDI5] = Source.[IDI5],
                                    Target.[IDis5] = Source.[IDis5],
                                    Target.[IDiscount5] = Source.[IDiscount5],
                                    Target.[IDI5CashierID] = Source.[IDI5CashierID],
                                    Target.[Rate] = Source.[Rate],
                                    Target.[IsSDis] = Source.[IsSDis],
                                    Target.[SDNo] = Source.[SDNo],
                                    Target.[SDID] = Source.[SDID],
                                    Target.[SDIs] = Source.[SDIs],
                                    Target.[SDiscount] = Source.[SDiscount],
                                    Target.[DDisCashierID] = Source.[DDisCashierID],
                                    Target.[Nett] = Source.[Nett],
                                    Target.[LocationID] = Source.[LocationID],
                                    Target.[DocumentID] = Source.[DocumentID],
                                    Target.[BillTypeID] = Source.[BillTypeID],
                                    Target.[SaleTypeID] = Source.[SaleTypeID],
                                    Target.[Receipt] = Source.[Receipt],
                                    Target.[SalesmanID] = Source.[SalesmanID],
                                    Target.[Salesman] = Source.[Salesman],
                                    Target.[CustomerID] = Source.[CustomerID],
                                    Target.[Customer] = Source.[Customer],
                                    Target.[CashierID] = Source.[CashierID],
                                    Target.[Cashier] = Source.[Cashier],
                                    Target.[StartTime] = Source.[StartTime],
                                    Target.[EndTime] = Source.[EndTime],
                                    Target.[RecDate] = Source.[RecDate],
                                    Target.[BaseUnitID] = Source.[BaseUnitID],
                                    Target.[UnitNo] = Source.[UnitNo],
                                    Target.[RowNo] = Source.[RowNo],
                                    Target.[IsRecall] = Source.[IsRecall],
                                    Target.[RecallNO] = Source.[RecallNO],
                                    Target.[RecallAdv] = Source.[RecallAdv],
                                    Target.[TaxAmount] = Source.[TaxAmount],
                                    Target.[IsTax] = Source.[IsTax],
                                    Target.[TaxPercentage] = Source.[TaxPercentage],
                                    Target.[IsStock] = Source.[IsStock],
                                    Target.[UpdateBy] = Source.[UpdateBy],
                                    Target.[Status] = Source.[Status],
                                    Target.[ZNo] = Source.[ZNo],
                                    Target.[GroupOfCompanyID] = Source.[GroupOfCompanyID],
                                    Target.[DataTransfer] = Source.[DataTransfer],
                                    Target.[CustomerType] = Source.[CustomerType],
                                    Target.[TransStatus] = Source.[TransStatus],
                                    Target.[ZDate] = Source.[ZDate],
                                    Target.[IsPromotionApplied] = Source.[IsPromotionApplied],
                                    Target.[PromotionID] = Source.[PromotionID],
                                    Target.[IsPromotion] = Source.[IsPromotion],
                                    Target.[LocationIDBilling] = Source.[LocationIDBilling],
                                    Target.[TableID] = Source.[TableID],
                                    Target.[OrderTerminalID] = Source.[OrderTerminalID],
                                    Target.[TicketID] = Source.[TicketID],
                                    Target.[OrderNo] = Source.[OrderNo],
                                    Target.[IsPrinted] = Source.[IsPrinted],
                                    Target.[ItemComment] = Source.[ItemComment],
                                    Target.[Packs] = Source.[Packs],
                                    Target.[IsCancelKOT] = Source.[IsCancelKOT],
                                    Target.[StewardID] = Source.[StewardID],
                                    Target.[StewardName] = Source.[StewardName],
                                    Target.[ServiceCharge] = Source.[ServiceCharge],
                                    Target.[ServiceChargeAmount] = Source.[ServiceChargeAmount],
                                    Target.[ShiftNo] = Source.[ShiftNo],
                                    Target.[IsDayEnd] = Source.[IsDayEnd],
                                    Target.[UpdateUnitNo] = Source.[UpdateUnitNo]
                    WHEN NOT MATCHED
                        THEN INSERT ( [ProductID], [ProductCode],
                                      [RefCode], [BarCodeFull], [Descrip], [BatchNo],
                                      [SerialNo], [ExpiryDate], [Cost], [AvgCost], [Price],
                                      [Qty], [BalanceQty], [Amount], [UnitOfMeasureID],
                                      [UnitOfMeasureName], [ConvertFactor], [IDI1], [IDis1],
                                      [IDiscount1], [IDI1CashierID], [IDI2], [IDis2],
                                      [IDiscount2], [IDI2CashierID], [IDI3], [IDis3],
                                      [IDiscount3], [IDI3CashierID], [IDI4], [IDis4],
                                      [IDiscount4], [IDI4CashierID], [IDI5], [IDis5],
                                      [IDiscount5], [IDI5CashierID], [Rate], [IsSDis], [SDNo],
                                      [SDID], [SDIs], [SDiscount], [DDisCashierID], [Nett],
                                      [LocationID], [DocumentID], [BillTypeID], [SaleTypeID],
                                      [Receipt], [SalesmanID], [Salesman], [CustomerID],
                                      [Customer], [CashierID], [Cashier], [StartTime],
                                      [EndTime], [RecDate], [BaseUnitID], [UnitNo], [RowNo],
                                      [IsRecall], [RecallNO], [RecallAdv], [TaxAmount],
                                      [IsTax], [TaxPercentage], [IsStock], [UpdateBy],
                                      [Status], [ZNo], [GroupOfCompanyID], [DataTransfer],
                                      [CustomerType], [TransStatus], [ZDate],
                                      [IsPromotionApplied], [PromotionID], [IsPromotion],
                                      [LocationIDBilling], [TableID], [OrderTerminalID],
                                      [TicketID], [OrderNo], [IsPrinted], [ItemComment],
                                      [Packs], [IsCancelKOT], [StewardID], [StewardName],
                                      [ServiceCharge], [ServiceChargeAmount], [ShiftNo],
                                      [IsDayEnd], [UpdateUnitNo] )
                          VALUES    ( Source.[ProductID],
                                      Source.[ProductCode], Source.[RefCode],
                                      Source.[BarCodeFull], Source.[Descrip], Source.[BatchNo],
                                      Source.[SerialNo], Source.[ExpiryDate], Source.[Cost],
                                      Source.[AvgCost], Source.[Price], Source.[Qty],
                                      Source.[BalanceQty], Source.[Amount],
                                      Source.[UnitOfMeasureID], Source.[UnitOfMeasureName],
                                      Source.[ConvertFactor], Source.[IDI1], Source.[IDis1],
                                      Source.[IDiscount1], Source.[IDI1CashierID],
                                      Source.[IDI2], Source.[IDis2], Source.[IDiscount2],
                                      Source.[IDI2CashierID], Source.[IDI3], Source.[IDis3],
                                      Source.[IDiscount3], Source.[IDI3CashierID],
                                      Source.[IDI4], Source.[IDis4], Source.[IDiscount4],
                                      Source.[IDI4CashierID], Source.[IDI5], Source.[IDis5],
                                      Source.[IDiscount5], Source.[IDI5CashierID],
                                      Source.[Rate], Source.[IsSDis], Source.[SDNo],
                                      Source.[SDID], Source.[SDIs], Source.[SDiscount],
                                      Source.[DDisCashierID], Source.[Nett],
                                      Source.[LocationID], Source.[DocumentID],
                                      Source.[BillTypeID], Source.[SaleTypeID],
                                      Source.[Receipt], Source.[SalesmanID], Source.[Salesman],
                                      Source.[CustomerID], Source.[Customer],
                                      Source.[CashierID], Source.[Cashier], Source.[StartTime],
                                      Source.[EndTime], Source.[RecDate], Source.[BaseUnitID],
                                      Source.[UnitNo], Source.[RowNo], Source.[IsRecall],
                                      Source.[RecallNO], Source.[RecallAdv],
                                      Source.[TaxAmount], Source.[IsTax],
                                      Source.[TaxPercentage], Source.[IsStock],
                                      Source.[UpdateBy], Source.[Status], Source.[ZNo],
                                      Source.[GroupOfCompanyID], Source.[DataTransfer],
                                      Source.[CustomerType], Source.[TransStatus],
                                      Source.[ZDate], Source.[IsPromotionApplied],
                                      Source.[PromotionID], Source.[IsPromotion],
                                      Source.[LocationIDBilling], Source.[TableID],
                                      Source.[OrderTerminalID], Source.[TicketID],
                                      Source.[OrderNo], Source.[IsPrinted],
                                      Source.[ItemComment], Source.[Packs],
                                      Source.[IsCancelKOT], Source.[StewardID],
                                      Source.[StewardName], Source.[ServiceCharge],
                                      Source.[ServiceChargeAmount], Source.[ShiftNo],
                                      Source.[IsDayEnd], Source.[UpdateUnitNo] ); ";

                #endregion

                CommonService.BulkInsertDataSyncPaymentTranDet(dt, "TransactionDet", mergeSql, strHOConnection, strOutletConnection);
                Logger.WriteLog(dt.TableName.ToString() + " - " + dt.Rows.Count.ToString(), "TransactionDet", this.Name, Logger.logtype.Event, Common.LoggedLocationID);

            }
            string textForLabel = "TransactionDet -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;

        }


        private int DownPay()
        {

            DataTable dt = new DataTable();
            TransactionDet transactionDet = new TransactionDet();
            InvSalesServices invSalesServices = new InvSalesServices();
            invSalesServices.UpdatePaymentDetDT(0, 1, strOutletConnection);
            dt = invSalesServices.GetPaymentDetDT(strOutletConnection);
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "PaymentDet";
                string mergeSql = ""; //CommonService.MergeSqlTo(dt, dt.TableName.ToString());

                #region MERGE QU
                mergeSql = @" MERGE INTO PaymentDet AS Target
                        USING #TEMP AS Source
                        ON
                         Target.[UnitNo] = Source.[UnitNo]  AND
                         Target.[ZNo] = Source.[ZNo]  AND
                         Target.[Receipt] = Source.[Receipt]  AND
                         Target.[ZDate] = Source.[ZDate]  AND
                         Target.[SDate] = Source.[SDate]  AND
                         Target.[LocationID] = Source.[LocationID]  AND
                         Target.[RowNo] = Source.[RowNo]
                        WHEN MATCHED
                            THEN UPDATE
                              SET       Target.[RowNo] = Source.[RowNo],
                                        Target.[PayTypeID] = Source.[PayTypeID],
                                        Target.[Amount] = Source.[Amount],
                                        Target.[Balance] = Source.[Balance],
                                        Target.[SDate] = Source.[SDate],
                                        Target.[Receipt] = Source.[Receipt],
                                        Target.[LocationID] = Source.[LocationID],
                                        Target.[CashierID] = Source.[CashierID],
                                        Target.[UnitNo] = Source.[UnitNo],
                                        Target.[BillTypeID] = Source.[BillTypeID],
                                        Target.[SaleTypeID] = Source.[SaleTypeID],
                                        Target.[RefNo] = Source.[RefNo],
                                        Target.[BankId] = Source.[BankId],
                                        Target.[ChequeDate] = Source.[ChequeDate],
                                        Target.[IsRecallAdv] = Source.[IsRecallAdv],
                                        Target.[RecallNo] = Source.[RecallNo],
                                        Target.[Descrip] = Source.[Descrip],
                                        Target.[EnCodeName] = Source.[EnCodeName],
                                        Target.[UpdatedBy] = Source.[UpdatedBy],
                                        Target.[Status] = Source.[Status],
                                        Target.[ZNo] = Source.[ZNo],
                                        Target.[CustomerId] = Source.[CustomerId],
                                        Target.[CustomerType] = Source.[CustomerType],
                                        Target.[CustomerCode] = Source.[CustomerCode],
                                        Target.[GroupOfCompanyID] = Source.[GroupOfCompanyID],
                                        Target.[Datatransfer] = Source.[Datatransfer],
                                        Target.[ZDate] = Source.[ZDate],
                                        Target.[TerminalID] = Source.[TerminalID],
                                        Target.[LoyaltyType] = Source.[LoyaltyType],
                                        Target.[IsUploadToGL] = Source.[IsUploadToGL],
                                        Target.[LocationIDBilling] = Source.[LocationIDBilling],
                                        Target.[TableID] = Source.[TableID],
                                        Target.[TicketID] = Source.[TicketID],
                                        Target.[OrderNo] = Source.[OrderNo],
                                        Target.[ShiftNo] = Source.[ShiftNo],
                                        Target.[IsDayEnd] = Source.[IsDayEnd],
                                        Target.[UpdateUnitNo] = Source.[UpdateUnitNo]
                        WHEN NOT MATCHED
                            THEN INSERT ( [RowNo], [PayTypeID], [Amount],
                                          [Balance], [SDate], [Receipt], [LocationID], [CashierID],
                                          [UnitNo], [BillTypeID], [SaleTypeID], [RefNo], [BankId],
                                          [ChequeDate], [IsRecallAdv], [RecallNo], [Descrip],
                                          [EnCodeName], [UpdatedBy], [Status], [ZNo], [CustomerId],
                                          [CustomerType], [CustomerCode], [GroupOfCompanyID],
                                          [Datatransfer], [ZDate], [TerminalID], [LoyaltyType],
                                          [IsUploadToGL], [LocationIDBilling], [TableID],
                                          [TicketID], [OrderNo], [ShiftNo], [IsDayEnd],
                                          [UpdateUnitNo] )
                              VALUES    ( Source.[RowNo],
                                          Source.[PayTypeID], Source.[Amount], Source.[Balance],
                                          Source.[SDate], Source.[Receipt], Source.[LocationID],
                                          Source.[CashierID], Source.[UnitNo], Source.[BillTypeID],
                                          Source.[SaleTypeID], Source.[RefNo], Source.[BankId],
                                          Source.[ChequeDate], Source.[IsRecallAdv],
                                          Source.[RecallNo], Source.[Descrip], Source.[EnCodeName],
                                          Source.[UpdatedBy], Source.[Status], Source.[ZNo],
                                          Source.[CustomerId], Source.[CustomerType],
                                          Source.[CustomerCode], Source.[GroupOfCompanyID],
                                          Source.[Datatransfer], Source.[ZDate],
                                          Source.[TerminalID], Source.[LoyaltyType],
                                          Source.[IsUploadToGL], Source.[LocationIDBilling],
                                          Source.[TableID], Source.[TicketID], Source.[OrderNo],
                                          Source.[ShiftNo], Source.[IsDayEnd],
                                          Source.[UpdateUnitNo] );
                      ";
                #endregion
                CommonService.BulkInsertDataSyncPaymentDet(dt, "PaymentDet", mergeSql, strHOConnection, strOutletConnection);
                Logger.WriteLog(dt.TableName.ToString() + " - " + dt.Rows.Count.ToString(), "PaymentDet", this.Name, Logger.logtype.Event, Common.LoggedLocationID);

            }
            string textForLabel = "PaymentDet -" + dt.Rows.Count.ToString();
            lblMsg.SafeInvoke(d => d.Text = textForLabel);
            return dt.Rows.Count;

        }

        void bgUp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void frmDTS_Load(object sender, EventArgs e)
        {
            try
            {
                Thread.Sleep(10000);


            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            if (!myWorker.IsBusy)//Check if the worker is already in progress
            {
                btnUp.Enabled = false;//Disable the Start button
                myWorker.RunWorkerAsync();//Call the background worker
            }
        }

        private void frmDTS_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            strHOConnection = ConfigurationManager.ConnectionStrings["SysConn"].ToString();

            strOutletConnection = ConfigurationManager.ConnectionStrings["OutCon"].ToString();

            SqlConnection myConn = new SqlConnection(strHOConnection);
            try
            {
                myConn.Open();
                if (myConn.State != ConnectionState.Open)
                {
                    lblConnection.ForeColor = Color.Red;
                    lblConnection.Text = "HeadOffice Connection Fail";
                    timer1.Enabled = false;
                    return;
                }

                if (myConn.State == ConnectionState.Open)
                {
                    lblConnection.ForeColor = Color.Green;
                    lblConnection.Text = "HeadOffice Connection Ok";
                    timer1.Enabled = true;
                    pictureBox1.Visible = true;

                }
            }
            catch
            {
                lblConnection.ForeColor = Color.Red;
                lblConnection.Text = "HeadOffice Connection Fail";
                return;
            }



            myConn = new SqlConnection(strOutletConnection);
            try
            {
                myConn.Open();
                if (myConn.State != ConnectionState.Open)
                {
                    lblConnection.ForeColor = Color.Red;
                    lblConnection.Text = "Outlet Connection Fail";
                    return;
                }

                if (myConn.State == ConnectionState.Open)
                {
                    lblConnection.ForeColor = Color.Green;
                    lblConnection.Text = lblConnection.Text + " And Outlet Connection Ok";
                    timer1.Enabled = true;
                    pictureBox1.Visible = true;
                }
            }
            catch
            {
                lblConnection.ForeColor = Color.Red;
                lblConnection.Text = "Outlet Connection Fail";
                return;
            }
        }
    }
}
