using Microsoft.EntityFrameworkCore;

namespace WarehouseProject.Service
{
    public interface ITendersService
    {
        IEnumerable<Tender> GetAll();
        IEnumerable<Tender> GetAll(int id);
        IEnumerable<Tender> GetAllCompleted();
        IEnumerable<Tender> GetAllCompleted(int id);
        void AddTender(TenderViewModel tender);
        Tender? GetLastTender();
        Tender? GeTById(int id);
        bool Delete();
        Tender? GetTenderByRequiredItemId(int id);
        bool SPCMemberinlasttender();
        bool TECMemberinlasttender();
        bool SLCMemberinlasttender();
        bool RCCMemberinlasttender();
        bool STCMemberinlasttender();
        bool EXCMemberinlasttender();
        Tender? getTenderByName(tendernameViewModel name);
        IEnumerable<Tender> Search(string term);
        IEnumerable<Tender> SearchNET(int term);
        IEnumerable<Tender> SearchET(int term);
        IEnumerable<Tender> GetTendersByEntityId(int id);
        IEnumerable<Tender> GetFinishedTendersByEntityId(int id);
        public IEnumerable<Tender> SearchET(int term, int id);
        public IEnumerable<Tender> SearchNET(int term, int id);
    }
}
