using AutoMapper;
using Events.Application.Common.DTOs;
using Events.Application.Common.Mapper.EventMapping;
using Events.Application.Events.Queries.GetEventByName;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Moq;

namespace Events.Tests.Events.Queries
{
    public class GetEventByNameQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;
        private readonly Mock<IEventRepository> _eventRepositoryMock;

        public GetEventByNameQueryHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _eventRepositoryMock = new Mock<IEventRepository>();

            _unitOfWorkMock.Setup(u => u.eventRepository)
                       .Returns(_eventRepositoryMock.Object);

            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<EventToEventDTO>())
                .CreateMapper();
        }

        [Fact]
        public async Task Handle_ShouldReturnEvent()
        {
            // Arrange
            Guid id = Guid.Parse("ae86d955-a260-49ba-bf48-4d2ca7d44853");
            string name = "Test Event";

            Event eventDb = new Event()
            {
                Id = id,
                Name = name,
                Description = "Test Description",
                Location = "Test Location",
                DateTime = DateTime.Parse("2024-12-12"),
                Category = Category.Conference,
                MaxParticipants = 10,
                UriImage = ""
            };
            _eventRepositoryMock.Setup(
                r => r.GetEventByNameAsync(name, It.IsAny<CancellationToken>()))
                            .ReturnsAsync(eventDb);

            GetEventByNameQuery query = new GetEventByNameQuery { Name = name };

            GetEventByNameQueryHandler handler = new GetEventByNameQueryHandler(_mapper, _unitOfWorkMock.Object);

            // Act
            EventDTO result = await handler.Handle(query, default);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);

            _eventRepositoryMock.Verify(
                r => r.GetEventByNameAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
