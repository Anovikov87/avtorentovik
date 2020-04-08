using System;
using System.Threading;
using System.Windows.Forms;
using Avtorentovik.Utils;

namespace Avtorentovik
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            VLog.Init();
            Application.Run(new LoginForm());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            VLog.Log("Необработанная ошибка:"+args.ExceptionObject);
            MessageBox.Show(args.ExceptionObject.ToString());
        }
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs args)
        {
            var message = args.Exception.ToString();
            VLog.Log(message);
            MessageBox.Show(message);
        }
    }
}
