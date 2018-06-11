using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehaviorAgency.Data.Entities
{
    public partial class Case
    {
        public int CaseId { get; set; }
        public int CustomerId { get; set; }
        public int? RbtId { get; set; }
        public int? AnalystId { get; set; }
        public int StatusId { get; set; }
        [Required]
        [StringLength(50)]
        public string CaseNumber { get; set; }
        [StringLength(50)]
        public string PolicyNumber { get; set; }
        [StringLength(50)]
        public string SecondaryPolicyNumber { get; set; }
        [StringLength(50)]
        public string Insurer { get; set; }
        [StringLength(50)]
        public string SecondInsurer { get; set; }
        [StringLength(50)]
        public string MedicaidNumber { get; set; }
        public int? HoursApproved { get; set; }
        [StringLength(50)]
        public string AdministeredLanguage { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey("AnalystId")]
        [InverseProperty("CaseAnalyst")]
        public UserInfo Analyst { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("Case")]
        public CustomerInfo Customer { get; set; }
        [ForeignKey("RbtId")]
        [InverseProperty("CaseRbt")]
        public UserInfo Rbt { get; set; }
        [ForeignKey("StatusId")]
        [InverseProperty("Case")]
        public CaseStatus Status { get; set; }
    }
}
