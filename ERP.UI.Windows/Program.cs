using ERP.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.UI.Windows
{
    static class Program
    {
        public static string FileName = string.Empty;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            // Validate Date Time Format
            //if (!Common.ValidateMachineDateTimeFromat())
            //{ return; }

            Common.LoggedPcName = (Environment.MachineName.Length > 50 ? Environment.MachineName .Substring(0,50): Environment.MachineName);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmBarcode());
        }

      
    }
}
