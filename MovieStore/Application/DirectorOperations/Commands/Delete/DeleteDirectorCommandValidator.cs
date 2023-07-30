using FluentValidation;

namespace MovieStore.Application.DirectorOperations.Commands.Delete
{
    public class DeleteDirectorCommandValidator:AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(command=>command.Id).NotEmpty().GreaterThan(0);
        }
    }
}
