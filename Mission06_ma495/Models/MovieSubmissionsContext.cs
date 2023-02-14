using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_ma495.Models
{
    public class MovieSubmissionsContext : DbContext
    {
        public MovieSubmissionsContext (DbContextOptions<MovieSubmissionsContext> options) : base (options)
        {

        }

        public DbSet<ApplicationResponse> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                
                new ApplicationResponse
                {
                    MovieId = 1,
                    Category = "Family",
                    Title = "The Princess Bride",
                    Year = "1987",
                    Director = "Inigo Montoya",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Mom",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    MovieId = 2,
                    Category = "Family",
                    Title = "The Guernsey Literary and Potato Peel Pie Society",
                    Year = "2018",
                    Director = "Mike Newell",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Julia",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    MovieId = 3,
                    Category = "Schi-fi/Adventure",
                    Title = "Dune",
                    Year = "2021",
                    Director = "Denis Villeneuve",
                    Rating = "PG-13",
                    Edited = true,
                    LentTo = "",
                    Notes = ""
                }
            );
        }
    }
}
