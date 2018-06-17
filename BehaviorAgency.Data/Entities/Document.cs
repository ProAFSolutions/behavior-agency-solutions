using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class Document
    {
        [Key]
        public int DocId { get; set; }
        public int DocTypeId { get; set; }
        public int DocCategoryId { get; set; }
        public int UserId { get; set; }
        public int DocStatusId { get; set; }
        [Required]
        [StringLength(50)]
        public string DocName { get; set; }
        [Required]
        public string DocPath { get; set; }
        [StringLength(50)]
        public string DocFormat { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }
        public int? ReviewedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReviewedOn { get; set; }
        public int? ApprovedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApprovedOn { get; set; }
        public int? RejectedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RejectedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey("ApprovedBy")]
        [InverseProperty("DocumentApprovedByNavigation")]
        public UserInfo ApprovedByNavigation { get; set; }
        [ForeignKey("DocCategoryId")]
        [InverseProperty("Document")]
        public DocumentCategory DocCategory { get; set; }
        [ForeignKey("DocStatusId")]
        [InverseProperty("Document")]
        public DocumentStatus DocStatus { get; set; }
        [ForeignKey("DocTypeId")]
        [InverseProperty("Document")]
        public DocumentType DocType { get; set; }
        [ForeignKey("RejectedBy")]
        [InverseProperty("DocumentRejectedByNavigation")]
        public UserInfo RejectedByNavigation { get; set; }
        [ForeignKey("ReviewedBy")]
        [InverseProperty("DocumentReviewedByNavigation")]
        public UserInfo ReviewedByNavigation { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("DocumentUser")]
        public UserInfo User { get; set; }
    }
}
