using AutoMapper;
using MovieStore.DBOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.CastOperations.Commands.Create
{
    public class CreateCastCommand
    {
        public CreateCastModel Model { get; set; }
        private readonly IMovieStoreDbContext dbContext;
        private readonly IMapper mapper;

        public CreateCastCommand(IMovieStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public void Handle()
        {
            var cast = dbContext.Casts.Where(b => b.Name == Model.Name&&b.Surname==Model.Surname).FirstOrDefault();
            if (cast != null) throw new InvalidOperationException("Oyuncu zaten mevcut");
            //cast = mapper.Map<Book>(Model);
            dbContext.Casts.Add(cast);
            dbContext.SaveChanges();
        }
    }

    public class CreateCastModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Movies { get; set; }
    }
}
