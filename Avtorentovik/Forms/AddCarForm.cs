using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Avtorentovik.Utils;
using Avtorentovik.Core.Model;
using Avtorentovik.Properties;

namespace Avtorentovik.Forms
{    
    public partial class AddCarForm : Form
    {
        private Car _currentCar;
        private Mark[] _marks;
        private CarModel[] _models;
        private List<Damage> _damages;
        private List<Rent> _rents;
        private User _user;
        private CarRental[] _carRentals;
        public AddCarForm(User user, Car car=null)
        {
            InitializeComponent();
            _currentCar = car;
            _user = user;
        }

        public Car GetCar => _currentCar;

        private void AddCarForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _marks = Model.Marks.GetAll();
            _damages=new List<Damage>();
            _rents=new List<Rent>();
            _carRentals = Model.CarRentals.GetbyUser(_user.Id);
            comboBoxEditRentals.Properties.Items.AddRange(_carRentals);
            comboBoxEditMark.Properties.Items.AddRange(_marks.Cast<object>().ToArray());
            _models = Model.CarModels.GetAll();
            //var colors = Enum.GetValues(typeof (KnownColor));            Другой способ получения цветов
            //comboBoxEditColor.Properties.Items.AddRange(GetAllColors());
            if (_currentCar != null)
            {
                comboBoxEditMark.SelectedItem = _marks.FirstOrDefault(q => q.Id == _currentCar.Model.MarkId);
                FillModels(_currentCar.Model.MarkId);
                comboBoxEditModel.SelectedItem = _models.FirstOrDefault(q=>q.Id==_currentCar.Model.Id);
                if((int)_currentCar.Color>1)
                    comboBoxEditColor.SelectedIndex = (int)_currentCar.Color-2;
                if (_currentCar.CarRental!=null)
                    comboBoxEditRentals.SelectedItem= _carRentals.FirstOrDefault(q => q.Id == _currentCar.CarRental.Id);
                comboBoxEditBodyType.SelectedIndex = (int)_currentCar.BodyType - 1;
                comboBoxEditKpp.SelectedIndex = _currentCar.Kpp ? 0 : 1;
                textEditNumber.Text = _currentCar.Number;
                textEditSts.Text = _currentCar.Sts;
                spinEditYear.Value = _currentCar.Year;
                textEditEngine.Text = _currentCar.Enginge;
                textEditBodyNumber.Text = _currentCar.BodyNumber;
                memoEditTO.Text = _currentCar.TO;
                dateEdit1.DateTime = _currentCar.Insurance;
                _damages = _currentCar.Damages;         
                gridControlDamages.DataSource =_damages;
                _rents = _currentCar.Rents;
                gridControlRents.DataSource = _rents;
            }
            gridViewRents.RowStyle += GridViewRents_RowStyle;
        }

        private List<string> GetAllColors()
        {
            return (from property in typeof (Color).GetProperties() where property.PropertyType == typeof (Color) select ((Color) property.GetValue(null)).Name).ToList();
        }

