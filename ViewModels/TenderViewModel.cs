namespace WarehouseProject.ViewModels
{
    public class TenderViewModel :DBViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
     //   public int EntityId {  get; set; }
      //  public IEnumerable<SelectListItem> SelectEntitie { get; set; } = Enumerable.Empty<SelectListItem>();
        public DateOnly DateOnly { get; set; }
    }
    public class DBViewModel
    {
        public int EntityId { get; set; }
        public IEnumerable<SelectListItem> SelectEntitie { get; set; } = Enumerable.Empty<SelectListItem>();   
        public int ID {  get; set; }
    }
}
