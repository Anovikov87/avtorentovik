using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class Templates
        {
            internal static Template ToModel(DB.Templates dbItem)
            {
                return new Template()
                {
                    Id = dbItem.Id,
                    Path= dbItem.Path,
                    File = dbItem.File                    
                };
            }

            public static Template Read(int id, UnitOfWork unitOfWork)
            {
                var dbItem = new XPCollection<DB.Templates>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbItem == null)
                    throw new Exception(Resources.Templates_Read_Шаблон_не_найден);

                return ToModel(dbItem);
            }

            public static Template GetbyUser(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Templates>(unitOfWork).FirstOrDefault(q=>q.User!=null&&q.User.Id==id);
                    if (query == null)
                        return null;
                    return ToModel(query);
                        //.Select(ToModel).ToArray();
                }
            }

            public static int Post(Template item)
            {
                return AddNew(item);
            }

            internal static int AddNew(Template item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    DB.Templates dbItem;
                    using (var items = new XPCollection<DB.Templates>(unitOfWork))
                    {                      

                        dbItem = new DB.Templates(unitOfWork)
                        {
                           Path = item.Path,                           
                           File= item.File
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

            public static int Put(Template user)
            {
                return Change(user);
            }

            internal static int Change(Template item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Templates>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == item.Id);
                        if (dbItem == null)
                            throw new Exception(Resources.Templates_Read_Шаблон_не_найден);
                      
                        dbItem.Path = item.Path;
                        dbItem.File= item.File;                        
                    }

                    unitOfWork.CommitChanges();

                    return item.Id;
                }
            }

            public static void Delete(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Templates>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == id);
                        if (dbItem == null)
                            throw new Exception(Resources.Templates_Read_Шаблон_не_найден);

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
                    using (var collection = new XPCollection<DB.Templates>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
