using System;
using System.Collections.Generic;

namespace BehaviorAgency.Data.Entities
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Document = new HashSet<Document>();
        }

        public int DocTypeId { get; set; }
        public string DocTypeName { get; set; }
        public string DocTypeDesc { get; set; }
        public int DocCategoryId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public DocumentCategory DocCategory { get; set; }
        public ICollection<Document> Document { get; set; }
    }
}
