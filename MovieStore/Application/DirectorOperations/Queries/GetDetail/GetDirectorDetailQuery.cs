using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DBOperations;
using MovieStore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.DirectorOperations.Queries.GetDetail
{
    public class GetDirectorDetailQuery
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetDirectorDetailQuery(IMovieStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public Director Handle()
        {
            var director = dbContext.Directors.Include(x => x.Movies).Where(x => x.Id == Id).FirstOrDefault();
            //BookDetailViewModel vm = mapper.Map<BookDetailViewModel>(book);
            return director;
        }
    }

    public class DirectorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
