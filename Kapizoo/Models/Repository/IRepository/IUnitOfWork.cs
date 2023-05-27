namespace Kapizoo.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public IGalleryPicturesRepository GalleryPicturesRepository { get; }
        public Task SaveAsync();

    }
}
