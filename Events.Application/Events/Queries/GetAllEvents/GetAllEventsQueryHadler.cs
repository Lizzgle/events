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

namespace Events.Application.Events.Queries.GetAllEvents
{
    public class GetAllEventsQueryHadler : IRequestHandler<GetAllEventsQuery, IEnumerable<EventDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetAllEventsQueryHadler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _eventRepository = unitOfWork.Events;
            _mapper = mapper;
        }
        async Task<IEnumerable<EventDTO>> IRequestHandler<GetAllEventsQuery, IEnumerable<EventDTO>>.Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Event> query = await _eventRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<EventDTO>>(query);

        }
    }
}
