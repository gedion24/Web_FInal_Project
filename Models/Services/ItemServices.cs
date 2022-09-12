using ElectronicsStore.Areas.Identity.Data;

namespace ElectronicsStore.Models.Services
{
    public class ItemServices : IItemServices
    {
        private readonly ElectronicsStoreDataContext _context;
        public ItemServices(ElectronicsStoreDataContext context)
        {
            _context=context;
        }

        public List<Items> Getall()
        {
            var result = _context.item.ToList();
            return result;
        }

        public Items GetById(long id)
        {
            var result = _context.item.Find(id);
           return result;
        }
    }
}
