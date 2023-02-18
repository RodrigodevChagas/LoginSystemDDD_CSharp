using FluentResults;
using SistemaDeLogin.Domain.EntitiesIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLogin.Infra.Data.Interface
{
    public interface IUserRepository
    {
        Result UploadProfilePic(Usuarios user, string path);
        Usuarios GetUserInfo(Usuarios user);
    }
}
