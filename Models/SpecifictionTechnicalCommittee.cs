namespace WarehouseProject.Models
{
    public class SpecifictionTechnicalCommittee
    {
        public int Id { get; set; }
        public int ReceiveproccesId { get; set; }
        public Receiveprocces Receiveprocces { get; set; }
        public int HeadID { get; set; }
        public ICollection<SpecifictionTechnicalCommitteeMember> Members { get; set; }
    }
}
