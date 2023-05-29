using KapyZoo.Business.Services.IServices;
using KapyZoo.DAL.Context;
using KapyZoo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.Business.Services
{
    public class GalleryPicturesService : IGalleryPicturesService
    {
        private ZooDbContext _db;

        public GalleryPicturesService(ZooDbContext db)
        {
            _db = db;
        }

        public Task CreateGalleryPicture(GalleryPicture galleryPicture)
        {
            //galleryPicture.GalleryPictureId = _db.GalleryPictures.ToList().MaxBy(gp => gp.GalleryPictureId).GalleryPictureId + 1;
            _db.GalleryPictures.Add(galleryPicture);

            _db.SaveChanges();

            return Task.CompletedTask;
        }

        public Task DeleteGalleryPicture(int id)
        {
            var objToRemove = _db.GalleryPictures.Where(galleryPicture => galleryPicture.GalleryPictureId == id).FirstOrDefault();
            _db.GalleryPictures.Remove(objToRemove);
            _db.SaveChanges();
            return Task.CompletedTask;
        }

        public Task EditGalleryPicture(GalleryPicture galleryPicture)
        {
            var itemToUpdate = _db.GalleryPictures.FirstOrDefault(gp => gp.GalleryPictureId == galleryPicture.GalleryPictureId);
            itemToUpdate.Title = galleryPicture.Title;
            itemToUpdate.Picture = galleryPicture.Picture;
            return Task.CompletedTask;
        }

        public async Task<GalleryPicture> GetByIdAsync(int id)
        {
            return await Task.FromResult(_db.GalleryPictures.Where(gp => gp.GalleryPictureId == id).FirstOrDefault());
        }

        public IQueryable<GalleryPicture> List()
        {
            return _db.GalleryPictures;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
