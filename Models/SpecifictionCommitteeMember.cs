namespace WarehouseProject.Models
{
    public class SpecifictionCommitteeMember
    {
        public int SpecifictionCommitteeId { get; set; }
        public SpecifictionCommittee SpecifictionCommittee { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
