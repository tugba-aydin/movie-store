using FluentValidation;
using MovieStore.Application.DirectorOperations.Commands.Create;

namespace MovieStore.Application.CastOperations.Commands.Create
{
    public class CreateDirectorCommandValidator:AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(command=>command.Model.Name).NotEmpty();
            RuleFor(command=>command.Model.Surname).NotEmpty().MinimumLength(2);
        }
    }
}
