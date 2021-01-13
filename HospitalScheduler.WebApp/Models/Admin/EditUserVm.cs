using HospitalScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Models
{
    public class EditUserVm
    {
        public int Id { get; set; }
        public string CNP { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public SpecializationVm Specialization { get; set; }
        public bool IsMedic { get; set; }
    }
}
