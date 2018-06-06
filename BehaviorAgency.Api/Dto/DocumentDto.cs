using BehaviorAgency.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BehaviorAgency.Api.Dto
{
    public class DocumentDto
    {
        public int DocId { get; set; }
        public int DocTypeId { get; set; }
        public string DocName { get; set; }

        public DocumentDto(Document doc) {
            DocId = doc.DocId;
            DocName = doc.DocName;
            DocTypeId = doc.DocTypeId;
        }

    }
}
