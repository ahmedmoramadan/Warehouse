
namespace WarehouseProject.Controllers
{
    public class ExpiritionProccessController : Controller
    {
        private readonly IExpiritionProccesService _ExpiritionproccesService;
        public ExpiritionProccessController(IExpiritionProccesService expiritionproccesService)
        {
            _ExpiritionproccesService = expiritionproccesService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ReceiveProccecViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _ExpiritionproccesService.Add(model);
            return RedirectToAction("SelectEXCCommitteemembers", "Committee");
        }
    }
}
