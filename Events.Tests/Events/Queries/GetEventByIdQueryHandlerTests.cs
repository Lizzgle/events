using AutoMapper;
using Events.Application.Common.DTOs;
using Events.Application.Common.Mapper.EventMapping;
using Events.Application.Events.Queries.GetEventById;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Events.Domain.Enums;
using Moq;

namespace Events.Tests.Events.Queries
{
    public class GetEventByIdQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;
        private readonly Mock<IEventRepository> _eventRepositoryMock;

        public GetEventByIdQueryHandlerTests()
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

            Event eventDb = new Event()
            {
                Id = id,
                Name = "Test Event",
                Description = "Test Description",
                Location = "Test Location",
                DateTime = DateTime.Parse("2024-12-12"),
                Category = Category.Conference,
                MaxParticipants = 10,
                UriImage = ""
            };
            _eventRepositoryMock.Setup(
                r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
                            .ReturnsAsync(eventDb);

            GetEventByIdQuery query = new GetEventByIdQuery { Id = id };

            GetEventByIdQueryHandler handler = new GetEventByIdQueryHandler(_unitOfWorkMock.Object, _mapper);

            // Act
            EventDTO result = await handler.Handle(query, default);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);

            _eventRepositoryMock.Verify(
                r => r.GetByIdAsync(
                    It.IsAny <Guid>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
