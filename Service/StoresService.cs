//namespace WarehouseProject.Service
//{
//    public class StoresService : IStoresService
//        {
//            private readonly AppDbContext _context;
//            public StoresService(AppDbContext context)
//            {
//                _context = context;
//            }
//            public IEnumerable<SelectListItem> GetStores()
//            {
//                return _context.Stores.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
//                    .OrderBy(x => x.Text)
//                    .AsNoTracking()
//                    .ToList();
//            }
//        }
//    }
