using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class UserSettings
    {
        [Key]
        public int UserId { get; set; }
        public bool? NotifyDocExpiration { get; set; }
        public bool? SendReminders { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("UserSettings")]
        public UserInfo User { get; set; }
    }
}
