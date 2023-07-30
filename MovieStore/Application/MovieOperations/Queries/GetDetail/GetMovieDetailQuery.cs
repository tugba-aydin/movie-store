using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DBOperations;
using MovieStore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.MovieOperations.Queries.GetDetail
{
    public class GetMovieDetailQuery
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetMovieDetailQuery(IMovieStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public Movie Handle()
        {
            var movie = dbContext.Movies.Include(x => x.Director).Where(x => x.Id == Id).FirstOrDefault();
            //BookDetailViewModel vm = mapper.Map<BookDetailViewModel>(book);
            return movie;
        }
    }

    public class MovieDetailViewModel
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public List<string> Casts { get; set; }
        public string Director { get; set; }
    }
}
