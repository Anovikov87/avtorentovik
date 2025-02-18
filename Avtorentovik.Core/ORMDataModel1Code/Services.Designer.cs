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

    public partial class Services : PersistentBase
    {
        int fId;
        [Key(true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>("Id", ref fId, value); }
        }
        string fName;
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>("Name", ref fName, value); }
        }
        int fPriceType;
        public int PriceType
        {
            get { return fPriceType; }
            set { SetPropertyValue<int>("PriceType", ref fPriceType, value); }
        }
        int fPrice;
        public int Price
        {
            get { return fPrice; }
            set { SetPropertyValue<int>("Price", ref fPrice, value); }
        }
        bool fStatus;
        public bool Status
        {
            get { return fStatus; }
            set { SetPropertyValue<bool>("Status", ref fStatus, value); }
        }
        Users fUser;
        [Association(@"ServicesReferencesUsers")]
        public Users User
        {
            get { return fUser; }
            set { SetPropertyValue<Users>("User", ref fUser, value); }
        }
        int fSiteId;
        public int SiteId
        {
            get { return fSiteId; }
            set { SetPropertyValue<int>("SiteId", ref fSiteId, value); }
        }
        int fCompanyId;
        public int CompanyId
        {
            get { return fCompanyId; }
            set { SetPropertyValue<int>("CompanyId", ref fCompanyId, value); }
        }
        [Association(@"OrderServicesReferencesServices", typeof(OrderServices))]
        public IList<OrderServices> OrderServicesCollection { get { return GetList<OrderServices>("OrderServicesCollection"); } }
    }

}
