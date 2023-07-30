using FluentValidation;

namespace MovieStore.Application.CastOperations.Commands.Create
{
    public class CreateCastCommandValidator:AbstractValidator<CreateCastCommand>
    {
        public CreateCastCommandValidator()
        {
            RuleFor(command=>command.Model.Name).NotEmpty().NotNull();
            RuleFor(command=>command.Model.Surname).NotEmpty().NotNull();
        }
    }
}
