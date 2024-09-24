using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Infrastructure.Data.Seeders
{
    public static class RoleSeeder
    {
        public static void SeedRoles(this EntityTypeBuilder<Role> builder)
        {
            builder.HasData([Role.Admin, Role.Client]);
        }
    }
}
