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

namespace ERP.UI.Windows
{
    public partial class FrmBasePrintForm : Form
    {
        private static FrmBasePrintForm baseform;

        public FrmBasePrintForm()
        {
            InitializeComponent();
        }

        public static FrmBasePrintForm GetBaseForm
        {
            get { return baseform; }
            set { baseform = value; }
        }

        private void FrmBasePrintForm_Load(object sender, EventArgs e)
        {
            this.Top = 1;
            this.Left = 1;
            FormLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           
            CloseForm();
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public virtual void ClearForm()
        {
            Common.ClearForm(this);
            errorProvider.Clear();
            InitializeForm();
            
        }

        public virtual void CloseForm()
        {
            if (Toast.Show(this.Text, "", "Do you want to close this form?", Toast.messageType.Question, Toast.messageAction.General).Equals(DialogResult.Yes))
            {
                this.Close();
                this.Dispose();
                baseform = null;
            }
        }

        public virtual void FormLoad()
        {
            InitializeForm();
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

        public virtual void Help() { }

        public virtual void Print() { }

        public virtual void InitializeForm() { }

        private void FrmBasePrintForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                CloseForm();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

    }
}
