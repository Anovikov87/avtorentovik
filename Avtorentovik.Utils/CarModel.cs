using System.ComponentModel;

namespace Avtorentovik.Utils
{
    public    class CarModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Модель")]
        public string Name { get; set; }
        [Browsable(false)]
        public int MarkId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
