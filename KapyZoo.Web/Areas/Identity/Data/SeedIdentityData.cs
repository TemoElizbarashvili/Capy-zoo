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
        private  UserManager<IdentityUser> _userManager;
        private  RoleManager<IdentityRole> _roleManager;

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
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@dokkyoshi.com",
                    EmailConfirmed = true,
                    FirstName = "Main",
                    LastName = "Admin"
                }, "P@ssword123").GetAwaiter().GetResult();

                ApplicationUser user = context.ApplicationUser.FirstOrDefault(u => u.Email == "admin@dokkyoshi.com");

                _userManager.AddToRoleAsync(user, RD.AdminRole).GetAwaiter().GetResult();
            }
        }
    }
}
