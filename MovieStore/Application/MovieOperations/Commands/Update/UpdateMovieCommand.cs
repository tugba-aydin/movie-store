using MovieStore.DBOperations;
using System;
using System.Linq;

namespace MovieStore.Application.MovieOperations.Commands.Update
{
    public class UpdateMovieCommand
    {
            public int Id { get; set; }
            public UpdateMovieModel Model { get; set; }
            private readonly IMovieStoreDbContext dbContext;
            public UpdateMovieCommand(IMovieStoreDbContext _dbContext)
            {
                dbContext = _dbContext;
            }
            public void Handle()
            {
                var movie = dbContext.Movies.Where(b => b.Id == Id).FirstOrDefault();
                if (movie == null) throw new InvalidOperationException("Böyle bir film bulunamadı");
                movie.Price = Model.Price;
                dbContext.SaveChanges();
            }
        }

        public class UpdateMovieModel
        {
            public decimal Price { get; set; }
        }
      }
