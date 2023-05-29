using KapyZoo.Business.Services.IServices;
using KapyZoo.DAL.Repositories.IRepository;
using KapyZoo.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Kapizoo.Controllers
{
    public class CartController : Controller
    {
        private IZooService _zooService;
        private Cart cart;

        public CartController(IZooService repo, Cart crtServices)
        {
            _zooService = repo;
            cart = crtServices;
        }

        public IActionResult Index()
        {
            return View(cart);
        }

        [HttpPost]
        public IActionResult Plus(long capyId)
        {
            var capybara = _zooService.Capybaras.Where(c => c.CapybaraID == capyId).FirstOrDefault();
            if (capybara != null)
            {
                cart.AddItem(capybara, 1);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Minus(long capyId)
        {
            var capybara = _zooService.Capybaras.Where(c => c.CapybaraID == capyId).FirstOrDefault();
            if (capybara != null)
            {
                cart.RemoveItem(capybara, 1);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(long capyId)
        {
            var capybara = _zooService.Capybaras.FirstOrDefault(c => c.CapybaraID == capyId);
            if (capybara != null)
            {
                cart.RemoveLine(capybara);
            }
            return RedirectToAction("Index");
        }
    }
}