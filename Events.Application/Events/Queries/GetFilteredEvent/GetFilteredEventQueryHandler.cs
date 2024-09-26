using AutoMapper;
using Events.Application.Common.DTOs;
using Events.Application.Common.Models;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;
using System.Linq;

namespace Events.Application.Events.Queries.GetFilteredEvent
{
    public class GetFilteredEventQueryHandler : IRequestHandler<GetFilteredEventQuery, PaginatedResult<EventDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        public GetFilteredEventQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _eventRepository = unitOfWork.eventRepository;
        }

        public async Task<PaginatedResult<EventDTO>> Handle(GetFilteredEventQuery request, CancellationToken token)
        {
            IQueryable<Event> query = await _eventRepository.GetAllAsync(token);
            
            if (!string.IsNullOrEmpty(request.Location))
            {
                query = query.Where(x => x.Location == request.Location);
            }

            if (request.Date.HasValue)
            {
                query = query.Where(x => x.DateTime.Date == request.Date);
            }

            if (!string.IsNullOrEmpty(request.CategoryName))
            {
                query = query.Where(x => x.Category.Name == request.CategoryName);
            }

            if (query is null)
                throw new KeyNotFoundException($"Event with filters {request.Date} {request.CategoryName} {request.Location} not found");

            var count = query.Count();
            var events = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

            return new()
            {
                Items = _mapper.Map<IEnumerable<EventDTO>>(events),
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = (int)Math.Ceiling(count / (double)request.PageSize)
            };
        }
    }
}
