using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Utility;
using ERP.Service;

namespace ERP.UI.Windows
{
    public partial class FrmBaseTransactionForm : Form
    {
        private static FrmBaseTransactionForm basetransactionform;

        public FrmBaseTransactionForm()
        {
            InitializeComponent();
        }

        public static FrmBaseTransactionForm GetBaseTransactionForm
        {
            get { return basetransactionform; }
            set { basetransactionform = value; }
        }

        public virtual void Clear()
        {
            if (Toast.Show(this.Text, "", "Do you want to clear this form?", Toast.messageType.Question, Toast.messageAction.General).Equals(DialogResult.Yes))
            {
                ClearForm();
            }
            else
            {
                return;
            }
        }

        public virtual void ClearForm()
        {
            Common.ClearForm(this);
            errorProvider.Clear();
            InitializeForm();


        }

        public virtual void CloseForm()
        { 
            DialogResult dialogResult = MessageBox.Show("Do you want to close this form?", this.Text, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
                basetransactionform = null;
            } 
        }


        public virtual void FormLoad()
        {
            InitializeForm();
        }

        public virtual void Save() { }

        public virtual void Delete() { }

        public virtual void Print() { }

        public virtual void InitializeForm() { }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Save(); 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void FrmBaseTransactionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                CloseForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void FrmBaseTransactionForm_Load(object sender, EventArgs e)
        {
            this.Top = 1;
            this.Left = 1;
            FormLoad();
            // this.Height = this.Height + 40;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is GroupBox || ctrl is Panel)
                {
                    //ctrl.Top = ctrl.Top + pnl_header.Height + 5;
                    var pnl = ctrl as Panel;
                    if (pnl != null)
                        pnl.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }















    }
}
