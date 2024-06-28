namespace WarehouseProject.ViewModels
{
    public class CommitteeRCCViewModel : CommitteeViewModel
    {
        [Display(Name = "Recive Committee Members")]
        public List<int> SelectRCCMembers { get; set; } = default!;
    }
    public class EditCommitteeRCCViewModel : CommitteeViewModel
    {
       public int id {  get; set; }
    }

}
