using AutoMapper;
using HospitalScheduler.BusinessLogic;
using HospitalScheduler.Entities;
using HospitalScheduler.Entities.Enums;
using HospitalScheduler.WebApp.Code.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace HospitalScheduler.WebApp.Models
{
    public class CreateAppointmentVm : IValidatableObject
    {
        public CreateAppointmentVm()
        {
            OverlapAppointments = new List<OverlapAppointmentVm>();
        }

        public bool IsMedic { get; set; }

        [Required(ErrorMessage = "Select a patient")]
        [DisplayName("Patient Name")]
        [ValidateUser(ErrorMessage = "Invalid Patient. Please select a valid user")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Select a medic")]
        [DisplayName("Medic Name")]
        [ValidateUser(ErrorMessage = "Invalid Medic. Please select a valid user")]
        public int MedicId { get; set; }

        [Required(ErrorMessage = "Incorrect date")]
        [DisplayName("Date")]
        [ValidateAppointmentDate(ErrorMessage = "You can schedule an appointment starting 24 hours from now")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Select room")]
        [DisplayName("Room")]

        public int RoomId { get; set; }
        [Required(ErrorMessage = "Insert Duration")]
        [DisplayName("Duration")]
        [ValidateDuration(ErrorMessage = "Duration must be between 30 and 10000 minutes")]

        public ushort Duration { get; set; }
        [Required(ErrorMessage = "Insert details")]
        [DisplayName("Details")]
        public string Details { get; set; }

        [DisplayName("Type")]
        public byte Type { get; set; }
        public byte Status { get; set; }

        public List<OverlapAppointmentVm> OverlapAppointments { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var appointmentService = validationContext.GetService(typeof(AppointmentService)) as AppointmentService;
            (var medicOverlap, var roomOverlap) = appointmentService.CheckAppointments(MedicId, RoomId, 0, AppointmentDate, Duration);

            List<Appointment> appointments = new List<Appointment>();
            appointments = medicOverlap.ToList();
            appointments = appointments.Union(roomOverlap).ToList();
            foreach (var appointment in appointments)
            {
                string message;
                if (appointment.RoomId == RoomId && RoomId != (int)DefaultIds.NotSetRoom)
                {
                    if (appointment.MedicId == MedicId)
                    {
                        message = "Room Occupied, Medic Busy";
                    }

                    else
                    {
                        message = "Room Occupied";
                    }
                }
                else
                {

                    message = "Medic Busy";
                }

                OverlapAppointments.Add(new OverlapAppointmentVm()
                {
                    Medic = appointment.Medic.FirstName + " " + appointment.Medic.LastName,
                    StartDate = appointment.AppointmentDate,
                    Room = appointment.Room.Name,
                    Duration = appointment.Duration,
                    Message = message
                });
            }
            if (medicOverlap.Count() > 0)
            {
                string medicMessage;
                if (IsMedic == true)
                {
                    medicMessage = "You already have scheduled appointments in the selected interval. See below for details";
                }

                else
                {
                    medicMessage = "The medic you selected already has scheduled appointments in the selected interval. See below for details";
                }

                yield return new ValidationResult(medicMessage, new List<string>() { nameof(MedicId) });
            }

            if (RoomId != (int)DefaultIds.NotSetRoom && roomOverlap.Count() > 0)
            {
                appointments = appointments.Union(roomOverlap).ToList();
                yield return new ValidationResult("Appointment overlaps with other appointments in the same room. See below for details", new List<string>() { nameof(RoomId) });
            }
        }
    }
}
