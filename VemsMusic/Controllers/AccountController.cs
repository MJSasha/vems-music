using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using VemsMusic.Models;
using VemsMusic.Other_Data.ViewModels;

namespace VemsMusic.Controllers
{
    public class AccountController : Controller
    {
        private AppDBContext _context;
        public AccountController(AppDBContext context)
        {
            _context = context;
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
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerModel.Email);
                if (user == null)
                {
                    user = new User { Email = registerModel.Email, Password = registerModel.Password };
                    Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                    {
                        user.Role = userRole;
                    }

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user);

                    return Redirect("~/");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(registerModel);
        }

        [Route("~/Account/Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("~/Account/Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == loginModel.Email && u.Password == loginModel.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return Redirect("~/DBRedaction/Index");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(loginModel);
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
