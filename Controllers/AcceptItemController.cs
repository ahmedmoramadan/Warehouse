namespace WarehouseProject.Controllers
{
    public class AcceptItemController : Controller
    {
        private readonly IAcceptItemsService _acceptItemsService;
        private readonly IOffersService _offersService;
        public AcceptItemController( IAcceptItemsService acceptItemsService, IOffersService ordersService )
        {
            _acceptItemsService = acceptItemsService;
            _offersService = ordersService;            
        }
        public IActionResult Index(int id)//id=>tenderid
        {
            return View(_offersService.Lastoffers(id));
        }
        public IActionResult ChooseAcceptItem(int RQId, int OId) //Get Alternative item using id 4 requireditem to Choose AcceptItem
        {
            return View(_acceptItemsService.ChooseAcceptItem(RQId, OId));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChooseAcceptItem(int id )
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _acceptItemsService.AcceptItem(id);
            return RedirectToAction("index", "Offer");
        }
        public IActionResult UpdateAccepted(int id , int tid)
        {
            var VM = new ViewModel();
            VM.Tid = tid;
            VM.offer = _offersService.GetbyId(id);
            return View(VM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAccepted(ViewModel model)
        {
            if(!ModelState.IsValid)
            {
                var VM = new ViewModel();
                VM.offer = _offersService.GetbyId(model.offer!.id);
                VM.Tid = model.Tid;
                return View(VM);
            }

             _acceptItemsService.Isaccept(model);
             return RedirectToAction("index", "Offer",new {id=model.Tid});
        }      
    }
}
