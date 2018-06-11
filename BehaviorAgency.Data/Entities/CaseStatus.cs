using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class CaseStatus
    {
        public CaseStatus()
        {
            Case = new HashSet<Case>();
        }

        [Key]
        public int StatusId { get; set; }
        [StringLength(10)]
        public string Status { get; set; }

        [InverseProperty("Status")]
        public ICollection<Case> Case { get; set; }
    }
}
