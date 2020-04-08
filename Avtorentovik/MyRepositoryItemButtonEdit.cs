using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace Avtorentovik
{
    public class MyRepositoryItemButtonEdit : RepositoryItemButtonEdit
    {
        public override DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo CreateViewInfo()
        {
            return new MyRepositoryItemButtonEditViewInfo(this);
        }
    }
    public class MyRepositoryItemButtonEditViewInfo : ButtonEditViewInfo
    {
        public MyRepositoryItemButtonEditViewInfo(RepositoryItem item) : base(item) { }

        protected override DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs CreateButtonInfo(EditorButton button, int index)
        {
            return base.CreateButtonInfo(new MyEditorButton(), index);
        }
    }

    public class MyEditorButton : EditorButton
    {
        public MyEditorButton() : this(string.Empty)
        {
        }

        public MyEditorButton(string myCaption)
        {
            _myCaption = myCaption;
            Kind = ButtonPredefines.Glyph;
        }

        private string _myCaption;

        public override string Caption
        {
            get { return _myCaption; }
            set { _myCaption = value; }
        }

    }
}
