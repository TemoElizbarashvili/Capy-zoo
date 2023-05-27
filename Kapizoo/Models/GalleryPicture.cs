using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Kapizoo.Models
{
    public class GalleryPicture
    {
        [BindNever]
        public long GalleryPictureId { get; set; }

        [Required(ErrorMessage ="Please upload an image")]
        public string Picture { get; set; }

        [Required(ErrorMessage ="Please enter the title")]
        public string Title { get; set; }
    }
}
