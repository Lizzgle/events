using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Common.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public IDictionary<string, string[]> ValidationErrors { get; }

        public ValidationErrorException()
                : base("One or more validation failures have occurred.")
        {
            ValidationErrors = new Dictionary<string, string[]>();
        }

        public ValidationErrorException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            ValidationErrors = failures
                .GroupBy(validationFailure => validationFailure.PropertyName, validationFailure => validationFailure.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
