using FluentValidation;

namespace MovieStore.Application.CustomerOperations.Commands.Delete
{
    public class DeleteCustomerCommandValidator:AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator() {
            RuleFor(command=>command.Id).NotEmpty();
        }
    }
}
