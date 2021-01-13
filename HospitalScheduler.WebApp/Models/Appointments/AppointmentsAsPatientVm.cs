using HospitalScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Models
{
    public class AppointmentsAsPatientVm
    {
        public List<Appointment> AppointmentsAsPatient { get; set; }
    }
}
