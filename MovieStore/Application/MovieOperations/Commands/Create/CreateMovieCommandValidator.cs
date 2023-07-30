using FluentValidation;
using System;

namespace MovieStore.Application.MovieOperations.Commands.Create
{
    public class CreateMovieCommandValidator:AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.Year).NotNull();
            RuleFor(command => command.Model.Price).GreaterThan(0);
        }
    }
}
