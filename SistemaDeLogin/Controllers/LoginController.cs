using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SistemaDeLogin.AplicationIdentity.Requests;
using SistemaDeLogin.ApplicationIdentity.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;

namespace SistemaDeLogin.Controllers
{
    public class LoginController : Controller {

        private readonly ILoginService loginService;


        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        public IActionResult Index() {
            //var cookieRequest = HttpContext.Request.Cookies[".AspNetCore.Identity.Application"];
            if (User.Identity != null && User.Identity.IsAuthenticated) { return RedirectToAction("Index", "Home"); }

            return View();
        }


        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
            if (!ModelState.IsValid) return View("Index");

            Task<Result> result = loginService.LoginUser(request);

            if (result.Result.IsFailed)
            {
                ModelState.AddModelError("", "");
                return View("Index");
            }
   
            return RedirectToAction("Index", "Home");
        }
        [HttpGet("signin-google")]
        public IActionResult SignInGoogle()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(HandleGoogleCallback))
            };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("handle-google-callback")]
        public async Task<IActionResult> HandleGoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

            // Autentica o usuário em seu sistema
            // Envie o token de autenticação para o servidor para autenticar o usuário

            return Redirect("/");
        }
        public IActionResult Logout() {

            Result result = loginService.LogoutUser();

            if (result.IsFailed)
                return RedirectToAction("Index", "Home");
            return RedirectToAction("Index", "Login");

        }

        
    }
}
