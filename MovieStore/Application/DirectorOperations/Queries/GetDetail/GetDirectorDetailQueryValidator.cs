using FluentValidation;

namespace MovieStore.Application.DirectorOperations.Queries.GetDetail
{
    public class GetDirectorDetailQueryValidator:AbstractValidator<GetDirectorDetailQuery>
    {
        public GetDirectorDetailQueryValidator()
        {
            RuleFor(query=>query.Id).NotEmpty().GreaterThan(0);
        }
    }
}
