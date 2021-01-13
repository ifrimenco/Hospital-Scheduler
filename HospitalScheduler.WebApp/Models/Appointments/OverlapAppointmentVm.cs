using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Models
{
    public class OverlapAppointmentVm
    {
        public string Medic { get; set; }
        public string Room { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Message { get; set; }
    }
}
