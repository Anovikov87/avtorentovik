using System;
using System.IO;


namespace Avtorentovik.Utils
{
    public static class VLog
    {
        private static string _logName = "";
        private static readonly object ThisLock = new object();

        public static void Init()
        {
            var logdir = Path.GetTempPath() + "Avtorentovik\\";
            if (!Directory.Exists(logdir))
                Directory.CreateDirectory(logdir);
            _logName = logdir + "Log_" + DateTime.UtcNow.ToString("yy_MM_dd_HH_mm_ss") + ".log";
        }

        public static void Log(string value)
        {
            lock (ThisLock)
            {
                var logMessage = $"{DateTime.UtcNow.ToString("yy_MM_dd_HH_mm_ss")} - {value}";
                File.AppendAllText(_logName, logMessage + Environment.NewLine);
            }
        }

        public static void Log(Exception ex)
        {
            lock (ThisLock)
            {                
                var logMessage = $"{DateTime.UtcNow.ToString("yy_MM_dd_HH_mm_ss")} - Exception: {ex.Message}";
                File.AppendAllText(_logName, logMessage + Environment.NewLine);
                if (ex.InnerException != null)
                {                    
                    logMessage = $"{DateTime.UtcNow.ToString("yy_MM_dd_HH_mm_ss")} - {ex.InnerException.Message}";
                    File.AppendAllText(_logName, logMessage + Environment.NewLine);
                    logMessage = $"{DateTime.UtcNow.ToString("yy_MM_dd_HH_mm_ss")} - {ex.InnerException.Source}";
                    File.AppendAllText(_logName, logMessage + Environment.NewLine);
                }
            }
        }
    }
}
