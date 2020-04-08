using DevExpress.Xpo;

namespace Avtorentovik.Core.DB
{

    public partial class Templates
    {
        public Templates(Session session) : base(session)
        { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
