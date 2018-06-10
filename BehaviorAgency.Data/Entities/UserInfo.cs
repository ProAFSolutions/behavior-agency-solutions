using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            AgencyUsers = new HashSet<AgencyUsers>();
            DocumentApprovedByNavigation = new HashSet<Document>();
            DocumentRejectedByNavigation = new HashSet<Document>();
            DocumentReviewedByNavigation = new HashSet<Document>();
            DocumentUser = new HashSet<Document>();
        }

        [Key]
        public int UserId { get; set; }
        [StringLength(450)]
        public string AspNetUserId { get; set; }
        public int? AddressId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(1)]
        public string Sex { get; set; }
        [Column("DOB", TypeName = "date")]
        public DateTime? Dob { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Mobile { get; set; }
        [StringLength(50)]
        public string SecondaryPhone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("UserInfo")]
        public Address Address { get; set; }
        [InverseProperty("User")]
        public UserSettings UserSettings { get; set; }
        [InverseProperty("User")]
        public ICollection<AgencyUsers> AgencyUsers { get; set; }
        [InverseProperty("ApprovedByNavigation")]
        public ICollection<Document> DocumentApprovedByNavigation { get; set; }
        [InverseProperty("RejectedByNavigation")]
        public ICollection<Document> DocumentRejectedByNavigation { get; set; }
        [InverseProperty("ReviewedByNavigation")]
        public ICollection<Document> DocumentReviewedByNavigation { get; set; }
        [InverseProperty("User")]
        public ICollection<Document> DocumentUser { get; set; }
    }
}
