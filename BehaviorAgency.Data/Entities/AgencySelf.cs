using System;
using System.Collections.Generic;

namespace BehaviorAgency.Data.Entities
{
    public partial class AgencySelf
    {
        public int IdServAgencyId { get; set; }
        public string AgencyName { get; set; }
        public byte[] AgencyLogo { get; set; }
    }
}
