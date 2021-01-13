using AutoMapper;
using HospitalScheduler.Entities;
using HospitalScheduler.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Code.Mappings
{
    public class SpecializationVmProfile : Profile
    {
        public SpecializationVmProfile()
        {
            CreateMap<Specialization, SpecializationVm>()
                .ForMember(s => s.Id, ss => ss.MapFrom(e => e.Id))
                .ForMember(s => s.Name, ss => ss.MapFrom(e => e.Name));
        }
    }
}
