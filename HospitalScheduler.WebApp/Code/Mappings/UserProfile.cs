using AutoMapper;
using HospitalScheduler.Entities;
using HospitalScheduler.Entities.Enums;
using HospitalScheduler.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Code.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterVm, User>()
                .ForMember(u => u.PasswordHash, s => s.MapFrom(r => r.Password));
        }
    }
}
