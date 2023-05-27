using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kapizoo.Models
{
    public class Capybara
    {
        [BindNever]
        public long CapybaraID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter an age")]
        public int Age { get; set; }
        [StringLength(1)] // F or M
        public char gender { get; set; }
        public double Price { get; set; }  

        public string Image { get; set; }
    }
}
