namespace WarehouseProject.Service
{
    public interface IVendorsService
    {
        IEnumerable<SelectListItem> GetVendors();
        IEnumerable<Vendor> GetAll();
        void Add(AddVendorViewModel Model);
        bool Remove(int id);
        void Update(EditVendorViewModel vendor);
        Vendor? GetById(int id);
        EditVendorViewModel EditVendorViewModel(int id);
        IEnumerable<Vendor> Search(string term);
    }
}
