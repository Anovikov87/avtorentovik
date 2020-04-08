using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class Marks
        {
            internal static Mark ToModel(DB.Marks dbItem,UnitOfWork unitOfWork)
            {
                var mark= new Mark()
                {
                    Id = dbItem.Id,
                    Name = dbItem.Name,
                    SiteId = dbItem.SiteId
                };
                foreach (var model in dbItem.ModelsCollection)
                {
                    mark.Models.Add(CarModels.Read(model.Id, unitOfWork));
                }
                return mark;
            }

            public static Mark Read(int id, UnitOfWork unitOfWork)
            {
                var dbItem = new XPCollection<DB.Marks>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbItem == null)
                    throw new Exception(Resources.Marks_Read_Марка_не_найдена_);

                return ToModel(dbItem, unitOfWork);
            }

            public static Mark[] GetAll()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Marks>(unitOfWork).Select(u => u);

                    return query                        
                        .OrderBy(u => u.Name)
                        .Select(q=>ToModel(q, unitOfWork)).ToArray();
                }
            }

            public static int Post(Mark item)
            {
                return AddNew(item);
            }

            internal static int AddNew(Mark item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    DB.Marks dbItem;
                    using (var items = new XPCollection<DB.Marks>(unitOfWork))
                    {
                        dbItem = items.FirstOrDefault(u => u.Name== item.Name);
                        if (dbItem != null)
                            throw new Exception(Resources.Marks_AddNew_Такая_марка_уже_есть_);

                        dbItem = new DB.Marks(unitOfWork)
                        {
                           Name = item.Name,
                            SiteId = item.SiteId
                        };
                        items.Add(dbItem);
                    }
                    unitOfWork.CommitChanges();

                    return dbItem.Id;
                }
            }

            public static int Put(Mark user)
            {
                return Change(user);
            }

            internal static int Change(Mark item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Marks>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == item.Id);
                        if (dbItem == null)
                            throw new Exception(Resources.Marks_Read_Марка_не_найдена_);

                        var duplicatedbItem = items.FirstOrDefault(u => u.Name == item.Name&& u.Id != item.Id);
                        if (duplicatedbItem != null)
                            throw new Exception(Resources.Marks_AddNew_Такая_марка_уже_есть_);

                        dbItem.Name = item.Name;
                        dbItem.SiteId = item.SiteId;
                    }

                    unitOfWork.CommitChanges();

                    return item.Id;
                }
            }

            public static void Delete(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Marks>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == id);
                        if (dbItem == null)
                            throw new Exception(Resources.Marks_Read_Марка_не_найдена_);

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
                    using (var collection = new XPCollection<DB.Marks>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
