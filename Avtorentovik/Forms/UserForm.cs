using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avtorentovik.Core.Model;
using Avtorentovik.Properties;
using Avtorentovik.Utils;

namespace Avtorentovik.Forms
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var login = textBox1.Text.Trim();
                var pass = textBox2.Text.Trim();
                var user = new User()
                {
                    PasswordHash = MD5Hash.Get(pass, Encoding.Default),
                    Login = login,
                };
                Model.Users.Post(user);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
                MessageBox.Show(Resources.UserForm_simpleButton2_Click_Ошибка_во_время_создания_пользователя_);
            }            
        }      
    }
}
