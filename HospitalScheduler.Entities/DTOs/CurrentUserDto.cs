using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.Entities.DTOs
{
    public class CurrentUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsMedic { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
