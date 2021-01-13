using HospitalScheduler.BusinessLogic;
using HospitalScheduler.WebApp.Code.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Models
{
    public class RegisterVm : IValidatableObject
    {

        [Required(ErrorMessage = "Mandatory Field")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        [DisplayName("CNP or Passport ID")]
        public string CNP { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        [EmailAddress]
        [ValidateEmail(ErrorMessage = "Invalid E-mail Address")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        [DisplayName("Gender")]
        public int GenderId { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        [ValidateBirthDate(ErrorMessage = "You can't be born in the future, or be more than 130 years old")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var userAccountService = validationContext.GetService(typeof(UserAccountService)) as UserAccountService;
            if (userAccountService.VerifyCNP(CNP, 0))
            {
                yield return new ValidationResult("CNP already exists", new List<string>() { nameof(CNP) });
            }

            if (userAccountService.VerifyMail(Email, 0))
            {
                yield return new ValidationResult("Email already exists", new List<string>() { nameof(Email) });
            }
        }
    }
}
