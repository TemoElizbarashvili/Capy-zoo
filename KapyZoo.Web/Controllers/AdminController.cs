using KapyZoo.Business.Services;
using KapyZoo.Business.Services.IServices;
using KapyZoo.DAL.UnitOfWork.Contract;
using KapyZoo.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Kapizoo.Controllers
{
    public class AdminController : Controller
    {
        private ICapybaraService _capybarasService;
        private IGalleryPicturesService _galleryPicturesService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminController(ICapybaraService cs, IGalleryPicturesService gps, IWebHostEnvironment hostEnvironment)
        {
            _capybarasService = cs;
            _galleryPicturesService = gps;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult GalleryPictures()
        {
            var galleryPicturesList = _galleryPicturesService.List().ToList();
            return View(galleryPicturesList);
        }

        [HttpGet]
        public IActionResult GalleryPictureUpsert(int galleryPictureId)
        {
            var galleryPicture = _galleryPicturesService.List().Where(gp => gp.GalleryPictureId == galleryPictureId).FirstOrDefault();
            return View(galleryPicture);
        }


        [HttpPost]
        public IActionResult GalleryPictureUpsert(int galleryPictureId, string title, IFormFile pictureFile)
        {
            GalleryPicture galleryPicture = _galleryPicturesService.List().Where(gp => gp.GalleryPictureId == galleryPictureId).FirstOrDefault();
            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if (galleryPicture == null)
            {
                galleryPicture = new GalleryPicture();
                //create
                if (files.Count > 0)
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"img/galleryPictures");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    galleryPicture.Picture = @"\img\galleryPictures\" + fileName_new + extension;
                    galleryPicture.Title = title;
                    _galleryPicturesService.CreateGalleryPicture(galleryPicture);
                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        return View();
                    }
                }
            }
            else
            {
                //update
                var objFromDb = _galleryPicturesService.List().ToList().Where(gp => gp.GalleryPictureId == galleryPicture.GalleryPictureId).FirstOrDefault();
                if (files.Count > 0)
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"img/galleryPictures");
                    var extension = Path.GetExtension(files[0].FileName);

                    //delete old image
                    var oldImagePath = Path.Combine(webRootPath, objFromDb.Picture.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                    //new upload
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    galleryPicture.Picture = @"\img\galleryPictures\" + fileName_new + extension;
                }
                else
                {
                    galleryPicture.Picture = objFromDb.Picture;
                }
                galleryPicture.Title = title;
                _galleryPicturesService.EditGalleryPicture(galleryPicture);
                _galleryPicturesService.SaveAsync();
            }

            return RedirectToAction("GalleryPictures");
        }

        public async Task<IActionResult> GalleryPictureDelete(int galleryPictureId)
        {
            await _galleryPicturesService.DeleteGalleryPicture(galleryPictureId);
            return RedirectToAction("GalleryPictures");
        }

        [HttpGet]
        public IActionResult Capybaras()
        {
            var capybarasList = _capybarasService.List().ToList();
            return View(capybarasList);
        }

    }
}