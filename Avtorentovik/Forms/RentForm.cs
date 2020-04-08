using System;
using System.Windows.Forms;
using Avtorentovik.Utils;

namespace Avtorentovik.Forms
{
    public partial class RentForm : Form
    {
        private Rent _rent;
        public RentForm(Rent rent=null)
        {
            InitializeComponent();
            _rent = rent;
            if (_rent != null)
            {
                spinEditFrom.Value = _rent.From;
                spinEditTo.Value = _rent.To;
                spinEditPrice.Value = _rent.Price;
                checkEdit1.Checked = _rent.Status;
            }
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public Rent GetRent()
        {
            if (_rent == null)
            {
                _rent = new Rent();
            }
            _rent.From = (int)spinEditFrom.Value;
            _rent.To = (int)spinEditTo.Value;
            _rent.Price = (int)spinEditPrice.Value;
            _rent.Status = checkEdit1.Checked;
            return _rent;
        }
    }
}
