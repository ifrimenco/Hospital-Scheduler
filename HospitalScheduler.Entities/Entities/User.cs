using HospitalScheduler.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.Entities
{
    public class User : IEntity
    {
        public User() 
        {
            UserRoles = new HashSet<UserRole>();
            AppointmentsAsMedic = new List<Appointment>();
            AppointmentsAsPatient = new List<Appointment>();
        } 
        public int Id { get; set; }
        public string CNP { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ProfilePicture ProfilePicture { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public Specialization Specialization { get; set; }
        public int? SpecializationId { get; set; }
        public ICollection<Appointment> AppointmentsAsMedic { get; set; }
        public ICollection<Appointment> AppointmentsAsPatient { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
