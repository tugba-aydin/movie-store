using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DBOperations;
using MovieStore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.CastOperations.Queries.GetAll
{
    public class GetCastQuery
    {
        private readonly IMovieStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetCastQuery(IMovieStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public List<Cast> Handle()
        {
            var castList = dbContext.Casts.Include(x => x.Movies).OrderBy(x => x.Id).ToList();
            //List<BookViewModel> vm = mapper.Map<List<BookViewModel>>(bookList);
            return castList;
        }
    }

    public class CastViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Movies { get; set; }
    }
}
