using KapyZoo.DAL.Context;
using KapyZoo.Web.Models;
using KapyZoo.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KapyZoo.Web.Areas.Identity.Data
{
    public class SeedIdentityData : ISeedIdentityData
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public SeedIdentityData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void EnsurePopulated(IApplicationBuilder app)
        {
            IdentityDataContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityDataContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!_roleManager.RoleExistsAsync(RD.AdminRole).GetAwaiter().GetResult())
            {
                //Initialize roles if they do not exsist
                _roleManager.CreateAsync(new IdentityRole(RD.AdminRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(RD.CustomerRole)).GetAwaiter().GetResult();

                //Initialize Admin user
                _userManager.CreateAsync(new IdentityUser
                {
                    UserName = "admin@dokkyoshi.com",
                    Email = "admin@dokkyoshi.com",
                    EmailConfirmed = true
                }, "Password-23").GetAwaiter().GetResult();

                var user = _userManager.FindByEmailAsync("admin@dokkyoshi.com").GetAwaiter().GetResult();

                if (user != null)
                {
                    if (!_userManager.IsInRoleAsync(user, RD.AdminRole).GetAwaiter().GetResult())
                    {
                        _userManager.AddToRoleAsync(user, RD.AdminRole).GetAwaiter().GetResult();
                    }
                }
            }
        }
    }
}
