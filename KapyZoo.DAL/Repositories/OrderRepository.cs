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
    public class OrderRepository : IOrderRepository
    {
        private ZooDbContext _db;

        public OrderRepository(ZooDbContext db)
        {
            _db = db;
        }

        public async Task CreateOrder(Order order)
        {
            await _db.Orders.AddAsync(order);
            _db.SaveChanges();
        }

        public async Task DeleteOrder(int id)
        {
            var orderToRemove = _db.Orders.Where(order => order.OrderId == id).FirstOrDefault();
            await Task.FromResult(_db.Orders.Remove(orderToRemove));
        }

        public Task EditOrder(Order order)
        {
            var orderToEdit = _db.Orders.Where(ord => ord.OrderId == order.OrderId).FirstOrDefault();
            orderToEdit.AddresLine1 = order.AddresLine1;
            orderToEdit.AddresLine2 = order.AddresLine2;
            orderToEdit.AddresLine3 = order.AddresLine3;
            orderToEdit.Lines = order.Lines;
            orderToEdit.Name = order.Name;
            orderToEdit.Shipped = order.Shipped;
            return Task.CompletedTask;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await Task.FromResult(_db.Orders. Where(order => order.OrderId == id).FirstOrDefault());
        }

        public async Task<IQueryable<Order>> ListAsync()
        {
            return await Task.FromResult(_db.Orders);
        }
    }
}
