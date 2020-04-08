using System.Collections.Generic;
using System.ComponentModel;

namespace Avtorentovik.Utils
{
    public class Mark
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName()]
        public string Name { get; set; }
        [Browsable(false)]
        public List<CarModel> Models { get; set; }
        [Browsable(false)]
        public int SiteId { get; set; }       

        public Mark()
        {
            Models=new List<CarModel>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
