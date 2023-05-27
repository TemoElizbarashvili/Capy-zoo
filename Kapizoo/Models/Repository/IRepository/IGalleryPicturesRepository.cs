namespace Kapizoo.Models.Repository.IRepository
{
    public interface IGalleryPicturesRepository
    {
        public IQueryable<GalleryPicture> List();
        public Task<GalleryPicture> GetByIdAsync(int id);
        public Task CreateGalleryPicture(GalleryPicture galleryPicture);
        public Task DeleteGalleryPicture(int id);
        public Task EditGalleryPicture(GalleryPicture galleryPicture);

    }
}
