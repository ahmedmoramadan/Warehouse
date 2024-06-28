namespace WarehouseProject.Models
{
    public class Vendor
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string number { get; set; }
        public ICollection<Offer> offers { get; set; }
    }
}
