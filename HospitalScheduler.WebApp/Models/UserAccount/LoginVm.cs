using HospitalScheduler.WebApp.Code.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Models
{
    public class LoginVm
    {
        [Required]
        [ValidateEmail(ErrorMessage = "Invalid E-mail Address")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool AreCredentialsInvalid { get; set; }
    }
}
