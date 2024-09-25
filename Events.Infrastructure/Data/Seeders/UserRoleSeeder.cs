using Events.Domain.Entities;
using Events.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.Data.Seeders
{
    public static class UserRoleSeeder
    {

        public static void SeedUserRole(this EntityTypeBuilder<UserRole> builder)
        {

            builder.HasData(
                new UserRole() 
                {
                    UserId = Guid.Parse("b643dbc3-41cf-4834-9519-04b24df72ea2"),
                    RoleId = Role.Admin.Id,
                },
                //new UserRole()
                //{
                //    UserId = Guid.Parse("b643dbc3-41cf-4834-9519-04b24df72ea2"),
                //    RoleId = Role.Client.Id,
                //},
                new UserRole()
                {
                    UserId = Guid.Parse("b7a2e030-0a08-4bfa-b2b6-343cde02c23f"),
                    RoleId = Role.Admin.Id,
                },
                new UserRole()
                {
                    UserId = Guid.Parse("fa6a3ae0-9ca2-44a5-aa08-0f510af78f87"),
                    RoleId = Role.Client.Id,
                });
        }
    }
}
