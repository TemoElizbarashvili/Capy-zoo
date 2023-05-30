using KapyZoo.Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KapyZoo.Web.Controllers
{
    public class GameController : Controller
    {
        private IGalleryPicturesService _galleryPicturesService;

        public GameController(IGalleryPicturesService gps)
        {
            _galleryPicturesService = gps;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Game()
        {
            return View();
        }
    }
}
