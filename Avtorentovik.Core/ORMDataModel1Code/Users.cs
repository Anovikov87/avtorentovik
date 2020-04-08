using DevExpress.Xpo;

namespace Avtorentovik.Core.DB
{

    public partial class Users
    {
        public Users(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
