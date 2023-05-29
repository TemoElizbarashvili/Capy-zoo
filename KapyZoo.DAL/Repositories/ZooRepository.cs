using KapyZoo.DAL.Context;
using KapyZoo.DAL.Repositories.IRepository;
using KapyZoo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.DAL.Repositories
{
    public class ZooRepository : IZooRepository
    {
        private ZooDbContext _dbContext;
        public ZooRepository(ZooDbContext ctx)
        {
            _dbContext = ctx;
        }
        public IQueryable<Capybara> Capybaras => _dbContext.Capybaras;

        public IQueryable<GalleryPicture> GalleryPictures => _dbContext.GalleryPictures;

    }
}
