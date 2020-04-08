using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtorentovik.Controls
{
    public partial class DateSquare : Panel
    {
        public DateSquare()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            InitializeComponent();
        }

        public void SetDate(DateTime date)
        {
            var tag = int.Parse(Tag.ToString());
            if (date.Day > 1)
            {
                if (tag == 2)
                {
                    labelControl1.BackColor = Color.Red;
                    labelControl2.BackColor = Color.Red;
                    labelControl3.BackColor = Color.Red;
                }
                date = date.AddDays(tag-2);                          
            }
            else
            {
                date=date.AddDays(tag-1);
                if (tag == 2)
                {
                    labelControl1.BackColor = Color.Gray;
                    labelControl2.BackColor = Color.Gray;
                    labelControl3.BackColor = Color.Gray;
                }
            }        
            var month = "";
            switch (date.Month)
            {
                case 1:
                    month = "янв";
                    break;
                case 2:
                    month = "фев";
                    break;
                case 3:
                    month = "март";
                    break;
                case 4:
                    month = "апр";
                    break;
                case 5:
                    month = "май";
                    break;
                case 6:
                    month = "июнь";
                    break;
                case 7:
                    month = "июль";
                    break;
                case 8:
                    month = "авг";
                    break;
                case 9:
                    month = "сент";
                    break;
                case 10:
                    month = "окт";
                    break;
                case 11:
                    month = "нояб";
                    break;
                case 12:
                    month = "дек";
                    break;
            }                       
            labelControl1.Text = month;            
            labelControl2.Text = date.Day.ToString();
            labelControl3.Text = date.Year.ToString();
        }
    }
}
