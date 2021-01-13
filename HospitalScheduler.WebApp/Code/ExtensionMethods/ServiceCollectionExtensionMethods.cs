using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalScheduler.BusinessLogic;
using Microsoft.AspNetCore.Http;
using HospitalScheduler.Entities.DTOs;
using HospitalScheduler.Entities.Enums;
using System.IO;
using HospitalScheduler.Entities;

namespace HospitalScheduler.WebApp.Code.ExtensionMethods
{
    public static class ServiceCollectionExtensionMethods
    {
        public static IServiceCollection AddHospitalSchedulerBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<UserAccountService>();
            services.AddScoped<UserService>();
            services.AddScoped<AdminService>();
            services.AddScoped<AppointmentService>();
            services.AddScoped<SpecializationService>();
            services.AddScoped<RoomService>();
            return services;
        }

        public static IServiceCollection AddHospitalSchedulerCurrentUser(this IServiceCollection services)
        {
            services.AddScoped(s =>
            {
                var accessor = s.GetService<IHttpContextAccessor>();
                var httpContext = accessor.HttpContext;
                var id = httpContext.User.Claims?.FirstOrDefault(c => c.Type == "Id")?.Value;
                var isAuthenticated = httpContext.User.Identity.IsAuthenticated;

                if (isAuthenticated)
                {
                    var userService = s.GetService<UserService>();

                    var user = userService.GetUserById(int.Parse(id));
                    byte[] profilePicture = user.ProfilePicture != null ? user.ProfilePicture.File : null;  

                    return new CurrentUserDto
                    {
                        IsAuthenticated = isAuthenticated,
                        Id = Convert.ToInt32(id),
                        Email = httpContext.User.Identity.Name,
                        ProfilePicture = profilePicture,
                        IsMedic = user.UserRoles.Any(e => e.RoleId == (int) RoleTypes.Medic),
                        IsAdmin = user.UserRoles.Any(e => e.RoleId == (int) RoleTypes.Admin),
                    };
                }

                return new CurrentUserDto
                {
                    IsAuthenticated = false
                };
            });
            return services;
        }
    }
}
