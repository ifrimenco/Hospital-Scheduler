using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Code.Validators
{
    public class ValidateAppointmentDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime >= DateTime.Now.AddMinutes(1400) && dateTime <= DateTime.Now.AddYears(1);
        }
    }
}
