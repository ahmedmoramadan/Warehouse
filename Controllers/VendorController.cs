using Microsoft.AspNetCore.Mvc;

namespace WarehouseProject.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorsService _vendorsService;
        public VendorController(IVendorsService vendorsService)
        {
            _vendorsService = vendorsService;
        }
        public IActionResult Index()
        {
            return View(_vendorsService.GetAll());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AddVendorViewModel vendor)
        {
            if(!ModelState.IsValid) 
            { return View(vendor); }
            _vendorsService.Add(vendor);
            return View("successfullyView");
        }
        public IActionResult Edit(int id)
        {
            return View(_vendorsService.EditVendorViewModel(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditVendorViewModel vendor)
        {
            if(!ModelState.IsValid) { return View(vendor); }
            _vendorsService.Update(vendor);
            return View("successfullyView");
        }
        public IActionResult Delete(int id)
        {
            bool isdelete = _vendorsService.Remove(id);
            return isdelete ? View("successfullyView"): BadRequest();
        }
        public IActionResult Search(string term)
        {
            var search = _vendorsService.Search(term);
            return View(nameof(Index), search);
        }
    }
}
