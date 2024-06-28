

namespace WarehouseProject.Service
{
    public interface IRequireditemsService 
    {
        void AddNeededItem(RequiredItemViewModel Model);
        IEnumerable<RequiredItem>? GetRequiredItemsByTenderId(int id);
        RequiredItem? Edit(SpecificationNeededItemViewModel Model);
        RequiredItem? EditValidation(int id);
        RequiredItem? GetById(int id);
        IEnumerable<RequiredItem>? GetLastValidItems(int id);
        RequiredItem? GetById(int id, int ID); //not used
        void Isvalid(ChooseValidTViewModel model);
    }
}
