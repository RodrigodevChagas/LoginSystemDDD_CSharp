using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SistemaDeLogin.AplicationIdentity.Dtos;
using SistemaDeLogin.ApplicationIdentity.Services;

namespace SistemaDeLogin.Controllers
{
    public class CadastroController : Controller
    {
        private readonly CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        public IActionResult Index()
        {
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
