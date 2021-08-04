using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.TimerControll.Model
{
    class CreateSms
    {
        public string msisdn { get; set; }

        public string mt_port { get; set; }

        public string channel { get; set; }

        public string s_time { get; set; }

        public string e_time { get; set; }

        public string msg { get; set; }

        public string callback_url { get; set; }
    }
}
