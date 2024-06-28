namespace WarehouseProject.ViewModels
{
    public class CommitteeSLCViewModel : CommitteeViewModel1
    {
        [Display(Name = "Selection Committee Members")]
        public List<int> SelectSLCMembers { get; set; } = default!;
    }
    public class EditCommitteeSLCViewModel : CommitteeSLCViewModel
    {
      public int id {  get; set; }
    }

}
