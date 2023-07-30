using MovieStore.DBOperations;
using System;
using System.Linq;

namespace MovieStore.Application.CastOperations.Commands.Delete
{
    public class DeleteCastCommand
    {
        private readonly IMovieStoreDbContext dbContext;
        public int Id { get; set; }

        public DeleteCastCommand(IMovieStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Handle()
        {
            var cast = dbContext.Casts.Where(x => x.Id == Id).FirstOrDefault();
            if (cast == null) throw new InvalidOperationException("Oyuncu bulunamadı");

            dbContext.Casts.Remove(cast);
            dbContext.SaveChanges();
        }
    }
}
