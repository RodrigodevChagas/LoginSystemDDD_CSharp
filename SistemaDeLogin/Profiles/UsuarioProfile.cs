using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SistemaDeLogin.Data.Dtos;
using SistemaDeLogin.Models;

namespace SistemaDeLogin.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
         
            CreateMap<CreateUsuarioDto, Usuarios>();
            CreateMap<Usuarios, IdentityUser<int>>();
        }
    }
}
