using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DBOperations;
using MovieStore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.DirectorOperations.Queries.GetAll
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetDirectorsQuery(IMovieStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public List<Director> Handle()
        {
            var directorList = dbContext.Directors.Include(x => x.Movies).OrderBy(x => x.Id).ToList();
            //List<BookViewModel> vm = mapper.Map<List<BookViewModel>>(bookList);
            return directorList;
        }
    }

    public class DirectorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
