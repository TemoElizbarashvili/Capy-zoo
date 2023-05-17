using Kapizoo.Models;
using Kapizoo.Models.Repository.IRepository;
using Kapizoo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kapizoo.Controllers
{
    public class HomeController : Controller
    {
        private IZooRepository ZooRepository;
        private Cart cart;

        public HomeController(IZooRepository zooRepository, Cart crtServices)
        {
            ZooRepository = zooRepository;
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
            List<Capybara> capybaras = ZooRepository.Capybaras.ToList();
            ViewData["Capybaras"] = capybaras;
            return View(cart);
          
        }

        [HttpPost]
        public IActionResult Store(long capyId)
        {
            Capybara capy = ZooRepository.Capybaras.FirstOrDefault(c => c.CapybaraID == capyId);
            if(capy != null)
            {
                cart.AddItem(capy, 1);
            }
            return Ok();
        }

    }
}