using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lunch.Admin.Models;
using Lunch.Service;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Lunch.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _Service;

        public HomeController(UserService service)
        {
            _Service = service;
        }

        [Authorize(Roles = "1")]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Denied()
        {
            return Content("Denied");
        }

        [HttpPost]
        public IActionResult Login(string account, string password)
        {
            var user = _Service.Login(account, _Service.Encrypt(password));
            if (user == null || user.RoleId != 1)
            {
                return Json(new ResponseModel(false, 0, 0));
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, account));
            identity.AddClaim(new Claim("UserId", user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.RoleId.ToString()));
            HttpContext.SignInAsync(new ClaimsPrincipal(identity));

            return Json(new ResponseModel(true, 0, 0));
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/Home/Login");
        }
        
        [Authorize(Roles = "1")]
        public IActionResult UpdatePwd()
        {
            return View();
        }

        [Authorize(Roles ="1")]
        public IActionResult ChangePassword(string password, string newPassword)
        {
            var userIdStr = User.Claims.SingleOrDefault(s => s.Type == "UserId").Value;
            int.TryParse(userIdStr, out int userId);

            var result = _Service.ChangePassword(
                userId,
                _Service.Encrypt(password),
                _Service.Encrypt(newPassword));
            return Ok(true);
        }
    }
}
