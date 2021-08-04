using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Utility;

namespace ERP.UI.Windows.CustomControls
{
    /// <summary>
    /// Extended Textbox Control used to display Percentage values (Can be entered greater than values to 100)
    /// </summary>
    /// 
    public partial class TextBoxPercentGrt100 : UserControl
    {
       // variable to keep temp value
        private string tmpValue;

        // member variable used to keep Percentage value
        private Decimal mPercentageValue;

        /// <summary>
        /// property to maintain value of control
        /// </summary>
        public decimal PercentageValue
        {
            get
            {
                return mPercentageValue;
            }
            set
            {
                mPercentageValue = value;
            }
        }


        // constructor
        public TextBoxPercentGrt100()
        {
            InitializeComponent();
            //PercentageValue = 0;
        }

        // default OnPaint
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        /// <summary>
        /// Keypress handler used to restrict user input
        /// to numbers and control characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxPercentGrt100_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows only numbers, decimals and control characters
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && this.Text.Contains("."))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && this.Text.Length < 1)
            {
                e.Handled = true;
            }

            tmpValue = this.Text.Trim();
        }



        /// <summary>
        /// Update display to show decimal as Numeric
        /// whenver it is validated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxPercentGrt100_Validated(object sender, EventArgs e)
        {
            try
            {                
                // format the value as numeric
                Decimal dTmp = Convert.ToDecimal(SetTextValue(this.Text));

                /// <summery>
                /// Change the 'F' value(number of decimal points) depending on system requirenment
                /// If entered value is 450000.02622 Then formated value is 
                /// F  --> 450000.03
                /// F2 --> 450000.03
                /// F3 --> 450000.026
                /// F4 --> 450000.0262
                /// </summary>
                
                //this.Text = dTmp.ToString("F2");                
                this.Text = Common.ConvertDecimalToStringCurrency(dTmp);
            }
            catch { }
        }



        /// <summary>
        /// Revert back to the display of numbers only
        /// whenever the user clicks in the box for
        /// editing purposes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxPercentGrt100_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Update the numeric value each time the value is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxPercentGrt100_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.Text.Trim()))
                { return; }

                if (!validatePercentage(this.Text.Trim()))
                {
                    this.ForeColor = Color.Black;
                    this.Text = tmpValue;
                    //this.SelectionStart = this.Text.Length;
                }
                else
                {
                    tmpValue = string.Empty;
                    this.ForeColor = Color.Black;
                }
            }
            catch { }
        }


        /// <summary>
        //// Validate Percentage(0 < Percentage)
        /// </summary>
        /// <param name="ParNumber"></param>
        /// <returns></returns>
        public static bool validatePercentage(string ParNumber)
        {
            try
            {
                Convert.ToDecimal(ParNumber);
                if (Convert.ToDecimal(ParNumber) >= 0) // &&Convert.ToDecimal(ParNumber) <= 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Set text value to '0' if input text is empty
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string SetTextValue(string text)
        {
            return text.Equals(string.Empty) ? text = "0" : text;
        }

    }
}