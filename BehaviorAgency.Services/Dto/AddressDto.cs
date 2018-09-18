using BehaviorAgency.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviorAgency.Services.Dto
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }

        public AddressDto() { }

        public AddressDto(Address address) {
            Id = address.AddressId;
            Street = address.Address1;
            Address2 = address.Address2;
            City = address.City;
            ZipCode = address.ZipCode;
            State = address.State;
            CountryCode = address.CountryCode;
        }
    }
}
