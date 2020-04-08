using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class CarModels
        {
            private static CarModel ToModel(DB.CarModels dbItem)
            {
                return 
                new CarModel()
                {
                    Id = dbItem.Id,
                    Name = dbItem.Name,   
                    MarkId = dbItem.Mark.Id
                };                
                
            }

            public static CarModel Read(int id, UnitOfWork unitOfWork)
            {
                var dbItem = new XPCollection<DB.CarModels>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbItem == null)
                    throw new Exception(Resources.CarModels_Read_Модель_не_найдена_);

                return ToModel(dbItem);
            }

            public static CarModel[] GetAll()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.CarModels>(unitOfWork).Select(u => u);

                    return query                        
                        .OrderBy(u => u.Name)
                        .Select(ToModel).ToArray();
                }
            }        

            public static int Post(CarModel item)
            {
                return AddNew(item);
            }

            internal static int AddNew(CarModel item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    DB.CarModels dbItem;
                    using (var items = new XPCollection<DB.CarModels>(unitOfWork))
                    {
                        dbItem = items.FirstOrDefault(u => u.Name== item.Name);
                        if (dbItem != null)
                            throw new Exception(Resources.CarModels_AddNew_Такая_модель_уже_есть_);

                        dbItem = new DB.CarModels(unitOfWork)
                        {
                           Name = item.Name,                                                     
                        };
                        items.Add(FillDependencies(unitOfWork,dbItem,item));
                    }
                    unitOfWork.CommitChanges();

                    return dbItem.Id;
                }
            }

            private static DB.CarModels FillDependencies(UnitOfWork unitOfWork, DB.CarModels dbItem, CarModel item)
            {
                using (var items = new XPCollection<DB.Marks>(unitOfWork))
                {
                    dbItem.Mark = items.FirstOrDefault(q => q.Id == item.MarkId);
                }                
                return dbItem;
            }

            public static int Put(CarModel user)
            {
                return Change(user);
            }

            private static int Change(CarModel item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.CarModels>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == item.Id);
                        if (dbItem == null)
                            throw new Exception(Resources.CarModels_Read_Модель_не_найдена_);

                        var duplicatedbItem = items.FirstOrDefault(u => u.Name == item.Name&& u.Id != item.Id);
                        if (duplicatedbItem != null)
                            throw new Exception(Resources.CarModels_AddNew_Такая_модель_уже_есть_);

                        dbItem.Name = item.Name;                        
                    }

                    unitOfWork.CommitChanges();

                    return item.Id;
                }
            }

            public static void Delete(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.CarModels>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == id);
                        if (dbItem == null)
                            throw new Exception(Resources.CarModels_Read_Модель_не_найдена_);

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
                    using (var collection = new XPCollection<DB.CarModels>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
