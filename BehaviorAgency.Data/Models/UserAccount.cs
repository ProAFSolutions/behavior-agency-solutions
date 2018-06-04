using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Models
{
    public partial class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(10)]
        public string Password { get; set; }
        [StringLength(50)]
        public string ProviderName { get; set; }
        [StringLength(50)]
        public string ProviderSubjectId { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("UserAccount")]
        public User User { get; set; }
    }
}
