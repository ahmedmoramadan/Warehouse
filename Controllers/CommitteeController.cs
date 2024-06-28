namespace WarehouseProject.Controllers
{
    public class CommitteeController : Controller
    {
        private readonly IMembersService _membersService;
        private readonly ICommitteesService _committeesService;
        private readonly ITendersService _tendersService;
        private readonly IAccountsService _accountsService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public CommitteeController(IMembersService membersService, ICommitteesService committeesService 
            , ITendersService tendersService , IAccountsService accountsService , UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _membersService = membersService;
            _committeesService = committeesService;
            _tendersService = tendersService;
            _accountsService = accountsService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //id for tender
        public IActionResult LastSPCMembers(int id)
        {
            var SPC = _committeesService.GetSpecifictionCommitteeTenderID(id);
            return View(SPC);
        }
        public IActionResult LastTECMembers(int id)
        {
            var TEC = _committeesService.GetTechnicalCommitteeByTenderId(id);
            return View(TEC);
        } 
        public IActionResult LastSLCMembers(int id)
        {
            var slc = _committeesService.GetBySelectionCommitteeId(id);
            return View(slc);
        }
        public IActionResult LastRCCMembers()
        {
            return View(_committeesService.GetByReciveCommitteeID());
        }
        public IActionResult LastSTCMembers()
        {
            return View(_committeesService.GetBySpecificationTechnicalID());
        }
        public IActionResult LastEXCMembers()
        {
            return View(_committeesService.GetByExpireCommitteeID());
        }
        //id => tender id
        public IActionResult SelectSPCCommitteemembers(int id)
        {
            CommitteeSPCViewModel viewModel = new()
            {
                Memebers = _membersService.GetMembers(),
                TID = id,
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectSPCCommitteemembers(CommitteeSPCViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CommitteeSPCViewModel viewModel = new()
                {
                    Memebers = _membersService.GetMembers(),
                    TID = model.TID,
                };
                return View(viewModel);
            }
            _committeesService.SelectSPCMembers(model);
            return RedirectToAction(nameof(LastSPCMembers), new { id = model.TID });
        }
        public IActionResult EditSPC(int id)
        {
            var C = _committeesService.GetSpecifictionCommitteeTenderID(id);
            if (C == null) return null!;
            EditCommitteeSPCViewModel vimo = new()
            {
                SelectSPCMembers = C.Members.Select(x=>x.MemberId).ToList(),
                id = C.Id,
                TID = id,
                Memebers = _membersService.GetMembers(),
            };
            return View(vimo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSPC(EditCommitteeSPCViewModel model)
        {
            if (!ModelState.IsValid)
            {
                EditCommitteeSPCViewModel vModel = new()
                {
                    //SelectSPCMembers = model.Members.Select(x => x.MemberId).ToList(),
                    Memebers = _membersService.GetMembers(),
                    TID = model.TID,
                    id = model.id
                };
                return View(vModel);
            }
            _committeesService.EditSPC(model);
            return  View("successfullyView");
        }
        public IActionResult EditTEC(int id)
        {
            var C = _committeesService.GetTechnicalCommitteeByTenderId(id);
            if (C == null) return null!;
            EditCommitteeTECViewModel vimo = new()
            {
                SelectTECMembers = C.Members.Select(x => x.MemberId).ToList(),
                id = C.Id,
                TID = id,
                Memebers = _membersService.GetMembers(),
            };
            return View(vimo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTEC(EditCommitteeTECViewModel model)
        {
            if (!ModelState.IsValid)
            {
                EditCommitteeTECViewModel vModel = new()
                {
                    Memebers = _membersService.GetMembers(),
                    TID = model.TID,
                    id = model.id
                };
                return View(vModel);
            }
            _committeesService.EditTEC(model);
            return View("successfullyView");
        }
        public IActionResult EditSLC(int id)
        {
            var C = _committeesService.GetBySelectionCommitteeId(id);
            if (C == null) return null!;
            EditCommitteeSLCViewModel vimo = new()
            {
                SelectSLCMembers = C.Members.Select(x => x.MemberId).ToList(),
                id = C.Id,
                TID = id,
                Memebers = _membersService.GetMembers(),
            };
            return View(vimo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSLC(EditCommitteeSLCViewModel model)
        {
            if (!ModelState.IsValid)
            {
                EditCommitteeSLCViewModel vModel = new()
                {
                    Memebers = _membersService.GetMembers(),
                    TID = model.TID,
                    id = model.id
                };
                return View(vModel);
            }
            _committeesService.EditSLC(model);
            return View("successfullyView");
        }
        public IActionResult SelectTECCommitteemembers(int id)
        {
            CommitteeTECViewModel viewModel = new()
            {
                TID = id,   
                Memebers = _membersService.GetMembers(),
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectTECCommitteemembers(CommitteeTECViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CommitteeTECViewModel viewModel = new()
                {
                    TID = model.TID,
                    Memebers = _membersService.GetMembers(),
                };
                return View(viewModel);
            }
            _committeesService.SelectTECMembers(model);
            return RedirectToAction(nameof(LastTECMembers) , new { id = model.TID });
        }
        public IActionResult SelectSLCCommitteemembers(int id)
        {
            CommitteeSLCViewModel viewModel = new()
            {
                TID = id,
                Memebers = _membersService.GetMembers(),
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectSLCCommitteemembers(CommitteeSLCViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CommitteeSLCViewModel viewModel = new()
                {
                    Memebers = _membersService.GetMembers(),
                };
                return View(viewModel);
            }
            _committeesService.SelectSLCMembers(model);
            return RedirectToAction(nameof(LastSLCMembers) , new { id = model.TID });
        }

        public IActionResult SelectRCCCommitteemembers()
        {
            CommitteeRCCViewModel viewModel = new()
            {
                Memebers = _membersService.GetMembers(),
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectRCCCommitteemembers(CommitteeRCCViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CommitteeRCCViewModel viewModel = new()
                {
                    Memebers = _membersService.GetMembers(),
                };
                _committeesService.SelectRCCmembers(model);
                return View(viewModel);
            }
            _committeesService.SelectRCCmembers(model);
            return RedirectToAction(nameof(LastRCCMembers));
        }

        public IActionResult SelectSTCCommitteemembers()
        {
            CommitteeSTCViewModel viewModel = new()
            {
                Memebers = _membersService.GetALLMembers(),
            };
            if(_committeesService.GetBySpecificationTechnicalID() != null)
            {
                return RedirectToAction("LastSTCMembers");
            }
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectSTCCommitteemembers(CommitteeSTCViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CommitteeSTCViewModel viewModel = new()
                {
                    Memebers = _membersService.GetALLMembers(),
                };
                return View(viewModel);
            }
            _committeesService.SelectSTCMembers(model);
            return RedirectToAction(nameof(LastSTCMembers));
        }

        public IActionResult SelectEXCCommitteemembers()
        {
            CommitteeEXCViewModel viewModel = new()
            {
                Memebers = _membersService.GetMembers(),
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectEXCCommitteemembers(CommitteeEXCViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CommitteeEXCViewModel viewModel = new()
                {
                    Memebers = _membersService.GetMembers(),
                };
                return View(model);
            }
            _committeesService.SelectEXCMembers(model);
            return RedirectToAction(nameof(LastEXCMembers));
        }

        public async Task<IActionResult> ChooseHeadSPCMember(int id ,int tid)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _committeesService.HeadMemberSPC(id,tid);
            await _accountsService.Register1(tid);
            await _accountsService.Logout();
            await _accountsService.LoginManager1();
            return View("successfullyView");
        }
        public async Task<IActionResult> ChooseHeadTECMember(int id , int tid)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _committeesService.HeadMemberTEC(id,tid);
            await _accountsService.Register2(tid);
            await _accountsService.Logout();
            await _accountsService.LoginManager1();
            return View("successfullyView");
        }
        public async Task<IActionResult> ChooseHeadSLCMember(int id ,int tid)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _committeesService.HeadMemberSLC(id, tid);
            await _accountsService.Register3(tid);
            await _accountsService.Logout();
            await _accountsService.LoginManager1();
            return View("successfullyView");
        }
        public async Task<IActionResult> ChooseHeadRCCMember(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _committeesService.HeadMemberRCC(id);
            await _accountsService.Register4();
            await _accountsService.Logout();
            await _accountsService.LoginManager2();
            return View("successfullyView");
        }
        public async Task<IActionResult> ChooseHeadSTCMember(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _committeesService.HeadMemberSTC(id);
            await _accountsService.Register5();
            await _accountsService.Logout();
            await _accountsService.LoginManager2();
            return View("successfullyView");
        }
        public async Task<IActionResult> ChooseHeadEXCMember(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _committeesService.HeadMemberEXC(id);
            await _accountsService.Register6();
            await _accountsService.Logout();
            await _accountsService.LoginManager2();
            return View("successfullyView");
        }
    }
}
