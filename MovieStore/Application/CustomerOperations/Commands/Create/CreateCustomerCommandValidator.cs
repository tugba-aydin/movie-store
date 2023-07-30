using FluentValidation;

namespace MovieStore.Application.CustomerOperations.Commands.Create
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(command=>command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(2);
        }
    }
}
