using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace Avtorentovik.Controls
{
    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemCustomToggle : RepositoryItemToggleSwitch
    {
        static RepositoryItemCustomToggle() { RegisterCustomToggle(); }

        public RepositoryItemCustomToggle()
        {
            BrushOn = new SolidBrush(Color.FromArgb(92,184,92));
            BrushOff = new SolidBrush(Color.FromArgb(201,48,44));
        }

        public const string CustomToggleName = "CustomToggle";

        public override string EditorTypeName { get { return CustomToggleName; } }

        public override DevExpress.Utils.HorzAlignment GlyphAlignment
        {
            get
            {
                return DevExpress.Utils.HorzAlignment.Center;
            }

        }


        private Brush _BrushOn, _BrushOff;

        public virtual Brush BrushOn
        {
            get { return _BrushOn; }
            set
            {
                if (_BrushOn != value)
                {
                    _BrushOn = value;
                    OnPropertiesChanged();
                }
            }
        }
        public virtual Brush BrushOff
        {
            get { return _BrushOff; }
            set
            {
                if (_BrushOff != value)
                {
                    _BrushOff = value;
                    OnPropertiesChanged();
                }
            }
        }

        public static void RegisterCustomToggle()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomToggleName,
                typeof(CustomToggle), typeof(RepositoryItemCustomToggle),
                typeof(CustomToggleViewInfo), new CustomToggleSwitchPainter(), true));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemCustomToggle source = item as RepositoryItemCustomToggle;
                if (source == null) return;
                BrushOn = source.BrushOn;
                BrushOff = source.BrushOff;
            }
            finally
            {
                EndUpdate();
            }
        }


    }

    [ToolboxItem(true)]
    public class CustomToggle : ToggleSwitch
    {

        static CustomToggle() { RepositoryItemCustomToggle.RegisterCustomToggle(); }

        public CustomToggle()
        {

        }


        public override string EditorTypeName
        {
            get
            {
                return
                    RepositoryItemCustomToggle.CustomToggleName;
            }
        }


        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomToggle Properties
        {
            get { return base.Properties as RepositoryItemCustomToggle; }
        }

    }

    class CustomToggleSwitchPainter : ToggleSwitchPainter
    {
        public CustomToggleSwitchPainter()
            : base()
        { }

        protected override void DrawContent(ControlGraphicsInfoArgs info)
        {
            BaseCheckEditViewInfo vi = info.ViewInfo as BaseCheckEditViewInfo;

            vi.CheckInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            ToggleObjectInfoArgs args = (vi.CheckInfo) as ToggleObjectInfoArgs;

            if (args.GlyphRect.X == args.SwitchRect.X)
                vi.CheckInfo.CaptionRect = new Rectangle(args.SwitchRect.Right, args.SwitchRect.Y, args.SwitchRect.Width+10, args.SwitchRect.Height);
            else
                if (args.GlyphRect.Right == args.SwitchRect.Right)
                vi.CheckInfo.CaptionRect = new Rectangle(args.GlyphRect.X, args.GlyphRect.Y, args.SwitchRect.Width+10, args.SwitchRect.Height);

            base.DrawContent(info);
        }

    }
    public class CustomToggleViewInfo : ToggleSwitchViewInfo
    {
        public CustomToggleViewInfo(RepositoryItem item)
            : base(item)
        {
        }

        protected override BaseCheckObjectPainter CreateCheckPainter()
        {
            if (IsPrinting) return TogglePainterHelper.GetPainter(ActiveLookAndFeelStyle.Flat);
            SkinCustomToggleObjectPainter painter = new SkinCustomToggleObjectPainter(LookAndFeel);
            painter.BrushOn = ((RepositoryItemCustomToggle)Item).BrushOn;
            painter.BrushOff = ((RepositoryItemCustomToggle)Item).BrushOff;
            return painter;
        }

    }

    public class SkinCustomToggleObjectPainter : SkinToggleObjectPainter
    {

        public virtual Brush BrushOn { get; set; }
        public virtual Brush BrushOff { get; set; }

        public SkinCustomToggleObjectPainter(ISkinProvider provider)
            : base(provider)
        {
        }

        protected override void DrawToggleSwitch(ToggleObjectInfoArgs args)
        {
            if (args.IsOn)
            {
                args.Graphics.FillRectangle(BrushOn, args.Bounds);
            }
            else {
                args.Graphics.FillRectangle(BrushOff, args.Bounds);
            }
        }
        /*  protected override void DrawToggleSwitchThumb(ToggleObjectInfoArgs args)
          {
              SkinElementInfo info = GetToggleSwitchThumbSkinElementInfo(args);
              info.Bounds = args.Bounds;
              info.Bounds = new Rectangle(info.Bounds.Location, new Size(info.Bounds.Width, info.Bounds.Height + 3));
              if (args.IsOn)
              {
                  info.OffsetContent(0, -3);
              }
              else {
                  info.OffsetContent(-4, -3);
              }
              SkinElementPainter.Default.DrawObject(info);
          }*/
    }
}
