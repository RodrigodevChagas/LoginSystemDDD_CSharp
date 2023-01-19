using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SistemaDeLogin.Services;

namespace SistemaDeLogin.Controllers
{
    public class LoginController : Controller {

        private readonly LoginService loginService;

        public LoginController(LoginService loginService)
        {
            this.loginService = loginService;
        }
        
        public IActionResult Index() { 
        
            return View();
        }


        [HttpPost]
        public IActionResult LogaUsuario(string usuario, string senha)
        {

            Result resultado = loginService.LogaUsuario(usuario, senha);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Json(new { Msg = "Usuario logado com sucesso" });
        }

                //protected readonly ILoginRepositorio loginRepositorio;



        //    [HttpPost]
        //    public IActionResult LogaUsuario(LoginRequest request)
        //    {

        //        Result resultado = _loginService.LogaUsuario(request);
        //        if (resultado.IsFailed) return Unauthorized(resultado.Errors);
        //        return Ok(resultado.Successes.First());
        //    }

        //    //[HttpPost]
        //    //public async Task<IActionResult> Logar(string username, string senha) {

        //    //    var user = loginRepositorio.BuscaUsuario(username, senha);
        //    //    if (user == null) return Json(new { Msg = "Usuario nao logado" });

        //    //    int userId = user.Id;
        //    //    string userUsername = user.Username!;

        //    //    List<Claim> direitosDeAcesso = new List<Claim> { 
        //    //        new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
        //    //        new Claim(ClaimTypes.Name, userUsername),
        //    //    };

        //    //    var identity = new ClaimsIdentity(direitosDeAcesso, "Identity.Login");
        //    //    var userPrincipal = new ClaimsPrincipal(new[] { identity });

        //    //    await HttpContext.SignInAsync(userPrincipal,
        //    //        new AuthenticationProperties 
        //    //        {
        //    //            IsPersistent = false,
        //    //            ExpiresUtc = DateTime.Now.AddHours(2),
        //    //        });

        //    //    return Json(new { Msg = "Usuario logado com sucesso" });

        //    //}

        //    public async Task<IActionResult> Logout() {

        //        if (User.Identity != null && User.Identity.IsAuthenticated) {
        //            await HttpContext.SignOutAsync();
        //        }
        //        return RedirectToAction("Index", "Login");

        //    }

    }
}
