using System.Text;
using Avtorentovik.Core.DB;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Avtorentovik.Core.Properties;
using Avtorentovik.Utils;

namespace Avtorentovik.Core.Model
{
    public static partial class Model
    {
        public static readonly string ConnectionString = $@"XpoProvider=MSSqlServer;data source={Settings.Default.DatabaseInstance
                };integrated security=SSPI;initial catalog=Avtorentovik";

        static Model()
        {            
            Init();
        }
        private static bool _initialized;
        public static void Init()
        {
            if (!_initialized)
            {
                VLog.Log("Инициализируем модель");
                VLog.Log("строка подключения:"+ ConnectionString);
                XpoDefault.DataLayer = ConnectionHelper.GetDataLayer(AutoCreateOption.DatabaseAndSchema);
                _initialized = true;
                VLog.Log("Добавляем админа");
                InitTables();
                VLog.Log("Модель готова");                
            }
        }

        private static void InitTables()
        {

            if (!Users.HasAny())
            {
                var user = new User()
                {
                    PasswordHash = MD5Hash.Get("123456", Encoding.Default),
                    Login = "Info@karatauto.ru",                    
                };
                Users.AddNew(user);
            }         
        }

    }
}
