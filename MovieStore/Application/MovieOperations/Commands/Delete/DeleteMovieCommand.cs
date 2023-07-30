using MovieStore.DBOperations;
using System;
using System.Linq;

namespace MovieStore.Application.MovieOperations.Commands.Delete
{
    public class DeleteMovieCommand
    {
        private readonly IMovieStoreDbContext dbContext;
        public int Id { get; set; }

        public DeleteMovieCommand(IMovieStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Handle()
        {
            var movie = dbContext.Movies.Where(x => x.Id == Id).FirstOrDefault();
            if (movie == null) throw new InvalidOperationException("Film bulunamadı");

            dbContext.Movies.Remove(movie);
            dbContext.SaveChanges();
        }
    }
}
