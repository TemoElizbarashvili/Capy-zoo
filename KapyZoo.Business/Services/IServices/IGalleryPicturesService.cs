using KapyZoo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.Business.Services.IServices
{
    public interface IGalleryPicturesService
    {
        public IQueryable<GalleryPicture> List();
        public Task<GalleryPicture> GetByIdAsync(int id);
        public Task CreateGalleryPicture(GalleryPicture galleryPicture);
        public Task DeleteGalleryPicture(int id);
        public Task EditGalleryPicture(GalleryPicture galleryPicture);

        public Task SaveAsync();
    }
}
