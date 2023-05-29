using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.Shared.Models
{
    public class Capybara
    {
        [BindNever]
        public long CapybaraID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter an age")]
        [Range(0,15)]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please choose gender")]
        public string Gender { get; set; }
        public double Price { get; set; }

        public string Image { get; set; }
    }
}
