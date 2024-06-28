using System;

namespace WarehouseProject.Service
{
    public class RequireditemsService : IRequireditemsService
    {
        private readonly AppDbContext _context;
        private readonly ITendersService _tendersService;
        public RequireditemsService(AppDbContext context, ITendersService tendersService)
        {
            _context = context;
            _tendersService = tendersService;
        }

        public void AddNeededItem(RequiredItemViewModel Model)
        {
            RequiredItem n = new()
            {
                TenderId = Model.TID,
                Name = Model.Name,
                IsValid = false,
            };
            _context.RequiredItems.Add(n);
             _context.SaveChanges();
        }
        public RequiredItem? Edit(SpecificationNeededItemViewModel Model)
        {
            var Item = _context.RequiredItems.Find(Model.id);
            if (Item == null)
                return null;
            Item.Id = Model.id;
            Item.Name = Model.Name;
            Item.Description = Model.Description;
            Item.InitialPrice = Model.InitialPrice;
            Item.Type = Model.Type;
            Item.DATESAndP = DateOnly.FromDateTime(DateTime.Now);
            _context.SaveChanges();
            return Item;
        }
        public IEnumerable<RequiredItem>? GetRequiredItemsByTenderId(int id)
        {
            var T = _context.Tenders.Find(id);
            if (T == null)
                return null!;
            return _context.RequiredItems.Include(x => x.Tender).Where(x => x.TenderId == T.Id).ToList();
        }
        public RequiredItem? GetById(int id) =>  _context.RequiredItems
            .Include(x=>x.alternativeItems)
            .FirstOrDefault(x=>x.Id == id);
        public RequiredItem? GetById(int id, int ID) => _context.RequiredItems
           .Include(x => x.alternativeItems)!.ThenInclude(x=>x.OfferId).FirstOrDefault(x => x.Id == id); //not used
        public RequiredItem? EditValidation(int id)
        {
            var RI = GetById(id);
            RI!.IsValid = true;
            _context.SaveChanges();
            return RI;
        }
        public IEnumerable<RequiredItem>? GetLastValidItems(int id)
        {
            if (GetRequiredItemsByTenderId(id) != null!) 
            {
                return GetRequiredItemsByTenderId(id)!.Where(x => x.IsValid == true).ToList();
            }
            return null!;
        }
        public void Isvalid(ChooseValidTViewModel model)
        {
            foreach (var i in model.uniqueid)
            {
                RequiredItem? item = GetById(i);
                if(item != null)
                {
                    item.IsValid = true;
                    item.DATEName = DateOnly.FromDateTime(DateTime.Now);
                }
            _context.SaveChanges();
            }
        }
    }
}
