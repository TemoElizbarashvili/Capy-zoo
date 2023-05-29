using KapyZoo.Shared.Models;

namespace Kapizoo.Models.ViewModels
{
    public class StoreViewModel
    {
        public IEnumerable<Capybara> Capybaras { get; set; }
        public Cart Cart { get; set; }
    }
}