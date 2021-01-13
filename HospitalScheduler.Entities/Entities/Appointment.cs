using HospitalScheduler.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.Entities
{
    public class Appointment : IEntity
    {
        public Appointment()
        {
            Documents = new HashSet<Document>();
        }
        public int Id { get; set; }
        public User Medic { get; set; }
        public int MedicId { get; set; }
        public User Patient { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Room Room { get; set; }
        public ushort Duration { get; set; }
        public int? RoomId { get; set; }
        public string Details { get; set; }
        public string Conclusions { get; set; }
        public ICollection<Document> Documents { get; set; }
        public byte TypeId { get; set; }
        public byte StatusId { get; set; }
    }
}
