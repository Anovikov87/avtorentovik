using System.ComponentModel;

namespace Avtorentovik.Utils
{
    public class Damage
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Деталь")]
        public string Detail { get; set; }
        [DisplayName("Повреждение")]
        public string Description { get; set; }
        [Browsable(false)]
        public int CarId { get; set; }
        [Browsable(false)]
        public bool Archive { get; set; }
        public override string ToString()
        {
            return string.Format("{0} - {1}",Detail,Description);
        }
    }
}
