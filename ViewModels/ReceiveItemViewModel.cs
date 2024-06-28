namespace WarehouseProject.ViewModels
{
    public class ReceiveItemViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than or Equal 1")]
        public int Quantity { get; set; }
    }
}
