namespace ElectronicsStore.Models.Services
{
    public interface ISellerService
    {
        List<Items> GetAll();              
        void Add(Items item);
        Items GetById(long id);
        Items Update(Items item);
        void Delete(long id);
    }
}
