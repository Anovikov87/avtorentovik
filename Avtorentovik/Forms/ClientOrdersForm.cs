using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avtorentovik.Utils;

namespace Avtorentovik.Forms
{
    public partial class ClientOrdersForm : Form
    {
        private List<ClientOrder> _orders;
        public ClientOrdersForm(List<ClientOrder> orders )
        {
            InitializeComponent();
            _orders = orders;
        }

        private void ClientOrdersForm_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = _orders;
        }
    }
}
