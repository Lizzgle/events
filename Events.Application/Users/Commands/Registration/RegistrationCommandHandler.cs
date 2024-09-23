using AutoMapper;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Users.Commands.Registration
{
    internal class RegistrationCommandHandler : IRequestHandler<RegistrationCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public RegistrationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.Users;
        }

        public async Task Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request);
            
            await _userRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
