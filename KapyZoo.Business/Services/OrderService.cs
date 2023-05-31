using KapyZoo.Business.Services.IServices;
using KapyZoo.DAL.Context;
using KapyZoo.DAL.UnitOfWork.Contract;
using KapyZoo.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace KapyZoo.Business.Services
{
    public class OrderService : IOrderService
    {
        private ZooDbContext _db;
        public OrderService(ZooDbContext db)
        {
            _db = db;
        }
        public IQueryable<Order> Orders => _db.Orders.Include(o => o.Lines).ThenInclude(o => o.Capybara);

        public Task CreateOrder(Order order)
        {
            _db.AttachRange(order.Lines.Select(l => l.Capybara));
            _db.Orders.Add(order);
            _db.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task DeleteOrder(int id)
        {
            var orderFromDb = _db.Orders.Where(o => o.OrderId == id).Include(o => o.Lines).FirstOrDefault();
            orderFromDb.Lines = null;
            await Task.FromResult(_db.Orders.Remove(orderFromDb));
            _db.SaveChanges();
        }

        public Task ShipTheOrder(Order order)
        {
            var orderToShip = _db.Orders.Where(ord => ord.OrderId == order.OrderId).FirstOrDefault();
            orderToShip.Shipped = true;
            return Task.CompletedTask;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await Task.FromResult(_db.Orders.Where(order => order.OrderId == id).FirstOrDefault());
        }

        public async Task<IQueryable<Order>> ListAsync()
        {
            return await Task.FromResult(_db.Orders.Include(o => o.Lines).ThenInclude(o => o.Capybara));
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
