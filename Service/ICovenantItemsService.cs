
namespace WarehouseProject.Service
{
    public interface ICovenantItemsService
    {
        void Add(CovenantViewModel model);
        void ReturnCovenant(int id);
        bool Delete(int id);
        IEnumerable<CovenantItem> ListCovenantItems();
    }
    
}

