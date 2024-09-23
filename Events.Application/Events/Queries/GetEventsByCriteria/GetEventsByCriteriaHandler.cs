using AutoMapper;
using Events.Application.Common;
using Events.Application.Common.DTOs.EventDTO;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Events.Queries.GetEventsByCriteria
{
    public class GetEventsByCriteriaHandler : IRequestHandler<GetEventsByCriteria, PaginatedResult<EventDTOWithoutParticipants>>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        public GetEventsByCriteriaHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _eventRepository = unitOfWork.Events;
        }

        public async Task<PaginatedResult<EventDTOWithoutParticipants>> Handle(GetEventsByCriteria request, CancellationToken cancellationToken)
        {
            IQueryable<Event> query = await _eventRepository.GetEventsByCriteria(request.Date, request.Category,
                request.Location, cancellationToken);

            if (query is null)
                throw new KeyNotFoundException($"Event with filters {request.Date} {request.Category} {request.Location} not found");

            var count = query.Count();
            var events = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

            return new()
            {
                Items = _mapper.Map<IEnumerable<EventDTOWithoutParticipants>>(events),
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = (int)Math.Ceiling(count / (double)request.PageSize)
            };
        }
    }
}
