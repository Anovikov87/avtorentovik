using DevExpress.Xpo;

namespace Avtorentovik.Core.DB
{

    public partial class OrderServices
    {
        public OrderServices(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