        private void comboBoxEditMark_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Mark)comboBoxEditMark.SelectedItem;
            if (item==null)
                return;
            FillModels(item.Id);
        }

        private void FillModels(int markId)
        {
            comboBoxEditModel.Properties.Items.Clear();
            comboBoxEditModel.Text = "";
            comboBoxEditModel.Enabled = true;
            comboBoxEditModel.Properties.Items.AddRange(_models.Where(q => q.MarkId == markId).Cast<object>().ToArray());
        }

        private void simpleButtonNext_Click(object sender, EventArgs e)
        {
            xtraTabControlGeneral.SelectedTabPageIndex++;            
        }

        private void Save()
        {
            try
            {

                if (string.IsNullOrEmpty(comboBoxEditModel.Text)||comboBoxEditMark.SelectedIndex<0)
                {
                    MessageBox.Show(Resources.AddCarForm_Save_Выберите_модель_и_марку_автомобиля_);
                    return;
                }
                var mark = (Mark)comboBoxEditMark.SelectedItem;
                var model = new CarModel();
                if (comboBoxEditModel.SelectedItem is CarModel)
                    model = (CarModel) comboBoxEditModel.SelectedItem;
                else
                {
                    model = new CarModel()
                    {
                        Name = comboBoxEditModel.Text,
                        MarkId = mark.Id
                    };
                    model.Id = Model.CarModels.Post(model);
                }
                if (comboBoxEditColor.SelectedIndex < 0)
                {
                    MessageBox.Show(Resources.AddCarForm_Save_Выберите_цвет_автомобиля);
                    return;
                }
                if (comboBoxEditRentals.SelectedIndex < 0)
                {
                    MessageBox.Show(Resources.AddCarForm_Save_Необходимо_выбрать_пункт_выдачи_для_авто_);
                    return;
                }
                var rental = (CarRental)comboBoxEditRentals.SelectedItem;
                var color = comboBoxEditColor.SelectedIndex+2;
                var type = (Body)comboBoxEditBodyType.SelectedIndex+1;
                var kpp = comboBoxEditKpp.SelectedIndex == 0;
                var number = textEditNumber.Text.Trim();
                var sts = textEditSts.Text.Trim();
                var year = (int) spinEditYear.Value;
                var engine = textEditEngine.Text.Trim();
                var body = textEditBodyNumber.Text.Trim();
                var to = memoEditTO.Text.Trim();
                var insurance = dateEdit1.DateTime;
                if (_currentCar == null)
                {
                    var car = new Car
                    {
                        Model = model,
                        Color =(CarColor) color,
                        BodyType = type,
                        Kpp = kpp,
                        Number = number,
                        Sts = sts,
                        Year = year,
                        Enginge = engine,
                        BodyNumber = body,
                        Insurance = insurance,
                        TO = to,
                        Damages = (List<Damage>) (gridControlDamages.DataSource ?? new List<Damage>()),
                        Rents = (List<Rent>) (gridControlRents.DataSource ?? new List<Rent>()),
                        User = _user,
                        CarRental = rental
                    };
                    car.Id=Model.Cars.Post(car);
                    _currentCar = car;
                }
                else
                {
                    _currentCar.Model = model;
                    _currentCar.Color = (CarColor)color;
                    _currentCar.BodyType = type;
                    _currentCar.Kpp = kpp;
                    _currentCar.Number = number;
                    _currentCar.Sts = sts;
                    _currentCar.Year = year;
                    _currentCar.Enginge = engine;
                    _currentCar.BodyNumber = body;
                    _currentCar.TO = to;
                    _currentCar.Insurance = insurance;
                    _currentCar.Damages = (List<Damage>)(gridControlDamages.DataSource??new List<Damage>());
                    _currentCar.Rents = (List<Rent>)(gridControlRents.DataSource??new List<Rent>());
                    _currentCar.User = _user;
                    _currentCar.CarRental = rental;
                    Model.Cars.Put(_currentCar);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
                MessageBox.Show(ex.Message);
            }            
        }       

      

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

      

        private void simpleButtonAddDamage_Click(object sender, EventArgs e)
        {
            var df = new DamageForm();
            if (df.ShowDialog()==DialogResult.Cancel)
                return;            
            _damages.Add(df.GetDamage());
            gridControlDamages.DataSource = null;            
            gridControlDamages.DataSource = _damages;
        }

        private void simpleButtonChangeDamage_Click(object sender, EventArgs e)
        {
            if (gridViewDamages.SelectedRowsCount == 0)
            {
                MessageBox.Show(Resources.AddCarForm_simpleButtonChangeDamage_Click_Выберите_повреждение_для_редактирования_);
                return;
            }
            var idx = gridViewDamages.GetSelectedRows()[0];
            var damage = (Damage)gridViewDamages.GetRow(idx);
            var df = new DamageForm(damage);
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
                MessageBox.Show(Resources.AddCarForm_simpleButtonDeleteDamage_Click_Выберите_повреждение_для_удаления_);
                return;
            }
            var idx = gridViewDamages.GetSelectedRows()[0];
            var damage = (Damage)gridViewDamages.GetRow(idx);
            _damages.Remove(damage);
            gridControlDamages.DataSource = null;
            gridControlDamages.DataSource = _damages;
        }

        private void simpleButtonAddRent_Click(object sender, EventArgs e)
        {
            var rf = new RentForm();
            if (rf.ShowDialog()==DialogResult.Cancel)
                return;
            _rents.Add(rf.GetRent());
            gridControlRents.DataSource = null;
            gridControlRents.DataSource = _rents;
        }

        private void simpleButtonEditRent_Click(object sender, EventArgs e)
        {
            if (gridViewRents.SelectedRowsCount == 0)
            {
                MessageBox.Show(Resources.AddCarForm_simpleButtonEditRent_Click_Выберите_стоимость_аренды_для_редактирования_);
                return;
            }
            var idx = gridViewRents.GetSelectedRows()[0];
            var rent = (Rent)gridViewRents.GetRow(idx);
            var df = new RentForm(rent);
            if (df.ShowDialog() == DialogResult.Cancel)
                return;
            df.GetRent();
            gridControlRents.DataSource = null;
            gridControlRents.DataSource = _rents;
            
        }

        private void GridViewRents_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = e.RowHandle % 2 == 0 ? Color.White : Color.LightGray;
        }

        private void simpleButtonDeleteRent_Click(object sender, EventArgs e)
        {
            if (gridViewRents.SelectedRowsCount == 0)
            {
                MessageBox.Show(Resources.AddCarForm_simpleButtonDeleteRent_Click_Выберите_стоимость_аренды_для_удаления_);
                return;
            }
            var idx = gridViewRents.GetSelectedRows()[0];
            var rent = (Rent)gridViewRents.GetRow(idx);
            _rents.Remove(rent);
            gridControlRents.DataSource = null;
            gridControlRents.DataSource = _rents;
        }
        private void labelControl11_Click(object sender, EventArgs e)
        {

        }
    }
}
