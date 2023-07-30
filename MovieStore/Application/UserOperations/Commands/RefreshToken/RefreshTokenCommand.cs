using Microsoft.Extensions.Configuration;
using MovieStore.DBOperations;
using MovieStore.Entities;
using MovieStore.TokenOperations;
using MovieStore.TokenOperations.Models;
using System;
using System.Linq;

namespace MovieStore.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        private readonly IMovieStoreDbContext context;
        private readonly IConfiguration configuration;
        public string RefreshToken;
        public RefreshTokenCommand(IMovieStoreDbContext _context, IConfiguration _configuration)
        {
            context = _context;

            configuration = _configuration;
        }

        public Token Handle()
        {
            User user = context.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpirationDate > DateTime.Now);
            if (user is not null)
            {

                TokenHandler tokenHandler = new TokenHandler(configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpirationDate = token.Expiration.AddMinutes(5);
                context.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Valid Refresh Token Bulunamadı");
            }
        }
    }
}
