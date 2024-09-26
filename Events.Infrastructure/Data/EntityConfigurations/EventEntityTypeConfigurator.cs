using Events.Domain.Entities;
using Events.Infrastructure.Data.Models;
using Events.Infrastructure.Data.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.Data.EntityConfigurations
{
    public class EventEntityTypeConfigurator : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");
            builder.HasKey(e => e.Id);

            builder.Property(e  => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(1000);
            builder.Property(e => e.DateTime).IsRequired();
            builder.Property(e => e.Location).IsRequired().HasMaxLength(200);
            builder.Property(e => e.MaxParticipants).IsRequired();

            builder
                .HasMany(e => e.Users)
                .WithMany(u => u.Events)
                .UsingEntity<Participant>(ep => ep.SeedParticipants());


            builder.SeedEvents();
        }
    }
}
