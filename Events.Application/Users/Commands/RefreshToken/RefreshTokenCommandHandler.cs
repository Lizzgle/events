using Events.Application.Common.Exceptions;
using Events.Application.Common.Providers;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;
using System.Security.Claims;

namespace Events.Application.Users.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtProvider _jwtProvider;

        public RefreshTokenCommandHandler(IJwtProvider jwtProvider,
                                            IUserRepository userRepository,
                                            IUnitOfWork unitOfWork)
        {
            _jwtProvider = jwtProvider;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal = _jwtProvider.GetClaimsPrincipal(request.Jwt);

            Claim? id = principal?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (id is null || !Guid.TryParse(id.Value, out Guid guidId))
            {
                throw new InvalidTokenException("Invalid data in token");
            }

            User? dbUser = await _userRepository.GetByIdAsync(guidId, cancellationToken);

            if (dbUser is null)
                throw new KeyNotFoundException("Invalid User from token");

            if (dbUser.RefreshToken is null
                    || dbUser.RefreshToken != request.RefreshToken
                    || dbUser.RefreshTokenExpiry < DateTime.UtcNow)
            {
                dbUser.RefreshToken = null;
                dbUser.RefreshTokenExpiry = null;

                await _userRepository.UpdateAsync(dbUser, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                throw new InvalidTokenException("Refresh token is not valid");
            }

            string jwt = _jwtProvider.GenerateJwt(dbUser);

            return new() { Jwt = jwt, RefreshToken = dbUser.RefreshToken! };
        }
    }
}
