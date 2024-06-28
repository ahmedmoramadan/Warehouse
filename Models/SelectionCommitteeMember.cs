namespace WarehouseProject.Models
{
    public class SelectionCommitteeMember
    {
        public int SelectionCommitteeId { get; set; }
        public SelectionCommittee SelectionCommittee { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
