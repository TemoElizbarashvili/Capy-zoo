using KapyZoo.Business.Services;
using KapyZoo.Business.Services.IServices;
using KapyZoo.DAL.Repositories.IRepository;
using KapyZoo.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kapizoo.Controllers
{
    public class HomeController : Controller
    {
        private IZooService _zooService;
        private Cart cart;

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
        public ViewResult Store()
        {
            List<Capybara> capybaras = _zooService.Capybaras.ToList();
            ViewData["Capybaras"] = capybaras;
            return View(cart);

        }

        [HttpPost]
        public IActionResult Store(long capyId)
        {
            Capybara capy = _zooService.Capybaras.FirstOrDefault(c => c.CapybaraID == capyId);
            if (capy != null)
            {
                cart.AddItem(capy, 1);
            }
            List<Capybara> capybaras = _zooService.Capybaras.ToList();
            ViewData["Capybaras"] = capybaras;
            return View(cart);
        }

    }
}