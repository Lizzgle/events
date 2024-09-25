using FluentValidation;

namespace Events.Application.Events.Queries.GetAllEvents
{
    public class GetAllEventsQueryValidator : AbstractValidator<GetAllEventsQuery>
    {
        public GetAllEventsQueryValidator() 
        {
            RuleFor(x => x.PageNumber).GreaterThan(0);
            RuleFor(x => x.PageSize).GreaterThan(0);
        }

    }
}
