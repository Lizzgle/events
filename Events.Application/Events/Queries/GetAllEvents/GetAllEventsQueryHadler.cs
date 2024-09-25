using AutoMapper;
using Events.Application.Common.DTOs;
using Events.Application.Common.Models;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;

namespace Events.Application.Events.Queries.GetAllEvents
{
    public class GetAllEventsQueryHadler : IRequestHandler<GetAllEventsQuery, PaginatedResult<EventDTO>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetAllEventsQueryHadler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _eventRepository = unitOfWork.eventRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<EventDTO>> Handle(GetAllEventsQuery request, CancellationToken token)
        {
            IQueryable<Event> query = await _eventRepository.GetAllAsync(token);
            int count = query.Count();

            List<Event> events = query
                .OrderBy(u => u.Id)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

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
