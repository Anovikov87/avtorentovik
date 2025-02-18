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

    public partial class Rents : PersistentBase
    {
        int fId;
        [Key(true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>("Id", ref fId, value); }
        }
        int fFrom;
        public int From
        {
            get { return fFrom; }
            set { SetPropertyValue<int>("From", ref fFrom, value); }
        }
        int fTo;
        public int To
        {
            get { return fTo; }
            set { SetPropertyValue<int>("To", ref fTo, value); }
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
        Cars fCar;
        [Association(@"RentsReferencesCars")]
        public Cars Car
        {
            get { return fCar; }
            set { SetPropertyValue<Cars>("Car", ref fCar, value); }
        }
        Users fUser;
        [Association(@"RentsReferencesUsers")]
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
    }

}
