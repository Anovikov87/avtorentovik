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
using Avtorentovik.Forms;
using Avtorentovik.Utils;

namespace Avtorentovik.Forms
{    
    public partial class DamagesForm : Form
    {
        List<Damage> _damages;
        private Car _car;
        public DamagesForm(Car car)
        {
            InitializeComponent();
            _damages = car.Damages;
            _car = car;
        }

        private void DamagesForm_Load(object sender, EventArgs e)
        {
            gridControlDamages.DataSource = _damages;
        }        

        private void simpleButtonAddDamage_Click(object sender, EventArgs e)
        {
            DamageForm df = new DamageForm();
            if (df.ShowDialog() == DialogResult.Cancel)
                return;
            _damages.Add(df.GetDamage());
            gridControlDamages.DataSource = null;
            gridControlDamages.DataSource = _damages;
        }

        private void simpleButtonChangeDamage_Click(object sender, EventArgs e)
        {
            if (gridViewDamages.SelectedRowsCount == 0)
            {
                MessageBox.Show("Выберите повреждение для редактирования.");
                return;
            }
            var idx = gridViewDamages.GetSelectedRows()[0];
            var damage = (Damage)gridViewDamages.GetRow(idx);
            DamageForm df = new DamageForm(damage);
            if (df.ShowDialog() == DialogResult.Cancel)
                return;
            df.GetDamage();
            gridControlDamages.DataSource = null;
            gridControlDamages.DataSource = _damages;
        }

        private void simpleButtonDeleteDamage_Click(object sender, EventArgs e)
        {
            if (gridViewDamages.SelectedRowsCount == 0)
            {
                MessageBox.Show("Выберите повреждение для удаления.");
                return;
            }
            var idx = gridViewDamages.GetSelectedRows()[0];
            var damage = (Damage)gridViewDamages.GetRow(idx);
            _damages.Remove(damage);
            gridControlDamages.DataSource = null;
            gridControlDamages.DataSource = _damages;
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _car.Damages = _damages;
                Model.Cars.Put(_car);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
            DialogResult = DialogResult.OK;
        }
    }
}
