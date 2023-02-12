using AutoMapper;
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
        private readonly IWebHostEnvironment _hostEnvironment;


        public HomeController(ILogger<HomeController> logger, UserRepository userRepository, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            this.userRepository = userRepository;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index(LoginRequest request, Usuarios userr)
        {
            if(User.Identity != null && !string.IsNullOrEmpty(User.Identity.Name) && userr.ProfilePic == null) 
            {
                Usuarios user = new Usuarios();
                user.Username = request.Username != null ? request.Username : User.Identity.Name;
                user = userRepository.GetUserInfo(user);
                return View(user);
            }
            if (User.Identity != null && !string.IsNullOrEmpty(User.Identity.Name) && userr.ProfilePic != null)
            {
                Usuarios user = new Usuarios();
                user.Username = request.Username != null ? request.Username : User.Identity.Name;
                user = userRepository.GetUserInfo(user);
                user.ProfilePic = userr.ProfilePic;
                return View(user);
            }
            return RedirectToAction("Index", "Login");
        }

        
        public IActionResult PictureManagement(Usuarios user) 
        {

            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(user.ProfilePicFile.FileName);
            string extension = Path.GetExtension(user.ProfilePicFile.FileName);
            user.ProfilePic = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create)) 
            {
                user.ProfilePicFile.CopyTo(fileStream);
            }
            return RedirectToAction("Index", "Home", user);
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