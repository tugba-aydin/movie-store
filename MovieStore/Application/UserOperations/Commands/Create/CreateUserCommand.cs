using AutoMapper;
using MovieStore.DBOperations;
using MovieStore.Entities;
using System;
using System.Linq;

namespace MovieStore.Application.UserOperations.Commands.Create
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IMovieStoreDbContext context;
        private readonly IMapper mapper;
        public CreateUserCommand(IMovieStoreDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public void Handle()
        {
            var user = context.Users.SingleOrDefault(x => x.Email == Model.Email);

            if (user is not null)
                throw new InvalidOperationException("Kullanıcı zaten kayıtlı");

            user = mapper.Map<User>(Model);
            context.Users.Add(user);
            context.SaveChanges();
        }
    }

    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
