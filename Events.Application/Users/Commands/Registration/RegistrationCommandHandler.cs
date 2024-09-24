using AutoMapper;
using Events.Application.Common.Providers;
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
    internal class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, RegistrationCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        public RegistrationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IJwtProvider jwtProvider)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.Users;
            _jwtProvider = jwtProvider;
        }

        public async Task Hand1le(RegistrationCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request);
            
            await _userRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<RegistrationCommandResponse> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request);

            user.Roles.Add(Role.Client);
            await _userRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            string jwt = _jwtProvider.GenerateJwt(user);
            string refresh = _jwtProvider.GenerateRefreshToken();

            user.RefreshToken = refresh;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(1);

            await _userRepository.UpdateAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new() { JwtToken = jwt, RefreshToken = refresh };
        }
    }
}
