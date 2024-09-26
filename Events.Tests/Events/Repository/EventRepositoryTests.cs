using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Events.Domain.Enums;
using Events.Infrastructure;
using Events.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Events.Tests.Events.Repository
{
    public class EventRepositoryTests
    {
        private readonly ApplicationDbContext _context;

        public EventRepositoryTests()
        {
            DbContextOptions options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
             .Options;

            _context = new ApplicationDbContext(options);
        }

        private List<Event> SeedTestData()
        {
            var events = new List<Event>()
            {
                new Event
                {
                    Id = Guid.Parse("93e1c56f-09f4-491b-bca7-59d96c23adce"),
                    Name = "TestName 1",
                    Description = "TestDescription 1",
                    DateTime = DateTime.Parse("2024-12-12"),
                    Location = "TestLocation 1",
                    Category = Category.Conference,
                    MaxParticipants = 10,
                },
                new Event
                {
                    Id = Guid.Parse("4750af4b-b267-40c0-8ea7-33cf59566601"),
                    Name = "TestName 2",
                    Description = "TestDescription 2",
                    DateTime = DateTime.Parse("2025-01-01"),
                    Location = "TestLocation 2",
                    Category = Category.Concert,
                    MaxParticipants = 10,
                }
            };
            _context.Events.AddRange(events);
            _context.SaveChanges();

            return events;
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllEvents()
        {
            //Arrange
            SeedTestData();

            IEventRepository eventRepository = new EventRepository(_context);

            //Act
            IQueryable<Event> dbevents = await eventRepository.GetAllAsync();

            //Assert
            Assert.NotEmpty(dbevents);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsEventById()
        {
            //Arrange
            List<Event> events = SeedTestData();
            Event eventDb = events.First();

            IEventRepository eventRepository = new EventRepository(_context);

            //Act
            Event eventById = await eventRepository.GetByIdAsync(eventDb.Id);

            //Assert
            Assert.Equal(eventDb.Id, eventById.Id);
            Assert.Equal(eventDb.Name, eventById.Name);
            Assert.Equal(eventDb.Description, eventById.Description);
            Assert.Equal(eventDb.DateTime, eventById.DateTime);
            Assert.Equal(eventDb.Location, eventById.Location);
            Assert.Equal(eventDb.Category, eventById.Category);
            Assert.Equal(eventDb.MaxParticipants, eventById.MaxParticipants);
        }

        [Fact]
        public async Task CreateAsync_CreatesEvent()
        {
            //Arrange
            Event testevent = new()
            {
                Id = Guid.Parse("93e1c56f-09f4-491b-bca7-59d96c23adce"),
                Name = "TestName 1",
                Description = "TestDescription 1",
                DateTime = DateTime.Parse("2024-12-12"),
                Location = "TestLocation 1",
                Category = Category.Conference,
                MaxParticipants = 10,
            };

            IEventRepository eventRepository = new EventRepository(_context);

            //Act
            await eventRepository.CreateAsync(testevent);
            await _context.SaveChangesAsync();

            //Assert
            Event dbevent = await eventRepository.GetByIdAsync(testevent.Id);
            Assert.Equal(testevent.Id, dbevent.Id);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesEvent()
        {
            //Arrange
            List<Event> events = SeedTestData();
            Event eventDb = events.First();

            IEventRepository eventRepository = new EventRepository(_context);

            //Act
            eventDb.Name = "Updated TestName 1";
            await eventRepository.UpdateAsync(eventDb);
            await _context.SaveChangesAsync();

            //Assert
            Event updatedEvent = await eventRepository.GetByIdAsync(eventDb.Id);
            Assert.Equal("Updated TestName 1", updatedEvent.Name);
        }

        [Fact]
        public async Task DeleteAsync_RemovesEvent()
        {
            //Arrange
            List<Event> events = SeedTestData();
            Event eventDb = events.First();

            IEventRepository eventRepository = new EventRepository(_context);

            //Act
            await eventRepository.DeleteAsync(eventDb);
            await _context.SaveChangesAsync();

            //Assert
            Event deletedEvent = await eventRepository.GetByIdAsync(eventDb.Id);
            Assert.Null(deletedEvent);
        }

        [Fact]
        public async Task GetByNameAsync_ReturnsEventsByName()
        {
            //Arrange
            SeedTestData();

            IEventRepository eventRepository = new EventRepository(_context);

            //Act
            Event dbevent = await eventRepository.GetEventByNameAsync("TestName 1");

            //Assert
            Assert.Equal("TestName 1", dbevent.Name);
            Assert.Equal("TestDescription 1", dbevent.Description);
            Assert.Equal(DateTime.Parse("2024-12-12"), dbevent.DateTime);
            Assert.Equal("TestLocation 1", dbevent.Location);
            Assert.Equal(Category.Conference, dbevent.Category);
            Assert.Equal(10, dbevent.MaxParticipants);
        }

        [Fact]
        public async Task CountOfParticipantsAsync_ReturnsCountOfParticipants()
        {
            //Arrange
            List<Event> events = SeedTestData();
            Event eventDb = events.First();

            IEventRepository eventRepository = new EventRepository(_context);

            //Act
            int countOfParticipants = await eventRepository.CountOfParticipantsAsync(eventDb.Id);

            //Assert
            Assert.Equal(0, countOfParticipants);
        }
    }
}
