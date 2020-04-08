using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace Avtorentovik.Utils
{
    public class Client
    {
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("Имя клиента")]
        public string ShowName => string.Format("{0} \n {1}", Fio, Born);

        [Browsable(false)]
        public string Fio { get; set; }
        [Browsable(false)]
        public bool Deleted { get; set; }

        [DisplayName("Статус")]
        public string ShowStatusClient
        {
            get
            {
                var stat = "";
                switch (Status)
                {
                    case ClientStatus.Active:
                        stat = "Активный";
                        break;
                    case ClientStatus.Debtor:
                        stat = "Должник";
                        break;
                    case ClientStatus.Refuse:
                        stat = "Отказ ПО СБ";
                        break;
                }
                return stat;
            }
        }

        [DisplayName("Телефон клиента")]
        public string Phone { get; set; }

        [DisplayName("История клиента")]
        public string ShowHistory {
            get
            {
                var res = "";
                if (Orders.Count == 0)
                    res = "ОТСУТСТВУЕТ";
                else
                {
                    var min = Orders.Min(q => q.DateFrom).Date.ToShortDateString();
                    res = $"{Orders.Count} заказов с {min} \n Открыть список";
                }
                return res;
            }
        }

    [Browsable(false)]
        public string Passport { get; set; }
        [Browsable(false)]
        public DateTime When { get; set; }
        [Browsable(false)]
        public string Who { get; set; }
        [Browsable(false)]
        public string Code { get; set; }
        [Browsable(false)]
        public string License { get; set; }
        [Browsable(false)]
        public DateTime LicenseDate { get; set; }
        [Browsable(false)]
        public string Registration { get; set; }
        [Browsable(false)]
        public string Address { get; set; }
        [Browsable(false)]
        public string Born { get; set; }

        [DisplayName("Особые сведения")]
        public string ShowComments => string.IsNullOrEmpty(Comments) ? "Сведения остуствуют. \n Добавить" : Comments;

        [Browsable(false)]
        public string Comments { get; set; }
        [Browsable(false)]
        public ClientStatus Status { get; set; }
        [Browsable(false)]
        public User User { get; set; }
        public override string ToString()
        {
            return Fio;
        }
        [Browsable(false)]
        public int SiteId { get; set; }
        [Browsable(false)]
        public List<ClientOrder> Orders { get; set; }
        public Client()
        {
            Orders = new List<ClientOrder>();
        }

        public Client Clone()
        {
            return new Client()
            {
                Fio = this.Fio,
               Phone = this.Phone,
               Address = this.Address,
               Born = this.Born,
               Status = this.Status,
               Registration = this.Registration,
               LicenseDate = this.LicenseDate,
               Who = this.Who,
               When = this.When,
                License = this.License,
                Passport = this.Passport,
                SiteId = this.SiteId,                              
            };
        }     
    }
}
