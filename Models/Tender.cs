using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace WarehouseProject.Models
{
    public class Tender
    {
        public int Id { get; set; }
        [DisplayName("Tender Name")]    
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Create On")]
        public DateOnly DateOnly { get; set; }
        public DateOnly? DateFinitished { get; set; }
        public bool Finitished { get; set; }
        public int EntityId { get; set; }
        public Entity Entity { get; set; }
        public ICollection<RequiredItem>? RequiredItems { get; set; }
        public SelectionCommittee? selectionCommittee { get; set; }
        public TechnicalCommittee? TechnicalCommittee { get; set; }
        public SpecifictionCommittee? SpecifictionCommittee { get; set; }
    }
    public class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Tender> tenders { get; set; }
    }
}
