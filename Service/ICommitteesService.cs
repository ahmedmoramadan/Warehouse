namespace WarehouseProject.Service
{
    public interface ICommitteesService
    {
        void SelectSLCMembers(CommitteeSLCViewModel model);
        void SelectEXCMembers(CommitteeEXCViewModel model);
        void SelectSPCMembers(CommitteeSPCViewModel model);
        void SelectTECMembers(CommitteeTECViewModel model);
        void SelectSTCMembers(CommitteeSTCViewModel model);
        void SelectRCCmembers(CommitteeRCCViewModel model);

        SpecifictionCommittee GetSpecifictionCommitteeTenderID(int id);
        TechnicalCommittee GetTechnicalCommitteeByTenderId(int id);
        SelectionCommittee GetBySelectionCommitteeId(int id);
        ReciveCommittee GetByReciveCommitteeID();
        ExpireCommittee GetByExpireCommitteeID();
        SpecifictionTechnicalCommittee GetBySpecificationTechnicalID();
        //id => member id  tid=>tender id
        void HeadMemberSPC(int id , int tid);
        void HeadMemberTEC(int id ,int tid);
        void HeadMemberSLC(int id , int tid);
        void HeadMemberRCC(int id);
        void HeadMemberSTC(int id);
        void HeadMemberEXC(int id);

       
        SpecifictionCommittee EditSPC(EditCommitteeSPCViewModel model);
        TechnicalCommittee EditTEC(EditCommitteeTECViewModel model);
        SelectionCommittee EditSLC(EditCommitteeSLCViewModel model);
        //ReciveCommittee EditRCC(EditCommitteeRCCViewModel model);
        //SpecifictionTechnicalCommittee EditSTC(EditCommitteeSTCViewModel model);
        //ExpireCommittee EditEXC(EditCommitteeEXCViewModel model);

    }
}