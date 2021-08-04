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


namespace ERP.Utility
{
    public enum ERPMessageBoxIcon { ERROR, INFO, QUESTION, CAUTION }
    public enum ERPMessageBoxBtn { OK, CANCEL_OK, YES_NO, YES_NO_CANCEL }
    public partial class FrmMessageBox : Form
    {
        private static FrmMessageBox singleton = null;
        FrmMessageBox()
        {
            InitializeComponent();
        }
        public static DialogResult ShowMsg(string msg, string caption, ERPMessageBoxBtn btn, ERPMessageBoxIcon icon)
        {
            if (msg.Length > 210) throw new Exception("Message Length should be less than 210 characters");
            if (singleton == null || singleton.IsDisposed)
                singleton = new FrmMessageBox();
            switch (icon)
            {
               
            }
            switch (btn)
            {
                case ERPMessageBoxBtn.OK:
                    singleton.btnOk.Visible = true;
                    singleton.btnCancel.Visible = false;
                    singleton.btnYes.Visible = false;
                    singleton.btnNo.Visible = false;
                    singleton.AcceptButton = singleton.btnOk;
                    break;
                case ERPMessageBoxBtn.CANCEL_OK:
                    singleton.btnOk.Visible = true;
                    singleton.btnCancel.Visible = true;
                    singleton.btnYes.Visible = false;
                    singleton.btnNo.Visible = false;
                    singleton.AcceptButton = singleton.btnOk;
                    break;
                case ERPMessageBoxBtn.YES_NO:
                    singleton.btnOk.Visible = false;
                    singleton.btnCancel.Visible = false;
                    singleton.btnYes.Visible = true;
                    singleton.btnNo.Visible = true;
                    singleton.AcceptButton = singleton.btnYes;
                    break;
                case ERPMessageBoxBtn.YES_NO_CANCEL:
                    singleton.btnOk.Visible = false;
                    singleton.btnCancel.Visible = true;
                    singleton.btnYes.Visible = true;
                    singleton.btnNo.Visible = true;
                    singleton.btnYes.Location = new System.Drawing.Point(125, 111);
                    singleton.btnNo.Location = new System.Drawing.Point(206, 111);
                    singleton.btnCancel.Location = new System.Drawing.Point(287, 111);
                    singleton.AcceptButton = singleton.btnYes;
                    break;
            }

            singleton.Text = caption;
            singleton.lblTxtMessage.Text = msg;
            return singleton.ShowDialog();
        }

        public static DialogResult ShowMsg(string msg)
        {
            if (singleton == null || singleton.IsDisposed)
                singleton = new FrmMessageBox();
            return FrmMessageBox.ShowMsg(msg, "Information", ERPMessageBoxBtn.OK, ERPMessageBoxIcon.INFO);
        }

        public static DialogResult ShowMsg(string msg, string caption)
        {
            if (singleton == null || singleton.IsDisposed)
                singleton = new FrmMessageBox();
            return FrmMessageBox.ShowMsg(msg, caption, ERPMessageBoxBtn.OK, ERPMessageBoxIcon.INFO);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Dispose();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Dispose();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            Dispose();
        }

        private void FrmMessageBox_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = this.Text;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }
    }
}
