namespace WarehouseProject.Models
{
    public class ReciveCommittee
    {
        public int Id { get; set; }
        public int ReceiveproccesID { get; set; }
        public Receiveprocces receiveprocces { get; set; }
        public int HeadID { get; set; }
        public ICollection<ReciveCommitteeMember> Members { get; set; }
    }
}
