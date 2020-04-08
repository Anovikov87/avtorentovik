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
    public partial class AskForm : XtraForm
    {
        private string _serverUrl = "avtorentovik.ru";
        private  Task _task;
        public AskForm()
        {            
            InitializeComponent();
        }
        private void TaskTimer_Tick(object sender, EventArgs e)
        {
            if (_task?.IsCompleted == true || _task?.IsCanceled == true || _task?.IsFaulted == true)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void simpleButtonOld_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void simpleButtonUpdate_Click(object sender, EventArgs e)
        {
            _task = new Task(() =>
            {               
                var appPath = Path.Combine(Path.GetTempPath(), Application.ProductName);
                try
                {
                    Directory.CreateDirectory(appPath);
                    appPath = Path.Combine(appPath, "Setup.exe");
                    VLog.Log("Скачиваем файл обновления");
                    var url = new Uri("http://"+_serverUrl+"/api/crm/download");
                    var cookies = new CookieContainer();
                    var request = HttpWebRequest.Create(url) as HttpWebRequest;
                    request.CookieContainer = cookies;
                    request.ServicePoint.Expect100Continue = false;
                    request.Method = "GET";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
                    request.PreAuthenticate = true;
                   
                    var resp = request.GetResponse();                    
                      using (var fileStream = File.Create(appPath))
                      {                        
                        resp.GetResponseStream().CopyTo(fileStream);
                      }                                   
                }
                catch (Exception ex)
                {
                    VLog.Log(ex);
                    MessageBox.Show(ex.Message);
                    return;
                }
                try
                {
                    VLog.Log("Запускаем установщик обновления");
                      Process.Start(appPath);
                }
                catch (Exception ex)
                {
                    VLog.Log(ex);
                    MessageBox.Show(ex.Message);
                }
            });
               _task.Start();
        }
    }
}
