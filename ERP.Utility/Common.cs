using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Data.Entity;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Net.NetworkInformation;
using System.Globalization;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.ComponentModel;

//using ERP.

namespace ERP.Utility
{
    public static class Common
    {

        // Data Structure for Report Fileds, Filed Names and Data types
        public struct ReportDataStruct
        {
            public string ReportField; // Ex :- FieldString1 (Report value field)
            public string ReportFieldName; // Ex :- Document No (Report text field)
            public object ReportDataType; // Ex :- string (Report value field data type)
            public string DbColumnName; // Ex :- DocumentNo (Column name of the data base table)
            public string DbJoinColumnName; // Ex :- DocumentNo (Join Column name of the data base table)
            public object DbJoinTableName; // Ex :- DocumentNo (Joined Table name of the data base table)
            public object ValueDataType; // Ex :- string (C# data type)
            public bool IsSelectionField;  // Ex :- DocumentNo (Fields to be loaded into field selection grid in report generater form )
            public bool IsConditionField;  // Ex :- DocumentNo (Fields to be loaded into field selection grid in report generater form )
            public bool IsGroupBy; // Ex :- Supplier Code (Fields to be loaded into Group by grid in report generater form )
            public bool IsColumnTotal;// Ex :- Net Amount (Fields to be loaded into Column total grid in report generater form )
            public bool IsRowTotal;// Ex :- Net Amount (Fields to be loaded into Raw total grid in report generater form )
            public bool IsJoinField; // Ex :- SupplierID
            public bool IsConditionNameJoined; // Ex :- (Fields to be loaded into conditions using Join Column Name of the data base table)
            public bool IsResultGroupBy;  // Ex :- DocumentNo (Selected Groupby field for Report)
            public bool IsRecordFilterByGivenOption; // Ex :- (allow to enter field for record searching or not)
            public bool IsManualRecordFilter; // Ex :- (Allow to select records based on manual entered record )
            public bool IsResultOrderBy;  // Ex :- DocumentNo (Selected Orderby field for Report)
            public bool IsMandatoryField; // Ex :- Codes of master data (Department Code of departments)
            public bool IsUntickedField; // Ex :- User entered Fields/default untick fields (Stock Entry field of Product Master)
            public bool IsUnAuthorized; // Ex :- Display cost prices of products only for authorized users
            public bool IsRecordFilterByOneOption; // Ex :- (allow to enter only one field)
            public bool IsUncheckable; // Ex :- Users cant check these fields
            public bool IsComparisonField; // Ex :- Document Date (Arrange two date ranges of same data)
            public string ComparisonFieldNamePortion; // Ex :- Document Date (Compare with)
            public bool IsNotDisplayedOnGrid; // Ex :- Invisible from Data GRID
            public bool IsManualGroupBy; // Ex :- (Apply auto grouping)
            public bool IsManualOrderBy; // Ex :- (Apply auto Ordering)
            public bool IsNotDisplayedOrderBy; // Ex :- (Apply auto Ordering)
            public bool IsDetailView;
        }

        // Data structure for report conditions
        public struct ReportConditionsDataStruct
        {
            public ReportDataStruct ReportDataStruct;
            public string ConditionFrom;
            public string ConditionTo;
        }

        // class for CheckedListBox selection
        public class CheckedListBoxSelection
        {
            public string Value;
            public CheckState isChecked;
        }

        //If add property pls apply changes for Method, other related places
        public struct ModuleTypes
        {
            public static bool InventoryAndSales;
            public static bool PointOfSales;
            public static bool Manufacture;
            public static bool HirePurchase;
            public static bool CustomerRelationshipModule;
            public static bool GiftVouchers;
            public static bool Accounts;
            public static bool NonTrading;
            public static bool HrManagement;
            public static bool HospitalManagement;
            public static bool ApparelManufacture;
            public static bool DashBoard;
            public static bool FixedAsset;
            public static bool RestaurantManagement;
        }

        public struct ModuleFeatureTypes
        {
            public static bool AccountFeaturesOnly;
        }

        public struct ModuleTypeName
        {
            public static string InventoryAndSales = "InventoryAndSales";
            public static string PointOfSales = "PointOfSales";
            public static string Manufacture = "Manufacture";
            public static string HirePurchase = "HirePurchase";
            public static string CustomerRelationshipModule = "CustomerRelationshipModule";
            public static string GiftVouchers = "GiftVouchers";
            public static string Accounts = "Accounts";
            public static string NonTrading = "NonTrading";
            public static string HrManagement = "HrManagement";
            public static string HospitalManagement = "HospitalManagement";
            public static string ApparelManufacture = "ApparelManufacture";
            public static string DashBoard = "DashBoard";
            public static string FixedAsset = "FixedAsset";
            public static string RestaurantManagement = "RestaurantManagement";
        }


        public struct ModuleTypeNumber
        {
            public static int Common = 1;
            public static int InventoryAndSales = 2;
            public static int PointOfSales = 7;
            public static int Manufacture = 12;
            public static int HirePurchase = 13;
            public static int CustomerRelationshipModule = 4;
            public static int GiftVouchers = 6;
            public static int Accounts = 5;
            public static int NonTrading = 3;
            public static int HrManagement = 14;
            public static int HospitalManagement = 10;
            public static int ApparelManufacture = 11;
            public static int DashBoard = 9;
            public static int FixedAsset = 16;
            public static int RestaurantManagement = 15;
        }

        public struct KeyFunctions
        {
            public static Keys DeleteGridItemF2 = Keys.F2;
            public static Keys SearchGridF3 = Keys.F3;
            public static Keys DisplayReferenceDocumentF4 = Keys.F4;
        }

        public static string GetModuleTypesText(string moduleType)
        {
            switch (moduleType.ToString())
            {
                case "InventoryAndSales": //Inv
                    return "Inventory And Sales";
                case "PointOfSales":
                    return "Point Of Sales";
                case "Manufacture":
                    return "Manufacture";
                case "HirePurchase":
                    return "HirePurchase";
                case "CustomerRelationshipModule": //crm
                    return "Customer Relationship";
                case "GiftVouchers":
                    return "GiftVouchers";
                case "Accounts": //Acc
                    return "Accounts";
                case "NonTrading":
                    return "Non Trading";
                case "HrManagement": //hrm
                    return "Hr Management";
                case "HospitalManagement": //Hsp
                    return "Hospital Management";
                case "RestaurantManagement":
                    return "Restaurant Management";
                case "ApparelManufacture": //apm
                    return "Apparel Manufacture";
                case "DashBoard":
                    return "DashBoard";
                case "FixedAsset":
                    return "Fixed Asset";
                default:
                    return "";
            }
        }

        public struct ReferenceCardTypeIDs
        {
            public static int Supplier;
            public static int Customer;
            public static int LoyaltyCustomer;
            public static int LogisticSupplier;
            public static int Employee;
        }

        public enum ComparisonResutType
        {
            OnlyNonCompared = 1,
            OnlyCompared = 2,
            Compared = 3
        }

        public enum AccountTransactionType
        {
            Receipt = 1,
            Payment = 2
        }

        public enum BankDepositMode
        {
            Cheque = 1,
            Cash = 2
        }

        //// Data Structure for Cheque Return Filter Condition
        //public struct ChequeReturnFilterCondition
        //{
        //    public object DataType;
        //    public string DbColumnName; // Ex :- DocumentNo (Column name of the data base table)
        //    public bool IsSelectionField;  // Ex :- DocumentNo (Fields to be loaded into field selection grid in report generater form )
        //}


        #region Pre Initialization Based On Client

        public static int GiftVoucherSerialLength = 0;

        public static int GiftVoucherCoupanSerialLength = 8;

        public static byte decimalPointsCurrency = 2;
        public static byte decimalPointsQty = 3;
        public static int decimalPointsNumeric = 2;

        public static string defaultBatch = "*DEFAULT_BATCH*";
        public static bool IsSearchFormOpened;


        public static void SetPreInitializeFeature(int systemProductId)
        {
            switch (systemProductId)
            {
                case 1: // Company :1
                    GiftVoucherSerialLength = 8;
                    break;
                case 2: // Company :2 MANJARI
                    GiftVoucherSerialLength = 8;
                    break;

                default:
                    break;
            }
        }

        #endregion

        public static int CharacterLengthChequeNo = 6;
        //public static Color GridBackColor = Color.FromArgb(0, 192, 192);
        public static Color GridBackColor = Color.LightGray;
        public static bool tStatus = false;
        public static bool isHeadOffice;

