﻿using KapyZoo.Business.Services.IServices;
using KapyZoo.Shared.Models;
using KapyZoo.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Kapizoo.Controllers
{
    [Authorize(Roles = $"{RD.AdminRole}")]
    public class AdminController : Controller
    {
        private ICapybaraService _capybarasService;
        private IGalleryPicturesService _galleryPicturesService;
        private IOrderService _orderService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminController(ICapybaraService cs, IGalleryPicturesService gps, IWebHostEnvironment hostEnvironment, IOrderService os)
        {
            _capybarasService = cs;
            _galleryPicturesService = gps;
            _orderService = os;
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
            var objFromDb = await _galleryPicturesService.GetByIdAsync(galleryPictureId);
            string fileName_new = Guid.NewGuid().ToString();
            string webRootPath = _hostEnvironment.WebRootPath;
            var uploads = Path.Combine(webRootPath, @"img/galleryPictures");

            //delete image from files
            var oldImagePath = Path.Combine(webRootPath, objFromDb.Picture.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

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
                    var uploads = Path.Combine(webRootPath, @"img/Capybara");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    objToWorkWith.Image = @"\img\Capybara\" + fileName_new + extension;
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
                    var uploads = Path.Combine(webRootPath, @"img/Capybara");
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
                    objToWorkWith.Image = @"\img\Capybara\" + fileName_new + extension;
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
            var objToWorkWith = _capybarasService.GetById(capybaraId);
            string webRootPath = _hostEnvironment.WebRootPath;
            string fileName_new = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, @"img/Capybara");

            //delete old image
            var oldImagePath = Path.Combine(webRootPath, objToWorkWith.Image.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            

            await _capybarasService.DeleteCapybara(capybaraId);

            return RedirectToAction("Capybaras");
        }

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var listOfOrders = await _orderService.ListAsync();
            return View(listOfOrders.ToList());
        }

        public async Task<IActionResult> OrdersShip(int orderId)
        {
            var objFromDb = await _orderService.GetByIdAsync(orderId);
            await _orderService.ShipTheOrder(objFromDb);
            return RedirectToAction("Orders");
        }

        public async Task<IActionResult> OrdersDelete(int orderId)
        { 
            await _orderService.DeleteOrder(orderId);
            return RedirectToAction("Orders");
        }
    }
}