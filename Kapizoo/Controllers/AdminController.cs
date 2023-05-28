using Kapizoo.Models;
using Kapizoo.Models.Repository;
using Kapizoo.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Kapizoo.Controllers
{
    public class AdminController : Controller
    {
        public IUnitOfWork _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminController(IUnitOfWork db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;

        }

        public IActionResult GalleryPictures() 
        {
            var galleryPicturesList = _db.GalleryPicturesRepository.List().ToList();
            return View(galleryPicturesList);
        }

        [HttpGet]
        public IActionResult GalleryPictureUpsert(int galleryPictureId)
        {
            var galleryPicture = _db.GalleryPicturesRepository.List().Where(gp => gp.GalleryPictureId == galleryPictureId).FirstOrDefault();
            return View(galleryPicture);
        }


        [HttpPost]
        public IActionResult GalleryPictureUpsert(int galleryPictureId, string title, IFormFile pictureFile)
        {
            GalleryPicture galleryPicture = _db.GalleryPicturesRepository.List().Where(gp => gp.GalleryPictureId == galleryPictureId).FirstOrDefault();
            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if(galleryPicture == null)
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
                    _db.GalleryPicturesRepository.CreateGalleryPicture(galleryPicture);
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
                var objFromDb = _db.GalleryPicturesRepository.List().ToList().Where(gp => gp.GalleryPictureId == galleryPicture.GalleryPictureId).FirstOrDefault();
                if(files.Count > 0)
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
                _db.GalleryPicturesRepository.EditGalleryPicture(galleryPicture);
                _db.SaveAsync();
            }

            return RedirectToAction("GalleryPictures");
        }

    }
}
