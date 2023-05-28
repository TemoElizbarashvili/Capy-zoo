using Kapizoo.Models;
using Kapizoo.Models.Repository;
using Kapizoo.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Kapizoo.Controllers
{
    public class GalleryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GalleryController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;

        }
        public IActionResult Index()
        {
            List<GalleryPicture> pictureList = _unitOfWork.GalleryPicturesRepository.List().ToList();
            return View(pictureList);
        }

        public IActionResult Add()
        {
            return View();
        }

    }
}
