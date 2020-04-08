using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Avtorentovik.Utils
{
    public class Car
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Browsable(false)]
        public CarModel Model { get; set; }

        [Browsable(false)]
        public Body BodyType { get; set; }

        [Browsable(false)]
        /// True=Ручная
        public bool Kpp { get; set; }

        [Browsable(false)]
        public CarColor Color { get; set; }

        [Browsable(false)]
        public string ColorName
        {
            get
            {
                var name = "";
                switch (Color)
                {
                    case CarColor.Beige:
                        name = "Бежевый";
                        break;
                    case CarColor.Black:
                        name = "Черный";
                        break;
                    case CarColor.Blue:
                        name = "Синий";
                        break;
                    case CarColor.Brown:
                        name = "Коричневый";
                        break;
                    case CarColor.Green:
                        name = "Зеленый";
                        break;
                    case CarColor.Red:
                        name = "Красный";
                        break;
                    case CarColor.Silver:
                        name = "Серебро";
                        break;
                    case CarColor.White:
                        name = "Белый";
                        break;
                    case CarColor.Yellow:
                        name = "Желтый";
                        break;
                    default:
                        name = "Не указан";
                        break;
                }
                return name;
            }
        }

        [Browsable(false)]
        public string Number { get; set; }
        [Browsable(false)]
        public bool Deleted { get; set; }

        [Browsable(false)]
        public string Sts { get; set; }

        [Browsable(false)]
        public int Year { get; set; }

        [DisplayName("Точка выдачи")]
        public CarRental CarRental { get; set; }

        [Browsable(false)]
        public string Enginge { get; set; }

        [DisplayName("Автомобиль")]
        public string Description => string.Format("{0} {1}\n Госномер:{2}", Model, KppName, Number);

        [DisplayName("Статус")]
        public string ShowStatus
        {
            get
            {
                var result = "Свободен";
                if (Orders.Count > 0)
                {
                    var now = DateTime.Now;
                    var ord = Orders.FirstOrDefault(q => q.DateFrom <= now && q.DateTo >= now);
                    if (ord != null)
                    {
                        result = "В аренде";
                    }
                }
                return result;
            }
        }


        [DisplayName("Тип кузова")]
        public string BodyName
        {
            get
            {
                switch (BodyType)
                {
                    case Body.Cabrio:
                        return "Кабриолет";
                    case Body.Cargo:
                        return "Грузовой";
                    case Body.Hatch:
                        return "Хэтчбек";
                    case Body.Jeep:
                        return "Внедорожник";
                    case Body.Mikrobus:
                        return "Микроавтобус";
                    case Body.Minivan:
                        return "Минивен";
                    case Body.Sedan:
                        return "Седан";
                    case Body.Universal:
                        return "Универсал";
                    default:
                        return "";
                }
            }
        }
        [Browsable(false)]
        public string BodyNumber { get; set; }
        [DisplayName("Страховка")]
        public DateTime Insurance { get; set; }
        public string TO { get; set; }
        [Browsable(false)]
        public List<Damage> Damages { get; set; }
        [Browsable(false)]
        public List<Rent> Rents { get; set; }
        [Browsable(false)]
        public double Mileage { get; set; }
        public Car()
        {
            Damages=new List<Damage>();
            Rents=new List<Rent>();
            Orders=new List<CarOrder>();
        }

        [Browsable(false)]
        public string KppName => Kpp ? "Ручная" : "АКПП";
        [Browsable(false)]
        public List<CarOrder> Orders { get; set; }
        [DisplayName("Повреждения")]
        public string DamageCount => string.Format("Открыть \n список ({0})", Damages.Count);
        [Browsable(false)]
        public User User { get; set; }
        [Browsable(false)]
        public int SiteId { get; set; }
        public override string ToString()
        {
            return $"{Model} {KppName}";
        }
        [Browsable(false)]
        public int GetSiteBody
        {
            get
            {
                var res = 0;
                switch (BodyType)
                {
                    case Body.Sedan:
                        res = 1;
                        break;
                    case Body.Universal:
                        res = 2;
                        break;
                    case Body.Hatch:
                        res = 3;
                        break;
                    case Body.Minivan:
                        res = 4;
                        break;
                    case Body.Cabrio:
                        res = 5;
                        break;
                    case Body.Cargo:
                        res = 8;
                        break;
                    case Body.Mikrobus:
                        res = 9;
                        break;
                    case Body.Jeep:
                        res = 12;
                        break;                    
                }
                return res;
            }
        }

        public void SetSiteBody(int id)
        {
            switch (id)
            {
                case 1:
                    BodyType = Body.Sedan;
                    break;
                case 2:
                    BodyType = Body.Universal;
                    break;
                case 3:
                    BodyType = Body.Hatch;
                    break;
                case 4:
                    BodyType = Body.Minivan;
                    break;
                case 5:
                    BodyType = Body.Cabrio;
                    break;
                case 8:
                    BodyType = Body.Cargo;
                    break;
                case 9:
                    BodyType = Body.Mikrobus;
                    break;
                case 12:
                    BodyType = Body.Jeep;
                    break;
                default:
                    BodyType = Body.Sedan;
                    break;
            }
        }

        /*
   {"id":1,"value":"Седан"},
   {"id":2,"value":"Универсал"},
   {"id":3,"value":"Хетчбэк"}
   {"id":4,"value":"Минивэн"},
   {"id":5,"value":"Родстер"},
   {"id":6,"value":"Фаэтон"},
   {"id":7,"value":"Пикап"},
   {"id":8,"value":"Фургон"},
   {"id":9,"value":"Микроавтобус"},
   {"id":10,"value":"Лимузин"},
   "id":12,"value":"Внедорожник"},
   */
    }
}
