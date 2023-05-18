using Kapizoo.Models;
using Kapizoo.Models.Repository;
using Kapizoo.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;


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
        public IActionResult Plus(string capyJson)
        {
            var capybara = System.Text.Json.JsonSerializer.Deserialize<Capybara>(capyJson);

            //CartLine line = cart.Lines.Where(c => c.Capybara.CapybaraID == capybara.CapybaraID).FirstOrDefault();
            cart.AddItem(capybara, 1);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Minus(string capyJson)
        {
            var capybara = System.Text.Json.JsonSerializer.Deserialize<Capybara>(capyJson);
            //CartLine line = cart.Lines.Where(c => c.Capybara.CapybaraID == capybara.CapybaraID).FirstOrDefault();
            cart.RemoveItem(capybara, 1);
            return RedirectToAction("Index");
        }
       
        [HttpPost]
        public IActionResult Remove(string capyJson)
        {
            var capybara = System.Text.Json.JsonSerializer.Deserialize<Capybara>(capyJson);
            cart.RemoveLine(capybara);

            return RedirectToAction("Index");
        }
    }
}
