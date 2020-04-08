using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Avtorentovik.Core.Model;
using Avtorentovik.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler.Native;
using Novacode;

namespace Avtorentovik.Forms
{
    public partial class AddOrderForm : Form
    {
        private Order _order;
        private Car _car;
        private User _user;        

        public AddOrderForm(User user,DateTime date, Car car)
        {
            InitializeComponent();
            _order = new Order();
            _user = user;
            _car = car;
            dateEditFrom.DateTime = date;
            timeEditFrom.Time = date;
            dateEditTo.DateTime = date.AddDays(3);
            dateEditFrom.Enabled = false;
        }

        public AddOrderForm(User user,Order order)
        {
            InitializeComponent();                    
            _order = order;            
            _user = user;
            dateEditFrom.DateTime = _order.DateFrom;
            timeEditFrom.Time = _order.DateFrom;
            dateEditTo.DateTime = _order.DateTo;
            timeEditTo.Time = _order.DateTo;
            dateEditFrom.Enabled = false;
            if (order.Discount > 0)
            {
                comboBoxEditDiscount.Visible = true;
                spinEditDiscount.Visible = true;                
                labelControlDiscount.Visible = false;
            }
        }

        private void labelControlClient_Click(object sender, EventArgs e)
        {
            AddClientForm acf = new AddClientForm(_user);
            if (acf.ShowDialog()==DialogResult.Cancel)
                return;
            LoadData();
        }

        private void LoadData()
        {            
            var cars = Model.Cars.GetAllNamesWithRentsByUser(_user.Id);
            comboBoxEditCars.Properties.Items.AddRange(cars);
            if (_car != null)
            {                
                comboBoxEditCars.SelectedItem = cars.FirstOrDefault(q=>q.Id==_car.Id);
            }
            var clients = Model.Clients.GetAllNamesByUser(_user.Id);
            comboBoxEditClients.Properties.Items.AddRange(clients);
            var services = Model.Services.GetAllByUser(_user.Id).Where(q => q.Status);
            groupControl1.Controls.Clear();
           
            foreach (var service in services)
            {
                CheckEdit ce = new CheckEdit();
                if (_order.Services.FirstOrDefault(q => q.Id == service.Id) != null)
                {
                    ce.Checked = true;
                }
                ce.CheckedChanged += Ce_CheckedChanged;
                               
                var text = service.Name;
                ce.Tag = service;
                if (service.Price == 0)
                {
                    text += " (бесплатно)";
                }
                else
                {
                    text += string.Format(" + {0} руб.{1}", service.Price, service.PriceType == 0 ? @"/сутки" : "");
                }
                ce.Text = text;
                groupControl1.Controls.Add(ce);
                ce.Dock=DockStyle.Top;
                ce.BringToFront();
            }
            if (_order.Id != 0)
            {                
                comboBoxEditCars.SelectedItem = cars.FirstOrDefault(q => q.Id == _order.Car.Id);
                comboBoxEditClients.SelectedItem = clients.FirstOrDefault(q=>q.Id== _order.Client.Id);
                spinEditDiscount.Value = _order.Discount;
                comboBoxEditDiscount.SelectedIndex = _order.DiscountType ? 0 : 1;
                CalcPrice();                
                labelControlNumber.Text =$"Госномер: {_order.Car.Number}";
                labelControlPhone.Text =$"Телефон: {_order.Client.Phone}";
            }
        }

        private void Ce_CheckedChanged(object sender, EventArgs e)
        {
            CalcPrice();
        }

        private void AddOrderForm_Load(object sender, EventArgs e)
        {
            DeleteOrder = false;
            LoadData();
        }

        private void simpleButtonPrint_Click(object sender, EventArgs e)
        {
          Print();  
        }

