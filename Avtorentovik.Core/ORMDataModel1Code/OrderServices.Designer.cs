﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Avtorentovik.Core.DB
{

    public partial class OrderServices : PersistentBase
    {
        int fId;
        [Key(true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>("Id", ref fId, value); }
        }
        Services fService;
        [Association(@"OrderServicesReferencesServices")]
        public Services Service
        {
            get { return fService; }
            set { SetPropertyValue<Services>("Service", ref fService, value); }
        }
        Orders fOrder;
        [Association(@"OrderServicesReferencesOrders")]
        public Orders Order
        {
            get { return fOrder; }
            set { SetPropertyValue<Orders>("Order", ref fOrder, value); }
        }
    }

}
