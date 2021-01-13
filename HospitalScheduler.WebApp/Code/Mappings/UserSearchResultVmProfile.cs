using AutoMapper;
using HospitalScheduler.Entities;
using HospitalScheduler.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Code.Mappings
{
    public class UserSearchResultVmProfile : Profile
    {
        public UserSearchResultVmProfile()
        {
            CreateMap<User, UserSearchResultVm>()
                .ForMember(u => u.Specialization, s => s.MapFrom(r => r.Specialization.Name));
        }
    }
}
