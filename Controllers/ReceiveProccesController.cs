namespace WarehouseProject.Controllers
{
    public class ReceiveProccesController : Controller
    {
        private readonly IReceiveItemsService _itemsService;
        public ReceiveProccesController(IReceiveItemsService itemsService)
        {
            _itemsService = itemsService;
        }
        public IActionResult Index()
        {
            return View(); 
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ReceiveProccecViewModel MYdate)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            _itemsService.AddReceiveProcces(MYdate);
            return RedirectToAction("SelectRCCCommitteemembers", "Committee");
        }
        public IActionResult EnterItems()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EnterItems(ReceiveItemViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            _itemsService.AddReceiveItem(model);
            return RedirectToAction(nameof(EnterItems));
           
        }
        public IActionResult SelectValid()
        {
            ReceiveItemIsValidViewModel model = new ReceiveItemIsValidViewModel()
            {
                checkValid = _itemsService.GetLastRIs()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectValid(ReceiveItemIsValidViewModel mo)
        {
            if (!ModelState.IsValid)
            {
                ReceiveItemIsValidViewModel model = new ReceiveItemIsValidViewModel()
                {
                    checkValid = _itemsService.GetLastRIs()
                };
               
            return View(model);
            }
            _itemsService.IsValid(mo);
            return RedirectToAction(nameof(ItemStore));
        }
        public IActionResult ItemStore()
        {
            if (User.IsInRole("SpecificationTechnical_Head")) {
                return View(_itemsService.GETValidItem().Where(x=>x.IsValid));
            }
            return View(_itemsService.GETValidItem());
        }
        public IActionResult Search(string term)
        {
            var search = _itemsService.Search(term);
            return View(nameof(ItemStore), search);
        }
        public IActionResult Delete()
        {
            bool isDelete =_itemsService.Delete();
            return isDelete ? RedirectToAction("index", "home") : BadRequest();
        }
    }
}
