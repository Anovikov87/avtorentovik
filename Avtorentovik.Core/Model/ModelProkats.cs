using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class Prokats
        {
            internal static Prokat ToModel(DB.Prokats dbItem)
            {
                return new Prokat()
                {
                    Id = dbItem.Id,
                    Name = dbItem.Name,
                    Address = dbItem.Address,
                    Phones = dbItem.Phones,
                    Worktime = dbItem.Worktime
                };
            }

            public static Prokat Read(int id, UnitOfWork unitOfWork)
            {
                var dbItem = new XPCollection<DB.Prokats>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbItem == null)
                    throw new Exception(Resources.Prokats_Read_Автопрокат_не_найден_);

                return ToModel(dbItem);
            }

            public static Prokat GetbyUser(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Prokats>(unitOfWork).FirstOrDefault(u => u.User!=null&&u.User.Id==id);
                    if (query == null)
                        return null;
                    return ToModel(query);                        
                }
            }

            public static int Post(Prokat item)
            {
                return AddNew(item);
            }

            internal static int AddNew(Prokat item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    DB.Prokats dbItem;
                    using (var items = new XPCollection<DB.Prokats>(unitOfWork))
                    {                      

                        dbItem = new DB.Prokats(unitOfWork)
                        {
                            Name = item.Name,
                            Address = item.Address,
                            Phones = item.Phones,
                            Worktime = item.Worktime
                        };
                        using (var usrs = new XPCollection<DB.Users>(unitOfWork))
                        {
                            dbItem.User = usrs.FirstOrDefault(q => q.Id == item.User.Id);
                        }
                        items.Add(dbItem);
                    }
                    unitOfWork.CommitChanges();

                    return dbItem.Id;
                }
            }

            public static int Put(Prokat user)
            {
                return Change(user);
            }

            internal static int Change(Prokat item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Prokats>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == item.Id);
                        if (dbItem == null)
                            throw new Exception(Resources.Prokats_Read_Автопрокат_не_найден_);

                        dbItem.Name = item.Name;
                        dbItem.Address = item.Address;
                        dbItem.Phones = item.Phones;
                        dbItem.Worktime = item.Worktime;
                    }

                    unitOfWork.CommitChanges();

                    return item.Id;
                }
            }

            public static void Delete(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Prokats>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == id);
                        if (dbItem == null)
                            throw new Exception(Resources.Prokats_Read_Автопрокат_не_найден_);

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
                    using (var collection = new XPCollection<DB.Prokats>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
