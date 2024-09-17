using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().Length(1, 100);
            RuleFor(x => x.Description).NotEmpty().Length(1, 1000);
            RuleFor(x => x.DateTime).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Address).NotEmpty().Length(1, 100);
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.MaxParticipants).NotEmpty().GreaterThan(0);
        }

    }
}
