namespace WarehouseProject.Service
{
    public class EntitysService : IEntitysService
    {
        private readonly AppDbContext _context;
        public EntitysService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetEntitys()
        {
            return _context.Entities.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                .OrderBy(x => x.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
