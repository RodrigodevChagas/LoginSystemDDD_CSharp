using AutoMapper;
using SistemaDeLogin.Domain.EntitiesIdentity;
using Microsoft.AspNetCore.Identity;


namespace SistemaDeLogin.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Usuarios, IdentityUser<int>>();
        }
    }
}