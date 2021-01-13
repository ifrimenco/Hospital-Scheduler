using HospitalScheduler.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.Entities
{
    public class Room : IEntity
    {
        public Room()
        {
            Appointments = new List<Appointment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Appointment> Appointments;

  
    }
}
