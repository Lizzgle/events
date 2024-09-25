using FluentValidation;

namespace Events.Application.Users.Queries.GetUserEvents
{
    public class GetUserEventsQueryValidator : AbstractValidator<GetUserEventsQuery>
    {
        public GetUserEventsQueryValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.PageSize).GreaterThan(0);
            RuleFor(x => x.PageNumber).GreaterThan(0);
        }

    }
}
