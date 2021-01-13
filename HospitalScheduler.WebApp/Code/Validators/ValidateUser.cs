using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Code.Validators
{
    public class ValidateUser : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int id = (int)value;
            return (id > 0);
        }
    }
}
