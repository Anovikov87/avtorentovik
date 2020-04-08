using Avtorentovik.Controls;

namespace Avtorentovik.Forms
{
    partial class AddClientForm
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditWhen = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControlstatus = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonNext = new DevExpress.XtraEditors.SimpleButton();
            this.textEditBorn = new Avtorentovik.Controls.CueTextBox();
            this.textEditAddress = new Avtorentovik.Controls.CueTextBox();
            this.textEditRegistration = new Avtorentovik.Controls.CueTextBox();
            this.textEditLicense = new Avtorentovik.Controls.CueTextBox();
            this.textEditCode = new Avtorentovik.Controls.CueTextBox();
            this.textEditWho = new Avtorentovik.Controls.CueTextBox();
            this.textEditPassport = new Avtorentovik.Controls.CueTextBox();
            this.textEditPhone = new Avtorentovik.Controls.CueTextBox();
            this.textEditFio = new Avtorentovik.Controls.CueTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditWhen.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditWhen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ФИО";
            // 
            // dateEditWhen
            // 
            this.dateEditWhen.EditValue = new System.DateTime(2016, 9, 6, 14, 6, 23, 0);
            this.dateEditWhen.Location = new System.Drawing.Point(107, 100);
            this.dateEditWhen.Name = "dateEditWhen";
            this.dateEditWhen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditWhen.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditWhen.Size = new System.Drawing.Size(104, 20);
            this.dateEditWhen.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(214, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(110, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Контактный телефон";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(18, 81);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Паспорт";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(583, 81);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(102, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Код подразделения";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(18, 126);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(153, 13);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Водительское удостоверение";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(217, 126);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(64, 13);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Регистрация";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(18, 171);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(96, 13);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "Место проживания";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(522, 171);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(85, 13);
            this.labelControl9.TabIndex = 17;
            this.labelControl9.Text = "Место рождения";
            // 
            // dateEditDate
            // 
            this.dateEditDate.EditValue = new System.DateTime(2016, 9, 6, 14, 6, 23, 0);
            this.dateEditDate.Location = new System.Drawing.Point(107, 145);
            this.dateEditDate.Name = "dateEditDate";
            this.dateEditDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDate.Size = new System.Drawing.Size(104, 20);
            this.dateEditDate.TabIndex = 20;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(107, 81);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(33, 13);
            this.labelControl10.TabIndex = 21;
            this.labelControl10.Text = "Выдан";
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.EditValue = "Активный";
            this.comboBoxEdit1.Location = new System.Drawing.Point(410, 50);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "Активный",
            "Должник",
            "Запрет по СБ"});
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new System.Drawing.Size(126, 20);
            this.comboBoxEdit1.TabIndex = 22;
            // 
            // labelControlstatus
            // 
            this.labelControlstatus.Location = new System.Drawing.Point(410, 31);
            this.labelControlstatus.Name = "labelControlstatus";
            this.labelControlstatus.Size = new System.Drawing.Size(36, 13);
            this.labelControlstatus.TabIndex = 23;
            this.labelControlstatus.Text = "Статус";
            // 
            // simpleButtonNext
            // 
            this.simpleButtonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonNext.Appearance.BackColor = System.Drawing.Color.DarkOrange;
            this.simpleButtonNext.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButtonNext.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButtonNext.Appearance.Options.UseBackColor = true;
            this.simpleButtonNext.Appearance.Options.UseFont = true;
            this.simpleButtonNext.Appearance.Options.UseForeColor = true;
            this.simpleButtonNext.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.simpleButtonNext.Location = new System.Drawing.Point(482, 218);
            this.simpleButtonNext.Name = "simpleButtonNext";
            this.simpleButtonNext.Size = new System.Drawing.Size(205, 33);
            this.simpleButtonNext.TabIndex = 24;
            this.simpleButtonNext.Text = "Сохранить";
            this.simpleButtonNext.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // textEditBorn
            // 
            this.textEditBorn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditBorn.Cue = "Город";
            this.textEditBorn.Location = new System.Drawing.Point(522, 190);
            this.textEditBorn.Name = "textEditBorn";
            this.textEditBorn.Size = new System.Drawing.Size(165, 20);
            this.textEditBorn.TabIndex = 18;
            // 
            // textEditAddress
            // 
            this.textEditAddress.Cue = "Город, улица, дом, квартира";
            this.textEditAddress.Location = new System.Drawing.Point(18, 190);
            this.textEditAddress.Name = "textEditAddress";
            this.textEditAddress.Size = new System.Drawing.Size(498, 20);
            this.textEditAddress.TabIndex = 16;
            // 
            // textEditRegistration
            // 
            this.textEditRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditRegistration.Cue = "Город, улица, дом, квартира";
            this.textEditRegistration.Location = new System.Drawing.Point(217, 145);
            this.textEditRegistration.Name = "textEditRegistration";
            this.textEditRegistration.Size = new System.Drawing.Size(470, 20);
            this.textEditRegistration.TabIndex = 14;
            // 
            // textEditLicense
            // 
            this.textEditLicense.Cue = "32 ВТ 41920";
            this.textEditLicense.Location = new System.Drawing.Point(18, 145);
            this.textEditLicense.Name = "textEditLicense";
            this.textEditLicense.Size = new System.Drawing.Size(83, 20);
            this.textEditLicense.TabIndex = 12;
            // 
            // textEditCode
            // 
            this.textEditCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditCode.Cue = "100-100";
            this.textEditCode.Location = new System.Drawing.Point(583, 100);
            this.textEditCode.Name = "textEditCode";
            this.textEditCode.Size = new System.Drawing.Size(104, 20);
            this.textEditCode.TabIndex = 10;
            // 
            // textEditWho
            // 
            this.textEditWho.Cue = "Кем выдан";
            this.textEditWho.Location = new System.Drawing.Point(217, 100);
            this.textEditWho.Name = "textEditWho";
            this.textEditWho.Size = new System.Drawing.Size(360, 20);
            this.textEditWho.TabIndex = 8;
            // 
            // textEditPassport
            // 
            this.textEditPassport.Cue = "1112 415432";
            this.textEditPassport.Location = new System.Drawing.Point(18, 100);
            this.textEditPassport.Name = "textEditPassport";
            this.textEditPassport.Size = new System.Drawing.Size(83, 20);
            this.textEditPassport.TabIndex = 6;
            // 
            // textEditPhone
            // 
            this.textEditPhone.Cue = "+7 (929) 111-11-11";
            this.textEditPhone.Location = new System.Drawing.Point(214, 50);
            this.textEditPhone.Name = "textEditPhone";
            this.textEditPhone.Size = new System.Drawing.Size(190, 20);
            this.textEditPhone.TabIndex = 4;
            // 
            // textEditFio
            // 
            this.textEditFio.Cue = "Алексеев Иван Иванович";
            this.textEditFio.Location = new System.Drawing.Point(18, 50);
            this.textEditFio.Name = "textEditFio";
            this.textEditFio.Size = new System.Drawing.Size(190, 20);
            this.textEditFio.TabIndex = 1;
            // 
            // AddClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(699, 261);
            this.Controls.Add(this.simpleButtonNext);
            this.Controls.Add(this.labelControlstatus);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.dateEditDate);
            this.Controls.Add(this.textEditBorn);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.textEditAddress);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.textEditRegistration);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.textEditLicense);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.textEditCode);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.textEditWho);
            this.Controls.Add(this.textEditPassport);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.textEditPhone);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.dateEditWhen);
            this.Controls.Add(this.textEditFio);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(715, 300);
            this.Name = "AddClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить нового клиента";
            this.Load += new System.EventHandler(this.AddClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditWhen.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditWhen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private CueTextBox textEditFio;
        private DevExpress.XtraEditors.DateEdit dateEditWhen;
        private CueTextBox textEditPhone;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private CueTextBox textEditPassport;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private CueTextBox textEditWho;
        private CueTextBox textEditCode;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private CueTextBox textEditLicense;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private CueTextBox textEditRegistration;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private CueTextBox textEditAddress;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private CueTextBox textEditBorn;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.DateEdit dateEditDate;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControlstatus;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNext;
    }
}