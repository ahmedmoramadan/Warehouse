namespace WarehouseProject.Service
{
    public class OffersService : IOffersService
    {
        private readonly AppDbContext _context;
        private readonly IRequireditemsService _requireditemsService;
        public OffersService(AppDbContext context , IRequireditemsService requireditemsService)
        {
            _context = context;
            _requireditemsService = requireditemsService;
        }
        public void AddOffer(OfferViewModel model)
        {
            Offer of = new()
            {
                VendorId = model.VendorId,
                CreateOn = model.CreateOn,
            };
            _context.Add(of);
            _context.SaveChanges();
        }
        public IEnumerable<RequiredItemOffer> GetRequiredItemsOffer() => _context.RequiredItemOffers.ToList();
        public void AddReqItemToOffer(int id)
        {

            RequiredItemOffer RIO = new()
            {
                RequiredItemId = id,
                OfferId = LastOffer()!.id                
            };
            var RIIO = GetRequiredItemsOffer();
            bool isfounded = false;
            foreach (var RO in RIIO)
            {               
                if (RO.RequiredItemId == id && RO.OfferId ==LastOffer()!.id)
                {
                     isfounded = true;
                }                
            }
            if(!isfounded)
            {
                _context.RequiredItemOffers.Add(RIO);
                _context.SaveChanges();
            }
        }
        public Offer? LastOffer() => _context.Offers.OrderBy(i => i.id).LastOrDefault();

        public IEnumerable<Offer> AllOffers() => _context.Offers
            .Include(v=>v.Vendor)
            .Include(a => a.alternativeItems)
            .ThenInclude(x=>x.RequiredItem).ToList();
        public IEnumerable<Offer> Lastoffers(int id)// offer for id=>requireditem-id
        {
            if(_requireditemsService.GetLastValidItems(id) == null) { return null!; }
            var ListItems = _requireditemsService.GetLastValidItems(id);
            var ListOffers = AllOffers();
            var MyOfferList = new List<Offer>();
            foreach(var i in ListItems!)
            {
                foreach(var item in ListOffers)
                {
                    foreach (var al in item.alternativeItems)
                    {
                        if (i.Id == al.RequiredItemId)
                        {
                            if(!MyOfferList.Contains(item))
                                MyOfferList.Add(item);                           
                        }
                    }
                }
            }
            return MyOfferList;
        }

        public Offer GetById(int id) => _context.Offers.Where(x => x.id == id).Include(x => x.Vendor).Include(x=>x.alternativeItems)
            .Include(x => x.RequiredItems)
            .ThenInclude(x => x.RequiredItem).FirstOrDefault()!;

        public bool Delete()
        {
            bool isDelete = false;
            Offer? Of = LastOffer();
            if (Of != null)
            {
                _context.Remove(Of);
                _context.SaveChanges();
                isDelete = true;
            }
            return isDelete;
        }

        public Offer GetbyId(int id) => _context.Offers.Include(a => a.alternativeItems).ThenInclude(x=>x.RequiredItem).FirstOrDefault(x => x.id == id)!;
       
    }
}
 //< a onclick = "if(!confirm('are you sure u want to delete it !?')){return false}" class= "btn btn-danger rounded rounded-0 " asp - action = "Delete" asp - route - id = "@Model" >
 //       < i class= "bi bi-trash3 " ></ i >
 //   </ a >