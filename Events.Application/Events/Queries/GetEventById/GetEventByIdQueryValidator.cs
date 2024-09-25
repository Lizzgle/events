using FluentValidation;

namespace Events.Application.Events.Queries.GetEventById
{
    public class GetEventByIdQueryValidator : AbstractValidator<GetEventByIdQuery>
    {
        public GetEventByIdQueryValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
