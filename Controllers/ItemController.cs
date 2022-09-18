using ElectronicsStore.Areas.Identity.Data;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
namespace ElectronicsStore.Controllers
{
    public class ItemController : Controller
    {
        
        public readonly ElectronicsStoreDataContext ecd;
        public readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ElectronicsStoreUser> _userManager;
        public ItemController(ElectronicsStoreDataContext EDC, IWebHostEnvironment IWE, UserManager<ElectronicsStoreUser> userManager)
        {
            this.ecd = EDC;
            this.webHostEnvironment = IWE;
            _userManager = userManager;
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

        public async Task<IActionResult> Create(ItemViewModel itemView, SellerViewModel sellerView, ElectronicsStoreUser electronicsStore )
        {


            //string UninqeFileName = UploadedFile(itemView);
            //itemView.ImageUrl = UninqeFileName;

            var user = await _userManager.GetUserAsync(User);
            string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(itemView.ImageFile.FileName);
                string extension = Path.GetExtension(itemView.ImageFile.FileName);
                itemView.ItemImage = fileName = fileName + DateTime.Now.ToString("yymmsfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Images", fileName);

                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await itemView.ImageFile.CopyToAsync(filestream);
                }





            var item = new Items()
            {

                //  ItemId = long.newLong(),
                ItemId = Guid.NewGuid(),
                SellerId = Guid.NewGuid(),
                Id = user.Id,




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
        public async Task<IActionResult> Update(UpdateItemModel model)
        {
             //var result = await ecd.item.FirstOrDefaultAsync(x => x.ItemId == Id);
            Console.WriteLine("dafdsaaaaaaaaaaaaaaaaaasadf");
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
                return await Task.Run(() => View("Update", result));

            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Update(Guid Id, ItemViewModel itemView)
        {

            var result = await ecd.item.FirstOrDefaultAsync(x => x.ItemId == Id);


            if (result != null)
            {

                string wwwRootPath = webHostEnvironment.WebRootPath;
                var Updatemodel = new UpdateItemModel()
                {

                    SellerId = itemView.SellerId,
                    ItemId = itemView.ItemId,
                    ItemStatus = itemView.ItemStatus,
                    ItemDescription = itemView.ItemDescription,
                    Condition = itemView.Condition,
                    Amount = itemView.Amount,
                    PricePerItem = itemView.PricePerItem,
                    brand = itemView.brand

                };
                if (itemView.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(itemView.ImageFile.FileName);
                    string extension = Path.GetExtension(itemView.ImageFile.FileName);
                    itemView.ItemImage = fileName = fileName + DateTime.Now.ToString("yymmsfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Images", fileName);

                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await itemView.ImageFile.CopyToAsync(filestream);
                    }
                    Updatemodel.ItemImage = itemView.ItemImage;
                }





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

        //private string UploadedFile(ItemViewModel itemView)
        //{
        //    string UninqeFileName = null;
        //    if(itemView.ImageFile != null)
        //    {
        //        string uploadfolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
        //        UninqeFileName = Guid.NewGuid().ToString() + "_" + itemView.ImageFile.FileName;
        //        string filepath= Path.Combine(uploadfolder, UninqeFileName);
        //        using (var filestream = new FileStream(filepath, FileMode.Create))
        //        {
        //            itemView.ImageFile.CopyTo(filestream);
        //        }
        //    }
        //    return UninqeFileName;
        //} 
    }
}
