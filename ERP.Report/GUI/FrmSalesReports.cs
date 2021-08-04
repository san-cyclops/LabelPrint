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
using ERP.Report.Logistic;
using ERP.Service;
using ERP.Domain;
using ERP.UI.Windows;
using ERP.UI.Windows.Reports;
using ERP.Utility;
using System.Collections;
using ERP.Report.Inventory;
using System.Reflection;
using ERP.Report.Inventory.Transactions.Reports;
using ERP.Report.GUI;
using ERP.Report.Inventory.Reference.Reports;

namespace ERP.Report.GUI
{
    public partial class FrmSalesReports : FrmBaseReportsForm
    {
        int documentID = 0;
        bool isValidControls = true;
        UserPrivileges accessRights = new UserPrivileges();
        private GroupBox groupBox1;
        private DateTimePicker dtpToDate;
        private DateTimePicker dtpFromDate;
        private Label lblDateRange;
        private Label label5;
        private GroupBox gbFieldSelection;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private Label label1;
        private GroupBox groupBox2;
        private CheckedListBox chkLstSlab;
        private CheckBox chkAllSlab;
        List<Common.CheckedListBoxSelection> locationList = new List<Common.CheckedListBoxSelection>();
        string[] locationNames;
        BinCardService binCardService = new BinCardService();
        private CheckedListBox chkLstLocations;
        private CheckBox chkLocation;
        long[] arrLocationIds;

