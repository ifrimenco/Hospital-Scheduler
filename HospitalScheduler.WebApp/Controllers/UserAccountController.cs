using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HospitalScheduler.BusinessLogic;
using HospitalScheduler.Entities;
using HospitalScheduler.Entities.DTOs;
using HospitalScheduler.WebApp.Code;
using HospitalScheduler.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace HospitalScheduler.WebApp.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly UserAccountService UserAccountService;
        private readonly UserService UserService;
        private readonly IMapper Mapper;
        private readonly CurrentUserDto CurrentUser;

        public UserAccountController(UserAccountService userAccountService, UserService userService, IMapper mapper, CurrentUserDto currentUser)
        {
            UserAccountService = userAccountService;
            UserService = userService;
            Mapper = mapper;
            CurrentUser = currentUser;
        }

        [HttpGet] 
        public IActionResult Register()
        {
            var model = new RegisterVm();
            return View("Register", model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var user = Mapper.Map<User>(model);

                user = UserAccountService.RegisterNewUser(user);
                var MailSender = new MailSender();
                MailSender.SendWelcomeMail(user.Email);

                await LogIn(user);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginVm();
            return View("Login", model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = UserAccountService.Login(model.Email, model.Password);
            if (user == null)
            {
                model.AreCredentialsInvalid = true;

                return View(model);
            }

            await LogIn(user);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await LogOut();

            return RedirectToAction("Index", "Home");
        }

        private async Task LogIn(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
            };
            user.UserRoles
                .ToList()
                .ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r.Role.Name)));

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                    scheme: "HospitalSchedulerCookies",
                    principal: principal);
        }

        private async Task LogOut()
        {
            await HttpContext.SignOutAsync(scheme: "HospitalSchedulerCookies");
        }
    }
}
