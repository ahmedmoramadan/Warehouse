namespace WarehouseProject.Models
{
    public class ExpiritionProcces
    {
        public int Id { get; set; }
        public DateOnly Createon { get; set; }
        public ExpireCommittee? ExpireCommittee { get; set; }
    }
}
