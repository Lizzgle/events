using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.Data.Seeders
{
    public static class EventSeeder
    {
        public static void SeedEvents(this EntityTypeBuilder<Event> eventConfBuilder)
        {
            eventConfBuilder.HasData([
                new Event()
                {
                    Id = Guid.Parse("82c68eb8-89ca-41d3-9cc2-4c1aacc06318"),
                    Name = "Экология везде",
                    Description = "Мероприятия в честь строительства нового мусоросжигательного завода",
                    DateTime = DateTime.Parse("12.12.2024 18:30"),
                    Location = "Минск",
                    CategoryId = Category.Conference.Id,
                    //Category = Category.Conference,
                    MaxParticipants = 40,
                    UriImage = ""
                },
                new Event()
                {
                    Id = Guid.Parse("67ce57c8-6b3e-467b-8716-e1d4ab408dad"),
                    Name = "Полумарафон",
                    Description = "Есть различные дистанции: 5км, 10.5км, 21км",
                    DateTime = DateTime.Parse("01.11.2024 10:00"),
                    Location = "Стадион Динамо",
                    CategoryId = Category.Sports.Id,
                    //Category = Category.Sports,
                    MaxParticipants = 10000,
                    UriImage = ""
                },
                new Event()
                {
                    Id = Guid.Parse("298a2e93-ffdd-4e4e-bf48-5a9a56aa572c"),
                    Name = "Viva Braslav",
                    Description = "Фестиваль проходит в течение 3-ёх дней на Браславских озерах.",
                    DateTime = DateTime.Parse("28.07.2025 14:00"),
                    Location = "Браслав",
                    CategoryId = Category.Festival.Id,
                    //Category = Category.Festival,
                    MaxParticipants = 3,
                    UriImage = ""
                }
                ]);
        }
    }
}
