using KapyZoo.Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KapyZoo.Web.Controllers
{
    public class TestController : Controller
    {
        private IGalleryPicturesService _galleryPicturesService;

        public TestController(IGalleryPicturesService gps)
        {
            _galleryPicturesService = gps;
        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}
