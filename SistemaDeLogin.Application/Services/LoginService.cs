using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SistemaDeLogin.AplicationIdentity.Requests;
using SistemaDeLogin.Application.Interfaces;
using SistemaDeLogin.Domain.EntitiesIdentity;
using System.Security.Claims;

namespace SistemaDeLogin.ApplicationIdentity.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        
        public async Task<Result> LoginUser(LoginRequest request)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(request.Username, request.Password, true, false);
            if (resultadoIdentity.Result.Succeeded && request.Username != null) {
                IdentityUser<int> identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(identidade => identidade.NormalizedUserName == request.Username.ToUpper())!;
                Token token = _tokenService.CreateToken(identityUser);

                await _signInManager.SignInAsync(identityUser, true);
                var userPrincial =  _signInManager.CreateUserPrincipalAsync(identityUser);
                var eaioooo =  _signInManager.IsSignedIn(userPrincial.Result);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login Failed");
        }

        public Result LogoutUser()
        {
            var resultadoIdentity = _signInManager.SignOutAsync();
            if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Login Failed");
        }
    }
}
