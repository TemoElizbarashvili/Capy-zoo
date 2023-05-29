using KapyZoo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.DAL.Repositories.IRepository
{
    public interface IZooRepository
    {
        IQueryable<Capybara> Capybaras { get; }

        IQueryable<GalleryPicture> GalleryPictures { get; }
    }
}
