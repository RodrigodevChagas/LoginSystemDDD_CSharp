using AutoMapper;
using SistemaDeLogin.ApplicationIdentity.ViewModels;
using SistemaDeLogin.Domain.EntitiesIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLogin.ApplicationIdentity.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuarios, UserViewModel>();
        }
    }
}
