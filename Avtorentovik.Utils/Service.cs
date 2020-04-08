namespace Avtorentovik.Utils
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int PriceType { get; set; }
        public bool Status{ get; set; }
        public User User { get; set; }
        public int SiteId { get; set; }
        public int CompanyId { get; set; }
    }
}
