namespace Avtorentovik.Forms
{
    partial class DamagesForm
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
            this.gridControlDamages = new DevExpress.XtraGrid.GridControl();
            this.gridViewDamages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButtonDeleteDamage = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonChangeDamage = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAddDamage = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDamages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDamages)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlDamages
            // 
            this.gridControlDamages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlDamages.Location = new System.Drawing.Point(12, 50);
            this.gridControlDamages.MainView = this.gridViewDamages;
            this.gridControlDamages.Name = "gridControlDamages";
            this.gridControlDamages.Size = new System.Drawing.Size(538, 335);
            this.gridControlDamages.TabIndex = 11;
            this.gridControlDamages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDamages});
            // 
            // gridViewDamages
            // 
            this.gridViewDamages.GridControl = this.gridControlDamages;
            this.gridViewDamages.Name = "gridViewDamages";
            this.gridViewDamages.OptionsBehavior.ReadOnly = true;
            this.gridViewDamages.OptionsView.ShowGroupPanel = false;
            // 
            // simpleButtonDeleteDamage
            // 
            this.simpleButtonDeleteDamage.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButtonDeleteDamage.Appearance.Options.UseBackColor = true;
            this.simpleButtonDeleteDamage.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButtonDeleteDamage.Location = new System.Drawing.Point(174, 21);
            this.simpleButtonDeleteDamage.Name = "simpleButtonDeleteDamage";
            this.simpleButtonDeleteDamage.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonDeleteDamage.TabIndex = 10;
            this.simpleButtonDeleteDamage.Text = "Удалить";
            this.simpleButtonDeleteDamage.Click += new System.EventHandler(this.simpleButtonDeleteDamage_Click);
            // 
            // simpleButtonChangeDamage
            // 
            this.simpleButtonChangeDamage.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButtonChangeDamage.Appearance.Options.UseBackColor = true;
            this.simpleButtonChangeDamage.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButtonChangeDamage.Location = new System.Drawing.Point(93, 21);
            this.simpleButtonChangeDamage.Name = "simpleButtonChangeDamage";
            this.simpleButtonChangeDamage.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonChangeDamage.TabIndex = 9;
            this.simpleButtonChangeDamage.Text = "Изменить";
            this.simpleButtonChangeDamage.Click += new System.EventHandler(this.simpleButtonChangeDamage_Click);
            // 
            // simpleButtonAddDamage
            // 
            this.simpleButtonAddDamage.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButtonAddDamage.Appearance.Options.UseBackColor = true;
            this.simpleButtonAddDamage.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButtonAddDamage.Location = new System.Drawing.Point(12, 21);
            this.simpleButtonAddDamage.Name = "simpleButtonAddDamage";
            this.simpleButtonAddDamage.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonAddDamage.TabIndex = 8;
            this.simpleButtonAddDamage.Text = "Добавить";
            this.simpleButtonAddDamage.Click += new System.EventHandler(this.simpleButtonAddDamage_Click);
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
            this.simpleButton1.Location = new System.Drawing.Point(460, 391);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(90, 33);
            this.simpleButton1.TabIndex = 13;
            this.simpleButton1.Text = "Закрыть";
            // 
            // simpleButtonAdd
            // 
            this.simpleButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonAdd.Appearance.BackColor = System.Drawing.Color.DarkOrange;
            this.simpleButtonAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButtonAdd.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButtonAdd.Appearance.Options.UseBackColor = true;
            this.simpleButtonAdd.Appearance.Options.UseFont = true;
            this.simpleButtonAdd.Appearance.Options.UseForeColor = true;
            this.simpleButtonAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButtonAdd.Location = new System.Drawing.Point(364, 391);
            this.simpleButtonAdd.Name = "simpleButtonAdd";
            this.simpleButtonAdd.Size = new System.Drawing.Size(90, 33);
            this.simpleButtonAdd.TabIndex = 12;
            this.simpleButtonAdd.Text = "Сохранить";
            this.simpleButtonAdd.Click += new System.EventHandler(this.simpleButtonAdd_Click);
            // 
            // DamagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.simpleButton1;
            this.ClientSize = new System.Drawing.Size(562, 433);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.simpleButtonAdd);
            this.Controls.Add(this.gridControlDamages);
            this.Controls.Add(this.simpleButtonDeleteDamage);
            this.Controls.Add(this.simpleButtonChangeDamage);
            this.Controls.Add(this.simpleButtonAddDamage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DamagesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Повреждения";
            this.Load += new System.EventHandler(this.DamagesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDamages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDamages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlDamages;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDamages;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDeleteDamage;
        private DevExpress.XtraEditors.SimpleButton simpleButtonChangeDamage;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAddDamage;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAdd;
    }
}