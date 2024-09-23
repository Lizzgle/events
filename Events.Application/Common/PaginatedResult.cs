using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Common
{
    public class PaginatedResult<T>
    {
        public required IEnumerable<T> Items { get; init; }

        public required int CurrentPage { get; init; }

        public required int TotalPages { get; init; }

        public required int PageSize { get; init; }
    }
}
