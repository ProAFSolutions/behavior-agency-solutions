using System;
using System.Collections.Generic;

namespace BehaviorAgency.Data.Entities
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            CaseAnalyst = new HashSet<Case>();
            CaseRbt = new HashSet<Case>();
            DocumentApprovedByNavigation = new HashSet<Document>();
            DocumentRejectedByNavigation = new HashSet<Document>();
            DocumentReviewedByNavigation = new HashSet<Document>();
            DocumentUser = new HashSet<Document>();
        }

        public int UserId { get; set; }
        public string IdServUserId { get; set; }
        public int? AddressId { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string SecondaryPhone { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public Address Address { get; set; }
        public UserSettings UserSettings { get; set; }
        public ICollection<Case> CaseAnalyst { get; set; }
        public ICollection<Case> CaseRbt { get; set; }
        public ICollection<Document> DocumentApprovedByNavigation { get; set; }
        public ICollection<Document> DocumentRejectedByNavigation { get; set; }
        public ICollection<Document> DocumentReviewedByNavigation { get; set; }
        public ICollection<Document> DocumentUser { get; set; }
    }
}
