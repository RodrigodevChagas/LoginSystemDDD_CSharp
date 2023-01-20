using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SistemaDeLogin.Data.Dtos;
using SistemaDeLogin.Services;

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
            Result user = _cadastroService.CreateUser(createUsuarioDto);
            if (user.IsSuccess)  return RedirectToAction("Index", "Login", new { area = "" });
            return View("Index");
        }
    }
}
