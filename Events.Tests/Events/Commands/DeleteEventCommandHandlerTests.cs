using Events.Application.Events.Commands.DeleteEvent;
using Events.Domain.Abstractions;
using Moq;

namespace Events.Tests.Events.Commands
{
    public class DeleteEventCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IEventRepository> _eventRepositoryMock;

        public DeleteEventCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _eventRepositoryMock = new Mock<IEventRepository>();

            _unitOfWorkMock.Setup(u => u.eventRepository)
                       .Returns(_eventRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateEvent()
        {
            // Arrange
            DeleteEventCommand command = new DeleteEventCommand
            {
                Id = Guid.Parse("ae86d955-a260-49ba-bf48-4d2ca7d44853"),

            };

            DeleteEventCommandHandler handler = new(_unitOfWorkMock.Object);

            // Act
            Func<Task> action = () => handler.Handle(command, default);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(action);
        }
    }
}
