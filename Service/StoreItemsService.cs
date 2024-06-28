
namespace WarehouseProject.Service
{
    public class StoreItemsService : IStoreItemsService
    {
        private readonly AppDbContext _context;
        public StoreItemsService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetStoreItems()
        {
            return _context.ReceivedItems.Where(x => x.IsValid == true &&x.Quantity>0)
                 .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                 .OrderBy(x => x.Text)
                 .ToList();
        }
    }
    
}

