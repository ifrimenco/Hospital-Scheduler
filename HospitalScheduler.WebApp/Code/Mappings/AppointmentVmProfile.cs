using AutoMapper;
using HospitalScheduler.Entities;
using HospitalScheduler.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Code.Mappings
{
    public class AppointmentVmProfile : Profile
    {
        public AppointmentVmProfile()
        {
            CreateMap<Appointment, AppointmentVm>()
                .ForMember(a => a.Medic, s => s.MapFrom(r => r.Medic.FirstName + " " + r.Medic.LastName))
                .ForMember(a => a.Patient, s => s.MapFrom(r => r.Patient.FirstName + " " + r.Patient.LastName))
                .ForMember(a => a.Room, s => s.MapFrom(r => r.Room.Name));
        }
    }
}
