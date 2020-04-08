using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtorentovik.Utils
{
    public class CarOrder
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("№ Заказа")]
        public string ShowId => string.Format("№{0} \n С {1} по \n {2}", Id, DateFrom.Date.ToShortDateString(), DateTo.Date.ToShortDateString());
       
        [Browsable(false)]
        public int ClientId { get; set; }                        
        [Browsable(false)]
        public DateTime DateFrom { get; set; }
        [Browsable(false)]
        public DateTime DateTo { get; set; }
        [Browsable(false)]
        public string Territory { get; set; }        
        [Browsable(false)]
        public List<Service> Services { get; set; }        

        public CarOrder()
        {            
            Services = new List<Service>();
        }
    }
}
