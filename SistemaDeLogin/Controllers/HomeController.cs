using Microsoft.AspNetCore.Mvc;
using SistemaDeLogin.AplicationIdentity.Requests;
using SistemaDeLogin.ApplicationIdentity.Services;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.Data.Repository;
using SistemaDeLogin.Models;
using System.Diagnostics;

namespace SistemaDeLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository userRepository;
        private readonly UserService userService;
        private readonly IWebHostEnvironment _hostEnvironment;


        public HomeController(UserRepository userRepository, IWebHostEnvironment hostEnvironment, UserService userService) 
        {

            this.userRepository = userRepository;
            _hostEnvironment = hostEnvironment;
            this.userService = userService;
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

        
        public IActionResult PictureManagement(Usuarios user) 
        {
            if (User.Identity != null && !string.IsNullOrEmpty(User.Identity.Name))
                user.Username = User.Identity.Name;

            string wwwRootPath = _hostEnvironment.WebRootPath;
            var result = userService.UploadProfilePic(user, wwwRootPath);

            return RedirectToAction("Index", "Home");
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