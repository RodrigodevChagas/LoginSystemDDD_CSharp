using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SistemaDeLogin.AplicationIdentity.Requests;
using SistemaDeLogin.ApplicationIdentity.Services;
using SistemaDeLogin.ApplicationIdentity.ViewModels;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.Data.Repository;
using SistemaDeLogin.Models;
using System.Diagnostics;

namespace SistemaDeLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LoginService loginService;

        public HomeController(ILogger<HomeController> logger, LoginService loginService)
        {
            _logger = logger;
            this.loginService = loginService;
        }

        public IActionResult Index(LoginRequest request)
        {
            UserViewModel user = new UserViewModel(request.Username!);
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                user.Username = User.Identity.Name!;
            }
            UserViewModel pegaInfo = loginService.SearchUserInfo(user);

            return View(pegaInfo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}