using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Models
{
    public partial class Rbt
    {
        public int RbtId { get; set; }
        [Required]
        [StringLength(50)]
        public string RbtName { get; set; }
        [Required]
        [StringLength(50)]
        public string RbtLastName { get; set; }
    }
}
