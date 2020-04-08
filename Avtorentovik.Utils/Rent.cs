using System.ComponentModel;

namespace Avtorentovik.Utils
{
    public class Rent
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("От")]
        public int From { get; set; }

        [DisplayName("До")]
        public string ToShow
        {
            get
            {
                if (To == 0)
                    return "и более";
                else
                    return To.ToString();
            }
        }
        [Browsable(false)]
        public int To { get; set; }

        [DisplayName("Цена")]
        public string PriceShow => string.Format("{0} руб.",Price);
        [Browsable(false)]
        public int Price { get; set; }
        [Browsable(false)]
        public bool Status { get; set; }
        [Browsable(false)]
        public int CarId { get; set; }
        [Browsable(false)]
        public int SiteId { get; set; }
        [DisplayName("Статус")]
        public string ShowStatus => Status ? "активна" : "неактивна";
    }
}
