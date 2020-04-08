using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class CarRentals
        {
            internal static CarRental ToModel(DB.CarRentals dbItem, UnitOfWork unitOfWork)
            {
                return new CarRental()
                {
                    Id = dbItem.Id,
                    Name = dbItem.Name,
                    SiteId = dbItem.SiteId,
                    UserId = dbItem.User.Id
                };
            }

            public static CarRental Read(int id, UnitOfWork unitOfWork)
            {
                var dbItem = new XPCollection<DB.CarRentals>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbItem == null)
                    throw new Exception(Resources.CarRentals_Read_Точка_выдачи_не_найдена_);

                return ToModel(dbItem,unitOfWork);
            }

            public static CarRental[] GetbyUser(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.CarRentals>(unitOfWork).Where(u => u.User!=null&&u.User.Id==id);
                
                    return query
                         .OrderBy(u => u.Id)
                         .Select(q => ToModel(q, unitOfWork)).ToArray();
                }
            }

            public static int Post(CarRental item)
            {
                return AddNew(item);
            }

            internal static int AddNew(CarRental item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    DB.CarRentals dbItem;
                    using (var items = new XPCollection<DB.CarRentals>(unitOfWork))
                    {                      

                        dbItem = new DB.CarRentals(unitOfWork)
                        {
                            Name = item.Name,
                            SiteId = item.SiteId,                           
                        };
                        using (var usrs = new XPCollection<DB.Users>(unitOfWork))
                        {
                            dbItem.User = usrs.FirstOrDefault(q => q.Id == item.UserId);
                        }
                        items.Add(dbItem);
                    }
                    unitOfWork.CommitChanges();

                    return dbItem.Id;
                }
            }

            public static int Put(CarRental user)
            {
                return Change(user);
            }

            internal static int Change(CarRental item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.CarRentals>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == item.Id);
                        if (dbItem == null)
                            throw new Exception(Resources.CarRentals_Read_Точка_выдачи_не_найдена_);

                        dbItem.Name = item.Name;
                        dbItem.SiteId=item.SiteId;                        
                    }

                    unitOfWork.CommitChanges();

                    return item.Id;
                }
            }

            public static void Delete(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.CarRentals>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == id);
                        if (dbItem == null)
                            throw new Exception(Resources.CarRentals_Read_Точка_выдачи_не_найдена_);

                        items.DeleteObjectOnRemove = true;
                        items.Remove(dbItem);
                    }

                    unitOfWork.CommitChanges();
                }
            }

            internal static bool HasAny()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var collection = new XPCollection<DB.CarRentals>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
