namespace WarehouseProject.Models
{
    public class RequiredItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public int InitialPrice { get; set; }
        public bool IsValid {  get; set; }
        public int TenderId { get; set; }
        public Tender Tender { get; set; }
        public DateOnly? DATEName { get; set; }
        public DateOnly? DATESAndP { get; set; }
        public ICollection<RequiredItemOffer> Offers { get; set; }
        public ICollection<AlternativeItem>? alternativeItems { get; set; }  
    }
}
