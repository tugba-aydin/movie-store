using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.CastOperations.Commands.Create;
using MovieStore.Application.CastOperations.Commands.Delete;
using MovieStore.Application.CustomerOperations.Commands.Create;
using MovieStore.Application.CustomerOperations.Commands.Delete;
using MovieStore.DBOperations;
using MovieStore.Entities;
using System.Linq;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext context;
        private readonly IMapper mapper;
        public CustomerController(IMovieStoreDbContext _context, IMapper _apper)
        {
            context = _context;
            mapper = _apper;
        }

        [HttpPost]
        public IActionResult AddCast([FromBody] CreateCustomerModel newAuthor)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(context, mapper);

            command.Model = newAuthor;
            CreateCustomerCommandValidator validator= new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(context);

            command.Id = id;
            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
