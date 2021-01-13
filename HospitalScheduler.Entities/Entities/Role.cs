using HospitalScheduler.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.Entities
{
    public class Role : IEntity
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public int Id;
        public string Name { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
