namespace WarehouseProject.Service
{
    public interface IOffersService
    {
        void AddOffer(OfferViewModel model);
        void AddReqItemToOffer(int id);
        Offer? LastOffer();
        IEnumerable<Offer> AllOffers();
        IEnumerable<Offer> Lastoffers(int id);
        Offer GetById(int id);
        Offer GetbyId(int id);
        bool Delete();
    }
}
