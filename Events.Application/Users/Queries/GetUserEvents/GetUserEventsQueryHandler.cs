using AutoMapper;
using Events.Application.Common.DTOs;
using Events.Application.Common.Models;
using Events.Domain.Abstractions;
using MediatR;

namespace Events.Application.Users.Queries.GetUserEvents
{
    public class GetUserEventsQueryHandler : IRequestHandler<GetUserEventsQuery, PaginatedResult<EventDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public GetUserEventsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userRepository = unitOfWork.userRepository;
        }

        public async Task<PaginatedResult<EventDTO>> Handle(GetUserEventsQuery request, CancellationToken token)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, token);
            if (user is null)
                throw new InvalidOperationException("User not found");

            var query = await _userRepository.GetUserEventsAsync(user.Id, token);

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
