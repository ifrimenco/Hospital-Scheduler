using HospitalScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Models
{
    public class UserListVm
    {
        public IEnumerable<User> Users { get; set; }

        public bool HasForward { get; set; }

        public int Page { get; set; }
    }
}
