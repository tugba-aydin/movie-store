using FluentValidation;

namespace MovieStore.Application.MovieOperations.Commands.Delete
{
    public class DeleteMovieCommandValidator:AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
