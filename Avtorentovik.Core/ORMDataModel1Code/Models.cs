using DevExpress.Xpo;

namespace Avtorentovik.Core.DB
{

    public partial class CarModels
    {
        public CarModels(Session session) : base(session)
        { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
