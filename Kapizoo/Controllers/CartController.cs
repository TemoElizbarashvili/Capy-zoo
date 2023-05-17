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
    }
}
