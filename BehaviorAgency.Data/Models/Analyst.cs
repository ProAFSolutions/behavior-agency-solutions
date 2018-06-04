using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Models
{
    public partial class Analyst
    {
        public int AnalystId { get; set; }
        [Required]
        [StringLength(50)]
        public string AnalystName { get; set; }
        [Required]
        [StringLength(50)]
        public string AnalystLastName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
