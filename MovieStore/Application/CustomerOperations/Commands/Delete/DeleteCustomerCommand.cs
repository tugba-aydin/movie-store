using MovieStore.DBOperations;
using System;
using System.Linq;

namespace MovieStore.Application.CustomerOperations.Commands.Delete
{
    public class DeleteCustomerCommand
    {
        private readonly IMovieStoreDbContext dbContext;
        public int Id { get; set; }

        public DeleteCustomerCommand(IMovieStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Handle()
        {
            var customer = dbContext.Customers.Where(x => x.Id == Id).FirstOrDefault();
            if (customer == null) throw new InvalidOperationException("Müşteri bulunamadı");

            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();
        }
    }
}
