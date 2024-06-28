namespace WarehouseProject.Models
{
    public class ExpireCommittee
    {
        public int Id { get; set; }
        public int ExpiritionProccesID { get; set; }
        public ExpiritionProcces Tender { get; set; }
        public int HeadID {  get; set; }
        public ICollection<ExpireCommitteeMember> Members { get; set; }
    }
}
