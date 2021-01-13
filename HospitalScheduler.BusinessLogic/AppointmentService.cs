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
    public class AppointmentService : BaseService
    {
        public AppointmentService(UnitOfWork unitOfWork) :
            base(unitOfWork)
        {
        }

        public IEnumerable<Appointment> GetMedicAppointments(int medicId)
        {
            var user = UnitOfWork.Users
                .Get()
                .First(e => e.Id == medicId);

            return user.AppointmentsAsMedic;
        }

        public IEnumerable<Appointment> GetPatientAppointments(int patientId)
        {
            var user = UnitOfWork.Users
                .Get()
                .First(e => e.Id == patientId);

            return user.AppointmentsAsPatient;
        }

        public void Add(Appointment appointment)
        {
            var medic = UnitOfWork.Users.Get().Where(u => u.Id == appointment.MedicId).FirstOrDefault();
            var patient = UnitOfWork.Users.Get().Where(u => u.Id == appointment.PatientId).FirstOrDefault();
            appointment.Medic = medic;
            appointment.Patient = patient;
            UnitOfWork.Appointments.Insert(appointment);
            UnitOfWork.SaveChanges();
        }

        public void ChangeStatus(int appointmentId, byte statusId)
        {
            var appointment = UnitOfWork.Appointments.Get().FirstOrDefault(e => e.Id == appointmentId);
            appointment.StatusId = statusId;
            UnitOfWork.SaveChanges();
        }

        public void ChangeRoom(int appointmentId, int roomId)
        {
            var appointment = UnitOfWork.Appointments.Get().FirstOrDefault(e => e.Id == appointmentId);
            appointment.RoomId = roomId;
            UnitOfWork.SaveChanges();
        }

        public void AddConclusions(int appointmentId, string conclusions)
        {
            var appointment = UnitOfWork.Appointments.Get().FirstOrDefault(e => e.Id == appointmentId);
            appointment.Conclusions = conclusions;
            UnitOfWork.SaveChanges();
        }

        public IEnumerable<Appointment> GetAsPatient(int patientId)
        {
            return UnitOfWork.Appointments.Get().Where(a => a.PatientId == patientId).Include(a => a.Medic).Include(a => a.Room);
        }

        public bool IsMedic(int medicId, int appointmentId)
        {
            var medic = UnitOfWork.Users.Get().FirstOrDefault(u => u.Id == medicId);

            if (medic == null)
            {
                return false;
            }

            var appointment = medic.AppointmentsAsMedic.FirstOrDefault(a => a.Id == appointmentId);

            if (appointment == null)
            {
                return false;
            }

            return true;
        }

        public Appointment GetById(int appointmentId)
        {
            return UnitOfWork.Appointments.Get()
                .Where(a => a.Id == appointmentId)
                .Include(a => a.Patient)
                .Include(a => a.Medic)
                .Include(a => a.Room).FirstOrDefault();
        }

        public void Remove(int appointmentId)
        {
            var appointment = UnitOfWork.Appointments.Get().FirstOrDefault(e => e.Id == appointmentId);

            if (appointment == null)
            {
                return;
            }

            UnitOfWork.Appointments.Delete(appointment);
            UnitOfWork.SaveChanges();
        }

        public void RemoveMedicAppointments(int medicId)
        {
            var appointments = UnitOfWork.Appointments.Get().Where(a => a.MedicId == medicId);
            if (appointments == null)
            {
                return;
            }

            foreach (var appointment in appointments)
            {
                UnitOfWork.Appointments.Delete(appointment);
            }
            UnitOfWork.SaveChanges();
        }

        public (IEnumerable<Appointment>, IEnumerable<Appointment>) CheckAppointments(int medicId, int roomId, int appointmentId, DateTime startDate, int duration)
        {
            DateTime endDate = startDate.AddMinutes(duration);

            var appointments = UnitOfWork.Appointments
                    .Get()
                    .Include(e => e.Medic)
                    .Include(e => e.Room)
                    .Where(e => (e.MedicId == medicId || e.RoomId == roomId) && (e.AppointmentDate < endDate
                    && startDate < e.AppointmentDate.AddMinutes(e.Duration)));

            List<Appointment> medicOverlapAppointments = new List<Appointment>();
            List<Appointment> roomOverlapAppointments = new List<Appointment>();

            if (appointments.Count() == 0)
            {
                return (medicOverlapAppointments, roomOverlapAppointments);
            }

            if (appointmentId == 0)
            {
                medicOverlapAppointments = appointments.Where(e => e.MedicId == medicId).ToList();
                roomOverlapAppointments = appointments.Where(e => e.RoomId != (int)DefaultIds.NotSetRoom && e.RoomId == roomId).ToList();
                return (medicOverlapAppointments, roomOverlapAppointments);
            }

            medicOverlapAppointments = appointments.Where(e => e.Id != appointmentId && e.MedicId == medicId).ToList();
            roomOverlapAppointments = appointments.Where(e => e.Id != appointmentId && e.RoomId != (int)DefaultIds.NotSetRoom && e.RoomId == roomId).ToList();
            return (medicOverlapAppointments, roomOverlapAppointments);
        }

        public IEnumerable<Appointment> GetAsMedic(int medicId)
        {
            return UnitOfWork.Appointments.Get().Where(a => a.MedicId == medicId).Include(a => a.Patient).Include(a => a.Room);
        }
    }
}
