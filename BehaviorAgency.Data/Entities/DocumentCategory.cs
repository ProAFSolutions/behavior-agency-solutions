using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class DocumentCategory
    {
        public DocumentCategory()
        {
            DocumentType = new HashSet<DocumentType>();
        }

        [Key]
        public int DocCategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string DocCategoryName { get; set; }

        [InverseProperty("DocCategory")]
        public ICollection<DocumentType> DocumentType { get; set; }
    }
}
