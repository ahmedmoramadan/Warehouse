namespace WarehouseProject.ViewModels
{
    public class OfferViewModel
    {
        public int VendorId { get; set; }
        public IEnumerable<SelectListItem> Vendors { get; set; } = new List<SelectListItem>();
        public DateOnly CreateOn { get; set; }
        public int TID {  get; set; }
    }
}
