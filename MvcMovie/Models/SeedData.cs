using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "The Home Teachers",
                         ReleaseDate = DateTime.Parse("1989-1-11"),
                         Genre = "Religious Comedy",
                         Rating = "PG",
                         Price = 7.99M
                     },

                     new Movie
                     {
                         Title = "Jhonny Lingo",
                         ReleaseDate = DateTime.Parse("1984-3-13"),
                         Genre = "Comedy",
                         Rating = "PG",
                         Price = 8.99M
                     },

                     new Movie
                     {
                         Title = "Joseph Smith: The prophet of the restoration",
                         ReleaseDate = DateTime.Parse("1986-2-23"),
                         Genre = "Religious",
                         Rating = "PG",
                         Price = 9.99M
                     },

                   new Movie
                   {
                       Title = "Finding Faith in Christ",
                       ReleaseDate = DateTime.Parse("1959-4-15"),
                       Genre = "Religious",
                       Rating = "PG",
                       Price = 3.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}