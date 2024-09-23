using AutoMapper;
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
    public class GetUserEventsQueryHandler : IRequestHandler<GetUserEventsQuery, UserDTO>
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

        public async Task<UserDTO> Handle(GetUserEventsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user is null)
                throw new InvalidOperationException("User not found");

            var events = await _userRepository.GetUserEvents(user.Id, cancellationToken);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
