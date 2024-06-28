namespace WarehouseProject.Models
{
    public class ReciveCommitteeMember
    {
        public int ReciveCommitteeId { get; set; }
        public ReciveCommittee ReciveCommittee { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
