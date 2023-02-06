using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SistemaDeLogin.AplicationIdentity.Requests;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.Data.Repository;
using SistemaDeLogin.Models;
using System.Diagnostics;

namespace SistemaDeLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserRepository userRepository;


        public HomeController(ILogger<HomeController> logger, UserRepository userRepository)
        {
            _logger = logger;
            this.userRepository = userRepository;
        }

        public IActionResult Index(LoginRequest request)
        {
            if(User.Identity != null && !string.IsNullOrEmpty(User.Identity.Name)) 
            {
                Usuarios user = new Usuarios();
                user.Username = request.Username != null ? request.Username : User.Identity.Name;
                user = userRepository.GetUserInfo(user);
                return View(user);
            }

            return RedirectToAction("Index", "Login");
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