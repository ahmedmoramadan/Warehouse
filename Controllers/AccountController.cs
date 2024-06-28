namespace WarehouseProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel ModelUser)
        {
            if (ModelState.IsValid)
            {
                AppUser NEWUser = new AppUser()
                {
                    UserName = ModelUser.UserName,
                    PasswordHash = ModelUser.Password,
                };
                IdentityResult r = await _userManager.CreateAsync(NEWUser, ModelUser.Password);
                if (r.Succeeded)
                {
                    await _userManager.AddToRoleAsync(NEWUser, ModelUser.RN);
                    await _signInManager.SignInAsync(NEWUser, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                else
                {
                    foreach (var item in r.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(ModelUser);
        }
        public IActionResult Login()
        {
            var mv = new LoginViewModel();
            return View(mv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser? user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    bool isValidPassword = await _userManager.CheckPasswordAsync(user, model.password);

                    if (isValidPassword)
                    {
                        await _signInManager.SignInAsync(user, true);
                        return RedirectToAction("Index","home");
                    }
                }
                    ModelState.AddModelError("", "اسم مستخدم خطا او كلمه سرا غير صحيحه"+"\n"+" اذا كنت متاكد من الاسم وكلمه السر اسال المدير ان يختارك ك هيد ");
            }

            return View(model);
        }
        //logout and delete user
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            var lastUser = _userManager.Users.ToList();
            if (lastUser != null)
            {
                foreach (var user in lastUser)
                {
                    if (!(user.UserName == "Warehouse_manager" || user.UserName == "Purchases_Manager" || user.UserName == "TheHeader"))
                    {
                        await _userManager.DeleteAsync(user);
                    }
                }                
            }
            return RedirectToAction(nameof(Login));
        }
        public async Task<IActionResult> LogoutManager()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        
        
}
   
}