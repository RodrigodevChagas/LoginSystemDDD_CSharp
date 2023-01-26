using Microsoft.Extensions.DependencyInjection;
using SistemaDeLogin.Services;
using MediatR;

namespace SistemaDeLogin.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<CadastroService, CadastroService>();
            services.AddScoped<LoginService, LoginService>();
            services.AddScoped<TokenService, TokenService>();

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
