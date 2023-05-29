using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.Shared.Models
{
    public class GalleryPicture
    {
        [BindNever]
        public long GalleryPictureId { get; set; }

        [Required(ErrorMessage = "Please upload an image")]
        public string Picture { get; set; }

        [Required(ErrorMessage = "Please enter the title")]
        public string Title { get; set; }
    }
}
