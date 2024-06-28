namespace WarehouseProject.Controllers
{
    public class CovenantItemController : Controller
    {
        private readonly IStoreItemsService _storeItemsService;
        private readonly IMembersService _membersService;
        private readonly ICovenantItemsService _covenantItemsService;
        public CovenantItemController(IStoreItemsService storeItemsService, IMembersService membersService , ICovenantItemsService covenantItemsService)
        {
            _storeItemsService = storeItemsService;
            _membersService = membersService;
            _covenantItemsService = covenantItemsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            CovenantViewModel viewModel = new CovenantViewModel();
            viewModel.Memebers = _membersService.GetALLMembers();
            viewModel.StoreItems = _storeItemsService.GetStoreItems();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CovenantViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                CovenantViewModel vM = new CovenantViewModel();
                viewModel.Memebers = _membersService.GetALLMembers();
                viewModel.StoreItems = _storeItemsService.GetStoreItems();
                return View(vM);
            }
            _covenantItemsService.Add(viewModel);
            return RedirectToAction(nameof(Index),nameof(Member));
        }
        public IActionResult ReturnCovenant(int id)
        {
            _covenantItemsService.ReturnCovenant(id);
            return RedirectToAction(nameof(Index), "home");
        }
        public IActionResult Delete(int id , int MemberID)
        {
            bool IsDelete = _covenantItemsService.Delete(id);
            return IsDelete ? RedirectToAction(nameof(Details) , "member" , _membersService.GetById(MemberID)) : BadRequest();
        }
    }
}
