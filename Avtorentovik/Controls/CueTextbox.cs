using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Avtorentovik.Controls
{
    public class CueTextBox : TextBox//DevExpress.XtraEditors.TextEdit
    {
        [Localizable(true)]
        public string Cue
        {
            get { return _cue; }
            set { _cue = value; UpdateCue(); }
        }

        private void UpdateCue()
        {
            if (IsHandleCreated && _cue != null)
            {
                SendMessage(Handle, 0x1501, (IntPtr)1, _cue);
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateCue();
        }
        private string _cue;

        // PInvoke
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
    }
}
