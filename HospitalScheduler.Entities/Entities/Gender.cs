using HospitalScheduler.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.Entities
{
    public class Gender : IEntity
    {
        public Gender()
        {
            Users = new HashSet<User>();
        }
        public int Id;
        public string Type { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
