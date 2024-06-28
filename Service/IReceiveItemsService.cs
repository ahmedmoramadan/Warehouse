namespace WarehouseProject.Service
{
    public interface IReceiveItemsService
    {
        bool Delete();
        Receiveprocces? GetLast();
        void AddReceiveProcces(ReceiveProccecViewModel D);
        void AddReceiveItem(ReceiveItemViewModel model);
        IEnumerable<ReceivedItem> GetLastRIs();
        void IsValid(ReceiveItemIsValidViewModel model);
        IEnumerable<ReceivedItem> GETValidItem();
        IEnumerable<ReceivedItem> Search(string term);
    }
    public class ExpiritionProccesService : IExpiritionProccesService
    {
        private readonly AppDbContext _context;
        public ExpiritionProccesService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(ReceiveProccecViewModel D)
        {
            ExpiritionProcces EP = new()
            {
                Createon = D.DateOnly,
            };
            _context.Add(EP);   
            _context.SaveChanges();
        }
    }
    public interface IExpiritionProccesService
    {
        void Add(ReceiveProccecViewModel D);
    }
}
