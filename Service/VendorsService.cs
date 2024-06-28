namespace WarehouseProject.Service
{
    public class VendorsService : IVendorsService
    {
        private readonly AppDbContext _context;
        public VendorsService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetVendors()
        {
            return _context.Vendors.Select(x=> new SelectListItem { Value=x.id.ToString() , Text = x.Name})
                .OrderBy(x=>x.Text)
                .ToList();
        }

        public void Add(AddVendorViewModel Model)
        {
            Vendor V = new()
            {
                Name = Model.Name,
                number = Model.number,
            };
            _context.Add(V);
            _context.SaveChanges();
        }

        public IEnumerable<Vendor> GetAll()=>_context.Vendors.AsNoTracking().ToList();

        public Vendor? GetById(int id) => _context.Vendors.Find(id);

        public bool Remove(int id)
        {
            bool isDelete = false;
            var v = GetById(id);
            if (v != null)
            {
                _context.Vendors.Remove(v);
                _context.SaveChanges();
                isDelete = true;
            }
            return isDelete;
        }

        public void Update(EditVendorViewModel vendor)
        {
            Vendor? V  =GetById(vendor.id);
            if(V == null)
            {
                return;
            }
            V.number = vendor.number;
            V.Name = vendor.Name;
            _context.SaveChanges();           
        }

        public EditVendorViewModel EditVendorViewModel(int id)
        {
           Vendor? vendor = GetById(id);
            if(vendor == null) { return null!; }
            EditVendorViewModel V = new()
            {
                Name = vendor.Name,
                number = vendor.number,
            };
            return V;
        }
        public IEnumerable<Vendor> Search(string term) => _context.Vendors.Where(x => x.Name.Contains(term)).OrderBy(x => x.Name).ToList();
    }
}
