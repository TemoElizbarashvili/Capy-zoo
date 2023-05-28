namespace Kapizoo.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public IGalleryPicturesRepository GalleryPicturesRepository { get; }
        public ICapybaraRepository CapybaraRepository { get; }
        public Task SaveAsync();

    }
}
