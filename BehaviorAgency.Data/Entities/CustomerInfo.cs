using System;
using System.Collections.Generic;

namespace BehaviorAgency.Data.Entities
{
    public partial class CustomerInfo
    {
        public CustomerInfo()
        {
            Case = new HashSet<Case>();
        }

        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string NaturalLanguage { get; set; }
        public bool? Multilingual { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public Address Address { get; set; }
        public ICollection<Case> Case { get; set; }
    }
}
