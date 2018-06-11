using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class Agency
    {
        public Agency()
        {
            AgencyUsers = new HashSet<AgencyUsers>();
            Document = new HashSet<Document>();
            DocumentType = new HashSet<DocumentType>();
        }

        public int AgencyId { get; set; }
        public int? AddressId { get; set; }
        [Required]
        [StringLength(50)]
        public string AgencyName { get; set; }
        [Column(TypeName = "image")]
        public byte[] AgencyLogo { get; set; }
        public string DropBoxClientId { get; set; }
        public string DropBoxClientSecret { get; set; }
        public string GoogleClientId { get; set; }
        public string GoogleClientSecret { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("Agency")]
        public Address Address { get; set; }
        [InverseProperty("Agency")]
        public ICollection<AgencyUsers> AgencyUsers { get; set; }
        [InverseProperty("Agency")]
        public ICollection<Document> Document { get; set; }
        [InverseProperty("Agency")]
        public ICollection<DocumentType> DocumentType { get; set; }
    }
}
