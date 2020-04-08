using System;
using System.Windows.Forms;
using Avtorentovik.Core.Model;
using Avtorentovik.Properties;
using Avtorentovik.Utils;

namespace Avtorentovik.Forms
{
    public partial class CloseOrderForm : Form
    {
        private readonly Order _order;
        public CloseOrderForm(Order order)
        {
            InitializeComponent();
            _order = order;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var df = new DamageForm();
            if (df.ShowDialog()==DialogResult.Cancel)
                return;
            var dd = df.GetDamage();
            dd.CarId = _order.Car.Id;
            _order.Damages.Add(dd);
            ShowDamages();
        }

        private void ShowDamages()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = _order.Damages;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show(Resources.CloseOrderForm_simpleButton2_Click_Выберите_повреждение_для_редактирования_);
                return;
            }
            var idx = gridView1.GetSelectedRows()[0];
            var row = (Damage)gridView1.GetRow(idx);
            var df = new DamageForm(row);
            if (df.ShowDialog() == DialogResult.Cancel)
                return;
            df.GetDamage();            
            ShowDamages();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show(Resources.CloseOrderForm_simpleButton3_Click_Выберите_повреждение_для_удаления_);
                return;
            }
            var idx = gridView1.GetSelectedRows()[0];
            var row = (Damage)gridView1.GetRow(idx);
            _order.Damages.Remove(row);
            ShowDamages();
        }

        private void CloseOrderForm_Load(object sender, EventArgs e)
        {
            spinEditStart.Value = (decimal)_order.Car.Mileage;
            labelControlOrder.Text = $"Заказ №{_order.Id}";
        }

        private void simpleButtonAccept_Click(object sender, EventArgs e)
        {
            var end = (double)spinEditEnd.Value;
            if (_order.MileageStart > end)
            {
                MessageBox.Show(Resources.CloseOrderForm_simpleButtonAccept_Click_Пробег_при_сдаче_должен_быть_больше_пробега_в_начале_);
                return;                
            }
            var wash = (double)spinEditWash.Value;
            var overrun = (double)spinEditOverrun.Value;
            var other = (double)spinEditOther.Value;            
            try
            {                
                _order.Closed = true;
                _order.Wash = wash;
                _order.MileageEnd = end;
                _order.Other = other;
                _order.Overrun = overrun;
                Model.Orders.Put(_order);
                var car = _order.Car;
                car.Mileage = end;                
                car.Damages.AddRange(_order.Damages);
                Model.Cars.Put(car);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
