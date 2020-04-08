using DevExpress.Xpo;

namespace Avtorentovik.Core.DB
{

    public partial class Orders
    {
        public Orders(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
