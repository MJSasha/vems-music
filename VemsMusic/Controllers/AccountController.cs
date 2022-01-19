using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using VemsMusic.Models;
using VemsMusic.Other_Data.Interfaces;
using VemsMusic.Other_Data.PersonalExceptions;
using VemsMusic.Other_Data.ViewModels;

namespace VemsMusic.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAllUsers _allUsers;
        public AccountController(IAllUsers allUsers)
        {
            _allUsers = allUsers;
        }

        [Route("~/Account/Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("~/Account/Register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                if (await _allUsers.UserIsInDatabase(registerModel))
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
                else
                {
                    User user = new User { Email = registerModel.Email, Password = registerModel.Password };
                    await _allUsers.AddNewUser(user);

                    await Authenticate(user);
                    HttpContext.Response.Cookies.Append("id", user.Id.ToString());

                    return Redirect("~/");
                }
            }
            return View(registerModel);
        }

        [Route("~/Account/Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("~/Account/Login/{ReturnUrl?}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = await _allUsers.GetUserByLoginModelAsync(loginModel);
                    await Authenticate(user);
                    HttpContext.Response.Cookies.Append("id", user.Id.ToString());

                    return Redirect(ReturnUrl ?? "~/");
                }
                catch (NotFoundException)
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
            }
            return View(loginModel);
        }

        [Route("~/Account/Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(".AspNetCore.Cookies");
            Response.Cookies.Delete("id");
            return Redirect("~/");

        }

        private async Task Authenticate(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
