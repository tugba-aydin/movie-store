using FluentValidation;

namespace MovieStore.Application.MovieOperations.Commands.Update
{
    public class UpdateMovieCommandValidator:AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command => command.Model.Price).GreaterThan(0);
        }
    }
}
