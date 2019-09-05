using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;

namespace GENXAPI.Api
{
    public class CustomException
    {
        /// <summary>
        /// WriteExceptionMessageToFile will write to a file in the "Error" directory on the Web Server 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void WriteExceptionMessageToFile(string message, Exception exception)
        {
            // Changes made - Bill G. - 1/27/2018 - If the exception file didn't exist, error was not written
            string fileName = string.Empty;
            try
            {
                string exceptionFileName = string.Empty;
                string applicationPath = System.AppDomain.CurrentDomain.BaseDirectory;
                if (ConfigurationManager.AppSettings["CustomExceptionFileName"] != null)
                {
                    exceptionFileName = ConfigurationManager.AppSettings["CustomExceptionFileName"];
                }
                else
                {
                    exceptionFileName = "CustomException.txt";
                }
                fileName = Path.GetFileNameWithoutExtension(exceptionFileName) + DateTime.Now.ToString("-yyyy-MM-dd") + Path.GetExtension(exceptionFileName);
                string logPath = Path.Combine(applicationPath, "Error");
                fileName = Path.Combine(logPath, fileName);

                if (exception == null)
                {
                    var errorMessages = new StringBuilder();
                    errorMessages.AppendLine("----------------------------------------------" + "\n");
                    errorMessages.AppendLine("DateTime : " + DateTime.Now + "\n");
                    errorMessages.AppendLine("Message : " + message + "\n");
                    //errorMessages.AppendLine("Link : " + exception.HelpLink + "\n");
                    //errorMessages.AppendLine("InnerException : " + exception.InnerException + "\n");
                    if (HttpContext.Current != null)
                    {
                        errorMessages.AppendLine(HttpContext.Current.User.Identity.Name);
                    }
                    //errorMessages.AppendLine("StackTrace: " + exception.StackTrace);
                    errorMessages.AppendLine("----------------------------------------------" + "\n");
                    if (!File.Exists(fileName))
                    {
                        // Make sure path exists and then create file
                        string path = System.IO.Path.GetDirectoryName(fileName);
                        System.IO.Directory.CreateDirectory(path);
                    }
                    // This method will create the file if it doesn't exist
                    File.AppendAllText(fileName, errorMessages.ToString());
                }
                else
                {
                    var errorMessages = new StringBuilder();
                    errorMessages.AppendLine("----------------------------------------------" + "\n");
                    errorMessages.AppendLine("DateTime : " + DateTime.Now + "\n");
                    errorMessages.AppendLine("Message : " + exception.Message + "\n");
                    errorMessages.AppendLine("Link : " + exception.HelpLink + "\n");
                    errorMessages.AppendLine("InnerException : " + exception.InnerException + "\n");
                    if (HttpContext.Current != null)
                    {
                        errorMessages.AppendLine(HttpContext.Current.User.Identity.Name);
                    }
                    //errorMessages.AppendLine("StackTrace: " + exception.StackTrace);
                    errorMessages.AppendLine("StackTrace: " + exception.StackTrace);
                    errorMessages.AppendLine("----------------------------------------------" + "\n");
                    if (!File.Exists(fileName))
                    {
                        // Make sure path exists and then create file
                        string path = System.IO.Path.GetDirectoryName(fileName);
                        System.IO.Directory.CreateDirectory(path);
                    }
                    // This method will create the file if it doesn't exist
                    File.AppendAllText(fileName, errorMessages.ToString());
                }
            }
            catch (Exception ex)
            {
                // Bill G. - 1/27/2018 - Added try/catch to error handler
                try
                {
                    var errorMessages = new StringBuilder();
                    errorMessages.AppendLine("----------------------------------------------" + "\n");
                    errorMessages.AppendLine("DateTime : " + DateTime.Now + "\n");
                    errorMessages.AppendLine("Message : " + ex.Message + "\n");
                    errorMessages.AppendLine("Link : " + ex.HelpLink + "\n");
                    errorMessages.AppendLine("InnerException : " + ex.InnerException + "\n");
                    errorMessages.AppendLine("StackTrace: " + ex.StackTrace);
                    errorMessages.AppendLine("----------------------------------------------" + "\n");
                    if (!File.Exists(fileName))
                    {
                        // Make sure path exists
                        string path = System.IO.Path.GetDirectoryName(fileName);
                        System.IO.Directory.CreateDirectory(path);
                    }
                    // This method will create the file if it doesn't exist
                    File.AppendAllText(fileName, errorMessages.ToString());
                }
                catch { }
            }
        }

