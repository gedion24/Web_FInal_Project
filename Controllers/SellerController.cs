using ElectronicsStore.Areas.Identity.Data;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicsStore.Controllers
{
    public class SellerController : Controller
    {
        public readonly ElectronicsStoreDataContext ecd;
        public SellerController(ElectronicsStoreDataContext EDC)
        {
            this.ecd = EDC;
           
        }

        //public async Task <IActionResult> Index() 
        //{
        //    var result = await ecd.seller.ToListAsync();
        //    return View (result);
        //}



       
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public async Task <IActionResult> Create(SellerViewModel sellerView)
        //{
        //    var seller = new ElectronicsStoreUser()
        //    {
        //        SellerId = Guid.NewGuid(),
        //        SellerImage=sellerView.SellerImage,
        //        SellerEmail = sellerView.SellerEmail,
        //        SellerPhone = sellerView.SellerPhone,

        //    };
        //   await ecd.AddAsync(seller);
        //    await ecd.SaveChangesAsync();

        //    return RedirectToAction("Index");

        //}

        //[HttpGet]
         
        //public  async Task<IActionResult> Update(Guid id) 
        //{
        //  var result= await ecd.seller.FirstOrDefaultAsync(x =>x.SellerId == id );

        //    if (result != null)
        //    {
        //        var Updatemodel = new UpdateSellerModel()
        //        {
        //            SellerId = result.SellerId,

                    
                    
        //        };
        //        return await Task.Run (()=>View("Update",Updatemodel));
        //    }
           
        //    return RedirectToAction("Index");  
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(UpdateSellerModel model)
        //{
        //    var result= await ecd.seller.FindAsync(model.SellerId);
        //    if(result != null)
        //    {
        //        result.SellerImage = model.SellerImage;
        //        result.SellerEmail = model.SellerEmail;
        //        result.SellerPhone = model.SellerPhone;


        //      await  ecd.SaveChangesAsync();
        //      return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]

        //public async Task<IActionResult> Delete(UpdateSellerModel model)
        //{
        //    var result= await ecd.seller.FindAsync(model.SellerId);
        //    if( result != null)
        //    {
        //        ecd.seller.Remove(result);
        //        await ecd.SaveChangesAsync();

        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");

        //}





    }
}
