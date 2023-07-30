using AutoMapper;
using MovieStore.DBOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.DirectorOperations.Commands.Create
{
    public class CreateDirectorCommand
    {
        public CreateDirectorModel Model { get; set; }
        private readonly IMovieStoreDbContext dbContext;
        private readonly IMapper mapper;

        public CreateDirectorCommand(IMovieStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public void Handle()
        {
            var director = dbContext.Directors.Where(b => b.Name == Model.Name&&b.Surname==Model.Surname).FirstOrDefault();
            if (director != null) throw new InvalidOperationException("Yönetmen zaten mevcut");
            //book = mapper.Map<Book>(Model);
            dbContext.Directors.Add(director);
            dbContext.SaveChanges();
        }
    }

    public class CreateDirectorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Movies { get; set; }
    }
}
