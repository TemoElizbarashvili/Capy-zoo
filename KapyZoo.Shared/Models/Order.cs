using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.Shared.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get;  set; }
        [Required(ErrorMessage = "Please enter your first addres line")]
        public string AddresLine1 { get; set; }
        public string AddresLine2 { get; set; }
        public string AddresLine3 { get; set; }
        [BindNever]
        public bool Shipped { get; set; }

    }
}
