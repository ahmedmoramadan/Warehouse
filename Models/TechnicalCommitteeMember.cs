namespace WarehouseProject.Models
{
    public class TechnicalCommitteeMember
    {
        public int TechnicalCommitteeId { get; set; }
        public TechnicalCommittee TechnicalCommittee { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }

    }
}
