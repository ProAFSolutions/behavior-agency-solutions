using System;
using System.Collections.Generic;

namespace BehaviorAgency.Data.Entities
{
    public partial class Address
    {
        public Address()
        {
            CustomerInfo = new HashSet<CustomerInfo>();
            UserInfo = new HashSet<UserInfo>();
        }

        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<CustomerInfo> CustomerInfo { get; set; }
        public ICollection<UserInfo> UserInfo { get; set; }
    }
}
