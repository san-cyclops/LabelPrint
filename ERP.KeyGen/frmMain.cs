using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ERP.KeyGen
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                stbPass.Text = Encryption.MakePassword(stbBase.Text, txtIdentifier.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Can't make password\n" + ex.Message);
            }
        }
    }
}