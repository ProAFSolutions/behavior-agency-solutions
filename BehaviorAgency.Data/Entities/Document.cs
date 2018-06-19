using System;
using System.Collections.Generic;

namespace BehaviorAgency.Data.Entities
{
    public partial class Document
    {
        public int DocId { get; set; }
        public int DocTypeId { get; set; }
        public int DocCategoryId { get; set; }
        public int UserId { get; set; }
        public int DocStatusId { get; set; }
        public string DocName { get; set; }
        public string DocPath { get; set; }
        public string DocFormat { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? ReviewedBy { get; set; }
        public DateTime? ReviewedOn { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public int? RejectedBy { get; set; }
        public DateTime? RejectedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public UserInfo ApprovedByNavigation { get; set; }
        public DocumentCategory DocCategory { get; set; }
        public DocumentStatus DocStatus { get; set; }
        public DocumentType DocType { get; set; }
        public UserInfo RejectedByNavigation { get; set; }
        public UserInfo ReviewedByNavigation { get; set; }
        public UserInfo User { get; set; }
    }
}
