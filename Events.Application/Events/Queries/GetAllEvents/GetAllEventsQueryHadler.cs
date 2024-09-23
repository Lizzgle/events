using AutoMapper;
using Events.Application.Common;
using Events.Application.Common.DTOs.EventDTO;
using Events.Application.Common.DTOs.UserDTO;
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
    public class GetAllEventsQueryHadler : IRequestHandler<GetAllEventsQuery, PaginatedResult<EventDTO>>
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

        public async Task<PaginatedResult<EventDTO>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Event> query = await _eventRepository.GetAllAsync(cancellationToken);
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
