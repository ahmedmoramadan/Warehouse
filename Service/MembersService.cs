namespace WarehouseProject.Service
{
    public class MembersService : IMembersService
    {
        private readonly AppDbContext _context;
        public MembersService(AppDbContext context)
        {
            _context = context;
           
        }
        public IEnumerable<SelectListItem> GetMembers()
        {
            return _context.Members.Where(x => x.Password != null)
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                .AsNoTracking()
                .OrderBy(x => x.Text)
                .ToList();
        }
        public IEnumerable<SelectListItem> GetALLMembers()
        {
            return _context.Members
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                .AsNoTracking()
                .OrderBy(x => x.Text)
                .ToList();
        }
        public IEnumerable<Member> GetMembersHaveCovenent() => _context.Members.Where(_x => _x.CovenantItems.Any()).ToList();
        public Member? GetById(int id) => _context.Members.Include(x => x.CovenantItems).FirstOrDefault(x => x.Id == id);
        public IEnumerable<Member> Search(string term)
        {
            return _context.Members.Include(x=>x.CovenantItems).Where(x => x.Name.Contains(term) && x.CovenantItems.Any()).AsNoTracking().ToList();
        }
        public IEnumerable<Member> SearchAll(string term)=> _context.Members.Where(x => x.Name.Contains(term)).OrderBy(x=>x.Name).ToList();
        public void AddGeneralMember(MemberMainViewModel member)
        {
            Member M1 = new Member()
            {
                Name = member.Name,
                PhoneNumber = member.PhoneNumber,
            };
            _context.Add(M1);
            _context.SaveChanges();
        }
        public void AddMember(MemberViewModel member)
        {
            Member M2 = new Member()
            {
                Name = member.Name,
                PhoneNumber = member.PhoneNumber,
                Password = member.Password,
            };
            _context.Add(M2);
            _context.SaveChanges();
        }
        public IEnumerable<Member> GetAll() => _context.Members.OrderBy(x=>x.Name).ToList();
        public EditMemberGeneralViewModel? GetByID_UseingGeneralViewmodel(int id)
        {
            var m = GetById(id);
            if(m==null) return null;
            EditMemberGeneralViewModel EM = new()
            {
                Id= m.Id,
                Name = m.Name,
                PhoneNumber = m.PhoneNumber,
            };
            return EM;
        }
        public void EditMemberGeneralViewModel(EditMemberGeneralViewModel member)
        {
            var m = GetById(member.Id);
            if(m==null) return;
            m.Name = member.Name;
            m.PhoneNumber = member.PhoneNumber;
            _context.SaveChanges();
        }
        public EditMemberViewModel? GetByID_UseingViewmodel(int id)
        {
            var m = GetById(id);
            if (m == null) return null;
            EditMemberViewModel EM = new()
            {
                Id = m.Id,
                Name = m.Name,
                PhoneNumber = m.PhoneNumber,
                password = m.Password!
            };
            return EM;
        }
        public void EditMemberViewModel(EditMemberViewModel member)
        {
            var m = GetById(member.Id);
            if (m == null) return;
            m.Name = member.Name;
            m.PhoneNumber = member.PhoneNumber;
            m.Password = member.password;
            _context.SaveChanges();
        }
        public bool Remove(int id)
        {
            bool isDelete = false;
            var v = GetById(id);
            if (v != null)
            {
                _context.Remove(v);
                _context.SaveChanges();
                isDelete = true;
            }
            return isDelete;
        }
    }
}
