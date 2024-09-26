using AutoMapper;
using Events.Application.Events.Commands.CreateEvent;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Events.Domain.Enums;
using Moq;

namespace Events.Tests.Events.Commands
{
    public class CreateEventCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IEventRepository> _eventRepositoryMock;
        private readonly IMapper _mapper;

        public CreateEventCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _eventRepositoryMock = new Mock<IEventRepository>();
            MapperConfiguration conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateEventCommand, Event>();
            });
            _mapper = conf.CreateMapper();

            _unitOfWorkMock.Setup(u => u.eventRepository)
                       .Returns(_eventRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateEvent()
        {
            // Arrange
            Guid id = Guid.Parse("ae86d955-a260-49ba-bf48-4d2ca7d44853");

            CreateEventCommand command = new CreateEventCommand
            {
                Name = "Test Event",
                Description = "Test Description",
                Location = "Test Location",
                DateTime = DateTime.Parse("2024-12-12"),
                Category = Category.Conference,
                MaxParticipants = 10,
                UriImage = ""
            };
            
            _eventRepositoryMock.Setup(
                r => r.CreateAsync(
                    It.IsNotNull<Event>(),
                    It.IsAny<CancellationToken>()));

            CreateEventCommandHandler handler = new(_unitOfWorkMock.Object, _mapper);

            // Act
            await handler.Handle(command, default);

            // Assert
            _eventRepositoryMock.Verify(
                r => r.CreateAsync(
                    It.Is<Event>(e => e.Name == command.Name &&
                                     e.Description == command.Description &&
                                     e.Location == command.Location &&
                                     e.DateTime == command.DateTime &&
                                     e.Category == command.Category &&
                                     e.MaxParticipants == command.MaxParticipants &&
                                     e.UriImage == command.UriImage),
                    It.IsAny<CancellationToken>()), Times.Once);

            
        }            
    }
}
