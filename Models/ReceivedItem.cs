namespace WarehouseProject.Models
{
    public class ReceivedItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type {  get; set; }
        public string Description { get; set; } 
        public int Quantity { get; set; }
        public bool IsValid { get; set; }
        public int ReceiveproccesId {  get; set; }
        public Receiveprocces Receiveprocces { get; set; } 
    }
}
