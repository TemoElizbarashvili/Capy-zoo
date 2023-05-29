using KapyZoo.Business.Services.IServices;
using KapyZoo.DAL.UnitOfWork.Contract;
using KapyZoo.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Kapizoo.Controllers
{
    public class GalleryController : Controller
    {
        private IGalleryPicturesService _galleryPicturesService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GalleryController(IGalleryPicturesService galleryPicturesService, IWebHostEnvironment hostEnvironment)
        {
            _galleryPicturesService = galleryPicturesService;
            _hostEnvironment = hostEnvironment;

        }
        public IActionResult Index()
        {
            List<GalleryPicture> pictureList = _galleryPicturesService.List().ToList();
            return View(pictureList);
        }

        public IActionResult Add()
        {
            return View();
        }

    }
}