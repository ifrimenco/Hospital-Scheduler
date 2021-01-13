using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Code.Validators
{
    public class ValidateDuration : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            ushort duration = (ushort)value;

            return duration >= 30 && duration <= 10000;
        }
    }
}
