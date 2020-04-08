using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class Damages
        {
            internal static Damage ToModel(DB.Damages dbItem)
            {
                return new Damage()
                {
                    Id = dbItem.Id,
                    Description = dbItem.Description,
                    Detail = dbItem.Detail,
                    CarId = dbItem.Car.Id,
                    Archive = dbItem.Archive
                };
            }

            public static Damage Read(int id, UnitOfWork unitOfWork)
            {
                var dbItem = new XPCollection<DB.Damages>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbItem == null)
                    throw new Exception(Resources.Damages_Read_Повреждение_не_найдено_);

                return ToModel(dbItem);
            }

            public static Damage[] GetAll()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Damages>(unitOfWork).Select(u => u);

                    return query                        
                        .OrderBy(u => u.Id)
                        .Select(ToModel).ToArray();
                }
            }

            public static int Post(Damage item)
            {
                return AddNew(item);
            }

            internal static int AddNew(Damage item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    DB.Damages dbItem;
                    using (var items = new XPCollection<DB.Damages>(unitOfWork))
                    {                     
                        dbItem = new DB.Damages(unitOfWork)
                        {
                            Description = item.Description,
                            Detail = item.Detail,                            
                        };
                        items.Add(FillDependencies(unitOfWork,dbItem,item));
                    }
                    unitOfWork.CommitChanges();

                    return dbItem.Id;
                }
            }

            internal static int AddNew(Damage item, UnitOfWork unitOfWork, bool commit = false)
            {
                DB.Damages dbItem;
                using (var items = new XPCollection<DB.Damages>(unitOfWork))
                {
                    if (item.Id > 0)
                    {
                        dbItem = items.FirstOrDefault(q => q.Id == item.Id);
                        if (dbItem != null)
                            dbItem.Archive = false;
                    }
                    else
                    {
                        dbItem = new DB.Damages(unitOfWork)
                        {
                            Description = item.Description,
                            Detail = item.Detail,
                        };
                    }
                    items.Add(FillDependencies(unitOfWork, dbItem, item));
                }
                if (commit)
                    unitOfWork.CommitChanges();

                return dbItem.Id;
            }

            private static DB.Damages FillDependencies(UnitOfWork unitOfWork, DB.Damages dbItem, Damage item)
            {
                using (var items = new XPCollection<DB.Cars>(unitOfWork))
                {
                    dbItem.Car = items.FirstOrDefault(q => q.Id == item.CarId);
                }
                return dbItem;
            }

            public static int Put(Damage user)
            {
                return Change(user);
            }

            internal static int Change(Damage item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Damages>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == item.Id);
                        if (dbItem == null)
                            throw new Exception(Resources.Damages_Read_Повреждение_не_найдено_);                       

                        dbItem.Description = item.Description;
                        dbItem.Detail= item.Detail;
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
                    using (var items = new XPCollection<DB.Damages>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == id);
                        if (dbItem == null)
                            throw new Exception(Resources.Damages_Read_Повреждение_не_найдено_);

                        items.DeleteObjectOnRemove = true;
                        items.Remove(dbItem);
                    }

                    unitOfWork.CommitChanges();
                }
            }

            public static void Delete(int id,UnitOfWork unitOfWork)
            {
        
                    using (var items = new XPCollection<DB.Damages>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == id);
                        if (dbItem == null)
                            throw new Exception(Resources.Damages_Read_Повреждение_не_найдено_);

                        items.DeleteObjectOnRemove = true;
                        items.Remove(dbItem);
                    }              
            }

            public static void DeleteByCarId(UnitOfWork unitOfWork, int id)
            {
                using (var items = new XPCollection<DB.Damages>(unitOfWork))
                {
                    var dbItems = items.Where(u => u.Car.Id == id).ToArray();
                    
                    using (var oitems = new XPCollection<DB.OrderDamages>(unitOfWork))
                    {                       
                        items.DeleteObjectOnRemove = true;
                        for (var i = 0; i < dbItems.Length; i++)
                        {
                            var dbItem = dbItems[i];
                            var od = oitems.Any(q => q.Damage.Id == dbItem.Id);
                            if (!od)
                                items.Remove(dbItem);
                            else
                                dbItem.Archive = true;
                        }
                    }
                }
            }

            internal static bool HasAny()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var collection = new XPCollection<DB.Damages>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
