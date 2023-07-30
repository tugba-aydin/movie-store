using MovieStore.DBOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.CastOperations.Commands.Update
{
    public class UpdateCastCommand
    {
        public int Id { get; set; }
        public UpdateCastModel Model { get; set; }
        private readonly IMovieStoreDbContext dbContext;
        public UpdateCastCommand(IMovieStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Handle()
        {
            var cast = dbContext.Casts.Where(b => b.Id == Id).FirstOrDefault();
            if (cast == null) throw new InvalidOperationException("Böyle bir oyuncu bulunamadı");
            cast.Movies = Model.Movies;
            dbContext.SaveChanges();
        }
    }

    public class UpdateCastModel
    {
        public List<Movie> Movies { get; set; }
    }
}
