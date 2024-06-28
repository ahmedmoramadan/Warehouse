namespace WarehouseProject.ViewModels
{
    public class CommitteeEXCViewModel : CommitteeViewModel
    {
        [Display(Name = "Expier Committee Members")]
        public List<int> SelectEXCMembers { get; set; } = default!;
    }
    public class EditCommitteeEXCViewModel : CommitteeViewModel
    {
       public int id {  get; set; }
    }


}
