namespace Avtorentovik.Forms
{
    partial class AskOrderForm
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlCar = new DevExpress.XtraEditors.LabelControl();
            this.labelControlClient = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTo = new DevExpress.XtraEditors.LabelControl();
            this.labelControlFrom = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.DarkOrange;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton1.Location = new System.Drawing.Point(384, 77);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(132, 33);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Отказать";
            // 
            // labelControlCar
            // 
            this.labelControlCar.Location = new System.Drawing.Point(24, 23);
            this.labelControlCar.Name = "labelControlCar";
            this.labelControlCar.Size = new System.Drawing.Size(61, 13);
            this.labelControlCar.TabIndex = 4;
            this.labelControlCar.Text = "Автомобиль";
            // 
            // labelControlClient
            // 
            this.labelControlClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlClient.Location = new System.Drawing.Point(265, 23);
            this.labelControlClient.Name = "labelControlClient";
            this.labelControlClient.Size = new System.Drawing.Size(37, 13);
            this.labelControlClient.TabIndex = 5;
            this.labelControlClient.Text = "Клиент";
            // 
            // labelControlTo
            // 
            this.labelControlTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlTo.Location = new System.Drawing.Point(265, 42);
            this.labelControlTo.Name = "labelControlTo";
            this.labelControlTo.Size = new System.Drawing.Size(125, 13);
            this.labelControlTo.TabIndex = 11;
            this.labelControlTo.Text = "Дата окончания аренды";
            // 
            // labelControlFrom
            // 
            this.labelControlFrom.Location = new System.Drawing.Point(24, 42);
            this.labelControlFrom.Name = "labelControlFrom";
            this.labelControlFrom.Size = new System.Drawing.Size(111, 13);
            this.labelControlFrom.TabIndex = 10;
            this.labelControlFrom.Text = "Дата начала аренды:";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.BackColor = System.Drawing.Color.DarkOrange;
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton2.Location = new System.Drawing.Point(175, 76);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(202, 33);
            this.simpleButton2.TabIndex = 28;
            this.simpleButton2.Text = "Подтвердить бронирование";
            // 
            // AskOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(528, 122);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.labelControlTo);
            this.Controls.Add(this.labelControlFrom);
            this.Controls.Add(this.labelControlClient);
            this.Controls.Add(this.labelControlCar);
            this.Controls.Add(this.simpleButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(540, 160);
            this.Name = "AskOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Получена заявка на аренду авто";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControlCar;
        private DevExpress.XtraEditors.LabelControl labelControlClient;
        private DevExpress.XtraEditors.LabelControl labelControlTo;
        private DevExpress.XtraEditors.LabelControl labelControlFrom;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}