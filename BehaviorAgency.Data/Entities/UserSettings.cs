using System;
using System.Collections.Generic;

namespace BehaviorAgency.Data.Entities
{
    public partial class UserSettings
    {
        public int UserId { get; set; }
        public bool? NotifyDocExpiration { get; set; }
        public bool? SendReminders { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }

        public UserInfo User { get; set; }
    }
}
