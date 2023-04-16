using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.DataIdentity.Context;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Duende.IdentityServer.AspNetIdentity;
using System.Security.Policy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace SistemaDeLogin.Infra.CrossCutting.Identity
{
    public static class WebAppIdentityConfig
    {
        public static void AddWebAppIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //Add Identity Db Context
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>
                (opt => opt.SignIn.RequireConfirmedEmail = false)
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;

                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            //services.AddIdentity<UserApiAuth, IdentityRole>()
            //.AddEntityFrameworkStores<DbContextApiAuth>()
            //.AddDefaultTokenProviders();

            //services.AddScoped<ProfileService<UserApiAuth>>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "myapp-auth-cookie"; // define o nome do cookie
                options.Cookie.HttpOnly = true; // define se o cookie é acessível somente pelo HTTP
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // define a política de segurança do cookie
                options.Cookie.SameSite = SameSiteMode.Strict; // define o modo SameSite do cookie
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
            });

            //services.AddAuthentication().AddIdentityServerJwt().AddGoogle(googleOptions =>
            //{
            //    googleOptions.ClientId = "904390947652-8o1b7cotbchllers2pjkpc2dlhcfemai.apps.googleusercontent.com";
            //    googleOptions.ClientSecret = "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";
            //});

        }
    }
}