        public static int GroupOfCompanyID;
        public static string GroupOfCompanyName;
        public static int SystemProductID;
        public static string LoggedUser;
        public static long LoggedUserId;
        public static int LoggedLocationID;
        public static string LoggedLocationCode;
        public static string LoggedLocationName;
        public static int LoggedCompanyID;
        public static string Version = "1.4.0.0";  // sanjeewa
        public static string LastBuildDate = "01-02-2015";  // sanjeewa
        public static string LoggedCompanyName;
        public static string LoggedCompanyAddress;
        public static int EntryLevel;
        public static bool IsMultyCurrency;
        public static bool IsBatch;
        public static string LoggedPcName;
        public static long UserGroupID;
        public static string Connection = "SysConn";
        public static bool IsTransactionEntryDefendOnLocation = false; //?
        public static string CurrenyCode;
        public static string CurrenyFormat;
        public static decimal CurrenyRate;
        public static int DefaultCurrenyID;
        public static bool IsAvailabledGRNPayment = false;
        public static bool AllowMinusStock;
        public static int cardNoLength = 12;
        public static int encodeNoLength = 7;

        public static string DepartmentName = "";
        public static string CategoryName = "";
        public static string SubCategoryName = "";
        public static string SubCategory2Name = "";

        public static bool isDependDepartment = false;
        public static bool isDependCategory = false;
        public static bool isDependSubCategory = false;
        public static bool isDependSubCategory2 = false;


        public static string AuthorName = "ERP SYSTEM.";
        public static string AuthorAddress = "# Colombo ";
        public static string DateFormat = "dd/MM/yyyy";

