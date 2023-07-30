using MovieStore.DBOperations;
using System;
using System.Linq;

namespace MovieStore.Application.DirectorOperations.Commands.Delete
{
    public class DeleteDirectorCommand
    {
        private readonly IMovieStoreDbContext dbContext;
        public int Id { get; set; }

        public DeleteDirectorCommand(IMovieStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Handle()
        {
            var director = dbContext.Directors.Where(x => x.Id == Id).FirstOrDefault();
            if (director == null) throw new InvalidOperationException("Yazar bulunamadı");

            dbContext.Directors.Remove(director);
            dbContext.SaveChanges();
        }
    }
}
