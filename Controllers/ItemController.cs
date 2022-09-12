using ElectronicsStore.Areas.Identity.Data;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicsStore.Controllers
{
    public class ItemController : Controller
    {
        public readonly ElectronicsStoreDataContext ecd;
        public readonly IWebHostEnvironment webHostEnvironment;
        public ItemController(ElectronicsStoreDataContext EDC, IWebHostEnvironment IWE)
        {
            this.ecd = EDC;
            this.webHostEnvironment = IWE; 

        }
        public async Task<IActionResult> Index()
        {
            var result = await ecd.item.ToListAsync();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(ItemViewModel itemView, SellerViewModel sellerView,Items item )
        {


            string UninqeFileName = UploadedFile(itemView);
            itemView.ImageUrl = UninqeFileName;


       

            var item = new Items()
            { 
               
              //  ItemId = long.newLong(),
                   ItemId= Guid.NewGuid(),
                   SellerId = Guid.NewGuid(),
                
                ItemImage = itemView.ItemImage,
                ItemStatus = itemView.ItemStatus,
                ItemDescription = itemView.ItemDescription,
                Condition = itemView.Condition,
                Amount = itemView.Amount,
                PricePerItem = itemView.PricePerItem,
                brand =itemView.brand
                

            };
            await ecd.AddAsync(item);
            await ecd.SaveChangesAsync();
             return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<IActionResult> Update(Guid Id)
        {
            var result = await ecd.item.FirstOrDefaultAsync(x => x.ItemId== Id);

            if (result != null)
            { 

                var Updatemodel = new UpdateItemModel()
                {

                    SellerId= result.SellerId,
                    ItemId = result.ItemId,
                    ItemImage = result.ItemImage,
                    ItemStatus = result.ItemStatus,
                    ItemDescription = result.ItemDescription,
                    Condition = result.Condition,
                    Amount = result.Amount,
                    PricePerItem = result.PricePerItem,
                    brand = result.brand

                };
                return await Task.Run(() => View("Update", Updatemodel));
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateItemModel model)
        {
            var result = await ecd.item.FindAsync(model.ItemId);
            if (result != null)
            {
                result.ItemImage = model.ItemImage;
                result.ItemStatus = model.ItemStatus;
                result.ItemDescription = model.ItemDescription;
                result.Condition = model.Condition;
                result.Amount = model.Amount;
                result.PricePerItem = model.PricePerItem;
                result.brand = model.brand;


                await ecd.SaveChangesAsync();
            return RedirectToAction("Index");
            }
           
            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(UpdateItemModel model)
        {
            var result = await ecd.item.FindAsync(model.ItemId);
            if (result != null)
            {
                ecd.item.Remove(result);
                await ecd.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        private string UploadedFile(ItemViewModel itemView)
        {
            string UninqeFileName = null;
            if(itemView.ImageFile != null)
            {
                string uploadfolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                UninqeFileName = Guid.NewGuid().ToString() + "_" + itemView.ImageFile.FileName;
                string filepath= Path.Combine(uploadfolder, UninqeFileName);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    itemView.ImageFile.CopyTo(filestream);
                }
            }
            return UninqeFileName;
        } 
    }
}
