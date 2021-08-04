using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Utility
{
    public static class Logger
    {
        #region enum
        //public enum logtype
        //{
        //    Event,
        //    ErrorLog
        //}
        #endregion
        #region Members
        //private static readonly ILog logger = LogManager.GetLogger(typeof(Logger));
        #endregion

        /*
        #region Constuctors

        static Logger()
        {
            XmlConfigurator.Configure();
        }

        public static void WriteLog(Exception ex, string methodName, string formName = "Default", logtype LogType = logtype.ErrorLog, long LocationID = 1)
        {

            string logFormated = @"  " + ex.ToString() + "   |  Method Name " + methodName + formName + LogType + LocationID + "  |  Machine name -" + Environment.MachineName;
            logger.Error(logFormated);
            Toast.Show("Logger", ex.Message.ToString(), "", Toast.messageType.Error, Toast.messageAction.General);
        }


        public static void WriteLog(string log, string methodName, string formName = "Default", logtype LogType = logtype.ErrorLog, long LocationID = 1)
        {
            string logFormated = @"  " + log.ToString() + "   |  Method Name " + methodName + formName + LogType + LocationID + "  |  Machine name -" + Environment.MachineName;
            logger.Info(logFormated);
            Toast.Show("Logger",log,"", Toast.messageType.Error, Toast.messageAction.General);
        }

        public static void WriteLog(Exception ex, string methodName)
        {
            string logFormated = @"  " + ex.ToString() + "   |  Method Name " + methodName + "  |  Machine name -" + Environment.MachineName;
            logger.Error(logFormated);
            Toast.Show("Logger",ex.Message.ToString(),"", Toast.messageType.Error, Toast.messageAction.General);
        }

        #endregion



        */


    

       
        public static string debugFile = string.Empty;
        public static string debugFilePath = @"C:\LOG\";

        public enum logtype
        {
            Event,
            ErrorLog
        }

        public static void SetPathLog(string path)
        {
            if (String.IsNullOrEmpty(path))
                debugFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location);

            else
                debugFilePath = path;
            
        }



        public static void WriteLog(Exception log, string methodName, string formName = "Default", logtype LogType = logtype.ErrorLog, long LocationID = 1)
        {
            // No path

            try
            {
                //if (debugFilePath == string.Empty)
                //    debugFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location);

                
                //string tmpdebugFilePath;
                //switch (LogType)
                //{
                //    case logtype.ErrorLog:
                //        var lineNumber = new System.Diagnostics.StackTrace(log, true).GetFrame(0).GetFileLineNumber();
                //        tmpdebugFilePath = debugFilePath + "Error.log";
                //        System.IO.File.AppendAllText(tmpdebugFilePath, "Date Time : [" + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] " + "| Version : " + Common.Version.Trim() + "| User : " + Common.LoggedUser.Trim() + "| Location : " + LocationID.ToString() + "| Error Source : " + methodName.Trim() + "| Form Name : " + formName.Trim() + "| Error : " + log.Message.ToString().Trim() + "\r\n" + lineNumber.ToString()  + "\r\n");
                //        Toast.Show("", "", log.Message.ToString().Trim(), Toast.messageType.Error, Toast.messageAction.General);
                //        break;
                //    case logtype.Event:
                //        tmpdebugFilePath = debugFilePath + @"\Events";
                //        bool isExists = System.IO.Directory.Exists(tmpdebugFilePath);
                //        if(!isExists)
                //            System.IO.Directory.CreateDirectory(tmpdebugFilePath);
                //        tmpdebugFilePath = debugFilePath + @"\Events\Event-" + DateTime.Now.ToString("dd-MM-yyyy") + ".log";
                //        System.IO.File.AppendAllText(@tmpdebugFilePath, "Date Time : [" + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] " + "| Version : " + Common.Version.Trim() + "| User : " + Common.LoggedUser.Trim() + "| Location : " + LocationID.ToString() + "| Event Source : " + methodName.Trim() + "| Event Name : " + formName.Trim() + "| Event : " + log.Message.ToString().Trim() + "\r\n");
                //        break;
                //    default:
                //        tmpdebugFilePath = debugFilePath + "Error.log";
                //        System.IO.File.AppendAllText(tmpdebugFilePath, "Date Time : [" + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] " + "| Version : " + Common.Version.Trim() + "| User : " + Common.LoggedUser.Trim() + "| Location : " + LocationID.ToString() + "| Error Source : " + methodName.Trim() + "| Form Name : " + formName.Trim() + "| Error : " + log.Message.ToString().Trim() + "\r\n");

                //        break;
                //}




            }
            catch (Exception exc)
            {

            }
        }

        public static void WriteLog(string log, string methodName,string formName="Default", logtype LogType = logtype.ErrorLog, long LocationID = 1)
        {
            // No path

            try
            {
                if (debugFilePath == string.Empty)
                    debugFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location);


                string tmpdebugFilePath;
                switch (LogType)
                {
                    case logtype.ErrorLog:
                        tmpdebugFilePath = debugFilePath + "Error.log";
                            System.IO.File.AppendAllText(tmpdebugFilePath, "Date Time : [" + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] " + "| Version : " + Common.Version.Trim() + "| User : " + Common.LoggedUser.Trim() + "| Location : " + LocationID.ToString() + "| Error Source : " + methodName.Trim() + "| Form Name : " + formName.Trim() + "| Error : " + log.Trim() + "\r\n");
                            Toast.Show("","","", Toast.messageType.Error, Toast.messageAction.General);
                            
                        break;
                    case logtype.Event:
                        tmpdebugFilePath = debugFilePath + @"\Events";
                        bool isExists = System.IO.Directory.Exists(tmpdebugFilePath);
                        if(!isExists)
                            System.IO.Directory.CreateDirectory(tmpdebugFilePath);
                        tmpdebugFilePath = debugFilePath + @"\Events\Event-" + DateTime.Now.ToString("dd-MM-yyyy") + ".log";
                        System.IO.File.AppendAllText(@tmpdebugFilePath, "Date Time : [" + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] " + "| Version : " + Common.Version.Trim() + "| User : " + Common.LoggedUser.Trim() + "| Location : " + LocationID.ToString() + "| Event Source : " + methodName.Trim() + "| Event Name : " + formName.Trim() + "| Event : " + log.Trim() + "\r\n");
                        break;
                    default:
                        tmpdebugFilePath = debugFilePath + "Error.log";
                            System.IO.File.AppendAllText(tmpdebugFilePath, "Date Time : [" + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] " + "| Version : " + Common.Version.Trim() + "| User : " + Common.LoggedUser.Trim() + "| Location : " + LocationID.ToString() + "| Error Source : " + methodName.Trim() + "| Form Name : " + formName.Trim() + "| Error : " + log.Trim() + "\r\n");

                        break;
                }



           
            }
                catch (Exception exc)
            {

            }

        }
        public static void SMSWriteLog(string log)
        {
            // No path

            try
            {
                if (debugFilePath == string.Empty)
                    debugFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location);


                string tmpdebugFilePath;
              
                        tmpdebugFilePath = debugFilePath + @"\Events";
                        bool isExists = System.IO.Directory.Exists(tmpdebugFilePath);
                        if (!isExists)
                            System.IO.Directory.CreateDirectory(tmpdebugFilePath);
                        tmpdebugFilePath = debugFilePath + @"\Events\Event-" + DateTime.Now.ToString("dd-MM-yyyy") + ".log";
                        System.IO.File.AppendAllText(@tmpdebugFilePath, "Date Time : [" + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] " +  "| Event : " + log.Trim() + "\r\n");
                 




            }
            catch (Exception exc)
            {

            }

        }

    }
}
