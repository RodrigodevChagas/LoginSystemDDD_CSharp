using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SistemaDeLogin.AplicationIdentity.Requests;
using SistemaDeLogin.Application.Interfaces;
using SistemaDeLogin.ApplicationIdentity.ViewModels;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.Data.Repository;
using System.Security.Claims;

namespace SistemaDeLogin.ApplicationIdentity.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly LoginRepository _loginRepository;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService, LoginRepository loginRepository, IMapper mapper)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _loginRepository = loginRepository;
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

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login Failed");
        }

        public UserViewModel SearchUserInfo(UserViewModel user) 
        {
            var map = _mapper.Map<Usuarios>(user);
            UserViewModel mapT = _mapper.Map<UserViewModel>(_loginRepository.SearchUserInfo(map));
            return mapT;
        }
        public Result LogoutUser()
        {
            var resultadoIdentity = _signInManager.SignOutAsync();
            if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Login Failed");
        }
    }
}
