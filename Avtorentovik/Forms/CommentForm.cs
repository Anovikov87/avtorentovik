using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtorentovik.Forms
{
    public partial class CommentForm : Form
    {
        public CommentForm()
        {
            InitializeComponent();
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(memoEdit1.Text.Trim()))
            {
                MessageBox.Show("Сведения не должны быть пустыми.");
                return;
            }
            DialogResult = DialogResult.OK;
        }

        public string GetComment()
        {
            return memoEdit1.Text.Trim();
        }
    }
}
