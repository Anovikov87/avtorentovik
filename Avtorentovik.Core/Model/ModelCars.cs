using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class Cars
        {
            private static Car ToModel(DB.Cars dbItem,UnitOfWork unitOfWork)
            {
                var car=
                new Car()
                {
                    Id = dbItem.Id,
                   Color = (CarColor)dbItem.Color,
                   BodyType = (Body)dbItem.Body,
                   BodyNumber = dbItem.BodyNumber,
                   Enginge = dbItem.Engine,
                   Kpp = dbItem.Kpp,
                   Number = dbItem.Number,
                   Sts = dbItem.Sts,
                   TO = dbItem.TO,
                   Year = dbItem.Year,
                   Insurance = dbItem.Insurance,
                   Model = CarModels.Read(dbItem.Model.Id,unitOfWork),       
                   Mileage = dbItem.Mileage,                   
                   SiteId = dbItem.SiteId,
                   User = Users.Read(dbItem.User.Id,unitOfWork),
                   Deleted = dbItem.Deleted
                };
                if (dbItem.CarRental != null)
                {
                    car.CarRental = CarRentals.Read(dbItem.CarRental.Id,unitOfWork);
                }
                foreach (var damage in dbItem.DamagesCollection.Where(damage => !damage.Archive))
                {
                    car.Damages.Add(Damages.Read(damage.Id,unitOfWork));
                }
                foreach (var rent in dbItem.RentsCollection)
                {
                    car.Rents.Add(Rents.Read(rent.Id,unitOfWork));
                }
                foreach (var order in dbItem.OrdersCollection.Where(q=>!q.Deleted))
                {
                    var cor = new CarOrder()
                    {
                        ClientId = order.Client.Id,
                        DateFrom = order.DateFrom,
                        DateTo = order.DateTo,
                        Id = order.Id,
                        Territory = order.Territory
                    };
                    foreach (var serv in order.OrderServicesCollection)
                    {
                        cor.Services.Add(Services.Read(serv.Service.Id,unitOfWork));
                    }
                    car.Orders.Add(cor);                
                }
                return car;
            }

            private static Car ToShortModel(DB.Cars dbItem, UnitOfWork unitOfWork)
            {
                var car =
                new Car()
                {
                    Id = dbItem.Id,
                    Color = (CarColor)dbItem.Color,                    
                    BodyNumber = dbItem.BodyNumber,
                    Enginge = dbItem.Engine,
                    Kpp = dbItem.Kpp,
                    Number = dbItem.Number,
                    Sts = dbItem.Sts,
                    TO = dbItem.TO,
                    Year = dbItem.Year,
                    Insurance = dbItem.Insurance,
                    Model = CarModels.Read(dbItem.Model.Id, unitOfWork),
                    Mileage = dbItem.Mileage,
                    SiteId = dbItem.SiteId,
                    User = Users.Read(dbItem.User.Id, unitOfWork),
                    Deleted = dbItem.Deleted
                };
                if (dbItem.CarRental != null)
                {
                    car.CarRental = CarRentals.Read(dbItem.CarRental.Id, unitOfWork);
                }
                return car;
            }

            private static Car ToShortRentsModel(DB.Cars dbItem, UnitOfWork unitOfWork)
            {
                var car =
                new Car()
                {
                    Id = dbItem.Id,
                    Color = (CarColor)dbItem.Color,
                    BodyNumber = dbItem.BodyNumber,
                    Enginge = dbItem.Engine,
                    Kpp = dbItem.Kpp,
                    Number = dbItem.Number,
                    Sts = dbItem.Sts,
                    TO = dbItem.TO,
                    Year = dbItem.Year,
                    Insurance = dbItem.Insurance,
                    Model = CarModels.Read(dbItem.Model.Id, unitOfWork),
                    Mileage = dbItem.Mileage,                    
                    SiteId = dbItem.SiteId,
                    User = Users.Read(dbItem.User.Id, unitOfWork),
                    Deleted = dbItem.Deleted
                };
                if (dbItem.CarRental != null)
                {
                    car.CarRental = CarRentals.Read(dbItem.CarRental.Id, unitOfWork);
                }
                foreach (var rent in dbItem.RentsCollection)
                {
                    car.Rents.Add(Rents.Read(rent.Id, unitOfWork));
                }
                return car;
            }


            public static Car ReadShort(int id, UnitOfWork unitOfWork)
            {
                var dbItem = new XPCollection<DB.Cars>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbItem == null)
                    throw new Exception(Resources.Cars_Read_Автомобиль_не_найден_);

                return ToShortModel(dbItem, unitOfWork);
            }

            public static Car Read(int id, UnitOfWork unitOfWork)
            {
                var dbItem = new XPCollection<DB.Cars>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbItem == null)
                    throw new Exception(Resources.Cars_Read_Автомобиль_не_найден_);

                return ToModel(dbItem,unitOfWork);
            }

            public static Car Read(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var dbItem = new XPCollection<DB.Cars>(unitOfWork).FirstOrDefault(u => u.Id == id);
                    if (dbItem == null)
                        throw new Exception(Resources.Cars_Read_Автомобиль_не_найден_);

                    return ToModel(dbItem, unitOfWork);
                }
            }

            public static Car ReadSite(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var dbItem = new XPCollection<DB.Cars>(unitOfWork).FirstOrDefault(u => u.SiteId == id);
                    if (dbItem == null)
                        return null;

                    return ToModel(dbItem, unitOfWork);
                }
            }

            public static Car[] GetAllNamesByUser(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Cars>(unitOfWork).Where(q => q.User != null && q.User.Id == id).Select(u => u);
                    return query
                        .OrderBy(u => u.Id)
                        .Select(q => ToShortModel(q, unitOfWork)).ToArray();
                }
            }

            public static Car[] GetAllNamesWithRentsByUser(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Cars>(unitOfWork).Where(q => q.User != null && q.User.Id == id &&!q.Deleted).Select(u => u);
                    return query
                        .OrderBy(u => u.Id)
                        .Select(q => ToShortRentsModel(q, unitOfWork)).ToArray();
                }
            }

            public static Car[] GetAllbyUser(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Cars>(unitOfWork).Where(q=>q.User!=null&&q.User.Id==id && !q.Deleted).Select(u => u);
                    return query
                        .OrderBy(u => u.Id)
                        .Select(q => ToModel(q, unitOfWork)).ToArray();
                }
            }

            public static Car[] GetAll()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Cars>(unitOfWork).Select(u => u);

                    return query
                        .OrderBy(u => u.Id)
                        .Select(q=>ToModel(q,unitOfWork)).ToArray();
                }
            }

            public static int Post(Car item)
            {
                return AddNew(item);
            }

            private static int AddNew(Car item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    DB.Cars dbItem;
                    using (var items = new XPCollection<DB.Cars>(unitOfWork))
                    {                        
                        dbItem = new DB.Cars(unitOfWork)
                        {
                            Color = (int)item.Color,
                            Engine = item.Enginge,
                            Kpp = item.Kpp,
                            Number = item.Number,
                            Sts = item.Sts,
                            TO = item.TO,
                            Year = item.Year,
                            Body = (int)item.BodyType,
                            Insurance = item.Insurance,
                            BodyNumber = item.BodyNumber,       
                            Mileage                     = item.Mileage,                            
                            SiteId = item.SiteId,
                            Deleted = item.Deleted
                        };
                        items.Add(FillDependencies(unitOfWork, dbItem, item));
                    }
                    unitOfWork.CommitChanges();
                    AddDependencies(unitOfWork, item, dbItem.Id);
                    
                    unitOfWork.CommitChanges();
                    return dbItem.Id;
                }
            }
            private static void AddDependencies(UnitOfWork unitOfWork, Car item, int carId)
            {                                
                foreach (var itm in item.Damages)
                {
                    itm.CarId = carId;
                    Damages.AddNew(itm, unitOfWork);
                }
                foreach (var rent in item.Rents)
                {
                    rent.CarId = carId;
                    Rents.AddNew(rent, unitOfWork);
                }
            }
            private static DB.Cars FillDependencies(UnitOfWork unitOfWork, DB.Cars dbItem, Car item)
            {
                using (var items = new XPCollection<DB.CarModels>(unitOfWork))
                {
                    dbItem.Model = items.FirstOrDefault(q => q.Id == item.Model.Id);
                }
                using (var items = new XPCollection<DB.Users>(unitOfWork))
                {
                    dbItem.User= items.FirstOrDefault(q => q.Id == item.User.Id);
                }
                using (var items = new XPCollection<DB.CarRentals>(unitOfWork))
                {
                    dbItem.CarRental = items.FirstOrDefault(q => q.Id == item.CarRental.Id);
                }
                return dbItem;
            }

            public static int Put(Car user)
            {
                return Change(user);
            }

            private static int Change(Car item)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Cars>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == item.Id);
                        if (dbItem == null)
                            throw new Exception(Resources.Cars_Read_Автомобиль_не_найден_);

                        dbItem.Number = item.Number;
                        dbItem.Sts = item.Sts;
                        dbItem.Insurance = item.Insurance;
                        dbItem.Kpp = item.Kpp;
                        dbItem.Color = (int)item.Color;
                        dbItem.Engine = item.Enginge;
                        dbItem.TO = item.TO;
                        dbItem.Year = item.Year;
                        dbItem.Body = (int) item.BodyType;
                        dbItem.BodyNumber = item.BodyNumber;
                        dbItem.Mileage = item.Mileage;                        
                        dbItem.SiteId = item.SiteId;
                        dbItem.Deleted = item.Deleted;
                        FillDependencies(unitOfWork, dbItem, item);
                    }
                    Damages.DeleteByCarId(unitOfWork,item.Id);
                    Rents.DeleteByCarId(unitOfWork,item.Id);
                    AddDependencies(unitOfWork,item,item.Id);
                    if (item.Deleted)
                    {
                        Orders.SetDeletedByCar(item.Id);
                    }
                    unitOfWork.CommitChanges();

                    return item.Id;
                }
            }

            public static void Delete(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var items = new XPCollection<DB.Cars>(unitOfWork))
                    {
                        var dbItem = items.FirstOrDefault(u => u.Id == id);
                        if (dbItem == null)
                            throw new Exception(Resources.Cars_Read_Автомобиль_не_найден_);

                        items.DeleteObjectOnRemove = true;
                        Damages.DeleteByCarId(unitOfWork, id);
                        Rents.DeleteByCarId(unitOfWork, id);
                        Orders.DeleteByCar(id);
                        items.Remove(dbItem);
                    }

                    unitOfWork.CommitChanges();
                }
            }

            internal static bool HasAny()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var collection = new XPCollection<DB.Cars>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
