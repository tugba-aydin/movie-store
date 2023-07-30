using MovieStore.DBOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.DirectorOperations.Commands.Update
{
    public class UpdateDirectorCommand
    {
        public int Id { get; set; }
        public UpdateDirectorModel Model { get; set; }
        private readonly IMovieStoreDbContext dbContext;
        public UpdateDirectorCommand(IMovieStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Handle()
        {
            var director = dbContext.Directors.Where(b => b.Id == Id).FirstOrDefault();
            if (director == null) throw new InvalidOperationException("Böyle bir yazar bulunamadı");
            director.Movies = Model.Movies;
            dbContext.SaveChanges();
        }
    }

    public class UpdateDirectorModel
    {
        public List<Movie> Movies { get; set; }
    }
}
