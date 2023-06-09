﻿namespace KapyZoo.Shared.Models
{
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Capybara Capybara { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Capybara capybara, int quantity)
        {
            CartLine line = Lines.Where(c => c.Capybara.CapybaraID == capybara.CapybaraID).FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Capybara = capybara,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveItem(Capybara capybara, int quantity)
        {
            CartLine line = Lines.Where(c => c.Capybara.CapybaraID == capybara.CapybaraID).FirstOrDefault();
            if (line != null)
            {
                if (line.Quantity <= quantity)
                {
                    RemoveLine(capybara);
                }
                else
                {
                    line.Quantity -= quantity;
                }
            }
        }


        public virtual void RemoveLine(Capybara capybara) => Lines.RemoveAll(l => l.Capybara.CapybaraID == capybara.CapybaraID);

        public double ComputeTotalValue() => Lines.Sum(i => i.Capybara.Price * i.Quantity);

        public virtual void Clear() => Lines.Clear();
    }
}
