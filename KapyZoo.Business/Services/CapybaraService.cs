using KapyZoo.Business.Services.IServices;
using KapyZoo.DAL.Context;
using KapyZoo.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace KapyZoo.Business.Services
{
    public class CapybaraService : ICapybaraService
    {
        private ZooDbContext _db;
        private OrderService _orderService;

        public CapybaraService(ZooDbContext db)
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
            var objToDelete = _db.Capybaras.Where(c => c.CapybaraID == id).Include(c => c.Lines).FirstOrDefault();
            objToDelete.Lines.Clear();
            _db.Capybaras.Remove(objToDelete);
            _db.SaveChanges();
            return Task.CompletedTask;
        }

        public Task EditCapybara(Capybara capy)
        {
            var objFromDbtoEdit = _db.Capybaras.ToList().Where(c => c.CapybaraID == capy.CapybaraID).FirstOrDefault();

            objFromDbtoEdit.Price = capy.Price;
            objFromDbtoEdit.Gender = capy.Gender;
            objFromDbtoEdit.Age = capy.Age;
            objFromDbtoEdit.Description = capy.Description;
            objFromDbtoEdit.Name = capy.Name;
            objFromDbtoEdit.Image = capy.Image;

            return Task.CompletedTask;
        }

        public  Capybara GetById(int id)
        {
            return _db.Capybaras.FirstOrDefault(capy => capy.CapybaraID == id);
        }

        public IQueryable<Capybara> List()
        {
            return _db.Capybaras;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
