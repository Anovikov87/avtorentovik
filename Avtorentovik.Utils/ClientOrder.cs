using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtorentovik.Utils
{
    public class ClientOrder
    {
        [DisplayName("№ Заказа")]
        public int Id { get; set; }                
        [DisplayName("Автомобиль")]        
        public Car Car { get; set; }
        [DisplayName("Дата начала")]
        public DateTime DateFrom { get; set; }
        [DisplayName("Дата окончания")]
        public DateTime DateTo { get; set; }        
        
        [DisplayName("Статус")]
        public string ShowStatus => Closed ? "Договор закрыт" : "Договор открыт";
        [Browsable(false)]
        public bool Closed { get; set; }        
    }
}
