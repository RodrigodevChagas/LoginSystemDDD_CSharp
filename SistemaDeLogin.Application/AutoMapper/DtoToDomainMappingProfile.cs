using AutoMapper;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.AplicationIdentity.Dtos;

namespace SistemaDeLogin.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<CreateUsuarioDto, Usuarios>();
        }
    }
}
