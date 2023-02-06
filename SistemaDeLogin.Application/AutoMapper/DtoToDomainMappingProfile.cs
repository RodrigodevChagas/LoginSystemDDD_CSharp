using AutoMapper;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.AplicationIdentity.Dtos;
using SistemaDeLogin.ApplicationIdentity.Dtos;
using SistemaDeLogin.AplicationIdentity.Requests;

namespace SistemaDeLogin.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<CreateUsuarioDto, Usuarios>();
            CreateMap<LoginRequest, Usuarios>();
            
        }
    }
}
