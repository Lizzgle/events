using FluentValidation;

namespace Events.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
        }


    }
}
