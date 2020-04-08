using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class Rents
        {
            internal static Rent ToModel(DB.Rents dbItem)
            {
                return new Rent()
                {
                    Id = dbItem.Id,                    
                    CarId = dbItem.Car.Id,
                    From = dbItem.From,
                    To = dbItem.To,
                    Price = dbItem.Price,
                    Status = dbItem.Status,
                    SiteId = dbItem.SiteId
                };
            }

            public static Rent Read(int id, UnitOfWork unitOfWork)
            {
                var dbItem = new XPCollection<DB.Rents>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbItem == null)
                    throw new Exception(Resources.Rents_Read_Стоимость_аренды_не_найдена_);

                return ToModel(dbItem);
            }

            public static Rent[] GetAll()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Rents>(unitOfWork).Select(u => u);

                    return query                        
                        .OrderBy(u => u.From)
                        .Select(ToModel).ToArray();
                }
            }

            public static int Post(Rent item)
            {
                return AddNew(item);
            }

            internal static int AddNew(Rent item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    DB.Rents dbItem;
                    using (var items = new XPCollection<DB.Rents>(unitOfWork))
                    {                     
                        dbItem = new DB.Rents(unitOfWork)
                        {
                            Status= item.Status,
                            Price= item.Price,
                            To= item.To,
                            From = item.From,
                            SiteId                           = item.SiteId
                        };
                        items.Add(FillDependencies(unitOfWork,dbItem,item));
                    }
                    unitOfWork.CommitChanges();

                    return dbItem.Id;
                }
            }

            internal static int AddNew(Rent item,UnitOfWork unitOfWork)
            {                
                    DB.Rents dbItem;
                    using (var items = new XPCollection<DB.Rents>(unitOfWork))
                    {
                        dbItem = new DB.Rents(unitOfWork)
                        {
                            Status = item.Status,
                            Price = item.Price,
                            To = item.To,
                            From = item.From,
                            SiteId = item.SiteId
                        };
                        items.Add(FillDependencies(unitOfWork, dbItem, item));
                    }                    
                    return dbItem.Id;                
            }

            private static DB.Rents FillDependencies(UnitOfWork unitOfWork, DB.Rents dbItem, Rent item)
            {
                using (var items = new XPCollection<DB.Cars>(unitOfWork))
                {
                    dbItem.Car = items.FirstOrDefault(q => q.Id == item.CarId);
                }
                return dbItem;
            }

            public static int Put(Rent user)
            {
                return Change(user);
            }

            internal static int Change(Rent item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Rents>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == item.Id);
                        if (dbItem == null)
                            throw new Exception(Resources.Rents_Read_Стоимость_аренды_не_найдена_);

                        dbItem.Status = item.Status;
                        dbItem.Price = item.Price;
                        dbItem.To = item.To;
                        dbItem.From = item.From;
                        dbItem.SiteId = item.SiteId;
                        FillDependencies(unitOfWork, dbItem, item);
                    }

                    unitOfWork.CommitChanges();

                    return item.Id;
                }
            }

            public static void Delete(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Rents>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == id);
                        if (dbItem == null)
                            throw new Exception(Resources.Rents_Read_Стоимость_аренды_не_найдена_);

                        items.DeleteObjectOnRemove = true;
                        items.Remove(dbItem);
                    }

                    unitOfWork.CommitChanges();
                }
            }

            public static void DeleteByCarId(UnitOfWork unitOfWork, int id)
            {
                using (var items = new XPCollection<DB.Rents>(unitOfWork))
                {
                    var dbItems = items.Where(u => u.Car!=null&& u.Car.Id == id).ToArray();

                    items.DeleteObjectOnRemove = true;
                    for (var i = 0; i < dbItems.Length; i++)
                    {
                        var dbItem = dbItems[i];
                        items.Remove(dbItem);
                    }
                }
            }

            internal static bool HasAny()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var collection = new XPCollection<DB.Rents>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
