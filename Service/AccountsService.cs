namespace WarehouseProject.Service
{
    public class AccountsService : IAccountsService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private ICommitteesService _committeesService;
        private readonly IMembersService _membersService;

        public AccountsService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager
            , ICommitteesService committeesService, IMembersService membersService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _committeesService = committeesService;
            _membersService = membersService;
        }

        public async Task Register1(int tid)
        {
            var RC = _committeesService.GetSpecifictionCommitteeTenderID(tid);
            var m = _membersService.GetById(RC.HeadID);
            if (m == null) return;
            AppUser user = new AppUser()
            {
                UserName = m!.Name.Replace(" ", "_"),
                PasswordHash = m.Password
            };
            IdentityResult r = await _userManager.CreateAsync(user, m.Password!);
            if (r.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Specification_Head");
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
        }
        public async Task Register2(int tid)
        {
            var TC = _committeesService.GetTechnicalCommitteeByTenderId(tid);
            var m = _membersService.GetById(TC.HeadID);
            if (m == null) return;
            AppUser user = new AppUser()
            {
                UserName = m!.Name.Replace(" ", "_"),
                PasswordHash = m.Password
            };
            IdentityResult r = await _userManager.CreateAsync(user, m.Password!);
            if (r.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Technical_Head");
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
        }
        public async Task Register3(int tid)
        {
            var SC = _committeesService.GetBySelectionCommitteeId(tid);
            var m = _membersService.GetById(SC.HeadID);
            if (m == null) return;
            AppUser user = new AppUser()
            {
                UserName = m!.Name.Replace(" ", "_"),
                PasswordHash = m.Password
            };
            IdentityResult r = await _userManager.CreateAsync(user, m.Password!);
            if (r.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Selection_Head");
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
        }
        public async Task Register4()
        {
            var RC = _committeesService.GetByReciveCommitteeID();
            var m = _membersService.GetById(RC.HeadID);
            if (m == null) return;
            AppUser user = new AppUser()
            {
                UserName = m!.Name.Replace(" ", "_"),
                PasswordHash = m.Password
            };
            IdentityResult r = await _userManager.CreateAsync(user, m.Password!);
            if (r.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Recive_Head");
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
        }
        public async Task Register5()
        {
            var STC = _committeesService.GetBySpecificationTechnicalID();
            var m = _membersService.GetById(STC.HeadID);
            if (m == null) return;
            AppUser user = new AppUser()
            {
                UserName = m!.Name.Replace(" ", "_"),
                PasswordHash = m.Password
            };
            IdentityResult r = await _userManager.CreateAsync(user, m.Password!);
            if (r.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "SpecificationTechnical_Head");
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
        }
        public async Task Register6()
        {
            var EC = _committeesService.GetByExpireCommitteeID();
            var m = _membersService.GetById(EC.HeadID);
            if (m == null) return;
            AppUser user = new AppUser()
            {
                UserName = m!.Name.Replace(" ", "_"),
                PasswordHash = m.Password
            };
            IdentityResult r = await _userManager.CreateAsync(user, m.Password!);
            if (r.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Expire_Head");
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
        }
        public async Task LoginManager1()
        {
            AppUser? user = await _userManager.FindByNameAsync("Warehouse_manager");
            if (user == null) return;
            bool isvalid = await _userManager.CheckPasswordAsync(user, "Man1000@111");
            if (isvalid)
            {
                await _signInManager.SignInAsync(user, true);
            }
        }
        public async Task LoginManager2()
        {
            AppUser? user = await _userManager.FindByNameAsync("Purchases_Manager");
            if (user == null) return;
            bool isvalid = await _userManager.CheckPasswordAsync(user, "Man2000@111");
            if (isvalid)
            {
                await _signInManager.SignInAsync(user, true);
            }
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

