using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class Document : IAuditable
    {
        [Key]
        public int DocId { get; set; }
        public int DocTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string DocName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }

        [ForeignKey("DocTypeId")]
        [InverseProperty("Document")]
        public DocumentType DocType { get; set; }
    }
}