        /// <summary>
        /// To convert numbers to it's verbal format
        /// </summary>
        static string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        static string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        static string[] thou = { "", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion" };


        #region Clear
        #region ClearForm

        public static void ClearForm(Control control)
        {

            string a;
            foreach (Control c in control.Controls)
            {

                if (!c.HasChildren)
                {

                    if (c.Tag == null || c.Tag.ToString().Equals("3") || c.Tag.ToString().Trim().Equals(string.Empty))
                    {

                        if (c is TextBox)
                        {


                            ((TextBox)c).Clear();
                        }

                        if (c is CheckBox)
                        {


                            ((CheckBox)c).Checked = false;
                        }

                        if (c is RadioButton)
                        {


                            ((RadioButton)c).Checked = false;
                        }

                        if (c is ComboBox)
                        {

                            {
                                if (!((ComboBox)c).SelectedIndex.Equals(-1))
                                    ((ComboBox)c).SelectedIndex = 0;
                                //if (!((ComboBox)c).Text.Trim().Equals(string.Empty))
                                ((ComboBox)c).Text = string.Empty;


                            }
                        }

                        if (c is DataGridView)
                        {


                            ((DataGridView)c).DataSource = null;
                            ((DataGridView)c).Refresh();
                        }
                    }
                }
                else
                    ClearForm(c);

            }

        }

        public static void ClearForm(Control control, Control excludeControl)
        {


            foreach (Control c in control.Controls)
            {

                if (!c.HasChildren)
                {
                    if (c != excludeControl)
                    {
                        if ((c.Tag == null || c.Tag.ToString().Equals("3") || c.Tag.ToString().Trim().Equals(string.Empty)))
                        {

                            if (c is TextBox)
                            {


                                ((TextBox)c).Clear();
                            }

                            if (c is CheckBox)
                            {


                                ((CheckBox)c).Checked = false;
                            }

                            if (c is RadioButton)
                            {


                                ((RadioButton)c).Checked = false;
                            }

                            if (c is ComboBox)
                            {

                                {
                                    if (!((ComboBox)c).SelectedIndex.Equals(-1))
                                        ((ComboBox)c).SelectedIndex = 0;
                                    ((ComboBox)c).Text = string.Empty;


                                }
                            }

                            if (c is DataGridView)
                            {


                                ((DataGridView)c).DataSource = null;
                                ((DataGridView)c).Refresh();
                            }
                        }

                    }

                }

                else
                    ClearForm(c);

            }

        }

        #endregion

        #region ClearTextBox

        public static void ClearTextBox(params TextBox[] textBox)
        {
            foreach (TextBox TBox in textBox)
                TBox.Text = string.Empty;
        }

        #endregion

        #region ClearComboBox

        public static void ClearComboBox(params ComboBox[] comboBox)
        {
            foreach (ComboBox CBox in comboBox)
                if (CBox.DropDownStyle.Equals(ComboBoxStyle.DropDownList))
                {
                    CBox.SelectedIndex = -1;
                }
                else
                {
                    CBox.Text = string.Empty;
                }
        }

        #endregion

        #region ClearCheckBox

        public static void ClearCheckBox(params CheckBox[] checkBox)
        {
            foreach (CheckBox ChBox in checkBox)
                ChBox.Checked = false;
        }

        #endregion

        #region Reset Datetime pickers of the given form to current Datetime
        /// <summary>
        /// Reset Datetime pickers of the given form to current Datetime
        /// </summary>
        /// <param name="control"></param>
        public static void ResetDates(Control control)
        {
            foreach (var pb in control.Controls.OfType<DateTimePicker>())
            {
                pb.Value = DateTime.Now;
            }
        }

        #endregion

        #endregion

        #region Enable
        #region EnableButton

        public static void EnableButton(bool enable, params Button[] button)
        {

            foreach (Button b in button)
                b.Enabled = enable;
        }

        #endregion

        #region EnableTextBox

        public static void EnableTextBox(bool enable, params TextBox[] textBox)
        {
            foreach (TextBox t in textBox)
                t.Enabled = enable;
        }

        #endregion

        #region EnableComboBox

        public static void EnableComboBox(bool enable, params ComboBox[] comboBox)
        {
            foreach (ComboBox c in comboBox)
                c.Enabled = enable;
        }
        #endregion

        #region EnableCheckBox

        public static void EnableCheckBox(bool enable, params CheckBox[] checkox)
        {
            foreach (CheckBox c in checkox)
                c.Enabled = enable;
        }

        #endregion
        #endregion

        #region Visible
        #region VisibleTexBox

        public static void VisibleTextBox(bool visible, params TextBox[] textBox)
        {

            foreach (TextBox t in textBox)
                t.Visible = visible;
        }

        #endregion

        # region VisibleLable
        public static void VisibleLable(bool visible, params Label[] label)
        {

            foreach (Label l in label)
                l.Visible = visible;
        }
        #endregion

        #region VisibleHeaderText

        public static void VisibleDataGridViewColumn(bool visible, params DataGridViewColumn[] dataGridViewColumn)
        {

            foreach (DataGridViewColumn h in dataGridViewColumn)
                h.Visible = visible;
        }

        #endregion

        #endregion

        #region Conversion

        #region ConvertStringToInt

        public static int ConvertStringToInt(string Value)
        {
            try
            {
                return (Value.Trim() != string.Empty ? int.Parse(Value) : 0);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion

        #region ConvertStringToBool

        public static bool ConvertStringToBool(string Value)
        {
            try
            {
                return (Value.Trim() != string.Empty ? bool.Parse(Value) : false);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region ConvertStringToDecimal

        public static decimal ConvertStringToDecimal(string Value)
        {
            try
            {
                if (Value == null)
                    Value = "0";
                return (Value.Trim() != string.Empty ? Convert.ToDecimal(Value) : 0);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion

        #region ConvertDecimalToStringCurrency

        public static string ConvertDecimalToStringCurrency(decimal Value)
        {
            try
            {
                if (Value == null)
                    Value = 0;

                return String.Format("{0:N" + Math.Abs(decimalPointsCurrency) + "}", Value);
            }
            catch (Exception ex)
            {
                return String.Format("{0:N" + Math.Abs(decimalPointsCurrency) + "}", 0);
            }
        }

        #endregion

        #region ConvertDecimalToStringQty

        public static string ConvertDecimalToStringQty(decimal Value)
        {
            try
            {
                if (Value == null)
                    Value = 0;

                return String.Format("{0:N" + Math.Abs(decimalPointsQty) + "}", Value);
            }
            catch (Exception ex)
            {
                return String.Format("{0:N" + Math.Abs(decimalPointsQty) + "}", 0);
            }
        }

        #endregion

        #region ConvertDecimalToDecimalQty

        public static decimal ConvertDecimalToDecimalQty(decimal Value)
        {
            try
            {
                if (Value == null)
                    Value = 0;

                return Math.Round(Value, Math.Abs(decimalPointsQty));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion

        #region ConvertStringToDecimalCurrency

        public static decimal ConvertStringToDecimalCurrency(string Value)
        {
            try
            {
                if (Value == null)
                    Value = "0";
                return Math.Round((Value.Trim() != string.Empty ? Convert.ToDecimal(Value) : 0), decimalPointsCurrency);
            }
            catch (Exception ex)
            {
                return 0;

            }
        }



        #endregion

        #region ConvertStringToDecimalQty
        public static decimal ConvertStringToDecimalQty(string Value)
        {
            try
            {
                if (Value == null)
                    Value = "0";
                return Math.Round((Value.Trim() != string.Empty ? Convert.ToDecimal(Value) : 0), decimalPointsQty);


            }
            catch (Exception ex)
            {
                return 0;

            }
        }
        #endregion

        #region ConvertStringToLong

        public static long ConvertStringToLong(string Value)
        {
            try
            {

                return (long)(Value.Trim() != string.Empty ? Convert.ToDouble(Value) : 0);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion

        #region ConvertStringToDateTime

        public static DateTime ConvertStringToDateTime(string Value)
        {
            try
            {

                return (DateTime)(Value.Trim() != string.Empty ? Convert.ToDateTime(Value) : DateTime.Now);
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }



        #endregion

        #region ConvertStringToDate

        public static DateTime ConvertStringToDate(string Value)
        {
            try
            {

                return (DateTime)(Value.Trim() != string.Empty ? Convert.ToDateTime(Value).Date : DateTime.Now);
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }

        public static DateTime ConvertDateTimeToDate(DateTime Value)
        {
            try
            {

                return (DateTime)(Convert.ToDateTime(Value).Date);
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }

        #endregion

        #region ConvertIntToString

        //public static int ConvertIntToString(int Value)
        //{
        //    try
        //    {
        //        //return (Value.Trim() != string.Empty ? int.Parse(Value) : 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}

        #endregion

        //#region ConvertStringToTime

        //public static DateTime ConvertStringToTime(string Value)
        //{
        //    try
        //    {

        //        return (DateTime)(Value.Trim() != string.Empty ? Convert.ToDateTime(Value).TimeOfDay : DateTime.Now);
        //    }
        //    catch (Exception ex)
        //    {
        //        return DateTime.Now;
        //    }
        //}

        //#endregion

        #endregion

        #region SetGridStyleBackColor
        public static void SetGridStyleBackColor(params DataGridView[] dataGridView)
        {
            foreach (DataGridView t in dataGridView)
            { t.AlternatingRowsDefaultCellStyle.BackColor = (GridBackColor); }
        }
        #endregion

        #region SetZeroToTextBox

        public static void SetZeroToTextBox(params TextBox[] textBox)
        {
            foreach (TextBox t in textBox)
                t.Text = "0";
        }

        #endregion

        #region TextBoxReadOnly

        public static void ReadOnlyTextBox(bool readOnly, params TextBox[] textBox)
        {
            foreach (TextBox t in textBox)
                t.ReadOnly = readOnly;
        }

        #endregion

        #region Set read only property of Data grid view columns
        /// <summary>
        /// Enable or disable data grid view read only columns
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="dataGridViewColumns"></param>
        /// <param name="readOnly"></param>
        public static void SetDataGridviewColumnsReadOnly(bool readOnly, DataGridView dataGridView, params DataGridViewColumn[] dataGridViewColumns)
        {
            foreach (DataGridViewBand band in dataGridView.Columns)
            {
                if (dataGridViewColumns.Contains(band))
                { band.ReadOnly = readOnly; }
                else
                { band.ReadOnly = !readOnly; }
            }
        }

        #endregion

        #region SetFocus
        /// <summary>
        /// Setfucs Controls
        /// </summary>
        /// <param name="e"></param>
        /// <param name="ctrl"></param>

        public static void SetFocus(KeyEventArgs e, Control ctrl)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ctrl.Focus();
            }
        }

        public static void SetFocus(KeyEventArgs e, Control tabctrl, TabPage tabPage)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabctrl.Focus();
                if (tabctrl is TabControl)
                {
                    ((TabControl)tabctrl).SelectedTab = tabPage;

                }

            }
        }



        public static void SetFocus(Form selectedForm, Control ctrl)
        {
            try
            {
                selectedForm.Controls[ctrl.Name].Focus();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region SetMenu
        public static void SetMenu(Form form, Form mdiForm)
        {

            try
            {
                bool isChild = false;

                foreach (Form f in mdiForm.MdiChildren)
                {
                    if (f.Name.Equals(form.Name))
                    {
                        if (!form.Name.Equals("FrmReprotGenerator"))
                        {
                            isChild = true;
                            break;
                        }
                    }
                }

                if (isChild)
                {
                    form.Focus();
                }
                else
                {
                    if (!form.Name.Equals("FrmReprotGenerator"))
                    {
                        if (form.Tag != null)
                        {
                            form.MaximizeBox = false;
                            form.MdiParent = mdiForm;
                            form.Show();
                            form.Focus();
                        }
                        else
                        {
                            //form.FormBorderStyle = FormBorderStyle.None;
                            form.BackColor = ColorTranslator.FromHtml("#a0a0a0");
                            form.MdiParent = mdiForm;
                            form.Show();
                            form.Focus();
                        }
                    }
                    else if (form.Name.Equals("FrmReprotGenerator"))
                    {
                        //form.FormBorderStyle = FormBorderStyle.None;
                        form.BackColor = ColorTranslator.FromHtml("#a0a0a0");
                        form.Show();
                        form.WindowState = FormWindowState.Maximized;
                        form.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), "", Logger.logtype.ErrorLog, Common.LoggedLocationID);

            }
        }
        #endregion

        #region Set Form Opacity

        public static void SetFormOpacity(Form form, bool isActive)
        {
            if (isActive)
            { form.Opacity = 1; }
            else
            { form.Opacity = 0.9; }
        }

        #endregion

        #region SetAutoComplete to text box

        public static void SetAutoComplete<T>(TextBox textBox, List<T> list)
        {
            AutoCompleteStringCollection AutoCompleteCode = new AutoCompleteStringCollection();

            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            string a;
            //            public static T[] ConvertListToArray<T>(List<T> list) {
            int count = list.Count;
            T[] array = new T[count];
            for (int i = 0; i < list.Count; i++)
            {
                array[i] = list[i];
                //return array;
                a = array[i].ToString();

                MessageBox.Show(a);
                AutoCompleteCode.Add(list[i].ToString());
                a = list[i].ToString();
            }
            for (int i = 0; i < list.Count; i++)
            {
                a = list[i].ToString();
            }
            foreach (var val in list)
            {
                a = val.ToString();
            }

            textBox.AutoCompleteCustomSource = AutoCompleteCode;
        }

        public static void SetAutoComplete(TextBox textBox, AutoCompleteStringCollection autoCompleteCode, bool isComplete)
        {
            if (isComplete)
            {
                textBox.AutoCompleteCustomSource = null;
                textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox.AutoCompleteCustomSource = autoCompleteCode;
            }
            else
            {
                textBox.AutoCompleteMode = AutoCompleteMode.None;
                textBox.AutoCompleteSource = AutoCompleteSource.None;
                textBox.AutoCompleteCustomSource = null;
            }
        }

        public static void SetAutoComplete(TextBox textBox, string[] stringCollection, bool isComplete)
        {
            if (isComplete)
            {
                AutoCompleteStringCollection autoCompleteCode = new AutoCompleteStringCollection();
                autoCompleteCode.AddRange(stringCollection);
                textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox.AutoCompleteCustomSource = autoCompleteCode;
            }
            else
            {
                textBox.AutoCompleteMode = AutoCompleteMode.None;
                textBox.AutoCompleteSource = AutoCompleteSource.None;
                textBox.AutoCompleteCustomSource = null;
            }
        }

        #endregion

        #region SetAutoBindRecords to combo box
        public static void SetAutoBindRecords(ComboBox comboBox, string[] stringCollection)
        {
            AutoCompleteStringCollection autoCompleteCode = new AutoCompleteStringCollection();
            autoCompleteCode.AddRange(stringCollection);
            comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBox.AutoCompleteCustomSource = autoCompleteCode;
            comboBox.DataSource = autoCompleteCode;
            comboBox.SelectedIndex = -1;
        }

        public static void SetAutoBindRecords(ComboBox comboBox, string[] stringCollection, bool isComplete)
        {
            if (isComplete)
            {
                AutoCompleteStringCollection autoCompleteCode = new AutoCompleteStringCollection();
                autoCompleteCode.AddRange(stringCollection);
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                comboBox.AutoCompleteCustomSource = autoCompleteCode;
                comboBox.DataSource = autoCompleteCode;
                comboBox.SelectedIndex = -1;
            }
            else
            {
                comboBox.AutoCompleteMode = AutoCompleteMode.None;
                comboBox.AutoCompleteSource = AutoCompleteSource.None;
                comboBox.AutoCompleteCustomSource = null;
            }
        }

        public static void SetAutoBindRecords(ComboBox comboBox, string[] stringCollection, string displayMember, string valueMember, bool isComplete)
        {
            if (isComplete)
            {
                AutoCompleteStringCollection autoCompleteCode = new AutoCompleteStringCollection();
                autoCompleteCode.AddRange(stringCollection);
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                comboBox.AutoCompleteCustomSource = autoCompleteCode;
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;
                comboBox.DataSource = autoCompleteCode;
                comboBox.SelectedIndex = -1;
            }
            else
            {
                comboBox.AutoCompleteMode = AutoCompleteMode.None;
                comboBox.AutoCompleteSource = AutoCompleteSource.None;
                comboBox.AutoCompleteCustomSource = null;
            }
        }

        public static void BindRecords(ComboBox comboBox, Dictionary<String, String> stringCollection)
        {
            comboBox.DataSource = new BindingSource(stringCollection, null);
            comboBox.DisplayMember = "Key";
            comboBox.ValueMember = "Value";
            comboBox.SelectedIndex = -1;
        }

        public static void BindRecords(ComboBox comboBox, Dictionary<String, int> stringCollection)
        {
            comboBox.DataSource = new BindingSource(stringCollection, null);
            comboBox.DisplayMember = "Key";
            comboBox.ValueMember = "Value";
            comboBox.SelectedIndex = -1;
        }

        public static void BindRecords(DataGridViewComboBoxColumn cataGridViewComboBoxColumn, Dictionary<String, int> stringCollection)
        {
            cataGridViewComboBoxColumn.DataSource = new BindingSource(stringCollection, null);
            cataGridViewComboBoxColumn.DisplayMember = "Key";
            cataGridViewComboBoxColumn.ValueMember = "Value";

        }
        #endregion

        #region Load into checkbox list

        public static void LoadLocationsToCheckList<T>(CheckedListBox chkListLocation, List<T> locations)
        {
            chkListLocation.DataSource = locations;
            chkListLocation.DisplayMember = "LocationName";
            chkListLocation.ValueMember = "LocationID";
        }

        public static void LoadItemsToCheckListt<T>(CheckedListBox checkedListBox, List<CheckedListBoxSelection> items, string displayMember, string valueMember)
        {
            checkedListBox.DataSource = items.OrderBy(v => v.Value).Select(v => v.Value.Trim()).ToList();
            checkedListBox.DisplayMember = displayMember;
            checkedListBox.ValueMember = valueMember;
        }
        public static void LoadItemsToCheckListWithoutOrdert<T>(CheckedListBox checkedListBox, List<CheckedListBoxSelection> items, string displayMember, string valueMember)
        {
            checkedListBox.DataSource = items.Select(v => v.Value.Trim()).ToList();
            checkedListBox.DisplayMember = displayMember;
            checkedListBox.ValueMember = valueMember;
        }
        public static void LoadItemsToCheckList(CheckedListBox checkedListBox, string[] items, string displayMember, string valueMember)
        {
            checkedListBox.DataSource = items;
            checkedListBox.DisplayMember = displayMember;
            checkedListBox.ValueMember = valueMember;
        }

        #endregion

        #region Load into combo box

        #region Load All User Groups into combo box
        /// <summary>
        /// Load All User Groups into combo box
        /// </summary>

        public static void LoadAllUserGroups<U>(ComboBox cmbUserGroup, List<U> userGroups)
        {
            cmbUserGroup.DataSource = userGroups;
            cmbUserGroup.DisplayMember = "UserGroupName";
            cmbUserGroup.ValueMember = "UserGroupID";
            cmbUserGroup.SelectedIndex = -1;
        }


        #endregion

        #region Load All User Accounts into combo box
        /// <summary>
        /// Load All User Accounts into combo box
        /// </summary>

        public static void LoadAllUserAccounts<U>(ComboBox cmbUser, List<U> userAccounts)
        {
            cmbUser.DataSource = userAccounts;
            cmbUser.DisplayMember = "UserName";
            cmbUser.ValueMember = "UserMasterID";
            cmbUser.SelectedIndex = -1;
        }


        #endregion

        #region Load Payment Methods into combo box
        /// <summary>
        /// Load payment methods into given Combo box control
        /// </summary>
        /// <param name="cmbPaymentMethod"></param>
        public static void LoadPaymentMethods<T>(ComboBox cmbPaymentMethod, List<T> paymentMethods)
        {
            cmbPaymentMethod.DataSource = paymentMethods;
            cmbPaymentMethod.DisplayMember = "PaymentMethodName";
            cmbPaymentMethod.ValueMember = "PaymentMethodID";

            cmbPaymentMethod.SelectedIndex = -1;
        }

        public static void LoadPaymentTerms<T>(ComboBox cmbPaymentTerm, List<T> paymentTerms)
        {
            cmbPaymentTerm.DataSource = paymentTerms;
            cmbPaymentTerm.DisplayMember = "PaymentTermName";
            cmbPaymentTerm.ValueMember = "PaymentTermID";

            cmbPaymentTerm.SelectedIndex = -1;
        }

        public static void LoadSupplierNamesToCombo<T>(ComboBox cmbName, List<T> suppliers)
        {
            cmbName.DataSource = suppliers;
            cmbName.DisplayMember = "SupplierName";
            cmbName.ValueMember = "SupplierCode";

            cmbName.SelectedIndex = 0;
        }

        #endregion

        #region Load All Locations into combo box
        /// <summary>
        /// Load All Locations into combo box
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmbLocation"></param>
        /// <param name="locations"></param>
        ///
        public static void LoadLocations<T>(ComboBox cmbLocation, List<T> locations)
        {
            cmbLocation.DataSource = locations;
            cmbLocation.DisplayMember = "LocationName";
            cmbLocation.ValueMember = "LocationID";
            cmbLocation.SelectedIndex = -1;
        }
        #endregion

        public static void LoadProductsToGrid(DataGridView dgvName, DataTable dtProducts)
        {
            if (dtProducts.Rows.Count > 0)
            {
                dgvName.DataSource = dtProducts;
                DataGridViewColumn column = dgvName.Columns[1];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        public static void LoadProductions<T>(ComboBox cmbLocation, List<T> locations)
        {
            cmbLocation.DataSource = locations;
            cmbLocation.DisplayMember = "LocationName";
            cmbLocation.ValueMember = "LocationID";
            cmbLocation.SelectedIndex = -1;
        }

        #region Load All Jobs/Classes into combo box
        /// <summary>
        /// Load All Jobs/Classes into combo box
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmbJobClass"></param>
        /// <param name="JobsClasses"></param>
        ///
        public static void LoadJobsClasses<T>(ComboBox cmbJobClass, List<T> JobsClasses)
        {
            cmbJobClass.DataSource = JobsClasses;
            cmbJobClass.DisplayMember = "JobClassName";
            cmbJobClass.ValueMember = "JobClassID";
            cmbJobClass.SelectedIndex = -1;
        }
        #endregion

        public static void LoadLoyltyCardTypes<T>(ComboBox cmbCardType, List<T> cardTypes)
        {
            cmbCardType.DataSource = cardTypes;
            cmbCardType.DisplayMember = "CardName";
            cmbCardType.ValueMember = "CardMasterID";
            cmbCardType.SelectedIndex = -1;
        }

        public static void LoadCardTypes<T>(ComboBox cmbCardType, List<T> cardTypes)
        {
            cmbCardType.DataSource = cardTypes;
            cmbCardType.DisplayMember = "CardName";
            cmbCardType.ValueMember = "CardMasterID";
            cmbCardType.SelectedIndex = -1;
        }

        public static void LoadCurrencyCodes<T>(ComboBox cmbCurrencyCode, List<T> currencies)
        {
            cmbCurrencyCode.DataSource = currencies;
            cmbCurrencyCode.DisplayMember = "CurrencyCode";
            cmbCurrencyCode.ValueMember = "CurrencyID";
            cmbCurrencyCode.SelectedIndex = -1;
        }
        public static void LoadAllProductCode<T>(ComboBox productCode, List<T> productCodes)
        {
            productCode.DataSource = productCodes;
            productCode.DisplayMember = "ProductCode";
            productCode.ValueMember = "InvproductmasterID";
            productCode.SelectedIndex = -1;
        }
        #region Load All Unit Of Measures into combo box
        /// <summary>
        /// Load All Unit Of Measures into combo box
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmbLocation"></param>
        /// <param name="unitOfMeasures"></param>
        public static void LoadUnitOfMeasures<T>(ComboBox cmbUnitOfMeasure, List<T> unitOfMeasures)
        {
            cmbUnitOfMeasure.DataSource = unitOfMeasures;
            cmbUnitOfMeasure.DisplayMember = "UnitOfMeasureName";
            cmbUnitOfMeasure.ValueMember = "UnitOfMeasureID";
            cmbUnitOfMeasure.SelectedIndex = -1;
        }

        #endregion

        #region Load All Banks into combo box
        /// <summary>
        /// Load All Banks into combo box
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmbBank"></param>
        /// <param name="banks"></param>
        public static void LoadAllBanks<T>(ComboBox cmbBank, List<T> banks)
        {
            cmbBank.DataSource = banks;
            cmbBank.DisplayMember = "BankName";
            cmbBank.ValueMember = "BankID";
            cmbBank.SelectedIndex = -1;
        }

        #endregion

        #region Load All Cost centers into combo box
        /// <summary>
        /// Load All Cost centers in to combo box
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmbCostCenter"></param>
        /// <param name="costCenters"></param>
        public static void LoadCostCenters<T>(ComboBox cmbCostCenter, List<T> costCenters)
        {
            cmbCostCenter.DataSource = costCenters;
            cmbCostCenter.DisplayMember = "CostCentreName";
            cmbCostCenter.ValueMember = "CostCentreID";
            cmbCostCenter.SelectedIndex = -1;
        }

        #endregion

        public static void LoadLoyltyTypes<T>(ComboBox cmbType, List<T> types)
        {
            cmbType.DataSource = types;
            cmbType.DisplayMember = "LookupValue";
            cmbType.ValueMember = "LookupKey";
            cmbType.SelectedIndex = -1;
        }


        public static void LoadProductTypes<T>(ComboBox cmbProductType, List<T> productTypes)
        {
            cmbProductType.DataSource = productTypes;
            cmbProductType.DisplayMember = "ProductTypeName";
            cmbProductType.ValueMember = "InvProductTypeID";
            cmbProductType.SelectedIndex = -1;
        }

        public static void LoadKitchensBars<T>(ComboBox cmbKitchenBar, List<T> KitchenBar)
        {
            cmbKitchenBar.DataSource = KitchenBar;
            cmbKitchenBar.DisplayMember = "KitchenBarName";
            cmbKitchenBar.ValueMember = "InvKitchenBarID";
            cmbKitchenBar.SelectedIndex = -1;
        }

        public static void LoadLocationCodes<T>(ComboBox cmbLocation, List<T> locations)
        {
            cmbLocation.DataSource = locations;
            cmbLocation.DisplayMember = "LocationCode";
            cmbLocation.ValueMember = "LocationID";
        }

        public static void LoadTransferTypes<T>(ComboBox cmbTransferTypes, List<T> transferTypes)
        {
            cmbTransferTypes.DataSource = transferTypes;
            cmbTransferTypes.DisplayMember = "TransferType";
            cmbTransferTypes.ValueMember = "InvTransferTypeID";
            cmbTransferTypes.SelectedIndex = -1;
        }

        public static void LoadPOSDocuments<T>(ComboBox cmbReturnDocument, List<T> returnDocuments)
        {
            cmbReturnDocument.DataSource = returnDocuments;
            cmbReturnDocument.DisplayMember = "Receipt";
            cmbReturnDocument.ValueMember = "TransactionDetId";
            cmbReturnDocument.SelectedIndex = -1;
        }

        public static void LoadLgsTransferTypes<T>(ComboBox cmbTransferTypes, List<T> transferTypes)
        {
            cmbTransferTypes.DataSource = transferTypes;
            cmbTransferTypes.DisplayMember = "TransferType";
            cmbTransferTypes.ValueMember = "LgsTransferTypeID";
            cmbTransferTypes.SelectedIndex = -1;
        }

        public static void LoadInvReturnTypes<T>(ComboBox cmbTransferTypes, List<T> returnTypes)
        {
            cmbTransferTypes.DataSource = returnTypes;
            cmbTransferTypes.DisplayMember = "ReturnType";
            cmbTransferTypes.ValueMember = "InvReturnTypeID";
            cmbTransferTypes.SelectedIndex = -1;
        }

        public static void LoadLgsReturnTypes<T>(ComboBox cmbTransferTypes, List<T> returnTypes)
        {
            cmbTransferTypes.DataSource = returnTypes;
            cmbTransferTypes.DisplayMember = "ReturnType";
            cmbTransferTypes.ValueMember = "LgsReturnTypeID";
            cmbTransferTypes.SelectedIndex = -1;
        }

        public static void LoadEmployeeDesignations<T>(ComboBox cmbDesigTypes, List<T> designations)
        {
            cmbDesigTypes.DataSource = designations;
            cmbDesigTypes.DisplayMember = "Designation";
            cmbDesigTypes.ValueMember = "EmployeeDesignationTypeID";
            cmbDesigTypes.SelectedIndex = -1;
        }

        public static void LoadDepartmentNames<T>(ComboBox cmbDepartment, List<T> DepartmentName)
        {
            cmbDepartment.DataSource = DepartmentName;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "InvDepartmentID";
            cmbDepartment.SelectedIndex = -1;
        }

        public static void LoadTOGDocuments<T>(ComboBox cmbTOGDocument, List<T> returnDocuments)
        {
            cmbTOGDocument.DataSource = returnDocuments;
            cmbTOGDocument.DisplayMember = "DocumentNo";
            cmbTOGDocument.ValueMember = "DocumentID";
            cmbTOGDocument.SelectedIndex = -1;
        }

        public static void LoadDamageType<T>(ComboBox cmbDamage, List<T> DamageName)
        {
            cmbDamage.DataSource = DamageName;
            cmbDamage.DisplayMember = "DamageType";
            cmbDamage.ValueMember = "InvDamageTypeID";
            cmbDamage.SelectedIndex = -1;
        }

        public static void LoadStockTakingLayer<T>(ComboBox cmbLayer, List<T> locations)
        {
            cmbLayer.DataSource = locations;
            cmbLayer.DisplayMember = "FormText";
            cmbLayer.ValueMember = "AutoGenerateInfoID";
            cmbLayer.SelectedIndex = -1;
        }

        #region Load All Promotion Types into combo box
        /// <summary>
        /// Load All Promotion Types into combo box
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmbBank"></param>
        /// <param name="banks"></param>
        public static void LoadAllPromotionTypes<T>(ComboBox cmbPromotionType, List<T> promotionTypes)
        {
            cmbPromotionType.DataSource = promotionTypes;
            cmbPromotionType.DisplayMember = "PromotionTypeName";
            cmbPromotionType.ValueMember = "InvPromotionTypeID";
            cmbPromotionType.SelectedIndex = -1;
        }
        #endregion

        #region LoadAutoGenetateInfo
        public static void LoadAutoGenetateFormNames<T>(ComboBox cmbFormName, List<T> formNames)
        {
            cmbFormName.DataSource = formNames;
            cmbFormName.DisplayMember = "FormText";
            cmbFormName.ValueMember = "FormName";
            cmbFormName.SelectedIndex = -1;
        }


        #endregion
        #endregion

        public static void SetAutoCompleteModeByListItems(ComboBox cmbComboBox)
        {
            cmbComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        #region Allow Delete

        /// <summary>
        /// Allow to delete grid view items(rows) only on 'F2' key down of grid view
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool AllowDeleteGridRow(KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
            { return true; }
            else
            { return false; }
        }

        #endregion

        #region FormatDate

        public static DateTime FormatDate(DateTime Value)
        {
            try
            {
                return DateTime.Parse(string.Format("{0:dd/MM/yyyy}", Value));
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }

        public static DateTime FormatDateTime(DateTime Value)
        {
            try
            {
                return DateTime.Parse(string.Format("{0:dd/MM/yyyy hh:mm:ss}", Value));
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }

        #endregion

        #region Get

        #region GetDate

        public static DateTime GetSystemDate()
        {
            return Common.FormatDate(DateTime.Now);
        }

        #endregion

        #region GetDateWithTime

        public static DateTime GetSystemDateWithTime()
        {
            return Common.FormatDateTime(DateTime.Now);
        }


        #endregion

        #region GetSummaryAmount

        public static decimal GetSummaryAmount<T>(this IEnumerable<T> source, Func<T, bool> predicate, Func<T, decimal> valueSelector)
        {
            return source.Where(predicate)
                         .Sum(valueSelector);

            //return source.Sum(valueSelector);
        }

        public static decimal GetSummaryAmount<T>(this IEnumerable<T> source, Func<T, decimal> valueSelector)
        {
            //return source.Where(predicate)
            //             .Sum(valueSelector);

            return source.Sum(valueSelector);
        }

        public static decimal GetSummaryAmountJournelEntryCr<T>(this IEnumerable<T> source, Func<T, decimal> valueSelector)
        {
            return source.Sum(valueSelector);
        }

        public static decimal GetSummaryAmountJournelEntryDr<T>(this IEnumerable<T> source, Func<T, decimal> valueSelector)
        {
            return source.Sum(valueSelector);
        }

        public static int GetTotalCount<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            //return source.Where(predicate)
            //             .Sum(valueSelector);

            return source.Count();
        }

        public static int GetTotalCount<T>(this IEnumerable<T> source)
        {
            //return source.Where(predicate)
            //             .Sum(valueSelector);

            return source.Count();
        }
        #endregion

        #region GetTotalAmount

        public static decimal GetTotalAmount(params decimal[] value)
        {
            return value.Sum(x => x);
        }

        #endregion

        #region GetDiscountAmount

        public static decimal GetDiscountAmount(bool isPercentage, decimal amountToDiscount, decimal discountValue)
        {
            if (discountValue > 0)
            {
                if (isPercentage)
                {
                    return (amountToDiscount * discountValue) / 100;
                }
                else
                {
                    return discountValue;
                }
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Get percentage value
        /// <summary>
        /// Remove character '%'  from given string and return percentage value
        /// </summary>
        /// <param name="percentageString"></param>
        /// <returns></returns>
        public static decimal GetPercentageValue(string percentageString)
        {
            decimal percentageValue = 0;
            if (string.Equals("%", percentageString.Substring(percentageString.Length - 1, 1)))
            {
                return percentageValue = Decimal.Parse(percentageString.Remove(percentageString.Length - 1));
            }
            else
            {
                return percentageValue = Decimal.Parse(percentageString);
            }

        }

        #endregion

        #region Get Selection Criteria For Gift Vouchers
        public static string[] GetGiftVoucherSelectionCriteria(int selectionCriteria)
        {
            string[] giftVoucherSelectionCriteria = new string[] { };
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            if (selectionCriteria == 0)
            {
                dictionary[1] = "Base On Voucher Quantity";
                dictionary[2] = "Base On Voucher Serial Range";
                dictionary[3] = "Base On Voucher No Range";
            }
            else
            {
                dictionary[1] = "Base On Voucher Quantity";
                dictionary[2] = "Base On Voucher Serial Range";
            }

            List<KeyValuePair<int, string>> list = dictionary.ToList();
            int count = 0;
            giftVoucherSelectionCriteria = new string[list.Count];
            foreach (KeyValuePair<int, string> pair in list)
            {
                giftVoucherSelectionCriteria[count] = pair.Value;
                count++;
            }
            return giftVoucherSelectionCriteria;
        }
        #endregion

        #endregion

        #region Display String Format
        public static string ConvertStringToDisplayFormat(string displayString)
        {
            string formattedDisplayString = "";
            if (displayString.EndsWith("*"))
            { formattedDisplayString = displayString.Replace(displayString.Substring((displayString.Length - 1), 1), ""); }
            else
            { formattedDisplayString = displayString; }

            return formattedDisplayString;
        }
        #endregion

        public static DataTable DataTableColumnNameChange(DataTable inputTable)
        {
            DataTable dtReturn = new DataTable();
            string NewColName;
            foreach (DataColumn column in inputTable.Columns)
            {
                NewColName = GetColumnNameWithSpace(column);
                inputTable.Columns[column.ToString()].ColumnName = NewColName;
            }
            return inputTable;
        }

        public static string GetColumnNameWithSpace(DataColumn dtColName)
        {
            string colName;
            colName = (dtColName.ToString()).Substring(0, 1);
            foreach (char input in (dtColName.ToString()).Substring(1))
            {
                if (Char.IsUpper(input))
                {
                    colName += " " + input;
                }
                else
                {
                    colName = colName + input;
                }
            }
            return colName;
        }

        //#region LINQ To DataTable
        ///// <summary>
        ///// Convert LINQ query to DataTable
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="varlist"></param>
        ///// <returns></returns>

        //public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        //{

        //    DataTable dtReturn = new DataTable();
        //    // column names
        //    PropertyInfo[] oProps = null;

        //    if (varlist == null)
        //    { return dtReturn; }

        //    foreach (T rec in varlist)
        //    {
        //        // Use reflection to get property names, to create table, Only first time, others will follow
        //        if (oProps == null)
        //        {
        //            oProps = ((Type)rec.GetType()).GetProperties();
        //            foreach (PropertyInfo pi in oProps)
        //            {
        //                Type colType = pi.PropertyType;

        //                if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
        //                { colType = colType.GetGenericArguments()[0]; }

        //                dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
        //            }
        //        }

        //        DataRow dr = dtReturn.NewRow();
        //        foreach (PropertyInfo pi in oProps)
        //        {
        //            dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
        //            (rec, null);
        //        }

        //        dtReturn.Rows.Add(dr);
        //    }
        //    return dtReturn;
        //}


        //#endregion

        //private DataSet LINQToDataSet(var myDB, IQueryable item)
        //{
        //    SqlCommand cmd = myDB.GetCommand(item) as SqlCommand;

        //    DataTable oDataTable = new DataTable();
        //    SqlDataAdapter oDataAdapter = new SqlDataAdapter(cmd);
        //    oDataAdapter.Fill(oDataTable);

        //    DataSet oDataSet = new DataSet();
        //    oDataSet.Tables.Add(oDataTable);
        //    return oDataSet;
        //}

        /// <summary>
        /// Convert IQueryable query to object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<T> ConvertQueryToList<T>(IQueryable<T> query)
        {
            return query.ToList();
        }

        #region Copy File
        public static bool CopyDirectory(string SourcePath, string DestinationPath, bool overwriteexisting)
        {
            bool ret = false;
            try
            {
                SourcePath = SourcePath.EndsWith(@"\") ? SourcePath : SourcePath + @"\";
                DestinationPath = DestinationPath.EndsWith(@"\") ? DestinationPath : DestinationPath + @"\";

                if (Directory.Exists(SourcePath))
                {
                    if (Directory.Exists(DestinationPath) == false)
                        Directory.CreateDirectory(DestinationPath);

                    foreach (string fls in Directory.GetFiles(SourcePath))
                    {
                        FileInfo flinfo = new FileInfo(fls);
                        flinfo.CopyTo(DestinationPath + flinfo.Name, overwriteexisting);
                    }
                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo drinfo = new DirectoryInfo(drs);
                        if (CopyDirectory(drs, DestinationPath + drinfo.Name, overwriteexisting) == false)
                            ret = false;
                    }
                }
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }

        public static bool CopyDirectoryToTargetServer(string SourcePath, string DestinationPath, bool overwriteexisting)
        {
            bool ret = false;
            try
            {
                SourcePath = SourcePath.EndsWith(@"\") ? SourcePath : SourcePath + @"\";
                DestinationPath = DestinationPath.EndsWith(@"\") ? DestinationPath : DestinationPath + @"\";

                if (Directory.Exists(SourcePath))
                {
                    if (Directory.Exists(DestinationPath) == false)
                        Directory.CreateDirectory(DestinationPath);

                    foreach (string fls in Directory.GetFiles(SourcePath))
                    {
                        FileInfo flinfo = new FileInfo(fls);
                        flinfo.CopyTo(DestinationPath + flinfo.Name, overwriteexisting);
                        //Delete file after copy to destination for prevent duplicate
                        //if (System.IO.File.Exists(@fls))
                        //{
                        //    System.IO.File.Delete(@fls);
                        //}
                    }
                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo drinfo = new DirectoryInfo(drs);
                        if (CopyDirectory(drs, DestinationPath + drinfo.Name, overwriteexisting) == false)
                            ret = false;
                    }
                }
                ret = true;




            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }

        public static bool CheckTargetIPStatus(String LocIP)
        {
            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                // Use the default Ttl value which is 128,
                // but change the fragmentation behavior.
                options.DontFragment = true;
                bool ping = false;
                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 1000;
                //check slave server 1
                if (LocIP.Trim() != string.Empty)
                {

                    PingReply reply = pingSender.Send(LocIP);
                    if (reply.Status == IPStatus.Success)
                    {

                        //Console.WriteLine("Address: {0}", reply.Address.ToString());
                        //Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                        //Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                        //Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                        //Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);

                        //lblServer1Status.Text = LocDescription + " Server On Line";
                        //lblServer1Status.BackColor = Color.Silver;
                        ping = true;
                    }
                    else
                    {
                        //isTargetsvr1Online = false;
                        //lblServer1Status.Text = LocDescription + " Server Is Off Line";
                        //lblServer1Status.BackColor = Color.Red;
                        ping = false;
                    }
                }
                return ping;
            }
            catch (System.Net.NetworkInformation.PingException)
            {
                //return ("Failed: Host unknown.");
                return false;
            }

        }

        #endregion

        #region "getobject filled object with property reconized"

        public static List<T> ConvertTo<T>(DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }
        public static T getObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                //Properties = typeof(T).GetProperties().Where ( P=> !P.GetGetMethod().IsVirtual).ToArray();
                foreach (PropertyInfo objProperty in Properties)
                {
                    Type propertyType = objProperty.PropertyType;
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }

                        }
                    }
                    if (propertyType.IsGenericType)
                    {
                        propertyType = Nullable.GetUnderlyingType(propertyType);
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }

        #endregion

        #region ValidateDate

        public static bool ValidateDate(DateTime docDate)
        {
            //docDate = Common.FormatDate(docDate);
            DateTime dtNow = Common.FormatDate(DateTime.Now);

            if (docDate < dtNow) { return false; }
            else { return true; }
        }

        #endregion

        #region validate Machine date time format
        public static bool ValidateMachineDateTimeFromat()
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            DateTimeFormatInfo dtfi = ci.DateTimeFormat;
            string[] SystemDateTimePatterns = new string[250];
            int i = 0;

            foreach (string name in dtfi.GetAllDateTimePatterns('d'))
            {
                SystemDateTimePatterns[i] = name;
                i++;
            }

            string[] myDateTimeFormat = { "dd/MM/yyyy" };
            if (!myDateTimeFormat[0].Equals(SystemDateTimePatterns[0]))
            {
                MessageBox.Show("Your Machine DateTime Format is: " + SystemDateTimePatterns[0] + ".\n" + "Required DateTime Format is: dd/MM/yyyy. \nPlease Change the Datetime Format.", "System Datetime Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        /// <summary>
        /// check over lapping date ranges
        /// </summary>
        /// <param name="dateRanges"></param>
        /// <returns></returns>
        public static bool IsAnyDateRangeOverlap(params Tuple<DateTime, DateTime>[] dateRanges)
        {
            for (int i = 0; i < dateRanges.Length; i++)
            {
                for (int j = i + 1; j < dateRanges.Length; j++)
                {
                    if (dateRanges[i].Item1 <= dateRanges[j].Item2 && dateRanges[i].Item2 >= dateRanges[j].Item1)
                        return true;
                }
            }
            return false;
        }

        public static bool CopyDirectoryAll(DirectoryInfo source, DirectoryInfo destination)
        {
            try
            {
                if (!destination.Exists)
                {
                    destination.Create();
                }

                // Process subdirectories.
                DirectoryInfo[] dirs = source.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    // Get destination directory.
                    string destinationDir = Path.Combine(destination.FullName, dir.Name);

                    DirectoryInfo destinationX = new DirectoryInfo(destinationDir);

                    if (!destinationX.Exists)
                    {
                        destinationX.Create();
                    }

                    // Call CopyDirectory() recursively.
                    //CopyDirectoryAll(dir, new DirectoryInfo(destinationDir));

                    // Copy all files.
                    FileInfo[] files = dir.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        file.CopyTo(Path.Combine(destinationX.FullName,
                            file.Name));
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public static void EncryptConnectionString(bool encrypt, string fileName)
        {
            Configuration configuration = null;
            try
            {
                // Open the configuration file and retrieve the connectionStrings section.
                configuration = ConfigurationManager.OpenExeConfiguration(fileName);
                ConnectionStringsSection configSection = configuration.GetSection("connectionStrings") as ConnectionStringsSection;
                if ((!(configSection.ElementInformation.IsLocked)) && (!(configSection.SectionInformation.IsLocked)))
                {
                    if (encrypt && !configSection.SectionInformation.IsProtected)
                    {
                        //this line will encrypt the file
                        configSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    }

                    if (!encrypt && configSection.SectionInformation.IsProtected)//encrypt is true so encrypt
                    {
                        //this line will decrypt the file.
                        configSection.SectionInformation.UnprotectSection();
                    }
                    //re-save the configuration file section
                    configSection.SectionInformation.ForceSave = true;
                    // Save the current configuration

                    configuration.Save();
                    //Process.Start("notepad.exe", configuration.FilePath);
                    //configFile.FilePath
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //public static DataTable ExecuteSqlQuery(string sqlQuery)
        //{
        //    DataTable dtQueryResult = new DataTable();
        //    SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString);
        //    sqlConn.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = sqlConn;
        //    cmd.CommandText = sqlQuery.ToString();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandTimeout = 300;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dtQueryResult);

        //    return dtQueryResult;
        //}

        /// <summary>
        /// Check image size
        /// </summary>
        /// <returns></returns>
        public static bool CheckImageSize(PictureBox pictureBox, int sizeLimit)
        {
            long jpegKBSize;
            MemoryStream stream = new MemoryStream();
            pictureBox.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] pic = stream.ToArray();
            jpegKBSize = pic.Length / 1000;

            if (jpegKBSize > sizeLimit)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Check image size
        /// </summary>
        /// <returns></returns>
        public static bool CheckImageSize(Image image, int sizeLimit)
        {
            long jpegKBSize;
            MemoryStream stream = new MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] pic = stream.ToArray();
            jpegKBSize = pic.Length / 1000;

            if (jpegKBSize > sizeLimit)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #region SetModuleFeatures
        public static void SetModuleFeature(int systemProductId)
        {
            switch (systemProductId)
            {
                case 1: // Company :1  RetailIT
                    ModuleTypes.InventoryAndSales = true;
                    ModuleTypes.PointOfSales = true;
                    ModuleTypes.Manufacture = false;
                    ModuleTypes.HirePurchase = false;
                    ModuleTypes.CustomerRelationshipModule = true;
                    ModuleTypes.GiftVouchers = true;
                    ModuleTypes.Accounts = false;
                    ModuleTypes.NonTrading = false;
                    ModuleTypes.HrManagement = false;
                    ModuleTypes.HospitalManagement = false;
                    ModuleTypes.ApparelManufacture = false;
                    ModuleTypes.DashBoard = false;
                    ModuleTypes.RestaurantManagement = false;
                    ModuleFeatureTypes.AccountFeaturesOnly = false;
                    break;
                case 2: // Company :1  Manjari
                    ModuleTypes.InventoryAndSales = true;
                    ModuleTypes.PointOfSales = true;
                    ModuleTypes.Manufacture = false;
                    ModuleTypes.HirePurchase = false;
                    ModuleTypes.CustomerRelationshipModule = true;
                    ModuleTypes.GiftVouchers = true;
                    ModuleTypes.Accounts = false;
                    ModuleTypes.NonTrading = false;
                    ModuleTypes.HrManagement = false;
                    ModuleTypes.HospitalManagement = false;
                    ModuleTypes.ApparelManufacture = false;
                    ModuleTypes.DashBoard = false;
                    ModuleTypes.RestaurantManagement = false;
                    ModuleFeatureTypes.AccountFeaturesOnly = false;
                    break;
                case 3: // Company :3  RetailIT  --
                    ModuleTypes.InventoryAndSales = true;
                    ModuleTypes.PointOfSales = true;
                    ModuleTypes.Manufacture = false;
                    ModuleTypes.HirePurchase = false;
                    ModuleTypes.CustomerRelationshipModule = true;
                    ModuleTypes.GiftVouchers = true;
                    ModuleTypes.Accounts = false;
                    ModuleTypes.NonTrading = false;
                    ModuleTypes.HrManagement = false;
                    ModuleTypes.HospitalManagement = false;
                    ModuleTypes.ApparelManufacture = false;
                    ModuleTypes.DashBoard = false;
                    ModuleTypes.RestaurantManagement = false;
                    ModuleFeatureTypes.AccountFeaturesOnly = false;
                    break;
                default:
                    break;
            }
        }
        #endregion

        public static void ResetDateTimePickers(params DateTimePicker[] dtPicker)
        {
            foreach (DateTimePicker item in dtPicker)
            {
                item.Value = Common.GetSystemDate();
            }
        }

        #region Convert Currency To Its Verbal Format
        public static string ConvertNumberToWords(string rawnumber, bool isCurrency)
        {
            int inputNum = 0;
            int dig1, dig2, dig3, level = 0, lasttwo, threeDigits;
            string rupees, cents;
            try
            {
                string[] Splits = new string[2];
                Splits = rawnumber.Split('.');   //notice that it is ' and not "
                inputNum = Convert.ToInt32(Splits[0]);
                rupees = "";
                cents = Splits[1];
                if (cents.Length == 1)
                {
                    cents += "0";   // 12.5 is twelve and 50/100, not twelve and 5/100
                }
            }
            catch
            {
                cents = "00";
                inputNum = Convert.ToInt32(rawnumber);
                rupees = "";
            }

            string x = "";

            bool isNegative = false;
            if (inputNum < 0)
            {
                isNegative = true;
                inputNum *= -1;
            }
            if (inputNum == 0)
            {
                if (isCurrency)
                {
                    return "zero " + Common.CurrenyFormat + " and " + ConvertCentsToWords(Convert.ToInt32(cents)) + " only.";
                }
                else
                {
                    return "zero and " + ConvertCentsToWords(Convert.ToInt32(cents)) + " only.";
                }
            }

            string s = inputNum.ToString();

            while (s.Length > 0)
            {
                //Get the three rightmost characters
                x = (s.Length < 3) ? s : s.Substring(s.Length - 3, 3);

                // Separate the three digits
                threeDigits = int.Parse(x);
                lasttwo = threeDigits % 100;
                dig1 = threeDigits / 100;
                dig2 = lasttwo / 10;
                dig3 = (threeDigits % 10);

                // append a "thousand" where appropriate
                if (level > 0 && dig1 + dig2 + dig3 > 0)
                {
                    rupees = thou[level] + " " + rupees;
                    rupees = rupees.Trim();
                }

                // check that the last two digits is not a zero
                if (lasttwo > 0)
                {
                    if (lasttwo < 20)
                    {
                        // if less than 20, use "ones" only
                        rupees = ones[lasttwo] + " " + rupees;
                    }
                    else
                    {
                        // otherwise, use both "tens" and "ones" array
                        rupees = tens[dig2] + " " + ones[dig3] + " " + rupees;
                    }
                    if (s.Length < 3)
                    {
                        if (isCurrency)
                        {
                            if (isNegative) { rupees = " negative " + rupees; }
                            return rupees + " " + Common.CurrenyFormat + " and " + ConvertCentsToWords(Convert.ToInt32(cents)) + " only.";
                        }
                        else
                        {
                            if (isNegative) { rupees = " negative " + rupees; }
                            return rupees + " and " + ConvertCentsToWords(Convert.ToInt32(cents)) + " only.";
                        }
                    }
                }

                // if a hundreds part is there, translate it
                if (dig1 > 0)
                {
                    rupees = ones[dig1] + " hundred " + rupees;
                    s = (s.Length - 3) > 0 ? s.Substring(0, s.Length - 3) : "";
                    level++;
                }
                else
                {
                    if (s.Length > 3)
                    {
                        s = s.Substring(0, s.Length - 3);
                        level++;
                    }
                }
            }
            if (isCurrency)
            {
                if (isNegative) { rupees = " negative " + rupees; }
                return (rupees + " " + Common.CurrenyFormat + "and " + ConvertCentsToWords(Convert.ToInt32(cents)) + " only.");
            }
            else
            {
                if (isNegative) { rupees = " negative " + rupees; }
                return (rupees + "and " + ConvertCentsToWords(Convert.ToInt32(cents)) + " only.");
            }
        }

        private static string ConvertCentsToWords(int cents)
        {
            char[] centsArr = cents.ToString().ToCharArray();
            string stringValue = string.Empty;

            if (cents > 0)
            {
                if (cents < 20)
                {
                    // if less than 20, use "ones" only
                    stringValue = ones[cents] + " cent(s)";
                }
                else
                {
                    // otherwise, use both "tens" and "ones" array
                    stringValue = tens[Convert.ToInt32(centsArr[0].ToString())] + " " + ones[Convert.ToInt32(centsArr[1].ToString())] + " cents";
                }
            }
            else if (cents == 0)
            {
                stringValue = "zero cents";
            }
            return stringValue;
        }
        #endregion

        #region Convert Excel Sheet To DataTable
        /// <summary>
        /// Convert excel sheet to data table using Microsoft.Office.Interop
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static System.Data.DataTable ConvertExcelToDataTable(string path)
        {
            System.Data.DataTable dtExcelData = null;
            object rowIndex = 1;
            dtExcelData = new System.Data.DataTable();
            DataRow row;

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(path, 0, true, 5, "", "", true,
            Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;

            int temp = 1;
            while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, temp]).Value2 != null)
            {
                dtExcelData.Columns.Add(Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, temp]).Value2));
                temp++;
            }

            rowIndex = Convert.ToInt32(rowIndex) + 1;
            int columnCount = temp;
            temp = 1;

            while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, temp]).Value2 != null)
            {
                row = dtExcelData.NewRow();
                for (int i = 1; i < columnCount; i++)
                {
                    row[i - 1] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, i]).Value2);
                }

                dtExcelData.Rows.Add(row);
                rowIndex = Convert.ToInt32(rowIndex) + 1;
                temp = 1;
            }

            app.Workbooks.Close();

            // Add row numbers
            DataColumn colRow = dtExcelData.Columns.Add("Row", typeof(int));
            colRow.SetOrdinal(0);

            int rowNo = 1;
            foreach (DataRow dataRow in dtExcelData.Rows)
            {
                dataRow["Row"] = rowNo;
                rowNo++;
            }

            return dtExcelData;
        }

        #endregion


        public static void SetTootipText(string toolTipText, Control button, string title)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.ToolTipTitle = title;
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.IsBalloon = false;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;

            buttonToolTip.ShowAlways = true;

            buttonToolTip.AutoPopDelay = 5000;
            buttonToolTip.InitialDelay = 1000;
            buttonToolTip.ReshowDelay = 500;

            buttonToolTip.SetToolTip(button, toolTipText);
        }

        public static void ShowNotification(string titleText, string contentText, int delay, int animateInterval, int animateDuration, bool showImage)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
 
        }

        public static void HighlightControl(Control ConlName)
        {
            ConlName.Font = new Font(ConlName.Font, FontStyle.Bold);
        }


        public static void UnHighlightControl(Control controlName)
        {
            controlName.Font = new Font(controlName.Font, FontStyle.Regular);
        }

        public static string SentenceCase(string input)
        {
            if (input.Length < 1)
                return input;

            string sentence = input.ToLower();
            return sentence[0].ToString().ToUpper() +
               sentence.Substring(1);
        }

        public static DataTable ListToDataTable<T>(this List<T> iList)
        {
            DataTable dataTable = new DataTable();
            PropertyDescriptorCollection propertyDescriptorCollection =
                TypeDescriptor.GetProperties(typeof(T));
            for (int i = 0; i < propertyDescriptorCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                Type type = propertyDescriptor.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    type = Nullable.GetUnderlyingType(type);


                dataTable.Columns.Add(propertyDescriptor.Name, type);
            }
            object[] values = new object[propertyDescriptorCollection.Count];
            foreach (T iListItem in iList)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = propertyDescriptorCollection[i].GetValue(iListItem);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static void GridAlignment(DataGridView dtGrid)   // To Align data and set column width in the DataGridView Author :
        {
            if (dtGrid.RowCount > 0)
            {
                string dtType;


                for (int i = 0; i < dtGrid.Columns.Count; i++)
                {
                    string a;
                    a = dtGrid.Rows[0].Cells[i].Value.ToString();

                    dtType = dtGrid.Columns[i].ValueType.ToString();

                    switch (dtType)
                    {
                        case "System.Decimal":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.Double":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.Int16":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.Int32":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }
                            break;

                        case "System.Int64":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.Single":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }
                            break;

                        case "System.UInt16":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.UInt32":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.UInt64":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 6) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }

                            break;

                        case "System.DateTime":
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                            dtGrid.Columns[i].Width = 80;
                            break;

                        default:
                            dtGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            if (a.Length < 7)
                            {
                                dtGrid.Columns[i].Width = (a.Length + 5) * 10;
                            }
                            else
                            {
                                dtGrid.Columns[i].Width = (a.Length + 1) * 10;
                            }
                            break;
                    }

                }
            }
        }

        public static void LoadUnitNumbers<T>(ComboBox cmbUnit, List<T> units)
        {
            cmbUnit.DataSource = units;
            cmbUnit.DisplayMember = "UnitNo";
            cmbUnit.ValueMember = "UnitID";
            cmbUnit.SelectedIndex = -1;
        }

        public static void LoadShiftNumbers<T>(ComboBox cmbShift, List<T> shift)
        {
            cmbShift.DataSource = shift;
            cmbShift.DisplayMember = "ShiftNo";
            cmbShift.ValueMember = "ShiftID";
            cmbShift.SelectedIndex = -1;
        }

        public static void LoadOrderTerminals<T>(ComboBox cmbOrderTerminal, List<T> orderTerminals)
        {
            cmbOrderTerminal.DataSource = orderTerminals;
            cmbOrderTerminal.DisplayMember = "KitchenBarName";
            cmbOrderTerminal.ValueMember = "InvKitchenBarID";
            cmbOrderTerminal.SelectedIndex = -1;
        }

        public static void LoadBillingLocations<T>(ComboBox cmbLocation, List<T> locations)
        {
            cmbLocation.DataSource = locations;
            cmbLocation.DisplayMember = "LocationName";
            cmbLocation.ValueMember = "BillingLocationID";
            cmbLocation.SelectedIndex = -1;
        }


        #region FormatDataGrid

        public static Color HeaderColor()
        {
            return Color.FromArgb(50, 63, 79);
        }
        public static Color HeaderForeColor()
        {
            return Color.FromArgb(255, 255, 255);
        }
        public static Color GridBackColor2()
        {
            return Color.FromArgb(43, 87, 154);
            //return Color.FromArgb(132, 150, 176);
        }

        public static void FormatDataGrid(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = Color.FromArgb(242, 242, 242);
            //dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //dataGridView.ColumnHeadersHeight = 20;
            dataGridView.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView.RowHeadersVisible = false;

            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            dataGridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;


            //dataGridView.DefaultCellStyle.Font = new Font("Calibri", 9);

            dataGridView.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 119, 174);

            //dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 10);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = GridBackColor2();
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke; //Color.FromArgb(31, 56, 100);

            dataGridView.EnableHeadersVisualStyles = false;
            //dataGridView.AllowUserToAddRows = false;
        }

        #endregion

    }
}
