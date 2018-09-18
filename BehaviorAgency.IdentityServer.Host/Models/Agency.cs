using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BehaviorAgency.IdentityServer.Host.Models
{
    public class Agency
    {
        public string AgencyCode { get; set; }
        public string Name { get; set; }
        public ICollection<ApplicationUserAgency> AgencyUsers { get; set; }

        public Agency() { }
    }
}
