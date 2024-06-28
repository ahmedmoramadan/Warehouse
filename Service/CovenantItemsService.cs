

using System.Collections.Generic;

namespace WarehouseProject.Service
{
    public class CovenantItemsService : ICovenantItemsService
    {
        private readonly AppDbContext _context;
        public CovenantItemsService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(CovenantViewModel m)
        {
            var c = 0;
            var SI = _context.ReceivedItems.Find(m.SelectItem);
            if (SI != null && SI.Quantity >= m.QTY) {
                var ListCI = ListCovenantItems();
                foreach(var i in ListCI)
                {
                    if(i.Name== SI.Name && m.MemberId == i.MemberId && i.Type == SI.Type)
                    {
                        i.Quantity = i.Quantity + m.QTY;
                        SI.Quantity = SI.Quantity - m.QTY;
                      
                        ++c;
                    }
                }
                if (c == 0)
                {
                    CovenantItem ci = new()
                    {
                        Quantity = m.QTY,
                        Name = SI.Name,
                        Type = SI.Type,
                        Description = SI.Description,
                        MemberId = m.MemberId,
                    };
                    _context.Add(ci);
                    SI.Quantity = SI.Quantity - m.QTY;
                  
                }
                _context.SaveChanges();
            }
        }
        public void ReturnCovenant(int id)
        {
            Member? M = _context.Members.Include(x => x.CovenantItems).FirstOrDefault(x=>x.Id==id);
            var RI = _context.ReceivedItems.ToList(); 
            if (M != null)
            {
                foreach(var item in M.CovenantItems)
                {
                    foreach(var i in RI)
                    {
                        if(item.Name == i.Name && item.Type == i.Type && item.Description == i.Description)
                        {
                            int n = item.Quantity;
                            i.Quantity += n;
                            _context.SaveChanges();
                        }
                    }
                    _context.Remove(item);
                    _context.SaveChanges();
                }
            }
        }

        public IEnumerable<CovenantItem> ListCovenantItems()=> _context.covenantItems.ToList();

        public bool Delete(int id)
        {
            bool IsDelete = false;
            var CI = _context.covenantItems.Find(id);
            if (CI != null)
            {
                _context.Remove(CI);
                _context.SaveChanges();
                IsDelete= true;
            }
            return IsDelete;
        }
    }
    
}

