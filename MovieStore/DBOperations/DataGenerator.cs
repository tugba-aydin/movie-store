using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.Entities;
using System;
using System.Linq;

namespace MovieStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                // Look for any board games.
                if (context.Movies.Any())
                {
                    return;   // Data was already seeded
                }

                context.Movies.AddRange(
                    new Movie()
                    {
                        Name = "Personal Growth"
                    },
                    new Movie()
                    {
                        Name = "Science Fiction"
                    },
                    new Movie()
                    {
                        Name = "Romance"
                    }
                );

                context.Directors.AddRange(
                   new Director()
                   {
                       
                   },
                    new Director()
                    {
                        
                    },
                    new Director()
                    {
                      
                    });

                context.Casts.AddRange(
                   new Cast()
                   {

                   },
                    new Cast()
                    {

                    },
                    new Cast()
                    {

                    });

                context.Customers.AddRange(
                   new Customer()
                   {

                   },
                    new Customer()
                    {

                    });

                context.SaveChanges();
            }
        }
    }
}
