using FluentValidation;

namespace Events.Application.Participants.Commands.AddUserToEvent
{
    public class AddUserToEventCommandValidator : AbstractValidator<AddUserToEventCommand>
    {
        public AddUserToEventCommandValidator()
        {
            RuleFor(x => x.EventId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.DateOfRegistration).NotEmpty();

        }
    }
}
