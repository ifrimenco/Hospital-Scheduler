using HospitalScheduler.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.Entities
{
    public class Document : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }
        public Appointment Appointment { get; set; }
        public int AppointmentId { get; set; }
    }
}
