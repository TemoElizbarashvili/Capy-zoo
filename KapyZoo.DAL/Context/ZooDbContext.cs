using KapyZoo.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.DAL.Context
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options) : base(options) { }

        public DbSet<Capybara> Capybaras => Set<Capybara>();

        public DbSet<GalleryPicture> GalleryPictures => Set<GalleryPicture>();

    }
}
