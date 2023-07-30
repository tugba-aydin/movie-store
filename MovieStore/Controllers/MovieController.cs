using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.CastOperations.Commands.Create;
using MovieStore.Application.CastOperations.Commands.Delete;
using MovieStore.Application.CastOperations.Commands.Update;
using MovieStore.Application.CastOperations.Queries.GetAll;
using MovieStore.Application.CastOperations.Queries.GetDetail;
using MovieStore.Application.MovieOperations.Commands.Create;
using MovieStore.Application.MovieOperations.Commands.Delete;
using MovieStore.Application.MovieOperations.Commands.Update;
using MovieStore.Application.MovieOperations.Queries.GetAll;
using MovieStore.Application.MovieOperations.Queries.GetDetail;
using MovieStore.DBOperations;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext context;
        private readonly IMapper mapper;
        public MovieController(IMovieStoreDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new GetMoviesQuery(context, mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetMovieDetail(int id)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(context, mapper);
            query.Id = id;
            GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieModel newMovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(context, mapper);

            command.Model = newMovie;
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateMovie([FromBody] UpdateMovieModel updateMovie, int id)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(context);
            command.Model = updateMovie;
            command.Id = id;
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(context);

            command.Id = id;
            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
