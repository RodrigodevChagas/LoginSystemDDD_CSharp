using FluentResults;
using Microsoft.AspNetCore.Identity;
using SistemaDeLogin.Data.Requests;
using SistemaDeLogin.Models;
using SistemaDeLogin.Services;

namespace SistemaDeLogin.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        
        public Result LogaUsuario(string usuario, string senha)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(usuario, senha, false, false);
            if (resultadoIdentity.Result.Succeeded) {
                IdentityUser<int> identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(identidade => identidade.NormalizedUserName == usuario.ToUpper())!;
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Não foi possivel logar o usuario");
        }
    }
}
