using FluentValidation;

namespace MovieStore.Application.CastOperations.Commands.Update
{
    public class UpdateCastCommandValidator:AbstractValidator<UpdateCastCommand>
    {
        public UpdateCastCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().GreaterThan(0);
        }
    }
}
