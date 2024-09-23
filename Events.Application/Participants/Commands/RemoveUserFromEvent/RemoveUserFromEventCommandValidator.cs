using FluentValidation;

namespace Events.Application.Participants.Commands.RemoveUserFromEvent
{
    public class RemoveUserFromEventCommandValidator : AbstractValidator<RemoveUserFromEventCommand>
    {
        public RemoveUserFromEventCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.EventId).NotEmpty();
        }
    }
}
