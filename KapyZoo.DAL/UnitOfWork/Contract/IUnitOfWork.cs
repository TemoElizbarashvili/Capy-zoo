using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KapyZoo.DAL.Repositories.IRepository;

namespace KapyZoo.DAL.UnitOfWork.Contract
{
    public interface IUnitOfWork
    {
        public IGalleryPicturesRepository GalleryPicturesRepository { get; }
        public ICapybaraRepository CapybaraRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public Task SaveAsync();

    }
}
