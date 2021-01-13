using HospitalScheduler.Common;
using HospitalScheduler.DataAccess;
using HospitalScheduler.Entities;
using HospitalScheduler.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HospitalScheduler.BusinessLogic
{
    public class UserAccountService : BaseService
    {

        public UserAccountService(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public User Login(string email, string password)
        {
            var passwordHash = HashHelper.HashPassword(password);

            var user = UnitOfWork.Users.Get()
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return null;
            }

            string storedPassword = user.PasswordHash;

            if (HashHelper.VerifyPassword(password, storedPassword) == false)
            {
                return null;
            }
            return user;
        }

        public User RegisterNewUser(User user)
        {
            return ExecuteInTransaction(unitOfWork =>
            {

                user.PasswordHash = HashHelper.HashPassword(user.PasswordHash);

                user.UserRoles = new List<UserRole> {
                new UserRole
                {
                    RoleId = (int) RoleTypes.User,
                    UserId = user.Id
                } };

                user.Gender = unitOfWork.Genders.Get().Where(g => g.Id == user.GenderId).FirstOrDefault();
                unitOfWork.Users.Insert(user);
                unitOfWork.SaveChanges();
                var id = user.Id;
                user = UnitOfWork.Users.Get()
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefault(u => u.Id == id);
                return user;
            });
        }

        public bool VerifyCNP(string CNP, int id)
        {
            if (id == 0)
            {
                return UnitOfWork.Users.Get().Any(e => e.CNP == CNP);
            }
            else
            {
                return UnitOfWork.Users.Get().Any(e => e.CNP == CNP && e.Id != id);
            }
        }

        public bool VerifyMail(string email, int id)
        {
            if (id == 0)
            {
                return UnitOfWork.Users.Get().Any(e => e.Email == email);
            }
            else
            {
                return UnitOfWork.Users.Get().Any(e => e.Email == email && e.Id != id);
            }
        }
    }
}
