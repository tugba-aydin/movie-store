using FluentValidation;

namespace MovieStore.Application.DirectorOperations.Commands.Update
{
    public class UpdateDirectorCommandValidator:AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(command=>command.Id).NotEmpty().GreaterThan(0);
        }
    }
}
