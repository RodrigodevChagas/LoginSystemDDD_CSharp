using FluentResults;
using SistemaDeLogin.AplicationIdentity.Requests;

namespace SistemaDeLogin.ApplicationIdentity.Interfaces
{
    public interface ILoginService
    {
        Task<Result> LoginUser(LoginRequest request);
        Result LogoutUser();
    }
}
