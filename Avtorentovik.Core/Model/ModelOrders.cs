using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class Orders
        {
            internal static Order ToModel(DB.Orders dbItem,UnitOfWork unitOfWork)
            {
                var Order=
                new Order()
                {
                    Id = dbItem.Id,
                    Closed = dbItem.Closed,
                    Client = Clients.Read(dbItem.Client.Id,unitOfWork),
                    Car = Cars.Read(dbItem.Car.Id,unitOfWork),
                    DateFrom = dbItem.DateFrom,
                    DateTo = dbItem.DateTo,
                    MileageEnd = dbItem.MileageEnd,                    
                    Other = dbItem.Other,
                    Overrun = dbItem.Overrun,
                    Territory = dbItem.Territory,
                    Wash = dbItem.Wash            ,
                    Discount       = dbItem.Discount,
                    DiscountType = dbItem.DiscountType,
                    SiteId =dbItem.SiteId,
                    Deleted = dbItem.Deleted
            };
                foreach (var od in dbItem.OrderDamagesCollection)
                {
                    Order.Damages.Add(Damages.Read(od.Damage.Id,unitOfWork));
                }
                foreach (var os in dbItem.OrderServicesCollection)
                {
                    Order.Services.Add(Services.Read(os.Service.Id,unitOfWork));
                }
                return Order;
            }

            internal static Order ToShortModel(DB.Orders dbItem, UnitOfWork unitOfWork)
            {
                var Order =
                new Order()
                {
                    Id = dbItem.Id,
                    Closed = dbItem.Closed,
                    Client = Clients.ReadShort(dbItem.Client.Id, unitOfWork),
                    Car = Cars.ReadShort(dbItem.Car.Id, unitOfWork),
                    DateFrom = dbItem.DateFrom,
                    DateTo = dbItem.DateTo,
                    MileageEnd = dbItem.MileageEnd,
                    Other = dbItem.Other,
                    Overrun = dbItem.Overrun,
                    Territory = dbItem.Territory,
                    Wash = dbItem.Wash,
                    Discount = dbItem.Discount,
                    DiscountType = dbItem.DiscountType,
                    SiteId = dbItem.SiteId,
                    User = Users.Read(dbItem.User.Id,unitOfWork),
                    Deleted = dbItem.Deleted
                };
                foreach (var od in dbItem.OrderDamagesCollection)
                {
                    Order.Damages.Add(Damages.Read(od.Damage.Id, unitOfWork));
                }
           
                return Order;
            }

            public static Order Read(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var dbItem = new XPCollection<DB.Orders>(unitOfWork).FirstOrDefault(u => u.Id == id);
                    if (dbItem == null)
                        throw new Exception(Resources.Orders_Read_Заказ_не_найден_);

                    return ToModel(dbItem, unitOfWork);
                }
            }

            public static Order ReadSite(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var dbItem = new XPCollection<DB.Orders>(unitOfWork).FirstOrDefault(u => u.SiteId == id);
                    if (dbItem == null)
                        return null;

                    return ToModel(dbItem, unitOfWork);
                }
            }

            public static ClientOrder ReadForClient(int id, UnitOfWork unitOfWork)
            {
                var dbItem = new XPCollection<DB.Orders>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbItem == null)
                    throw new Exception(Resources.Orders_Read_Заказ_не_найден_);

                return new ClientOrder()
                {
                    Id = dbItem.Id,
                    DateFrom = dbItem.DateFrom,
                    DateTo = dbItem.DateTo,
                    Car = Cars.ReadShort(dbItem.Car.Id,unitOfWork),
                    Closed = dbItem.Closed,                    
                };
            }

            public static Order[] GetAllShortbyUser(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Orders>(unitOfWork).Where(q => q.User != null && q.User.Id == id && !q.Deleted).Select(u => u);

                    return query
                        .OrderByDescending(u => u.SiteId)
                        .Select(q => ToShortModel(q, unitOfWork)).ToArray();
                }
            }

            public static Order[] GetAllbyUser(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Orders>(unitOfWork).Where(q=>q.User!=null&&q.User.Id==id).Select(u => u);

                    return query
                        .OrderBy(u => u.Id)
                        .Select(q => ToModel(q, unitOfWork)).ToArray();
                }
            }

            public static Order[] GetAll()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Orders>(unitOfWork).Select(u => u);

                    return query
                        .OrderBy(u => u.Id)
                        .Select(q=>ToModel(q,unitOfWork)).ToArray();
                }
            }

            public static int Post(Order item)
            {
                return AddNew(item);
            }

            internal static int AddNew(Order item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    DB.Orders dbItem;
                    using (var items = new XPCollection<DB.Orders>(unitOfWork))
                    {                        
                        dbItem = new DB.Orders(unitOfWork)
                        {
                            Closed = item.Closed,                            
                            DateFrom = item.DateFrom,
                            DateTo = item.DateTo,
                            MileageEnd = item.MileageEnd,                            
                            Other = item.Other,
                            Overrun = item.Overrun,
                            Territory = item.Territory,
                            Wash = item.Wash,
                            Discount = item.Discount,
                            DiscountType = item.DiscountType,
                            SiteId = item.SiteId,
                            Deleted = item.Deleted
                    };
                        items.Add(FillDependencies(unitOfWork, dbItem, item));
                    }
                    unitOfWork.CommitChanges();
                    AddDependencies(unitOfWork, item, dbItem);
                    
                    unitOfWork.CommitChanges();
                    return dbItem.Id;
                }
            }
            private static void AddDependencies(UnitOfWork unitOfWork, Order item, DB.Orders dbItem)
            {                                
                foreach (var itm in item.Damages)
                {                                        
                    var did=Damages.AddNew(itm, unitOfWork,true);                    
                    itm.Id = did;
                    OrderDamages.AddNew(itm, dbItem, unitOfWork);
                }
                foreach (var serv in item.Services)
                {                    
                    OrderServices.AddNew(serv, dbItem, unitOfWork);
                }
            }
            private static DB.Orders FillDependencies(UnitOfWork unitOfWork, DB.Orders dbItem, Order item)
            {
                using (var items = new XPCollection<DB.Cars>(unitOfWork))
                {
                    var car= items.FirstOrDefault(q => q.Id == item.Car.Id);                    
                    dbItem.Car = car;
                }
                using (var items = new XPCollection<DB.Clients>(unitOfWork))
                {                    
                    dbItem.Client = items.FirstOrDefault(q => q.Id == item.Client.Id);
                }
                using (var items = new XPCollection<DB.Users>(unitOfWork))
                {
                    dbItem.User = items.FirstOrDefault(q => q.Id == item.User.Id);
                }
                return dbItem;
            }

            public static int Put(Order user)
            {
                return Change(user);
            }

            internal static int Change(Order item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    DB.Orders dbItem;
                    using (var items = new XPCollection<DB.Orders>(unitOfWork))
                    {
                        dbItem = items.FirstOrDefault(u => u.Id == item.Id);
                        if (dbItem == null)
                            throw new Exception(Resources.Orders_Read_Заказ_не_найден_);

                        dbItem.Closed = item.Closed;
                        dbItem.DateFrom = item.DateFrom;
                        dbItem.DateTo = item.DateTo;
                        dbItem.MileageEnd = item.MileageEnd;                        
                        dbItem.Other = item.Other;
                        dbItem.Overrun = item.Overrun;
                        dbItem.Territory = item.Territory;
                        dbItem.Wash = item.Wash;
                        dbItem.Discount = item.Discount;
                        dbItem.DiscountType = item.DiscountType;
                        dbItem.SiteId = item.SiteId;
                        dbItem.Deleted = item.Deleted;
                        FillDependencies(unitOfWork, dbItem, item);
                    }
                    //связи
                    OrderDamages.DeleteByOrder(item.Id,unitOfWork);
                    OrderServices.DeleteByOrder(item.Id,unitOfWork);
                    AddDependencies(unitOfWork,item,dbItem);
                    unitOfWork.CommitChanges();

                    return item.Id;
                }
            }

            public static void DeleteByClient(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Orders>(unitOfWork))
                    {
                        var dbItems = items.Where(u => u.Client!=null&&u.Client.Id == id).ToArray();

                        items.DeleteObjectOnRemove = true;
                        //связи
                        for (int index = 0; index < dbItems.Count(); index++)
                        {
                            var item = dbItems[index];
                            OrderDamages.DeleteByOrder(item.Id, unitOfWork);
                            OrderServices.DeleteByOrder(item.Id, unitOfWork);
                            items.Remove(item);
                        }
                    }
                    unitOfWork.CommitChanges();
                }
            }

            public static void SetDeletedByCar(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Orders>(unitOfWork))
                    {
                        var dbItems = items.Where(u => u.Car.Id == id).ToArray();
                        for (int index = 0; index < dbItems.Count(); index++)
                        {
                            var item = dbItems[index];
                            item.Deleted = true;
                        }
                    }
                    unitOfWork.CommitChanges();
                }
            }

            public static void SetDeletedByClient(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Orders>(unitOfWork))
                    {
                        var dbItems = items.Where(u => u.Client.Id == id).ToArray();
                        for (int index = 0; index < dbItems.Count(); index++)
                        {
                            var item = dbItems[index];
                            item.Deleted = true;
                        }
                    }
                    unitOfWork.CommitChanges();
                }
            }

            public static
                void DeleteByCar(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Orders>(unitOfWork))
                    {
                        var dbItems = items.Where(u => u.Car.Id == id).ToArray();
                        
                        items.DeleteObjectOnRemove = true;
                        //связи
                        for (int index = 0; index < dbItems.Count(); index++)
                        {
                            var item = dbItems[index];
                            OrderDamages.DeleteByOrder(item.Id, unitOfWork);
                            OrderServices.DeleteByOrder(item.Id, unitOfWork);
                            items.Remove(item);
                        }
                    }

                    unitOfWork.CommitChanges();
                }
            }
            public static void Delete(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Orders>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == id);
                        if (dbItem == null)
                            throw new Exception(Resources.Orders_Read_Заказ_не_найден_);

                        items.DeleteObjectOnRemove = true;
                        //связи
                        OrderDamages.DeleteByOrder(id,unitOfWork);                        
                        OrderServices.DeleteByOrder(id, unitOfWork);
                        items.Remove(dbItem);
                    }

                    unitOfWork.CommitChanges();
                }
            }

            internal static bool HasAny()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var collection = new XPCollection<DB.Orders>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
