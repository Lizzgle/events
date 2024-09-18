using AutoMapper;
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
    public class GetEventsByCriteriaHandler : IRequestHandler<GetEventsByCriteria, IEnumerable<EventDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        public GetEventsByCriteriaHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _eventRepository = unitOfWork.Events;
        }
        async Task<IEnumerable<EventDTO>> IRequestHandler<GetEventsByCriteria, IEnumerable<EventDTO>>.Handle(
            GetEventsByCriteria request, CancellationToken cancellationToken)
        {
            IQueryable<Event> query = await _eventRepository.GetEventsByCriteria(request.Date, request.Category, 
                request.Location, cancellationToken);

            if (query is null)
                throw new KeyNotFoundException($"Event with filters {request.Date} {request.Category} {request.Location} not found");

            return _mapper.Map<IEnumerable<EventDTO>>(query);
        }
    }
}
