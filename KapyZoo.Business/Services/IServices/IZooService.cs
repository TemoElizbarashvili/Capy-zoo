using KapyZoo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.Business.Services.IServices
{
    public interface IZooService
    {
        IQueryable<Capybara> Capybaras { get; }

        IQueryable<GalleryPicture> GalleryPictures { get; }
    }
}
