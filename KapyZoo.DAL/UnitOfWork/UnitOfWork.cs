using KapyZoo.DAL.Context;
using KapyZoo.DAL.Repositories;
using KapyZoo.DAL.Repositories.IRepository;
using KapyZoo.DAL.UnitOfWork.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZooDbContext _db;


        public UnitOfWork(ZooDbContext db)
        {
            _db = db;
            GalleryPicturesRepository = new GalleryPicturesRepository(_db);
            CapybaraRepository = new CapybaraRepository(_db);
            OrderRepository = new OrderRepository(_db);
        }


        public IGalleryPicturesRepository GalleryPicturesRepository { get; }
        public ICapybaraRepository CapybaraRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public Task SaveAsync()
        {
            _db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
