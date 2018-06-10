using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class AgencyUsers
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public int UserId { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey("AgencyId")]
        [InverseProperty("AgencyUsers")]
        public Agency Agency { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("AgencyUsers")]
        public UserInfo User { get; set; }
    }
}
