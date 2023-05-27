using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Kapizoo.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ZooDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ZooDbContext>();
            if (context.Database.GetPendingMigrations().Any()) 
            {
                context.Database.Migrate();
            }
            if (!context.Capybaras.Any())
            {
                context.Capybaras.AddRange(
                    new Capybara
                    {
                        Name = "Super Capy",
                        Age = 2,
                        Description = "the best capybara",
                        gender = 'F',
                        Price = 10,
                        Image = "https://i.pinimg.com/originals/ca/70/d6/ca70d6d5d7798711b1a5d05b7917cbfb.jpg"
                    },
                    new Capybara
                    {
                        Name = "Smart Capy",
                        Age = 3,
                        Description = "the best capybara",
                        gender = 'F',
                        Price = 1000,
                        Image = "https://i.pinimg.com/originals/d2/4a/de/d24ade94367972c5509b8f2dfe9cd8e0.jpg"
                    },
                    new Capybara
                    {
                        Name = "gangster Capy",
                        Age = 4,
                        Description = "the best capybara",
                        gender = 'M',
                        Price = 2500,
                        Image = "https://i.pinimg.com/originals/bb/04/ef/bb04eff25ff46f60c93c733093a9917b.jpg"

                    },
                    new Capybara
                    {
                        Name = "shrek Capy",
                        Age = 2,
                        Description = "the best capybara",
                        gender = 'M',
                        Price = 3500,
                        Image = "https://i.pinimg.com/originals/93/76/27/9376271cf4b1392629b7e6125d24f559.jpg"
                    },
                    new Capybara
                    {
                        Name = "Lazy Capy",
                        Age = 5,
                        Description = "the best capybara",
                        gender = 'F',
                        Price = 500,
                        Image = "https://i.pinimg.com/originals/97/13/3e/97133e9d1952cddef32cdc697c25ad37.jpg"
                    },
                    new Capybara
                    {
                        Name = "Slay Capy",
                        Age = 1,
                        Description = "the best capybara",
                        gender = 'M',
                        Price = 5000,
                        Image = "https://i.pinimg.com/564x/99/d7/85/99d78527baf3e70242a8bc02c8012b0d.jpg"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
