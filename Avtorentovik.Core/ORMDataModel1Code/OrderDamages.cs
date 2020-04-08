using DevExpress.Xpo;

namespace Avtorentovik.Core.DB
{

    public partial class OrderDamages
    {
        public OrderDamages(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
