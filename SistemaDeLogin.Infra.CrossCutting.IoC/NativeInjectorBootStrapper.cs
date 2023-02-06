using Microsoft.Extensions.DependencyInjection;
using MediatR;
using SistemaDeLogin.ApplicationIdentity.Services;
using SistemaDeLogin.Infra.Data.Repository;

namespace SistemaDeLogin.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<CadastroService, CadastroService>();
            services.AddScoped<LoginService, LoginService>();
            services.AddScoped<TokenService, TokenService>();
            services.AddScoped<UserRepository, UserRepository>();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
