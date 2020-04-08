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
    public partial class DateControl : Panel
    {
        public DateControl()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public void SetDate(DateTime date)
        {
            /*var days = DateTime.DaysInMonth(date.Year, date.Month);
            if (date.Day > 1)
                days = 30;
            this.Width = 1240 - (31 - days) * 40;*/
            foreach (DateSquare dates in Controls)
            {
                dates.SetDate(date);                
            }            
        }
    }
}
