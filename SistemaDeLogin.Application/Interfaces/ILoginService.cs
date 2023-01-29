using FluentResults;
using SistemaDeLogin.AplicationIdentity.Requests;

namespace SistemaDeLogin.Application.Interfaces
{
    public interface ILoginService
    {
        Result LogaUsuario(LoginRequest request);
        Result LogoutUsuario();
    }
}
