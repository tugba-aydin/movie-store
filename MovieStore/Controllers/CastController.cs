using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.CastOperations.Commands.Create;
using MovieStore.Application.CastOperations.Commands.Delete;
using MovieStore.Application.CastOperations.Commands.Update;
using MovieStore.Application.CastOperations.Queries.GetAll;
using MovieStore.Application.CastOperations.Queries.GetDetail;
using MovieStore.DBOperations;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly IMovieStoreDbContext context;
        private readonly IMapper mapper;
        public CastController(IMovieStoreDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetCasts()
        {
            GetCastQuery query = new GetCastQuery(context, mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetCastDetail(int id)
        {
            GetCastDetailQuery query = new GetCastDetailQuery(context, mapper);
            query.Id = id;
            GetCastDetailQueryValidator validator = new GetCastDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddCast([FromBody] CreateCastModel newCast)
        {
            CreateCastCommand command = new CreateCastCommand(context, mapper);

            command.Model = newCast;
            CreateCastCommandValidator validator = new CreateCastCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCast([FromBody] UpdateCastModel updateCast, int id)
        {
            UpdateCastCommand command = new UpdateCastCommand(context);
            command.Model = updateCast;
            command.Id = id;
            UpdateCastCommandValidator validator = new UpdateCastCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCast(int id)
        {
            DeleteCastCommand command = new DeleteCastCommand(context);

            command.Id = id;
            DeleteCastCommandValidator validator = new DeleteCastCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
