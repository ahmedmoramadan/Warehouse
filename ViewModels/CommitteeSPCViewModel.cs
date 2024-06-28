namespace WarehouseProject.ViewModels
{
    public class CommitteeSPCViewModel : CommitteeViewModel1
    {
        [Display(Name = "Specification And Pricing Committee Members")]
        public List<int> SelectSPCMembers { get; set; } = default!;
    }
    public class EditCommitteeSPCViewModel : CommitteeSPCViewModel
    {
        public int id { get; set; }
    }


}
