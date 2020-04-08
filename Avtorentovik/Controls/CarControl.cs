using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avtorentovik.Core.Model;
using Avtorentovik.Forms;
using Avtorentovik.Utils;
using DevExpress.Data.Mask;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Avtorentovik.Controls
{
    public partial class CarControl : Panel
    {
        private Car _car;
        private DateTime _date;
        private MainForm _form;
        private User _user;
        public CarControl(User user,Car car, MainForm form)
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            InitializeComponent();            
            _car = car;
            _user = user;
            _form = form;
            labelControl1.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            labelControl1.AutoSize = true;
            labelControl1.Text = _car.Description;
        }

        public void SetColor()
        {
            panelControl1.LookAndFeel.SetSkinStyle("Office 2013 Light Gray");
            foreach (PanelControl cntrl in panelControlDays.Controls)
            {
                cntrl.LookAndFeel.SetSkinStyle("Office 2013 Light Gray");
            }
        }

        const int width = 40;

        public void UpdateCar(Car car)
        {
            _car = car;
            labelControl1.Text = _car.Description;
        }

        public Car GetCar()
        {
            return _car;
        }

        private int _month;
        private int _year;
        private int _day;

        public void UpdateGraph()
        {
            panelControlDays.SuspendLayout();
            for (int i = 0; i < panelControlDays.Controls.Count; i++)
            {
                var ctrl = panelControlDays.Controls[i];
                if (!(ctrl is BusyControl))
                    continue;
                panelControlDays.Controls.Remove(ctrl);
                ctrl.Dispose();
                i--;
            }
            var days = DateTime.DaysInMonth(_year, _month);
            if (_day != 0)
            {
                days = 30;
            }
            this.Width = 1440 - (31 - days) * width;
            var startDate = new DateTime(_year, _month, 1);
            if (_day != 0)
            {
                startDate = new DateTime(_year, _month, _day).AddDays(-1);
            }
            _date = startDate;
            var endDate = startDate.AddDays(days);
            var orders = _car.Orders.Where(q => (q.DateFrom < endDate && q.DateTo > startDate)).OrderBy(q => q.DateTo);
            var curdate = startDate.Date;
            foreach (var order in orders)
            {                
                bool startmonth = order.DateFrom.Date < curdate.Date;
                var startdate = startmonth ? curdate.Date : order.DateFrom.Date; //дата начала
                var daystoend = (int)(endDate.Date - startdate).TotalDays + 1;//дней до конца 
                var totallength = (int)(order.DateTo.Date - startdate.Date).TotalDays + 1;
                bool endmonth = totallength < daystoend;
                var length = endmonth ? totallength : daystoend;//длина блока                
                if (curdate < startdate)
                {
                    curdate = startdate;
                }
                BusyControl bc = new BusyControl(order);
                bc.Click += Bc_Click;
                bc.labelControlBottom.Click += Bc_Click;
                bc.labelControlTop.Click += Bc_Click;
                bc.labelControlMid.Click += Bc_Click;
                bc.Width = width * (length);
                bc.Left = ((int)(curdate - startDate).TotalDays) * width;
                /*  if (day != 0)
                  {
                      bc.Left -= (startDate.Day-1)* width;
                  }*/

                //Распологаем в соответствии со временем.
                double hour = (double)width / 24;
                if (!startmonth)
                {
                    var moveright = (int)Math.Round(order.DateFrom.Hour * hour);
                    bc.Left += moveright;
                    bc.Width -= moveright;
                }
                if (endmonth)
                {
                    var cropright = (int)Math.Round((24 - order.DateTo.Hour) * hour);
                    bc.Width -= cropright;
                }

                bc.SetText();
                panelControlDays.Controls.Add(bc);
                bc.BringToFront();
                curdate = curdate.AddDays(length - 1);
            }
            panelControlDays.ResumeLayout();
        }
        public void ShowMonth(int month,int year,int day=0)
        {
            _month = month;
            _year = year;
            _day = day;
            UpdateGraph();                       
        }
   

        private void Bc_Click(object sender, EventArgs e)
        {
            var id = (int)((Control) sender).Tag;
            Order order = null;
            try
            {
                order = Model.Orders.Read(id);
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
            }
            if (order == null)
            {
                ((Control)sender).Dispose();
                return;
            }
            var oldfrom = order.DateFrom;
            var oldto = order.DateTo;
            AddOrderForm adf = new AddOrderForm(_user,order);
            if (adf.ShowDialog()==DialogResult.Cancel)
                return;
            _car = Model.Cars.Read(_car.Id);
            if (_date.Day == 0)
                ShowMonth(_date.Month, _date.Year);
            else
            {
                var dates = _date.AddDays(1);
                ShowMonth(dates.Month, dates.Year, dates.Day);
            }
            try
            {
                order = adf.GetOrder;
                if (adf.DeleteOrder)
                {
                    _form.DeleteOrder(order);
                    return;   
                }
                _form.PostOrder(order);
                if (order.DateFrom != oldfrom || order.DateTo != oldto)
                {
                    _form.PostBron(order.DateFrom, order.DateTo, order.SiteId);
                }
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void panelControl2_Click(object sender, EventArgs e)
        {
            var id = int.Parse(((PanelControl) sender).Tag.ToString());
            var date = _date.AddDays(id - 1).AddHours(10);
            AddOrderForm aof = new AddOrderForm(_user,date,_car);
            if (aof.ShowDialog()==DialogResult.Cancel)
                return;
            //_form.LoadCarGraph();
            _car = Model.Cars.Read(_car.Id);
            if (_date.Day==0)
                ShowMonth(_date.Month, _date.Year);
            else
            {                
                var dates = _date.AddDays(1);
                
                ShowMonth(dates.Month, dates.Year,dates.Day);
            }
            try
            {
                var order = aof.GetOrder;                
                _form.PostOrder(order);
                _form.PostBron(order.DateFrom, order.DateTo, order.SiteId);
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
