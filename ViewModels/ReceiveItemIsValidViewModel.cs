namespace WarehouseProject.ViewModels
{
    public class ReceiveItemIsValidViewModel
    {
        public IEnumerable<ReceivedItem>? checkValid { get; set; }  
        public List<int> uniqueName {  get; set; }
    }

}
