using Events.Application.Common.Services;
using Events.Application.Events.Commands.AddImage;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Moq;

namespace Events.Tests.Events.Commands
{
    public class AddImageCommandTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IImageService> _imageService;
        private readonly Mock<IImageService> _imageServiceMock;
        private readonly Mock<IEventRepository> _eventRepositoryMock;
        private readonly AddImageCommandHandler _handler;

        public AddImageCommandTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _eventRepositoryMock = new Mock<IEventRepository>();
            _imageServiceMock = new Mock<IImageService>();

            _unitOfWorkMock.Setup(u => u.eventRepository)
                       .Returns(_eventRepositoryMock.Object);
            _imageService = new Mock<IImageService>();
            _handler = new AddImageCommandHandler(_unitOfWorkMock.Object, _imageServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldAddImage()
        {
            // Arrange
            var eventId = Guid.NewGuid();
            var command = new AddImageCommand
            {
                Id = eventId,
                FileName = "test-image.jpg",
                ImageStream = new MemoryStream()
            };

            var dbEvent = new Event
            {
                Id = eventId,
                UriImage = "old-image-path.jpg"
            };

            _eventRepositoryMock.Setup(r => r.GetByIdAsync(eventId, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(dbEvent);
            _imageServiceMock.Setup(s => s.SaveImageAsync(command.ImageStream, command.FileName, dbEvent.UriImage, It.IsAny<CancellationToken>()))
                             .ReturnsAsync("new-image-path.jpg");

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _eventRepositoryMock.Verify(r => r.UpdateAsync(dbEvent, It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal("new-image-path.jpg", dbEvent.UriImage);
        }
    }
}
