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

        //[HttpPost]
        //public IActionResult Add(GalleryPicture galleryPicture)
        //{
        //    string webRootPath = _hostEnvironment.WebRootPath;
        //    var files = HttpContext.Request.Form.Files;

        //    if(files.Count > 0)
        //    {
        //        string fileName_new = Guid.NewGuid().ToString();
        //        var uploads = Path.Combine(webRootPath, @"img/galleryPictures");
        //        var extension = Path.GetExtension(files[0].FileName);

        //        using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
        //        {
        //            files[0].CopyTo(fileStream);
        //        }
        //        galleryPicture.Picture = @"\img\galleryPictures\" + fileName_new + extension;
        //        _unitOfWork.GalleryPicturesRepository.CreateGalleryPicture(galleryPicture);
        //    }
        //    else
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View();
        //        }
        //    }
          
        //    return RedirectToAction("Index");
        //}

    }
}
