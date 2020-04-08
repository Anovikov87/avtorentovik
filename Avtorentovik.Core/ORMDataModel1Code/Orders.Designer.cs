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

    public partial class Orders : PersistentBase
    {
        int fId;
        [Key(true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>("Id", ref fId, value); }
        }
        Cars fCar;
        [Association(@"OrdersReferencesCars")]
        public Cars Car
        {
            get { return fCar; }
            set { SetPropertyValue<Cars>("Car", ref fCar, value); }
        }
        Clients fClient;
        [Association(@"OrdersReferencesClients")]
        public Clients Client
        {
            get { return fClient; }
            set { SetPropertyValue<Clients>("Client", ref fClient, value); }
        }
        DateTime fDateFrom;
        public DateTime DateFrom
        {
            get { return fDateFrom; }
            set { SetPropertyValue<DateTime>("DateFrom", ref fDateFrom, value); }
        }
        DateTime fDateTo;
        public DateTime DateTo
        {
            get { return fDateTo; }
            set { SetPropertyValue<DateTime>("DateTo", ref fDateTo, value); }
        }
        string fTerritory;
        public string Territory
        {
            get { return fTerritory; }
            set { SetPropertyValue<string>("Territory", ref fTerritory, value); }
        }
        double fMileageEnd;
        public double MileageEnd
        {
            get { return fMileageEnd; }
            set { SetPropertyValue<double>("MileageEnd", ref fMileageEnd, value); }
        }
        double fWash;
        public double Wash
        {
            get { return fWash; }
            set { SetPropertyValue<double>("Wash", ref fWash, value); }
        }
        double fOverrun;
        public double Overrun
        {
            get { return fOverrun; }
            set { SetPropertyValue<double>("Overrun", ref fOverrun, value); }
        }
        double fOther;
        public double Other
        {
            get { return fOther; }
            set { SetPropertyValue<double>("Other", ref fOther, value); }
        }
        bool fClosed;
        public bool Closed
        {
            get { return fClosed; }
            set { SetPropertyValue<bool>("Closed", ref fClosed, value); }
        }
        int fMileageStart;
        public int MileageStart
        {
            get { return fMileageStart; }
            set { SetPropertyValue<int>("MileageStart", ref fMileageStart, value); }
        }
        int fDiscount;
        public int Discount
        {
            get { return fDiscount; }
            set { SetPropertyValue<int>("Discount", ref fDiscount, value); }
        }
        bool fDiscountType;
        public bool DiscountType
        {
            get { return fDiscountType; }
            set { SetPropertyValue<bool>("DiscountType", ref fDiscountType, value); }
        }
        Users fUser;
        [Association(@"OrdersReferencesUsers")]
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
        bool fDeleted;
        public bool Deleted
        {
            get { return fDeleted; }
            set { SetPropertyValue<bool>("Deleted", ref fDeleted, value); }
        }
        [Association(@"OrderServicesReferencesOrders", typeof(OrderServices))]
        public IList<OrderServices> OrderServicesCollection { get { return GetList<OrderServices>("OrderServicesCollection"); } }
        [Association(@"OrderDamagesReferencesOrders", typeof(OrderDamages))]
        public IList<OrderDamages> OrderDamagesCollection { get { return GetList<OrderDamages>("OrderDamagesCollection"); } }
    }

}
