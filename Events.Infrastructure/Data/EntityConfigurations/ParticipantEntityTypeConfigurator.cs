using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.Data.EntityConfigurations
{
    public class ParticipantEntityTypeConfigurator : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable("Participants");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.EventId).IsRequired();
          
        }
    }
}
