using Microsoft.AspNetCore.Mvc;

namespace Kapizoo.Controllers
{
    public class CapybarasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
