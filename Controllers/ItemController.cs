﻿using ElectronicsStore.Areas.Identity.Data;
using ElectronicsStore.Models;
using ElectronicsStore.Models.Services;
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
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()

        {

            //if (user == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    ElectronicsStoreUser userid =  _userManager.FindByIdAsync(User).Result;
            //    return View(userid);
            //}


            //var result = await ecd.item.ToListAsync();
            var uid = _userManager.GetUserId(User);
            var result = await ecd.item.Where(x => x.Id == uid).ToListAsync();
           
          //  Sellers s_user = _cs.Seller.Where(x => x.SUsername == se.SUsername && x.SPassword == se.SPassword).SingleOrDefault();
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
        public async Task<IActionResult> Update(Guid id)
        {
            var item = await ecd.item.FirstOrDefaultAsync(x => x.ItemId == id);



            if (item != null)
            {
                var viewModel = new UpdateItemModel();
                 
                viewModel.ItemId = item.ItemId;
                viewModel.ItemImage = item.ItemImage;
                viewModel.ItemStatus = item.ItemStatus;
                viewModel.ItemDescription = item.ItemDescription;
                viewModel.Condition = item.Condition;
                viewModel.Amount = item.Amount;
                viewModel.PricePerItem = item.PricePerItem;
                viewModel.brand = item.brand;

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
                    result.SellerId = model.SellerId;
                  
                    result.ItemId = model.ItemId;
                    result.ItemStatus = model.ItemStatus;
                    result.ItemDescription = model.ItemDescription;
                    result.Condition = model.Condition;
                    result.Amount = model.Amount;
                    result.PricePerItem = model.PricePerItem;
                    result.brand = model.brand;

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

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
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
