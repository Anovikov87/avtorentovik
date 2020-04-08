using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class Clients
        {
            internal static Client ToModel(DB.Clients dbItem,UnitOfWork unitOfWork)
            {
                var cl= new Client()
                {
                    Id = dbItem.Id,                    
                    Address = dbItem.Address,
                    Born = dbItem.Born,
                    Comments = dbItem.Comments,
                    Status = (ClientStatus)dbItem.Status,
                    Code = dbItem.Code,
                    Fio = dbItem.Fio,
                    License = dbItem.License,
                    LicenseDate = dbItem.LicenseDate,
                    Passport = dbItem.Passport,
                    Phone = dbItem.Phone,
                    Registration = dbItem.Registration,
                    When = dbItem.When,
                    Who = dbItem.Who,
                    SiteId = dbItem.SiteId,
                    Deleted = dbItem.Deleted
                };
                foreach (var order in dbItem.OrdersCollection.Where(q=>!q.Deleted))
                {
                    cl.Orders.Add(Orders.ReadForClient(order.Id,unitOfWork));
                }
                return cl;                
            }
          
            internal static Client ToShortModel(DB.Clients dbItem, UnitOfWork unitOfWork)
            {
                var cl = new Client()
                {
                    Id = dbItem.Id,
                    Address = dbItem.Address,
                    Born = dbItem.Born,
                    Comments = dbItem.Comments,                    
                    Code = dbItem.Code,
                    Fio = dbItem.Fio,
                    License = dbItem.License,
                    LicenseDate = dbItem.LicenseDate,
                    Passport = dbItem.Passport,
                    Phone = dbItem.Phone,
                    Registration = dbItem.Registration,
                    When = dbItem.When,
                    Who = dbItem.Who,
                    SiteId = dbItem.SiteId,
                    Deleted = dbItem.Deleted
                };                
                return cl;
            }

            public static Client Read(int id, UnitOfWork unitOfWork)
            {
                var dbItem = new XPCollection<DB.Clients>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbItem == null)
                    throw new Exception(Resources.Clients_Read_Клиент_не_найден_);

                return ToModel(dbItem,unitOfWork);
            }
            public static Client ReadShort(int id, UnitOfWork unitOfWork)
            {
                var dbItem = new XPCollection<DB.Clients>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbItem == null)
                    throw new Exception(Resources.Clients_Read_Клиент_не_найден_);

                return ToShortModel(dbItem, unitOfWork);
            }
            public static Client ReadShortName(string fio)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var dbItem = new XPCollection<DB.Clients>(unitOfWork).FirstOrDefault(u => u.Fio == fio);
                    if (dbItem == null)
                        return null;

                    return ToShortModel(dbItem, unitOfWork);
                }
            }
            public static Client ReadSite(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var dbItem = new XPCollection<DB.Clients>(unitOfWork).FirstOrDefault(u => u.SiteId == id);
                    if (dbItem == null)
                        return null;

                    return ToShortModel(dbItem, unitOfWork);
                }
            }
            public static Client[] GetAllNamesByUser(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Clients>(unitOfWork).Where(q => q.User != null && q.User.Id == id&&!q.Deleted).Select(u => u);

                    return query
                        .OrderBy(u => u.Id)
                        .Select(q => ToShortModel(q, unitOfWork)).ToArray();
                }
            }

            public static Client[] GetAllbyUser(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Clients>(unitOfWork).Where(q=>q.User!=null&&q.User.Id==id && !q.Deleted).Select(u => u);

                    return query
                        .OrderBy(u => u.Id)
                        .Select(q => ToModel(q, unitOfWork)).ToArray();
                }
            }

            public static Client[] GetAll()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Clients>(unitOfWork).Select(u => u);

                    return query                        
                        .OrderBy(u => u.Id)
                        .Select(q=>ToModel(q,unitOfWork)).ToArray();
                }
            }

            public static int Post(Client item)
            {
                return AddNew(item);
            }

            internal static int AddNew(Client item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    DB.Clients dbItem;
                    using (var items = new XPCollection<DB.Clients>(unitOfWork))
                    {                      
                        dbItem = new DB.Clients(unitOfWork)
                        {
                            Address = item.Address,
                            Born = item.Born,
                            Comments = item.Comments,
                            Status = (int)item.Status,
                            Code = item.Code,
                            Fio = item.Fio,
                            License = item.License,
                            LicenseDate = item.LicenseDate,
                            Passport = item.Passport,
                            Phone = item.Phone,
                            Registration = item.Registration,
                            When = item.When,
                            Who = item.Who,
                            SiteId = item.SiteId,
                            Deleted = item.Deleted
                        };
                        using (var users = new XPCollection<DB.Users>(unitOfWork))
                        {
                            dbItem.User = users.FirstOrDefault(q => q.Id == item.User.Id);
                        }
                        items.Add(dbItem);
                    }
                    unitOfWork.CommitChanges();

                    return dbItem.Id;
                }
            }

            public static int Put(Client user)
            {
                return Change(user);
            }

            internal static int Change(Client item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Clients>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == item.Id);
                        if (dbItem == null)
                            throw new Exception(Resources.Clients_Read_Клиент_не_найден_);

                        dbItem.Address = item.Address;
                        dbItem.Born = item.Born;
                        dbItem.Comments = item.Comments;
                        dbItem.Status = (int) item.Status;
                        dbItem.Code = item.Code;
                        dbItem.Fio = item.Fio;
                        dbItem.License = item.License;
                        dbItem.LicenseDate = item.LicenseDate;
                        dbItem.Passport = item.Passport;
                        dbItem.Phone = item.Phone;
                        dbItem.Registration = item.Registration;
                        dbItem.When = item.When;
                        dbItem.Who = item.Who;
                        dbItem.Deleted = item.Deleted;
                        dbItem.SiteId = item.SiteId;
                    }
                    if (item.Deleted)
                    {
                        Orders.SetDeletedByClient(item.Id);
                    }
                    unitOfWork.CommitChanges();

                    return item.Id;
                }
            }

            public static void Delete(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Clients>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == id);
                        if (dbItem == null)
                            throw new Exception(Resources.Clients_Read_Клиент_не_найден_);

                        Orders.DeleteByClient(id);
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
                    using (var collection = new XPCollection<DB.Clients>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
