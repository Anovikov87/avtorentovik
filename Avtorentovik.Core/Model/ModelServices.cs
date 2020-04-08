using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class Services
        {
            internal static Service ToModel(DB.Services dbItem, UnitOfWork unitOfWork)
            {
                var serv= new Service()
                {
                    Id = dbItem.Id,
                    Name = dbItem.Name,
                    Price = dbItem.Price,
                    PriceType = dbItem.PriceType,
                    Status = dbItem.Status,
                    SiteId = dbItem.SiteId,
                    CompanyId = dbItem.CompanyId,                    
                    User = Users.Read(dbItem.User.Id,unitOfWork)
                };
                return serv;
            }

            public static Service Read(int id, UnitOfWork unitOfWork)
            {
                var dbItem = new XPCollection<DB.Services>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbItem == null)
                    throw new Exception(Resources.Services_Read_Услуга_не_найдена_);

                return ToModel(dbItem,unitOfWork);
            }

            public static Service[] GetAll()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Services>(unitOfWork).Select(u => u);

                    return query                        
                        .OrderBy(u => u.Id)
                        .Select(q=>ToModel(q,unitOfWork)).ToArray();
                }
            }

            public static Service[] GetAllByUser(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Services>(unitOfWork).Where(q=> q.User!=null&&q.User.Id==id).Select(u => u);

                    return query
                        .OrderBy(u => u.Id)
                        .Select(q => ToModel(q, unitOfWork)).ToArray();
                }
            }

            public static int Post(Service item)
            {
                return AddNew(item);
            }

            internal static int AddNew(Service item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    DB.Services dbItem;
                    using (var items = new XPCollection<DB.Services>(unitOfWork))
                    {
                        dbItem = items.FirstOrDefault(u => u.Name== item.Name&& u.User!=null&&u.User.Id==item.User.Id);
                        if (dbItem != null)
                            throw new Exception(Resources.Services_AddNew_Такая_услуга_уже_существует_);

                        dbItem = new DB.Services(unitOfWork)
                        {
                           Name = item.Name,
                           Price = item.Price,
                           PriceType = item.PriceType  ,
                           Status = item.Status      ,
                            SiteId = item.SiteId,
                            CompanyId = item.CompanyId
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

            public static int Put(Service user)
            {
                return Change(user);
            }

            internal static int Change(Service item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Services>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == item.Id);
                        if (dbItem == null)
                            throw new Exception(Resources.Services_Read_Услуга_не_найдена_);

                      /*  var duplicatedbItem = items.FirstOrDefault(u => u.Name == item.Name&& u.Id != item.Id&&u.User!=null&&u.User.Id==item.User.Id);
                        if (duplicatedbItem != null)
                            throw new Exception(Resources.Services_AddNew_Такая_услуга_уже_существует_);
                            */
                       // dbItem.Name = item.Name;
                        dbItem.Price = item.Price;
                        dbItem.PriceType = item.PriceType;
                        dbItem.Status = item.Status;
                        dbItem.SiteId = item.SiteId;
                        dbItem.CompanyId = item.CompanyId;
                    }

                    unitOfWork.CommitChanges();

                    return item.Id;
                }
            }

            public static void Delete(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Services>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == id);
                        if (dbItem == null)
                            throw new Exception(Resources.Services_Read_Услуга_не_найдена_);

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
                    using (var collection = new XPCollection<DB.Services>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
