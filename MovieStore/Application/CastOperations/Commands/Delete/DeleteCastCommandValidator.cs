using FluentValidation;

namespace MovieStore.Application.CastOperations.Commands.Delete
{
    public class DeleteCastCommandValidator:AbstractValidator<DeleteCastCommand>
    {
        public DeleteCastCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
