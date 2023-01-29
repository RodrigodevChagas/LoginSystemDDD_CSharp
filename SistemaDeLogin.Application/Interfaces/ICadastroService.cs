using FluentResults;
using SistemaDeLogin.AplicationIdentity.Dtos;
using SistemaDeLogin.Data.Requests;

namespace SistemaDeLogin.ApplicationIdentity.Interfaces
{
    public interface ICadastroService
    {
        Result CreateUser(CreateUsuarioDto createUsuarioDto);
        Result AtivaUsuario(AtivaContaRequest request);
    }
}
