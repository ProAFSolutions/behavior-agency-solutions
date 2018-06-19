using System;
using System.Collections.Generic;

namespace BehaviorAgency.Data.Entities
{
    public partial class Case
    {
        public int CaseId { get; set; }
        public int CustomerId { get; set; }
        public int? RbtId { get; set; }
        public int? AnalystId { get; set; }
        public int StatusId { get; set; }
        public string CaseNumber { get; set; }
        public string PolicyNumber { get; set; }
        public string SecondaryPolicyNumber { get; set; }
        public string Insurer { get; set; }
        public string SecondInsurer { get; set; }
        public string MedicaidNumber { get; set; }
        public int? HoursApproved { get; set; }
        public string AdministeredLanguage { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }

        public UserInfo Analyst { get; set; }
        public CustomerInfo Customer { get; set; }
        public UserInfo Rbt { get; set; }
        public CaseStatus Status { get; set; }
    }
}
