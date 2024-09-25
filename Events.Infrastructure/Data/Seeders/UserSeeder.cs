using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Infrastructure.Data.Seeders
{
    public static class UserSeeder
    {
        public static void SeedUsers(this EntityTypeBuilder<User> userConfBuilder)
        {
            userConfBuilder.HasData([
                new User()
                {
                    Id = Guid.Parse("b643dbc3-41cf-4834-9519-04b24df72ea2"),
                    Name = "Елизавета",
                    Surname = "Глебцова",
                    Email = "lizaglebtsova@gmail.com",
                    DateOfBirth = DateTime.Parse("08.09.2003"),
                    Events = new List<Event>()
                },
                new User()
                {
                    Id = Guid.Parse("fa6a3ae0-9ca2-44a5-aa08-0f510af78f87"),
                    Name = "Бобик",
                    Surname = "Иванов",
                    Email = "bobicivanov@gmail.com",
                    DateOfBirth = DateTime.Parse("16.04.2000"),
                    Events = new List<Event>()
                },
                new User()
                {
                    Id = Guid.Parse("b7a2e030-0a08-4bfa-b2b6-343cde02c23f"),
                    Name = "Юлия",
                    Surname = "Сидорова",
                    Email = "yuliasidorova@gmail.com",
                    DateOfBirth = DateTime.Parse("11.08.2005"),
                    Events = new List<Event>()
                },
                ]);
        }
    }
}
