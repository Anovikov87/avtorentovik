using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avtorentovik.Utils;

namespace Avtorentovik.Controls
{
    public partial class BusyControl : Panel
    {
        private CarOrder Order;
        public BusyControl(CarOrder order)
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            InitializeComponent();
            Order = order;
            labelControlBottom.Tag=labelControlMid.Tag=labelControlTop.Tag=Tag = order.Id;            
        }

        public void SetText()
        {
            if (Width <= 250)
            {
                labelControlTop.Text = Order.DateFrom.ToString("dd MMM HH:mm");
                labelControlMid.Text = "-";
                labelControlMid.Height = 8;
                labelControlBottom.Text = Order.DateTo.ToString("dd MMM HH:mm");
            }
            else 
            {
                labelControlMid.Height = 13;
                labelControlTop.Text = "";                
                labelControlMid.Text =$"Занят с {Order.DateFrom.ToString("dd MMMM HH:mm")} по {Order.DateTo.ToString("dd MMMM HH:mm")}";
                labelControlBottom.Text = "";
            }
            
        }

        private void labelControlTop_Click(object sender, EventArgs e)
        {
           
        }
    }
}
