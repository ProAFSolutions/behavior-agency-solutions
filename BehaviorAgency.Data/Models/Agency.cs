using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Models
{
    public partial class Agency
    {
        public int AgencyId { get; set; }
        [Required]
        [StringLength(50)]
        public string AgencyName { get; set; }
        [Column(TypeName = "image")]
        public byte[] AgencyLogo { get; set; }
        [Required]
        [StringLength(50)]
        public string Address1 { get; set; }
        [StringLength(50)]
        public string Address2 { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string ZipCode { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
    }
}
