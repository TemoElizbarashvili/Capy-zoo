namespace KapyZoo.Web.Areas.Identity.Data
{
    public interface ISeedIdentityData
    {
        void EnsurePopulated(IApplicationBuilder app);
    }
}
