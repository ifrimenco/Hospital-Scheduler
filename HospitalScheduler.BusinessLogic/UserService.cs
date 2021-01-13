using HospitalScheduler.DataAccess;
using HospitalScheduler.Entities;
using HospitalScheduler.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalScheduler.BusinessLogic
{
    public class UserService : BaseService
    {
        public UserService(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public User GetUserById(int userId)
        {
            return UnitOfWork.Users.Get()
                .Include(e => e.UserRoles)
                .Include(e => e.Specialization)
                .Include(e => e.AppointmentsAsMedic)
                .Include(e => e.AppointmentsAsPatient)
                .First(e => e.Id == userId);
        }

        public IEnumerable<User> GetUsersByName(int userId, string name)
        {
            name = name.ToLower();
            return UnitOfWork.Users
                .Get()
                .Where(e => (e.FirstName + " " + e.LastName)
                    .ToLower()
                    .Contains(name) && e.Id != userId);
        }

        public IEnumerable<User> GetMedicsByName(int userId, string name)
        {
            name = name.ToLower();
            return UnitOfWork.Users
                .Get()
                .Include(u => u.Specialization)
                .Where(e => e.UserRoles
                    .Select(f => f.RoleId)
                    .Contains((int)RoleTypes.Medic)
                    && ((e.FirstName + " " + e.LastName)
                    .ToLower()
                    .Contains(name) 
                    || e.Specialization.Name.Contains(name)) 
                    && e.Id != userId)
               .OrderBy(u => u.Specialization.Name);
        }
        public bool IsMedic(int userId)
        {
            return UnitOfWork.Users.Get()
                .Include(e => e.UserRoles)
                .FirstOrDefault(u => u.Id == userId)
                .UserRoles.Any(ur => ur.RoleId == (int)RoleTypes.Medic);
        }

        public IEnumerable<User> GetAll()
        {
            return UnitOfWork.Users
                .Get()
                .Include(e => e.UserRoles)
                .Include(e => e.Specialization);
        }

        public IEnumerable<User> Get(int toSkip,int toTake)
        {
            return UnitOfWork.Users.Get()
                .Include(e => e.UserRoles)
                .Include(e => e.Specialization)
                .Skip(toSkip)
                .Take(toTake);
        } 
        public void SetSpecialization(int userId, Specialization specialization)
        {
            var user = UnitOfWork.Users.Get().Where(u => u.Id == userId).FirstOrDefault();
            user.SpecializationId = specialization.Id;
            UnitOfWork.SaveChanges();
        }

        public void SetSpecialization(int userId, int specializationId)
        {
            var user = UnitOfWork.Users.Get().Where(u => u.Id == userId).FirstOrDefault();
            user.SpecializationId = specializationId;
            UnitOfWork.SaveChanges();
        }
        public void RemoveSpecialization(int userId)
        {
            var user = UnitOfWork.Users.Get().Where(u => u.Id == userId).FirstOrDefault();
            user.Specialization = null;
            user.SpecializationId = null;
            UnitOfWork.SaveChanges();
        }

        public void ChangeCNP(int userId, string newCNP)
        {
            var user = UnitOfWork.Users.Get().Where(u => u.Id == userId).FirstOrDefault();
            user.CNP = newCNP;
            UnitOfWork.SaveChanges();
        }

        public void ChangeEmail(int userId, string newEmail)
        {
            var user = UnitOfWork.Users.Get().Where(u => u.Id == userId).FirstOrDefault();
            user.Email = newEmail;
            UnitOfWork.SaveChanges();
        }
    }
}
