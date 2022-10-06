using ElectronicsStore.Areas.Identity.Data;
using ElectronicsStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Linq;
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
             this. _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()

        {

           
            var uid = _userManager.GetUserId(User);
            
            var result = await ecd.item.Where(x => x.Id == uid).ToListAsync();
           
           
            return View(result);


        }
        //[HttpGet]
        //public async Task<IActionResult> Index(string Search)
        //{

        //    //Search bar
        //    ViewData["CurrentSearch"] = Search;

        //    var brand = from b in ecd.item select b;
        //    if (!String.IsNullOrEmpty(Search))
        //    {
        //        brand = brand.Where(b => b.brand.Contains(Search));
        //    }
        //    return View(brand.ToList());
        //}

        [HttpGet]   
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(ItemViewModel itemView, ElectronicsStoreUser electronicsStore )
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
              //  SellerId = Guid.NewGuid(),
                Id = user.Id,




                ItemImage = itemView.ItemImage,
                ItemName = itemView.ItemName,
                ItemStatus = itemView.ItemStatus,
                ItemDescription = itemView.ItemDescription,
                Condition = itemView.Condition,
                Amount = itemView.Amount,
                PricePerItem = itemView.PricePerItem,
                brand =itemView.brand,
                SellerEmail= itemView.SellerEmail,
                SellerPhonenumber= itemView.SellerPhonenumber,
               
                

            };
            await ecd.AddAsync(item);
            await ecd.SaveChangesAsync();
             return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var item = await ecd.item.FirstOrDefaultAsync(x => x.ItemId == id);



            if (item != null)
            {
                var viewModel = new UpdateItemModel();
                 
                viewModel.ItemId = item.ItemId;
                viewModel.ItemImage = item.ItemImage;
                viewModel.ItemName = item.ItemName;
                viewModel.ItemStatus = item.ItemStatus;
                viewModel.ItemDescription = item.ItemDescription;
                viewModel.Condition = item.Condition;
                viewModel.Amount = item.Amount;
                viewModel.PricePerItem = item.PricePerItem;
                viewModel.brand = item.brand;
                viewModel.SellerEmail = item.SellerEmail;
                viewModel.SellerPhonenumber = item.SellerPhonenumber;

                return  await Task.Run(()=>View(viewModel));
            }
            return RedirectToAction("Index");
        }


        [HttpPost]

        public async Task<IActionResult> Update( UpdateItemModel model)
        {
            var result = await ecd.item.FindAsync(model.ItemId);
            if (result != null)
            {

                string wwwRootPath = webHostEnvironment.WebRootPath;
                
                {
                    
                  
                    result.ItemId = model.ItemId;
                    result.ItemName = model.ItemName;
                    result.ItemStatus = model.ItemStatus;
                    result.ItemDescription = model.ItemDescription;
                    result.Condition = model.Condition;
                    result.Amount = model.Amount;
                    result.PricePerItem = model.PricePerItem;
                    result.brand = model.brand;
                    result.SellerEmail = model.SellerEmail;
                    result.SellerPhonenumber = model.SellerPhonenumber;

                };
                if (model.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    model.ItemImage = fileName = fileName + DateTime.Now.ToString("yymmsfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Images", fileName);

                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(filestream);
                    }
                    
                    result.ItemImage = model.ItemImage;

                    await ecd.SaveChangesAsync();
                }
                await ecd.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");



        }

      

        [HttpPost]

        public async Task<IActionResult> Delete(Guid id)
            
        {
            var result = await ecd.item.FindAsync(id);
            if (result != null)
            {

                ecd.item.Remove(result);
                await ecd.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

       

    }
}
