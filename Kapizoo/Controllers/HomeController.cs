using Kapizoo.Models;
using Kapizoo.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kapizoo.Controllers
{
    public class HomeController : Controller
    {
        private IZooRepository ZooRepository;

        public HomeController(IZooRepository zooRepository)
        {
            ZooRepository = zooRepository;
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

        public IActionResult Store()
        {
            IEnumerable<Capybara> capybaras = ZooRepository.Capybaras;
            return View(capybaras);
        }
    }
}