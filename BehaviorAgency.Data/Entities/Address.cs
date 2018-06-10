using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class Address
    {
        public Address()
        {
            Agency = new HashSet<Agency>();
            CustomerInfo = new HashSet<CustomerInfo>();
            UserInfo = new HashSet<UserInfo>();
        }

        public int AddressId { get; set; }
        [Required]
        [StringLength(50)]
        public string Address1 { get; set; }
        [StringLength(50)]
        public string Address2 { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }
        [StringLength(3)]
        public string CountryCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [InverseProperty("Address")]
        public ICollection<Agency> Agency { get; set; }
        [InverseProperty("Address")]
        public ICollection<CustomerInfo> CustomerInfo { get; set; }
        [InverseProperty("Address")]
        public ICollection<UserInfo> UserInfo { get; set; }
    }
}
