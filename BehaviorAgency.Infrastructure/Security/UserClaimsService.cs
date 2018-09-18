using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BehaviorAgency.Infrastructure.Security
{

    public interface IUserClaimsService
    {
        List<Claim> GetUserClaims();

        string GetClaimValue(string name);
    }

    public class UserClaimsService : IUserClaimsService
    {
        private readonly HttpContext _httpContext;

        public UserClaimsService(IHttpContextAccessor httpContextAccessor) {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public List<Claim> GetUserClaims()
        {
            var principal = _httpContext.User as ClaimsPrincipal;

            if (principal == null || principal.Claims == null || principal.Claims.ToList().Count == 0)
                throw new UnauthorizedAccessException("Unauthorized access");

            return principal.Claims.ToList();
        }

        public string GetClaimValue(string name)
        {
            var claim = GetUserClaims().SingleOrDefault(c => c.Type == name);

            return claim?.Value;
        }

    }
}
