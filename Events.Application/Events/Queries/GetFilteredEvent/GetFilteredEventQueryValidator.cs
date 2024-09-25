using FluentValidation;

namespace Events.Application.Events.Queries.GetFilteredEvent
{
    public class GetFilteredEventQueryValidator : AbstractValidator<GetFilteredEventQuery>
    {

        public GetFilteredEventQueryValidator()
        {
            RuleFor(x => x.Date).GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Location).MaximumLength(100);

            RuleFor(x => x.PageNumber).GreaterThan(0);
            RuleFor(x => x.PageSize).GreaterThan(0);
        }
    }
}
