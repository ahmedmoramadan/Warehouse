namespace WarehouseProject.Models
{
    public class AlternativeItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public bool IsAccept {  get; set; }              
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public int RequiredItemId { get; set; }
        public  DateOnly? Date {  get; set; }
        public RequiredItem RequiredItem { get; set; }
    }
}
