using AutoMapper;
using MovieStore.Application.MovieOperations.Commands.Create;
using MovieStore.Application.MovieOperations.Queries.GetAll;
using MovieStore.Entities;

namespace MovieStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMovieModel, Movie>();
        }
    }
}
