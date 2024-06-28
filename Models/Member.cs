namespace WarehouseProject.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Password { get; set; }
        public ICollection<CovenantItem> CovenantItems { get; set; }
        public ICollection<SelectionCommitteeMember> selectionCommitteeMembers { get; set; }
        public ICollection<SpecifictionCommitteeMember> specifictionCommitteeMembers { get; set; }
        public ICollection<TechnicalCommitteeMember> technicalCommitteeMembers { get; set; }
        public ICollection<SpecifictionTechnicalCommitteeMember> specifictionTechnicalCommitteeMembers { get; set; }
        public ICollection<ExpireCommitteeMember> expireCommitteeMembers { get; set;}
        public ICollection<ReciveCommitteeMember> reciveCommitteeMembers { get;set; }

    }
}
