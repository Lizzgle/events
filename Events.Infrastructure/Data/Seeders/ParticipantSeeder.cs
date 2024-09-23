using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Infrastructure.Data.Seeders
{
    public static class ParticipantSeeder 
    {
        public static void SeedParticipants(this EntityTypeBuilder<Participant> participantConfBuilder)
        {
            participantConfBuilder.HasData([
               new Participant()
                {
                    Id = Guid.Parse("281a55a2-57ef-4731-a4dd-3130d17f19c5"),
                    UserId = Guid.Parse("b643dbc3-41cf-4834-9519-04b24df72ea2"),
                    EventId = Guid.Parse("298a2e93-ffdd-4e4e-bf48-5a9a56aa572c"),
                    DateOfRegistration = DateTime.UtcNow
                    
               },
               new Participant()
               {
                    Id = Guid.Parse("2ccf13e8-0485-4f7c-80df-b2ff125a3a82"),
                    UserId = Guid.Parse("b643dbc3-41cf-4834-9519-04b24df72ea2"),
                    EventId = Guid.Parse("67ce57c8-6b3e-467b-8716-e1d4ab408dad"),
                    DateOfRegistration = DateTime.UtcNow

               },
               new Participant()
                {
                    Id = Guid.Parse("17df8d8e-85e4-4487-95fc-dd32704e6ba0"),
                    UserId = Guid.Parse("fa6a3ae0-9ca2-44a5-aa08-0f510af78f87"),
                    EventId = Guid.Parse("298a2e93-ffdd-4e4e-bf48-5a9a56aa572c"),
                    DateOfRegistration = DateTime.UtcNow

                }
                ]);
        }
    }
}
