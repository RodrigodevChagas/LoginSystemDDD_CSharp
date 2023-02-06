using AutoMapper;
using Azure.Core;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SistemaDeLogin.AplicationIdentity.Requests;
using SistemaDeLogin.ApplicationIdentity.Services;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.Data.Repository;

namespace SistemaDeLogin.Controllers
{
    public class LoginController : Controller {

        private readonly LoginService loginService;


        public LoginController(LoginService loginService)
        {
            this.loginService = loginService;
        }
        
        public IActionResult Index() {
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
   
            return RedirectToAction("Index", "Home", request);
        }

        public IActionResult Logout() {

            Result result = loginService.LogoutUser();

            if (result.IsFailed)
                return RedirectToAction("Index", "Home");
            return RedirectToAction("Index", "Login");

        }

    }
}
