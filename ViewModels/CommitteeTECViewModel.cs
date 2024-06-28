namespace WarehouseProject.ViewModels
{
    public class CommitteeTECViewModel : CommitteeViewModel1
    {
        [Display(Name = "Technical Committee Members")]
        public List<int> SelectTECMembers { get; set; } = default!;
    }

    public class EditCommitteeTECViewModel : CommitteeTECViewModel
    {
       public int id { get; set; }
    }

}
