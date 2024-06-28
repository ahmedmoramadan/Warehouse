namespace WarehouseProject.ViewModels
{
    public class CovenantViewModel 
    {
        public int MemberId { get; set; }
        public IEnumerable<SelectListItem> Memebers { get; set; } = Enumerable.Empty<SelectListItem>();
        public int SelectItem { get; set; }
        public IEnumerable<SelectListItem> StoreItems { get; set; } = Enumerable.Empty<SelectListItem>();
        [Required(ErrorMessage = "Please enter a value")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than or Equal 1")]
        [Display(Name ="Quantity")]
        public int QTY {  get; set; }

    }

}
