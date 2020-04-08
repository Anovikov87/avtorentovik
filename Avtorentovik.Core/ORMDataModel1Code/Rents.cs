using DevExpress.Xpo;

namespace Avtorentovik.Core.DB
{

    public partial class Rents
    {
        public Rents(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
