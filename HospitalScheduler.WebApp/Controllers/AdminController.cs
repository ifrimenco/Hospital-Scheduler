using AutoMapper;
using HospitalScheduler.BusinessLogic;
using HospitalScheduler.Entities;
using HospitalScheduler.Entities.DTOs;
using HospitalScheduler.Entities.Enums;
using HospitalScheduler.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserService UserService;
        private readonly UserAccountService UserAccountService;
        private readonly AdminService AdminService;
        private readonly AppointmentService AppointmentService;
        private readonly IMapper Mapper;
        private readonly SpecializationService SpecializationService;
        private readonly RoomService RoomService;
        private readonly CurrentUserDto CurrentUser;
        private readonly int PageCount = 5;

        public AdminController(
            UserService userService,
            UserAccountService userAccountService,
            AdminService adminService,
            AppointmentService appointmentService,
            SpecializationService specializationService,
            RoomService roomService,
            IMapper mapper,
            CurrentUserDto currentUser)
        {
            UserService = userService;
            UserAccountService = userAccountService;
            AdminService = adminService;
            AppointmentService = appointmentService;
            SpecializationService = specializationService;
            Mapper = mapper;
            RoomService = roomService;
            CurrentUser = currentUser;
        }
        [HttpGet]
        public IActionResult Index(int id = 1)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(404);
                }

                var users = UserService.Get((id - 1) * PageCount, PageCount + 1).ToList();

                if (users.Count() == 0)
                {
                    return StatusCode(404);
                }
                UserListVm userList = new UserListVm
                {
                    Users = users.Take(PageCount),
                    HasForward = users.Count == PageCount + 1,
                    Page = id
                };

                return View(userList);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult AddAdmin(int userId)
        {
            try
            {
                AdminService.AddRole(userId, (int)RoleTypes.Admin);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveAdmin(int userId)
        {
            try
            {
                AdminService.RemoveRole(userId, (int)RoleTypes.Admin);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult AddMedic(int userId)
        {
            try
            {
                AdminService.AddRole(userId, (int)RoleTypes.Medic);
                Specialization generalist = SpecializationService.GetByName("Generalist");
                if (generalist == null)
                {
                    SpecializationService.Add(new Specialization()
                    {
                        Name = "Generalist"
                    });
                    generalist = SpecializationService.GetByName("Generalist");
                }
                UserService.SetSpecialization(userId, generalist);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveMedic(int userId)
        {
            try
            {
                AdminService.RemoveRole(userId, (int)RoleTypes.Medic);
                UserService.RemoveSpecialization(userId);
                AppointmentService.RemoveMedicAppointments(userId);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok();
        }
        public IActionResult Edit(int id)
        {
            if (!CurrentUser.IsAdmin)
            {
                return StatusCode(403);
            }
            try
            {
                var user = UserService.GetUserById(id);

                if (user == null)
                {
                    return StatusCode(404);
                }
                var editUserVm = new EditUserVm()
                {
                    Name = user.FirstName + ' ' + user.LastName,
                    Id = user.Id,
                    CNP = user.CNP,
                    Email = user.Email,
                    Specialization = user.Specialization != null ? Mapper.Map<SpecializationVm>(user.Specialization) : null,
                    IsMedic = UserService.IsMedic(id)
                };
                return View(editUserVm);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult AddSpecialization(string name)
        {
            try
            {
                var specialization = new Specialization()
                {
                    Name = name
                };

                bool success = SpecializationService.Add(specialization);

                return Json(new
                {
                    success
                });
            }

            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult AddRoom(string name)
        {
            try
            {
                var room = new Room()
                {
                    Name = name
                };
                bool success = RoomService.Add(room);

                return Json(new
                {
                    success
                });
            }

            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult GetAllSpecializations()
        {
            try
            {
                var specializations = SpecializationService.GetAll();

                var result = specializations.Select(Mapper.Map<SpecializationVm>).ToList();

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

        [HttpGet]
        public IActionResult GetAllRooms()
        {
            try
            {
                var rooms = RoomService.GetAll();

                var result = rooms.Select(Mapper.Map<RoomVm>).ToList();

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

        [HttpPost]
        public IActionResult RemoveSpecialization(int id)
        {
            SpecializationService.Remove(id);
            return Json(new
            {
            });
        }

        [HttpPost]
        public IActionResult RemoveRoom(int id)
        {
            RoomService.Remove(id);
            return Json(new
            {
            });
        }

        [HttpPost]
        public IActionResult ModifyUser(int userId, string cnp, string email, int? specializationId)
        {
            int cnpCode = 0, emailCode = 0;

            if (cnp != null)
            {
                if (UserAccountService.VerifyCNP(cnp, userId))
                {
                    cnpCode = -1;
                }
                else
                {
                    UserService.ChangeCNP(userId, cnp);
                    cnpCode = 1;
                }
            }

            if (email != null)
            {
                if (UserAccountService.VerifyMail(email, userId))
                {
                    emailCode = -1;
                }
                else
                {
                    UserService.ChangeEmail(userId, email);
                    emailCode = 1;
                }
            }

            if (specializationId != null)
            {
                UserService.SetSpecialization(userId, (int)specializationId);
            }
            return Json(new
            {
                cnpCode,
                emailCode,
                specializationChanged = (specializationId != null),
            });
        }

    }
}
