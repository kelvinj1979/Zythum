using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Areas.Users.Models
{
    public class InputModelRegister
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter the Birthday date.")]
        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        //[Required(ErrorMessage = "NID is required.")]
        public string NID { get; set; }

        //[Required(ErrorMessage = "El campo telefono es obligatorio.")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{5})$", ErrorMessage = "El formato telefono ingresado no es válido.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [MaxLength(100)]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Select a role.")]
        public string Role { get; set; }
            
        [MaxLength(3)]
        [Display(Name = "Gender")]
        public string GenderId { get; set; }

       
        [MaxLength(3)]
        [Display(Name = "Country")]
        public string CountryId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

        [MaxLength(100)]
        [Display(Name = "City")]
        public string City { get; set; }


        [Display(Name = "AboutYou")]
        [DataType(DataType.MultilineText)]
        public string AboutYou { get; set; }


        public string ID { get; set; }
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
