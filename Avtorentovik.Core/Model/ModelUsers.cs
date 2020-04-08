using System;
using System.Linq;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;
using DevExpress.Xpo;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static class Users
        {
            internal static User ToModel(DB.Users dbUser)
            {
                return new User()
                {
                    Id = dbUser.Id,
                    Login = dbUser.Login,
                    PasswordHash = dbUser.PasswordHash,     
                    SiteId               = dbUser.SiteId
                };
            }

            public static User Read(int id, UnitOfWork unitOfWork)
            {
                var dbUser = new XPCollection<DB.Users>(unitOfWork).FirstOrDefault(u => u.Id == id);
                if (dbUser == null)
                    throw new Exception(Resources.Users_Read_Пользователь_не_найден_);

                return ToModel(dbUser);
            }

            internal static User Read(string login)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var dbUser = new XPCollection<DB.Users>(unitOfWork).FirstOrDefault(u => u.Login == login);
                    if (dbUser == null)
                        throw new Exception(Resources.Users_Read_Пользователь_не_найден_);

                    return ToModel(dbUser);
                }
            }

            public static User[] GetAll()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var query = new XPCollection<DB.Users>(unitOfWork).Select(u => u);

                    return query                        
                        .OrderBy(u => u.Login)
                        .Select(ToModel).ToArray();
                }
            }

            public static int Post(User user)
            {
                return AddNew(user);
            }

            internal static int AddNew(User user)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    DB.Users dbUser;
                    using (var users = new XPCollection<DB.Users>(unitOfWork))
                    {
                        dbUser = users.FirstOrDefault(u => u.Login == user.Login);
                        if (dbUser != null)
                            throw new Exception(Resources.Users_AddNew_Такой_пользователь_уже_существует_);

                        dbUser = new DB.Users(unitOfWork)
                        {
                            Login = user.Login,
                            PasswordHash = user.PasswordHash,   
                            SiteId                         = user.SiteId
                        };
                        users.Add(dbUser);
                    }
                    unitOfWork.CommitChanges();

                    return dbUser.Id;
                }
            }

            public static int Put(User user, bool changePassword)
            {
                return Change(user, changePassword);
            }

            internal static int Change(User user, bool changePassword)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var users = new XPCollection<DB.Users>(unitOfWork))
                    {
                        var dbUser = users.FirstOrDefault(u => u.Id == user.Id);
                        if (dbUser == null)
                            throw new Exception(Resources.Users_Read_Пользователь_не_найден_);

                        var duplicateDbUser = users.FirstOrDefault(u => u.Login == user.Login && u.Id != user.Id);
                        if (duplicateDbUser != null)
                            throw new Exception(Resources.Users_AddNew_Такой_пользователь_уже_существует_);
                        
                        dbUser.Login = user.Login;
                        dbUser.SiteId = user.SiteId;
                        if (changePassword)
                            dbUser.PasswordHash = user.PasswordHash;                        
                    }

                    unitOfWork.CommitChanges();

                    return user.Id;
                }
            }

            public static void Delete(int id)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var users = new XPCollection<DB.Users>(unitOfWork))
                    {
                        var dbUser = users.FirstOrDefault(u => u.Id == id);
                        if (dbUser == null)
                            throw new Exception(Resources.Users_Read_Пользователь_не_найден_);

                        users.DeleteObjectOnRemove = true;
                        users.Remove(dbUser);
                    }

                    unitOfWork.CommitChanges();
                }
            }

            internal static bool HasAny()
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    using (var collection = new XPCollection<DB.Users>(unitOfWork))
                    {
                        return collection.Any();
                    }
                }
            }
        }
    }
}
