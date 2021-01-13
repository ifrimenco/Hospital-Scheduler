using HospitalScheduler.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.Entities
{
    public class Specialization : IEntity
    {
        public Specialization()
        {
            Medics = new List<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> Medics { get; set; }
    }
}
