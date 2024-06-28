public interface IAlternativeItemsService
{
    void Add(AlternativeItemViewModel model);
    AlternativeItem? GetById(int id);
    IEnumerable<AlternativeItem> GetAcceptedItem(int id);
}

