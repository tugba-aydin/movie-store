using FluentValidation;

namespace MovieStore.Application.CastOperations.Queries.GetDetail
{
    public class GetCastDetailQueryValidator:AbstractValidator<GetCastDetailQuery>
    {
        public GetCastDetailQueryValidator()
        {
            RuleFor(query=>query.Id).NotEmpty();
        }
    }
}
