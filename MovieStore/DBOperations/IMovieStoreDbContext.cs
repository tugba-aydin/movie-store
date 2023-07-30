using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DBOperations
{
    public interface IMovieStoreDbContext
    {
        DbSet<Director> Directors { get; set; }
        DbSet<Cast> Casts { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Customer> Customers { get; set; }

        int SaveChanges();
    }
}
