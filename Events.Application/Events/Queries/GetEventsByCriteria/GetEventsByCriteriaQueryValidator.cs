using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Events.Queries.GetEventsByCriteria
{
    public class GetEventsByCriteriaQueryValidator : AbstractValidator<GetEventsByCriteria>
    {

        public GetEventsByCriteriaQueryValidator()
        {
            RuleFor(x => x.Date).GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Location).MaximumLength(100);

            RuleFor(x => x.PageNumber).GreaterThan(0);
            RuleFor(x => x.PageSize).GreaterThan(0);
        }
    }
}
