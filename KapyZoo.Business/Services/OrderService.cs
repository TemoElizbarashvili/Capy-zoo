using KapyZoo.Business.Services.IServices;
using KapyZoo.DAL.Context;
using KapyZoo.DAL.UnitOfWork.Contract;
using KapyZoo.Shared.Models;

namespace KapyZoo.Business.Services
{
    public class OrderService : IOrderService
    {
        private ZooDbContext _db;

        public OrderService(ZooDbContext db)
        {
            _db = db;
        }

        public Task CreateOrder(Order order)
        {
            _db.AttachRange(order.Lines.Select(l => l.Capybara));
            _db.Orders.Add(order);
            _db.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task DeleteOrder(int id)
        {
            var orderToRemove = _db.Orders.Where(order => order.OrderId == id).FirstOrDefault();
            await Task.FromResult(_db.Orders.Remove(orderToRemove));
            _db.SaveChanges();
        }

        public Task EditOrder(Order order)
        {
            var orderToEdit = _db.Orders.Where(ord => ord.OrderId == order.OrderId).FirstOrDefault();
            orderToEdit.addresLine1 = order.addresLine1;
            orderToEdit.addresLine2 = order.addresLine2;
            orderToEdit.addresLine3 = order.addresLine3;
            orderToEdit.Lines = order.Lines;
            orderToEdit.Name = order.Name;
            orderToEdit.Shipped = order.Shipped;
            _db.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await Task.FromResult(_db.Orders.Where(order => order.OrderId == id).FirstOrDefault());
        }

        public async Task<IQueryable<Order>> ListAsync()
        {
            return await Task.FromResult(_db.Orders);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
