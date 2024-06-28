namespace WarehouseProject.Controllers
{
    public class RequiredItemController : Controller
    {
       private readonly IRequireditemsService _requireditemsService;
        public RequiredItemController(IRequireditemsService requireditemsService)
        {
            _requireditemsService = requireditemsService;
        }
        //id=> tenderid
        public IActionResult Index(int id)
        {
            return View(_requireditemsService.GetRequiredItemsByTenderId(id));
        }
        public IActionResult AddNeededItem(int id)
        {
            RequiredItemViewModel model = new()
            {
                TID = id,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNeededItem(RequiredItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
             _requireditemsService.AddNeededItem(model);
            return RedirectToAction("AddNeededItem");
        }
     //   [Authorize(Roles = "Specification_Head")]
        public IActionResult Edit(int id,int Tid)//tid=>tenderid
        {
            var Item = _requireditemsService.GetById(id);
            if (Item == null)
                return BadRequest();
            SpecificationNeededItemViewModel p = new SpecificationNeededItemViewModel();
            p.id = Item.Id;
            p.Description = Item.Description!;
            p.Type = Item.Type!;
            p.TId = Tid;
            p.Name = Item.Name;
            p.InitialPrice = Item.InitialPrice;
            return View(p);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
     //   [Authorize(Roles = "Specification_Head")]
        public IActionResult Edit(SpecificationNeededItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var n = _requireditemsService.Edit(model);
            if (n == null)
                return BadRequest();
            //to go back for needed item and add sp.... and price for ather item
            return RedirectToAction(nameof(Index) , new {id=model.TId});
        }

        #region
        //  [Authorize(Roles = "Technical_Head")]
        //public IActionResult ChooseValidItem(int id,int tid)
        //{
        //    return View(_requireditemsService.GetRequiredItemsByTenderId(tid));
        //}
        //  [Authorize(Roles = "Technical_Head")]
        //public IActionResult EditValidation(int id)
        //{
        //    var item = _requireditemsService.GetById(id);
        //    if(item == null)
        //        return NotFound();
        //    if(item.IsValid == true)
        //        return Content("This item is alredy added");
        //    _requireditemsService.EditValidation(id);
        //    return View("ValidItems" , _requireditemsService.GetLastValidItems(id));
        //}
        #endregion

        // [Authorize(Roles = "Technical_Head , Warehouse_manager")]
        public IActionResult ValidItems(int id)
        {
            IEnumerable<RequiredItem>? List = _requireditemsService.GetLastValidItems(id);
            return View(List);

        }
        public IActionResult TheValidItems(int id)
        {
            IEnumerable<RequiredItem>? List = _requireditemsService.GetLastValidItems(id);
            return View(List);
        }

        //   [Authorize(Roles = "Technical_Head")]
        public IActionResult ChooseValidItems(int id)//id=>tenderid
        {
            var CVM = new ChooseValidTViewModel();
            CVM.CheckValid = _requireditemsService.GetRequiredItemsByTenderId(id)!;    
            CVM.Tid = id;
            return View(CVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Technical_Head")]
        public IActionResult ChooseValidItems(ChooseValidTViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var CVM = new ChooseValidTViewModel();
                CVM.CheckValid = _requireditemsService.GetRequiredItemsByTenderId(model.Tid)!;
                return View(CVM);
            }
            _requireditemsService.Isvalid(model);
            return RedirectToAction(nameof(ValidItems),new {id=model.Tid});
        }

    }
}
