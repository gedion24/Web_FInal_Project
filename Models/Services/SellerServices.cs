using ElectronicsStore.Areas.Identity.Data;

namespace ElectronicsStore.Models.Services
{
    public class SellerServices : ISellerService
    {
        private readonly ElectronicsStoreDataContext _context;
        public SellerServices (ElectronicsStoreDataContext context)
        {
            _context = context;
        }

        public void Add(Items item)
        {
            _context.item.Add(item);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            //_context.seller.Remove(GetById(id));
            //_context.SaveChanges();

            throw new NotImplementedException();
        }

        public List<Items> GetAll()
        {
            var result =_context.item.ToList();
            return result;
           // throw new NotImplementedException();
        }

        public Items GetById(long id)
        {
            var result = _context.item.Find(id);
            return result;
            //throw new NotImplementedException();
        }

        public Items Update(Items item)
        {
           // var result= _context.item.Update(item);
           //     _context.SaveChanges();
           // return result;
           throw new NotImplementedException();
        }

        //public void Add(Sellers seller)
        //{
        //    _context.seller.Add(seller);
        //    _context.SaveChanges();
        //}

        //public void Delete(long id)
        //{
        //   _context.seller.Remove(GetById(id));
        //    _context.SaveChanges();
        //}

        //public List<Sellers> GetAll()
        //{
        //    var result = _context.seller.ToList();
        //    return result;

        //    throw new NotImplementedException();
        //}

        //public Sellers GetById(long id)
        //{
        //    var result = _context.seller.Find(id);
        //    return result;
        //}



        //Sellers ISellerService.Update(Sellers seller)
        //{

        //    //var result= _context.item.Update(item);
        //    //_context.SaveChanges();
        //    //return result
        //    throw new NotImplementedException();
        //}
    }
}
