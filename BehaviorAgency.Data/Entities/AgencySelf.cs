using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class AgencySelf
    {
        [Key]
        public int IdServAgencyId { get; set; }
        [Required]
        [StringLength(50)]
        public string AgencyName { get; set; }
        [Column(TypeName = "image")]
        public byte[] AgencyLogo { get; set; }
    }
}