        /// <summary>
        /// WriteMessageToFile will write to a file in the "Error" directory on the Web Server 
        /// </summary>
        /// <param name="message"></param>
        public static void WriteMessageToFile(string message)
        {
            string fileName = string.Empty;
            try
            {
                string exceptionFileName = string.Empty;
                string applicationPath = System.AppDomain.CurrentDomain.BaseDirectory;
                if (ConfigurationManager.AppSettings["ApplicionLogFileName"] != null)
                {
                    exceptionFileName = ConfigurationManager.AppSettings["CustomExceptionFileName"];
                }
                else
                {
                    exceptionFileName = "ApplicationLog.txt";
                }
                fileName = Path.GetFileNameWithoutExtension(exceptionFileName) + DateTime.Now.ToString("-yyyy-MM-dd") + Path.GetExtension(exceptionFileName);
                string logPath = Path.Combine(applicationPath, "Error");
                fileName = Path.Combine(logPath, fileName);

                var errorMessages = new StringBuilder();
                errorMessages.AppendLine("----------------------------------------------" + "\n");
                errorMessages.AppendLine("DateTime : " + DateTime.Now + "\n");
                errorMessages.AppendLine("Message : " + message + "\n");
                errorMessages.AppendLine("----------------------------------------------" + "\n");
                if (!File.Exists(fileName))
                {
                    // Make sure path exists and then create file
                    string path = System.IO.Path.GetDirectoryName(fileName);
                    System.IO.Directory.CreateDirectory(path);
                }
                // This method will create the file if it doesn't exist
                File.AppendAllText(fileName, errorMessages.ToString());
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        /// <summary>
        /// WriteDatabaseException will write to a file in the "Error" directory on the Web Server 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void WriteDatabaseException(string message, Exception exception)
        {
            string fileName = string.Empty;
            try
            {
                string exceptionFileName = string.Empty;
                string applicationPath = System.AppDomain.CurrentDomain.BaseDirectory;
                if (ConfigurationManager.AppSettings["CustomExceptionFileName"] != null)
                {
                    exceptionFileName = ConfigurationManager.AppSettings["DatabaseExceptionFileName"];
                }
                else
                {
                    exceptionFileName = "DatabaseException.txt";
                }
                fileName = Path.GetFileNameWithoutExtension(exceptionFileName) + DateTime.Now.ToString("-yyyy-MM-dd") + Path.GetExtension(exceptionFileName);
                string logPath = Path.Combine(applicationPath, "Error");
                fileName = Path.Combine(logPath, fileName);

                if (exception == null)
                {
                    var errorMessages = new StringBuilder();
                    errorMessages.AppendLine("----------------------------------------------" + "\n");
                    errorMessages.AppendLine("DateTime : " + DateTime.Now + "\n");
                    errorMessages.AppendLine("Message : " + message + "\n");
                    //errorMessages.AppendLine("Link : " + exception.HelpLink + "\n");
                    //errorMessages.AppendLine("InnerException : " + exception.InnerException + "\n");
                    if (HttpContext.Current != null)
                    {
                        errorMessages.AppendLine(HttpContext.Current.User.Identity.Name);
                    }
                    //errorMessages.AppendLine("StackTrace: " + exception.StackTrace);
                    //errorMessages.AppendLine("StackTrace: " + exception.StackTrace);
                    errorMessages.AppendLine("----------------------------------------------" + "\n");
                    if (!File.Exists(fileName))
                    {
                        // Make sure path exists and then create file
                        string path = System.IO.Path.GetDirectoryName(fileName);
                        System.IO.Directory.CreateDirectory(path);
                    }
                    // This method will create the file if it doesn't exist
                    File.AppendAllText(fileName, errorMessages.ToString());
                }
                else
                {
                    var errorMessages = new StringBuilder();
                    errorMessages.AppendLine("----------------------------------------------" + "\n");
                    errorMessages.AppendLine("DateTime : " + DateTime.Now + "\n");
                    errorMessages.AppendLine("Message : " + exception.Message + "\n");
                    errorMessages.AppendLine("Link : " + exception.HelpLink + "\n");
                    errorMessages.AppendLine("InnerException : " + exception.InnerException + "\n");
                    if (HttpContext.Current != null)
                    {
                        errorMessages.AppendLine(HttpContext.Current.User.Identity.Name);
                    }
                    //errorMessages.AppendLine("StackTrace: " + exception.StackTrace);
                    errorMessages.AppendLine("StackTrace: " + exception.StackTrace);
                    errorMessages.AppendLine("----------------------------------------------" + "\n");
                    if (!File.Exists(fileName))
                    {
                        // Make sure path exists and then create file
                        string path = System.IO.Path.GetDirectoryName(fileName);
                        System.IO.Directory.CreateDirectory(path);
                    }
                    // This method will create the file if it doesn't exist
                    File.AppendAllText(fileName, errorMessages.ToString());
                }

            }
            catch (Exception ex)
            {
                // Bill G. - 1/27/2018 - Added try/catch to error handler
                try
                {
                    var errorMessages = new StringBuilder();
                    errorMessages.AppendLine("----------------------------------------------" + "\n");
                    errorMessages.AppendLine("DateTime : " + DateTime.Now + "\n");
                    errorMessages.AppendLine("Message : " + ex.Message + "\n");
                    errorMessages.AppendLine("Link : " + ex.HelpLink + "\n");
                    errorMessages.AppendLine("InnerException : " + ex.InnerException + "\n");
                    errorMessages.AppendLine("StackTrace: " + ex.StackTrace);
                    errorMessages.AppendLine("----------------------------------------------" + "\n");
                    if (!File.Exists(fileName))
                    {
                        // Make sure path exists and then create file
                        string path = System.IO.Path.GetDirectoryName(fileName);
                        System.IO.Directory.CreateDirectory(path);
                    }
                    // This method will create the file if it doesn't exist
                    File.AppendAllText(fileName, errorMessages.ToString());
                }
                catch { }
            }
        }
    }
}
