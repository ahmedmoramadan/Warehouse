namespace WarehouseProject.Controllers
{
    public class TenderController : Controller
    {
        private readonly ITendersService _tendersService;
        private readonly IEntitysService _entitysService;
        public TenderController(ITendersService tendersService , IEntitysService entitysService)
        {
            _tendersService = tendersService;
            _entitysService = entitysService;
        }
        public IActionResult Index()
        {
            return View(_tendersService.GetAll());
        }
        public IActionResult DashBoard(int id)
        {
            if (id != 0 )
            {
                var t = _tendersService.GetAll(id);
                return View(t);
            }           
            var AllTender = _tendersService.GetAll();
            return View(AllTender);
        }
        public IActionResult DashBoard2(int id)
        {
            if (id != 0 )
            {
                return View(_tendersService.GetAllCompleted(id));
            }
            var AllTender = _tendersService.GetAllCompleted();
            return View(AllTender);
        }
        public IActionResult EntityName()
        {
            DBViewModel DB = new()
            {
                SelectEntitie = _entitysService.GetEntitys()
            };
            return View(DB);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EntityName(DBViewModel DBModel)
        {
            if (!ModelState.IsValid)
            {
                DBViewModel DB = new()
                {
                    SelectEntitie = _entitysService.GetEntitys(),
                    ID = DBModel.ID
                };
                return View(DB);
            }
            else if (DBModel.ID == 0)
            {
                return RedirectToAction("DashBoard", new { id = DBModel.EntityId });
            }else if (DBModel.ID == 1)
            {
                return RedirectToAction("DashBoard2", new { id = DBModel.EntityId });
            }
            return BadRequest();
        }

        public IActionResult Details(int id)
        {
            var e = _tendersService.GeTById(id);
            return View(e);
        }
        public IActionResult TenderDetails(int id)
        {
            var e = _tendersService.GeTById(id);
            return View(e);
        }
        public IActionResult Tendername()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Tendername(tendernameViewModel name)
        {
            if (ModelState.IsValid)
            {
                var t = _tendersService.getTenderByName(name);
                if (t != null)
                {
                    if (User.IsInRole("Specification_Head"))
                        return RedirectToAction(nameof(Index), nameof(RequiredItem), new { id = t.Id });
                    else if (User.IsInRole("Technical_Head"))
                        return RedirectToAction("ChooseValidItems", nameof(RequiredItem), new { id = t.Id });
                    else if (User.IsInRole("Purchases_Manager"))
                        return RedirectToAction("Add", nameof(Offer), new { id = t.Id });
                    else if (User.IsInRole("Selection_Head"))
                    {
                        return RedirectToAction("index", nameof(Offer), new { id = t.Id });
                    }
                }                
                    ModelState.AddModelError("", "This name not found");
            }
            return View(name);
        }
        [HttpGet]
        public IActionResult CreateTender()
        {
            TenderViewModel model = new()
            {
                SelectEntitie = _entitysService.GetEntitys()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTender(TenderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _tendersService.AddTender(model);
            return RedirectToAction("AddNeededItem", "RequiredItem", new { id = _tendersService.GetLastTender()!.Id });
        }
        public IActionResult Delete()
        {
            bool isDelete= _tendersService.Delete();
            return isDelete ? RedirectToAction("index", "home") : BadRequest();
        }
        public IActionResult Search(string term)
        {
            var search = _tendersService.Search(term);
            return View(nameof(Index), search);
        }

        public IActionResult SearchEndTender(int term ,int id)
        {
            if (id == 0)
            {
                var search = _tendersService.SearchET(term);
                return View(nameof(DashBoard2), search);
            }
            else
            {
                var search = _tendersService.SearchET(term , id);
                return View(nameof(DashBoard2), search);
            }
        }
        public IActionResult SearchNET(int term , int id)
        {
            if (id == 0)
            {
                var search = _tendersService.SearchNET(term);
                return View(nameof(DashBoard), search);
            }
            else
            {
                var search = _tendersService.SearchNET(term,id);
                return View(nameof(DashBoard), search);
            }
        }
    }
}
