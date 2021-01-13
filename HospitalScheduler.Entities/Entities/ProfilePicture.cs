using HospitalScheduler.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.Entities
{
    public class ProfilePicture : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
