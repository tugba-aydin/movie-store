using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DBOperations;
using MovieStore.Entities;
using System.Linq;

namespace MovieStore.Application.CastOperations.Queries.GetDetail
{
    public class GetCastDetailQuery
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetCastDetailQuery(IMovieStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }
        public Cast Handle()
        {
            var cast = dbContext.Casts.Include(x => x.Movies).Where(x => x.Id == Id).FirstOrDefault();
            //BookDetailViewModel vm = mapper.Map<BookDetailViewModel>(book);
            return cast;
        }
    }

    public class CastDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public int PageCount { get; set; }
    }
}
