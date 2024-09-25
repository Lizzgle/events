using FluentValidation;

namespace Events.Application.Events.Queries.GetEventByIdWithParticipants
{
    public class GetParticipantsByEventIdQueryValidator : AbstractValidator<GetParticipantsByEventIdQuery>
    {
        public GetParticipantsByEventIdQueryValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.PageNumber).GreaterThan(0);
            RuleFor(x => x.PageSize).GreaterThan(0);

        }

    }
}
