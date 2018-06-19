using BehaviorAgency.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BehaviorAgency.IdentityServer.Host.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string AgencyCode { get; set; }

        [Required]
        public string UserRoleToken { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
       
        [DataType(DataType.Date)]
        [Display(Name = "Birthdate")]
        public string DBO { get; set; }

        [Required]
        [Display(Name = "Street")]
        public string Address1 { get; set; }
        
        [Display(Name = "Apt/Suite/etc")]
        public string Address2 { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string UserRole {
            get {
                return UserRoleToken ?? CryptoManager.Decrypt(UserRoleToken);
            }
        }
    }
}
