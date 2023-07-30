using AutoMapper;
using Microsoft.Extensions.Configuration;
using MovieStore.DBOperations;
using MovieStore.Entities;
using MovieStore.TokenOperations;
using MovieStore.TokenOperations.Models;
using Newtonsoft.Json.Linq;
using System.Linq;


namespace MovieStore.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        private readonly IMovieStoreDbContext context;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        public CreateTokenModel Model;
        public CreateTokenCommand(IMovieStoreDbContext _context, IMapper _mapper, IConfiguration _configuration)
        {
            context = _context;
            mapper = _mapper;
            configuration = _configuration;
        }

        public Token Handle()
        {
            User user = context.Users.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (user is not null)
            {
                //Token üretiliyor.
                TokenHandler handler =new TokenHandler(configuration);
                Token token = handler.CreateAccessToken(user);

                //Refresh token Users tablosuna işleniyor.
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpirationDate = token.Expiration.AddMinutes(5);
                context.SaveChanges();

                return token;
            }
            return null;
        }
    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
