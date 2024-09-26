using AutoMapper;
using Events.Application.Events.Commands.UpdateEvent;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Moq;

namespace Events.Tests.Events.Commands
{
    public class UpdateEventCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IEventRepository> _eventRepositoryMock;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _eventRepositoryMock = new Mock<IEventRepository>();
            MapperConfiguration conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UpdateEventCommand, Event>();
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

            UpdateEventCommand command = new UpdateEventCommand
            {
                Name = "Test Event",
                Description = "Test Description",
                Location = "Test Location",
                DateTime = DateTime.Parse("2024-12-12"),
                Category = Category.Conference,
                MaxParticipants = 10
            };

            UpdateEventCommandHandler handler = new(_unitOfWorkMock.Object, _mapper);

            // Act
            Func<Task> action = () => handler.Handle(command, default);

            // Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(action);
        }
    }
}
