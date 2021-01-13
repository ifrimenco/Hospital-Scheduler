using HospitalScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.DataAccess
{
    public class UnitOfWork
    {
        private readonly HospitalSchedulerContext Context;

        public UnitOfWork(HospitalSchedulerContext context)
        {
            Context = context;
        }

        private BaseRepository<User> users;
        private BaseRepository<UserRole> userRoles;
        private BaseRepository<Gender> genders;
        private BaseRepository<Appointment> appointments;
        private BaseRepository<Specialization> specializations;
        private BaseRepository<Room> rooms;
        public BaseRepository<User> Users => users ?? (users = new BaseRepository<User>(Context));
        public BaseRepository<UserRole> UserRoles => userRoles ?? (userRoles = new BaseRepository<UserRole>(Context));
        public BaseRepository<Gender> Genders => genders ?? (genders = new BaseRepository<Gender>(Context));
        public BaseRepository<Appointment> Appointments => appointments ?? (appointments = new BaseRepository<Appointment>(Context));
        public BaseRepository<Specialization> Specializations => specializations ?? (specializations = new BaseRepository<Specialization>(Context));
        public BaseRepository<Room> Rooms => rooms ?? (rooms = new BaseRepository<Room>(Context));
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
