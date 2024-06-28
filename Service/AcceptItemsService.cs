
namespace WarehouseProject.Service
{
    public class AcceptItemsService : IAcceptItemsService
    {
        private readonly AppDbContext _context;
      
        private readonly IAlternativeItemsService _alternativeItemsService;
        //private IOffersService _offersService;
        public AcceptItemsService(AppDbContext context 
            ,IAlternativeItemsService alternativeItemsService )
        {
            _context = context;
            _alternativeItemsService = alternativeItemsService;
        }
        public AlternativeItem AcceptItem(int id)
        {
            AlternativeItem? alt = _alternativeItemsService.GetById(id);
            if (alt == null)
                return null!;

            alt!.IsAccept = true;
            _context.SaveChanges();
            return alt;
        }       
        public IEnumerable<AlternativeItem> ChooseAcceptItem(int ID , int OId) // id 4 requireditem oid 4 offer
        {
            return _context.AlternativeItems.Include(x=>x.RequiredItem).Where(r=>r.RequiredItemId==ID && r.OfferId==OId).ToList();
        }
        public void Isaccept(ViewModel model)
        {
            int c = 0;
            foreach (var i in model.uniqueid)
            {
                var ALI = _alternativeItemsService.GetById(i);
                if(ALI != null) {
                    ALI.IsAccept = true;
                }
                c = _context.SaveChanges();
            }

            if (c > 0 )
            {
                Tender TN = _context.Tenders.Find(model.Tid)!;
                TN.Finitished = true;
                TN.DateFinitished = DateOnly.FromDateTime(DateTime.Now);
                _context.SaveChanges();
            }

        }

       
    }
    
    
}

