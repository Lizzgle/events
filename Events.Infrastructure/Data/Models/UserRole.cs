using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Infrastructure.Data.Models
{
    public class UserRole
    {
        public Guid UserId { get; init; }
        public int RoleId { get; init; }
    }
}
