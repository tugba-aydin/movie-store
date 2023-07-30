using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DBOperations
{
    public class MovieStoreDbContext:DbContext, IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Director> Directors { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
