using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class OrderDamages
        {

            public static int AddNew(Damage item,DB.Orders order,UnitOfWork unitOfWork)
            {                
                    DB.OrderDamages dbItem;
                    using (var items = new XPCollection<DB.Damages>(unitOfWork))
                    {
                        var dbDamage = items.FirstOrDefault(u => u.Id== item.Id);
                        if (dbDamage == null)
                            throw new Exception(Resources.Damages_Read_Повреждение_не_найдено_);

                        using (var ods = new XPCollection<DB.OrderDamages>(unitOfWork))
                        {
                        dbItem = new DB.OrderDamages(unitOfWork)
                            {
                                Damage = dbDamage,
                                Order = order
                            };
                        ods.Add(dbItem);
                        }                        
                    }                    
                    return dbItem.Id;                
            }           

            public static void DeleteByOrder(int id,UnitOfWork unitOfWork)
            {
                using (var items = new XPCollection<DB.OrderDamages>(unitOfWork))
                {
                    var dbItems = items.Where(u => u.Order.Id == id).ToArray();

                    items.DeleteObjectOnRemove = true;
                    for (var i = 0; i < dbItems.Length; i++)
                    {
                        var dbItem = dbItems[i];
                        items.Remove(dbItem);
                    }                                        
                }
            }

            public static void DeleteByDamage(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.OrderDamages>(unitOfWork))
                    {
                        var dbItems = items.Where(u => u.Damage.Id == id).ToArray();

                        items.DeleteObjectOnRemove = true;
                        for (var i = 0; i < dbItems.Length; i++)
                        {
                            var dbItem = dbItems[i];
                            Damages.Delete(dbItem.Damage.Id,unitOfWork);
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
                    using (var collection = new XPCollection<DB.OrderDamages>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
