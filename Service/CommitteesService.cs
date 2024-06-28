namespace WarehouseProject.Service
{
    public class CommitteesService : ICommitteesService
    {
        private readonly AppDbContext _context;
        private readonly ITendersService _tendersService;
        public CommitteesService(AppDbContext context, ITendersService tendersService)
        {
            _context = context;
            _tendersService = tendersService;
        }
        public void SelectSPCMembers(CommitteeSPCViewModel model)
        {
            SpecifictionCommittee SPC = new()
            {
                TenderId = model.TID,
                Members = model.SelectSPCMembers.Select(x => new SpecifictionCommitteeMember { MemberId = x }).ToList(),
            };
            _context.Add(SPC);
            _context.SaveChanges();
        }
        public void SelectTECMembers(CommitteeTECViewModel model)
        {
            TechnicalCommittee Technical = new()
            {
                TenderId = model.TID,
                Members = model.SelectTECMembers.Select(x => new TechnicalCommitteeMember { MemberId = x }).ToList()
            };
            _context.Add(Technical);
            _context.SaveChanges();
        }
        public void SelectSLCMembers(CommitteeSLCViewModel model)
        {
            SelectionCommittee SLC = new()
            {
                TenderId = model.TID,
                Members = model.SelectSLCMembers.Select(x => new SelectionCommitteeMember { MemberId = x }).ToList()
            };
            _context.Add(SLC);
            _context.SaveChanges();
        }
        public void SelectRCCmembers(CommitteeRCCViewModel model)
        {
            var LT = _context.ReceiveProcces.OrderBy(x => x.Id).LastOrDefault();
            if (LT == null) return;
            ReciveCommittee RCC = new()
            {
                ReceiveproccesID = LT.Id,
                Members = model.SelectRCCMembers.Select(x => new ReciveCommitteeMember { MemberId = x }).ToList()
            };
            _context.Add(RCC);
            _context.SaveChanges();
        }
        public void SelectSTCMembers(CommitteeSTCViewModel model)
        {
            var LT = _context.ReceiveProcces.OrderBy(x => x.Id).LastOrDefault();
            if (LT == null) return;
            SpecifictionTechnicalCommittee SPT = new()
            {
                ReceiveproccesId = LT.Id,
                Members = model.SelectSTCMembers.Select(x => new SpecifictionTechnicalCommitteeMember { MemberId = x }).ToList(),
            };
            _context.Add(SPT);
            _context.SaveChanges();
        }
        public void SelectEXCMembers(CommitteeEXCViewModel model)
        {
            var c = _context.ExpiritionProcces.OrderBy(x=>x.Id).LastOrDefault();
            ExpireCommittee EXC = new()
            {
               ExpiritionProccesID = c!.Id,
                Members = model.SelectEXCMembers.Select(x => new ExpireCommitteeMember { MemberId = x }).ToList()
                // HeadID = model.SelectEXCMembers.Select(x=> new  ExpireCommitteeMember { MemberId =x}).FirstOrDefault()!.MemberId
            };
            _context.Add(EXC);
            _context.SaveChanges();
        }
        public SpecifictionCommittee GetSpecifictionCommitteeTenderID(int id)
        {
            SpecifictionCommittee? S = _context.SpecifictionCommittees.Include(x => x.Members)
                .ThenInclude(x => x.Member)
                .FirstOrDefault(x => x.TenderId == id);
            if (S == null)
                return null!;
            return S;
        }
        public TechnicalCommittee GetTechnicalCommitteeByTenderId(int id)
        {
            TechnicalCommittee? t = _context.TechnicalCommittees.Include(x => x.Members)
                .ThenInclude(x => x.Member)
                .FirstOrDefault(x => x.TenderId == id);
            if (t == null)
                return null!;
            return t;
        }
        public SelectionCommittee GetBySelectionCommitteeId(int id)
        {
            SelectionCommittee? S = _context.SelectionCommittees.Include(x => x.Members)
                .ThenInclude(x => x.Member)
                .FirstOrDefault(x => x.TenderId == id);
            if (S == null)
                return null!;
            return S;
        }
        public ReciveCommittee GetByReciveCommitteeID()
        {
            Receiveprocces? T = _context.ReceiveProcces.OrderBy(x => x.Id).LastOrDefault();
            if (T == null)
                return null!;
            ReciveCommittee? R = _context.reciveCommittees.Include(x => x.Members).ThenInclude(x => x.Member).OrderBy(x => x.Id).Where(x => x.ReceiveproccesID == T.Id).LastOrDefault();
            if (R == null)
                return null!;
            return R;
        }
        public SpecifictionTechnicalCommittee GetBySpecificationTechnicalID()
        {
            Receiveprocces? T = _context.ReceiveProcces.OrderBy(x => x.Id).LastOrDefault();
            if (T == null)
                return null!;
            SpecifictionTechnicalCommittee? ST = _context.specifictionTechnicalCommittees.Include(x => x.Members).ThenInclude(x => x.Member).OrderBy(x => x.Id).Where(x => x.ReceiveproccesId == T.Id).LastOrDefault();
            if (ST == null)
                return null!;
            return ST;
        }
        public ExpireCommittee GetByExpireCommitteeID()
        {
           ExpiritionProcces? T = _context.ExpiritionProcces.OrderBy(x=>x.Id).LastOrDefault();
            if (T == null)
                return null!;
            ExpireCommittee? E = _context.expireCommittees.Include(x => x.Members).ThenInclude(x => x.Member).OrderBy(x => x.Id).Where(x=>x.ExpiritionProccesID==T.Id).LastOrDefault();
            if (E == null)
                return null!;
            return E;
        }
        public void HeadMemberSPC(int id, int tid)
        {
            SpecifictionCommittee? SPC = _context.SpecifictionCommittees.FirstOrDefault(x => x.TenderId == tid);
            if (SPC == null) return;
            SPC.HeadID = id;
            _context.SaveChanges();
        }
        public void HeadMemberTEC(int id, int tid)
        {
            TechnicalCommittee? TEC = _context.TechnicalCommittees.FirstOrDefault(x => x.TenderId == tid);
            if (TEC == null) return;
            TEC.HeadID = id;
            _context.SaveChanges();
        }
        public void HeadMemberSLC(int id, int tid)
        {
            SelectionCommittee? SLC = _context.SelectionCommittees.FirstOrDefault(x => x.TenderId == tid);
            if (SLC == null) return;
            SLC.HeadID = id;
            _context.SaveChanges();
        }
        public void HeadMemberRCC(int id)
        {
            ReciveCommittee? RCC = _context.reciveCommittees.OrderBy(x => x.Id).LastOrDefault();
            if (RCC == null) return;
            RCC.HeadID = id;
            _context.SaveChanges();
        }
        public void HeadMemberSTC(int id)
        {
            SpecifictionTechnicalCommittee? STC = _context.specifictionTechnicalCommittees.OrderBy(x => x.Id).LastOrDefault();
            if (STC == null) return;
            STC.HeadID = id;
            _context.SaveChanges();
        }
        public void HeadMemberEXC(int id)
        {
            ExpireCommittee? EXC = _context.expireCommittees.OrderBy(x => x.Id).LastOrDefault();
            if (EXC == null) return;
            EXC.HeadID = id;
            _context.SaveChanges();
        }

        public SpecifictionCommittee EditSPC(EditCommitteeSPCViewModel model)
        {
            var c = GetSpecifictionCommitteeTenderID(model.TID);
            if (c == null) return null!;
            c.Members = model.SelectSPCMembers.Select(x => new SpecifictionCommitteeMember { MemberId = x }).ToList();
            _context.SaveChanges();
            return c;
        }
        public TechnicalCommittee EditTEC(EditCommitteeTECViewModel model)
        {
            var c = GetTechnicalCommitteeByTenderId(model.TID);
            if (c == null) return null!;
            c.Members = model.SelectTECMembers.Select(x => new TechnicalCommitteeMember { MemberId = x }).ToList();
            _context.SaveChanges();
            return c;
        }
        public SelectionCommittee EditSLC(EditCommitteeSLCViewModel model)
        {
            var c = GetBySelectionCommitteeId(model.TID);
            if (c == null) return null!;
            c.Members = model.SelectSLCMembers.Select(x => new SelectionCommitteeMember { MemberId = x }).ToList();
            _context.SaveChanges();
            return c;
        }

       
    }
}
