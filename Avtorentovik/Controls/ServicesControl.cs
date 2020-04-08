using System;
using System.Drawing;
using System.Windows.Forms;
using Avtorentovik.Utils;

namespace Avtorentovik.Controls
{
    public partial class ServicesControl
    {
        private readonly Service _service;
        public ServicesControl(Service service)
        {
            InitializeComponent();
            _service = service;
            SetService();
        }

        private void SetService()
        {
            if (_service==null)
                return;
            labelControlName.Text = _service.Name;
            comboBoxEditPriceType.SelectedIndex = _service.PriceType;
            spinEditPrice.Value = _service.Price;
            toggleSwitchStatus.IsOn= _service.Status;            
        }


        public Service GetService()
        {
            _service.Price = (int)spinEditPrice.Value;
            _service.PriceType = comboBoxEditPriceType.SelectedIndex;
            _service.Status = toggleSwitchStatus.IsOn;
            return _service;
        }

        public void SetSkin()
        {
            panel1.LookAndFeel.SetSkinStyle("Office 2013 Dark Gray");
            panel2.LookAndFeel.SetSkinStyle("Office 2013 Dark Gray");
            panel3.LookAndFeel.SetSkinStyle("Office 2013 Dark Gray");
            toggleSwitchStatus.BackColor =Color.FromArgb(227,227,227);
        }

        private void toggleSwitchStatus_Toggled(object sender, EventArgs e)
        {             
        }
    }
}
