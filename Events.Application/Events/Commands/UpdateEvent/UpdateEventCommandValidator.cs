using FluentValidation;

namespace Events.Application.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.DateTime).NotEmpty().GreaterThanOrEqualTo(DateTime.UtcNow);
            RuleFor(x => x.Location).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.MaxParticipants).NotEmpty().GreaterThan(0);

        }
    }
}
