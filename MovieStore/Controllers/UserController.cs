using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieStore.Application.UserOperations.Commands.Create;
using MovieStore.Application.UserOperations.Commands.CreateToken;
using MovieStore.Application.UserOperations.Commands.RefreshToken;
using MovieStore.DBOperations;
using MovieStore.TokenOperations.Models;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMovieStoreDbContext context;
        readonly IMapper mapper;
        readonly IConfiguration configuration;
        public UserController(IMovieStoreDbContext _context, IConfiguration _configuration, IMapper _mapper)
        {
            context = _context;
            configuration = _configuration;
            mapper = _mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(context, mapper);
            command.Model = newUser;
            command.Handle();

            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> Login([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(context, mapper, configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(context, configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }
    }
}
