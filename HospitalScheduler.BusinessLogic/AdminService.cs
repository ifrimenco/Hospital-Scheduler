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
    public class AdminService : BaseService
    {
        public AdminService(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public void AddRole(int userId, int roleId)
        {
            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId
            };

            UnitOfWork.UserRoles.Insert(userRole);
            UnitOfWork.SaveChanges();
        }


        public void RemoveRole(int userId, int roleId)
        {
            var userRole = UnitOfWork.UserRoles.Get().FirstOrDefault(e => e.UserId == userId && e.RoleId == roleId);

            if (userRole == null)
            {
                return;
            }

            UnitOfWork.UserRoles.Delete(userRole);
            UnitOfWork.SaveChanges();
        }
    }
}
