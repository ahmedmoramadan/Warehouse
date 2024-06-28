namespace WarehouseProject.Controllers
{
    public class AlternativeItemController : Controller
    {
        private readonly IOffersService _offersService;
        private readonly ITendersService _TendersService;
        private readonly IAlternativeItemsService _alternativesService;
        public AlternativeItemController(IOffersService offersService
            , IAlternativeItemsService alternativesService  , ITendersService tendersService)
        {
            _offersService = offersService;
            _alternativesService = alternativesService;           
            _TendersService = tendersService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(int id)
        {
            Tender? t = _TendersService.GetTenderByRequiredItemId(id);
            if (t == null) return null!;
            _offersService.AddReqItemToOffer(id);
            AlternativeItemViewModel AIVM = new()
            {
                RequiredItemId = id,
                TID = t.Id,
            };
            return View(AIVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AlternativeItemViewModel AIV)
        {
            if (!ModelState.IsValid)
            {
                return View(AIV);
            }
            _alternativesService.Add(AIV);
            AlternativeItemViewModel AIVM = new()
            {
                TID = AIV.TID,
                RequiredItemId = AIV.RequiredItemId,
            };
            return RedirectToAction("Add",AIVM);
        }

        public IActionResult AccptedItems(int id)
        {
            return View(_alternativesService.GetAcceptedItem(id));
        }

    }
}
