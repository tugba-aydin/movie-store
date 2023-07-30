using AutoMapper;
using MovieStore.DBOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.MovieOperations.Commands.Create
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model { get; set; }
        private readonly IMovieStoreDbContext context;
        private readonly IMapper mapper;
        public CreateMovieCommand(IMovieStoreDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public void Handle()
        {
            var movie = context.Movies.SingleOrDefault(x => x.Name == Model.Name);

            if (movie is not null)
                throw new InvalidOperationException("Film zaten mevcut.");

            movie = mapper.Map<Movie>(Model);
            context.Movies.Add(movie);
            context.SaveChanges();
        }
    }

    public class CreateMovieModel
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public List<string> Casts { get; set; }
        public string Director { get; set; }
    }
}

