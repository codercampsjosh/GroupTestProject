using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using GroupTestProject.Models;

namespace GroupTestProject.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            //Seed Movie Database
            

            var movieOne = new Movie
            {
                Title = "Pacific Rim",
                Director = "Del Toro"
            };

            context.Movie.Add(movieOne);
            context.SaveChanges();

            var movieTwo = new Movie
            {
                Title = "Jurassic Park",
                Director = "Spielberg"
            };

            context.Movie.Add(movieTwo);
            context.SaveChanges();

            var movieThree = new Movie
            {
                Title = "Dumb & Dumber",
                Director = "Farley Brothers"
            };

            context.Movie.Add(movieThree);
            context.SaveChanges();

            var movieFour = new Movie
            {
                Title = "Batman the Dark Knight",
                Director = "Nolan"
            };

            context.Movie.Add(movieFour);
            context.SaveChanges();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }


        }

    }
}
