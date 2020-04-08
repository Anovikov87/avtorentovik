using DevExpress.Xpo;

namespace Avtorentovik.Core.DB
{

    public partial class Cars
    {
        public Cars(Session session) : base(session)
        { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
