namespace WarehouseProject.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMembersService _membersService;
        public MemberController(IMembersService membersService)
        {
            _membersService = membersService;
        }
        public IActionResult Index()
        {
            return View(_membersService.GetMembersHaveCovenent());
        }
        public IActionResult Member()
        {
            return View(_membersService.GetAll());
        }
        public IActionResult Details(int id)
        {
            return View(_membersService.GetById(id));
        }
        public IActionResult Search(string term)
        {
            var search = _membersService.Search(term);
            return View(nameof(Index), search);
        }
        public IActionResult Search1(string term)
        {
            return View(_membersService.SearchAll(term));
        }
        public IActionResult AddGeneralMember()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddGeneralMember(MemberMainViewModel Model)
        {
            if (!ModelState.IsValid)
            {
                return View(Model);
            }
            _membersService.AddGeneralMember(Model);
            return View("successfullyView");
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(MemberViewModel Model)
        {
            if(!ModelState.IsValid)
            {
                return View(Model);
            }
            _membersService.AddMember(Model);
            return View("successfullyView");
        }

        public IActionResult EditGeneralMember(int id)
        {
            return View(_membersService.GetByID_UseingGeneralViewmodel(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditGeneralMember(EditMemberGeneralViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _membersService.EditMemberGeneralViewModel(model);
            return View("successfullyView");
        }

        public IActionResult EditMember(int id)
        {
            return View(_membersService.GetByID_UseingViewmodel(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMember(EditMemberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _membersService.EditMemberViewModel(model);
            return View("successfullyView");
        }
        public IActionResult Delete(int id)
        {
          bool IsDelete =  _membersService.Remove(id);
            return IsDelete ? View("successfullyView") :BadRequest();
        }

    }
}
