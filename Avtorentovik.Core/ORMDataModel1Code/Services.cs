using DevExpress.Xpo;

namespace Avtorentovik.Core.DB
{

    public partial class Services
    {
        public Services(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
