namespace WarehouseProject.Models
{
    public class RequiredItemOffer
    {
        public int RequiredItemId { get; set; }
        public RequiredItem RequiredItem { get; set; }
        public int OfferId { get; set; }
        public Offer Offer { get; set; }

    }
}
