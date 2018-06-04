using BehaviorAgency.Data.Models;
using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BehaviorAgency.IdentityServer.Data
{
    public class IdentityServerUser
    {
        public string SubjectId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public List<Claim> Claims { get; set; }

        public IdentityServerUser(UserAccount account) {
            SubjectId = account.UserId.ToString();
            Username = account.UserName;
            Password = account.Password;
            Claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Name, account.User.Name),
                new Claim(JwtClaimTypes.GivenName, account.User.LastName),
                new Claim(JwtClaimTypes.Email, account.User.Email),
                new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                new Claim(JwtClaimTypes.PhoneNumber, account.User.Mobile),
                new Claim(JwtClaimTypes.PhoneNumberVerified, "false", ClaimValueTypes.Boolean),
            };
        }

    }
}
