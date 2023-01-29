using Microsoft.AspNetCore.Identity;
using SistemaDeLogin.Domain.EntitiesIdentity;

namespace SistemaDeLogin.Application.Interfaces
{
    public interface ITokenServices
    {
        Token CreateToken(IdentityUser<int> usuario);
    }
}
