namespace WarehouseProject.ViewModels
{
    public class CommitteeSTCViewModel : CommitteeViewModel
    {
        [Display(Name = "Specification Technical Committee Members")]
        public List<int> SelectSTCMembers { get; set; } = default!;
    }

    public class EditCommitteeSTCViewModel : CommitteeViewModel
    {
       public int id { get; set; }
    }
}
