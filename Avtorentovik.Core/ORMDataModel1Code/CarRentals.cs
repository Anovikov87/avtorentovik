using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Avtorentovik.Core.DB
{

    public partial class CarRentals
    {
        public CarRentals(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
