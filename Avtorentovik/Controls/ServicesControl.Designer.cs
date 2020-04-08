using System.Windows.Forms;

namespace Avtorentovik.Controls
{
    public partial class ServicesControl: UserControl
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
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.spinEditPrice = new DevExpress.XtraEditors.SpinEdit();
            this.comboBoxEditPriceType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControlName = new DevExpress.XtraEditors.LabelControl();
            this.panel3 = new DevExpress.XtraEditors.PanelControl();
            this.toggleSwitchStatus = new Avtorentovik.Controls.CustomToggle();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditPriceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel3)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panel2.Controls.Add(this.spinEditPrice);
            this.panel2.Controls.Add(this.comboBoxEditPriceType);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(147, 0);
            this.panel2.LookAndFeel.SkinName = "Office 2013";
            this.panel2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 50);
            this.panel2.TabIndex = 2;
            // 
            // spinEditPrice
            // 
            this.spinEditPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditPrice.Location = new System.Drawing.Point(114, 9);
            this.spinEditPrice.Name = "spinEditPrice";
            this.spinEditPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditPrice.Properties.IsFloatValue = false;
            this.spinEditPrice.Properties.Mask.EditMask = "N00";
            this.spinEditPrice.Size = new System.Drawing.Size(130, 20);
            this.spinEditPrice.TabIndex = 1;
            // 
            // comboBoxEditPriceType
            // 
            this.comboBoxEditPriceType.EditValue = "за сутки";
            this.comboBoxEditPriceType.Location = new System.Drawing.Point(8, 9);
            this.comboBoxEditPriceType.Name = "comboBoxEditPriceType";
            this.comboBoxEditPriceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditPriceType.Properties.Items.AddRange(new object[] {
            "за сутки",
            "все время"});
            this.comboBoxEditPriceType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditPriceType.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEditPriceType.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Appearance.BackColor = System.Drawing.Color.White;
            this.panel1.Appearance.Options.UseBackColor = true;
            this.panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panel1.Controls.Add(this.labelControlName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.LookAndFeel.SkinName = "Office 2013";
            this.panel1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(147, 50);
            this.panel1.TabIndex = 0;
            // 
            // labelControlName
            // 
            this.labelControlName.Location = new System.Drawing.Point(5, 12);
            this.labelControlName.Name = "labelControlName";
            this.labelControlName.Size = new System.Drawing.Size(63, 13);
            this.labelControlName.TabIndex = 0;
            this.labelControlName.Text = "labelControl1";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panel3.Controls.Add(this.toggleSwitchStatus);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(432, 0);
            this.panel3.LookAndFeel.SkinName = "Office 2013";
            this.panel3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(108, 50);
            this.panel3.TabIndex = 4;
            // 
            // toggleSwitchStatus
            // 
            this.toggleSwitchStatus.EditValue = true;
            this.toggleSwitchStatus.Location = new System.Drawing.Point(16, 5);
            this.toggleSwitchStatus.Name = "toggleSwitchStatus";
            this.toggleSwitchStatus.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.toggleSwitchStatus.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.toggleSwitchStatus.Properties.Appearance.Options.UseBackColor = true;
            this.toggleSwitchStatus.Properties.Appearance.Options.UseForeColor = true;
            this.toggleSwitchStatus.Properties.LookAndFeel.SkinName = "Office 2010 Silver";
            this.toggleSwitchStatus.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.toggleSwitchStatus.Properties.OffText = "Нет";
            this.toggleSwitchStatus.Properties.OnText = "Да";
            this.toggleSwitchStatus.Size = new System.Drawing.Size(75, 24);
            this.toggleSwitchStatus.TabIndex = 2;
            this.toggleSwitchStatus.Toggled += new System.EventHandler(this.toggleSwitchStatus_Toggled);
            // 
            // ServicesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "ServicesControl";
            this.Size = new System.Drawing.Size(540, 50);
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditPriceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel3)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchStatus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panel2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditPriceType;
        private DevExpress.XtraEditors.SpinEdit spinEditPrice;
        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraEditors.LabelControl labelControlName;
        private DevExpress.XtraEditors.PanelControl panel3;
        private CustomToggle toggleSwitchStatus;
    }
}
