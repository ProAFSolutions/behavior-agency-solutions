using BehaviorAgency.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BehaviorAgency.Services.Dto
{
    public class CustomerDto : IDtoEntityMapper<CustomerInfo>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Language { get; set; }
        public bool? Multilingual { get; set; }
        public AddressDto Address { get; set; }

        private readonly CustomerInfo _entity;

        public CustomerDto(){ }

        public CustomerDto(CustomerInfo customer)
        {
            _entity = customer;
        }

        #region Mappers
        public CustomerInfo MapToEntity()
        {
            return _entity ?? new CustomerInfo
            {

            };
        }

        public void MapFromEntity()
        {
            Id = _entity.CustomerId;
            Name = _entity.CustomerName;
            LastName = _entity.CustomerLastName;
            Language = _entity.NaturalLanguage;
            Multilingual = _entity.Multilingual;
            Address = new AddressDto(_entity.Address);
        }
        #endregion

        #region Updates

        public bool Set(CustomerDto newDto)
        {
            bool wasUpdated = SetName(newDto.Name) ||
                              SetLastName(newDto.LastName) ||
                              SetLanguage(newDto.Language) ||
                              SetMultilingual(newDto.Multilingual.HasValue ? newDto.Multilingual.Value : false);

            return wasUpdated;
        }

        public bool SetName(string name)
        {
            if (Name != name)
            {
                _entity.CustomerName = name;
                Name = name;
                return true;
            }
            return false;
        }

        public bool SetLastName(string lastName)
        {
            if (LastName != lastName)
            {
                _entity.CustomerLastName = lastName;
                LastName = lastName;
                return true;
            }
            return false;
        }

        public bool SetLanguage(string lan)
        {
            if (Language != lan)
            {
                _entity.NaturalLanguage = lan;
                Language = lan;
                return true;
            }
            return false;
        }

        public bool SetMultilingual(bool multi)
        {
            if (Multilingual != multi)
            {
                _entity.Multilingual = multi;
                Multilingual = multi;
                return true;
            }
            return false;
        }

        #endregion
    }
}
