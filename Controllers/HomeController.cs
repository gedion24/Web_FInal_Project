using ElectronicsStore.Areas.Identity.Data;
using ElectronicsStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ElectronicsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ElectronicsStoreDataContext ecd;
        public readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(ElectronicsStoreDataContext EDC, IWebHostEnvironment IWE)
        {
            this.ecd = EDC;
            this.webHostEnvironment = IWE;

        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public async Task<IActionResult> Index()
        {
            var result = await ecd.item.ToListAsync();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}