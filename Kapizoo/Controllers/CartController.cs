using Kapizoo.Models;
using Kapizoo.Models.Repository;
using Kapizoo.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Kapizoo.Controllers
{
    public class CartController : Controller
    {
        private IZooRepository ZooRepository;
        private Cart cart;

        public CartController(IZooRepository repo, Cart crtServices)
        {
            ZooRepository = repo;
            cart = crtServices;
        }

        public IActionResult Index()
        {
            return View(cart);
        }

        [HttpPost]
        public IActionResult Plus(long capyId)
        {
            var capybara = ZooRepository.Capybaras.Where(c => c.CapybaraID == capyId).FirstOrDefault();
            if (capybara != null)
            {
                cart.AddItem(capybara, 1);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Minus(long capyId)
        {
            var capybara = ZooRepository.Capybaras.Where(c => c.CapybaraID == capyId).FirstOrDefault();
            if (capybara != null)
            {
                cart.RemoveItem(capybara, 1);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(long capyId)
        {
            var capybara = ZooRepository.Capybaras.FirstOrDefault(c => c.CapybaraID == capyId);
            if (capybara != null)
            {
                cart.RemoveLine(capybara);
            }
            return RedirectToAction("Index");
        }
    }
}
