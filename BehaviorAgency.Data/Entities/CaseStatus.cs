using System;
using System.Collections.Generic;

namespace BehaviorAgency.Data.Entities
{
    public partial class CaseStatus
    {
        public CaseStatus()
        {
            Case = new HashSet<Case>();
        }

        public int StatusId { get; set; }
        public string Status { get; set; }

        public ICollection<Case> Case { get; set; }
    }
}
