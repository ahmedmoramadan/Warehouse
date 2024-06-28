namespace WarehouseProject.ViewModels
{
    public class SpecificationNeededItemViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Value must be greater than 0")]
        public int InitialPrice { get; set; }
        public int TId { get; set; }
    }
}
