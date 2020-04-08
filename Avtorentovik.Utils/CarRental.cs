using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtorentovik.Utils
{
    public class CarRental
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SiteId { get; set; }
        public int UserId { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
