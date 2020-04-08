using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Avtorentovik.Controls;
using Avtorentovik.Core.Model;
using Avtorentovik.Utils;

namespace Avtorentovik.Forms
{
    public partial class SettingsForm : Form
    {
        private Template _template;
        private Prokat _prokat;
        private User _user;
        private MainForm _mf;
        public SettingsForm(User user,MainForm mf)
        {
            InitializeComponent();
            _user = user;
            _mf = mf;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var services = Model.Services.GetAllByUser(_user.Id);
                if (services == null||!services.Any())
                {
                    var service = new Service() { Name = "GPS навигатор",User = _user};
                    Model.Services.Post(service);
                    var service1 = new Service() { Name = "Без депозита", User = _user };
                    Model.Services.Post(service1);
                    var service2 = new Service() { Name = "Без ограничения пробега", User = _user };
                    Model.Services.Post(service2);
                    var service3 = new Service() { Name = "Детское кресло", User = _user };
                    Model.Services.Post(service3);
                    services = Model.Services.GetAllByUser(_user.Id);
                }
                _prokat = Model.Prokats.GetbyUser(_user.Id);
                //panelControlServices.Controls.Clear();
                bool gray = true;
                foreach (var service in services)
                {
                    var sc = new ServicesControl(service);
                    panelControlServices.Controls.Add(sc);
                    sc.Dock=DockStyle.Top;
                    sc.BringToFront();
                    if (gray)
                        sc.SetSkin();
                    gray = !gray;
                }
                var template = Model.Templates.GetbyUser(_user.Id);
                if (template != null)
                {
                    textEditPath.Text = template.Path;
                    _template = template;                    
                }
                if (_prokat != null)
                {
                    textEditRName.Text = _prokat.Name;
                    textEditRAddress.Text = _prokat.Address;
                    textEditRPhones.Text = _prokat.Phones;
                    textEditRTime.Text = _prokat.Worktime;
                }
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButtonSelect_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==DialogResult.Cancel)
                return;
            var path = ofd.FileName;            
            try
            {
                if (_template==null)
                    _template=new Template();
                _template.File= File.ReadAllBytes(path);
                _template.Path = path;
                _template.User = _user;
                textEditPath.Text = path;
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            try
            {
                foreach (Control ctrl in panelControlServices.Controls)
                {
                    if (!(ctrl is ServicesControl)) continue;
                    var sc = (ServicesControl) ctrl;
                    var serv = sc.GetService();
                    Model.Services.Put(serv);
                }
                if (_template != null)
                {
                    if (_template.Id == 0)
                        Model.Templates.Post(_template);
                    else
                        Model.Templates.Put(_template);
                }
                var rName = textEditRName.Text.Trim();
                var rAddress = textEditRAddress.Text.Trim();
                var rPhones = textEditRPhones.Text.Trim();
                var rTime = textEditRTime.Text.Trim();
                if (_prokat == null)
                {
                    var prokat = new Prokat
                    {
                        Name = rName,
                        Address = rAddress,
                        Phones = rPhones,
                        Worktime = rTime,
                        User = _user
                    };
                    Model.Prokats.Post(prokat);
                }
                else
                {
                    _prokat.Name = rName;
                    _prokat.Address = rAddress;
                    _prokat.Phones = rPhones;
                    _prokat.Worktime = rTime;
                    Model.Prokats.Put(_prokat);
                }
                Close();
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
                MessageBox.Show(ex.Message);
            }
            
        }

        private void simpleButtonChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                var pass1 = textEditPassword1.Text.Trim();
                var pass2 = textEditPassword2.Text.Trim();
                var oldpass = textEditOldPassword.Text.Trim();
                if (string.IsNullOrEmpty(pass1) || string.IsNullOrEmpty(oldpass) || string.IsNullOrEmpty(pass2))
                {
                    MessageBox.Show("Пароль не может быть пустым");
                    return;
                }
                var oldpassHash = MD5Hash.Get(oldpass, Encoding.Default);
                if (_user.PasswordHash != oldpassHash)
                {
                    MessageBox.Show("Старый пароль не совпадает с введенным");
                    return;
                }
                if (!pass1.Equals(pass2))
                {
                    MessageBox.Show("Новые пароли не совпадают");
                    return;
                }
               
                string url = string.Format("https://" + _mf._serverUrl + "/api/company/update_password?password={0}", pass1);
                VLog.Log("Постим пароль.");
                var result=_mf.PostString(url);
                VLog.Log("Запостили пароль: "+result);
                if (result.ToLower() != "true")
                {
                    throw new Exception("Ошибка во время создания пароля.");                    
                }
                _user.PasswordHash = MD5Hash.Get(pass1, Encoding.Default);
                _user.Password = pass1;
                
                Model.Users.Put(_user, true);
                textEditPassword1.Text = "";
                textEditPassword2.Text = "";
                textEditOldPassword.Text = "";
                MessageBox.Show("Пароль изменен.");
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
                MessageBox.Show(ex.Message);
            }
        }       
    }
}
