using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviorAgency.Data.Entities
{
    public interface IAuditable
    {
        DateTime? CreatedOn { get; set; }
        int? CreatedBy { get; set; }
        DateTime? LastModifiedOn { get; set; }
        int? LastModifiedBy { get; set; }
    }
}
