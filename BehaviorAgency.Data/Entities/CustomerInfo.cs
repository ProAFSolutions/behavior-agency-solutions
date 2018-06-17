using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class CustomerInfo
    {
        public CustomerInfo()
        {
            Case = new HashSet<Case>();
        }

        [Key]
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerLastName { get; set; }
        [StringLength(20)]
        public string NaturalLanguage { get; set; }
        public bool? Multilingual { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("CustomerInfo")]
        public Address Address { get; set; }
        [InverseProperty("Customer")]
        public ICollection<Case> Case { get; set; }
    }
}
