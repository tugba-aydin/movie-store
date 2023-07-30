using FluentValidation;

namespace MovieStore.Application.MovieOperations.Queries.GetDetail
{
    public class GetMovieDetailQueryValidator:AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
