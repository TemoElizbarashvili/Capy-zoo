using KapyZoo.Shared.Models;
using KapyZoo.Web.Models;

namespace Kapizoo.Models.ViewModels
{
    public class StoreViewModel
    {
        public IEnumerable<Capybara> Capybaras { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public Cart Cart { get; set; }
    }
}