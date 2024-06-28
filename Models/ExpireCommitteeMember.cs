namespace WarehouseProject.Models
{
    public class ExpireCommitteeMember
    {
        public int ExpireCommitteeId { get; set; }
        public ExpireCommittee ExpireCommittee { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
