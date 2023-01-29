using FluentResults;
using Microsoft.AspNetCore.Identity;
using SistemaDeLogin.AplicationIdentity.Requests;
using SistemaDeLogin.Domain.EntitiesIdentity;

namespace SistemaDeLogin.ApplicationIdentity.Services
{
    public class LoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        
        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded && request.Username != null) {
                IdentityUser<int> identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(identidade => identidade.NormalizedUserName == request.Username.ToUpper())!;
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Não foi possivel logar o usuario");
        }
        public Result LogoutUsuario()
        {
            var resultadoIdentity = _signInManager.SignOutAsync();
            if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Logout Falhou");
        }
    }
}
