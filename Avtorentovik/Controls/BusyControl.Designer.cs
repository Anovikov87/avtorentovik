using DevExpress.XtraEditors.Controls;

namespace Avtorentovik.Controls
{
    partial class BusyControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControlBottom = new DevExpress.XtraEditors.LabelControl();
            this.labelControlMid = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTop = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // labelControlBottom
            // 
            this.labelControlBottom.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControlBottom.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlBottom.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControlBottom.Location = new System.Drawing.Point(0, 26);
            this.labelControlBottom.Name = "labelControlBottom";
            this.labelControlBottom.Size = new System.Drawing.Size(377, 13);
            this.labelControlBottom.TabIndex = 5;
            this.labelControlBottom.Text = "2016";
            // 
            // labelControlMid
            // 
            this.labelControlMid.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControlMid.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlMid.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControlMid.Location = new System.Drawing.Point(0, 13);
            this.labelControlMid.Name = "labelControlMid";
            this.labelControlMid.Size = new System.Drawing.Size(377, 13);
            this.labelControlMid.TabIndex = 4;
            this.labelControlMid.Text = "30";
            // 
            // labelControlTop
            // 
            this.labelControlTop.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControlTop.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlTop.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.labelControlTop.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControlTop.LineLocation = DevExpress.XtraEditors.LineLocation.Top;
            this.labelControlTop.Location = new System.Drawing.Point(0, 0);
            this.labelControlTop.Name = "labelControlTop";
            this.labelControlTop.Size = new System.Drawing.Size(377, 13);
            this.labelControlTop.TabIndex = 3;
            this.labelControlTop.Text = "сент";
            // 
            // BusyControl
            // 
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.Controls.Add(this.labelControlBottom);
            this.Controls.Add(this.labelControlMid);
            this.Controls.Add(this.labelControlTop);
            this.Size = new System.Drawing.Size(377, 44);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LabelControl labelControlBottom;
        public DevExpress.XtraEditors.LabelControl labelControlMid;
        public DevExpress.XtraEditors.LabelControl labelControlTop;
    }
}
