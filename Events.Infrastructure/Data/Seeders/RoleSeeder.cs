using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
