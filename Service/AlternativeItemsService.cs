namespace WarehouseProject.Service
{
    public class AlternativeItemsService : IAlternativeItemsService
    {
        private readonly AppDbContext _context;
        private readonly IOffersService _offersService;
        public AlternativeItemsService(AppDbContext context , IOffersService offersService)
        {
            _context = context;
            _offersService = offersService;
        }

        public void Add(AlternativeItemViewModel model)
        {
            var of = _offersService.LastOffer();
                
            AlternativeItem AI = new()
            {
                Name = model.Name,
                RequiredItemId = model.RequiredItemId,
                Price = model.Price,
                Type = model.Type,
                Description = model.Description,
                IsAccept = false,
                OfferId = of!.id
            };
            _context.Add(AI);
            _context.SaveChanges();
        }

        public AlternativeItem? GetById(int id) => _context.AlternativeItems.Find(id);
        public IEnumerable<AlternativeItem> GetAcceptedItem(int id)
        {
            IEnumerable<AlternativeItem> ALT = _context.AlternativeItems.Where(x=>x.RequiredItem.TenderId == id&& x.IsAccept).ToList();
            return ALT;
        }
    }
}

