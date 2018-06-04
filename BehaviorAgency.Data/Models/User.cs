using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        public string Mobile { get; set; }
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
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [InverseProperty("User")]
        public UserAccount UserAccount { get; set; }
    }
}
