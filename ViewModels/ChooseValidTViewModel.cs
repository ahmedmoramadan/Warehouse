namespace WarehouseProject.ViewModels
{
    public class ChooseValidTViewModel
    {
        public IEnumerable<RequiredItem> CheckValid { get; set; } = Enumerable.Empty<RequiredItem>();

        public List<int> uniqueid { get; set; }
        public int Tid {  get; set; }
    }

}
