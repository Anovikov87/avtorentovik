using DevExpress.Xpo;

namespace Avtorentovik.Core.DB
{

    public partial class Damages
    {
        public Damages(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
