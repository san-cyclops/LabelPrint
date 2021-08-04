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
using System.Net.Mail;
using System.Web.Services;
using System.Net;
using System.Reflection;
using ERP.Utility;
using ERP.Report.GUI;
//using Outlook = Microsoft.Office.Interop.Outlook;

namespace ERP.Report
{
    public partial class FrmReportViewer : Form
    {
        ReportDocument cryRpt;
        string pdfFile = "c:\\csharp.net-informations.pdf";
        public static string fromEmailId, emailId, subject, message, fileName;

        public FrmReportViewer()
        {
            InitializeComponent();
        }

        private void FrmReportViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void FrmReportViewer_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.P)
            //{
            //    crRptViewer.PrintReport();
            //}
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.P)
            {
                crRptViewer.PrintReport();
            }

        }

        private void FrmReportViewer_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
            button1.Focus();
        }

        private void crRptViewer_Click(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
            button1.Focus();

            //this.ActiveControl = crRptViewer;
            //crRptViewer.Focus();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                crRptViewer.PrintReport();
            }
        }

        private void crRptViewer_Load(object sender, EventArgs e)
        {
            this.ActiveControl = crRptViewer;
            crRptViewer.Focus();
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            try
            {
                //FrmEMailForm frmEMailForm = new FrmEMailForm();
                //frmEMailForm.ShowDialog();
                SendEmail();
                //SendEMailThroughGmail();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void ExportReport() 
        {
            ExportOptions CrExportOptions=new ExportOptions();
            cryRpt = new ReportDocument();
            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            CrDiskFileDestinationOptions.DiskFileName = pdfFile;
            CrExportOptions = cryRpt.ExportOptions;
            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            CrExportOptions.FormatOptions = CrFormatTypeOptions;
            cryRpt.Export();
        }

        public void SetSendingOptions(string fromEmailIdPrm, string emailIdPrm, string subjectPrm, string messagePrm) 
        {
            fromEmailId = fromEmailIdPrm;
            emailId = emailIdPrm;
            subject = subjectPrm;
            message = messagePrm;
        }

        public void SendEmail() 
        {
            try
            {
                //Outlook.Application oApp = new Outlook.Application();
                //Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

                //oMsg.HTMLBody = message;
                //String sDisplayName = "MyAttachment";
                //int iPosition = (int)oMsg.Body.Length + 1;
                //int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                //Outlook.Attachment oAttach = oMsg.Attachments.Add(@"C:\\crm.jpg", iAttachType, iPosition, sDisplayName);

                //oMsg.Subject = subject;

                //Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                //Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(emailId);
                //oRecip.Resolve();

                //oMsg.Send();

                //oRecip = null;
                //oRecips = null;
                //oMsg = null;
                //oApp = null;
            }
            catch (Exception ex) 
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedLocationID);
            }
        }

        public void SendEMailThroughGmail() 
        {
            try
            {
                //Mail Message
                MailMessage mM = new MailMessage();
                //Mail Address
                mM.From = new MailAddress(fromEmailId);
                //receiver email id
                mM.To.Add(emailId);
                //subject of the email
                mM.Subject = subject;
                //deciding for the attachment
                mM.Attachments.Add(new Attachment(@"C:\\crm.jpg"));
                //add the body of the email
                mM.Body = message;
                mM.IsBodyHtml = true;
                //SMTP client
                SmtpClient sC = new SmtpClient("smtp.gmail.com");
                //port number for Gmail mail
                sC.Port = 587;
                //credentials to login in to Gmail account
                sC.Credentials = new NetworkCredential(fromEmailId, "password");
                //enabled SSL
                sC.EnableSsl = true;
                //Send an email
                sC.Send(mM);
            }//end of try block
            catch (Exception ex)
            {

            }//end of catch
        }//end of 

    }
}
