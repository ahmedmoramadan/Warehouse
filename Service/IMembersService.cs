namespace WarehouseProject.Service
{

    public interface IMembersService
    {
        IEnumerable<SelectListItem> GetMembers();
        IEnumerable<SelectListItem> GetALLMembers();

        IEnumerable<Member> GetMembersHaveCovenent();
        Member? GetById(int id);
        IEnumerable<Member> Search(string search);
        IEnumerable<Member> SearchAll(string term);
        void AddGeneralMember(MemberMainViewModel member);
        void AddMember(MemberViewModel member);
        IEnumerable<Member> GetAll();
        EditMemberGeneralViewModel? GetByID_UseingGeneralViewmodel(int id);
        EditMemberViewModel? GetByID_UseingViewmodel(int id);
        void EditMemberGeneralViewModel(EditMemberGeneralViewModel member);
        void EditMemberViewModel(EditMemberViewModel member);
        bool Remove(int id);

        // Member? Getmember();
    }
}
