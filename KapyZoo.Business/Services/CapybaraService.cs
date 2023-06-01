using KapyZoo.Business.Services.IServices;
using KapyZoo.DAL.Context;
using KapyZoo.Shared.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace KapyZoo.Business.Services
{
    public class CapybaraService : ICapybaraService
    {
        private ZooDbContext _db;
        private IOrderService _orderService;

        public CapybaraService(ZooDbContext db, IOrderService os)
        {
            _db = db;
            _orderService = os;
        }

        public Task CreateCapybara(Capybara capy)
        {
            _db.Capybaras.Add(capy);
            _db.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task DeleteCapybara(int id)
        {
            var objToDelete = _db.Capybaras.Where(c => c.CapybaraID == id).Include(c => c.Lines).FirstOrDefault();
            foreach(var item in objToDelete.Lines)
            {
                await _orderService.DeleteOrder(item.OrderId);
            }
            objToDelete.Lines.Clear();
            _db.Capybaras.Remove(objToDelete);
            _db.SaveChanges();
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
