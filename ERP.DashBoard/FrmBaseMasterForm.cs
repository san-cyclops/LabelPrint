using ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.DashBoard
{
    public partial class FrmBaseMasterForm : Form
    {
        public FrmBaseMasterForm()
        {
            InitializeComponent();
        }

        private static FrmBaseMasterForm baseform;


        public static FrmBaseMasterForm GetBaseForm
        {
            get { return baseform; }
            set { baseform = value; }
        }

        private void FrmBaseMasterForm_Load(object sender, EventArgs e)
        {
            FormLoad();
        }


        public virtual void ClearForm()
        {
            Common.ClearForm(this);
            InitializeForm();
        }

        public virtual void CloseForm(string formName)
        {
            if (Toast.Show(formName,"Do you want to close this form?","", Toast.messageType.Question, Toast.messageAction.General).Equals(DialogResult.Yes))
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

        public virtual void Save() { }

        public virtual void Delete() { }

        public virtual void Clear() { }

        public virtual void View() { }

        public virtual void Help() { }

        public virtual void Print() { }

        public virtual void InitializeForm() { }

        private void FrmBaseMasterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                CloseForm(this.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
