using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Common.Providers
{
    public interface IJwtProvider
    {
        public string GenerateJwt(User user);

        public string GenerateRefreshToken();

        public ClaimsPrincipal? GetClaimsPrincipal(string token);
    }
}
