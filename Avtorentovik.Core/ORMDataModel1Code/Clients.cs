using DevExpress.Xpo;

namespace Avtorentovik.Core.DB
{

    public partial class Clients
    {
        public Clients(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
