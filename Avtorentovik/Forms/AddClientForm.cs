using System;
using System.Windows.Forms;
using Avtorentovik.Core.Model;
using Avtorentovik.Properties;
using Avtorentovik.Utils;
using DevExpress.XtraScheduler;

namespace Avtorentovik.Forms
{
    public partial class AddClientForm : Form
    {
        private Client _client;
        private User _user;
        private Client _oldClient;
        public AddClientForm(User user,Client client=null)
        {
            InitializeComponent();
            _client = client;
            _user = user;
            _oldClient = _client?.Clone();
        }

        public Client GetOldClient => _oldClient;

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var fio = textEditFio.Text.Trim();
                var phone = textEditPhone.Text.Trim();
                var passport = textEditPassport.Text.Trim();
                var when = dateEditWhen.DateTime;
                var who = textEditWho.Text.Trim();
                var code = textEditCode.Text.Trim();
                var license = textEditLicense.Text.Trim();
                var licenseDate = dateEditDate.DateTime;
                var registration = textEditRegistration.Text.Trim();
                var address = textEditAddress.Text.Trim();
                var born = textEditBorn.Text.Trim();
                var status = (ClientStatus)(comboBoxEdit1.SelectedIndex + 1);
                if (string.IsNullOrEmpty(fio))
                {
                    MessageBox.Show(Resources.AddClientForm_simpleButtonSave_Click_Укажите_ФИО_клиента_);
                    return;
                }
                if (_client == null)
                {
                    var client = new Client
                    {
                        Fio = fio,
                        Phone = phone,
                        Passport = passport,
                        When = when,
                        Who = who,
                        Code = code,
                        License = license,
                        LicenseDate = licenseDate,
                        Registration = registration,
                        Address = address,
                        Born = born,
                        Status = status,
                        User = _user
                    };
                    client.Id=Model.Clients.Post(client);                    
                }
                else
                {
                    _client.Fio = fio;
                    _client.Phone = phone;
                    _client.Passport = passport;
                    _client.When = when;
                    _client.Who = who;
                    _client.Code = code;
                    _client.License = license;
                    _client.LicenseDate = licenseDate;
                    _client.Registration = registration;
                    _client.Address = address;
                    _client.Born = born;
                    _client.Status = status;
                    Model.Clients.Put(_client);
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddClientForm_Load(object sender, EventArgs e)
        {
            if (_client == null)
            {
                labelControlstatus.Visible = comboBoxEdit1.Visible = false;
                return;
            }           
            textEditFio.Text = _client.Fio;
            textEditPhone.Text = _client.Phone;
            textEditPassport.Text = _client.Passport;
            dateEditWhen.DateTime = _client.When;
            textEditWho.Text = _client.Who;
            textEditCode.Text = _client.Code;
            textEditLicense.Text = _client.License;
            dateEditDate.DateTime = _client.LicenseDate;
            textEditRegistration.Text = _client.Registration;
            textEditAddress.Text = _client.Address;
            textEditBorn.Text = _client.Born;
            comboBoxEdit1.SelectedIndex = (int) _client.Status - 1;
        }
    }
}
