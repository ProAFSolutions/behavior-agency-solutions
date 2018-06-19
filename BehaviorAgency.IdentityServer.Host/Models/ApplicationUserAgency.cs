using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BehaviorAgency.IdentityServer.Host.Models
{
    public class ApplicationUserAgency
    {
        public string UserId { get; set; }

        public string AgencyCode { get; set; }

        public ApplicationUser User { get; set; }

        public Agency Agency { get; set; }
    }
}
