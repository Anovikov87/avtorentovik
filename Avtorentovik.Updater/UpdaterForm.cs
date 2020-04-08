using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Web;
using Avtorentovik.Utils;

namespace Avtorentovik.Updater
{
    public partial class UpdaterForm : XtraForm
    {
        private const string Version = "1.0.0.0";
        private string _serverUrl = "avtorentovik.ru";
        private readonly Task _task;
        private bool update = false;
        public UpdaterForm()
        {
            _task = new Task(() =>
            {                                             
                update = false;
                try
                {                    
                    VLog.Log("Шлём запрос на проверку версии");
                    var url = new Uri("http://"+_serverUrl+"/api/crm/version");
                    var cookies = new CookieContainer();
                    var request = HttpWebRequest.Create(url) as HttpWebRequest;
                    request.CookieContainer = cookies;
                    request.ServicePoint.Expect100Continue = false;
                    request.Method = "GET";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
                    request.PreAuthenticate = true;                    
                    StreamReader objReader = new StreamReader(request.GetResponse().GetResponseStream());
                    var response = objReader.ReadToEnd();
                    var decoded = HttpUtility.HtmlDecode(Regex.Unescape(response));
                    var siteversion = decoded.Split(':')[1].Split('"')[1];
                    //{"version":"1.00.000.000"}
                    VLog.Log("Получили версию: "+ siteversion);                   
                    if (Version != siteversion)
                    {
                        try
                        {
                            var ver = Version.Split('.');
                            var dec = siteversion.Split('.');
                            for (int i = 0; i < ver.Count(); i++)
                            {
                                var ver1 = int.Parse(ver[i]);
                                var dec1 = int.Parse(dec[i]);
                                if (ver1 < dec1)
                                {
                                    update = true;
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            VLog.Log(ex);
                            //MessageBox.Show(ex.Message);
                        }
                    }                                      
                }
                catch (Exception ex)
                {
                    VLog.Log(ex);
                    MessageBox.Show(ex.Message);                    
                }
              
            });
            _task.Start();

            InitializeComponent();
        }
        private void TaskTimer_Tick(object sender, EventArgs e)
        {
            if (_task?.IsCompleted == true || _task?.IsCanceled == true || _task?.IsFaulted == true)
            {                
                try
                {
                    TaskTimer.Enabled = false;
                    if (update)
                    {
                        VLog.Log("Спрашиваем про обновление");
                        AskForm af = new AskForm();
                        Hide();
                        if (af.ShowDialog()!=DialogResult.Cancel);
                        {
                            Close();                            
                        }
                    }               
                    VLog.Log("Запускаем основное приложение");
                        var appPath = Regex.Replace(Application.ExecutablePath.ToLower(), "(.*).updater.exe$", "$1.exe");
                        Process.Start(appPath);                    
                    Close();
                }
                catch (Exception ex)
                {
                    VLog.Log(ex);
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
