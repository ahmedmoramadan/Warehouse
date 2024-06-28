namespace WarehouseProject.Models
{
    public class SpecifictionTechnicalCommitteeMember
    {
        public int SpecifictionTechnicalCommitteeId { get; set; }
        public SpecifictionTechnicalCommittee SpecifictionTechnicalCommittee { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
