using Microsoft.Extensions.DependencyInjection;
using MediatR;
using SistemaDeLogin.ApplicationIdentity.Services;
using SistemaDeLogin.Infra.Data.Repository;
using SistemaDeLogin.ApplicationIdentity.Interfaces;

namespace SistemaDeLogin.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<CadastroService, CadastroService>();
            services.AddScoped<LoginService, LoginService>();
            services.AddScoped<EmailServices, EmailServices>();
            services.AddScoped<TokenService, TokenService>();
            services.AddScoped<UserService, UserService>();
            services.AddScoped<UserRepository, UserRepository>();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
