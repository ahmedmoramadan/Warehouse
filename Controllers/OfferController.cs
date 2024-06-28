namespace WarehouseProject.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOffersService _offersService;
        private readonly IVendorsService _venorsService;
        public OfferController(IOffersService offersService, IVendorsService venorsService)
        {
            _offersService = offersService;
            _venorsService = venorsService;
        }
        public IActionResult Index(int id)
        {
           return View(_offersService.Lastoffers(id));
        }
        public IActionResult Details(int id)
        {            
            return View(_offersService.GetById(id));
        }
        public IActionResult Add(int id)//id=> tenderid
        {
            OfferViewModel model = new OfferViewModel();
            model.Vendors = _venorsService.GetVendors();
            model.TID = id;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(OfferViewModel model)
        {
            if (!ModelState.IsValid)
            {
                OfferViewModel OF = new OfferViewModel();
                OF.Vendors = _venorsService.GetVendors();
                OF.TID = model.TID;
                return View(OF);
            }
            _offersService.AddOffer(model);
            return RedirectToAction("ValidItems", "RequiredItem", new { id = model.TID });
        }
       
    }
}

