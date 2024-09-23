using AutoMapper;
using Events.Application.Common;
using Events.Application.Common.DTOs.EventDTO;
using Events.Application.Common.DTOs.ParticipantDTO;
using Events.Application.Common.DTOs.UserDTO;
using Events.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Users.Queries.GetUserEvents
{
    public class GetUserEventsQueryHandler : IRequestHandler<GetUserEventsQuery, PaginatedResult<EventDTOWithoutParticipants>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public GetUserEventsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.Users;
        }

        public async Task<PaginatedResult<EventDTOWithoutParticipants>> Handle(GetUserEventsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user is null)
                throw new InvalidOperationException("User not found");

            var query = await _userRepository.GetUserEvents(user.Id, cancellationToken);
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
