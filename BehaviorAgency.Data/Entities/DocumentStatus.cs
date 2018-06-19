using System;
using System.Collections.Generic;

namespace BehaviorAgency.Data.Entities
{
    public partial class DocumentStatus
    {
        public DocumentStatus()
        {
            Document = new HashSet<Document>();
        }

        public int DocStatus { get; set; }
        public string Status { get; set; }

        public ICollection<Document> Document { get; set; }
    }
}
