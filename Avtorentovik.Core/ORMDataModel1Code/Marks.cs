using DevExpress.Xpo;

namespace Avtorentovik.Core.DB
{

    public partial class Marks
    {
        public Marks(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
