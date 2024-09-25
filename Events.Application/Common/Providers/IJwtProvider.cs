using Events.Domain.Entities;
using System.Security.Claims;

namespace Events.Application.Common.Providers
{
    public interface IJwtProvider
    {
        public string GenerateJwt(User user);

        public string GenerateRefreshToken();

        public ClaimsPrincipal? GetClaimsPrincipal(string token);
    }
}
