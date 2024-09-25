using FluentValidation;

namespace Events.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().Length(1, 100);
            RuleFor(x => x.Description).NotEmpty().Length(1, 1000);
            RuleFor(x => x.DateTime).NotEmpty().GreaterThanOrEqualTo(DateTime.UtcNow);
            RuleFor(x => x.Location).NotEmpty().Length(1, 100);
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.MaxParticipants).NotEmpty().GreaterThan(0);
        }

    }
}
