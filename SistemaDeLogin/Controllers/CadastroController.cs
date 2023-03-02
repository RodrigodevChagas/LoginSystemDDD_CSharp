using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SistemaDeLogin.AplicationIdentity.Dtos;
using SistemaDeLogin.ApplicationIdentity.Interfaces;

namespace SistemaDeLogin.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ICadastroService _cadastroService;

        public CadastroController(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated) { return RedirectToAction("Index", "Home"); }
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUsuarioDto createUsuarioDto) {
            if (!ModelState.IsValid)
                return View("Index");

            Result user = _cadastroService.CreateUser(createUsuarioDto);
            if (user.IsSuccess)  return RedirectToAction("Index", "Login", new { area = "" });
            return View("Index");
        }
    }
}
