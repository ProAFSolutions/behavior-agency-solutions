using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }
    }
}
