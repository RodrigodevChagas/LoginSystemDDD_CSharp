using Microsoft.AspNetCore.Mvc;
using SistemaDeLogin.AplicationIdentity.Requests;
using SistemaDeLogin.ApplicationIdentity.Interfaces;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.Data.Interface;
using SistemaDeLogin.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace SistemaDeLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IUserService userService;
        private readonly IWebHostEnvironment _hostEnvironment;


        public HomeController(IUserRepository userRepository, IWebHostEnvironment hostEnvironment, IUserService userService) 
        {

            this.userRepository = userRepository;
            _hostEnvironment = hostEnvironment;
            this.userService = userService;
        }

        //Implementar utilização do identity para não ficar com login e senha a mostra.
        [Route("HomeBoladao")]
        public IActionResult Index()
        {
            if(User.Identity !=null && User.Identity.IsAuthenticated) 
            {
               
                Usuarios user = new Usuarios();
                user.Email = User.FindFirst(ClaimTypes.Email)?.Value!;
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