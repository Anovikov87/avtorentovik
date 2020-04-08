namespace Avtorentovik.Forms
{
    partial class RentForm
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
            this.spinEditFrom = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditTo = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditPrice = new DevExpress.XtraEditors.SpinEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // spinEditFrom
            // 
            this.spinEditFrom.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditFrom.Location = new System.Drawing.Point(120, 48);
            this.spinEditFrom.Name = "spinEditFrom";
            this.spinEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditFrom.Properties.Mask.EditMask = "d";
            this.spinEditFrom.Size = new System.Drawing.Size(100, 20);
            this.spinEditFrom.TabIndex = 0;
            // 
            // spinEditTo
            // 
            this.spinEditTo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditTo.Location = new System.Drawing.Point(120, 74);
            this.spinEditTo.Name = "spinEditTo";
            this.spinEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditTo.Properties.Mask.EditMask = "d";
            this.spinEditTo.Size = new System.Drawing.Size(100, 20);
            this.spinEditTo.TabIndex = 1;
            // 
            // spinEditPrice
            // 
            this.spinEditPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditPrice.Location = new System.Drawing.Point(120, 100);
            this.spinEditPrice.Name = "spinEditPrice";
            this.spinEditPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditPrice.Properties.Mask.EditMask = "d";
            this.spinEditPrice.Size = new System.Drawing.Size(100, 20);
            this.spinEditPrice.TabIndex = 2;
            // 
            // checkEdit1
            // 
            this.checkEdit1.EditValue = true;
            this.checkEdit1.Location = new System.Drawing.Point(120, 126);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Активна";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Дней аренды от";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 81);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Дней аренды до";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(86, 103);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(26, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Цена";
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSave.Appearance.BackColor = System.Drawing.Color.DarkOrange;
            this.simpleButtonSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButtonSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButtonSave.Appearance.Options.UseBackColor = true;
            this.simpleButtonSave.Appearance.Options.UseFont = true;
            this.simpleButtonSave.Appearance.Options.UseForeColor = true;
            this.simpleButtonSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButtonSave.Location = new System.Drawing.Point(56, 157);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(90, 33);
            this.simpleButtonSave.TabIndex = 7;
            this.simpleButtonSave.Text = "Сохранить";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.Appearance.BackColor = System.Drawing.Color.DarkOrange;
            this.simpleButtonCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButtonCancel.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButtonCancel.Appearance.Options.UseBackColor = true;
            this.simpleButtonCancel.Appearance.Options.UseFont = true;
            this.simpleButtonCancel.Appearance.Options.UseForeColor = true;
            this.simpleButtonCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Location = new System.Drawing.Point(152, 157);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(90, 33);
            this.simpleButtonCancel.TabIndex = 8;
            this.simpleButtonCancel.Text = "Отмена";
            // 
            // RentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.simpleButtonCancel;
            this.ClientSize = new System.Drawing.Size(254, 202);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonSave);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.spinEditPrice);
            this.Controls.Add(this.spinEditTo);
            this.Controls.Add(this.spinEditFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(270, 240);
            this.Name = "RentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Стоимость аренды";
            ((System.ComponentModel.ISupportInitialize)(this.spinEditFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit spinEditFrom;
        private DevExpress.XtraEditors.SpinEdit spinEditTo;
        private DevExpress.XtraEditors.SpinEdit spinEditPrice;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
    }
}