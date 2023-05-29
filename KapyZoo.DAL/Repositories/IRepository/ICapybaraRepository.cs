using KapyZoo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.DAL.Repositories.IRepository
{
    public interface ICapybaraRepository
    {
        public IQueryable<Capybara> List();
        public Task<Capybara> GetByIdAsync(int id);
        public Task CreateCapybara(Capybara capy);
        public Task DeleteCapybara(int id);
        public Task EditCapybara(Capybara capy);
    }
}
