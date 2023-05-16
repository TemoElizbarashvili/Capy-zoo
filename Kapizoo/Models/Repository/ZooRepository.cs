using Kapizoo.Models.Repository.IRepository;

namespace Kapizoo.Models.Repository
{
    public class ZooRepository : IZooRepository
    {
        private ZooDbContext _dbContext;
        public ZooRepository(ZooDbContext ctx) 
        {
            _dbContext = ctx;
        }
        public IQueryable<Capybara> Capybaras => _dbContext.Capybaras;

    }
}
