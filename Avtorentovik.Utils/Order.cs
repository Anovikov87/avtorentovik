using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Avtorentovik.Utils
{
    public class Order
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("№ Заказа")]
        public string ShowId => string.Format("№{0} \n С {1} по \n {2}",SiteId,DateFrom.Date.ToShortDateString(),DateTo.Date.ToShortDateString());

        [DisplayName("Имя клиента")]
        public string ShowClient => string.Format("{0} \n {1}", Client.Fio, Client.Phone);
        [Browsable(false)]
        public Client Client { get; set; }

        [DisplayName("Автомобиль")]
        public string ShowCar => Car.Description;
        [Browsable(false)]
        public Car Car { get; set; }
        [DisplayName("Штрафы")]
        public string Fines
        {
            get
            {
                var sum = Wash + Overrun + Other;
                var res = "";
                if (sum == 0)
                    res="НЕТ";
                else
                {
                    if (Wash != 0)
                        res += string.Format("Мойка: {0} руб \n ",Wash);
                    if (Overrun != 0)
                        res += string.Format("Перепробег: {0} руб \n ", Overrun);
                    if (Other!= 0)
                        res += string.Format("Другое: {0} руб",Other);
                }
                return res;                 
            }
        }

        [DisplayName("Новые повреждения")]        
        public string ShowDamages => Damages.Count == 0 ? "Новые повреждения отсутствуют" : Damages.Aggregate("", (current, damage) => current + (damage.ToString() + ";"));
        
        [Browsable(false)]
        public string ShowStatus => Closed ? "Договор закрыт" : "Завершить";
        [Browsable(false)]
        public DateTime DateFrom { get; set; }
        [Browsable(false)]
        public DateTime DateTo { get; set; }
        [Browsable(false)]
        public string Territory { get; set; }
        [Browsable(false)]
        public List<Damage> Damages { get; set; }
        [Browsable(false)]
        public List<Service>  Services { get; set; }
        [Browsable(false)]
        public double Wash { get; set; }
        [Browsable(false)]
        public double Overrun { get; set; }
        [Browsable(false)]
        public int SiteId  { get; set; }
        [Browsable(false)]
        public double Other { get; set; }
        [Browsable(false)]
        public double MileageStart { get; set; }
        [Browsable(false)]
        public double MileageEnd { get; set; }
        [Browsable(false)]
        public bool Closed { get; set; }
        [Browsable(false)]
        public int Discount { get; set; }
        [Browsable(false)]
        public bool DiscountType { get; set; }
        [Browsable(false)]
        public bool Deleted { get; set; }
        [Browsable(false)]
        public User User { get; set; }
        public Order()
        {
            Damages=new List<Damage>();
            Services=new List<Service>();
        }
    }
}
