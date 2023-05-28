using Kapizoo.Models.Repository.IRepository;

namespace Kapizoo.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZooDbContext _db;


        public UnitOfWork(ZooDbContext db)
        {
            _db = db;
            GalleryPicturesRepository = new GalleryPicturesRepository(_db);
            CapybaraRepository = new CapybaraRepository(_db);
        }
      

        public IGalleryPicturesRepository GalleryPicturesRepository { get; }
        public ICapybaraRepository CapybaraRepository { get; }

        public Task SaveAsync()
        {
            _db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
