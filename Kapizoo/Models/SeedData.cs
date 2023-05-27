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
            if (!context.GalleryPictures.Any())
            {
                context.GalleryPictures.AddRange(
                    new GalleryPicture
                    {
                        Title = "Orange capybara in water",
                        Picture = "https://i.pinimg.com/originals/1b/6a/c5/1b6ac5cd81f64d8535ea20b5390cc2f3.jpg"
                    },
                    new GalleryPicture
                    {
                        Title = "Cute capybara pinterest",
                        Picture = "https://i.pinimg.com/originals/c3/3e/38/c33e38ba0b4a6252bfb4276926a1c4d2.jpg"
                    },
                    new GalleryPicture
                    {
                        Title = "Gamer Capybara",
                        Picture = "https://i.pinimg.com/originals/c3/ef/ed/c3efed485e403561ccdc46e0d798e39a.jpg"
                    },
                    new GalleryPicture
                    {
                        Title = "Capybara",
                        Picture = "https://i.pinimg.com/originals/1d/96/93/1d9693375e47f7f2b0f1b01111d7275a.jpg"
                    },
                    new GalleryPicture
                    {
                        Title = "Cool 😎 sunglasses capybara",
                        Picture = "https://i.pinimg.com/originals/ee/04/8e/ee048e8915ec824de4f65edb75dd17ef.jpg"
                    },
                    new GalleryPicture
                    {
                        Title = "CAPY",
                        Picture = "https://i.pinimg.com/originals/30/c9/38/30c9385534be840af0229b602e37f2c7.jpg"
                    },
                    new GalleryPicture
                    {
                        Title = "Baby Capybara passport photo",
                        Picture = "https://i.redd.it/21vsjc5dtg201.jpg"
                    },
                    new GalleryPicture
                    {
                        Title = "Animals Sitting on Capybaras",
                        Picture = "https://64.media.tumblr.com/6ac14801d4c0c3f079e4a7cdcc8ab021/a8883e9c47759300-be/s1280x1920/4e8824afd492823b6b0bd0272589a130e878b31d.jpg"
                    },
                    new GalleryPicture
                    {
                        Title = "Lil baby capybara",
                        Picture = "https://i.redd.it/lil-baby-capybara-v0-6bqg8nebkza81.jpg?s=3ae121c8684c8c0680f4b5b571208b50d0512ece"
                    },
                    new GalleryPicture
                    {
                        Title = "Capybara pic",
                        Picture = "https://i.pinimg.com/originals/16/01/43/16014314b6be222038eaae943586c339.jpg"
                    },
                    new GalleryPicture
                    {
                        Title = "Capybara taking bath",
                        Picture = "https://i.pinimg.com/564x/80/07/5a/80075ad06e15ecbc25bcd2fd2b3c4536.jpg"
                    },
                    new GalleryPicture
                    {
                        Title = "Animals Sitting on Capybaras",
                        Picture = "https://i.pinimg.com/564x/ef/af/26/efaf262785f916603cff706eb0532744.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
