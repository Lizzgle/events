using Events.Domain.Entities;
using Events.Infrastructure.Data.Models;
using Events.Infrastructure.Data.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.Data.EntityConfigurations
{
    public class UserEntityTypeConfigurator : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Surname).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(255);
            builder.Property(u => u.DateOfBirth).IsRequired();


            builder.HasMany(u => u.Roles).WithMany()
                            .UsingEntity<UserRole>(ur => ur.SeedUserRole());

            builder.SeedUsers();
        }
    }
}
