using AutoMapper;
using MovieStore.DBOperations;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MovieStore.Application.CustomerOperations.Commands.Create
{
    public class CreateCustomerCommand
    {
        public CreateCustomerModel Model { get; set; }
        private readonly IMovieStoreDbContext dbContext;
        private readonly IMapper mapper;
        public CreateCustomerCommand(IMovieStoreDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper =_mapper;
        }
        public void Handle()
        {
            var customer = dbContext.Customers.Where(b => b.Name == Model.Name && b.Surname == Model.Surname).FirstOrDefault();
            if (customer != null) throw new InvalidOperationException("Müşteri zaten mevcut");
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }
    }

    public class CreateCustomerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
