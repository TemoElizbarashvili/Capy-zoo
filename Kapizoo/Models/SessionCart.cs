using Kapizoo.infrastructure;
using System.Text.Json.Serialization;

namespace Kapizoo.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            SessionCart cart = session.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Capybara capybara, int quantity)
        {
            base.AddItem(capybara, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveItem(Capybara capybara, int quantity)
        {
            base.RemoveItem(capybara, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Capybara capybara)
        {
            base.RemoveLine(capybara);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
