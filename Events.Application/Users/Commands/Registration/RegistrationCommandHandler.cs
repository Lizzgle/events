using AutoMapper;
using Events.Application.Common.Providers;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;

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
            _userRepository = unitOfWork.userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<RegistrationCommandResponse> Handle(RegistrationCommand request, CancellationToken token)
        {
            User user = _mapper.Map<User>(request);

            
            await _userRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync(token);
            
            user.Roles.Add(Role.Client);
            
            string jwt = _jwtProvider.GenerateJwt(user);
            string refresh = _jwtProvider.GenerateRefreshToken();

            user.RefreshToken = refresh;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(1);

            await _userRepository.UpdateAsync(user, token);
            await _unitOfWork.SaveChangesAsync(token);

            return new() { JwtToken = jwt, RefreshToken = refresh };
        }
    }
}
