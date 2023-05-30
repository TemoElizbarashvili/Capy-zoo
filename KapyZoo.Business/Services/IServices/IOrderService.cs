using KapyZoo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.Business.Services.IServices
{
    public interface IOrderService
    {
        public Task<IQueryable<Order>> ListAsync();
        public Task<Order> GetByIdAsync(int id);
        public Task CreateOrder(Order order);
        public Task DeleteOrder(int id);
        public Task EditOrder(Order order);
        public Task SaveAsync();
       
    }
}
