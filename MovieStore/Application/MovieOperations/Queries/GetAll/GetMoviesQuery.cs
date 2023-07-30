using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DBOperations;
using MovieStore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.MovieOperations.Queries.GetAll
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetMoviesQuery(IMovieStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public List<Movie> Handle()
        {
            var movieList = dbContext.Movies.Include(x => x.Director).OrderBy(x => x.Id).ToList();
            //List<BookViewModel> vm = mapper.Map<List<BookViewModel>>(bookList);
            return movieList;
        }
    }

    public class MovieViewModel
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public List<string> Casts { get; set; }
        public string Director { get; set; }
    }
}

