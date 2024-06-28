namespace WarehouseProject.Models
{
    public class SelectionCommittee
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public Tender Tender { get; set; }
        public int HeadID { get; set; }
        public ICollection<SelectionCommitteeMember> Members { get; set; }
    }
}
