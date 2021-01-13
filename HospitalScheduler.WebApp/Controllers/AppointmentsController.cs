using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalScheduler.BusinessLogic;
using HospitalScheduler.Entities;
using HospitalScheduler.Entities.DTOs;
using HospitalScheduler.Entities.Enums;
using HospitalScheduler.WebApp.Code;
using HospitalScheduler.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalScheduler.WebApp.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly UserAccountService UserAccountService;
        private readonly AppointmentService AppointmentService;
        private readonly UserService UserService;
        private readonly RoomService RoomService;
        private readonly IMapper Mapper;
        private readonly CurrentUserDto CurrentUser;
        private MailSender mailSender;
        public AppointmentsController(
            UserAccountService userAccountService,
            AppointmentService appointmentService,
            UserService userService,
            RoomService roomService,
            IMapper mapper,
            CurrentUserDto currentUser)
        {
            UserAccountService = userAccountService;
            AppointmentService = appointmentService;
            UserService = userService;
            RoomService = roomService;
            Mapper = mapper;
            CurrentUser = currentUser;
            mailSender = new MailSender();
        }
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            if (!CurrentUser.IsAuthenticated)
            {
                return StatusCode(403);
            }
            return View();
        }

        public IActionResult Medic()
        {
            if (!CurrentUser.IsMedic)
            {
                return StatusCode(403);
            }
            try
            {
                var model = new AppointmentsAsMedicVm()
                {
                    AppointmentsAsMedic = AppointmentService.GetAsMedic(CurrentUser.Id).OrderBy(a => a.AppointmentDate).ToList()
                };

                return View(model);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        public IActionResult Patient()
        {
            if (!CurrentUser.IsAuthenticated)
            {
                return StatusCode(403);
            }
            try
            {
                var model = new AppointmentsAsPatientVm()
                {
                    AppointmentsAsPatient = AppointmentService.GetAsPatient(CurrentUser.Id).OrderBy(a => a.AppointmentDate).ToList()
                };
                return View(model);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpGet]
        public IActionResult GetUsersByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrEmpty(name))
            {
                return Json(new
                {
                    result = new List<UserSearchResultVm>(),
                    isEmpty = true // de sters isempty
                });
            }

            var users = UserService.GetUsersByName(CurrentUser.Id, name);

            var result = users.Select(Mapper.Map<UserSearchResultVm>).OrderBy(e => e.FirstName).ToList();

            bool isEmpty = result.Count() == 0;

            return Json(new
            {
                result,
                isEmpty // de sters isempty
            });
        }

        [HttpGet]
        public IActionResult GetMedicsByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrEmpty(name))
            {
                return Json(new
                {
                    result = new List<UserSearchResultVm>(),
                    isEmpty = true 
                });
            }
            var user = UserService.GetUserById(CurrentUser.Id);
            var users = UserService.GetMedicsByName(CurrentUser.Id, name);

            var result = users.Select(Mapper.Map<UserSearchResultVm>).ToList();

            bool isEmpty = result.Count() == 0;

            return Json(new
            {
                result,
                isEmpty
            });
        }

        [HttpGet]
        public IActionResult Create(bool isMedic)
        {
            if (isMedic == true && CurrentUser.IsMedic == false)
            {
                return StatusCode(403);
            }

            var model = new CreateAppointmentVm()
            {
                IsMedic = isMedic,
            };

            try
            {
                if (isMedic == true)
                {
                    model.MedicId = CurrentUser.Id;
                    model.Status = (int)AppointmentStatus.Confirmed;
                }

                else
                {
                    model.PatientId = CurrentUser.Id;
                    model.Status = (int)AppointmentStatus.Pending;
                }
                return View(model);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Create(CreateAppointmentVm model)
        {
            if (model.IsMedic == true && CurrentUser.IsMedic == false)
            {
                return StatusCode(403);
            }


            if (!ModelState.IsValid)
            {
                return View(nameof(Create), model);
            }

            try
            {
                var appointment = Mapper.Map<Appointment>(model);
                AppointmentService.Add(appointment);
                mailSender.SendAppointmentMail(appointment.Medic.Email, appointment);
                mailSender.SendAppointmentMail(appointment.Patient.Email, appointment);
                string redirect;

                redirect = model.IsMedic == true ? "Medic" : "Patient";
                return RedirectToAction(redirect);

            }

            catch (System.Net.Mail.SmtpException)
            {
                string redirect;

                redirect = model.IsMedic == true ? "Medic" : "Patient";
                return RedirectToAction(redirect);
            }

            catch (Exception)
            {
                return (StatusCode(500));
            }
        }

        public IActionResult GetAllRooms()
        {
            try
            {
                var rooms = RoomService.GetAll();
                var result = rooms.Select(Mapper.Map<RoomVm>);
                return Json(new
                {
                    result
                });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                var appointment = AppointmentService.GetById(id);
                if (appointment == null)
                {
                    return StatusCode(404);
                }

                if (appointment.MedicId != CurrentUser.Id)
                {
                    return StatusCode(403);
                }
                var appointmentVm = Mapper.Map<AppointmentVm>(appointment);

                return View(appointmentVm);
            }

            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        public IActionResult View(int id)
        {
            try
            {
                var appointment = AppointmentService.GetById(id);

                if (appointment == null)
                {
                    return StatusCode(404);
                }
                if (appointment.PatientId != CurrentUser.Id)
                {
                    return StatusCode(403);
                }
                var appointmentVm = Mapper.Map<AppointmentVm>(appointment);
                return View(appointmentVm);
            }

            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult ConfirmAppointment(int appointmentId)
        {
            if (!AppointmentService.IsMedic(CurrentUser.Id, appointmentId))
            {
                return StatusCode(403);
            }

            try
            {
                AppointmentService.ChangeStatus(appointmentId, (byte)AppointmentStatus.Confirmed);
                return Json(new
                {

                });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        public IActionResult DenyAppointment(int appointmentId)
        {
            if (!AppointmentService.IsMedic(CurrentUser.Id, appointmentId))
            {
                return StatusCode(403);
            }

            try
            {
                AppointmentService.Remove(appointmentId);
                return Json(new
                {

                });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
