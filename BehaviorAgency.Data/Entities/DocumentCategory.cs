using System;
using System.Collections.Generic;

namespace BehaviorAgency.Data.Entities
{
    public partial class DocumentCategory
    {
        public DocumentCategory()
        {
            Document = new HashSet<Document>();
            DocumentType = new HashSet<DocumentType>();
        }

        public int DocCategoryId { get; set; }
        public string DocCategoryName { get; set; }

        public ICollection<Document> Document { get; set; }
        public ICollection<DocumentType> DocumentType { get; set; }
    }
}
