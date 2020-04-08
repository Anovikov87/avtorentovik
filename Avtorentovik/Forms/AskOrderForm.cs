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
    public partial class AskOrderForm : Form
    {    
        public AskOrderForm(Order order)
        {
            InitializeComponent();
            try
            {
                labelControlCar.Text = string.Format("Автомобиль: {0}", order.Car);
                labelControlClient.Text = string.Format("Клиент: {0}", order.Client);
                labelControlFrom.Text = string.Format("Дата начала аренды: {0}", order.DateFrom);
                labelControlTo.Text = string.Format("Дата окончания аренды: {0}", order.DateTo);
            }
            catch (Exception ex)
            {
                VLog.Log(ex);
            }
        }                
    }
}
