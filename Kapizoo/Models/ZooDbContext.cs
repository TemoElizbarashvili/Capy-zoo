using Microsoft.EntityFrameworkCore;

namespace Kapizoo.Models
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options) : base(options) { }

        public DbSet<Capybara> Capybaras => Set<Capybara>();
       
    }
}
