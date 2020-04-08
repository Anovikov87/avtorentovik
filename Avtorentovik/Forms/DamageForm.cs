using System;
using System.Windows.Forms;
using Avtorentovik.Properties;
using Avtorentovik.Utils;

namespace Avtorentovik.Forms
{
    public partial class DamageForm : Form
    {
        private Damage _damage;
        public DamageForm(Damage damage=null)
        {
            InitializeComponent();
            _damage = damage;
            if (_damage == null) return;
            textEditDetail.Text = _damage.Detail;
            textEditDescription.Text = _damage.Description;
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditDetail.Text.Trim()))
            {
                MessageBox.Show(Resources.DamageForm_simpleButtonSave_Click_Укажите_деталь_);
                return;
            }
            if (string.IsNullOrEmpty(textEditDescription.Text.Trim()))
            {
                MessageBox.Show(Resources.DamageForm_simpleButtonSave_Click_Укажите_деталь_);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        public Damage GetDamage()
        {
            if (_damage==null)
                _damage=new Damage();
            _damage.Detail = textEditDetail.Text.Trim();
            _damage.Description=textEditDescription.Text.Trim();
            return _damage;
        }

        private void DamageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
