using Microsoft.EntityFrameworkCore;

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
                    },
                    new Capybara
                    {
                        Name = "Smart Capy",
                        Age = 3,
                        Description = "the best capybara",
                        gender = 'F',
                        Price = 1000,

                    },
                    new Capybara
                    {
                        Name = "Hero Capy",
                        Age = 4,
                        Description = "the best capybara",
                        gender = 'M',
                        Price = 2500

                    },
                    new Capybara
                    {
                        Name = "Student Capy",
                        Age = 2,
                        Description = "the best capybara",
                        gender = 'M',
                        Price = 3500
                    },
                    new Capybara
                    {
                        Name = "Lazy Capy",
                        Age = 5,
                        Description = "the best capybara",
                        gender = 'F',
                        Price = 500
                    },
                    new Capybara
                    {
                        Name = "Slay Capy",
                        Age = 1,
                        Description = "the best capybara",
                        gender = 'M',
                        Price = 5000
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