        private void Print()
        {
           /* SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Docx Files | *.docx";
            sfd.DefaultExt = "docx";
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;
            var path = sfd.FileName;*/
            var text = "";
            var template = Model.Templates.GetbyUser(_user.Id);
            if (template==null)
                return;
            const string fio = "$фио";
            const string passport = "$паспорт";
            const string phone = "$телефон";
            const string vidan = "$когдавыдан";
            const string whom = "$кемвыдан";
            const string code = "$кодподразделения";
            const string drive = "$водительское";
            const string drivedate = "$датаводительского";
            const string reg = "$регистрация";
            const string address = "$местопроживания";
            const string born = "$месторождения";
            const string mark = "$марка";
            const string model = "$модель";
            const string bodytype = "$типкузова";
            const string kpp = "$типкпп";
            const string color = "$цвет";
            const string number = "$госномер";
            const string sts = "$стс";
            const string year = "$годвыпуска";
            const string engine = "$номердвигателя";
            const string bodynumber = "$номеркузова";
            const string territory = "$территория";
            const string rentname = "$названиепроката";
            const string rentaddress = "$адреспроката";
            const string rentphone = "$телефоныпроката";
            const string renttime = "$режимпроката";
            var prokat = Model.Prokats.GetbyUser(_user.Id);
            if (prokat==null)
                return;            
                        
            using (DocX document = DocX.Load(new MemoryStream(template.File)))
            {
                text = document.Text;
                document.ReplaceText(fio,_order.Client.Fio);                
                if (text.Contains(fio))
                {
                     document.ReplaceText(fio, _order.Client.Fio);
                }
                if (text.Contains(passport))
                {
                     document.ReplaceText(passport, _order.Client.Passport);
                }
                if (text.Contains(phone))
                {
                     document.ReplaceText(phone, _order.Client.Phone);
                }
                if (text.Contains(vidan))
                {
                     document.ReplaceText(vidan, _order.Client.When.ToShortDateString());
                }
                if (text.Contains(whom))
                {
                     document.ReplaceText(whom, _order.Client.Who);
                }
                if (text.Contains(code))
                {
                     document.ReplaceText(code, _order.Client.Code);
                }
                if (text.Contains(drive))
                {
                     document.ReplaceText(drive, _order.Client.License);
                }
                if (text.Contains(drivedate))
                {
                     document.ReplaceText(drivedate, _order.Client.LicenseDate.ToShortDateString());
                }
                if (text.Contains(reg))
                {
                     document.ReplaceText(reg, _order.Client.Registration);
                }
                if (text.Contains(address))
                {
                     document.ReplaceText(address, _order.Client.Address);
                }
                if (text.Contains(born))
                {
                     document.ReplaceText(born, _order.Client.Born);
                }
                if (text.Contains(mark))
                {
                    var cmark = Model.Marks.GetAll().FirstOrDefault(q => q.Id == _order.Car.Model.MarkId);
                    if (cmark != null)
                         document.ReplaceText(mark, cmark.Name);
                }
                if (text.Contains(model))
                {
                     document.ReplaceText(model, _order.Car.Model.Name);
                }
                if (text.Contains(bodytype))
                {
                     document.ReplaceText(bodytype, _order.Car.BodyName);
                }
                if (text.Contains(kpp))
                {
                     document.ReplaceText(kpp, _order.Car.KppName);
                }
                if (text.Contains(color))
                {
                     document.ReplaceText(color, _order.Car.ColorName);
                }
                if (text.Contains(number))
                {
                     document.ReplaceText(number, _order.Car.Number);
                }
                if (text.Contains(sts))
                {
                     document.ReplaceText(sts, _order.Car.Sts);
                }
                if (text.Contains(year))
                {
                     document.ReplaceText(year, _order.Car.Year.ToString());
                }
                if (text.Contains(engine))
                {
                     document.ReplaceText(engine, _order.Car.Enginge);
                }
                if (text.Contains(bodynumber))
                {
                     document.ReplaceText(bodynumber, _order.Car.BodyNumber);
                }
                if (text.Contains(territory))
                {
                    var terr = textEditTerritory.Text.Trim();
                     document.ReplaceText(territory, terr);
                }
                if (text.Contains(rentname))
                {
                     document.ReplaceText(renttime, prokat.Name);
                }
                if (text.Contains(rentaddress))
                {
                     document.ReplaceText(rentaddress, prokat.Address);
                }
                if (text.Contains(rentphone))
                {
                     document.ReplaceText(rentphone, prokat.Phones);
                }
                if (text.Contains(renttime))
                {
                     document.ReplaceText(renttime, prokat.Worktime);
                }
                try
                {                    
                    var tpath = Path.GetTempPath() + "Avtorentovik";
                    var filename = string.Format(@"{0}\{1}.docx", tpath, DateTime.Now.ToString("dd_mm_yy_hh_mm_ss"));
                    
                    if (!Directory.Exists(tpath))
                    {
                        Directory.CreateDirectory(tpath);
                    }
                    document.SaveAs(filename);
                    ProcessStartInfo info = new ProcessStartInfo(filename);
                    info.Verb = "Print";

                    info.CreateNoWindow = true;

                    info.WindowStyle = ProcessWindowStyle.Hidden;

                    Process.Start(info);
                    /*
                    using (StreamWriter outfile = new StreamWriter(path, false, Encoding.GetEncoding(1251)))
                    {
                        outfile.Write(text);
                    }*/
                    /* PrintDocument pd = new PrintDocument();                
                     pd.PrintPage += delegate(object sender, PrintPageEventArgs e)
                     {
                         Graphics g = e.Graphics;
                         g.DrawString(text, new Font("Times New Roman", 10), new SolidBrush(Color.Black),
                             new RectangleF(0, 0,e.PageBounds.Width,e.PageBounds.Height));
                     };
                         pd.Print();*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
             
        }

        public Order GetOrder => _order;
        
        private void Save()
        {
            try
            {
                var car = (Car) comboBoxEditCars.SelectedItem;
                if (car == null)
                {
                    MessageBox.Show("Необходимо выбрать машину.");
                    return;
                }
                var client = (Client) comboBoxEditClients.SelectedItem;
                if (client == null)
                {
                    MessageBox.Show("Необходимо указать клиента.");
                    return;
                }
                var services =
                    (from CheckEdit ctrl in groupControl1.Controls where ctrl.Checked select (Service) ctrl.Tag).ToList();
                _order.Car = car;
                _order.Client = client;
                _order.Closed = false;             
                _order.DateFrom = dateEditFrom.DateTime.Date.Add(timeEditFrom.Time.TimeOfDay);
                _order.DateTo = dateEditTo.DateTime.Date.Add(timeEditTo.Time.TimeOfDay);
                _order.MileageStart = car.Mileage;
                _order.Services = services;
                _order.Territory = textEditTerritory.Text.Trim();
                _order.Discount = (int) spinEditDiscount.Value;
                _order.DiscountType = comboBoxEditDiscount.SelectedIndex == 0;
                _order.User = _user;
                if (_order.Id == 0)
                {
                    _order.Id= Model.Orders.Post(_order);
                }
                else
                {
                    Model.Orders.Put(_order);
                }
                
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void CalcPrice()
        {
            var days =(int) (dateEditTo.DateTime.Date - dateEditFrom.DateTime.Date).TotalDays;
            if (comboBoxEditCars.SelectedIndex<0)
                return;
            var car = (Car)comboBoxEditCars.SelectedItem;          
            var rent = car.Rents.FirstOrDefault(q => q.From <= days && q.To >= days||q.From<=days&&q.To==0);
            if (rent == null)
            {
                    return;
            }
            var price = 0;
            price = days*rent.Price;
            //Services
            foreach (CheckEdit ctrl in groupControl1.Controls)
            {
                if (!ctrl.Checked)
                    continue;
                var service = (Service)ctrl.Tag;                
                price += service.Price*(service.PriceType==1?1:days);
            }
            var discount = spinEditDiscount.Value;
            var type = comboBoxEditDiscount.SelectedIndex == 0;
            if (type)
            {
                price -= (int)((discount/100)*price);
            }
            else
            {
                price -= (int)discount;
            }
            labelControlTotal.Text=$"Итого: {price} руб. за {days} дн. аренды";
        }

        private void dateEditTo_EditValueChanged(object sender, EventArgs e)
        {
            CalcPrice();
        }

        private void comboBoxEditCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEditCars.SelectedIndex < 0)
                return;
            var car = (Car)comboBoxEditCars.SelectedItem;            
            CalcPrice();
            labelControlNumber.Text=$"Госномер: {car.Number}";
        }

        private void comboBoxEditClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEditClients.SelectedIndex < 0)
                return;
            var client = (Client)comboBoxEditClients.SelectedItem;
            labelControlPhone.Text = $"Телефон: {client.Phone}";
        }

        public bool DeleteOrder;
        private void labelControlDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить бронирование?","Внимание",MessageBoxButtons.YesNo)==DialogResult.No)
                return;
            try
            {
                if (_order.Id != 0)
                {
                    if (_order.User == null)
                    {
                        _order.User = _user;
                    }
                    _order.Deleted = true;
                    Model.Orders.Put(_order);
                    DeleteOrder = true;
                    DialogResult = DialogResult.OK;
                }else
                    DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void labelControlDiscount_Click(object sender, EventArgs e)
        {
            comboBoxEditDiscount.Visible = true;
            spinEditDiscount.Visible = true;
            labelControlDiscount.Visible = false;
        }

        private void spinEditDiscount_ValueChanged(object sender, EventArgs e)
        {
            CalcPrice();
        }

        private void comboBoxEditDiscount_EditValueChanged(object sender, EventArgs e)
        {
            CalcPrice();
        }
    }
}
