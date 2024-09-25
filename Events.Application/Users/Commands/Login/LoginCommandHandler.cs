using AutoMapper;
using Events.Application.Common.Providers;
using Events.Domain.Abstractions;
using MediatR;

namespace Events.Application.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        public LoginCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IJwtProvider jwtProvider)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken token)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email, token);

            if (user is null)
                throw new InvalidOperationException("Invalid credentials");

            string jwt = _jwtProvider.GenerateJwt(user);
            string refresh = _jwtProvider.GenerateRefreshToken();

            user.RefreshToken = refresh;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(1);

            await _userRepository.UpdateAsync(user, token);
            await _unitOfWork.SaveChangesAsync(token);

            return new() { JwtToken = jwt, RefreshToken = refresh};
        }
    }
}
