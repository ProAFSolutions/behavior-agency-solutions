using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class DocumentType : IAuditable
    {
        public DocumentType()
        {
            Document = new HashSet<Document>();
        }

        [Key]
        public int DocTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string DocTypeName { get; set; }
        [Column(TypeName = "text")]
        public string DocTypeDesc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }

        [InverseProperty("DocType")]
        public ICollection<Document> Document { get; set; }
    }
}
