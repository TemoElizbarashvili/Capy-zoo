namespace Kapizoo.Models.Repository.IRepository
{
    public interface IZooRepository
    {
        IQueryable<Capybara> Capybaras { get; }

        IQueryable<GalleryPicture> GalleryPictures { get; }
    }
}
