namespace WarehouseProject.Models
{
    public class SpecifictionCommittee
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public Tender Tender { get; set; }
        public int HeadID { get; set; }
        public ICollection<SpecifictionCommitteeMember> Members { get; set; }
    }
}
