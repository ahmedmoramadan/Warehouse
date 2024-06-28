namespace WarehouseProject.Models
{
    public class Receiveprocces
    {
        public int Id { get; set; }
        public DateOnly DateOnly { get; set; }
       
        public ICollection<ReceivedItem> ReceivedItems { get; set; }
        public ReciveCommittee? ReciveCommittee { get; set;}
        public SpecifictionTechnicalCommittee SpecifictionTechnicalCommittee { get; set; }
    }
}
