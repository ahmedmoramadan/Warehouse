

namespace WarehouseProject.Service
{
    public class TendersService : ITendersService
    {
        private readonly AppDbContext _context;
        public TendersService(AppDbContext context)
        {
            _context = context;
        }
        public void AddTender(TenderViewModel tender)
        {
            Tender T = new()
            {
                Name = tender.Title,
                DateOnly = tender.DateOnly,
                Description = tender.Description,
                EntityId = tender.EntityId,
                Finitished = false,
            };
            _context.Add(T);
            _context.SaveChanges();
        }
        public bool Delete()
        {
            Tender? T = GetLastTender();
            bool isDelete = false;
            if (T != null)
            {
                _context.Remove(T);
                _context.SaveChanges();
                isDelete = true;
            }
            return isDelete;
        }
        public Tender? GetLastTender() => _context.Tenders.OrderBy(x => x.Id).LastOrDefault();
        public Tender? GeTById(int id) => _context.Tenders.Include(x=>x.Entity).Include(x=>x.RequiredItems).ThenInclude(x=>x.alternativeItems)
            .Include(x=>x.selectionCommittee).ThenInclude(x=>x!.Members).ThenInclude(x=>x.Member)
            .Include(x=>x.SpecifictionCommittee).ThenInclude(x => x!.Members).ThenInclude(x => x.Member)
            .Include(x=>x.TechnicalCommittee).ThenInclude(x => x!.Members).ThenInclude(x => x.Member)
            .FirstOrDefault(x=>x.Id == id);
        public IEnumerable<Tender> GetAll() => _context.Tenders
            .Include(x=>x.Entity)
            .Include(x=>x.RequiredItems)
            .Include(x=>x.TechnicalCommittee).ThenInclude(M=>M!.Members)
            .Include(x=>x.SpecifictionCommittee).ThenInclude(M => M!.Members)
            .Include(x=>x.selectionCommittee).ThenInclude(M => M!.Members)
            .ToList();
        public IEnumerable<Tender> GetAll(int id) => _context.Tenders.Where(x=>x.EntityId==id)
           .Include(x => x.Entity)
           .Include(x => x.RequiredItems)
           .Include(x => x.TechnicalCommittee).ThenInclude(M => M!.Members)
           .Include(x => x.SpecifictionCommittee).ThenInclude(M => M!.Members)
           .Include(x => x.selectionCommittee).ThenInclude(M => M!.Members)
           .ToList();
        public IEnumerable<Tender> GetAllCompleted()=>_context.Tenders.Where(x=>x.Finitished)
            .Include(x=>x.Entity)
            .Include(x=>x.RequiredItems)
            .Include(x=>x.TechnicalCommittee).ThenInclude(M=>M!.Members)
            .Include(x=>x.SpecifictionCommittee).ThenInclude(M => M!.Members)
            .Include(x=>x.selectionCommittee).ThenInclude(M => M!.Members)
            .ToList();
        public IEnumerable<Tender> GetAllCompleted(int id) => _context.Tenders.Where(x => x.Finitished && x.EntityId==id)
            .Include(x => x.Entity)
            .Include(x => x.RequiredItems)
            .Include(x => x.TechnicalCommittee).ThenInclude(M => M!.Members)
            .Include(x => x.SpecifictionCommittee).ThenInclude(M => M!.Members)
            .Include(x => x.selectionCommittee).ThenInclude(M => M!.Members)
            .ToList();

