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
    public class ZooService : IZooService
    {
        private ZooDbContext _dbContext;
        public ZooService(ZooDbContext ctx)
        {
            _dbContext = ctx;
        }
        public IQueryable<Capybara> Capybaras => _dbContext.Capybaras;

        public IQueryable<GalleryPicture> GalleryPictures => _dbContext.GalleryPictures;
    }
}
