using Kapizoo.Models.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Kapizoo.Models.Repository
{
    public class GalleryPicturesRepository : IGalleryPicturesRepository
    {
        private ZooDbContext _db;

        public GalleryPicturesRepository(ZooDbContext db) 
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
            _db.GalleryPictures.ToList().RemoveAll(gp => gp.GalleryPictureId == id);
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
    }
}
