using Business.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MVCFormProject.Models;
using System.Security.Claims;

namespace MVCFormProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;
        private readonly NavigationManager _navi;
        public LoginController(ILoginService loginService, IConfiguration config, NavigationManager navi)
        {
            _loginService = loginService;
            _config = config;
            _navi = navi;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserModel userDto)
        {

            var auth = await _loginService.Authenticate(userDto.Username, userDto.Password);

            var authDto = new UserModel
            {
                Username = auth.Username,
                Password = auth.Password,
                LoginResult = auth.LoginResult,
            };

            if (authDto.LoginResult == true)
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, authDto.Username)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Form");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }
    }
}
