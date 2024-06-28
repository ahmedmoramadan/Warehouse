namespace WarehouseProject.Models
{
    public class Offer
    {
        public int id { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public DateOnly CreateOn { get; set; }
        public ICollection<RequiredItemOffer> RequiredItems { get; set; }
        public ICollection<AlternativeItem> alternativeItems {  get; set; } 
    }
}
