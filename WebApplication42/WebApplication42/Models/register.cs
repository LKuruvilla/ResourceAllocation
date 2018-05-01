using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication42.Models
{
    public class register
    {

        public int userid { get; set; }

        public int addid { get; set; }

        public int UiID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(64, ErrorMessage = "Must be between 1 and 64 characters", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(64, ErrorMessage = "Must be between 1 and 64 characters", MinimumLength = 1)]
        public string LastName { get; set; }

        [StringLength(1, ErrorMessage = "Must be 1 character", MinimumLength = 1)]
        public string MiddleInitial { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "EmailAddress is required")]
        [StringLength(64, ErrorMessage = "Must be between 5 and 64 characters", MinimumLength = 5)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(64, ErrorMessage = "Must be between 1 and 64 characters", MinimumLength = 1)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(32, ErrorMessage = "Must be between 5 and 32 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(32, ErrorMessage = "Must be between 5 and 32 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(128, ErrorMessage = "Must be between 5 and 128 characters", MinimumLength = 5)]
        public string Street { get; set; }

        [StringLength(128, ErrorMessage = "Must not be more than 128 characters")]
        public string Street2 { get; set; }

       // public string Apt { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(32, ErrorMessage = "Must be between 1 and 32characters", MinimumLength = 1)]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(20, ErrorMessage = "Must be between 4 and 20 characters", MinimumLength = 4)]
        public string State { get; set; }

        [Required(ErrorMessage = "Zipcode is required")]
        public string ZipCode { get; set; }
    }
}