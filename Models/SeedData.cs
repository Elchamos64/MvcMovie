using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The R.M.",
                    ReleaseDate = DateTime.Parse("2003-1-31"),
                    Genre = "Comedy",
                    Price = 7.99M,
                    Image = "~/images/the-rm.jpg"
                },
                new Movie
                {
                    Title = "The Other Side of Heaven ",
                    ReleaseDate = DateTime.Parse("2001-12-14"),
                    Genre = "Adventure",
                    Price = 8.99M,
                    Image = "~/images/the-other-side-of-heaven.jpg"
                },
                new Movie
                {
                    Title = "The fightingh Preacher",
                    ReleaseDate = DateTime.Parse("2019-7-24"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Image = "~/images/the-fighting-preacher.jpg"
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-10-10"),
                    Genre = "Documentary",
                    Price = 3.99M,
                    Image = "~/images/meet-the-mormons.jpg"
                }
            );
            context.SaveChanges();
        }
    }
}