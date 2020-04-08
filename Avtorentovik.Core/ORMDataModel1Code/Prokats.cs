using DevExpress.Xpo;

namespace Avtorentovik.Core.DB
{

    public partial class Prokats
    {
        public Prokats(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
