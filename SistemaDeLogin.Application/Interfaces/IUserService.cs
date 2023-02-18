using FluentResults;
using SistemaDeLogin.Domain.EntitiesIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLogin.ApplicationIdentity.Interfaces
{
    public interface IUserService
    {
        Result UploadProfilePic(Usuarios user, string RootPath);
    }
}
