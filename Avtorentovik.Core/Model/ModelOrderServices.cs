using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class OrderServices
        {

            public static int AddNew(Service item,DB.Orders order,UnitOfWork unitOfWork)
            {                
                    DB.OrderServices dbItem;
                    using (var items = new XPCollection<DB.Services>(unitOfWork))
                    {
                        var dbServ = items.FirstOrDefault(u => u.Id== item.Id);
                        if (dbServ == null)
                            throw new Exception(Resources.Services_Read_Услуга_не_найдена_);

                        using (var oss = new XPCollection<DB.OrderServices>(unitOfWork))
                        {
                        dbItem = new DB.OrderServices(unitOfWork)
                            {
                                Service = dbServ,
                                Order = order
                            };
                            oss.Add(dbItem);
                        }                        
                    }                    
                    return dbItem.Id;                
            }           

            public static void DeleteByOrder(int id,UnitOfWork unitOfWork)
            {
                using (var items = new XPCollection<DB.OrderServices>(unitOfWork))
                {
                    var dbItems = items.Where(u => u.Order!=null&&u.Order.Id == id).ToArray();

                    items.DeleteObjectOnRemove = true;
                    for (var i = 0; i < dbItems.Length; i++)
                    {
                        var dbItem = dbItems[i];
                        items.Remove(dbItem);
                    }
                }
            }

            public static void DeleteByService(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.OrderServices>(unitOfWork))
                    {
                        var dbItems = items.Where(u => u.Service.Id == id).ToArray();

                        items.DeleteObjectOnRemove = true;
                        for (var i = 0; i < dbItems.Length; i++)
                        {
                            var dbItem = dbItems[i];
                            items.Remove(dbItem);
                        }
                    }
                    unitOfWork.CommitChanges();
                }
            }

            internal static bool HasAny()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var collection = new XPCollection<DB.OrderServices>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