        public FrmSalesReports()
        {
            InitializeComponent();
        }
        private void LoadAllLocations()
        {
            try
            {
                //LocationService locationService = new LocationService();
                //List<Location> locations = new List<Location>();

                //locations = locationService.GetAllLocations();
                //dgvLocation.DataSource = locations;
                //dgvLocation.Refresh();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }

        }
        public override void FormLoad()
        {
            try
            {
                //dgvLocation.AutoGenerateColumns = false;
                //dgvLocation.AllowUserToAddRows = false;
                //dgvLocation.AllowUserToDeleteRows = false;

                LoadAllLocations();


                AutoGenerateInfo autoGenerateInfo = new AutoGenerateInfo();
                autoGenerateInfo = AutoGenerateInfoService.GetAutoGenerateInfoByForm(this.Name);
                this.Text = autoGenerateInfo.FormText;
                documentID = autoGenerateInfo.DocumentID;
                //accessRights = CommonService.GetUserPrivilegesByUserIDandLocation(Common.LoggedUserId, Common.LoggedLocationID, documentID);
                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();

                for (int i = 0; i < chkLstSlab.Items.Count; i++)
                {
                    chkLstSlab.SetSelected(i, true);
                }

                LocationService locationService = new LocationService();
                locationList = CreateSelectionList(locationService.GetAllInventoryLocationNames());
                locationNames = locationService.GetAllInventoryLocationNames();

                // Location
                Common.LoadItemsToCheckListt<Common.CheckedListBoxSelection>(chkLstLocations, locationList, "", "");

                base.FormLoad();
            }
            catch (Exception ex)
            { Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID); }
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
        

        public override void ClearForm()
        {
            try
            {
                base.ClearForm();

                
                dtpFromDate.Value = Common.GetSystemDate();
                dtpToDate.Value = Common.GetSystemDate();

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }

        }

        private DataTable GetLocations()
        {
            DataTable dtLocations = new DataTable();
            dtLocations.Columns.Add("LocationID", typeof(int));

              if (locationList.Any(l => l.isChecked.Equals(CheckState.Checked)))
                {
                    LocationService locationService = new LocationService();
                    foreach (var item in locationList.Where(l => l.isChecked.Equals(CheckState.Checked)))
                    {
                        dtLocations.Rows.Add(locationService.GetLocationsByName(item.Value.Trim()).LocationID);
                    }
                }
           

            DataView dvLocations = dtLocations.DefaultView;
            dvLocations.Sort = "LocationID ASC";
            return dvLocations.ToTable();
        }
       
        public override void View()
        {
            try
            {
                FrmReportViewer objReportView = new FrmReportViewer();
                Cursor.Current = Cursors.WaitCursor;
                string ReportName = string.Empty;
                InvReportService invreportService = new InvReportService();

                DataTable dt = new DataTable();
                dt.TableName = "Slab";
                dt.Clear();
                dt.Columns.Add("SlabName");
                foreach (string  val in chkLstSlab.CheckedItems)
                {
                    DataRow _ravi = dt.NewRow();
                    _ravi["SlabName"] = val;
                    dt.Rows.Add(_ravi);
                }
                DataTable dtLocations = GetLocations();

                if (invreportService.getHourlySales(Common.LoggedUserId, dt, dtpFrom.Value, dtpTo.Value, dtLocations))
                {
                    InvRptHourlySales invRptHourlySales = new InvRptHourlySales();

                    invRptHourlySales.SetDataSource(invreportService.getHourlySalesData());



                    invRptHourlySales.SummaryInfo.ReportTitle = "Hourly Sales Report";
                    invRptHourlySales.SummaryInfo.ReportAuthor = Common.AuthorName + "  " + Common.AuthorAddress;

                    invRptHourlySales.DataDefinition.FormulaFields["User"].Text = "'" + Common.LoggedUser + "'";
                    invRptHourlySales.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpFromDate.Value + "'";
                    invRptHourlySales.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpToDate.Value + "'";

                    invRptHourlySales.DataDefinition.FormulaFields["LogingUser"].Text = "'" + Common.LoggedUser.ToString() + "'";
                    invRptHourlySales.DataDefinition.FormulaFields["LogingLocation"].Text = "'" + Common.LoggedLocationName + "'";
                    invRptHourlySales.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.LoggedCompanyName + "'";
                    invRptHourlySales.DataDefinition.FormulaFields["Address"].Text = "'" + Common.LoggedCompanyAddress + "'";

                    objReportView.crRptViewer.ReportSource = invRptHourlySales;
                    objReportView.WindowState = FormWindowState.Maximized;
                    objReportView.Show();

                }
                else
                {
                    Toast.Show(this.Name, "","Report View Error ..", Toast.messageType.Error, Toast.messageAction.General);
                }
               
                Cursor.Current = Cursors.Default;
                  
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;

                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.gbFieldSelection = new System.Windows.Forms.GroupBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkLstSlab = new System.Windows.Forms.CheckedListBox();
            this.chkAllSlab = new System.Windows.Forms.CheckBox();
            this.chkLstLocations = new System.Windows.Forms.CheckedListBox();
            this.chkLocation = new System.Windows.Forms.CheckBox();
            this.grpButtonSet2.SuspendLayout();
            this.grpButtonSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbFieldSelection.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtonSet2
            // 
            this.grpButtonSet2.Location = new System.Drawing.Point(584, 497);
            this.grpButtonSet2.Size = new System.Drawing.Size(236, 46);
            // 
            // grpButtonSet
            // 
            this.grpButtonSet.Location = new System.Drawing.Point(2, 497);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.lblDateRange);
            this.groupBox1.Location = new System.Drawing.Point(2, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(823, 325);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 124;
            this.label5.Text = "-";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(296, 20);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(149, 20);
            this.dtpToDate.TabIndex = 113;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(123, 20);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(149, 20);
            this.dtpFromDate.TabIndex = 96;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(10, 26);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(65, 13);
            this.lblDateRange.TabIndex = 95;
            this.lblDateRange.Text = "Date Range";
            // 
            // gbFieldSelection
            // 
            this.gbFieldSelection.Controls.Add(this.chkLstLocations);
            this.gbFieldSelection.Location = new System.Drawing.Point(12, 89);
            this.gbFieldSelection.Name = "gbFieldSelection";
            this.gbFieldSelection.Size = new System.Drawing.Size(410, 409);
            this.gbFieldSelection.TabIndex = 21;
            this.gbFieldSelection.TabStop = false;
            this.gbFieldSelection.Text = "Select Locations";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(276, 30);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(133, 21);
            this.dtpTo.TabIndex = 119;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(122, 30);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(133, 21);
            this.dtpFrom.TabIndex = 118;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 117;
            this.label1.Text = "Date Range";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkLstSlab);
            this.groupBox2.Location = new System.Drawing.Point(428, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 409);
            this.groupBox2.TabIndex = 120;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Slab";
            // 
            // chkLstSlab
            // 
            this.chkLstSlab.CheckOnClick = true;
            this.chkLstSlab.ColumnWidth = 250;
            this.chkLstSlab.FormattingEnabled = true;
            this.chkLstSlab.Items.AddRange(new object[] {
            "06:00-07:00",
            "07:00-08:00",
            "08:00-09:00",
            "09:00-10:00",
            "10:00-11:00",
            "11:00-12:00",
            "12:00-13:00",
            "13:00-14:00",
            "14:00-15:00",
            "15:00-16:00",
            "16:00-17:00",
            "17:00-18:00",
            "18:00-19:00",
            "19:00-20:00",
            "20:00-21:00",
            "21:00-22:00",
            "22:00-23:00",
            "23:00-00:00",
            "00:00-01:00",
            "01:00-02:00",
            "02:00-03:00",
            "03:00-04:00",
            "04:00-05:00",
            "05:00-06:00"});
            this.chkLstSlab.Location = new System.Drawing.Point(11, 17);
            this.chkLstSlab.MultiColumn = true;
            this.chkLstSlab.Name = "chkLstSlab";
            this.chkLstSlab.Size = new System.Drawing.Size(363, 388);
            this.chkLstSlab.TabIndex = 13;
            // 
            // chkAllSlab
            // 
            this.chkAllSlab.AutoSize = true;
            this.chkAllSlab.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllSlab.Location = new System.Drawing.Point(433, 66);
            this.chkAllSlab.Name = "chkAllSlab";
            this.chkAllSlab.Size = new System.Drawing.Size(69, 17);
            this.chkAllSlab.TabIndex = 121;
            this.chkAllSlab.Text = "All Slab";
            this.chkAllSlab.UseVisualStyleBackColor = true;
            this.chkAllSlab.CheckedChanged += new System.EventHandler(this.chkAllSlab_CheckedChanged);
            // 
            // chkLstLocations
            // 
            this.chkLstLocations.CheckOnClick = true;
            this.chkLstLocations.FormattingEnabled = true;
            this.chkLstLocations.Location = new System.Drawing.Point(9, 17);
            this.chkLstLocations.Name = "chkLstLocations";
            this.chkLstLocations.Size = new System.Drawing.Size(401, 388);
            this.chkLstLocations.TabIndex = 13;
            this.chkLstLocations.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstLocations_ItemCheck);
            // 
            // chkLocation
            // 
            this.chkLocation.AutoSize = true;
            this.chkLocation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLocation.Location = new System.Drawing.Point(21, 66);
            this.chkLocation.Name = "chkLocation";
            this.chkLocation.Size = new System.Drawing.Size(91, 17);
            this.chkLocation.TabIndex = 122;
            this.chkLocation.Text = "All Location";
            this.chkLocation.UseVisualStyleBackColor = true;
            this.chkLocation.Visible = false;
            this.chkLocation.CheckedChanged += new System.EventHandler(this.chkLocation_CheckedChanged);
            // 
            // FrmSalesReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(818, 543);
            this.Controls.Add(this.chkLocation);
            this.Controls.Add(this.chkAllSlab);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbFieldSelection);
            this.Name = "FrmSalesReports";
            this.Controls.SetChildIndex(this.gbFieldSelection, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpFrom, 0);
            this.Controls.SetChildIndex(this.dtpTo, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.chkAllSlab, 0);
            this.Controls.SetChildIndex(this.chkLocation, 0);
            this.Controls.SetChildIndex(this.grpButtonSet, 0);
            this.Controls.SetChildIndex(this.grpButtonSet2, 0);
            this.grpButtonSet2.ResumeLayout(false);
            this.grpButtonSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFieldSelection.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void chkAllSlab_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllSlab.Checked == true)
            {
                for (int x = 0; x < chkLstSlab.Items.Count; x++)
                {
                    chkLstSlab.SetItemChecked(x, true);
                }
            }
            else
            {
                for (int x = 0; x < chkLstSlab.Items.Count; x++)
                {
                    chkLstSlab.SetItemChecked(x, false);
                }
            }
        }

        private void chkLocation_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkLocation.Checked)
            //    CheckedGrdCheckBox(dgvLocation, "LocationAllow", true);
            //else
            //    CheckedGrdCheckBox(dgvLocation, "LocationAllow", false);
        }


        private void CheckedGrdCheckBox(DataGridView c, string checkstr, bool status)
        {
            for (int i = 0; i < c.RowCount; i++)
            {
                c.Rows[i].Cells[checkstr].Value = status;
            }


        }

        private void chkLstLocations_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                var item = (CheckedListBox)sender;
                SetItemCheckedStatus(locationList, item.SelectedItem.ToString().Trim(), e.CurrentValue.Equals(CheckState.Checked) ? CheckState.Unchecked : CheckState.Checked);
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
    }
}