        public bool SPCMemberinlasttender()
        {
            bool isMember = false;
            Tender? tender = GetLastTender();
            SpecifictionCommittee? sp = _context.SpecifictionCommittees.OrderBy(x => x.Id).LastOrDefault();
            if (tender != null)
            {
                if (sp == null) return false;
                if (sp.TenderId == tender.Id) return true;
            }
            return isMember;
        }
        public bool TECMemberinlasttender()
        {
            bool isMember = false;
            Tender? tender = GetLastTender();
            TechnicalCommittee? TC = _context.TechnicalCommittees.OrderBy(x => x.Id).LastOrDefault();
            if (tender != null)
            {
                if (TC == null) return false;
                if (TC.TenderId == tender.Id) return true;
            }
            return isMember;
        }
        public bool SLCMemberinlasttender()
        {
            bool isMember = false;
            Tender? tender = GetLastTender();
            SelectionCommittee? sl = _context.SelectionCommittees.OrderBy(x => x.Id).LastOrDefault();
            if (tender != null)
            {
                if (sl == null) return false;
                if (sl.TenderId == tender.Id) return true;
            }
            return isMember;
        }
        public bool RCCMemberinlasttender() // not complete
        {
            throw new NotImplementedException();
        }
        public bool STCMemberinlasttender() // not complete
        {
            throw new NotImplementedException();
        }
        public bool EXCMemberinlasttender()
        {
            bool isMember = false;
            Tender? tender = GetLastTender();
            ExpireCommittee? EX = _context.expireCommittees.OrderBy(x => x.Id).LastOrDefault();
            if (tender != null)
            {
                if (EX == null) return false;
                //if (EX.TenderId == tender.Id) return true;
            }
            return isMember;
        } //not done
        public IEnumerable<Tender> Search(string term) => _context.Tenders.Where(x => x.Name.Contains(term)).OrderBy(x => x.Name).ToList();
        public Tender? getTenderByName(tendernameViewModel name)
        {
           Tender? t = _context.Tenders.FirstOrDefault(x => x.Name == name.TenderName);
            if (t == null) return null;
            return t;
        }
        public IEnumerable<Tender> SearchET(int term) => _context.Tenders.Where(x => x.DateFinitished != null && x.DateOnly.Year == term).Include(x => x.Entity)
            .Include(x => x.RequiredItems)
            .Include(x => x.TechnicalCommittee).ThenInclude(M => M!.Members)
            .Include(x => x.SpecifictionCommittee).ThenInclude(M => M!.Members)
            .Include(x => x.selectionCommittee).ThenInclude(M => M!.Members)
            .ToList();
        public IEnumerable<Tender> SearchET(int term ,int id) => _context.Tenders
            .Where(x => x.DateFinitished != null && x.DateOnly.Year == term && x.EntityId==id)
            .Include(x => x.Entity)
           .Include(x => x.RequiredItems)
           .Include(x => x.TechnicalCommittee).ThenInclude(M => M!.Members)
           .Include(x => x.SpecifictionCommittee).ThenInclude(M => M!.Members)
           .Include(x => x.selectionCommittee).ThenInclude(M => M!.Members)
           .ToList();

        public IEnumerable<Tender> SearchNET(int term) => _context.Tenders.Where(x => x.DateFinitished == null && x.DateOnly.Year == term).Include(x => x.Entity)
        .Include(x => x.RequiredItems)
        .Include(x => x.TechnicalCommittee).ThenInclude(M => M!.Members)
        .Include(x => x.SpecifictionCommittee).ThenInclude(M => M!.Members)
        .Include(x => x.selectionCommittee).ThenInclude(M => M!.Members)
        .ToList();
        public IEnumerable<Tender> SearchNET(int term , int id) => _context.Tenders
            .Where(x => x.DateFinitished == null && x.DateOnly.Year == term &&x.EntityId==id)
            .Include(x => x.Entity)
       .Include(x => x.RequiredItems)
       .Include(x => x.TechnicalCommittee).ThenInclude(M => M!.Members)
       .Include(x => x.SpecifictionCommittee).ThenInclude(M => M!.Members)
       .Include(x => x.selectionCommittee).ThenInclude(M => M!.Members)
       .ToList();
        public Tender? GetTenderByRequiredItemId(int id)
        {
            RequiredItem? RI = _context.RequiredItems.FirstOrDefault(x => x.Id == id);
            if (RI == null) return null;
            return _context.Tenders.FirstOrDefault(x => x.Id == RI.TenderId);
        }

        public IEnumerable<Tender> GetTendersByEntityId(int id) =>_context.Tenders.Where(x => x.DateFinitished == null && x.EntityId==id).Include(x => x.Entity)
        .Include(x => x.RequiredItems)
        .Include(x => x.TechnicalCommittee).ThenInclude(M => M!.Members)
        .Include(x => x.SpecifictionCommittee).ThenInclude(M => M!.Members)
        .Include(x => x.selectionCommittee).ThenInclude(M => M!.Members)
        .ToList();
        public IEnumerable<Tender> GetFinishedTendersByEntityId(int id) => _context.Tenders.Where(x => x.DateFinitished != null && x.EntityId == id).Include(x => x.Entity)
           .Include(x => x.RequiredItems)
           .Include(x => x.TechnicalCommittee).ThenInclude(M => M!.Members)
           .Include(x => x.SpecifictionCommittee).ThenInclude(M => M!.Members)
           .Include(x => x.selectionCommittee).ThenInclude(M => M!.Members)
           .ToList();
    }
}
