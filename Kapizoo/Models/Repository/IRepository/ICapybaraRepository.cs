namespace Kapizoo.Models.Repository.IRepository
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
