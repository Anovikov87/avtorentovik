namespace Avtorentovik.Updater
{
    partial class AskForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TaskTimer = new System.Windows.Forms.Timer(this.components);
            this.simpleButtonUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOld = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // TaskTimer
            // 
            this.TaskTimer.Enabled = true;
            this.TaskTimer.Interval = 300;
            this.TaskTimer.Tick += new System.EventHandler(this.TaskTimer_Tick);
            // 
            // simpleButtonUpdate
            // 
            this.simpleButtonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonUpdate.Appearance.BackColor = System.Drawing.Color.DarkOrange;
            this.simpleButtonUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButtonUpdate.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButtonUpdate.Appearance.Options.UseBackColor = true;
            this.simpleButtonUpdate.Appearance.Options.UseFont = true;
            this.simpleButtonUpdate.Appearance.Options.UseForeColor = true;
            this.simpleButtonUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.simpleButtonUpdate.Location = new System.Drawing.Point(61, 36);
            this.simpleButtonUpdate.Name = "simpleButtonUpdate";
            this.simpleButtonUpdate.Size = new System.Drawing.Size(81, 33);
            this.simpleButtonUpdate.TabIndex = 1;
            this.simpleButtonUpdate.Text = "Обновить";
            this.simpleButtonUpdate.Click += new System.EventHandler(this.simpleButtonUpdate_Click);
            // 
            // simpleButtonOld
            // 
            this.simpleButtonOld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonOld.Appearance.BackColor = System.Drawing.Color.DarkOrange;
            this.simpleButtonOld.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButtonOld.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButtonOld.Appearance.Options.UseBackColor = true;
            this.simpleButtonOld.Appearance.Options.UseFont = true;
            this.simpleButtonOld.Appearance.Options.UseForeColor = true;
            this.simpleButtonOld.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.simpleButtonOld.Location = new System.Drawing.Point(158, 36);
            this.simpleButtonOld.Name = "simpleButtonOld";
            this.simpleButtonOld.Size = new System.Drawing.Size(176, 33);
            this.simpleButtonOld.TabIndex = 2;
            this.simpleButtonOld.Text = "Запустить старую версию";
            this.simpleButtonOld.Click += new System.EventHandler(this.simpleButtonOld_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(350, 16);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Появилась новая версия программы, можете обновить её.";
            // 
            // AskForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 81);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButtonOld);
            this.Controls.Add(this.simpleButtonUpdate);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Обновление";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer TaskTimer;
        private DevExpress.XtraEditors.SimpleButton simpleButtonUpdate;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOld;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}

