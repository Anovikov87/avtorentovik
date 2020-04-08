namespace Avtorentovik.Forms
{
    partial class AddOrderForm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlClient = new DevExpress.XtraEditors.LabelControl();
            this.labelControlNumber = new DevExpress.XtraEditors.LabelControl();
            this.labelControlPhone = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTerritory = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlDelete = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTotal = new DevExpress.XtraEditors.LabelControl();
            this.labelControlDiscount = new DevExpress.XtraEditors.LabelControl();
            this.timeEditFrom = new DevExpress.XtraEditors.TimeEdit();
            this.dateEditFrom = new DevExpress.XtraEditors.DateEdit();
            this.dateEditTo = new DevExpress.XtraEditors.DateEdit();
            this.timeEditTo = new DevExpress.XtraEditors.TimeEdit();
            this.comboBoxEditCars = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditClients = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.textEditTerritory = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditDiscount = new DevExpress.XtraEditors.SpinEdit();
            this.comboBoxEditDiscount = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditCars.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditClients.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTerritory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditDiscount.Properties)).BeginInit();
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
            this.simpleButton1.Location = new System.Drawing.Point(371, 383);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(132, 33);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Закрыть";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButtonPrint
            // 
            this.simpleButtonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonPrint.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButtonPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButtonPrint.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.simpleButtonPrint.Appearance.Options.UseBackColor = true;
            this.simpleButtonPrint.Appearance.Options.UseFont = true;
            this.simpleButtonPrint.Appearance.Options.UseForeColor = true;
            this.simpleButtonPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButtonPrint.Location = new System.Drawing.Point(185, 383);
            this.simpleButtonPrint.Name = "simpleButtonPrint";
            this.simpleButtonPrint.Size = new System.Drawing.Size(180, 33);
            this.simpleButtonPrint.TabIndex = 3;
            this.simpleButtonPrint.Text = "Распечатать договор";
            this.simpleButtonPrint.Click += new System.EventHandler(this.simpleButtonPrint_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Автомобиль";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Location = new System.Drawing.Point(264, 23);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Клиент";
            // 
            // labelControlClient
            // 
            this.labelControlClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlClient.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelControlClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControlClient.Location = new System.Drawing.Point(264, 68);
            this.labelControlClient.Name = "labelControlClient";
            this.labelControlClient.Size = new System.Drawing.Size(72, 13);
            this.labelControlClient.TabIndex = 7;
            this.labelControlClient.Text = "Новый клиент";
            this.labelControlClient.Click += new System.EventHandler(this.labelControlClient_Click);
            // 
            // labelControlNumber
            // 
            this.labelControlNumber.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControlNumber.Location = new System.Drawing.Point(24, 68);
            this.labelControlNumber.Name = "labelControlNumber";
            this.labelControlNumber.Size = new System.Drawing.Size(44, 13);
            this.labelControlNumber.TabIndex = 6;
            this.labelControlNumber.Text = "Госзнак:";
            // 
            // labelControlPhone
            // 
            this.labelControlPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlPhone.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControlPhone.Location = new System.Drawing.Point(264, 87);
            this.labelControlPhone.Name = "labelControlPhone";
            this.labelControlPhone.Size = new System.Drawing.Size(48, 13);
            this.labelControlPhone.TabIndex = 9;
            this.labelControlPhone.Text = "Телефон:";
            // 
            // labelControlTerritory
            // 
            this.labelControlTerritory.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControlTerritory.Location = new System.Drawing.Point(24, 87);
            this.labelControlTerritory.Name = "labelControlTerritory";
            this.labelControlTerritory.Size = new System.Drawing.Size(42, 13);
            this.labelControlTerritory.TabIndex = 8;
            this.labelControlTerritory.Text = "Филиал:";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl7.Location = new System.Drawing.Point(264, 112);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(125, 13);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "Дата окончания аренды";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(24, 112);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(111, 13);
            this.labelControl8.TabIndex = 10;
            this.labelControl8.Text = "Дата начала аренды:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(30, 298);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(137, 13);
            this.labelControl9.TabIndex = 13;
            this.labelControl9.Text = "Территория эксплуатации:";
            // 
            // labelControlDelete
            // 
            this.labelControlDelete.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelControlDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControlDelete.Location = new System.Drawing.Point(24, 392);
            this.labelControlDelete.Name = "labelControlDelete";
            this.labelControlDelete.Size = new System.Drawing.Size(124, 13);
            this.labelControlDelete.TabIndex = 14;
            this.labelControlDelete.Text = "Удалить бронирование?";
            this.labelControlDelete.Click += new System.EventHandler(this.labelControlDelete_Click);
            // 
            // labelControlTotal
            // 
            this.labelControlTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlTotal.Location = new System.Drawing.Point(285, 305);
            this.labelControlTotal.Name = "labelControlTotal";
            this.labelControlTotal.Size = new System.Drawing.Size(34, 13);
            this.labelControlTotal.TabIndex = 15;
            this.labelControlTotal.Text = "Итого:";
            // 
            // labelControlDiscount
            // 
            this.labelControlDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlDiscount.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelControlDiscount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControlDiscount.Location = new System.Drawing.Point(285, 324);
            this.labelControlDiscount.Name = "labelControlDiscount";
            this.labelControlDiscount.Size = new System.Drawing.Size(175, 13);
            this.labelControlDiscount.TabIndex = 16;
            this.labelControlDiscount.Text = "Сделать индивидуальную скидку";
            this.labelControlDiscount.Click += new System.EventHandler(this.labelControlDiscount_Click);
            // 
            // timeEditFrom
            // 
            this.timeEditFrom.EditValue = new System.DateTime(2016, 9, 15, 10, 0, 0, 0);
            this.timeEditFrom.Location = new System.Drawing.Point(144, 131);
            this.timeEditFrom.Name = "timeEditFrom";
            this.timeEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.timeEditFrom.Size = new System.Drawing.Size(100, 20);
            this.timeEditFrom.TabIndex = 17;
            // 
            // dateEditFrom
            // 
            this.dateEditFrom.EditValue = null;
            this.dateEditFrom.Location = new System.Drawing.Point(24, 131);
            this.dateEditFrom.Name = "dateEditFrom";
            this.dateEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFrom.Size = new System.Drawing.Size(100, 20);
            this.dateEditFrom.TabIndex = 18;
            // 
            // dateEditTo
            // 
            this.dateEditTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEditTo.EditValue = null;
            this.dateEditTo.Location = new System.Drawing.Point(264, 131);
            this.dateEditTo.Name = "dateEditTo";
            this.dateEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Size = new System.Drawing.Size(100, 20);
            this.dateEditTo.TabIndex = 20;
            this.dateEditTo.EditValueChanged += new System.EventHandler(this.dateEditTo_EditValueChanged);
            // 
            // timeEditTo
            // 
            this.timeEditTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeEditTo.EditValue = new System.DateTime(2016, 9, 15, 10, 0, 0, 0);
            this.timeEditTo.Location = new System.Drawing.Point(384, 131);
            this.timeEditTo.Name = "timeEditTo";
            this.timeEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.timeEditTo.Size = new System.Drawing.Size(100, 20);
            this.timeEditTo.TabIndex = 19;
            // 
            // comboBoxEditCars
            // 
            this.comboBoxEditCars.Location = new System.Drawing.Point(24, 42);
            this.comboBoxEditCars.Name = "comboBoxEditCars";
            this.comboBoxEditCars.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditCars.Size = new System.Drawing.Size(220, 20);
            this.comboBoxEditCars.TabIndex = 21;
            this.comboBoxEditCars.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditCars_SelectedIndexChanged);
            // 
            // comboBoxEditClients
            // 
            this.comboBoxEditClients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEditClients.Location = new System.Drawing.Point(264, 42);
            this.comboBoxEditClients.Name = "comboBoxEditClients";
            this.comboBoxEditClients.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditClients.Size = new System.Drawing.Size(220, 20);
            this.comboBoxEditClients.TabIndex = 22;
            this.comboBoxEditClients.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditClients_SelectedIndexChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Location = new System.Drawing.Point(24, 190);
            this.groupControl1.LookAndFeel.SkinName = "Office 2013";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(460, 85);
            this.groupControl1.TabIndex = 23;
            this.groupControl1.Text = "Дополнительные услуги";
            // 
            // textEditTerritory
            // 
            this.textEditTerritory.Location = new System.Drawing.Point(24, 317);
            this.textEditTerritory.Name = "textEditTerritory";
            this.textEditTerritory.Size = new System.Drawing.Size(220, 20);
            this.textEditTerritory.TabIndex = 24;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 171);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(129, 13);
            this.labelControl3.TabIndex = 25;
            this.labelControl3.Text = "Дополнительные услуги:";
            // 
            // spinEditDiscount
            // 
            this.spinEditDiscount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditDiscount.Location = new System.Drawing.Point(285, 321);
            this.spinEditDiscount.Name = "spinEditDiscount";
            this.spinEditDiscount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditDiscount.Properties.DisplayFormat.FormatString = "N00";
            this.spinEditDiscount.Properties.EditFormat.FormatString = "N00";
            this.spinEditDiscount.Properties.Mask.EditMask = "N00";
            this.spinEditDiscount.Size = new System.Drawing.Size(119, 20);
            this.spinEditDiscount.TabIndex = 26;
            this.spinEditDiscount.Visible = false;
            this.spinEditDiscount.ValueChanged += new System.EventHandler(this.spinEditDiscount_ValueChanged);
            // 
            // comboBoxEditDiscount
            // 
            this.comboBoxEditDiscount.EditValue = "%";
            this.comboBoxEditDiscount.Location = new System.Drawing.Point(410, 321);
            this.comboBoxEditDiscount.Name = "comboBoxEditDiscount";
            this.comboBoxEditDiscount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditDiscount.Properties.Items.AddRange(new object[] {
            "%",
            "руб"});
            this.comboBoxEditDiscount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditDiscount.Size = new System.Drawing.Size(50, 20);
            this.comboBoxEditDiscount.TabIndex = 27;
            this.comboBoxEditDiscount.Visible = false;
            this.comboBoxEditDiscount.EditValueChanged += new System.EventHandler(this.comboBoxEditDiscount_EditValueChanged);
            // 
            // AddOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(515, 428);
            this.Controls.Add(this.comboBoxEditDiscount);
            this.Controls.Add(this.spinEditDiscount);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.textEditTerritory);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.comboBoxEditClients);
            this.Controls.Add(this.comboBoxEditCars);
            this.Controls.Add(this.dateEditTo);
            this.Controls.Add(this.timeEditTo);
            this.Controls.Add(this.dateEditFrom);
            this.Controls.Add(this.timeEditFrom);
            this.Controls.Add(this.labelControlDiscount);
            this.Controls.Add(this.labelControlTotal);
            this.Controls.Add(this.labelControlDelete);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControlPhone);
            this.Controls.Add(this.labelControlTerritory);
            this.Controls.Add(this.labelControlClient);
            this.Controls.Add(this.labelControlNumber);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButtonPrint);
            this.Controls.Add(this.simpleButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление бронированием";
            this.Load += new System.EventHandler(this.AddOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timeEditFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditCars.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditClients.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTerritory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditDiscount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonPrint;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControlClient;
        private DevExpress.XtraEditors.LabelControl labelControlNumber;
        private DevExpress.XtraEditors.LabelControl labelControlPhone;
        private DevExpress.XtraEditors.LabelControl labelControlTerritory;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControlDelete;
        private DevExpress.XtraEditors.LabelControl labelControlTotal;
        private DevExpress.XtraEditors.LabelControl labelControlDiscount;
        private DevExpress.XtraEditors.TimeEdit timeEditFrom;
        private DevExpress.XtraEditors.DateEdit dateEditFrom;
        private DevExpress.XtraEditors.DateEdit dateEditTo;
        private DevExpress.XtraEditors.TimeEdit timeEditTo;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditCars;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditClients;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit textEditTerritory;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spinEditDiscount;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditDiscount;
    }
}