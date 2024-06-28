
namespace WarehouseProject.Service
{
    public class ReceiveItemsService : IReceiveItemsService
    {
        private readonly AppDbContext _context;
       
        public ReceiveItemsService(AppDbContext context)
        {
            _context = context;
        }
        public void AddReceiveProcces(ReceiveProccecViewModel D)
        {
            Receiveprocces RP = new Receiveprocces();
            RP.DateOnly = D.DateOnly;
            _context.Add(RP);
            _context.SaveChanges();
        }
        public void AddReceiveItem(ReceiveItemViewModel model)
        {
            var LRP = GetLast();
            if(LRP != null)
            {
                ReceivedItem RI = new()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Type = model.Type,
                    Quantity = model.Quantity,
                    IsValid = false,
                    ReceiveproccesId = LRP.Id,
                };
                _context.Add(RI);
                _context.SaveChanges();
            }
        }
        public Receiveprocces? GetLast() => _context.ReceiveProcces
            .OrderBy(x => x.Id)
            .LastOrDefault();
        public bool Delete()
        {
            Receiveprocces? LAST = GetLast();
            bool isDelete = false;
            if (LAST != null)
            {
                _context.Remove(LAST);
                _context.SaveChanges();
                isDelete = true;
            }
            return isDelete;
        }
        public IEnumerable<ReceivedItem> GetLastRIs()
        {
            var RP = GetLast();
            if (RP != null)
            {
                return _context.ReceivedItems.Where(x => x.ReceiveproccesId == RP.Id).ToList();
            }
            return Enumerable.Empty<ReceivedItem>();
        }
        public void IsValid(ReceiveItemIsValidViewModel model)
        {
            foreach(var it in model.uniqueName)
            {
                var RI = _context.ReceivedItems.Find(it);
                if (RI != null)
                {
                    RI.IsValid = true;
                }
                _context.SaveChanges();
            }
        }

        public IEnumerable<ReceivedItem> GETValidItem()
        {
          return _context.ReceivedItems.Where(x=>x.IsValid && x.Quantity>0).ToList();
        }
        public IEnumerable<ReceivedItem> Search(string term)
        {
            return _context.ReceivedItems.Where(x => x.Name.Contains(term) && x.IsValid==true).AsNoTracking().ToList();
        }
    }
}
