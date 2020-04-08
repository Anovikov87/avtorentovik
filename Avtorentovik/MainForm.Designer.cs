namespace Avtorentovik
{
    partial class MainForm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageCars = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlMain = new DevExpress.XtraGrid.GridControl();
            this.gridViewMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDeleteCar = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAddCar = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageRents = new DevExpress.XtraTab.XtraTabPage();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.carPanel1 = new Avtorentovik.Controls.CarPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xtraScrollableControl2 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.panelControlDate = new DevExpress.XtraEditors.PanelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.spinEditYear = new DevExpress.XtraEditors.SpinEdit();
            this.comboBoxEditMonths = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateControl1 = new Avtorentovik.Controls.DateControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxEditSpot = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditKpp = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditBodyType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditMarks = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditModels = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabPageClients = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonDeleteClient = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAddClient = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageOrders = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPageCars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.xtraTabPageRents.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carPanel1)).BeginInit();
            this.xtraScrollableControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlDate)).BeginInit();
            this.panelControlDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMonths.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSpot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditKpp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditBodyType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditModels.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.xtraTabPageClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.xtraTabPageOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.xtraTabControl1.Appearance.Options.UseBackColor = true;
            serializableAppearanceObject2.Image = global::Avtorentovik.Properties.Resources.settings_icon;
            serializableAppearanceObject2.Options.UseImage = true;
            this.xtraTabControl1.CustomHeaderButtons.AddRange(new DevExpress.XtraTab.Buttons.CustomHeaderButton[] {
            new DevExpress.XtraTab.Buttons.CustomHeaderButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Выйти из системы", -1, true, true, DevExpress.XtraEditors.ImageLocation.Default, null, serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraTab.Buttons.CustomHeaderButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Настройки", -1, true, true, DevExpress.XtraEditors.ImageLocation.MiddleLeft, global::Avtorentovik.Properties.Resources.settings_icon_small, serializableAppearanceObject2, "", null, null, true)});
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.LookAndFeel.SkinName = "Office 2010 Black";
            this.xtraTabControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.PageImagePosition = DevExpress.XtraTab.TabPageImagePosition.Center;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageCars;
            this.xtraTabControl1.Size = new System.Drawing.Size(1042, 441);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageRents,
            this.xtraTabPageCars,
            this.xtraTabPageClients,
            this.xtraTabPageOrders});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            this.xtraTabControl1.CustomHeaderButtonClick += new DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventHandler(this.xtraTabControl1_CustomHeaderButtonClick);
            // 
            // xtraTabPageCars
            // 
            this.xtraTabPageCars.Appearance.Header.Image = global::Avtorentovik.Properties.Resources.New_Bitmap_Image;
            this.xtraTabPageCars.Appearance.Header.Options.UseImage = true;
            this.xtraTabPageCars.Appearance.HeaderActive.Image = global::Avtorentovik.Properties.Resources.New_Bitmap_Image;
            this.xtraTabPageCars.Appearance.HeaderActive.Options.UseImage = true;
            this.xtraTabPageCars.Controls.Add(this.gridControlMain);
            this.xtraTabPageCars.Controls.Add(this.panelControl1);
            this.xtraTabPageCars.ImageIndex = 0;
            this.xtraTabPageCars.ImagePadding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.xtraTabPageCars.Name = "xtraTabPageCars";
            this.xtraTabPageCars.Size = new System.Drawing.Size(1036, 413);
            this.xtraTabPageCars.Text = "Автомобили";
            // 
            // gridControlMain
            // 
            this.gridControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMain.Location = new System.Drawing.Point(0, 58);
            this.gridControlMain.MainView = this.gridViewMain;
            this.gridControlMain.Name = "gridControlMain";
            this.gridControlMain.Size = new System.Drawing.Size(1036, 355);
            this.gridControlMain.TabIndex = 2;
            this.gridControlMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMain});
            // 
            // gridViewMain
            // 
            this.gridViewMain.GridControl = this.gridControlMain;
            this.gridViewMain.Name = "gridViewMain";
            this.gridViewMain.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewMain.OptionsFind.AlwaysVisible = true;
            this.gridViewMain.OptionsFind.FindNullPrompt = "Введите текст для поиска";
            this.gridViewMain.OptionsFind.ShowCloseButton = false;
            this.gridViewMain.OptionsSelection.MultiSelect = true;
            this.gridViewMain.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewMain.OptionsView.RowAutoHeight = true;
            this.gridViewMain.OptionsView.ShowAutoFilterRow = true;
            this.gridViewMain.OptionsView.ShowGroupPanel = false;
            this.gridViewMain.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewMain_RowStyle);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.simpleButtonDeleteCar);
            this.panelControl1.Controls.Add(this.simpleButtonAddCar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1036, 58);
            this.panelControl1.TabIndex = 5;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.BackColor2 = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton1.Location = new System.Drawing.Point(170, 20);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(153, 23);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Редактировать автомобиль";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButtonDeleteCar
            // 
            this.simpleButtonDeleteCar.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButtonDeleteCar.Appearance.BackColor2 = System.Drawing.Color.White;
            this.simpleButtonDeleteCar.Appearance.Options.UseBackColor = true;
            this.simpleButtonDeleteCar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButtonDeleteCar.Location = new System.Drawing.Point(329, 20);
            this.simpleButtonDeleteCar.Name = "simpleButtonDeleteCar";
            this.simpleButtonDeleteCar.Size = new System.Drawing.Size(128, 23);
            this.simpleButtonDeleteCar.TabIndex = 4;
            this.simpleButtonDeleteCar.Text = "Удалить отмеченные";
            this.simpleButtonDeleteCar.Click += new System.EventHandler(this.simpleButtonDeleteCar_Click);
            // 
            // simpleButtonAddCar
            // 
            this.simpleButtonAddCar.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButtonAddCar.Appearance.BackColor2 = System.Drawing.Color.White;
            this.simpleButtonAddCar.Appearance.Options.UseBackColor = true;
            this.simpleButtonAddCar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButtonAddCar.Location = new System.Drawing.Point(11, 20);
            this.simpleButtonAddCar.Name = "simpleButtonAddCar";
            this.simpleButtonAddCar.Size = new System.Drawing.Size(153, 23);
            this.simpleButtonAddCar.TabIndex = 3;
            this.simpleButtonAddCar.Text = "+Добавить автомобиль";
            this.simpleButtonAddCar.Click += new System.EventHandler(this.simpleButtonAddCar_Click);
            // 
            // xtraTabPageRents
            // 
            this.xtraTabPageRents.Controls.Add(this.xtraScrollableControl1);
            this.xtraTabPageRents.Controls.Add(this.xtraScrollableControl2);
            this.xtraTabPageRents.Controls.Add(this.panelControl5);
            this.xtraTabPageRents.Controls.Add(this.panelControl4);
            this.xtraTabPageRents.Name = "xtraTabPageRents";
            this.xtraTabPageRents.Size = new System.Drawing.Size(1036, 413);
            this.xtraTabPageRents.Text = "График занятости автомобилей";
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraScrollableControl1.Controls.Add(this.carPanel1);
            this.xtraScrollableControl1.Controls.Add(this.panel1);
            this.xtraScrollableControl1.FireScrollEventOnMouseWheel = true;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 119);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(1036, 288);
            this.xtraScrollableControl1.TabIndex = 4;
            this.xtraScrollableControl1.Scroll += new DevExpress.XtraEditors.XtraScrollEventHandler(this.xtraScrollableControl1_Scroll);
            this.xtraScrollableControl1.Click += new System.EventHandler(this.xtraScrollableControl1_Click);
            // 
            // carPanel1
            // 
            this.carPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.carPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.carPanel1.Location = new System.Drawing.Point(0, 0);
            this.carPanel1.Name = "carPanel1";
            this.carPanel1.Size = new System.Drawing.Size(1440, 0);
            this.carPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1440, 0);
            this.panel1.TabIndex = 6;
            // 
            // xtraScrollableControl2
            // 
            this.xtraScrollableControl2.Controls.Add(this.panelControlDate);
            this.xtraScrollableControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraScrollableControl2.FireScrollEventOnMouseWheel = true;
            this.xtraScrollableControl2.Location = new System.Drawing.Point(0, 64);
            this.xtraScrollableControl2.Name = "xtraScrollableControl2";
            this.xtraScrollableControl2.Size = new System.Drawing.Size(1036, 79);
            this.xtraScrollableControl2.TabIndex = 14;
            this.xtraScrollableControl2.Scroll += new DevExpress.XtraEditors.XtraScrollEventHandler(this.xtraScrollableControl2_Scroll);
            // 
            // panelControlDate
            // 
            this.panelControlDate.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControlDate.Appearance.Options.UseBackColor = true;
            this.panelControlDate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlDate.Controls.Add(this.panelControl6);
            this.panelControlDate.Controls.Add(this.dateControl1);
            this.panelControlDate.Location = new System.Drawing.Point(0, 0);
            this.panelControlDate.LookAndFeel.SkinName = "Office 2013";
            this.panelControlDate.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControlDate.Name = "panelControlDate";
            this.panelControlDate.Size = new System.Drawing.Size(1457, 55);
            this.panelControlDate.TabIndex = 14;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.spinEditYear);
            this.panelControl6.Controls.Add(this.comboBoxEditMonths);
            this.panelControl6.Location = new System.Drawing.Point(0, 0);
            this.panelControl6.LookAndFeel.SkinName = "Office 2010 Black";
            this.panelControl6.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(200, 55);
            this.panelControl6.TabIndex = 5;
            // 
            // spinEditYear
            // 
            this.spinEditYear.EditValue = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            this.spinEditYear.Location = new System.Drawing.Point(111, 19);
            this.spinEditYear.Name = "spinEditYear";
            this.spinEditYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditYear.Properties.DisplayFormat.FormatString = "d";
            this.spinEditYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.spinEditYear.Properties.EditFormat.FormatString = "d";
            this.spinEditYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.spinEditYear.Properties.IsFloatValue = false;
            this.spinEditYear.Properties.Mask.EditMask = "d";
            this.spinEditYear.Size = new System.Drawing.Size(79, 20);
            this.spinEditYear.TabIndex = 5;
            this.spinEditYear.EditValueChanged += new System.EventHandler(this.spinEdit1_EditValueChanged);
            // 
            // comboBoxEditMonths
            // 
            this.comboBoxEditMonths.Location = new System.Drawing.Point(11, 19);
            this.comboBoxEditMonths.Name = "comboBoxEditMonths";
            this.comboBoxEditMonths.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditMonths.Properties.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.comboBoxEditMonths.Size = new System.Drawing.Size(94, 20);
            this.comboBoxEditMonths.TabIndex = 4;
            this.comboBoxEditMonths.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditMonths_SelectedIndexChanged);
            // 
            // dateControl1
            // 
            this.dateControl1.Location = new System.Drawing.Point(200, 0);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Size = new System.Drawing.Size(1240, 55);
            this.dateControl1.TabIndex = 4;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.comboBoxEditSpot);
            this.panelControl5.Controls.Add(this.comboBoxEditKpp);
            this.panelControl5.Controls.Add(this.comboBoxEditBodyType);
            this.panelControl5.Controls.Add(this.comboBoxEditMarks);
            this.panelControl5.Controls.Add(this.comboBoxEditModels);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl5.Location = new System.Drawing.Point(0, 25);
            this.panelControl5.LookAndFeel.SkinName = "Office 2010 Black";
            this.panelControl5.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(1036, 39);
            this.panelControl5.TabIndex = 1;
            // 
            // comboBoxEditSpot
            // 
            this.comboBoxEditSpot.EditValue = "Пункт выдачи";
            this.comboBoxEditSpot.Location = new System.Drawing.Point(612, 6);
            this.comboBoxEditSpot.Name = "comboBoxEditSpot";
            this.comboBoxEditSpot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSpot.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEditSpot.TabIndex = 4;
            this.comboBoxEditSpot.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditSpot_SelectedIndexChanged);
            // 
            // comboBoxEditKpp
            // 
            this.comboBoxEditKpp.EditValue = "Тип КПП";
            this.comboBoxEditKpp.Location = new System.Drawing.Point(506, 6);
            this.comboBoxEditKpp.Name = "comboBoxEditKpp";
            this.comboBoxEditKpp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditKpp.Properties.Items.AddRange(new object[] {
            "Все типы КПП",
            "Ручная",
            "АКПП"});
            this.comboBoxEditKpp.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEditKpp.TabIndex = 3;
            this.comboBoxEditKpp.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditKpp_SelectedIndexChanged);
            // 
            // comboBoxEditBodyType
            // 
            this.comboBoxEditBodyType.EditValue = "Тип кузова";
            this.comboBoxEditBodyType.Location = new System.Drawing.Point(400, 6);
            this.comboBoxEditBodyType.Name = "comboBoxEditBodyType";
            this.comboBoxEditBodyType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditBodyType.Properties.Items.AddRange(new object[] {
            "Все типы кузова",
            "Седан",
            "Хэтчбек",
            "Универсал",
            "Внедорожник",
            "Кабриолет",
            "Минивен",
            "Микроавтобус",
            "Грузовой"});
            this.comboBoxEditBodyType.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEditBodyType.TabIndex = 2;
            this.comboBoxEditBodyType.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditBodyType_SelectedIndexChanged);
            // 
            // comboBoxEditMarks
            // 
            this.comboBoxEditMarks.EditValue = "Марка";
            this.comboBoxEditMarks.Location = new System.Drawing.Point(248, 6);
            this.comboBoxEditMarks.Name = "comboBoxEditMarks";
            this.comboBoxEditMarks.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditMarks.Size = new System.Drawing.Size(146, 20);
            this.comboBoxEditMarks.TabIndex = 1;
            this.comboBoxEditMarks.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditMarks_SelectedIndexChanged);
            // 
            // comboBoxEditModels
            // 
            this.comboBoxEditModels.EditValue = "Начните вводить модель авто";
            this.comboBoxEditModels.Location = new System.Drawing.Point(11, 6);
            this.comboBoxEditModels.Name = "comboBoxEditModels";
            this.comboBoxEditModels.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditModels.Size = new System.Drawing.Size(231, 20);
            this.comboBoxEditModels.TabIndex = 0;
            this.comboBoxEditModels.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditModels_SelectedIndexChanged);
            // 
            // panelControl4
            // 
            this.panelControl4.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl4.Appearance.Options.UseBackColor = true;
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(1036, 25);
            this.panelControl4.TabIndex = 0;
            // 
            // xtraTabPageClients
            // 
            this.xtraTabPageClients.Controls.Add(this.panelControl2);
            this.xtraTabPageClients.Name = "xtraTabPageClients";
            this.xtraTabPageClients.Size = new System.Drawing.Size(1036, 413);
            this.xtraTabPageClients.Text = "Клиенты";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.BackColor2 = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.simpleButtonDeleteClient);
            this.panelControl2.Controls.Add(this.simpleButtonAddClient);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1036, 58);
            this.panelControl2.TabIndex = 6;
            // 
            // simpleButtonDeleteClient
            // 
            this.simpleButtonDeleteClient.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButtonDeleteClient.Appearance.BackColor2 = System.Drawing.Color.White;
            this.simpleButtonDeleteClient.Appearance.Options.UseBackColor = true;
            this.simpleButtonDeleteClient.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButtonDeleteClient.Location = new System.Drawing.Point(181, 20);
            this.simpleButtonDeleteClient.Name = "simpleButtonDeleteClient";
            this.simpleButtonDeleteClient.Size = new System.Drawing.Size(128, 23);
            this.simpleButtonDeleteClient.TabIndex = 4;
            this.simpleButtonDeleteClient.Text = "Удалить отмеченных";
            this.simpleButtonDeleteClient.Click += new System.EventHandler(this.simpleButtonDeleteClient_Click);
            // 
            // simpleButtonAddClient
            // 
            this.simpleButtonAddClient.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButtonAddClient.Appearance.BackColor2 = System.Drawing.Color.White;
            this.simpleButtonAddClient.Appearance.Options.UseBackColor = true;
            this.simpleButtonAddClient.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButtonAddClient.Location = new System.Drawing.Point(11, 20);
            this.simpleButtonAddClient.Name = "simpleButtonAddClient";
            this.simpleButtonAddClient.Size = new System.Drawing.Size(153, 23);
            this.simpleButtonAddClient.TabIndex = 3;
            this.simpleButtonAddClient.Text = "+Добавить клиента";
            this.simpleButtonAddClient.Click += new System.EventHandler(this.simpleButtonAddClient_Click);
            // 
            // xtraTabPageOrders
            // 
            this.xtraTabPageOrders.Controls.Add(this.panelControl3);
            this.xtraTabPageOrders.Name = "xtraTabPageOrders";
            this.xtraTabPageOrders.Size = new System.Drawing.Size(1036, 413);
            this.xtraTabPageOrders.Text = "Заказы";
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl3.Appearance.BackColor2 = System.Drawing.Color.White;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1036, 10);
            this.panelControl3.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 441);
            this.Controls.Add(this.xtraTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avtorentovik - мой автопрокат";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPageCars.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.xtraTabPageRents.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carPanel1)).EndInit();
            this.xtraScrollableControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlDate)).EndInit();
            this.panelControlDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMonths.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSpot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditKpp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditBodyType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditModels.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.xtraTabPageClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.xtraTabPageOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraTab.XtraTabPage xtraTabPageCars;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageClients;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageOrders;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDeleteCar;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAddCar;
        private DevExpress.XtraGrid.GridControl gridControlMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMain;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDeleteClient;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAddClient;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageRents;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSpot;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditKpp;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditBodyType;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditMarks;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditModels;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private System.Windows.Forms.Panel panel1;
        private Controls.CarPanel carPanel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl2;
        private DevExpress.XtraEditors.PanelControl panelControlDate;
        private Controls.DateControl dateControl1;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SpinEdit spinEditYear;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditMonths;
    }
}