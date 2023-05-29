using KapyZoo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.Business.Services.IServices
{
    public interface ICapybaraService
    {
        public IQueryable<Capybara> List();
        public Capybara GetById(int id);
        public Task CreateCapybara(Capybara capy);
        public Task DeleteCapybara(int id);
        public Task EditCapybara(Capybara capy);

        public Task SaveAsync();
    }
}
