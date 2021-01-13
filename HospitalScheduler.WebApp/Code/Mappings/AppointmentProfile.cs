using AutoMapper;
using HospitalScheduler.Entities;
using HospitalScheduler.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Code.Mappings
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<CreateAppointmentVm, Appointment>()
                .ForMember(a => a.MedicId, s => s.MapFrom(r => r.MedicId))
                .ForMember(a => a.PatientId, s => s.MapFrom(r => r.PatientId))
                .ForMember(a => a.TypeId, s => s.MapFrom(r => r.Type))
                .ForMember(a => a.StatusId, s => s.MapFrom(r => r.Status))
                .ForMember(a => a.RoomId, s => s.MapFrom(r => r.RoomId))
                .ForMember(a => a.AppointmentDate, s => s.MapFrom(r => r.AppointmentDate))
                .ForMember(a => a.Details, s => s.MapFrom(r => r.Details));

        }
    }
}
