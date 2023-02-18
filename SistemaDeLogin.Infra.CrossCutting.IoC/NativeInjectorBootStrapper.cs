using Microsoft.Extensions.DependencyInjection;
using MediatR;
using SistemaDeLogin.ApplicationIdentity.Services;
using SistemaDeLogin.Infra.Data.Repository;
using SistemaDeLogin.ApplicationIdentity.Interfaces;
using SistemaDeLogin.Infra.Data.Interface;

namespace SistemaDeLogin.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICadastroService, CadastroService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IEmailServices, EmailServices>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<TokenService>();

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
