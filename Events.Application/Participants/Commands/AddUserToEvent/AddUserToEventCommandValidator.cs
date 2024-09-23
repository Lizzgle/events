using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
