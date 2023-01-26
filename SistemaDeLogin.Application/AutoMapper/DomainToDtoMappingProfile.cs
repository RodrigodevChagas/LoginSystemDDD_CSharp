using AutoMapper;

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