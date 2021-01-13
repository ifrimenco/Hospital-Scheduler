using HospitalScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Models
{
    public class AppointmentVm
    {
        public int Id { get; set; }
        public string Medic { get; set; }
        public int MedicId { get; set; }
        public string Patient { get; set; }
        public DateTime AppointmentDate { get; set; }
        public byte TypeId { get; set; }
        public byte StatusId { get; set; }
        public string Room { get; set; }
        public ushort Duration { get; set; }
        public string Details { get; set; }
        public string Conclusions { get; set; }
        public List<Document> Documents { get; set; }
    }
}
