using AutoMapper;
using SistemaDeLogin.ApplicationIdentity.ViewModels;
using SistemaDeLogin.Domain.EntitiesIdentity;

namespace SistemaDeLogin.ApplicationIdentity.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, Usuarios>();
        }
    }
}
