using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaDeLogin.AplicationIdentity.Dtos;
using SistemaDeLogin.ApplicationIdentity.Interfaces;
using SistemaDeLogin.Data.Requests;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.Data.Context;

namespace SistemaDeLogin.ApplicationIdentity.Services
{
    public class CadastroService : ICadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private DataContextDashBoard dbSet;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, DataContextDashBoard dbSet)
        {
            _mapper = mapper;
            _userManager = userManager;
            this.dbSet = dbSet;
        }

        public Result CreateUser(CreateUsuarioDto createUsuarioDto)
        {
            
            Usuarios usuario = _mapper.Map<Usuarios>(createUsuarioDto);
            

            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            
            Task<IdentityResult> ResultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createUsuarioDto.Password);

            if (ResultadoIdentity.Result.Succeeded) {

                dbSet.Users.Add(usuario);
                dbSet.SaveChanges();
                var code =  _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                return Result.Ok()
                    .WithSuccess(code);
            } 
            
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result AtivaUsuario(AtivaContaRequest request)
        {
            var IdentityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.Id);

            if (IdentityUser == null) return Result.Fail("Usuario com campo(s) nulo(s)"); 
                
            var IdentityResult = _userManager.ConfirmEmailAsync(IdentityUser, request.CodigoDeAtivacao).Result;


            return IdentityResult.Succeeded ?  Result.Ok() :  Result.Fail("Falha ao ativar conta de usuario");
        }
    }
}
