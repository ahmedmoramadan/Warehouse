namespace WarehouseProject.ViewModels
{
    public class CommitteeViewModel1 : CommitteeViewModel
    {        
        public int TID { get; set; }
    }
    public class CommitteeViewModel
    {
        public IEnumerable<SelectListItem> Memebers { get; set; } = Enumerable.Empty<SelectListItem>();       
    }

}
