namespace WarehouseProject.Models
{
    public class CovenantItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int MemberId {  get; set; } 
        public Member Member { get; set; }
    }
}
