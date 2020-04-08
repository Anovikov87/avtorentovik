using System.ComponentModel;

namespace Avtorentovik.Utils
{
    public class User
    {
        [DisplayName("Логин")]
        public string Login { get; set; }
        [Browsable(false)]
        public string PasswordHash { get; set; }
        [Browsable(false)]
        public string Password { get; set; }
        [Browsable(false)]
        public int Id { get; set; }
        [Browsable(false)]
        public int SiteId { get; set; }
        public override string ToString()
        {
            return Login;
        }
    }    
}
