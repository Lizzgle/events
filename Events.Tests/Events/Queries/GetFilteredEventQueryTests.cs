using AutoMapper;
using Events.Application.Common.DTOs;
using Events.Application.Common.Mapper.EventMapping;
using Events.Application.Common.Models;
using Events.Application.Events.Queries.GetFilteredEvent;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Moq;

namespace Events.Tests.Events.Queries
{
    public class GetFilteredEventQueryTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;
        private readonly Mock<IEventRepository> _eventRepositoryMock;

        public GetFilteredEventQueryTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _eventRepositoryMock = new Mock<IEventRepository>();

            _unitOfWorkMock.Setup(u => u.eventRepository)
                       .Returns(_eventRepositoryMock.Object);

            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<EventToEventDTO>())
                .CreateMapper();
        }

        [Fact]
        public async Task Handle_Should_ReturnFirstPage_WhenPageNoEqual1()
        {
            //Arrange
            _eventRepositoryMock.Setup(
                r => r.GetAllAsync(
                        It.IsAny<CancellationToken>()))
                        .Returns(Task.FromResult(Events.AsQueryable())!);

            int pageSize = 2;
            int pageNo = 1;
            DateTime date = DateTime.Parse("2024-12-12");

            GetFilteredEventQuery query = new GetFilteredEventQuery { Date = date, PageSize = pageSize, PageNumber = pageNo };

            GetFilteredEventQueryHandler handler = new(_mapper, _unitOfWorkMock.Object);

            //Act
            PaginatedResult<EventDTO> result = await handler.Handle(query, default);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Items);
            Assert.True(result.PageSize >= result.Items.Count());
            Assert.Equal(result.PageSize, pageSize);
        }


        private static Event[] Events => [
            new()
            {
                Id = Guid.Parse("93e1c56f-09f4-491b-bca7-59d96c23adce"),
                Name = "TestName 1",
                Description = "TestDescription 1",
                DateTime = DateTime.Parse("2024-12-12"),
                Location = "TestLocation 1",
                Category = Category.Conference,
                MaxParticipants = 10,
            },
            new()
            {
                Id = Guid.Parse("4750af4b-b267-40c0-8ea7-33cf59566601"),
                Name = "TestName 2",
                Description = "TestDescription 2",
                DateTime = DateTime.Parse("2025-01-01"),
                Location = "TestLocation 2",
                Category = Category.Concert,
                MaxParticipants = 10,
            }];
    }
}