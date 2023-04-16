using FluentResults;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SistemaDeLogin.AplicationIdentity.Requests;
using SistemaDeLogin.ApplicationIdentity.Interfaces;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.CrossCutting.Identity.ConfigEmail;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SistemaDeLogin.ApplicationIdentity.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IEmailServices _emailService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService, IEmailServices emailService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
        }

        public async Task<Result> LoginUser(LoginRequest request)
        {
            var resultadoIdentity = await _signInManager.PasswordSignInAsync(request.Username, request.Password, true, false);
            if (resultadoIdentity.IsNotAllowed | string.IsNullOrEmpty(request.Username)) 
                return Result.Fail("Login Failed");
            
            IdentityUser<int> identityUser = _signInManager.UserManager.Users
                .FirstOrDefault( identidade => identidade.NormalizedUserName == request.Username!.ToUpper())!;

            Token token = _tokenService.CreateToken(identityUser);

            await _signInManager.SignInAsync(identityUser, authentication(), CookieAuthenticationDefaults.AuthenticationScheme);
            
            return Result.Ok().WithSuccess(token.Value);
        }

        public Result LogoutUser()
        {
            var resultadoIdentity = _signInManager.SignOutAsync();
            if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Login Failed");
        }

        static AuthenticationProperties authentication() 
        {
            var authProps = new AuthenticationProperties();
            authProps.IsPersistent = true;
            authProps.ExpiresUtc = DateTime.Now.AddDays(1);
            return authProps;
        }

    }
}
