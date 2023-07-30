using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.CastOperations.Commands.Create;
using MovieStore.Application.CastOperations.Commands.Delete;
using MovieStore.Application.CastOperations.Commands.Update;
using MovieStore.Application.CastOperations.Queries.GetAll;
using MovieStore.Application.CastOperations.Queries.GetDetail;
using MovieStore.Application.DirectorOperations.Commands.Create;
using MovieStore.Application.DirectorOperations.Commands.Delete;
using MovieStore.Application.DirectorOperations.Commands.Update;
using MovieStore.Application.DirectorOperations.Queries.GetAll;
using MovieStore.Application.DirectorOperations.Queries.GetDetail;
using MovieStore.DBOperations;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private readonly IMovieStoreDbContext context;
        private readonly IMapper mapper;
        public DirectoryController(IMovieStoreDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetDirectors()
        {
            GetDirectorsQuery query = new GetDirectorsQuery(context, mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetDirectorDetail(int id)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(context, mapper);
            query.Id = id;
            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddDirector([FromBody] CreateDirectorModel newDirector)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(context, mapper);

            command.Model = newDirector;
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateDirector([FromBody] UpdateDirectorModel updateDirector, int id)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(context);
            command.Model = updateDirector;
            command.Id = id;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(context);

            command.Id = id;
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
