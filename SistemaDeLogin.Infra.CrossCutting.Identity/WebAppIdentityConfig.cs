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

            services.AddIdentityServer().AddApiAuthorization<IdentityUser<int>, DbContextApiAuth>();
            //services.AddScoped<ProfileService<UserApiAuth>>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn")),
                    ValidateIssuer = true,
                    ValidIssuer = "suaIssuer",
                    ValidateAudience = true,
                    ValidAudience = "suaAudience",
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            //services.AddAuthentication().AddIdentityServerJwt().AddGoogle(googleOptions =>
            //{
            //    googleOptions.ClientId = "904390947652-8o1b7cotbchllers2pjkpc2dlhcfemai.apps.googleusercontent.com";
            //    googleOptions.ClientSecret = "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";
            //});

        }
    }
}

