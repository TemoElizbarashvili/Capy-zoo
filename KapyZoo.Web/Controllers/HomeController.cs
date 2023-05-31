using Kapizoo.Models.ViewModels;
using KapyZoo.Business.Services.IServices;
using KapyZoo.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kapizoo.Controllers
{
    public class HomeController : Controller
    {
        private IZooService _zooService;
        private Cart cart;
        public int PageSize = 6;

        public HomeController(IZooService zooService, Cart crtServices)
        {
            _zooService = zooService;
            cart = crtServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Store(int productPage = 1)
        {
            var viewModelForStore = new StoreViewModel
            {
                Capybaras = _zooService.Capybaras.OrderBy(c => c.CapybaraID).Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new KapyZoo.Web.Models.PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _zooService.Capybaras.Count()
                }
            };
            return View(viewModelForStore);

        }

        [HttpPost]
        public IActionResult Store(long capyId, int currPg)
        {
            Capybara capy = _zooService.Capybaras.FirstOrDefault(c => c.CapybaraID == capyId);
            if (capy != null)
            {
                cart.AddItem(capy, 1);
            }
            string currentPath = HttpContext.Request.Path + HttpContext.Request.QueryString;
            int currPage = currentPath.LastOrDefault();
            return RedirectToAction("Index", "Cart");
        }
    }
}