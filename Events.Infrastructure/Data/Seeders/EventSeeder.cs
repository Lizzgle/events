using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Infrastructure.Data.Seeders
{
    public static class EventSeeder
    {
        public static void SeedEvents(this EntityTypeBuilder<Event> eventConfBuilder)
        {
            eventConfBuilder.HasData([
                new Event()
                {
                    Id = Guid.Parse("35F010ED-8C38-4EEB-B9EC-5FB56CCF3189"),
                    Name = "Экология везде",
                    Description = "Мероприятия в честь строительства нового мусоросжигательного завода",
                    DateTime = DateTime.Parse("12.12.2024 18:30"),
                    Location = "Минск",
                    Category = Category.Conference,
                    MaxParticipants = 40,
                    UriImage = ""
                },
                new Event()
                {
                    Id = Guid.Parse("34F010ED-8C38-4EEB-B9EC-5FB56CCF3189"),
                    Name = "Полумарафон",
                    Description = "Есть различные дистанции: 5км, 10.5км, 21км",
                    DateTime = DateTime.Parse("01.11.2024 10:00"),
                    Location = "Стадион Динамо",
                    Category = Category.Sports,
                    MaxParticipants = 10000,
                    UriImage = ""
                },
                new Event()
                {
                    Id = Guid.Parse("33F010ED-8C38-4EEB-B9EC-5FB56CCF3189"),
                    Name = "Viva Braslav",
                    Description = "Фестиваль проходит в течение 3-ёх дней на Браславских озерах.",
                    DateTime = DateTime.Parse("28.07.2025 14:00"),
                    Location = "Браслав",
                    Category = Category.Festival,
                    MaxParticipants = 100000,
                    UriImage = ""
                }
                ]);
        }
    }
}
