using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class DocumentType
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
        public int DocCategoryId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey("DocCategoryId")]
        [InverseProperty("DocumentType")]
        public DocumentCategory DocCategory { get; set; }
        [InverseProperty("DocType")]
        public ICollection<Document> Document { get; set; }
    }
}
