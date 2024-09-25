using Events.Domain.Entities;
using Events.Infrastructure.Data.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.Data.EntityConfigurations
{
    public class RoleEntityTypeConfigurator : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).IsRequired().HasMaxLength(50);

            builder.SeedRoles();
        }
    }
}
