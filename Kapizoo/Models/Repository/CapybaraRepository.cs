using Kapizoo.Models.Repository.IRepository;

namespace Kapizoo.Models.Repository
{
    public class CapybaraRepository : ICapybaraRepository
    {
        private ZooDbContext _db;

        public CapybaraRepository(ZooDbContext db)
        {
            _db = db;
        }

        public Task CreateCapybara(Capybara capy)
        {
            _db.Capybaras.Add(capy);
            _db.SaveChanges();
            return Task.CompletedTask;
        }

        public Task DeleteCapybara(int id)
        {
            var objToDelete = _db.Capybaras.ToList().Where(c => c.CapybaraID == id).FirstOrDefault();
            _db.Capybaras.Remove(objToDelete);
            _db.SaveChanges();
            return Task.CompletedTask;
        }

        public Task EditCapybara(Capybara capy)
        {
            var objFromDbtoEdit = _db.Capybaras.ToList().Where(c => c.CapybaraID == capy.CapybaraID).FirstOrDefault();

            objFromDbtoEdit.Price = capy.Price;
            objFromDbtoEdit.gender = capy.gender;
            objFromDbtoEdit.Age = capy.Age;
            objFromDbtoEdit.Description = capy.Description;
            objFromDbtoEdit.Name = capy.Name;
            objFromDbtoEdit.Image = capy.Image;

            return Task.CompletedTask;
        }

        public async Task<Capybara> GetByIdAsync(int id)
        {
            return await Task.FromResult(_db.Capybaras.First(capy => capy.CapybaraID == id));
        }

        public IQueryable<Capybara> List()
        {
            return _db.Capybaras;
        }
    }
}
