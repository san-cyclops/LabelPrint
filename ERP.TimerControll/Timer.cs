using ERP.Service;
using ERP.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ERP.TimerControll.Model;

namespace ERP.TimerControll
{
    public partial class Frm_Timer : Telerik.WinControls.UI.RadForm
    {

        //PosSalesSummeryService posSalesSummeryService = new PosSalesSummeryService();

        public Frm_Timer()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                Visible = false; // Hide form window.
                ShowInTaskbar = false; // Remove from taskbar.
                Opacity = 0;
                InitializeForm();

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, MethodInfo.GetCurrentMethod().Name.ToString(), this.Name, Logger.logtype.ErrorLog, Common.LoggedUserId);
            }
        }

        private void InitializeForm()
        {
            dtp_SystemDate.Value = DateTime.Now;
            timer1.Enabled = true;

        }

        private void timer_Tick(object sender, EventArgs e)
        {

            listBox1.Items.Add(DateTime.Now.ToLongTimeString() + "," + DateTime.Now.ToLongDateString());
            //   SendSMS();
            GetSalesSummery();
        }

        private void btn_stop_click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void btn_start_click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }


        public void SendSMS(int CreditSale, string NetSale, string CashSale)
        {

            List<string> phoneNumber = new List<string>();
            phoneNumber.Add("94763162000");
            phoneNumber.Add("94710101554");

            foreach (string number in phoneNumber)
            {
                try
                {
                    string u_name = "cafela009";
                    string passwd = "cafela@999";
                    string postURL = "https://digitalreachapi.dialog.lk/refresh_token.php";

                    SmsConfig smsConfig = new SmsConfig();
                    smsConfig.u_name = "cafela009";
                 //   smsConfig.passwd = "cafela@999";

                    using (var client = new HttpClient(
                   new HttpClientHandler
                   {
                       AutomaticDecompression = DecompressionMethods.GZip
                   }))
                    {

                        StringContent contentToSend = null;

                        var objectSerialized = JsonConvert.SerializeObject(smsConfig, Newtonsoft.Json.Formatting.Indented,
                        new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                        contentToSend = new StringContent(objectSerialized, Encoding.UTF8, "application/json");

                        HttpResponseMessage resp = null;

                        resp = client.PostAsync(postURL, contentToSend).Result;

                        SmsRs smsRs = new SmsRs();
                        smsRs = resp.Content.ReadAsAsync<SmsRs>().Result;

                     //  smsRs = resp.Content.ReadAsStringAsync<SmsRs>.Result;

                        // ********send sms*******************

                        string postURLSms = "https://digitalreachapi.dialog.lk/camp_req.php ";


                        CreateSms CreateSms = new CreateSms();

                        DateTime s_timeDate = DateTime.Now.AddMinutes(1);
                        DateTime e_timeDate = DateTime.Now.AddMinutes(2);
                        string s_time = string.Format("{0:yyyy-MM-dd HH:mm:00}", s_timeDate);
                        string e_time = string.Format("{0:yyyy-MM-dd HH:mm:00}", e_timeDate);


                        //string phone = sendTo.Trim().Substring(1);
                        //CreateSms.msisdn = "94" + phone;
                        string total = Convert.ToString(CreditSale);
                        CreateSms.msisdn = number;
                        CreateSms.mt_port = "LaDefense";
                        CreateSms.channel = "1";
                        CreateSms.s_time = s_time;
                        CreateSms.e_time = e_time;
                        CreateSms.msg = "CashSale=" + CashSale + "\n" + "CreditSale=" + total + ".00" + "\n" + "NetSale=" + NetSale;
                        CreateSms.callback_url = "www.farholidays.com";


                        using (var clientSms = new HttpClient(
                      new HttpClientHandler
                      {
                          AutomaticDecompression = DecompressionMethods.GZip
                      }))
                        {

                            StringContent contentToSendSms = null;

                            var objectSerializedSms = JsonConvert.SerializeObject(CreateSms, Newtonsoft.Json.Formatting.Indented,
                                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                            contentToSendSms = new StringContent(objectSerializedSms, Encoding.UTF8, "application/json");

                            client.DefaultRequestHeaders.Add("Authorization", smsRs.access_token);


                            HttpResponseMessage respSms = null;

                            respSms = client.PostAsync(postURLSms, contentToSendSms).Result;

                            SmsStatus status = new SmsStatus();
                            status = respSms.Content.ReadAsAsync<SmsStatus>().Result;
                            Logger.SMSWriteLog("Message Send");

                        }
                        // return "Welcome to Elixir Points! Start collecting points, Plus get access to other exclusive offers.";

                    }
                }
                catch (Exception ex)
                {
                    Logger.SMSWriteLog(ex.ToString());

                    foreach (string numbers in phoneNumber)
                    {

                        string u_name = "cafela009";
                        string passwd = "cafela@999";
                        string postURL = "https://digitalreachapi.dialog.lk/refresh_token.php";

                        SmsConfig smsConfig = new SmsConfig();
                        smsConfig.u_name = "cafela009";
                        smsConfig.passwd = "cafela@999";

                        using (var client = new HttpClient(
                       new HttpClientHandler
                       {
                           AutomaticDecompression = DecompressionMethods.GZip
                       }))
                        {

                            StringContent contentToSend = null;

                            var objectSerialized = JsonConvert.SerializeObject(smsConfig, Newtonsoft.Json.Formatting.Indented,
                            new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                            contentToSend = new StringContent(objectSerialized, Encoding.UTF8, "application/json");

                            HttpResponseMessage resp = null;

                            resp = client.PostAsync(postURL, contentToSend).Result;

                            SmsRs smsRs = new SmsRs();
                            smsRs = resp.Content.ReadAsAsync<SmsRs>().Result;
                            //  smsRs = resp.Content.;

                            // ********send sms*******************

                            string postURLSms = "https://digitalreachapi.dialog.lk/camp_req.php ";


                            CreateSms CreateSms = new CreateSms();

                            DateTime s_timeDate = DateTime.Now.AddMinutes(1);
                            DateTime e_timeDate = DateTime.Now.AddMinutes(2);
                            string s_time = string.Format("{0:yyyy-MM-dd HH:mm:00}", s_timeDate);
                            string e_time = string.Format("{0:yyyy-MM-dd HH:mm:00}", e_timeDate);


                            //string phone = sendTo.Trim().Substring(1);
                            //CreateSms.msisdn = "94" + phone;
                            string total = Convert.ToString(CreditSale);
                            CreateSms.msisdn = number;
                            CreateSms.mt_port = "LaDefense";
                            CreateSms.channel = "1";
                            CreateSms.s_time = s_time;
                            CreateSms.e_time = e_time;
                            CreateSms.msg = "CashSale=" + CashSale + "\n" + "CreditSale=" + total + ".00" + "\n" + "NetSale=" + NetSale;
                            CreateSms.callback_url = "www.farholidays.com";


                            using (var clientSms = new HttpClient(
                          new HttpClientHandler
                          {
                              AutomaticDecompression = DecompressionMethods.GZip
                          }))
                            {

                                StringContent contentToSendSms = null;

                                var objectSerializedSms = JsonConvert.SerializeObject(CreateSms, Newtonsoft.Json.Formatting.Indented,
                                    new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                                contentToSendSms = new StringContent(objectSerializedSms, Encoding.UTF8, "application/json");

                                client.DefaultRequestHeaders.Add("Authorization", smsRs.access_token);


                                HttpResponseMessage respSms = null;

                                respSms = client.PostAsync(postURLSms, contentToSendSms).Result;

                                SmsStatus status = new SmsStatus();
                                status = respSms.Content.ReadAsAsync<SmsStatus>().Result;

                            }
                            // return "Welcome to Elixir Points! Start collecting points, Plus get access to other exclusive offers.";

                        }

                    }
                    //region Variables 

                }
            }
        }

        private void GetSalesSummery()
        {

            
             DateTime currentTime = DateTime.Now;
            string time = currentTime.ToLongTimeString();
            if (time == "1:00:00 PM" || time == "9:00:00 PM")
            {
   
                Logger.SMSWriteLog( "inside of Method-GetSalesSummery");
                try
                {

                    int locationId = 1;
                    int terminalId = 1;
                    DataTable posTerminals = null;
                    DateTime dateFrom = DateTime.Now;
                    DateTime dateTo = DateTime.Now;
                    DataTable SalesSummeryTotable = null;
                    string NetSale = string.Empty;
                    string CashSale = string.Empty;
                    int CreditAmount = 0;
                    string MasterCardSale, VisaCardSale, AmexCardSale, DebitCardSale = string.Empty;

                    PosSalesSummeryService posSalesSummeryService = new PosSalesSummeryService();

                    posSalesSummeryService = new PosSalesSummeryService();

                    if (posSalesSummeryService.ViewCurrentSale(locationId, terminalId, dateFrom, dateTo) == true)
                    {
                        SalesSummeryTotable = posSalesSummeryService.GetSalesSum();

                        foreach (DataRow row in SalesSummeryTotable.Rows)
                        {
                            NetSale = row["nett"].ToString();
                            CashSale = row["cashsale"].ToString();
                            MasterCardSale = row["MasterCard"].ToString();
                            VisaCardSale = row["VisaCard"].ToString();
                            AmexCardSale = row["AmexCard"].ToString();

                            string ms = MasterCardSale.Replace(".00", "");
                            string vs = VisaCardSale.Replace(".00", "");
                            string As = AmexCardSale.Replace(".00", "");

                            CreditAmount = Convert.ToInt32(ms) + Convert.ToInt32(vs) + Convert.ToInt32(As);

                          
                            SendSMS(CreditAmount, NetSale, CashSale);
                            Logger.SMSWriteLog("Send Message Ok");
                        }


                    }
                    else
                    {
                        Logger.SMSWriteLog("Error! Server");
                        SendErrorSms();
                        return;
                    }


                }
                catch (Exception ex)
                {
                    Logger.SMSWriteLog(ex.ToString());
                }

            }else if ((time == "1:10:00 PM" || time == "9:10:00 PM")) {

                Logger.SMSWriteLog("inside of Method-GetSalesSummery");
                try
                {

                    int locationId = 1;
                    int terminalId = 1;
                    DataTable posTerminals = null;
                    DateTime dateFrom = DateTime.Now;
                    DateTime dateTo = DateTime.Now;
                    DataTable SalesSummeryTotable = null;
                    string NetSale = string.Empty;
                    string CashSale = string.Empty;
                    int CreditAmount = 0;
                    string MasterCardSale, VisaCardSale, AmexCardSale, DebitCardSale = string.Empty;

                    PosSalesSummeryService posSalesSummeryService = new PosSalesSummeryService();

                    posSalesSummeryService = new PosSalesSummeryService();

                    if (posSalesSummeryService.ViewCurrentSale(locationId, terminalId, dateFrom, dateTo) == true)
                    {
                        SalesSummeryTotable = posSalesSummeryService.GetSalesSum();

                        foreach (DataRow row in SalesSummeryTotable.Rows)
                        {
                            NetSale = row["nett"].ToString();
                            CashSale = row["cashsale"].ToString();
                            MasterCardSale = row["MasterCard"].ToString();
                            VisaCardSale = row["VisaCard"].ToString();
                            AmexCardSale = row["AmexCard"].ToString();

                            string ms = MasterCardSale.Replace(".00", "");
                            string vs = VisaCardSale.Replace(".00", "");
                            string As = AmexCardSale.Replace(".00", "");

                            CreditAmount = Convert.ToInt32(ms) + Convert.ToInt32(vs) + Convert.ToInt32(As);


                            SendSMS(CreditAmount, NetSale, CashSale);
                            Logger.SMSWriteLog("Send Message Ok");
                        }


                    }
                    else
                    {
                        Logger.SMSWriteLog("Error! Server");
                        SendErrorSms();
                        return;
                    }


                }
                catch (Exception ex)
                {
                    Logger.SMSWriteLog(ex.ToString());
                }

            }
        }
        public void SendErrorSms()
        {
            List<string> phoneNumber = new List<string>();
            phoneNumber.Add("94763162019");
            phoneNumber.Add("94763164884");
            phoneNumber.Add("94763164883");


            foreach (string number in phoneNumber)
            {
                try
                {
                    string u_name = "cafela009";
                    string passwd = "cafela@999";
                    string postURL = "https://digitalreachapi.dialog.lk/refresh_token.php";

                    SmsConfig smsConfig = new SmsConfig();
                    smsConfig.u_name = "cafela009";
                    smsConfig.passwd = "cafela@999";

                    using (var client = new HttpClient(
                   new HttpClientHandler
                   {
                       AutomaticDecompression = DecompressionMethods.GZip
                   }))
                    {

                        StringContent contentToSend = null;

                        var objectSerialized = JsonConvert.SerializeObject(smsConfig, Newtonsoft.Json.Formatting.Indented,
                        new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                        contentToSend = new StringContent(objectSerialized, Encoding.UTF8, "application/json");

                        HttpResponseMessage resp = null;

                        resp = client.PostAsync(postURL, contentToSend).Result;

                        SmsRs smsRs = new SmsRs();
                        smsRs = resp.Content.ReadAsAsync<SmsRs>().Result;
                        //  smsRs = resp.Content.;

                        // ********send sms*******************

                        string postURLSms = "https://digitalreachapi.dialog.lk/camp_req.php ";


                        CreateSms CreateSms = new CreateSms();

                        DateTime s_timeDate = DateTime.Now.AddMinutes(1);
                        DateTime e_timeDate = DateTime.Now.AddMinutes(2);
                        string s_time = string.Format("{0:yyyy-MM-dd HH:mm:00}", s_timeDate);
                        string e_time = string.Format("{0:yyyy-MM-dd HH:mm:00}", e_timeDate);


                        //string phone = sendTo.Trim().Substring(1);
                        //CreateSms.msisdn = "94" + phone;

                        CreateSms.msisdn = number;
                        CreateSms.mt_port = "LaDefense";
                        CreateSms.channel = "1";
                        CreateSms.s_time = s_time;
                        CreateSms.e_time = e_time;
                        CreateSms.msg = "Something Went Wrong In Server please Check!";
                        CreateSms.callback_url = "www.farholidays.com";


                        using (var clientSms = new HttpClient(
                      new HttpClientHandler
                      {
                          AutomaticDecompression = DecompressionMethods.GZip
                      }))
                        {

                            StringContent contentToSendSms = null;

                            var objectSerializedSms = JsonConvert.SerializeObject(CreateSms, Newtonsoft.Json.Formatting.Indented,
                                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                            contentToSendSms = new StringContent(objectSerializedSms, Encoding.UTF8, "application/json");

                            client.DefaultRequestHeaders.Add("Authorization", smsRs.access_token);


                            HttpResponseMessage respSms = null;

                            respSms = client.PostAsync(postURLSms, contentToSendSms).Result;

                            SmsStatus status = new SmsStatus();
                            status = respSms.Content.ReadAsAsync<SmsStatus>().Result;

                        }

                    }
                }
                catch (Exception ex)
                {
                    Logger.SMSWriteLog(ex.ToString());
                }


            }


        }
    }
}
