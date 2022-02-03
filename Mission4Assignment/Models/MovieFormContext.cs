using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4Assignment.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext (DbContextOptions<MovieFormContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<MovieResponse> responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category { CategoryId=1, CategoryName="Action/Adventure"},
                new Category { CategoryId=2, CategoryName="Comedy" },
                new Category {  CategoryId=3, CategoryName="Drama"},
                new Category { CategoryId=4, CategoryName="Family"},
                new Category {  CategoryId=5, CategoryName="Horror/Suspense"},
                new Category {  CategoryId=6, CategoryName="Miscellaneous"},
                new Category { CategoryId=7, CategoryName="Television"},
                new Category { CategoryId=8, CategoryName="VHS"}
                );
            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    ApplicationId = 1,
                    CategoryId = 1,
                    Title = "Avengers",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = true,
                    LentTo = "Kellie Bruner",
                    Notes = "Great movie!"
                },

                new MovieResponse
                {
                    ApplicationId = 2,
                    CategoryId = 1,
                    Title = "Batman",
                    Year = 1989,
                    Director = "Tim Burton",
                    Rating = "PG-13",
                    Edited = true,
                    LentTo = "Kellie Bruner",
                    Notes = "Great movie!"
                },

                new MovieResponse
                {
                    ApplicationId = 3,
                    CategoryId = 1,
                    Title = "Iron Man",
                    Year = 2008,
                    Director = "Jon Favreau",
                    Rating = "PG-13",
                    Edited = true,
                    LentTo = "Kellie Bruner",
                    Notes = "Great movie!"
                }

                );
        }


    }
}
