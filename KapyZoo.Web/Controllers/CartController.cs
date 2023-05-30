using KapyZoo.Business.Services.IServices;
using KapyZoo.DAL.Repositories.IRepository;
using KapyZoo.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Kapizoo.Controllers
{
    public class CartController : Controller
    {
        private IZooService _zooService;
        private IOrderService _orderService;
        private Cart cart;

        public CartController(IZooService repo, Cart crtServices, IOrderService os)
        {
            _zooService = repo;
            _orderService = os;
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

        [HttpGet]
        public IActionResult Summary() => View();

        [HttpPost]
        public IActionResult Summary(Order order)
        {
            if(cart.Lines.Count == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                _orderService.CreateOrder(order);
                _orderService.SaveAsync();
                cart.Clear();
                return RedirectToAction("Completed");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Completed()
        {
            var seed = (int)DateTime.Now.Ticks;
            System.Random random = new System.Random(seed);
            return View(random.Next(1,10000));
        }
        
    }
}