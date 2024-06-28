namespace WarehouseProject.Service
{
    public interface IAcceptItemsService
    {
        IEnumerable<AlternativeItem> ChooseAcceptItem(int ID , int O); // id 4 requireditem oid 4 offer
        AlternativeItem AcceptItem(int id);
        void Isaccept(ViewModel model);
        //IEnumerable<AlternativeItem> GetAcceptedItems();
    }
    
}

