using KapyZoo.Business.Services.IServices;
using KapyZoo.Shared.Models;
using Microsoft.AspNetCore.Mvc;


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

        [HttpGet]
        public IActionResult CapybaraUpsert(int capybaraId)
        {
            var objFromDb = _capybarasService.GetById(capybaraId);
            return View(objFromDb);
        }

        [HttpPost]
        public IActionResult CapybaraUpsert(int capybaraId, string name, int age, double price, string description, string gender, IFormFile imgFile)
        {
            var objToWorkWith = _capybarasService.GetById(capybaraId);
            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if (objToWorkWith == null)
            {
                objToWorkWith = new Capybara();
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
                    objToWorkWith.Image = @"\img\galleryPictures\" + fileName_new + extension;
                    objToWorkWith.Name = name;
                    objToWorkWith.Age = age;
                    objToWorkWith.Description = description;
                    objToWorkWith.Gender = gender;
                    objToWorkWith.Price = price;
                    _capybarasService.CreateCapybara(objToWorkWith);
                    _capybarasService.SaveAsync();

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
                var objFromDb = _capybarasService.GetById(capybaraId);
                if (files.Count > 0)
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"img/galleryPictures");
                    var extension = Path.GetExtension(files[0].FileName);

                    //delete old image
                    var oldImagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                    //new upload
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    objToWorkWith.Image = @"\img\galleryPictures\" + fileName_new + extension;
                }
                else
                {
                    objToWorkWith.Image = objFromDb.Image;
                }
                objToWorkWith.Name = name;
                objToWorkWith.Age = age;
                objToWorkWith.Description = description;
                objToWorkWith.Gender = gender;
                objToWorkWith.Price = price;
                _capybarasService.EditCapybara(objToWorkWith);
                _capybarasService.SaveAsync();
            }

            return RedirectToAction("Capybaras");
        }

        public async Task<IActionResult> CapybaraDelete(int capybaraId)
        {
            await _capybarasService.DeleteCapybara(capybaraId);

            return RedirectToAction("Capybaras");
        }

    }
}